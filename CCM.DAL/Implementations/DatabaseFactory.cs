using System;

namespace CCM.DAL
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private CCMContext dataContext;

        public CCMContext Get()
        {
            return dataContext ?? (dataContext = new CCMContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
