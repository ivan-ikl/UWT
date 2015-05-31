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

function ShopController(products, shopId, basketItemsCount, basketAddUrl, basketRemoveUrl) {
    app.controller("ShopController", function($scope) {
        $scope.products = products;
        console.log("Shop controller configured");

        $scope.basketItemsCount = basketItemsCount;
        $scope.basketItemsEmpty = $scope.basketItemsCount === 0;

        // Add handlers for basket operations
        $scope.products.forEach(function(p) {
            console.log(p);
            p.UnitPrice = p.UnitPrice.toFixed(2) + " kn/kom";
            p.Image = p.Image.replace("~", "");

            p.addToBasket = function() {
                $.get(basketAddUrl + "?product=" + p.Id + "&shop=" + shopId, function (data) {
                    if (data) {
                        $scope.$apply(function() {
                            angular.extend(p, { "InBasket": true });
                            angular.extend($scope, { "basketItemsCount": $scope.basketItemsCount + 1 });
                            angular.extend($scope, { "basketItemsEmpty": false });
                    });
                        console.log("Product " + p.Title + " has been added to the basket");
                    } else {
                        console.log("Product " + p.Title + " hasn't been added to the basket");
                    }
                });
            };

            p.removeFromBasket = function() {
                $.get(basketRemoveUrl + "?product=" + p.Id, function (data) {
                    if (data) {
                        $scope.$apply(function() {
                             angular.extend(p, { "InBasket": false });
                             angular.extend($scope, { "basketItemsCount": $scope.basketItemsCount - 1 });
                             angular.extend($scope, { "basketItemsEmpty": $scope.basketItemsCount === 0 });
                        });
                        console.log("Product " + p.Title + " has been removed from the basket");
                    } else {
                        console.log("Product " + p.Title + "hasn't been removed from the basket");
                    }
                });
            };

        });
    });
}

function BasketController(basket, shopId, basketAddUrl, basketRemoveUrl, basketAmountUrl, basketBuyUrl, invoiceRedirect) {
    app.controller("BasketController", function ($scope) {
        $scope.basket = basket;
        console.log("Basket controller configured");

        $scope.basket.BasketItems.forEach(function(item) {
            console.log(item);
            item.totalPrice = function () { return item.UnitPrice * item.Amount; }

            item.onAmountChanged = function() {
                $.get(basketAmountUrl + "?product=" + item.Product.Id + "&newAmount=" + item.Amount);
            };
            item.removeFromBasket = function() {
                $.get(basketRemoveUrl + "?product=" + item.Product.Id, function (data) {
                    if (data) {
                        $scope.$apply(function () {
                            var index = $scope.basket.BasketItems.indexOf(item);
                            $scope.basket.BasketItems.splice(index, 1);
                        });
                        console.log("Product " + item.Product.Title + " has been removed from the basket");
                    } else {
                        console.log("Product " + item.Product.Title + "hasn't been removed from the basket");
                    }
                });
            };
        });

        $scope.basket.totalPrice = function() {
            var sum = 0;
            $scope.basket.BasketItems.forEach(function(item) {
                sum += item.UnitPrice * item.Amount;
            });
            return sum;
        };

        $scope.basket.buyBasket = function() {
            $.post(basketBuyUrl + "?shop=" + shopId, function(data) {
                // ReSharper disable once CoercedEqualsUsing
                if (data != 0) {
                    location.href = invoiceRedirect + "/" + data;
                } else {
                    location.reload();
                }
            });
        }
    });
}

function DiscountController(model, discountUrl) {
    app.controller("DiscountController", function($scope) {
        $scope.model = model;
        console.log("Discount controller configured");

        $scope.saveChanges = function () {
            $.post(discountUrl, $scope.model, function(data) {
                if (data) {
                    console.log("Changes successfully saved");
                } else {
                    console.log("Error saving changes");
                }
            });
        };
    });
}