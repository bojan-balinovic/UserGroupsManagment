using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Entity;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Repository.Contractors;

namespace UserGroupsManagment.Repository
{
    public abstract class GenericRepository<TContext, Entity, IModel, Model, Filter> : IGenericRepository<TContext, Entity, IModel, Model, Filter>
          where TContext : DbContext
           where Entity : BaseEntity
           where IModel : IBaseModel
         where Model : IModel
          where Filter : GenericFilter
    {

        #region DIProperties
        public TContext Context { get; }
        public DbSet<Entity> DbSet { get; set; }
        public IMapper Mapper { get; }


        #endregion

        #region Constructor
        public GenericRepository(TContext context, DbSet<Entity> dbSet, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            DbSet = dbSet;

        }
        #endregion



        public virtual async Task<IModel> AddOne(IModel model)
        {
            if (model != null)
            {
                var entity = Mapper.Map<Entity>(model);
                entity.DateCreated = DateTime.Now;
                entity.DateModified = DateTime.Now;
                await DbSet.AddAsync(entity);
                await Context.SaveChangesAsync();
                return Mapper.Map<IModel>(entity);
            }
            return default;
        }

        public async Task<IModel> DeleteOne(int id)
        {

            Entity entity = DbSet.Find(id);
            
            if (entity != null)
            {
                DbSet.Remove(entity);
                await Context.SaveChangesAsync();
                var model = Mapper.Map<IModel>(entity);
                return model;
            }

            return default;
        }

        public virtual async Task<PaginationList<IModel>> GetManyByFilter(Filter filter, int currentPage = -1, string orderBy = "")
        {
            var entities = await HandleFiltering(filter);
            entities = HandleSorting(entities, orderBy);
            var models = Mapper.Map<IEnumerable<IModel>>(entities);
            currentPage = filter.CurrentPage != null ? (int)filter.CurrentPage : currentPage;
            int? pageSize = filter.PageSize != null ? filter.PageSize : null;
            var paginationList = new PaginationList<IModel>(models.ToList(), currentPage, pageSize);
            return await Task.FromResult(paginationList);
        }

        public virtual async Task<IModel> GetOne(int id)
        {
            var vehicleEntity = await DbSet.FindAsync(id);

            var vehicle = Mapper.Map<IModel>(vehicleEntity);

            return vehicle;
        }

        #region Filtering and sorting entities
        public async virtual Task<IQueryable<Entity>> HandleFiltering(Filter filter)
        {
            IQueryable<Entity> entities;

            if (filter.UserId != null)
            {
                entities = DbSet.Where(e => (Guid)e.GetType().GetType().GetProperty("UserId").GetValue(e, null) == filter.UserId);
            }
            else
            {
                entities = DbSet;
            }



            return await Task.FromResult(entities);
        }



        public IQueryable<Entity> HandleSorting(IQueryable<Entity> entities, string orderBy)
        {

            if (orderBy == "date_created_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateCreated);
            }
            else if (orderBy == "date_created")
            {
                entities = entities.OrderBy(vm => vm.DateCreated);
            }
            else if (orderBy == "date_modified_desc")
            {
                entities = entities.OrderByDescending(vm => vm.DateModified);
            }
            else if (orderBy == "date_modified")
            {
                entities = entities.OrderBy(vm => vm.DateModified);
            }

            return entities;
        }
        #endregion

        public virtual async Task<IModel> UpdateOne(IModel model)
        {
            if (model != null)
            {
                var entity = Mapper.Map<Entity>(model);
                entity.DateModified = DateTime.UtcNow;

                var entityEntry = DbSet.Attach(entity);
                entityEntry.State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return model;
            }
            return default;
        }


        public async Task<IModel> GetOneByFilter(Filter filter)
        {
            var entities = await HandleFiltering(filter);
            entities = HandleSorting(entities, filter.OrderBy);
            var models = Mapper.Map<IEnumerable<IModel>>(entities);
            return await Task.FromResult(models.First());
        }

        public async Task<IEnumerable<IModel>> GetAll(Filter filter = null, int currentPage = -1, string orderBy = "")
        {
            IQueryable<Entity> entities = DbSet;

            if (filter != null)
            {
                entities = await HandleFiltering(filter);
                entities = HandleSorting(entities, orderBy);
            }

            var models = Mapper.Map<IEnumerable<IModel>>(entities);
            return models;
        }
    }
}