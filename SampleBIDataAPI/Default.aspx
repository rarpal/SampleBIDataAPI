﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleBIDataAPI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>All Products</h2>
        <ul id="products" />
    </div>
    <div>
        <h2>Search by ID</h2>
        <input type="text" id="prodId" size="5" />
        <input type="button" value="Search" onclick="    //find();" />
        <p id="product" />
    </div>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <script>
        //var uri = 'api/products';
        var uri = 'http://localhost/SampleBIDataAPI/api/products'

        $(document).ready(function () {
            // Send an AJAX request
            $.getJSON(uri)
                .done(function (data) {
                    // On success, 'data' contains a list of products.
                    $.each(data, function (key, item) {
                        // Add a list item for the product.
                        $('<li>', { text: formatItem(item) }).appendTo($('#products'));
                    });
                });
        });

        function formatItem(item) {
            return item.Name + ': $' + item.Price;
        }

        function find() {
            var id = $('#prodId').val();
            $.getJSON(uri + '/' + id)
                .done(function (data) {
                    $('#product').text(formatItem(data));
                })
                .fail(function (jqXHR, textStatus, err) {
                    $('#product').text('Error: ' + err);
                });
        }
    </script>
    </form>
</body>
</html>
