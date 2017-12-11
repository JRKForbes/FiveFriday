using System;

namespace CCM.DAL
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
