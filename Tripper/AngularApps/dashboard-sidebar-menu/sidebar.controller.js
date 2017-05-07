angular.module('mainApp').controller('sideBarController', function ($scope, $http) {

    $scope.selectedMenuItem = "search";

    $scope.selectMenuItem = function(itemToSelect) {
        $scope.selectedMenuItem = itemToSelect;
    }

    $scope.isSelected = function(itemToCheck) {
        return itemToCheck === $scope.selectedMenuItem;
    }
});