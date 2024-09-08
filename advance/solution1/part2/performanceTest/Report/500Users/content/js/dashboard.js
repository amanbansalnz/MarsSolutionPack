/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 76.87004656501304, "KoPercent": 23.12995343498696};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.5010533427286662, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.32058096415327564, 500, 1500, "Add new skill"], "isController": false}, {"data": [0.45740103270223753, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.949589611662379, 500, 1500, "Add Languages"], "isController": false}, {"data": [0.5332841146794635, 500, 1500, "Add Education"], "isController": false}, {"data": [0.3546500777604977, 500, 1500, "Disable existing listing"], "isController": false}, {"data": [0.7656211410224747, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5554940322382182, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.7677498467198038, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.9540766208251473, 500, 1500, "Delete Languages"], "isController": false}, {"data": [0.0, 500, 1500, "Update Education"], "isController": false}, {"data": [0.24862224448897796, 500, 1500, "Delete existing listing"], "isController": false}, {"data": [0.001573910853689247, 500, 1500, "Search Skill by all category"], "isController": false}, {"data": [0.5556851669941061, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.6799951088285644, 500, 1500, "SignIn"], "isController": false}, {"data": [0.9936380481778876, 500, 1500, "Add Cretifications"], "isController": false}, {"data": [0.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 137657, 31840, 23.12995343498696, 1625.3930566553092, 1, 99584, 284.0, 5585.7000000000335, 14788.95, 22491.220000000285, 175.4537795525487, 98.95229820097326, 122.12616589496633], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add new skill", 8090, 0, 0.0, 3791.1166872682334, 143, 85335, 1524.0, 4354.900000000001, 12448.349999999999, 64389.07000000001, 10.361048604716391, 2.2664793822817106, 22.239828938639285], "isController": false}, {"data": ["Update Skills", 8134, 3597, 44.221785099582, 316.6892058028026, 36, 2468, 227.0, 719.0, 856.25, 1244.2999999999993, 10.40569946794561, 2.368761259701773, 6.844291577063454], "isController": false}, {"data": ["Add Languages", 8163, 342, 4.189636163175304, 137.39544285189362, 36, 1908, 100.0, 286.0, 365.0, 558.3599999999997, 10.43370894515113, 2.1240990792536247, 6.225582192858731], "isController": false}, {"data": ["Add Education", 8127, 1861, 22.8989787129322, 604.721914605637, 55, 3210, 573.0, 992.1999999999998, 1119.0, 1492.6000000000013, 10.396997190623129, 2.138936833236745, 6.944869217174043], "isController": false}, {"data": ["Disable existing listing", 16075, 0, 0.0, 2320.0580404354473, 153, 84801, 1383.0, 3597.0, 4662.9999999999945, 32240.72, 20.61214545827563, 3.8144753139104735, 11.69497706177553], "isController": false}, {"data": ["Delete Education", 8098, 1857, 22.931588046431216, 98.94257841442338, 1, 1569, 58.0, 290.0, 352.0, 502.09000000000196, 10.365718630516788, 2.2114069426186176, 5.9937098609210615], "isController": false}, {"data": ["Delete Skills", 8127, 3596, 44.247569828965176, 67.89602559370007, 1, 1642, 43.0, 185.0, 277.59999999999945, 407.880000000001, 10.397409539210656, 2.2538547804959337, 6.6002779862967085], "isController": false}, {"data": ["Update Languages", 8155, 460, 5.6407112201103615, 451.7302268546906, 37, 2367, 367.0, 858.0, 974.1999999999998, 1356.199999999998, 10.42688204901338, 2.19474684484531, 6.519745528299619], "isController": false}, {"data": ["Delete Languages", 8144, 347, 4.260805500982318, 115.50994597249496, 3, 1503, 77.0, 257.0, 326.0, 448.10000000000036, 10.41795921082424, 1.9764170288188845, 6.0461622052039905], "isController": false}, {"data": ["Update Education", 8110, 8110, 100.0, 570.3720098643619, 3, 3157, 607.5, 1072.0, 1247.699999999999, 1694.7800000000007, 10.381557438430708, 1.9843647792542944, 7.320897882709523], "isController": false}, {"data": ["Delete existing listing", 7984, 0, 0.0, 2929.732089178357, 195, 87746, 1849.0, 5049.0, 6511.75, 32748.099999999973, 10.244263584491438, 1.9007910947786846, 5.872444066500462], "isController": false}, {"data": ["Search Skill by all category", 7942, 0, 0.0, 13224.761521027445, 791, 99584, 9757.5, 18668.8, 29015.699999999997, 97727.14, 10.188386368447048, 63.6376164185423, 7.621390584209412], "isController": false}, {"data": ["Add Skills", 8144, 3579, 43.94646365422397, 134.6833251473475, 35, 1743, 90.0, 304.5, 366.75, 531.1000000000004, 10.418372359587359, 2.2357224207844224, 6.501308532984689], "isController": false}, {"data": ["SignIn", 8178, 0, 0.0, 715.113842015164, 151, 4922, 572.0, 1363.0, 1680.0999999999985, 2797.42, 10.442830673676227, 5.017453800242874, 3.536596525712502], "isController": false}, {"data": ["Add Cretifications", 8095, 0, 0.0, 134.27869054972203, 35, 1516, 80.0, 310.0, 377.0, 528.0, 10.361401061099626, 2.2564379263918135, 6.80978800207036], "isController": false}, {"data": ["Delete Certification", 8091, 8091, 100.0, 13.864540847855666, 3, 490, 7.0, 21.0, 42.0, 169.07999999999993, 10.360259422637379, 1.1230359335085438, 5.89846801113046], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 21545, 67.66645728643216, 15.6512200614571], "isController": false}, {"data": ["500/Internal Server Error", 10295, 32.33354271356784, 7.4787333735298605], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 137657, 31840, "Test failed: text expected to contain /true/", 21545, "500/Internal Server Error", 10295, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": ["Update Skills", 8134, 3597, "Test failed: text expected to contain /true/", 3597, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Languages", 8163, 342, "Test failed: text expected to contain /true/", 342, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Education", 8127, 1861, "Test failed: text expected to contain /true/", 1861, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Education", 8098, 1857, "Test failed: text expected to contain /true/", 1857, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Skills", 8127, 3596, "Test failed: text expected to contain /true/", 3596, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Languages", 8155, 460, "Test failed: text expected to contain /true/", 460, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 8144, 347, "500/Internal Server Error", 347, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Education", 8110, 8110, "Test failed: text expected to contain /true/", 6253, "500/Internal Server Error", 1857, "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Skills", 8144, 3579, "Test failed: text expected to contain /true/", 3579, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certification", 8091, 8091, "500/Internal Server Error", 8091, "", "", "", "", "", "", "", ""], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
