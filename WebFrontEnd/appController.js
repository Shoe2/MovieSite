app.controller('movieAppController', ['$scope', '$http', function ($scope, '$http') {
    $http.get('http://URL.com').
        then(function (response) {
            $scope.movies = response.data;
        });
    $scope.submit = function ()
    {

        $http.post('http://URL.com', data, config).then(successCallback, errorCallback);
    }
    


}]);