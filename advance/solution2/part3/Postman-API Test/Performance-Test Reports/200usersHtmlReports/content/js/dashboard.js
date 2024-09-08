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

    var data = {"OkPercent": 99.95238095238095, "KoPercent": 0.047619047619047616};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9766666666666667, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.95, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Active status Skill"], "isController": false}, {"data": [0.62, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "delete Skill"], "isController": false}, {"data": [0.995, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description info"], "isController": false}, {"data": [0.995, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.995, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.98, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "View Share Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.99, 500, 1500, "SignIn"], "isController": false}, {"data": [0.99, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Sign out"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 2100, 1, 0.047619047619047616, 268.3347619047614, 102, 1164, 316.0, 426.0, 441.9499999999998, 742.9899999999998, 6.943204586482572, 1.6569151837965441, 5.14096125981141], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Education", 100, 0, 0.0, 345.93, 129, 735, 335.0, 518.3000000000004, 569.5499999999997, 734.0099999999995, 0.34004352557127315, 0.06873926737622416, 0.22923051338071274], "isController": false}, {"data": ["Add Certification", 100, 0, 0.0, 109.36999999999999, 103, 116, 109.0, 112.0, 112.94999999999999, 115.96999999999998, 0.3403085237075933, 0.0687928363354217, 0.2229951361404249], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 108.30999999999997, 104, 132, 108.0, 110.0, 112.0, 131.96999999999997, 0.33947673056750327, 0.07227141334347237, 0.19924366706159125], "isController": false}, {"data": ["Active status Skill", 200, 0, 0.0, 317.44000000000017, 304, 330, 318.0, 322.0, 323.95, 330.0, 0.6787552985335492, 0.12594092453259215, 0.39439394787838067], "isController": false}, {"data": ["Update Education", 100, 0, 0.0, 598.1499999999997, 235, 944, 643.0, 746.8, 844.95, 943.4299999999997, 0.339330433189231, 0.07278041312631915, 0.2415741072216303], "isController": false}, {"data": ["delete Skill", 100, 0, 0.0, 425.67, 409, 444, 426.0, 429.9, 433.95, 443.92999999999995, 0.3399776294719808, 0.06374580552599639, 0.19953765167251994], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 119.36, 108, 845, 112.0, 114.0, 115.94999999999999, 837.7499999999962, 0.3377591034522358, 0.06827747501427033, 0.20021462480029992], "isController": false}, {"data": ["Add Description info", 100, 0, 0.0, 318.11000000000007, 308, 334, 318.0, 323.0, 324.0, 333.99, 0.3392371912517513, 0.07288299030799344, 0.2146735350889989], "isController": false}, {"data": ["Add Skill", 100, 0, 0.0, 117.46999999999998, 105, 841, 110.0, 113.0, 114.0, 833.7999999999963, 0.33944907415265024, 0.06861909995077987, 0.209835218690066], "isController": false}, {"data": ["Add Share Skill", 200, 0, 0.0, 328.42499999999995, 308, 1078, 321.0, 326.0, 327.0, 1044.9900000000064, 0.6770136926019329, 0.1480967452566728, 1.252210872839903], "isController": false}, {"data": ["Update Certification", 100, 1, 1.0, 424.02000000000004, 223, 724, 422.0, 428.0, 429.0, 722.3599999999992, 0.3399487357306518, 0.057884239806637164, 0.2360386241254819], "isController": false}, {"data": ["View Share Skill", 100, 0, 0.0, 110.47000000000001, 105, 115, 111.0, 113.0, 113.0, 115.0, 0.34034442856170444, 0.2455864240861752, 0.176819566401198], "isController": false}, {"data": ["Delete Language", 100, 0, 0.0, 108.59000000000002, 104, 117, 109.0, 110.0, 111.94999999999999, 116.95999999999998, 0.33944907415265024, 0.06397819464009911, 0.2128186578183608], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 370.68999999999994, 344, 1149, 360.0, 365.9, 368.0, 1144.5199999999977, 0.3365745462133681, 0.1617135515009542, 0.21493440162094302], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 436.77000000000004, 411, 1164, 422.5, 427.0, 429.95, 1163.8899999999999, 0.3382480779052973, 0.07101888354456926, 0.20942312635933444], "isController": false}, {"data": ["Delete Certification", 100, 0, 0.0, 108.64000000000003, 103, 114, 109.0, 110.0, 111.0, 113.99, 0.3403073656126213, 0.06746327658140833, 0.2362876337407947], "isController": false}, {"data": ["Sign out", 100, 0, 0.0, 111.11, 103, 429, 108.0, 110.0, 111.0, 425.8499999999984, 0.3403479036270876, 0.06873099901469282, 0.18047745280225447], "isController": false}, {"data": ["Delete Skill", 100, 0, 0.0, 108.44000000000001, 102, 113, 109.0, 110.0, 111.0, 112.99, 0.3403073656126213, 0.0651369566992908, 0.22232971444808952], "isController": false}, {"data": ["Update Skill", 100, 0, 0.0, 422.1999999999999, 407, 436, 422.0, 427.0, 429.0, 436.0, 0.3399475800831512, 0.06871987214571512, 0.22176267919486814], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 1, 100.0, 0.047619047619047616], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 2100, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 100, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
