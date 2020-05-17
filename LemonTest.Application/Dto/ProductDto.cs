using System;
using System.Collections.Generic;
using System.Text;

namespace LemonTest.Application.Dto
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
