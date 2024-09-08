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

    var data = {"OkPercent": 98.95, "KoPercent": 1.05};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.963625, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Description Add"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings togglelsActive"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Add"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Delete"], "isController": false}, {"data": [0.5, 500, 1500, "Search Skill Category"], "isController": false}, {"data": [0.995, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings Delete"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.785, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.995, 500, 1500, "SignIn"], "isController": false}, {"data": [0.9975, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings View"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 4000, 42, 1.05, 177.79224999999994, 42, 1455, 143.0, 237.0, 1036.749999999999, 1110.0, 26.15558650633292, 13.935448727694189, 17.7244328120198], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Description Add", 200, 0, 0.0, 150.60000000000005, 134, 210, 149.0, 165.9, 181.95, 196.0, 1.3538028321555249, 0.29085607722091356, 0.7945659200444047], "isController": false}, {"data": ["Share Skill Add", 200, 0, 0.0, 109.93, 88, 499, 101.0, 115.70000000000002, 125.0, 476.95000000000005, 1.3545271684286808, 0.29630281809377396, 2.306929083730097], "isController": false}, {"data": ["SignOut", 200, 0, 0.0, 50.51499999999998, 42, 81, 50.0, 56.0, 59.94999999999999, 76.94000000000005, 1.3584926165926288, 0.2693105480159215, 0.7150659378353779], "isController": false}, {"data": ["Add Education", 200, 0, 0.0, 179.98000000000005, 130, 251, 185.0, 203.9, 216.79999999999995, 243.99, 1.351132248824515, 0.2731292729557369, 0.9046780420742582], "isController": false}, {"data": ["Delete Education", 200, 0, 0.0, 51.62000000000002, 43, 114, 50.0, 57.900000000000006, 66.0, 90.92000000000007, 1.355527842541886, 0.28857916960364366, 0.7889595646044569], "isController": false}, {"data": ["Manage Listings togglelsActive", 200, 0, 0.0, 155.39000000000004, 131, 459, 152.0, 170.0, 185.0, 200.95000000000005, 1.3576995139435741, 0.2519169020012491, 0.7849200314986288], "isController": false}, {"data": ["Certification Add", 200, 0, 0.0, 91.53500000000001, 82, 126, 90.0, 96.9, 104.79999999999995, 119.99000000000001, 1.3551788158447509, 0.27394728015611663, 0.8756254997221884], "isController": false}, {"data": ["Certification Delete", 200, 0, 0.0, 50.53999999999998, 43, 73, 50.0, 56.0, 58.94999999999999, 70.95000000000005, 1.3552798314031889, 0.2708044983431704, 0.794109276212806], "isController": false}, {"data": ["Search Skill Category", 200, 0, 0.0, 1094.1350000000002, 1032, 1455, 1091.0, 1125.0, 1142.75, 1409.0000000000018, 1.3488450514247177, 8.608107823301298, 0.9787030011802393], "isController": false}, {"data": ["Update Education", 200, 0, 0.0, 238.4399999999999, 175, 714, 234.0, 283.6, 330.5499999999999, 550.1400000000017, 1.350922342229157, 0.2925327345370051, 0.957307898842935], "isController": false}, {"data": ["Add Language", 200, 0, 0.0, 60.519999999999975, 47, 425, 54.0, 62.0, 69.0, 405.7500000000002, 1.3469374010842845, 0.27228129103949894, 0.7933842749267602], "isController": false}, {"data": ["Manage Listings Delete", 200, 0, 0.0, 202.4750000000001, 175, 257, 200.0, 218.9, 234.89999999999998, 254.8800000000001, 1.3571559440037457, 0.2531413918991362, 0.7925578657365625], "isController": false}, {"data": ["Add Skill", 200, 0, 0.0, 55.090000000000025, 46, 406, 52.0, 59.0, 66.94999999999999, 114.65000000000032, 1.3522467579883977, 0.27335456924179524, 0.846237077591919], "isController": false}, {"data": ["Update Certification", 200, 42, 21.0, 219.65500000000006, 129, 581, 232.5, 249.0, 261.84999999999997, 519.0000000000018, 1.35373868782109, 0.21358400625427273, 0.9275754032449116], "isController": false}, {"data": ["Delete Language", 200, 0, 0.0, 51.260000000000026, 42, 80, 50.0, 57.0, 61.0, 79.0, 1.352219329975322, 0.2599060630134208, 0.7857133802102702], "isController": false}, {"data": ["SignIn", 200, 0, 0.0, 194.54000000000008, 174, 1059, 185.0, 204.9, 216.0, 526.1100000000026, 1.337989536921821, 0.6428621603179063, 0.8480031342404902], "isController": false}, {"data": ["Update Language", 200, 0, 0.0, 199.67499999999998, 176, 568, 197.0, 215.9, 226.95, 252.91000000000008, 1.3488723427214848, 0.2832105016456243, 0.8458970780895921], "isController": false}, {"data": ["Manage Listings View", 200, 0, 0.0, 149.42499999999998, 131, 209, 148.0, 162.0, 171.89999999999998, 203.92000000000007, 1.3576718642871204, 0.5475766405767389, 0.826005440869996], "isController": false}, {"data": ["Delete Skill", 200, 0, 0.0, 51.61, 42, 100, 50.0, 56.900000000000006, 62.0, 79.97000000000003, 1.3523473368900067, 0.25200675666538197, 0.8832782674402094], "isController": false}, {"data": ["Update Skill", 200, 0, 0.0, 198.91, 177, 257, 198.0, 217.0, 227.95, 256.96000000000004, 1.3509679685494658, 0.2730960639548236, 0.8823773405520055], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 42, 100.0, 1.05], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 4000, 42, "500/Internal Server Error", 42, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 200, 42, "500/Internal Server Error", 42, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
