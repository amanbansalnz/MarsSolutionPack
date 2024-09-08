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

    var data = {"OkPercent": 99.18, "KoPercent": 0.82};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9629, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.998, 500, 1500, "Description Add"], "isController": false}, {"data": [0.981, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [0.999, 500, 1500, "SignOut"], "isController": false}, {"data": [0.995, 500, 1500, "Add Education"], "isController": false}, {"data": [0.999, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.998, 500, 1500, "Manage Listings togglelsActive"], "isController": false}, {"data": [0.999, 500, 1500, "Certification Add"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Delete"], "isController": false}, {"data": [0.488, 500, 1500, "Search Skill Category"], "isController": false}, {"data": [0.999, 500, 1500, "Update Education"], "isController": false}, {"data": [0.99, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings Delete"], "isController": false}, {"data": [0.999, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.835, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.987, 500, 1500, "SignIn"], "isController": false}, {"data": [0.995, 500, 1500, "Update Language"], "isController": false}, {"data": [0.999, 500, 1500, "Manage Listings View"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.997, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 10000, 82, 0.82, 182.32769999999977, 42, 3293, 143.0, 240.0, 1049.0, 1108.0, 28.354717516126748, 15.111699311512014, 19.214662933295525], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Description Add", 500, 0, 0.0, 152.94399999999993, 132, 1137, 148.5, 161.0, 165.0, 196.92000000000007, 1.4474964102089025, 0.31098555688081897, 0.8495559985698736], "isController": false}, {"data": ["Share Skill Add", 500, 0, 0.0, 140.2200000000001, 88, 2374, 99.5, 110.0, 123.0, 2150.9900000000016, 1.4477898040850838, 0.31670401964361206, 2.4657670100824083], "isController": false}, {"data": ["SignOut", 500, 0, 0.0, 51.156, 42, 563, 49.0, 54.900000000000034, 57.0, 70.0, 1.4631562621624863, 0.2900592980654148, 0.7701574465874808], "isController": false}, {"data": ["Add Education", 500, 0, 0.0, 192.44600000000003, 131, 2053, 176.0, 244.0, 252.0, 379.6400000000003, 1.4462487200698826, 0.2923569189985017, 0.9683652074499165], "isController": false}, {"data": ["Delete Education", 500, 0, 0.0, 52.918, 43, 672, 50.0, 56.0, 59.94999999999999, 77.87000000000012, 1.4472240794931244, 0.3081004387983409, 0.8423296400174826], "isController": false}, {"data": ["Manage Listings togglelsActive", 500, 0, 0.0, 151.502, 128, 1477, 144.0, 156.0, 165.0, 320.0, 1.4578152015137953, 0.27049305496838, 0.842799413375163], "isController": false}, {"data": ["Certification Add", 500, 0, 0.0, 94.78200000000004, 83, 689, 91.0, 97.0, 101.94999999999999, 195.87000000000012, 1.4470984229521389, 0.29252868510848895, 0.9350177739863799], "isController": false}, {"data": ["Certification Delete", 500, 0, 0.0, 51.509999999999984, 43, 389, 50.0, 56.0, 59.0, 66.97000000000003, 1.4478946164382371, 0.2893753131072108, 0.8483757518192796], "isController": false}, {"data": ["Search Skill Category", 500, 0, 0.0, 1114.4579999999983, 1028, 3293, 1080.5, 1118.9, 1162.5, 2300.98, 1.4547147304413603, 9.2837507455413, 1.0555205514823545], "isController": false}, {"data": ["Update Education", 500, 0, 0.0, 234.30199999999994, 177, 986, 225.5, 292.0, 301.0, 344.98, 1.4464286230867365, 0.31365748190517795, 1.0249867832584567], "isController": false}, {"data": ["Add Language", 500, 0, 0.0, 72.09800000000004, 47, 1554, 54.0, 60.0, 66.0, 878.4900000000005, 1.4395034288971675, 0.2909933689274548, 0.847898446451912], "isController": false}, {"data": ["Manage Listings Delete", 500, 0, 0.0, 196.26000000000013, 174, 267, 194.0, 210.0, 219.84999999999997, 258.0, 1.4582616354695894, 0.2719999730221597, 0.8516020097761859], "isController": false}, {"data": ["Add Skill", 500, 0, 0.0, 56.79799999999998, 45, 637, 53.0, 59.0, 62.0, 98.80000000000018, 1.446566718550193, 0.2924212018944238, 0.9052625825989596], "isController": false}, {"data": ["Update Certification", 500, 82, 16.4, 223.31600000000003, 128, 1310, 234.0, 247.0, 252.0, 304.8900000000001, 1.4470356028639728, 0.23246400860696778, 0.9915020121030058], "isController": false}, {"data": ["Delete Language", 500, 0, 0.0, 52.31400000000001, 43, 432, 50.5, 57.0, 60.94999999999999, 91.0, 1.4463658611373065, 0.2780016882705514, 0.840417663453806], "isController": false}, {"data": ["SignIn", 500, 0, 0.0, 196.2419999999999, 161, 2098, 173.0, 186.0, 195.0, 1138.91, 1.430971371986732, 0.6875370263842502, 0.9069340043158096], "isController": false}, {"data": ["Update Language", 500, 0, 0.0, 206.72599999999997, 173, 2045, 196.0, 211.0, 217.95, 445.73000000000116, 1.4452412541225506, 0.3034442086292465, 0.9063215168601844], "isController": false}, {"data": ["Manage Listings View", 500, 0, 0.0, 152.17800000000025, 130, 1127, 147.0, 159.90000000000003, 168.89999999999998, 279.0, 1.457186406199454, 0.5877128767191157, 0.886549932677988], "isController": false}, {"data": ["Delete Skill", 500, 0, 0.0, 51.614000000000026, 42, 389, 50.0, 55.0, 57.0, 79.87000000000012, 1.4469937258352048, 0.2696438894178455, 0.9450960387823258], "isController": false}, {"data": ["Update Skill", 500, 0, 0.0, 202.77000000000015, 175, 2065, 195.0, 208.0, 213.95, 265.73000000000025, 1.446223620881155, 0.29235184523671787, 0.9445930489430997], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 82, 100.0, 0.82], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 10000, 82, "500/Internal Server Error", 82, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 500, 82, "500/Internal Server Error", 82, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
