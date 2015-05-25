var app = angular.module("uwtApp", []);

function UsersController(users) {
    app.controller("UsersController", function ($scope) {
        $scope.users = users;
        console.log("Users controller configured");
    });    
}
