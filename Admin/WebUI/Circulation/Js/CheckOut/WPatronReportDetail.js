/**********************************************************************************/
/*************************		WStatIndex Js file		***************************/
/**********************************************************************************/
function GenRanNum(strIdlength){
var str;
str='';
for(i = 1;i<=strIdlength;i++){ 
	str=str + (String)(parseInt(9 * Math.random()+48));		
      } 
 return(str);
}
function GenURL(strIdlength) {
  
	document.images["anh1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src = '../../Common/WChartDir.aspx?i=2&x=' + GenRanNum(strIdlength);
	
}
function GenImage()
{
	document.images["anh1"].src='../../../WPrintBarCode.aspx';
	
}