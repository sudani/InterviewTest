fte.filter('paginate', ['_paginator', function(paginator) {


    return function(dataSet, name, pageSize) {
        if (!paginator.exists(name)) {
            paginator.register(name, dataSet.length, pageSize);
        } else {
            var config = paginator.get(name);

            var updateOptions = {
                size: dataSet.length,
                pageSize: pageSize
            };

            if (config.size != dataSet.length) {
                updateOptions.currentPage = 1;
            }

            paginator.update(name, updateOptions);
            
        }

        var data = paginator.get(name);

        return dataSet.slice((data.currentPage - 1) * data.pageSize, data.pageSize * data.currentPage);
    }

}])