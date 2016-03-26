app.controller('SubmitController', function ($scope, $http, $location, UserService, ChoiceService) {
    if (!UserService.authentication.isAuth) {
        $location.path('/login');
    }

    $scope.savedSuccessfully = false;
    $scope.message = "";

    studentService.getData(UserService.authentication.token).then(function (response) {
        console.log(response);
        $scope.diplomaOptions = response.options;
        $scope.user.yearTermId = response.yearterm.id;
    });

    $scope.user = {
        yearTermId: "",
        studentID: UserService.authentication.username,
        firstName: "",
        lastName: "",
        firstChoiceOptionId: "0",
        secondChoiceOptionId: "0",
        thirdChoiceOptionId: "0",
        fourthChoiceOptionId: "0",
    };

    var onRegisterComplete = function (data) {
        $scope.savedSuccessfully = true;
        $scope.message = "Your choices have been submitted successfully";

        console.log(data);
    };

    var onRegisterError = function (response) {
        var errors = [];
        for (var key in response.data.ModelState) {
            for (var i = 0; i < response.data.ModelState[key].length; i++) {
                errors.push(response.data.ModelState[key][i]);
            }
        }
        $scope.savedSuccessfully = false;
        $scope.message = "Failed to submit choices due to:" + errors.join('\n');

        console.log(response);
    };

    $scope.submitChoice = function () {
        console.log($scope.user);

        studentService.submitChoice($scope.user)
            .then(onRegisterComplete, onRegisterError);
    }
});