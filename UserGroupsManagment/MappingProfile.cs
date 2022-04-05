﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.ViewModels;

namespace UserGroupsManagment
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserViewModel, User>();
        }
    }
}