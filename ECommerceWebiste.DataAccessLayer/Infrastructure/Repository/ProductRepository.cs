﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWebsite.DataAccessLayer.Infrastructure.IRepository;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProdcutRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                if(product.ImageUrl != null)
                {
                    productDB.ImageUrl = product.ImageUrl;  
                }

            }
        }
    }
}
