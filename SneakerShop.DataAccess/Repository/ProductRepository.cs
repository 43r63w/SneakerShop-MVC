using SneakerShop.DataAccess.Data;
using SneakerShop.DataAccess.Repository.IRepository;
using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> Search(string keyword)
        {
            return _context.Products.Where(u=>u.Model.Contains(keyword)||u.Name.Contains(keyword)).ToList();
        }

        public void Update(Product obj)
        {
            _context.Products.Update(obj);
        }
    }
}
