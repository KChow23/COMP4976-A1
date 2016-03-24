(function () {
    var app = angular.module('reports', []);

    app.controller('ReportsController', function ($scope, $http) {

        var onUserComplete = function (response) {
            $scope.choices = response.data;
        };
        var onError = function (error) {
            $scope.error = error;
        };

        $scope.generateReports = function () {
            $http.get("http://localhost:59788/api/Choices")
            .then(onUserComplete, onError);
        };
    });
})();