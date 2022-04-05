﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserGroupsManagment.ViewModels
{
    public class CreateUserViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
