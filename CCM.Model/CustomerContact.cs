using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Model
{
    public class CustomerContact
    {
        public long CustomerContactID { get; set; }

        public long CustomerID { get; set; }
        public Customer Customer { get; set; }

        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }

    }
}
