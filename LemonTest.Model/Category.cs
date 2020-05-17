using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LemonTest.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
