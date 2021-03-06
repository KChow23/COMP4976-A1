﻿app.controller('LoginController', function ($scope, $http, $location, UserService) {
    if (UserService.authentication.isAuth) {
        $location.path('/choice');
    }

    $scope.message = 'Login Page';

    var onAddComplete = function (data) {
        $location.path('/home');
        console.log(data);
    };

    var onAddError = function (response) {
        alert(response.statusText + ', error code: ' + response.status);
    };

    $scope.loginUser = function () {
        var username = $scope.user.username;
        var password = $scope.user.password;
        UserService.login(username, password)
        .then(onAddComplete, onAddError);
    }
});