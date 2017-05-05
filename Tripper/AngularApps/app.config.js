angular.
  module('mainApp').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        //$locationProvider.hashPrefix('!');

        var delayObj = 
            {
                delay: function ($q, $timeout) {
                    var delay = $q.defer();
                    $timeout(delay.resolve, 1500);
                    return delay.promise;
                }
            }

        $routeProvider
        .when("/", {
            templateUrl: "/dashboard/search",
            controller: "searchController",
            resolve: delayObj
        })
        .when("/dashboard", {
            templateUrl: "/dashboard/dashboard",
            controller: "dashboardController",
            resolve: delayObj
        })
        .when("/search", {
            templateUrl: "/dashboard/search",
            controller: "searchController",
            resolve: delayObj
        })
        .when("/history", {
            templateUrl: "/dashboard/history",
            controller: "historyController",
            resolve: delayObj
        })
        .when("/profile", {
            templateUrl: "/dashboard/userProfile",
            controller: "profileController",
            resolve: delayObj
        })
        .when("/settings", {
            templateUrl: "/dashboard/settings",
            controller: "settingsController",
            resolve: delayObj
        })
        .otherwise({
            templateUrl: "/dashboard/blank",
            controller: "blankController",
            resolve: delayObj
        });
    }
  ]);