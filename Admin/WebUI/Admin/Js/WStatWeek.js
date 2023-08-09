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
		document.images["Image1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
}