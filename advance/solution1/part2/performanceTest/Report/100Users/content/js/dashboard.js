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

    var data = {"OkPercent": 78.8462141155823, "KoPercent": 21.1537858844177};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.7290295537169362, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.9527748132337247, 500, 1500, "Add new skill"], "isController": false}, {"data": [0.5190748371660242, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.9678746847205628, 500, 1500, "Add Languages"], "isController": false}, {"data": [0.8013707745541656, 500, 1500, "Add Education"], "isController": false}, {"data": [0.9638039268064645, 500, 1500, "Disable existing listing"], "isController": false}, {"data": [0.802998001332445, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.6286588610963278, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.7974641529474243, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.9679776773850651, 500, 1500, "Delete Languages"], "isController": false}, {"data": [0.0, 500, 1500, "Update Education"], "isController": false}, {"data": [0.9535054856837035, 500, 1500, "Delete existing listing"], "isController": false}, {"data": [0.46751942137690866, 500, 1500, "Search Skill by all category"], "isController": false}, {"data": [0.6282562466772993, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.9791721942159725, 500, 1500, "SignIn"], "isController": false}, {"data": [0.9981338309784058, 500, 1500, "Add Cretifications"], "isController": false}, {"data": [0.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 127632, 26999, 21.1537858844177, 286.037349567507, 1, 94113, 298.0, 693.0, 945.0, 1477.9900000000016, 179.9793555083001, 102.28340662624375, 125.3321960604486], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add new skill", 7496, 0, 0.0, 313.6714247598708, 144, 16710, 266.0, 483.3000000000002, 664.1499999999996, 1075.0599999999995, 10.605441089293116, 2.3199402382828693, 22.764413588150653], "isController": false}, {"data": ["Update Skills", 7523, 2788, 37.059683636847005, 317.76565200053193, 37, 4186, 247.0, 679.0, 756.0, 874.0, 10.639847594048021, 2.3779771096718947, 7.010476229706432], "isController": false}, {"data": ["Add Languages", 7533, 228, 3.02668259657507, 176.37368910128828, 36, 93556, 122.0, 324.0, 365.0, 434.65999999999985, 10.646311525801723, 2.1631489627690024, 6.352437834243021], "isController": false}, {"data": ["Add Education", 7514, 1470, 19.563481501197764, 204.5991482565874, 44, 93357, 160.0, 376.0, 414.0, 485.85000000000036, 10.626758103362688, 2.1806663565309874, 7.098342326855546], "isController": false}, {"data": ["Disable existing listing", 14974, 0, 0.0, 301.44056364364974, 143, 24967, 260.0, 416.0, 587.0, 921.25, 21.196391489168946, 3.922579931038119, 12.02646821797574], "isController": false}, {"data": ["Delete Education", 7505, 1469, 19.573617588274484, 163.83157894736863, 1, 93595, 108.0, 303.0, 345.0, 412.0, 10.619706949858852, 2.2648959343007338, 6.146492293018303], "isController": false}, {"data": ["Delete Skills", 7516, 2786, 37.06758914316126, 129.3320915380525, 1, 26627, 92.0, 294.0, 337.0, 411.65999999999985, 10.630368399688273, 2.2521775919301983, 6.7615769764692075], "isController": false}, {"data": ["Update Languages", 7532, 233, 3.093467870419543, 405.4405204460964, 36, 17196, 342.0, 716.0, 784.3499999999995, 888.6700000000001, 10.647637007748234, 2.237348012385724, 6.659820314057228], "isController": false}, {"data": ["Delete Languages", 7526, 228, 3.029497741163965, 165.7110018602175, 3, 93347, 111.0, 314.0, 353.0, 429.72999999999956, 10.64580695810848, 2.031051633260013, 6.180441790910184], "isController": false}, {"data": ["Update Education", 7512, 7512, 100.0, 225.5350106496273, 3, 4541, 189.0, 438.0, 476.34999999999945, 557.0, 10.62340373176754, 2.0784355917258504, 7.497338392867244], "isController": false}, {"data": ["Delete existing listing", 7474, 0, 0.0, 360.91517259834126, 183, 1936, 325.0, 485.0, 630.25, 997.0, 10.59440058854631, 1.9657579217029288, 6.073157368629575], "isController": false}, {"data": ["Search Skill by all category", 7466, 0, 0.0, 1081.781007232787, 630, 28063, 1019.0, 1398.3000000000002, 1561.0, 1906.0, 10.577482967078895, 66.06795025140293, 7.9124530788890945], "isController": false}, {"data": ["Add Skills", 7524, 2788, 37.05475810738969, 168.51780967570448, 36, 94113, 120.0, 319.0, 362.0, 435.0, 10.642977883710898, 2.2631490073485208, 6.641467644229748], "isController": false}, {"data": ["SignIn", 7538, 0, 0.0, 286.8737065534616, 150, 1214, 261.0, 426.0, 486.0, 628.6099999999997, 10.642097698918144, 5.1131953787770765, 3.604024215254709], "isController": false}, {"data": ["Add Cretifications", 7502, 0, 0.0, 171.90189282857975, 36, 93355, 121.0, 322.0, 364.0, 443.97000000000025, 10.615506960501031, 2.3117754415934866, 6.976793148844917], "isController": false}, {"data": ["Delete Certification", 7497, 7497, 100.0, 92.72162198212617, 3, 570, 55.0, 247.0, 289.0, 368.0, 10.609032323798363, 1.1500025272867367, 6.040103364037545], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 17805, 65.94688692173784, 13.950263256863483], "isController": false}, {"data": ["500/Internal Server Error", 9194, 34.05311307826216, 7.203522627554219], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 127632, 26999, "Test failed: text expected to contain /true/", 17805, "500/Internal Server Error", 9194, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": ["Update Skills", 7523, 2788, "Test failed: text expected to contain /true/", 2788, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Languages", 7533, 228, "Test failed: text expected to contain /true/", 228, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Add Education", 7514, 1470, "Test failed: text expected to contain /true/", 1470, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Education", 7505, 1469, "Test failed: text expected to contain /true/", 1469, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Skills", 7516, 2786, "Test failed: text expected to contain /true/", 2786, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Languages", 7532, 233, "Test failed: text expected to contain /true/", 233, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 7526, 228, "500/Internal Server Error", 228, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Education", 7512, 7512, "Test failed: text expected to contain /true/", 6043, "500/Internal Server Error", 1469, "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Skills", 7524, 2788, "Test failed: text expected to contain /true/", 2788, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certification", 7497, 7497, "500/Internal Server Error", 7497, "", "", "", "", "", "", "", ""], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
