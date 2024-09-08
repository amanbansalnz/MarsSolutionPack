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

    var data = {"OkPercent": 99.15, "KoPercent": 0.85};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9659166666666666, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Description Add"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings togglelsActive"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Add"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Delete"], "isController": false}, {"data": [0.5, 500, 1500, "Search Skill Category"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings Delete"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.8283333333333334, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "SignIn"], "isController": false}, {"data": [0.995, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings View"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 6000, 51, 0.85, 176.97833333333327, 42, 1211, 144.0, 236.0, 1030.199999999997, 1106.9899999999998, 29.528285636949725, 15.735976178978321, 20.009921580870593], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Description Add", 300, 0, 0.0, 150.70666666666654, 132, 235, 149.0, 164.0, 172.0, 197.95000000000005, 1.5135309668435817, 0.32517266865780076, 0.8883126084697194], "isController": false}, {"data": ["Share Skill Add", 300, 0, 0.0, 110.95666666666669, 89, 560, 102.0, 113.90000000000003, 132.89999999999998, 447.9100000000001, 1.5135615111398126, 0.331091580561834, 2.5777844486599935], "isController": false}, {"data": ["SignOut", 300, 0, 0.0, 50.67333333333335, 42, 88, 49.0, 58.0, 66.0, 80.98000000000002, 1.515610791148833, 0.3004579986359503, 0.7977677894816612], "isController": false}, {"data": ["Add Education", 300, 0, 0.0, 175.11333333333332, 133, 497, 180.5, 203.0, 209.0, 233.8800000000001, 1.5144172522413375, 0.30613708126362976, 1.0140088328386236], "isController": false}, {"data": ["Delete Education", 300, 0, 0.0, 51.463333333333345, 43, 93, 51.0, 56.900000000000034, 61.0, 78.93000000000006, 1.5155801640868123, 0.32265280837004406, 0.8821150173786526], "isController": false}, {"data": ["Manage Listings togglelsActive", 300, 0, 0.0, 152.84, 130, 205, 151.0, 167.90000000000003, 178.84999999999997, 200.95000000000005, 1.5151897775196344, 0.2811387282507134, 0.8759690901285386], "isController": false}, {"data": ["Certification Add", 300, 0, 0.0, 92.76666666666665, 84, 130, 92.0, 99.0, 104.0, 120.94000000000005, 1.5151591674705427, 0.30628705826797104, 0.9789940542629003], "isController": false}, {"data": ["Certification Delete", 300, 0, 0.0, 51.02333333333333, 43, 93, 50.0, 58.0, 65.89999999999998, 74.98000000000002, 1.5151974302251583, 0.30281753329646355, 0.8878109942725537], "isController": false}, {"data": ["Search Skill Category", 300, 0, 0.0, 1088.2933333333335, 1015, 1211, 1086.0, 1122.8000000000002, 1135.9, 1189.97, 1.5076740609703392, 9.621728504337076, 1.0939470969735956], "isController": false}, {"data": ["Update Education", 300, 0, 0.0, 227.13, 178, 351, 227.5, 262.90000000000003, 281.0, 336.95000000000005, 1.514004542013626, 0.3276794726217512, 1.0728732967448902], "isController": false}, {"data": ["Add Language", 300, 0, 0.0, 57.07333333333335, 46, 419, 53.0, 61.0, 70.84999999999997, 83.98000000000002, 1.5107033331151207, 0.30538631831526364, 0.8898298350060176], "isController": false}, {"data": ["Manage Listings Delete", 300, 0, 0.0, 203.7666666666666, 176, 267, 203.0, 220.90000000000003, 235.0, 261.97, 1.5147766461835204, 0.2825413470908714, 0.8846058929860792], "isController": false}, {"data": ["Add Skill", 300, 0, 0.0, 54.62666666666664, 46, 366, 53.0, 60.0, 65.89999999999998, 75.98000000000002, 1.5150979510825375, 0.3062746834707864, 0.9481494814577263], "isController": false}, {"data": ["Update Certification", 300, 51, 17.0, 223.00333333333333, 127, 615, 233.0, 252.0, 264.9, 311.8600000000001, 1.5139663394817189, 0.24264858948802706, 1.0373626390956574], "isController": false}, {"data": ["Delete Language", 300, 0, 0.0, 51.97333333333335, 42, 87, 51.0, 58.0, 63.94999999999999, 83.0, 1.5151285586582022, 0.29121836222178454, 0.8803725511734671], "isController": false}, {"data": ["SignIn", 300, 0, 0.0, 194.50333333333333, 171, 1070, 188.0, 205.80000000000007, 215.0, 269.6800000000003, 1.5029834220928542, 0.722136566083676, 0.9525744540412718], "isController": false}, {"data": ["Update Language", 300, 0, 0.0, 203.36000000000013, 176, 563, 197.0, 222.0, 237.95, 514.4900000000023, 1.5123635722027575, 0.3175372734605399, 0.9484075284198321], "isController": false}, {"data": ["Manage Listings View", 300, 0, 0.0, 150.07333333333327, 131, 193, 148.0, 163.0, 173.0, 186.97000000000003, 1.5154117373690432, 0.6111963354818504, 0.9219741331844862], "isController": false}, {"data": ["Delete Skill", 300, 0, 0.0, 50.86666666666667, 43, 77, 50.0, 56.0, 61.0, 75.96000000000004, 1.5151362107453459, 0.2823420817719013, 0.9896029301471702], "isController": false}, {"data": ["Update Skill", 300, 0, 0.0, 199.35333333333335, 175, 266, 197.0, 218.0, 226.0, 256.94000000000005, 1.514004542013626, 0.3060536525359576, 0.9888637869038607], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 51, 100.0, 0.85], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 6000, 51, "500/Internal Server Error", 51, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 300, 51, "500/Internal Server Error", 51, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
