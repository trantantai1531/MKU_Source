function GenRanNum(strIdlength) {
    var str;
    str = '';
    for (i = 1; i <= strIdlength; i++) {
        str = str + (String)(parseInt(9 * Math.random() + 48));
    }
    return (str);
}
function GenURLImg(strIdlength) {
    document.images["chart1"].src = '../../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
    document.images["chart2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(strIdlength);
    document.images["chart3"].src = '../../Common/WChartDir.aspx?i=3&x=' + GenRanNum(strIdlength);
    document.images["chart4"].src = '../../Common/WChartDir.aspx?i=4&x=' + GenRanNum(strIdlength);

}