/**************************************************************************
************************ Statistic Index Js file *************************
**************************************************************************/
// Gen random number function
function GenRanNum(strIdlength)
{

var str;
str='';
for(i = 1;i<=strIdlength;i++){ 
	str=str + (String)(parseInt(9 * Math.random()+48));		
      } 
 return(str);
}

// Gen Image url function
function GenURL(strIdlength){
	document.images["anh1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src='../Common/WChartDir.aspx?i=2&x='+GenRanNum(strIdlength);
}
function GenImageURL(strIdlength) {
    document.images["chart1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
    document.images["chart2"].src = '../Common/WChartDir.aspx?i=2&x=' + GenRanNum(strIdlength);
}
