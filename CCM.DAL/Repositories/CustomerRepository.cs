using CCM.Model;

namespace CCM.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private CCMContext dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public CustomerRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected CCMContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
