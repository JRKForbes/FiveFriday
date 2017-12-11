using System;
using System.Collections.Generic;
using CCM.Model;

namespace CCM.Service
{
    public interface ICustomerService
    {
        ReturnDTO SaveOrUpdateCustomer(CustomerDTO dto);
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerByID(long customerID);
        List<CustomerContactDTO> GetCustomerContacts(long customerID);
        ReturnDTO SaveOrUpdateCustomerContact(CustomerContactDTO dto);
        CustomerContactDTO GetCustomerContactByID(long customerContactID);
    }
}
