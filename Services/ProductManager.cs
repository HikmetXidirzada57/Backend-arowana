using DataAcces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager
    {
        private readonly ApplicationDbContext _context;

        public ProductManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges(true);
        }
        public void Delete(Product product)
        {
            product.IsDeleted = true;
            _context.SaveChanges();
        }
        public List<ProductPicture> GetProductPicture(List<int>picIds)
        {
            return _context.ProductPictures.Include(c=>c.Picture).Where(c=>picIds.Contains(c.PictureId)).ToList();
        }
        public List<Product> FindCategory(int? categoryId,int productId)
        {
            return _context.Products.Include(x=>x.Category).Include(c=>c.ProductPictures).ThenInclude(p=>p.Picture).Where(x=>x.Id!=productId && x.CategoryID==categoryId && !x.IsDeleted).ToList();
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.Include(x=>x.ProductPictures).ThenInclude(x=>x.Picture).Include(c => c.Category).Where(x => !x.IsDeleted).ToList();
        }
        public List<Blog> GetBlogs()
        {
            return _context.Blogs.ToList();
        }
        public Product GetProductId(int? id)
        {
            var productId = _context.Products.Include(x=>x.Category).Include(x=>x.ProductPictures).ThenInclude(x=>x.Picture).FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if(productId == null) return null;
            return(productId);
        }
        public List<Product> GetProductIds( IEnumerable<int> ids)
        {
            var selProduct = _context.Products.Include(x=>x.ProductPictures).ThenInclude(x=>x.Picture).Where(pr => ids.Contains(pr.Id)).ToList(); 
            
            return selProduct;
        }
        public List<Product> GetSlider()
        {
            return _context.Products.Where(x => x.IsSlider && !x.IsDeleted).OrderByDescending(x=>x.ModifiedOn).Take(6).ToList();
        }
        public List<Product> ProductNew(int count)
        {
            return _context.Products.Include(x => x.Category).Where(x => !x.IsDeleted).OrderByDescending(x => x.PublishDate).Take(count).ToList();
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
