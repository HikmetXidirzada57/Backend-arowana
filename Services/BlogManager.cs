using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogManager
    {
        private readonly ApplicationDbContext _context;

        public BlogManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Blog> FindBlogId(int? categoryId, int? blogId)
        {
            return _context.Blogs.Where(x => x.Id != blogId && x.BlogCategoyID == categoryId).ToList();

        }
        public Blog SingleBlog(int? id)
        {           
           var blog= _context.Blogs.FirstOrDefault(x => x.Id == id);
            if(blog == null) return null;

            return (blog);
        }
    }
}
