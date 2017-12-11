using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Model
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public IList<CustomerContact> CustomerContacts { get; set; }
    }
}
