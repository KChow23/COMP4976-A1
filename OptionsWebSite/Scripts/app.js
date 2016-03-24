(function () {
    var app = angular.module('reports', []);

    app.controller('ReportsController', function ($scope, $http) {
        var onUserComplete = function (response) {
            $scope.user = response.data;
        };
        var onError = function (error) {
            $scope.error = error;
        };

        $http.get("http://localhost:59788/api/Choices")
        .then(onUserComplete, onError);
        $scope.message = "Hello, Angular!";
    });
})();