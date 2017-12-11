(function () {
    "use strict";

    function config($routeProvider, $locationProvider, $httpProvider, $logProvider) {
        $logProvider.debugEnabled(false);
        delete $httpProvider.defaults.headers.common["X-Requested-With"];

        $routeProvider
            .when("/", {
                controller: "CustomerController",
                templateUrl: "modules/customers/customer.view.html",
                controllerAs: "vm"
            })
            .otherwise({ redirectTo: "/" });
    }

    function run($rootScope, $location, $cookieStore, $http, Idle) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get("globals") || {};
        $http.defaults.headers.common['x-loginid'] = 'user';

        var request = {
            headers: {
                'x-loginid': 'user',
            }
        };
        $.ajaxSetup(request);
        // start watching when the app runs. also starts the Keepalive service by default.
     
        $rootScope.page = $location.path();


        $rootScope.$on("$locationChangeStart", function (event, next, current) {
            // redirect to login page if not logged in and trying to access a restricted page    
        });
    }
    angular
        .module("app", ["ngRoute", "ngSanitize", "ngCookies", "ui.bootstrap", "angularUtils.directives.dirPagination"])
        .config(config)
        .factory('$exceptionHandler', ['$log', function ($log) {
            return function myExceptionHandler(exception, cause) {
                $log.error(exception, cause);
            };
        }])
        .run(run)
        .directive('stringToNumber', function () {
            return {
                require: 'ngModel',
                link: function (scope, element, attrs, ngModel) {
                    ngModel.$parsers.push(function (value) {
                        return '' + value;
                    });
                    ngModel.$formatters.push(function (value) {
                        return parseFloat(value);
                    });
                }
            };
        });

    config.$inject = ["$routeProvider", "$locationProvider", "$httpProvider", "$logProvider", "$sceProvider"];
    run.$inject = ["$rootScope", "$location", "$cookieStore", "$http"];
})();