fte.directive('thSort', ['_tableSorter', function(tableSorter) {
    return {
        restrict: 'A',
        scope: {
            thSortName: '@',
            thSort: '@'
        },
        template: '<span ng-transclude class="th-sort-text"></span>' +
            '<div class="th-sort-icons">' +
                '<a href="javascript:void(0)" class="th-sort-icon" ng-click="sort(\'+\')" title="Order {{headerText}} in ascending order">' +
                    '<i class="fa fa-lg fa-caret-up"></i>' +
                '</a>' +
                '<a href="javascript:void(0)" class="th-sort-icon" ng-click="sort(\'-\')" title="Order {{headerText}} in descending order">' +
                    '<i class="fa fa-lg fa-caret-down"></i>' +
                '</a>' +
            '</div>',
        transclude: true,
        link: function(scope, element, attrs) {
            var name = scope.thSortName;
            var property = scope.thSort;

            scope.headerText = element.find('.th-sort-text').text();

            scope.sort = function(direction) {
                tableSorter.update(name, property, direction);
            }
        }
    }    
}]);