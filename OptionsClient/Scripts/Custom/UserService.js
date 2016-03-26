//Student Service
(function () {

    var StudentService = function ($http) {

        var baseUrl = 'http://localhost:59788/api/Account/';

        var _getUser = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _getAllStudents = function () {
            return $http.get(baseUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        var _addUser = function (data) {
            return $http.post(baseUrl, data)
              .then(function (response) {
                  return response.data;
              });
        };

        var _deleteStudent = function (id) {
            return $http.delete(baseUrl + id)
              .then(function (response) {
                  return response.data;
              });
        };

        var _updateStudent = function (data) {
            return $http.put(baseUrl + data.StudentId, data)
              .then(function (response) {
                  return response.data;
              });
        };

        return {
            getStudent: _getStudent,
            getAllStudents: _getAllStudents,
            addStudent: _addStudent,
            deleteStudent: _deleteStudent,
            updateStudent: _updateStudent
        };
    };

    var module = angular.module("studentViewer");
    module.factory("StudentService", StudentService);

}());