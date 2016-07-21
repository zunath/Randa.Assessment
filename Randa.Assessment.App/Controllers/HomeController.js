app.controller("HomeController", [
    '$scope', function ($scope) {
        $scope.items = [];
        $scope.counter = 0;

        $scope.dosomething = function() {

            $scope.counter++;
            $scope.items.push({
                name: "testitem",
                value: $scope.counter
            });
        }

    }
]);