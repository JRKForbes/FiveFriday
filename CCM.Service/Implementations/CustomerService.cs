using System;
using System.Collections.Generic;
using System.Linq;
using CCM.DAL;
using CCM.Model;

namespace CCM.Service
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;
        private ICustomerRepository _customerRep;
        private ICustomerContactRepository _customerContactRep;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRep, ICustomerContactRepository customerContactRep)
        {
            this._unitOfWork = unitOfWork;
            this._customerRep = customerRep;
            this._customerContactRep = customerContactRep;
        }

        public ReturnDTO SaveOrUpdateCustomer(CustomerDTO dto)
        {
            ReturnDTO result = new ReturnDTO();

            Customer obj = _customerRep.GetMany(x => x.CustomerID == dto.CustomerID).FirstOrDefault();

            if (obj == null)
            {
                obj = new Customer();
            }
            else
            {
                dto.CustomerID = obj.CustomerID;
            }
            //populate the object
            obj.CustomerName = dto.CustomerName;
            obj.Longitude = dto.Longitude;
            obj.Latitude = dto.Latitude;

            if (obj.CustomerID > 0)
            {
                _customerRep.Update(obj);
            }
            else
            {
                _customerRep.Add(obj);
            }
            _unitOfWork.Commit();

            if (obj. CustomerID > 0) 
            {
                result.Result = "Customer Saved Successfully";
                result.Id = obj.CustomerID;
            }

            return result;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> result = new List<CustomerDTO>();

            List<Customer> list = _customerRep.GetAll().ToList();
            foreach (var m in list)
            {
                result.Add(Transfer(m));
            }

            return result;
        }

        public CustomerDTO GetCustomerByID(long customerID)
        {
            CustomerDTO result = new CustomerDTO();

            Customer customer = _customerRep.GetMany(x => x.CustomerID == customerID).FirstOrDefault();
            if (customer != null)
            {
                result = Transfer(customer);
            }

            return result;
        }

        public List<CustomerContactDTO> GetCustomerContacts(long customerID)
        {
            List<CustomerContactDTO> result = new List<CustomerContactDTO>();

            List<CustomerContact> list = _customerContactRep.GetMany(x => x.CustomerID == customerID).ToList();
            foreach (var m in list)
            {
                result.Add(Transfer(m));
            }

            return result;
        }

        public ReturnDTO SaveOrUpdateCustomerContact(CustomerContactDTO dto)
        {
            ReturnDTO result = new ReturnDTO();

            CustomerContact obj = _customerContactRep.GetMany(x => x.CustomerContactID == dto.CustomerContactID).FirstOrDefault();

            if (obj == null)
            {
                obj = new CustomerContact();
            }
            else
            {
                dto.CustomerContactID = obj.CustomerContactID;
            }
            //populate the object
            obj.CustomerID = dto.CustomerID;
            obj.ContactName = dto.ContactName;
            obj.EmailAddress = dto.EmailAddress;
            obj.ContactNumber = dto.ContactNumber;

            if (obj.CustomerContactID > 0)
            {
                _customerContactRep.Update(obj);
            }
            else
            {
                _customerContactRep.Add(obj);
            }
            _unitOfWork.Commit();
            
            if (obj.CustomerContactID > 0)
            {
                result.Result = "Contact Saved Successfully";
                result.Id = obj.CustomerID;
            }

            return result;
        }

        public CustomerContactDTO GetCustomerContactByID(long customerContactID)
        {
            CustomerContactDTO result = new CustomerContactDTO();

            CustomerContact contact = _customerContactRep.GetMany(x => x.CustomerContactID == customerContactID).FirstOrDefault();
            if (contact != null)
            {
                result = Transfer(contact);
            }

            return result;
        }

        private CustomerDTO Transfer(Customer m)
        {
            CustomerDTO result = new CustomerDTO();
            result.CustomerID = m.CustomerID;
            result.CustomerName = m.CustomerName;
            result.Latitude = m.Latitude;
            result.Longitude = m.Latitude;
            result.Contacts = GetCustomerContacts(m.CustomerID);

            return result;
        }

        private CustomerContactDTO Transfer(CustomerContact m)
        {
            CustomerContactDTO result = new CustomerContactDTO();
            result.CustomerContactID = m.CustomerContactID;
            result.CustomerID = m.CustomerID;
            result.ContactName = m.ContactName;
            result.EmailAddress = m.EmailAddress;
            result.ContactNumber = m.ContactNumber;

            return result;
        }
    }
}
