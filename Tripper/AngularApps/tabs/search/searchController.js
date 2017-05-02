angular.module('mainApp').controller('searchController', function ($scope, $http) {

    $scope.settings = {};

    $http.get("search/GetAvailableCultures")
    .then(function (response) {
        $scope.settings.locales = response.data;
        console.log(JSON.stringify(response.data), false);
    });

    $http.get("search/GetAvailableCurrencies")
    .then(function (response) {
        $scope.settings.currencies = response.data;
        console.log(JSON.stringify(response.data), false);
    });

    $scope.loadCountries = function () {
        $http.get("search/GetAvailableCountries", {
            params: { locale: $scope.settings.selectedLocale }
        })
        .then(function (response) {
            $scope.settings.countries = response.data;
            console.log(JSON.stringify(response.data), false);
        });
    }

    $scope.originPlace = {};
    $scope.originPlaces = [];

    $scope.refreshOrigin = function(search) {
        var params = { query: search};
        return $http.get('search/GetAutosuggestedPlace', { params: params })
          .then(function (response) {
                $scope.originPlaces = response.data;
            });
    };

    $scope.destinationPlace = {};
    $scope.destinationPlaces = [];

    $scope.refreshDestination = function (search) {
        var params = { query: search };
        return $http.get('search/GetAutosuggestedPlace', { params: params })
          .then(function (response) {
              $scope.destinationPlaces = response.data;
          });
    };
});