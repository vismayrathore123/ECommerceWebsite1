
using ECommerceWebsite.DataAccessLayer.Infrastructure.IRepository;


namespace ECommerceWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }

        public IProdcutRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }

        public void Save()
        {
          _context.SaveChanges();
        }
    }
}
