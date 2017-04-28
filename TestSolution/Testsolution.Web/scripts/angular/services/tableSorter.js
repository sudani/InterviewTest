fte.factory('_tableSorter', [function() {

    var sortMap = {};

    var registerSort = function(name, property, direction) {
        sortMap[name] = {
            property: property,
            direction: direction
        }
    }

    var sortExists = function(name) {
        return !!sortMap[name];
    }

    var getSort = function(name) {
        return sortMap[name];
    }

    var updateSort = function(name, property, direction) {
        angular.extend(sortMap[name], { property: property, direction: direction });
    }

    return {
        register: registerSort,
        exists: sortExists,
        get: getSort,
        update: updateSort
    }

}]);