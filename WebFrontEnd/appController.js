var app = angular.module("movieApp", []);
app.controller('movieAppController', ['$scope', '$http', function ($scope, $http) {
    $scope.addNewMovie = false;
    //$http.get('http://URL.com').
    //    then(function (response) {
    //        $scope.movies = response.data;
    //    });
    $scope.submit = function ()
    {
        $scope.close();
        $http.post('http://URL.com', data, config).then(successCallback, errorCallback);
    }
    
    $scope.showAddMoviePopup = function ()
    {
        $scope.addNewMovie = true;
    }

    $scope.close = function () {
        $scope.addNewMovie = false;
    }

}]);