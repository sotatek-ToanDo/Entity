﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public  int CategoryId { get; set; }
        [StringLength(100)]
        public string Name { set; get; }
        [Column(TypeName ="ntext")]
        public string Description { set; get; }
        //collect navigation
        public virtual List<Product> Products { get; set; }
    }
}
