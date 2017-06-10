angular.module('mainApp').controller('historyController', function ($scope, $http, $interval) {

    $scope.userHistory = [];

    $scope.sortType = 'OriginPlace';

    var refresh = function() {
        $scope.refreshHistory();
    }

    $interval(refresh, 7000);

    $scope.refreshHistory = function() {
        $http.get('history/GetHistoryRecords')
          .then(function (response) {
              $scope.userHistory = response.data;
          });
    }

    $scope.removeHistory = function () {
        $http({
            method: 'POST',
            url: 'History/RemoveHistory',
        })
        .success(function (data) {
            $scope.userHistory = [];
        });
    }
});