var app = angular.module("movieApp", []);
app.controller('movieAppController', ['$scope', '$http', function ($scope, $http) {
    $scope.addNewMovie = false;
    //$scope.refreshMovies();
    $scope.refreshMovies = function () {
        $http.get('/api/movies').
            then(function (response) {
                $scope.movies = response.data;
            }, function (response) { console.log("ERROR:" + response.ExceptionMessage); });
    };
    $scope.submit = function () {
        $scope.close();
        $http.post('api/SaveMovie', data, config).
            then($scope.refreshMovies(), function (response) {
                alert(response);
            });
    };
    
    $scope.showAddMoviePopup = function () {
        $scope.addNewMovie = true;
    };

    $scope.close = function () {
        $scope.addNewMovie = false;
    };

}]);