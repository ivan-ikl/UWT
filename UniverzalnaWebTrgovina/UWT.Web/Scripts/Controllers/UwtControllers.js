var app = angular.module("uwtApp", []);

function UsersController(users) {
    app.controller("UsersController", function ($scope) {
        $scope.users = users;
        console.log("Users controller configured");

        // Add handlers for blocking
        $scope.users.forEach(function (u) {
            console.log(u);

            u.block = function(url) {
                console.log("Blocking user " + u.Email);
                $.post(url, { "email": u.Email }, function (response) {
                    if (response) {
                        $scope.$apply(function() { angular.extend(u, { "Blocked": true }); });
                    }
                });
            }

            u.unblock = function(url) {
                console.log("Unblocking user " + u.Email);
                $.post(url, { "email": u.Email }, function(response) {
                    if (response) {
                        $scope.$apply(function () { angular.extend(u, { "Blocked": false }); });
                    }
                });
            }

        });
    });    
}
