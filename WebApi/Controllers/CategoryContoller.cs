using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/category")]
    public class CategoryContoller : Controller
    {
        List<Category> listOfCategories = new List<Category> {
                new Category{ Id=1,Title="Samsung1",DisplayOrder=1 },
                   new Category{ Id=2,Title="Samsung2",DisplayOrder=2 },
                      new Category{ Id=3,Title="Samsung3",DisplayOrder=3 },
                         new Category{ Id=4,Title="Samsung4",DisplayOrder=4 },
                            new Category{ Id=5,Title="Samsung5",DisplayOrder=5 },

            };

        private ApplicationDbContext _context;

        public CategoryContoller(ApplicationDbContext context)
        {
            _context = context;
        }
       // GET: api/values
       [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<Category> Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return _context.Categories;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IEnumerable<Category> Put(int id, [FromBody] Category category)
        {
            var categoryfromDb = _context.Categories.Find(id);
            if (categoryfromDb == null)
            {
                _context.Categories.Add(category);
            }
            else
            {
                categoryfromDb.Title = category.Title;
                categoryfromDb.DisplayOrder = category.DisplayOrder;
            }
            _context.SaveChanges();
            return _context.Categories;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IEnumerable<Category> Delete(int id)
        {
            var categoryfromDb = _context.Categories.Find(id);
            if(categoryfromDb == null) {
            }
            else {
                _context.Categories.Remove(categoryfromDb);
                _context.SaveChanges();
            }
            return _context.Categories;
        }
    }
}

