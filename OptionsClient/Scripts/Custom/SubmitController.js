app.controller('SubmitController', function ($scope, $http, $location, UserService, ChoiceService) {
    if (!UserService.authentication.isAuth) {
        $location.path('/login');
    }

    $scope.savedSuccessfully = false;
    $scope.message = "";

    ChoiceService.getOptions(UserService.authentication.token).then(function (response) {
        console.log(response);
        $scope.diplomaOptions = response;
    });

    ChoiceService.getYearTerm(UserService.authentication.token).then(function (response) {
        console.log(response);
        $scope.user.YearTermId = response;
    });

    $scope.user = {
        YearTermId: "",
        StudentId: UserService.authentication.username,
        StudentFirstName: "",
        StudentLastName: "",
        FirstChoiceOptionId: "0",
        SecondChoiceOptionId: "0",
        ThirdChoiceOptionId: "0",
        FourthChoiceOptionId: "0",
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

        var options = [$scope.user.FirstChoiceOptionId, $scope.user.SecondChoiceOptionId, $scope.user.ThirdChoiceOptionId, $scope.user.FourthChoiceOptionId];

        $scope.message = "";

        // Make sure theres no duplicate options
        for (var i = 0; i < options.length - 1; i++) {
            for (var k = i + 1; k < options.length; k++) {
                if (options[i] == options[k]) {
                    $scope.message = "Can't select the same option more than once. ";
                    return;
                }
            }
        }

        // Make sure they have not already submitted for this term
        ChoiceService.getChoices()
            .then(function (response) {
                for (var i in response) {
                    if (response[i].YearTermId == $scope.user.YearTermId && response[i].StudentId == $scope.user.StudentId) {
                        $scope.message = "You have already submitted for this term.";
                        return;
                    }
                }

                // If this all passed, submit the choices
                ChoiceService.submitChoice($scope.user)
                    .then(onRegisterComplete, onRegisterError);
            });

    }

    $scope.logoutUser = function () {
        UserService.logout();
        $location.path('/login');
    };
});