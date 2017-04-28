fte.factory('_paginator', [function() {

    var paginations = {};

    var registerPagination = function(name, size, pageSize) {
        paginations[name] = {
            size: size,
            pageSize: pageSize,
            currentPage: 1,
            pages: Math.ceil(size / pageSize) || 1
        }
    }

    var getPagination = function(name) {
        return paginations[name];
    }

    var paginationExists = function(name) {
        return !!paginations[name];
    }

    var updatePagination = function(name, options) {
        angular.extend(paginations[name], options);
        paginations[name].pages = Math.ceil(paginations[name].size / paginations[name].pageSize) || 1;
        if (paginations[name].currentPage > paginations[name].pages) {
            paginations[name].currentPage = paginations[name].pages;
        }
    }

    return {
        register: registerPagination,
        get: getPagination,
        exists: paginationExists,
        update: updatePagination
    }

}]);