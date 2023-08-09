/**********************************************************************************/
/*******************		WStatClassItemID Js file		***********************/
/**********************************************************************************/
// Generate Image URL
function GenAcqURL(strIdlength){
	document.images["anh1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(strIdlength);
}