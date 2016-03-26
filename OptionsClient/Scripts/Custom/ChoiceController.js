// Code goes here

(function () {

    var app = angular.module("diplomaApp");

    var ChoiceController = function ($scope, $location, ChoiceService) {
        var onGetOptionsComplete = function (data) {
            $scope.options = data;
        };

        var onGetOptionsError = function (reason) {
            $scope.error = "Could not get the options.";
        };

        ChoiceService.getData()
            .then(onGetOptionsComplete, onGetOptionsError);

        /*var _user = {
            StudentId: "",
            FirstName: "",
            LastName: "",
            Password: "",
        };

        var onGetAllComplete = function (data) {
            $scope.user = data;
        };

        var onGetAllError = function (reason) {
            $scope.error = "Could not get all students.";
        };

        $scope.search = function () {
            StudentService.getAllStudents()
              .then(onGetAllComplete, onGetAllError);
        };

        var onFindComplete = function (data) {
            $scope.person = data;
        };

        var onFindError = function (reason) {
            $scope.error = "Could not find a student.";
        };

        $scope.findStudent = function (personId) {
            StudentService.getStudent(personId)
            .then(onFindComplete, onFindError);
        };

        var onAddComplete = function (data) {
            $scope.newPerson = data;
            _student.StudentId = "";
            _student.FirstName = "";
            _student.LastName = "";
            _student.Program = "";
        };

        var onAddError = function (reason) {
            $scope.error = "Could not add a student.";
        };

        $scope.addStudent = function () {
            var data = {
                StudentId: _student.StudentId,
                FirstName: _student.FirstName,
                LastName: _student.LastName,
                Program: _student.Program,

            }
            StudentService.addStudent(data)
            .then(onAddComplete, onAddError);
        };

        var onUpdateComplete = function (data) {
            $scope.person = undefined;
            $("#dialog_update").dialog();
        };

        var onUpdateError = function (reason) {
            $scope.error = "Could not delete cartoon characters.";
        };

        $scope.updateStudent = function () {

            var data = {
                StudentId: _student.StudentId,
                FirstName: _student.FirstName,
                LastName: _student.LastName,
                Program: _student.Program,
            }

            StudentService.updateStudent(data)
            .then(onUpdateComplete, onUpdateError);
        };

        var onDeleteComplete = function (data) {
            $scope.student = data;
            $("#dialog_delete").dialog();
            //$scope.PersonId = 0;
        };

        var onDeleteError = function (reason) {
            $scope.error = "Could not delete students.";
        };

        $scope.deleteStudent = function (personId) {
            StudentService.deleteStudent(personId)
            .then(onDeleteComplete, onDeleteError);
        };*/
    };

    app.controller("ChoiceController", ChoiceController);
}());