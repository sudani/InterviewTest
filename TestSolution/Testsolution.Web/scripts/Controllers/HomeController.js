fte.controller('HomeController',
[
    '$scope', '$http', function(scope, http) {

        scope.people = [];


        scope.$evalAsync(function() {
            http.get('/Testsolution.Web/People/GetAll')
                .success(function(response) {
                    scope.people = response;
                })
                .error(function(response) {
                    console.log(response);
                });
        });
    }
]);