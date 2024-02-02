﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymProject.Areas.Identity.Data;

    public class AppUser : IdentityUser
    {
 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleId { get; set; }

    }


