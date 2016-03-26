// StudentService.js

(function () {

    var ChoiceService = function ($http, $window, localStorageService) {

        var baseUrl = 'http://localhost:59788/';

        var _getOptions = function (token) {
            return $http.get(baseUrl + 'api/options', { headers: { 'Authorization': token, 'Content-Type': 'application/json; charset=utf-8' } })
                .then(function (response) {
                    return response.data;
                })
        }

        var _getChoices = function (token) {
            return $http.get(baseUrl + 'api/choices', { headers: { 'Authorization': token, 'Content-Type': 'application/json; charset=utf-8' } })
                .then(function (response) {
                    return response.data;
                })
        }

        var _getYearTerm = function (token) {
            return $http.get(baseUrl + 'api/yearterms', { headers: { 'Authorization': token, 'Content-Type': 'application/json; charset=utf-8' } })
                .then(function (response) {
                    for (var i in response.data) {
                        if (response.data[i].IsDefault == true) {
                            return response.data[i].YearTermId;
                        }
                    }

                    return 1;
                })
        }

        var _submitChoice = function (userData) {
            var data = "YearTermID=" + userData.YearTermId
                + "&StudentID=" + userData.StudentId
                + "&StudentFirstName="
                + userData.StudentFirstName
                + "&StudentLastName="
                + userData.StudentLastName
                + "&FirstChoiceOptionId="
                + userData.FirstChoiceOptionId
                + "&SecondChoiceOptionId="
                + userData.SecondChoiceOptionId
                + "&ThirdChoiceOptionId="
                + userData.ThirdChoiceOptionId
                + "&FourthChoiceOptionId="
                + userData.FourthChoiceOptionId;

            return $http.post(baseUrl + 'api/choices', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function (response) {
                    return response.data;
                })
        };

        return {
            getOptions: _getOptions,
            getYearTerm: _getYearTerm,
            getChoices: _getChoices,
            submitChoice: _submitChoice
        };
    };

    var module = angular.module("diplomaApp");
    module.factory("ChoiceService", ['$http', '$q', 'localStorageService', ChoiceService]);

}());