(function () {
    "use strict";

    function commonService($http) {
        var service = {};
        var url = $("#baseUrl").val() + "/customer";
        var data = [];

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }

        function getCustomers() {
            return $http({
                method: "GET",
                url: url + "?list=1",
                datatype: "jsonp"
            }).then(handleSuccess, handleError("Error getting all customers"));
        }

        function getContacts(customerID) {
            return $http({
                method: "GET",
                url: url + "?contacts=1&customerID=" + customerID,
                datatype: "jsonp"
            }).then(handleSuccess, handleError("Error getting all customer contacts"));
        }

        function getCustomer(customerID) {
            return $http({
                method: "GET",
                url: url + "?customer=1&customerID=" + customerID,
                datatype: "jsonp"
            }).then(handleSuccess, handleError("Error getting customer"));
        }

        function getContact(contactID) {
            return $http({
                method: "GET",
                url: url + "?fetch=1&contactID=" + customerID,
                datatype: "jsonp"
            }).then(handleSuccess, handleError("Error getting customer contact"));
        }

        function postCustomer(customer) {
            return $http({
                method: "POST",
                url: url,
                data: customer,
                headers: {
                    'Content-Type': "application/json; charset=UTF-8"
                }
            })
            .then(handleSuccess, handleError("Error creating customer"));
        }

        function postContact(contact) {
            return $http({
                method: "POST",
                url: url + "?contact=1",
                data: contact,
                headers: {
                    'Content-Type': "application/json; charset=UTF-8"
                }
            })
            .then(handleSuccess, handleError("Error creating contact"));
        }

        service.GetCustomers = getCustomers;
        service.GetContacts = getContacts;
        service.GetCustomer = getCustomer;
        service.GetContact = getContact;
        service.PostCustomer = postCustomer;
        service.PostContact = postContact;

        service.Data = data;

        return service;
    }

    angular
		.module("app")
		.factory("CommonService", commonService);

    commonService.$inject = ["$http"];
})();