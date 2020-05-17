using System;
using System.Collections.Generic;
using System.Text;
using LemonTest.Model;
using LemonTest.EntityFramework;
using LemonTest.Application.Dto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LemonTest.Application
{
    public class ProductService : IProductService
    {
        private readonly LemonTestDbContext _context;

        public ProductService(LemonTestDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            List<ProductDto> productDto = new List<ProductDto>();

            var products = await _context.Products.ToListAsync();
            
            foreach(var product in products)
            {
                productDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    CategoryId = product.CategoryId
                });
            }

            return productDto;
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;

            return new ProductDto {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                CategoryId = product.CategoryId
            };
        }

        public async Task<ProductDto> Create(ProductDto dto)
        {
            Product product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = dto.CategoryId.Value
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                CategoryId = product.CategoryId
            };
        }

        public async Task<ProductDto> Update(ProductDto dto)
        {
            Product product = new Product
            {
                Id = dto.Id.Value,
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = dto.CategoryId.Value
            };

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(dto.Id.Value))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }


        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
