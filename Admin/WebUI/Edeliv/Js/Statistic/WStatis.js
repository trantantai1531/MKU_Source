/*
	GenRanNum function
	Purpose: Generate random number
*/
function GenRanNum(intNumber) {
	var str = '';
	var intCount;
	for(intCount = 1; intCount<=intNumber;intCount++){ 
		str=str + (String)(parseInt(9 * Math.random()+48));
	} 
	return(str);
}

/*
	GenURLImg function
	Purpose: set image source	
*/
function GenURLImg(intNumber){
	document.images["Image1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
	document.images["Image2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(intNumber);
	document.images["Image3"].src='../../Common/WChartDir.aspx?i=3&x='+GenRanNum(intNumber);
	document.images["Image4"].src='../../Common/WChartDir.aspx?i=4&x='+GenRanNum(intNumber);
	document.images["Image5"].src='../../Common/WChartDir.aspx?i=5&x='+GenRanNum(intNumber);
	document.images["Image6"].src='../../Common/WChartDir.aspx?i=6&x='+GenRanNum(intNumber);
}
function GenURLImg1(intNumber){
	document.images["Image1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
	document.images["Image2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(intNumber);	
}

function LoadStatMonth() {
	parent.Main.location.href='WStatisticMonth.aspx?Year=' + intYear;
}

function LoadStatDay() {
	parent.Main.location.href='WStatisticDay.aspx?Year=' + intYear + ',' + 'Month=' + intMonth;
}
