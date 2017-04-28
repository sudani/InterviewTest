fte.filter('tableSort', ['_tableSorter', '$filter', function(tableSorter, filter) {
    return function(list, name, property) {

        if (!tableSorter.exists(name)) {
            tableSorter.register(name, property);
        }

        var sort = tableSorter.get(name);

        return !sort ? list : filter('orderBy')(list, sort.direction + sort.property);
    }
}]);