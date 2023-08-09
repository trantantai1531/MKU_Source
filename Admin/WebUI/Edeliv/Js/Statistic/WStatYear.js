function GenRanNum(intNumber) {
    var str = '';
    var intCount;
    for (intCount = 1; intCount <= intNumber; intCount++) {
        str = str + (String)(parseInt(9 * Math.random() + 48));
    }
    return (str);
}

/*
	GenURLImg function
	Purpose: set image source	
*/
function GenURLImg(intNumber) {
    document.images["chart1"].src = '../../Common/WChartDir.aspx?i=1&x=' + GenRanNum(intNumber);
    document.images["chart2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(intNumber);
    document.images["chart3"].src = '../../Common/WChartDir.aspx?i=3&x=' + GenRanNum(intNumber);
    document.images["chart4"].src = '../../Common/WChartDir.aspx?i=4&x=' + GenRanNum(intNumber);
    document.images["chart5"].src = '../../Common/WChartDir.aspx?i=5&x=' + GenRanNum(intNumber);
    document.images["chart6"].src = '../../Common/WChartDir.aspx?i=6&x=' + GenRanNum(intNumber);
}