angular.module('mainApp').directive('resolveLoader', function ($rootScope, $timeout) {

    return {
        restrict: 'E',
        replace: true,
        template: '<div class="alert alert-success ng-hide"><strong>Welcome!</strong> Content is loading, please hold.</div>',
        link: function (scope, element) {

            $rootScope.$on('$routeChangeStart', function (event, currentRoute, previousRoute) {
                if (previousRoute) return;

                $timeout(function () {
                    element.removeClass('ng-hide');
                });
            });

            $rootScope.$on('$routeChangeSuccess', function () {
                element.addClass('ng-hide');
            });
        }
    };
});

angular.module('mainApp').directive('showDuringResolve', function ($rootScope) {

    return {
        link: function (scope, element) {

            element.addClass('ng-hide');

            var unregister = $rootScope.$on('$routeChangeStart', function () {
                element.removeClass('ng-hide');
            });

            scope.$on('$destroy', unregister);
        }
    };
});