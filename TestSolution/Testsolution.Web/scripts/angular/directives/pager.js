fte.directive('ftePager', ['_paginator', '$timeout', function(paginator, timeout) {

    return {
        restrict: 'E',
        scope: {
            pagerName: '@', // @ here because I just want to read the literal value from the attribute
            pagerAlignment: '@',
            hideWhenOnePage: '='
        },
        template: '' +
            '<div class="pager" ng-class="pagerAlignment" ng-show="showWhenOnePage()">' +
                '<a class="pager-button previous" href="javascript:void(0)" ng-disabled="currentPage == 1" ng-click="previous()"><i class="fa fa-caret-left"></i></a>' +
                '<span class="pager-button-wrapper" ng-repeat="number in pageNumbers">' +
                    '<a class="pager-button pager-button-ellipsis" href="javascript:void(0)" ng-show="showEllipsisBefore(number)"><i class="fa fa-ellipsis-h"></i></a>' +
                    '<a class="pager-button" ng-class="{\'pager-button-active\': number == currentPage}" href="javascript:void(0)" ng-click="setPage(number)" ng-show="showNumber(number)">' +
                        '<span ng-bind="number"></span>' +
                    '</a>' +
                    '<a class="pager-button pager-button-ellipsis" href="javascript:void(0)" ng-show="showEllipsisAfter(number)"><i class="fa fa-ellipsis-h"></i></a>' +
                '</span>' +
                '<a class="pager-button next" href="javascript:void(0)" ng-disabled="currentPage == totalPages" ng-click="next()"><i class="fa fa-caret-right"></i></a>' +
            '</div>',
        replace: true,
        link: function(scope, element, attrs) {

            function init() {
                var data = paginator.get(scope.pagerName);
                scope.currentPage = data.currentPage;
                scope.totalPages = data.pages;
                scope.pageNumbers = [];

                for (var i = 0; i < data.pages; i++) {
                    scope.pageNumbers.push(i + 1);
                }
            }

            function check() {
                if (paginator.exists(scope.pagerName)) {
                    init();
                    return;
                }
                timeout(check, 500);
            }

            check();
            
            scope.$watch(function () { return paginator.get(scope.pagerName); }, init, true);

            scope.setPage = function(page) {
                scope.currentPage = page;
                paginator.update(scope.pagerName, { currentPage: page });
            }

            scope.previous = function() {
                scope.currentPage = scope.currentPage == 1 ? 1 : scope.currentPage - 1;
                paginator.update(scope.pagerName, { currentPage: scope.currentPage });
            }

            scope.next = function() {
                scope.currentPage = scope.currentPage == scope.totalPages ? scope.totalPages : scope.currentPage + 1;
                paginator.update(scope.pagerName, { currentPage: scope.currentPage });
            }

            scope.showEllipsisBefore = function(number) {
                return number == scope.currentPage - 2 && number > 2;
            }

            scope.showEllipsisAfter = function (number) {
                return number == scope.currentPage + 2 && number < scope.totalPages - 1 ;
            }

            scope.showNumber = function(number) {
                return number == 1 || number == scope.totalPages || number >= scope.currentPage - 2 && number <= scope.currentPage + 2;
            }

            scope.showWhenOnePage = function() {
                return !scope.hideWhenOnePage || scope.totalPages > 1;
            }
        }
    }
    
}]);