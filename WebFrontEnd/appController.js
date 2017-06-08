var app = angular.module("movieApp", []);
app.controller('movieAppController', ['$scope', '$http', function ($scope, $http) {
    $scope.addNewMovie = false;
    $scope.deleteMovie = false;
    
    $scope.refreshMovies = function () {
        $http.get('/movies/api/movies').
            then(function (response) {
                $scope.movies = response.data.$values;
            }, function (response) { console.log("ERROR:" + response.ExceptionMessage); });
    };

    $scope.refreshMovies();

    $scope.submit = function () {
        $scope.close();
        $http.post('/movies/api/SaveMovie', data, config).
            then($scope.refreshMovies(), function (response) {
                alert(response);
            });
    };
    
    $scope.showPopup = function (movieID) {
        if (movieID === '')
        {
            $scope.addNewMovie = true;
        }
            
        else
        {
            $scope.deleteMovie = true;
        }
    };

    $scope.close = function () {
        $scope.addNewMovie = false;
        $scope.deleteMovie = false;

    };

}]);