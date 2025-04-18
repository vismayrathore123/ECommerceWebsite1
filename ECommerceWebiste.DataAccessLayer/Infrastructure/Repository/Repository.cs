﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerceWebsite.DataAccessLayer.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;    

        public Repository(ApplicationDbContext context)
        {
            _context = context;
           
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {

            _dbSet.RemoveRange(entity);
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties=null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item.Trim());
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (includeProperties!=null)
            {
                foreach (var item in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item.Trim());
                }
            }

            return query.ToList();
        }

    }
}
