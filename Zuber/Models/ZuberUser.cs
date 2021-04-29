﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class ZuberUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string PhoneNo { get; set; }
        //password needs to be hashed
        [Required]
        public string Password { get; set; }
    }
}