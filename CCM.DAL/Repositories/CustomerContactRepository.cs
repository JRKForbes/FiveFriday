using CCM.Model;

namespace CCM.DAL
{
    public class CustomerContactRepository : Repository<CustomerContact>, ICustomerContactRepository
    {
        private CCMContext dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public CustomerContactRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected CCMContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }
    public interface ICustomerContactRepository : IRepository<CustomerContact>
    {
    }
}
