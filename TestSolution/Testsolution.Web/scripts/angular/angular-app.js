window.fte = angular.module('fte', ['ngDialog']);

window.fte.config(['ngDialogProvider', '$httpProvider',  function (ngDialogProvider, httpProvider) {
    ngDialogProvider.setDefaults({
        className: 'ngdialog-theme-default',
        closeByDocument: false
    });

    httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    angular.extend(httpProvider.defaults.headers.post, { 'Content-Type': 'application/json' });
    angular.extend(httpProvider.defaults.headers.put, { 'Content-Type': 'application/json' });
}]);
