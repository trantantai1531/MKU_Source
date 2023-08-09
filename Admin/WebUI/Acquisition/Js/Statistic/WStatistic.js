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
	if(document.forms[0].hidHave.value>0) {
		document.images["Image1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
		document.images["Image2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(intNumber);
	}
	if(document.forms[0].hidHave1.value>0) {
		document.images["Image3"].src='../../Common/WChartDir.aspx?i=3&x='+GenRanNum(intNumber);
		document.images["Image4"].src='../../Common/WChartDir.aspx?i=4&x='+GenRanNum(intNumber);
	}
}
function GenURLImg1(intNumber){
	if(document.forms[0].hidHave.value>0) {
		document.images["Image1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
		document.images["Image2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(intNumber);
	}
}