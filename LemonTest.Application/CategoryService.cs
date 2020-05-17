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
    public class CategoryService : ICategoryService
    {
        private readonly LemonTestDbContext _context;

        public CategoryService(LemonTestDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            List<CategoryDto> CategoryDto = new List<CategoryDto>();

            var categories = await _context.Categories.ToListAsync();

            foreach (var category in categories)
            {
                CategoryDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });
            }

            return CategoryDto;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task<CategoryDto> Create(CategoryDto dto)
        {
            Category category = new Category
            {
                CategoryName = dto.CategoryName
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task<CategoryDto> Update(CategoryDto dto)
        {
            Category category = new Category
            {
                Id = dto.Id.Value,
                CategoryName = dto.CategoryName
            };

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(dto.Id.Value))
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
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
