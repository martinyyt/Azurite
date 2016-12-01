﻿$(document).ready(function () {
    var categoryId = $('#categoryId').val();

    loadSubCategories(categoryId);
    loadCategoryAttr(categoryId);
    loadProducts(categoryId);

    $('#search-products').click(function () {
        var value = $('#search').val();

        if (value != '') {
            $.ajax({
                url: MVC.Products.GetCategoryProductsFull + '?categoryId=' + categoryId + '&search=' + value,
                dataType: 'html',
                success: function (data) {
                    $('#productsContainer').html(data);
                }
            });
        }
    });
});

function loadSubCategories(categoryId) {
    $('#subCategoriesContainer').html('');
    $.ajax({
        url: MVC.Categories.GetCategoryTreeFull + '?categoryId=' + categoryId,
        dataType: 'html',
        success: function (data) {
            $('#subCategoriesContainer').html(data);
            $('.active').parents('ul').removeClass('collapse');
            $('.active').parents('li').addClass('parent');
        }
    });
}

function loadCategoryAttr(categoryId) {
    $('#categoriesAttrContainer').html('');
    $.ajax({
        url: MVC.Categories.GetCategoryAttrFull + '?categoryId=' + categoryId,
        dataType: 'html',
        success: function (data) {
            $('#categoriesAttrContainer').html(data);
        }
    });
}

function loadProducts(categoryId) {
    $('#productsContainer').html('');
    $.ajax({
        url: MVC.Products.GetCategoryProductsFull + '?categoryId=' + categoryId,
        dataType: 'html',
        success: function (data) {
            $('#productsContainer').append(data);
        }
    });
}