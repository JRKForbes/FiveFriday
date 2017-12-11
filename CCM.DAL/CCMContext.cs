using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using CCM.Model;

namespace CCM.DAL
{
    public class CCMContext : DbContext
    {
        public CCMContext() : base("DefaultConnection")
        {

        }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}", validationErrors.Entry.Entity.GetType().FullName,
                                          validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                if (ex.InnerException != null)
                {
                    Trace.TraceInformation(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        Trace.TraceInformation(ex.InnerException.InnerException.Message);
                    }
                }
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
    }
}
