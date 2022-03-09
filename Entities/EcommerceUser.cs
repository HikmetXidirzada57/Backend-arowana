﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Entities
{
    public class EcommerceUser:IdentityUser
    {
        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; }=string.Empty;

        public string Adress { get; set; }
    }
}
