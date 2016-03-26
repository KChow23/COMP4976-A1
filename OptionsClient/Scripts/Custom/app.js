var app = angular.module('diplomaApp', ['ngRoute', 'LocalStorageModule']);

// Setup the routing
app.config(function ($routeProvider, $httpProvider) {

    $routeProvider
      .when('/login', {
          templateUrl: 'views/login.html',
          controller: 'LoginController',
          title: 'Login'
      })
      .when('/register', {
          templateUrl: 'views/register.html',
          controller: 'RegisterController',
          title: 'Register'
      })
      .when('/choice', {
          templateUrl: 'views/choice.html',
          controller: 'SubmitController',
          title: 'Submit Choice'
      });

    $routeProvider.otherwise({ redirectTo: "/login" });

    $httpProvider.interceptors.push('AuthIntercept');

});

app.run(function ($rootScope, $route, $location, UserService) {
    $rootScope.$on("$routeChangeSuccess", function (currentRoute, previousRoute) {
        $rootScope.title = $route.current.title;
        UserService.fillAuthData();
        $rootScope.authentication = UserService.authentication;

        $rootScope.logout = function () {
            UserService.logout();
            $location.path('/home');
        }
    });
});