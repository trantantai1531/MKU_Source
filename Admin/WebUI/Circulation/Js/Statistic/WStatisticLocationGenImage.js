function GenURLImg(strIdlength) {
    document.images["image1"].src = '../../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
    document.images["image2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(strIdlength);

}