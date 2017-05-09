angular.module('mainApp').controller('sideBarController', function ($scope, $http, $location) {

    $scope.isSelected = function(itemToCheck) {
        return $location.path().indexOf("#/" + itemToCheck) > -1;
    }
});