var app = angular.module('diplomaApp', ['ngRoute', 'LocalStorageModule']);

// Setup the routing
app.config(function ($routeProvider) {

    $routeProvider
      .when('/home', {
          templateUrl: 'views/home.html',
          controller: 'HomeController',
          title: 'Home'
      })
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
      .when('/submit', {
          templateUrl: 'views/submit.html',
          controller: 'SubmitController',
          title: 'Submit Choice'
      });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

// Controls the rootscope
app.run(function ($rootScope, $route, $location,userService) {
    $rootScope.$on("$routeChangeSuccess", function (currentRoute, previousRoute) {
        //Change page title, based on Route information
        $rootScope.title = $route.current.title;

        // Set some data based on user authentication
        accountService.fillAuthData();
        $rootScope.authentication = accountService.authentication;

        // Allow users to logout
        $rootScope.logout = function () {
            accountService.logout();
            $location.path('/home');
        }
    });
});