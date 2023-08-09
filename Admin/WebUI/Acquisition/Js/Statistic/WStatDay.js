/**********************************************************************************/
/************************		WStatDay Js file		***************************/
/**********************************************************************************/
function GenURLImg(strIdlength){
	document.images["anh1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(strIdlength);
	document.images["anh3"].src='../../Common/WChartDir.aspx?i=3&x='+GenRanNum(strIdlength);
	document.images["anh4"].src='../../Common/WChartDir.aspx?i=4&x='+GenRanNum(strIdlength);
	document.images["anh5"].src='../../Common/WChartDir.aspx?i=5&x='+GenRanNum(strIdlength);
	document.images["anh6"].src='../../Common/WChartDir.aspx?i=6&x='+GenRanNum(strIdlength);
	
}
// Tranfser data
function TransferData(){
	parent.Display.location.href='WStatDay.aspx?year=' + document.forms[0].ddlYear.options[document.forms[0].ddlYear.options.selectedIndex].value + '&month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value;	
	return(false);
}

// Export data
function TransferDataExport() {
    parent.Display.location.href = 'WStatDay.aspx?export=true&year=' + document.forms[0].ddlYear.options[document.forms[0].ddlYear.options.selectedIndex].value + '&month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value;
    return (false);
}