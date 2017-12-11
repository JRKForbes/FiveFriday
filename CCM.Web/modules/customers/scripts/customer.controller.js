(function () {
	"use strict";

	function customerController(commonService, $window, $rootScope, $location, $scope, $timeout) {
		toastr.options = {
			"closeButton": true,
			"debug": false,
			"positionClass": "toast-top-right",
			"onclick": null,
			"showDuration": "1000",
			"hideDuration": "1000",
			"timeOut": "5000",
			"extendedTimeOut": "1000",
			"showEasing": "swing",
			"hideEasing": "linear",
			"showMethod": "fadeIn",
			"hideMethod": "fadeOut"
		};

		var vm = this;
		vm.Heading = "Customers";
		vm.IsCustomer = true;
		vm.Customer = {};
	    vm.list = [];
		vm.Item = {};

		$scope.$on('$viewContentLoaded', function () {
		});

		function bind() {
		    vm.readApps = function () {
		        vm.loading = true;
		        if (vm.IsCustomer) {
		            commonService.GetCustomers().then(function (data) {
		                vm.list = data;
		                vm.loading = false;
		            });
		        } else {
		            commonService.GetContacts(vm.Customer.CustomerID).then(function (data) {
		                vm.list = data;
		                vm.loading = false;
		            });
		        }
		    }

		    vm.Add = function () {
		        vm.Item = {};
		        if (!vm.IsCustomer) vm.Item.CustomerID = vm.Customer.CustomerID;
		        $('#editmodal').modal('toggle');
			};

			vm.edit = function(item) {
			    vm.Item = item;
			    $('#editmodal').modal('toggle');
			}

			vm.contacts = function (customer) {
			    vm.Customer = customer;

			    vm.Heading = "Contacts for " + customer.CustomerName;
			    vm.IsCustomer = false;
			    vm.readApps();
			}

			vm.back = function () {
			    vm.Heading = "Customers";
			    vm.IsCustomer = true;
			    vm.readApps();
			}
            
			vm.save = function () {
			    if (vm.IsCustomer) {
			        commonService.PostCustomer(vm.Item).then(function (data) {
			            if (data.IsError) {
			                console.log(data);
			                toastr.error(data.Result);
			            } else {
			                toastr.success(data.Result);
			            }
			            vm.readApps();
			        });
			    } else {
			        commonService.PostContact(vm.Item).then(function (data) {
			            if (data.IsError) {
			                console.log(data);
			                toastr.error(data.Result);
			            } else {
			                toastr.success(data.Result);
			            }
			            vm.readApps();
			        });
			    }
			}
		}
		bind();
		vm.readApps();
	}

	angular
		.module("app")
		.controller("CustomerController", customerController);

	customerController.$inject = ["CommonService", "$window", "$rootScope", "$location", "$scope", "$timeout"];
})();