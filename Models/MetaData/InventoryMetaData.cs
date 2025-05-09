﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfMVVM.Models.MetaData
{
    public class InventoryMetaData
    {
        [StringLength(50, ErrorMessage = "Please enter a value less than 50 characters long.")]
        [Display(Name = "Pet Name")]
        public string PetName;

        [StringLength(50, ErrorMessage = "Please enter a value less than 50 characters long.")]
        public string Make;
    }
}
