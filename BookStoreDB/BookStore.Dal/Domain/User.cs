﻿using BookStore.Dal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class User : BaseEntity
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserBook> UserBooks { get; set; }
        public List<Order> Orders { get; set; }
    }
    
}
