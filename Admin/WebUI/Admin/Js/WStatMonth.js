/*
	GenURLImg function
	Purpose: set image source
*/
function GenURLImg(intNumber){
	document.images["Image1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
}

/*
	MovePrevMonth function
	Purpose: stat for previous month
*/
function MovePrevMonth() {
	intThisMonth = parseFloat(document.forms[0].hidMonth.value) - 1;
	intThisYear = parseFloat(document.forms[0].hidYear.value);
	
	if (intThisMonth <= 0) {
		document.forms[0].hidMonth.value = 12;
		document.forms[0].hidYear.value = intThisYear - 1;
	} else {
		document.forms[0].hidMonth.value = intThisMonth;
	}
	document.forms[0].submit();
}

/*
	MoveNextMonth function
	Purpose: stat for next month
*/
function MoveNextMonth() {
	intThisMonth = parseFloat(document.forms[0].hidMonth.value) + 1;
	intThisYear = parseFloat(document.forms[0].hidYear.value);
	
	if (intThisMonth > 12) {
		document.forms[0].hidMonth.value = 1;
		document.forms[0].hidYear.value = intThisYear + 1;
	} else {
		document.forms[0].hidMonth.value = intThisMonth;
	}
	document.forms[0].submit();
}