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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9604761904761905, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.81, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.975, 500, 1500, "Active status Skill"], "isController": false}, {"data": [0.535, 500, 1500, "Update Education"], "isController": false}, {"data": [0.995, 500, 1500, "delete Skill"], "isController": false}, {"data": [0.995, 500, 1500, "Add Language"], "isController": false}, {"data": [0.995, 500, 1500, "Add Description info"], "isController": false}, {"data": [0.995, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.995, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.97, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "View Share Skill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.98, 500, 1500, "SignIn"], "isController": false}, {"data": [0.975, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Sign out"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.98, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 2100, 1, 0.047619047619047616, 282.9871428571437, 101, 1299, 316.0, 431.0, 636.9499999999998, 847.9799999999996, 6.935270805812417, 1.6549735025181638, 5.135086845690225], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Education", 100, 0, 0.0, 471.90999999999997, 130, 946, 435.0, 633.9, 749.0999999999998, 945.2299999999996, 0.34000652812534005, 0.06873178840033728, 0.2292055726219943], "isController": false}, {"data": ["Add Certification", 100, 0, 0.0, 124.27999999999997, 105, 456, 109.0, 112.0, 239.79999999999905, 455.98, 0.3404904424332809, 0.06882961092157143, 0.22311434264915184], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 107.60000000000004, 103, 119, 107.0, 110.0, 112.89999999999998, 118.95999999999998, 0.3393223732206783, 0.07223855211143347, 0.1991530725640895], "isController": false}, {"data": ["Active status Skill", 200, 0, 0.0, 333.07499999999993, 307, 660, 316.0, 323.0, 616.2499999999975, 656.0, 0.6784329555592492, 0.12588111480103256, 0.39420664898218094], "isController": false}, {"data": ["Update Education", 100, 0, 0.0, 704.72, 232, 1179, 738.5, 848.9, 1038.95, 1178.98, 0.3391785096496286, 0.07269814384560595, 0.24146595071736257], "isController": false}, {"data": ["delete Skill", 100, 0, 0.0, 427.49000000000007, 414, 739, 424.0, 429.0, 434.0, 736.4399999999987, 0.3398297452976059, 0.06371807724330111, 0.19945085637095816], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 117.52000000000001, 105, 836, 110.0, 113.0, 114.0, 828.8899999999963, 0.33796800118964737, 0.06831970336548535, 0.20033845383019133], "isController": false}, {"data": ["Add Description info", 100, 0, 0.0, 320.7, 309, 659, 317.0, 322.0, 323.0, 655.6499999999983, 0.3390784525815738, 0.0728488862968225, 0.21457308327427718], "isController": false}, {"data": ["Add Skill", 100, 0, 0.0, 119.58999999999996, 104, 850, 109.0, 112.0, 114.0, 845.7799999999978, 0.339636995978698, 0.06865708805428758, 0.20995138520948808], "isController": false}, {"data": ["Add Share Skill", 200, 0, 0.0, 329.21500000000003, 307, 1090, 321.0, 328.0, 331.0, 1047.8500000000056, 0.6766586595391954, 0.148019081774199, 1.251554200358629], "isController": false}, {"data": ["Update Certification", 100, 1, 1.0, 426.29999999999995, 219, 755, 419.0, 427.0, 432.0, 754.8699999999999, 0.3401198582380431, 0.057913377424204285, 0.23615744063207875], "isController": false}, {"data": ["View Share Skill", 100, 0, 0.0, 109.58, 105, 113, 110.0, 112.0, 113.0, 113.0, 0.3401939105290015, 0.24547781297839769, 0.17674136757952033], "isController": false}, {"data": ["Delete Language", 100, 0, 0.0, 113.97999999999996, 101, 446, 107.0, 110.0, 111.0, 445.8299999999999, 0.3396381495155062, 0.06401383091454364, 0.21293719920796383], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 379.2500000000001, 347, 1299, 358.0, 370.70000000000005, 403.79999999999995, 1293.269999999997, 0.3365994701924339, 0.161725526694021, 0.2149503179181996], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 443.38, 410, 1151, 419.0, 425.0, 719.9999999999966, 1150.99, 0.33844039895354233, 0.07105926345215975, 0.2095422001333455], "isController": false}, {"data": ["Delete Certification", 100, 0, 0.0, 107.31999999999998, 102, 137, 107.0, 110.0, 110.0, 136.76999999999987, 0.3404916017746422, 0.06749979996118396, 0.2364155555290729], "isController": false}, {"data": ["Sign out", 100, 0, 0.0, 107.27, 102, 137, 107.0, 110.0, 111.0, 136.8499999999999, 0.34018812403259, 0.0686987325866204, 0.18039272592743788], "isController": false}, {"data": ["Delete Skill", 100, 0, 0.0, 107.67999999999996, 102, 116, 108.0, 110.0, 111.0, 115.99, 0.3404962392190378, 0.06517310828801895, 0.22245310941165652], "isController": false}, {"data": ["Update Skill", 100, 0, 0.0, 429.58, 411, 753, 420.0, 424.0, 426.95, 752.8699999999999, 0.3401291130112991, 0.06875656874349503, 0.22188110106596465], "isController": false}]}, function(index, item){
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
