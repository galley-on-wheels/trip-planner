angular.module('mainApp').controller('searchController', function ($scope, $http) {

    $scope.totalBudget = 1000;

    // Search results popup setup

    var tripModal = document.getElementById('searchResultsModal');

    // Hotel modal

    var hotelModal = document.getElementById('hotelModal');

    var span = document.getElementsByClassName("close-trip")[0];
    var closeHotel = document.getElementsByClassName("close-hotel")[0];

    // --

    $scope.settings = {};

    $http.get("search/GetAvailableCultures")
    .then(function (response) {
        $scope.settings.locales = response.data;
        //console.log(JSON.stringify(response.data), false);
    });

    $http.get("search/GetAvailableCurrencies")
    .then(function (response) {
        $scope.settings.currencies = response.data;
        //console.log(JSON.stringify(response.data), false);
    });

    $scope.loadCountries = function () {
        $http.get("search/GetAvailableCountries", {
            params: { locale: $scope.settings.selectedLocale }
        })
        .then(function (response) {
            $scope.settings.countries = response.data;
            //console.log(JSON.stringify(response.data), false);
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


    // search results object

    $scope.searchResults = [];

    $scope.bookingSearchResults = [];
    $scope.searchResultsReady = true;
    $scope.bookingSearchResultsReady = true;


    $scope.submitForm = function () {

        $scope.searchResults = [];
        tripModal.style.display = "block";
        $scope.searchResultsReady = false;

        $scope.bookingSearchResultsReady = false;

        $scope.formData =
        {
            locale: $scope.settings.selectedLocale,
            currency: $scope.settings.selectedCurrency,
            country: $scope.settings.selectedCountry,

            originPlace: $scope.originPlace.selected.PlaceId,
            destinationPlace: $scope.destinationPlace.selected.PlaceId,

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
                $scope.searchResults = data;
                $scope.searchResultsReady = true;
        });

        $http({
            method: 'POST',
            url: 'BookingSearch/GetHotelsByTripDescription',
            data: $.param($scope.formData),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        })
        .success(function (data) {
            $scope.bookingSearchResults = JSON.parse(data);
            $scope.bookingSearchResultsReady = true;
        });

        $scope.formatDate = function (date) {
            if (typeof date === "undefined") {
                return new Date();
            }
  
            var dateOut = new Date(date.match(/\d+/)[0] * 1);

            return dateOut;
        };
    };
    
    // Search results

    span.onclick = function () {
        tripModal.style.display = "none";
    }

    closeHotel.onclick = function () {
        hotelModal.style.display = "none";
    }


    window.onclick = function (event) {
        if (event.target == tripModal) {
            tripModal.style.display = "none";
        }

        if (event.target == hotelModal) {
            hotelModal.style.display = "none";
        }
    }

    // Handle hotel selection

    $scope.currentHotel = null;
    // Hack
    $scope.currentRating = 0;

    $scope.showHotelInfo = function (hotelIndex) {
        $scope.currentHotel = $scope.bookingSearchResults.Hotels[hotelIndex];
        $scope.currentRating = $scope.currentHotel.Rating;

        hotelModal.style.display = "block";
    }

});


angular.module('mainApp').controller('RatingController', function ($scope) {
              this.rating1 = 5.5;//$scope.$parent.currentHotel.Rating;

              this.isReadonly = true;
              this.rateFunction = function (rating) {
                  console.log('Rating selected: ' + rating);
              };
          })
          .directive('starRating', function () {
              return {
                  restrict: 'EA',
                  template:
                    '<ul class="star-rating" ng-class="{readonly: readonly}">' +
                    '  <li ng-repeat="star in stars" class="star" ng-class="{filled: star.filled}" ng-click="toggle($index)">' +
                    '    <i class="fa fa-star"></i>' + // or &#9733
                    '  </li>' +
                    '</ul>',
                  scope: {
                      ratingValue: '=ngModel',
                      max: '=?', // optional (default is 5)
                      onRatingSelect: '&?',
                      readonly: '=?'
                  },
                  link: function (scope, element, attributes) {
                      if (scope.max == undefined) {
                          scope.max = 5;
                      }
                      function updateStars() {
                          scope.stars = [];
                          for (var i = 0; i < scope.max; i++) {
                              scope.stars.push({
                                  filled: i < scope.ratingValue
                              });
                          }
                      };
                      scope.toggle = function (index) {
                          if (scope.readonly == undefined || scope.readonly === false) {
                              scope.ratingValue = index + 1;
                              scope.onRatingSelect({
                                  rating: index + 1
                              });
                          }
                      };
                      scope.$watch('ratingValue', function (oldValue, newValue) {
                          if (newValue || newValue === 0) {
                              updateStars();
                          }
                      });
                  }
              };
          });