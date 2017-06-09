var app = angular.module("movieApp", []);
app.controller('movieAppController', ['$scope', '$http', function ($scope, $http) {
    $scope.addNewMovie = false;
    $scope.deleteMovie = false;
    $scope.newMovie = {};
    
    $scope.refreshMovies = function () {
        $http.get('/movies/api/movies').
            then(function (response) {
                $scope.movies = response.data.$values;
            }, function (response) { console.log("ERROR:" + response.data.ExceptionMessage); });
    };

    $scope.refreshMovies();

    $scope.submit = function () {
        $http.post('/movies/api/Movies', $scope.newMovie).
            then($scope.refreshMovies(),
            function (response) { console.log("ERROR:" + response.data.ExceptionMessage); });
        $scope.close();
    };
    
    $scope.showPopup = function (movieID) {
        if (movieID === '') {$scope.addNewMovie = true;}
        else {$scope.deleteMovie = true;}
    };

    $scope.close = function () {
        $scope.addNewMovie = false;
        $scope.deleteMovie = false;
    };

}]);