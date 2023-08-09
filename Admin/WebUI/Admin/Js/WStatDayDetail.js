/*
	GenURLImg function
	Purpose: set image source
*/
function GenURLImg(intNumber){
	document.images["Image1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
	document.images["Image2"].src='../Common/WChartDir.aspx?i=2&x='+GenRanNum(intNumber);
}
