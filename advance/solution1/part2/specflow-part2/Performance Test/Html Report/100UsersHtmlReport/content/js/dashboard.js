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

    var data = {"OkPercent": 98.9090909090909, "KoPercent": 1.0909090909090908};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9468181818181818, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Description Add"], "isController": false}, {"data": [0.8818181818181818, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings togglelsActive"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Add"], "isController": false}, {"data": [1.0, 500, 1500, "Certification Delete"], "isController": false}, {"data": [0.41818181818181815, 500, 1500, "Search Skill Category"], "isController": false}, {"data": [0.990909090909091, 500, 1500, "Update Education"], "isController": false}, {"data": [0.9363636363636364, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings Delete"], "isController": false}, {"data": [0.9636363636363636, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.7818181818181819, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.9727272727272728, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Manage Listings View"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.990909090909091, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 1100, 12, 1.0909090909090908, 209.11181818181825, 43, 2259, 143.0, 278.69999999999993, 1088.0, 1987.3100000000006, 20.909367396593673, 11.136447136129487, 14.168695231713809], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Description Add", 55, 0, 0.0, 164.6545454545455, 134, 452, 152.0, 178.6, 273.3999999999993, 452.0, 1.2216521179005355, 0.2624643222051931, 0.7170048074787322], "isController": false}, {"data": ["Share Skill Add", 55, 0, 0.0, 354.5090909090908, 97, 2259, 105.0, 1806.7999999999995, 2143.7999999999993, 2259.0, 1.2238267951313944, 0.2677121114349925, 2.084330010458156], "isController": false}, {"data": ["SignOut", 55, 0, 0.0, 55.32727272727272, 43, 173, 51.0, 59.599999999999994, 83.79999999999973, 173.0, 1.3112096505030277, 0.2599370693868307, 0.6901777359581367], "isController": false}, {"data": ["Add Education", 55, 0, 0.0, 100.81818181818181, 80, 175, 90.0, 165.4, 173.39999999999998, 175.0, 1.2173258670680152, 0.246080521956132, 0.8148215649277352], "isController": false}, {"data": ["Delete Education", 55, 0, 0.0, 52.0909090909091, 44, 78, 50.0, 60.0, 66.19999999999999, 78.0, 1.2219235298038258, 0.26013606396214256, 0.7111976794561329], "isController": false}, {"data": ["Manage Listings togglelsActive", 55, 0, 0.0, 178.49090909090913, 144, 427, 158.0, 279.0, 279.0, 427.0, 1.286700198853667, 0.23874320095917653, 0.7438735524622764], "isController": false}, {"data": ["Certification Add", 55, 0, 0.0, 96.27272727272728, 84, 199, 92.0, 108.39999999999999, 114.6, 199.0, 1.2208928056116672, 0.2468015730093898, 0.7888545666940443], "isController": false}, {"data": ["Certification Delete", 55, 0, 0.0, 57.34545454545455, 43, 195, 51.0, 65.0, 94.19999999999963, 195.0, 1.2240446887588188, 0.24456986652349053, 0.7172136848196203], "isController": false}, {"data": ["Search Skill Category", 55, 0, 0.0, 1247.4363636363637, 1071, 2086, 1106.0, 2004.2, 2077.6, 2086.0, 1.2643096869109467, 8.068616996057653, 0.9173653294676106], "isController": false}, {"data": ["Update Education", 55, 0, 0.0, 230.09090909090904, 127, 560, 236.0, 284.4, 348.7999999999993, 560.0, 1.2160608472627574, 0.2594709375276377, 0.8614771960953391], "isController": false}, {"data": ["Add Language", 55, 0, 0.0, 170.6363636363636, 48, 1919, 56.0, 245.99999999999943, 1634.9999999999984, 1919.0, 1.15345091542059, 0.23316830028521696, 0.6793317980202588], "isController": false}, {"data": ["Manage Listings Delete", 55, 0, 0.0, 221.4181818181818, 193, 291, 207.0, 284.8, 291.0, 291.0, 1.2884484737742168, 0.24032583836999558, 0.75243377667674], "isController": false}, {"data": ["Add Skill", 55, 0, 0.0, 96.59999999999998, 46, 557, 53.0, 206.19999999999953, 553.6, 557.0, 1.203975307560965, 0.243381727212031, 0.753446550337113], "isController": false}, {"data": ["Update Certification", 55, 12, 21.818181818181817, 229.2363636363636, 131, 452, 237.0, 280.0, 300.2, 452.0, 1.2179998228363895, 0.19154517810479227, 0.8345634439498627], "isController": false}, {"data": ["Delete Language", 55, 0, 0.0, 57.63636363636365, 46, 116, 52.0, 95.0, 98.99999999999991, 116.0, 1.202816778200586, 0.23118770639242445, 0.6989023271770984], "isController": false}, {"data": ["SignIn", 55, 0, 0.0, 223.14545454545458, 162, 1646, 176.0, 242.79999999999998, 429.3999999999984, 1646.0, 1.116479233486257, 0.5364333817141002, 0.7076123266919735], "isController": false}, {"data": ["Update Language", 55, 0, 0.0, 213.74545454545458, 180, 318, 202.0, 254.99999999999997, 318.0, 318.0, 1.1958081488889856, 0.25107300001087096, 0.7498218177914511], "isController": false}, {"data": ["Manage Listings View", 55, 0, 0.0, 166.5090909090909, 135, 253, 153.0, 253.0, 253.0, 253.0, 1.2838768411961063, 0.5178136088027265, 0.7811086641261468], "isController": false}, {"data": ["Delete Skill", 55, 0, 0.0, 56.98181818181818, 45, 174, 51.0, 69.8, 91.79999999999994, 174.0, 1.2180807476801099, 0.22698432966801763, 0.7955806161827564], "isController": false}, {"data": ["Update Skill", 55, 0, 0.0, 209.29090909090908, 178, 510, 202.0, 230.4, 232.6, 510.0, 1.2132709785581928, 0.24526083257963469, 0.7924391503242743], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 12, 100.0, 1.0909090909090908], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 1100, 12, "500/Internal Server Error", 12, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 55, 12, "500/Internal Server Error", 12, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
