﻿using BlogApp.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Account:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
       
    }
}
