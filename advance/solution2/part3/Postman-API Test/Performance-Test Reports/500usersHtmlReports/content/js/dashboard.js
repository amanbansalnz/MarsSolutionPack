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

    var data = {"OkPercent": 99.91428571428571, "KoPercent": 0.08571428571428572};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9690952380952381, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.884, 500, 1500, "Add Education"], "isController": false}, {"data": [0.999, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.989, 500, 1500, "Active status Skill"], "isController": false}, {"data": [0.569, 500, 1500, "Update Education"], "isController": false}, {"data": [0.992, 500, 1500, "delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [0.995, 500, 1500, "Add Description info"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.9975, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.972, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.999, 500, 1500, "View Share Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.987, 500, 1500, "SignIn"], "isController": false}, {"data": [0.992, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Sign out"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.989, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 10500, 9, 0.08571428571428572, 268.19295238095276, 99, 1554, 309.0, 419.0, 531.0, 826.9799999999996, 34.43808524246052, 7.892259784106004, 25.500428426179507], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Education", 500, 0, 0.0, 396.6559999999996, 126, 1382, 333.0, 615.0, 628.95, 1009.7500000000002, 1.668357268698948, 0.33725581505926, 1.1247106703542922], "isController": false}, {"data": ["Add Certification", 500, 0, 0.0, 108.45600000000005, 102, 595, 106.0, 109.0, 110.0, 118.0, 1.669460230118398, 0.33747877698682466, 1.0939529437592237], "isController": false}, {"data": ["Delete Education", 500, 0, 0.0, 105.33199999999992, 100, 422, 104.0, 107.0, 108.0, 112.0, 1.666738892018654, 0.35483308443365874, 0.978232494241417], "isController": false}, {"data": ["Active status Skill", 1000, 0, 0.0, 317.81600000000026, 302, 653, 311.0, 316.0, 318.94999999999993, 638.98, 3.323937669520821, 0.6167462472743711, 1.9313895638328988], "isController": false}, {"data": ["Update Education", 500, 0, 0.0, 658.448, 225, 1554, 632.0, 848.9000000000001, 937.0, 1251.2300000000007, 1.6660779857783583, 0.35617623439717966, 1.1861043472972883], "isController": false}, {"data": ["delete Skill", 500, 0, 0.0, 420.606, 406, 757, 415.0, 421.0, 425.0, 732.94, 1.6648076314781826, 0.3121514309021593, 0.9770990102718632], "isController": false}, {"data": ["Add Language", 500, 0, 0.0, 108.72599999999998, 102, 122, 108.0, 111.0, 112.0, 114.99000000000001, 1.6693821950372607, 0.33746300231710247, 0.9895621617414327], "isController": false}, {"data": ["Add Description info", 500, 0, 0.0, 314.768, 303, 658, 311.0, 317.0, 319.0, 625.1300000000026, 1.6655729404357806, 0.3578379364217497, 1.0539953763695173], "isController": false}, {"data": ["Add Skill", 500, 0, 0.0, 106.83000000000003, 102, 120, 107.0, 109.0, 110.0, 115.0, 1.66942678561889, 0.33747201623350603, 1.0319796438444895], "isController": false}, {"data": ["Add Share Skill", 1000, 0, 0.0, 314.44899999999967, 303, 650, 312.0, 319.0, 321.0, 331.97, 3.323981864354948, 0.727121032827645, 6.14806801864089], "isController": false}, {"data": ["Update Certification", 500, 9, 1.8, 415.24399999999997, 205, 755, 412.0, 418.0, 421.0, 738.9300000000001, 1.6677673931461432, 0.28345530967104954, 1.1579908364520584], "isController": false}, {"data": ["View Share Skill", 500, 0, 0.0, 108.53600000000006, 102, 756, 106.0, 109.0, 110.94999999999999, 118.97000000000003, 1.6677228911644042, 0.8719194031219772, 0.8664341583002568], "isController": false}, {"data": ["Delete Language", 500, 0, 0.0, 106.156, 100, 450, 105.0, 107.0, 108.0, 114.98000000000002, 1.6694212116659155, 0.31464677133937663, 1.046648845595232], "isController": false}, {"data": ["SignIn", 500, 0, 0.0, 360.06600000000026, 339, 715, 351.0, 359.0, 361.0, 706.0, 1.6677173285836744, 0.8012860602179374, 1.0664009992962233], "isController": false}, {"data": ["Update Language", 500, 0, 0.0, 419.2459999999999, 404, 755, 414.0, 421.0, 422.0, 740.96, 1.6677006410641266, 0.35015199006717496, 1.0325412172213437], "isController": false}, {"data": ["Delete Certification", 500, 0, 0.0, 105.9600000000001, 100, 416, 105.0, 108.0, 109.0, 116.94000000000005, 1.6695382724953587, 0.330972919254451, 1.1592204216251953], "isController": false}, {"data": ["Sign out", 500, 0, 0.0, 105.80000000000007, 99, 445, 104.0, 106.0, 108.0, 115.95000000000005, 1.6677173285836744, 0.3383609538592647, 0.8843462006063821], "isController": false}, {"data": ["Delete Skill", 500, 0, 0.0, 106.95799999999997, 101, 440, 105.0, 107.0, 108.0, 116.97000000000003, 1.6694379336365033, 0.3195212907593271, 1.0906777125027545], "isController": false}, {"data": ["Update Skill", 500, 0, 0.0, 419.73400000000004, 207, 766, 413.0, 419.0, 422.0, 747.8700000000001, 1.667678391557545, 0.3372130394522677, 1.0878995757426173], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 9, 100.0, 0.08571428571428572], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 10500, 9, "500/Internal Server Error", 9, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 500, 9, "500/Internal Server Error", 9, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
