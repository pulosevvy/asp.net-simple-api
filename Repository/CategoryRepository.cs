﻿using PokemonReviewsApp.Data;
using PokemonReviewsApp.Interfaces;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

           return Save();
        }
        public bool UpdateCategory(Category category)
        {
            _context.Update(category);

            return Save();

        }
        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);

            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
