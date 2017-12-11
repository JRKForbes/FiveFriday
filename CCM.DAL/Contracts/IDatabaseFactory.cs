using System;

namespace CCM.DAL
{
    public interface IDatabaseFactory : IDisposable
    {
        CCMContext Get();
    }
}
