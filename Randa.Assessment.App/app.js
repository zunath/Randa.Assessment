var app = angular.module("Assessment", ["ngRoute", "ui.bootstrap"]);

app.config([
    "$routeProvider", function($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/Views/Home.html",
            controller: "HomeController"
        })
        .when("/:name", {
            templateUrl: function (params) {
                return "/Views/" + params.name + ".html";
            },
            controller: ["$scope", "$routeParams", "$controller", function ($scope, $routeParams, $controller) {
                return $controller($routeParams.name + "Controller", { $scope: $scope });
            }]
        })
        .otherwise({
            redirectTo: "/"
        });
    }
]);