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

/*
	GenURLImg function
	Purpose: set image source
*/
function GenURLImg(intNumber){
	alert('Hello');
	document.images["anh1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
}
