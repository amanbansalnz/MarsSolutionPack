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

    var data = {"OkPercent": 78.04763435807385, "KoPercent": 21.95236564192615};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.6043701926644078, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.7921680388431497, 500, 1500, "Add new skill"], "isController": false}, {"data": [0.36521004855393707, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.8473717542748576, 500, 1500, "Add Languages"], "isController": false}, {"data": [0.649461684610513, 500, 1500, "Add Education"], "isController": false}, {"data": [0.8387692632467807, 500, 1500, "Disable existing listing"], "isController": false}, {"data": [0.6974878615157273, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5480261769052143, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.5648089508127507, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.8540215326155794, 500, 1500, "Delete Languages"], "isController": false}, {"data": [0.0, 500, 1500, "Update Education"], "isController": false}, {"data": [0.7900569981000634, 500, 1500, "Delete existing listing"], "isController": false}, {"data": [0.31792273590880304, 500, 1500, "Search Skill by all category"], "isController": false}, {"data": [0.5442263035676589, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.7203389830508474, 500, 1500, "SignIn"], "isController": false}, {"data": [0.8974034198860038, 500, 1500, "Add Cretifications"], "isController": false}, {"data": [0.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 80866, 17752, 21.95236564192615, 2351.2113743724226, 1, 271780, 402.0, 9847.500000000007, 32769.350000000035, 160032.87000000017, 79.48869930710578, 45.34774785418061, 55.23174563709604], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add new skill", 4737, 0, 0.0, 5122.082330588986, 147, 140865, 342.0, 1828.9999999999973, 11475.199999996747, 138357.96, 5.152502993933817, 1.1271100299230223, 11.059767168619658], "isController": false}, {"data": ["Update Skills", 4737, 1838, 38.800928857926955, 1086.8026176905219, 38, 190865, 524.0, 1214.1999999999998, 1656.0999999999995, 18479.26, 5.151757709691874, 1.1564055631397554, 3.3932236410838814], "isController": false}, {"data": ["Add Languages", 4737, 177, 3.7365421152628246, 794.5824361410168, 40, 160034, 313.0, 624.0, 954.0, 17602.459999999995, 5.1496742996790825, 1.0475754602038996, 3.0727060518592966], "isController": false}, {"data": ["Add Education", 4737, 1054, 22.25036943213004, 642.6119907114215, 45, 161914, 377.0, 670.1999999999998, 799.0999999999995, 7843.319999999996, 5.152430137093582, 1.0594687443575614, 3.441662318136728], "isController": false}, {"data": ["Disable existing listing", 9474, 0, 0.0, 1967.1876715220615, 145, 139829, 334.0, 1122.5, 1605.0, 67690.75, 10.307180974036218, 1.9074324165818979, 5.8481173299951585], "isController": false}, {"data": ["Delete Education", 4737, 1060, 22.377031876715222, 523.8503272113176, 2, 190530, 272.0, 574.0, 681.1999999999989, 6844.959999999999, 5.152502993933817, 1.099133251401248, 2.97988488106931], "isController": false}, {"data": ["Delete Skills", 4737, 1838, 38.800928857926955, 480.0920413763988, 1, 159921, 245.0, 567.1999999999998, 701.2999999999984, 6892.339999999999, 5.152486180633962, 1.0977243508949686, 3.2757325018599857], "isController": false}, {"data": ["Update Languages", 4737, 259, 5.467595524593625, 1726.2123706987545, 44, 191203, 732.0, 1314.0, 2029.3999999999978, 31490.139999999996, 5.150721394576574, 1.0846008129756426, 3.221035754944399], "isController": false}, {"data": ["Delete Languages", 4737, 178, 3.757652522693688, 794.6419674899728, 4, 190956, 284.0, 593.0, 763.0999999999995, 15774.879999999997, 5.1523180536702515, 0.97962795997246, 2.9905824481015713], "isController": false}, {"data": ["Update Education", 4737, 4737, 100.0, 671.4036309900778, 3, 149161, 430.0, 758.0, 914.0, 7389.059999999939, 5.152200371323877, 0.994689300061561, 3.6337978008794742], "isController": false}, {"data": ["Delete existing listing", 4737, 0, 0.0, 2470.4314967278815, 192, 139952, 402.0, 1330.3999999999996, 2416.7999999999956, 73491.7199999998, 5.155037452103422, 0.9565010897457522, 2.9550849456881925], "isController": false}, {"data": ["Search Skill by all category", 4737, 0, 0.0, 4201.750052776018, 662, 143342, 1291.0, 7106.799999999998, 10670.0, 100587.55999999997, 5.1525366208627155, 32.18322678421673, 3.8543389175594145], "isController": false}, {"data": ["Add Skills", 4737, 1822, 38.46316233903314, 628.880937302091, 38, 125238, 298.0, 606.0, 789.3999999999978, 13875.079999999985, 5.152301241577341, 1.0976530847051593, 3.2151567318046106], "isController": false}, {"data": ["SignIn", 5074, 52, 1.0248324793062673, 15196.343318880572, 150, 271780, 433.0, 7361.5, 133149.75, 252597.25, 4.9875801979108, 2.4473275769492013, 1.6766018632652038], "isController": false}, {"data": ["Add Cretifications", 4737, 0, 0.0, 480.2499472239796, 38, 190654, 294.0, 591.1999999999998, 705.0999999999995, 4646.819999999944, 5.152710366987845, 1.1221234490608296, 3.3864981220535353], "isController": false}, {"data": ["Delete Certification", 4737, 4737, 100.0, 302.45324044754057, 3, 16282, 173.0, 489.0, 582.1999999999989, 1952.7199999999993, 5.153063500058199, 0.5585840317445899, 2.933824238802666], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 11731, 66.08269490761604, 14.506714812158386], "isController": false}, {"data": ["Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 37, 0.20842721946822892, 0.0457547053149655], "isController": false}, {"data": ["500/Internal Server Error", 5984, 33.70887787291573, 7.399896124452798], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 80866, 17752, "Test failed: text expected to contain /true/", 11731, "500/Internal Server Error", 5984, "Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 37, "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": ["Update Skills", 4737, 1838, "Test failed: text expected to contain /true/", 1838, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Languages", 4737, 177, "Test failed: text expected to contain /true/", 177, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Education", 4737, 1054, "Test failed: text expected to contain /true/", 1054, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Education", 4737, 1060, "Test failed: text expected to contain /true/", 1060, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Skills", 4737, 1838, "Test failed: text expected to contain /true/", 1838, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Languages", 4737, 259, "Test failed: text expected to contain /true/", 259, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 4737, 178, "500/Internal Server Error", 178, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Education", 4737, 4737, "Test failed: text expected to contain /true/", 3683, "500/Internal Server Error", 1054, "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Skills", 4737, 1822, "Test failed: text expected to contain /true/", 1822, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["SignIn", 5074, 52, "Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 37, "500/Internal Server Error", 15, "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certification", 4737, 4737, "500/Internal Server Error", 4737, "", "", "", "", "", "", "", ""], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
