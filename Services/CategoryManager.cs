using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager
    {

        private readonly ApplicationDbContext _context;

        public CategoryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Categories category)
        {
            _context.Categoryes.Add(category);
            _context.SaveChanges();
        }
        public void Update(Categories category)
        {
            _context.Categoryes.Update(category);
            _context.SaveChanges(true);
        }
        public void Delete(Categories category)
        {
            category.IsDeleted = true;
            _context.SaveChanges();
        }
       
        public List<Categories>  GetAll()
        {
            return _context.Categoryes.Where(x=>!x.IsDeleted).ToList();
        }
        public Categories GetById(int? id)
        {
            var selectedCategory = _context.Categoryes.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);

            return selectedCategory;
        }
        public bool CategorytExists(int id)
        {
            return _context.Categoryes.Any(e => e.Id == id);
        }


    }
}
