<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleBIDataAPI.Default" %>
<!DOCTYPE html>
<script src="Scripts/d3.v3.min.js"></script>
<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="Scripts/sollisfunctions.js"></script>
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
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            $("document").ready(function() {Setup();});

            function Setup() {
                _toolTipDiv = d3.select("body").append("div")
                .attr("class", "tooltip")
                .style("opacity", 0).style("position", "absolute");

                
                
                
            }

            function GetChartData() {


            }

            function GetData() {

                var aj = $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: "api/MeasureOnAllDrugsByCondition",
                    data: {measure: 'Patient Count', condition: ''},
                    conentType: "application/json; charset=utf-8"

                });

            }


        </script>
    </form>
</body>
</html>
