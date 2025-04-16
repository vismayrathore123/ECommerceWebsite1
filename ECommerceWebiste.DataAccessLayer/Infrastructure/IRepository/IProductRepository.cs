﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWebsite.DataAccessLayer.Infrastructure.IRepository;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.DataAccessLayer.Infrastructure.IRepository
{
    public interface IProdcutRepository:IRepository<Product>
    {
        void Update(Product product);
        
    }
}
