'use strict';
app.factory('AuthIntercept', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

    var authInterceptFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptFactory.request = _request;
    authInterceptFactory.responseError = _responseError;

    return authInterceptFactory;
}]);