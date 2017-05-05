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
    $scope.loadingOrigin = false;

    $scope.refreshOrigin = function (search) {
        $scope.loadingOrigin = true;

        var params = { query: search };
        return $http.get('search/GetAutosuggestedPlace', { params: params })
          .then(function (response) {
              $scope.originPlaces = response.data;
              $scope.loadingOrigin = false;
          });
    };

    $scope.destinationPlace = {};
    $scope.destinationPlaces = [];
    $scope.loadingDestination = false;

    $scope.refreshDestination = function (search) {
        $scope.loadingDestination = true;
        var params = { query: search };
        return $http.get('search/GetAutosuggestedPlace', { params: params })
          .then(function (response) {
              $scope.destinationPlaces = response.data;
              $scope.loadingDestination = false;
          });
    };

    $scope.cabinClasses =
    [
        { Code: "economy", Name: "Economy" },
        { Code: "premiumeconomy", Name: "Premium economy" },
        { Code: "business", Name: "Business" },
        { Code: "first", Name: "First" }
    ];



    $scope.submitForm = function () {

        $scope.formData =
        {
            locale: $scope.settings.locales,
            currency: $scope.settings.currencies,
            countries: $scope.settings.countries,

            originPlace: $scope.originPlace.selected,
            destinationPlace: $scope.destinationPlace.selected,

            outboundDate: $scope.outboundDate,
            inboundDate: $scope.inboundDate,

            adults: $scope.adults,
            children: $scope.children,
            infants: $scope.infants,

            cabinClass: $scope.cabinClass
        }

        $http({
            method: 'POST',
            url: 'Search/GetItinerariesByTripDescription',
            data: $.param($scope.formData),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        })
        .success(function (data) {
            
        });
    };
});