dc = {
    version: "1.4.0",
    sollisversion: "1.1.9",
    constants: {
        CHART_CLASS: "dc-chart",
        DEBUG_GROUP_CLASS: "debug",
        STACK_CLASS: "stack",
        DESELECTED_CLASS: "deselected",
        SELECTED_CLASS: "selected",
        NODE_INDEX_NAME: "__index__",
        GROUP_INDEX_NAME: "__group_index__",
        DEFAULT_CHART_GROUP: "__default_chart_group__",
        EVENT_DELAY: 40,
        NEGLIGIBLE_NUMBER: 1e-10
    },
    _renderlet: null
};

String.prototype.replaceAll = function (find, replace) {
    var str = this;
    return str.replace(new RegExp(find, 'g'), replace);
};

if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (searchElement /*, fromIndex */) {
        'use strict';
        if (this == null) {
            throw new TypeError();
        }
        var n, k, t = Object(this),
        len = t.length >>> 0;

        if (len === 0) {
            return -1;
        }
        n = 0;
        if (arguments.length > 1) {
            n = Number(arguments[1]);
            if (n != n) { // shortcut for verifying if it's NaN
                n = 0;
            } else if (n != 0 && n != Infinity && n != -Infinity) {
                n = (n > 0 || -1) * Math.floor(Math.abs(n));
            }
        }
        if (n >= len) {
            return -1;
        }
        for (k = n >= 0 ? n : Math.max(len - Math.abs(n), 0) ; k < len; k++) {
            if (k in t && t[k] === searchElement) {
                return k;
            }
        }
        return -1;
    };
}

//Global Items
var _toolTipDiv = null;
var _drillPopupDiv = null;
var _tooltipActive = false;


dc.tooltipActive = function (x) {
    if (!arguments.length) return dc._tooltipActive;
    dc._tooltipActive = x;
    return dc;
};

dc.ShowToolTipCustom = function (d, l, x, y) {
    var s = d;
    s = s.replace("%SERIES%", l);
    var left = x;
    var top = y;

    if (dc.tooltipActive()) {

        _toolTipDiv.transition()
                    .duration(200)
                    .style("opacity", .9).style("z-index", 100);
    }
    else {
        //Show helper tip?
        // _toolTipDiv.transition()
        //  .duration(200)
        //  .style("opacity", .4);


    }

    _toolTipDiv.html(s)
                    .style("left", (left + 20) + "px")
                    .style("top", (top - 20) + "px");
}
dc.ShowToolTip = function (d, l) {

    var s = d;
    s = s.replace("%SERIES%", l);
    var left = d3.event.pageX;
    var top = d3.event.pageY;

    if (dc.tooltipActive()) {

        _toolTipDiv.transition()
                .duration(200)
                .style("opacity", .9).style("z-index", 100);
    }
    else {
        //Show helper tip?
        // _toolTipDiv.transition()
        //  .duration(200)
        //  .style("opacity", .4);


    }

    _toolTipDiv.html(s)
                .style("left", (left + 10) + "px")
                .style("top", (top - 20) + "px");
}

dc.ToggleToolTip = function () {
    dc.tooltipActive(!dc.tooltipActive());
    if (dc.tooltipActive()) {
        _toolTipDiv.transition()
                 .duration(200)
                 .style("opacity", .9).style("z-index", 100);
    }
    else {
        dc.HideToolTip();
    }

}
dc.MoveToolTipCustom = function (x, y) {
    var left = x;
    var top = y;


    _toolTipDiv.style("left", (left + 30) + "px")
                    .style("top", (top - 20) + "px");

}
dc.MoveToolTip = function () {
    var left = d3.event.pageX;
    var top = d3.event.pageY;


    _toolTipDiv.style("left", (left + 10) + "px")
                .style("top", (top - 20) + "px");
}

dc.HideToolTip = function () {
    _toolTipDiv.transition()
                .duration(500)
                .style("opacity", 0);

}
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}
