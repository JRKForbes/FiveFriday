using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CCM.Service;
using CCM.Model;

namespace CCM.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        
        public ReturnDTO Post(CustomerDTO dto)
        {
            return _customerService.SaveOrUpdateCustomer(dto);
        }

        public ReturnDTO PostContact(string contact, CustomerContactDTO dto)
        {
            return _customerService.SaveOrUpdateCustomerContact(dto);
        }

        public IEnumerable<CustomerDTO> Get(string list)
        {
            return _customerService.GetAllCustomers();
        }

        public CustomerDTO GetCustomer(string customer, long customerID)
        {
            return _customerService.GetCustomerByID(customerID);
        }

        public IEnumerable<CustomerContactDTO> GetContacts(string contacts, long customerID)
        {
            return _customerService.GetCustomerContacts(customerID);
        }

        public CustomerContactDTO GetCustomerContact(string fetch, long contactID)
        {
            return _customerService.GetCustomerContactByID(contactID);
        }
    }
}
