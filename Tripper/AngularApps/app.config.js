angular.
  module('mainApp').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        //$locationProvider.hashPrefix('!');

        $routeProvider
        .when("/", {
            templateUrl: "/dashboard/dashboard",
            controller: "dashboardController"
        })
        .when("/dashboard", {
            templateUrl: "/dashboard/dashboard",
            controller: "dashboardController"
        })
        .when("/search", {
            templateUrl: "/dashboard/search",
            controller: "searchController"
        })
        .when("/history", {
            templateUrl: "/dashboard/history",
            controller: "historyController"
        })
        .when("/profile", {
            templateUrl: "/dashboard/userProfile",
            controller: "profileController"
        })
        .when("/settings", {
            templateUrl: "/dashboard/settings",
            controller: "settingsController"
        })
        .otherwise({
            templateUrl: "/dashboard/blank",
            controller: "blankController"
        });
    }
  ]);