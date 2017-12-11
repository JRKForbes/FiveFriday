using System;
using System.Collections.Generic;

namespace CCM.Model
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
            Contacts = new List<CustomerContactDTO>();
        }

        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        
        public List<CustomerContactDTO> Contacts { get; set; }
    }
}
