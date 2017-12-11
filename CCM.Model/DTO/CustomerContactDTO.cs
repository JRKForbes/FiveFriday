using System;
using System.Collections.Generic;

namespace CCM.Model
{
    public class CustomerContactDTO
    {
        public long CustomerContactID { get; set; }

        public long CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
    }
}
