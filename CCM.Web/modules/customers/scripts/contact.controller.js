(function () {
	"use strict";

	function contactController(commonService, $window, $rootScope, $location, $scope, $timeout) {
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
		vm.CustomerList = [];
		vm.Customer = {};

		$scope.$on('$viewContentLoaded', function () {
		});

		function bind() {
		    var readApps = function (options) {
		        modelService.GetModels().then(function (data) {
		            options.success(data);
		        });
		    }

			vm.Add = function ($event) {
			    $event.preventDefault();

			};

			vm.edit = function($event, dataItem) {
			    $event.preventDefault();
			    $('#loadingModal').modal('show');
			    localStorage['x-currentModelId'] = dataItem.ModelId;
			    if (dataItem.ModelStatusId == "VariablesDefined") {
			        modelService.GetTraining(dataItem.ModelId).then(function (data) {
			            modelService.serviceData = data;
			            $location.path("/trainmodel");
			        });
			    }
			    else if (dataItem.ModelStatusId == "Trained") {
			        modelService.GetTestSamples(dataItem.ModelId).then(function (data) {
			            modelService.serviceData = data;
			            $location.path("/usemodel");
			        });
			    } else {
                    modelService.GetModelById(dataItem.ModelId).then(function (data) {
                        modelService.serviceData = data;
                        $location.path("/managemodel");
                    });
			    }
			}

		    //User functions
			vm.createNewUser = function () {
			    $('#userModal').modal('toggle');
			}

			vm.saveUser = function () {
			    if (vm.UnlockCode == "ATeam") {
			        commonService.PostUser(vm.User).then(function (data) {
			            if (data.IsError) {
			                console.log(data);
			                toastr.error(data.Result);
			            } else {
			                toastr.success(data.Result);
			            }
			        });
			    } else {
			        $timeout(function () {
			            toastr.error("Unlock Code Invalid. User Creation Failed");
			        }, 500);
			    }
			}
		}
		bind();
	}

	angular
		.module("app")
		.controller("ContactController", contactController);

	contactController.$inject = ["CommonService", "$window", "$rootScope", "$location", "$scope", "$timeout"];
})();