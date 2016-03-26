app.controller('RegisterController', function ($scope, $http, $location, $timeout, UserService) {
    if (UserService.authentication.isAuth) {
        $location.path('/choice');
    }

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.user = {
        username: "",
        password: "",
        email: "",
        confirmPassword: ""
    };

    var onRegisterComplete = function (data) {
        $scope.savedSuccessfully = true;
        $scope.message = "You have been registered.";

        startTimer();
        console.log(data);
    };

    var onRegisterError = function (response) {
        console.log(response);
    };

    $scope.register = function () {
        UserService.register($scope.user)
            .then(onRegisterComplete, onRegisterError);
    }

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

});