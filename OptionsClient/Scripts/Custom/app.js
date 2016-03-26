(function () {
    var app = angular.module("diplomaViewer", ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
          .when("/register", {
              templateUrl: "views/register.html",
              controller: "UserController"
          })
          .when("/login", {
              templateUrl: "views/login.html",
              controller: "UserController"
          })
          .when("/choice", {
              templateUrl: "views/choice.html",
              controller: "ChoiceController"
          })
          .otherwise({ redirectTo: "/login" });
    });
}());