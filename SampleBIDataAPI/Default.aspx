<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleBIDataAPI.Default" %>
<!DOCTYPE html>
<style>
    .chart rect {
      fill: steelblue;
    }

    .chart text {
      fill: white;
      font: 10px sans-serif;
      text-anchor: end;
    }
</style>
<svg class="chart"></svg>
<%--<div class="chart"></div>--%>
<%--<script src="Scripts/d3.v3.min.js"></script>--%>
<script src="http://d3js.org/d3.v3.min.js"></script>
<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="Scripts/sollisfunctions.js"></script>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<%--<body>--%>
    <%--<form id="form1" runat="server">--%>
        <%--<div class="chart">

        </div>--%>

        <script>
            var chartData;

            var width = 420,
                barHeight = 20;
            var x = d3.scale.linear()
                .range([0, width]);
            var chart = d3.select(".chart")
                .attr("width", width);

            //var data = [4, 8, 15, 16, 23, 42];
            //d3.tsv("http://localhost/SampleBIDataAPI/chartData.txt", type, function (error, data) {
            d3.json("api/DrugReporting?measure=Patient Count&&condition=[10073]", function (error, data) {
                x.domain([0, d3.max(data, function(d) { return d.Count; })]);

                chart.attr("height", barHeight * data.length);

                var bar = chart.selectAll("g")
                    .data(data)
                  .enter().append("g")
                    .attr("transform", function(d, i) { return "translate(0," + i * barHeight + ")"; });

                bar.append("rect")
                    .attr("width", function(d) { return x(d.Count); })
                    .attr("height", barHeight - 1);

                bar.append("text")
                    .attr("x", function(d) { return x(d.Count) - 3; })
                    .attr("y", barHeight / 2)
                    .attr("dy", ".35em")
                    .text(function(d) { return d.Count; });
            });

            function type(d) {
                d.value = +d.value; // coerce to number
                return d;
            }

            //function Setup() {
            //    _toolTipDiv = d3.select("body").append("div")
            //        .attr("class", "chart")
            //        .style("opacity", 0).style("position", "absolute");

            //    //GetChartData();
            //    ProcessCharts();
            //}

            //function ProcessCharts(){
            //    //d3.tsv("chartData.txt", type, function (error, data) {
            //    //    data.len

            //    //});
                
            //    chart.attr("height", barHeight * chartData.items);
                
            //    d3.select(".chart")
            //        .selectAll("g")
            //            .data(chartData)
            //        .enter().append("g")
            //            .attr("transform", function(d,i) {return "translate(0," + i * })
            //            .style("width", function (d) { return d.count + "px"; })
            //            .text(function (d) { return d.DrugName });
            //}

            //function GetChartData() {
            //    chartData = GetData();
            //    chartData.done(function (data) {
            //        //var d;
            //        //chartData = eval(data.d);
            //        ProcessCharts();
            //    });

            //    //data.done(function (data) {
            //    //    // On success, 'data' contains a list of products.
            //    //    $.each(data, function (key, item) {
            //    //        // Add a list item for the product.
            //    //        $('<li>', { text: formatItem(item) }).appendTo($('#products'));
            //    //    });
            //    //});
            //}

            //function formatItem(item) {
            //    return item.Name + ': $' + item.Price;
            //}

            //function GetData() {

            //    //var uri = 'api/products';
            //    var uri = "api/DrugReporting/MeasureOnAllDrugsByCondition";
            //    var aj = $.getJSON(uri, function(data){
            //        chart.attr("height", barHeight * data.items.count)
            //        var bar = chart.selectAll("g")
            //            .data(data)
            //            .enter().append("g")

            //        d3.slect(".chart")
            //            .selectAll("g")
            //                .data(data)
            //            .enter().append("g")
                            

            //    });

            //    //var aj = $.ajax({
            //    //    type: "GET",
            //    //    dataType: "json",
            //    //    url: "api/MeasureOnAllDrugsByCondition?measure=Patient Count&condition=",
            //    //    //data: {measure: 'Patient Count', condition: ''},
            //    //    conentType: "application/json; charset=utf-8"
            //    //});

            //    return aj;
            //}

            


        </script>
    <%--</form>--%>
<%--</body>--%>
<%--</html>--%>
