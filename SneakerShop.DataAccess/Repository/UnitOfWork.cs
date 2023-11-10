using Microsoft.Identity.Client.Extensibility;
using SneakerShop.DataAccess.Data;
using SneakerShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IApplicationRepository ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }


        public UnitOfWork(ApplicationDbContext context
            )
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
            ProductImage = new ProductImageRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);    
            ApplicationUser = new ApplicationUserRepository(_context);  
            OrderHeader = new OrderHeaderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);  
           
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
