angular.module('mainApp').controller('profileController', function($scope, $http) {

    $scope.settings = {};
    $scope.isDisabled = true;
    $scope.buttonTitle = "Edit";

    $http.get("account/GetCurrentUserInfo")
        .then(function(response) {
            if (response && response.data) {
                $scope.accountId = response.data.Id;
                $scope.lastName = response.data.LastName;
                $scope.firstName = response.data.FirstName;
                $scope.middleName = response.data.MiddleName;
                $scope.email = response.data.Email;
                $scope.phoneNumber = response.data.PhoneNumber;
                $scope.settings.selectedLocale = response.data.LocaleCode;
                if ($scope.settings.selectedLocale) {
                    $scope.loadCountries();
                }
                $scope.settings.selectedCountry = response.data.CountryCode;
                $scope.settings.selectedCurrency = response.data.CurrencyCode;
            }
        });

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
    $scope.edit = function() {
        if ($scope.isDisabled) {
            $scope.buttonTitle = "Save";
            $scope.enableEditing();
        } else {
            $scope.saveAccount();
        }
    }
    $scope.enableEditing = function() {
        $scope.isDisabled = false;
    }

    $scope.saveAccount = function () {
        var data = {};
        data.Id = $scope.accountId;
        data.FirstName = $scope.firstName;
        data.LastName = $scope.lastName;
        data.MiddleName = $scope.middleName;
        data.Email = $scope.email;
        data.PhoneNumber = $scope.phoneNumber;
        data.CountryCode = $scope.settings.selectedCountry;
        data.LocaleCode = $scope.settings.selectedLocale;
        data.CurrencyCode = $scope.settings.selectedCurrency;
        $http.post("account/EditAccount", data).then(
            function (response) {
                var a = 0;
            });
    }
    
});