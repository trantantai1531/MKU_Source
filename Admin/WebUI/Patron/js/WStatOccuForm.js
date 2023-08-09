/**************************************************************************
************************ Statistic Occupation Js file *********************
**************************************************************************/
function AddItem(){
var k = 0;
var strlbDest ='';
	for (i = 0; i < document.forms[0].lbSource.length; i++) {
		if(document.forms[0].lbSource.options[i].selected) {
			document.forms[0].lbDest.length++;
			document.forms[0].lbDest.options[(document.forms[0].lbDest.length)- 1].value = document.forms[0].lbSource.options[i].value;
			document.forms[0].lbDest.options[(document.forms[0].lbDest.length)- 1].text = document.forms[0].lbSource.options[i].text;
		}
			else {document.forms[0].lbSource.options[k].value =document.forms[0].lbSource.options[i].value;
				document.forms[0].lbSource.options[k].text =document.forms[0].lbSource.options[i].text;
				document.forms[0].lbSource.options[k].selected = false;
				k = k + 1;
			}
	}
	document.forms[0].lbSource.length = k;
	for (i=0;i<document.forms[0].lbDest.length;i++){
		strlbDest+=document.forms[0].lbDest.options[i].value + ',';
	}
	document.forms[0].txtID.value=strlbDest;
}
function RemoveItem(){
var k=0;              
var strlbSource='';
	for (i = 0; i < document.forms[0].lbDest.length; i++) {	
		if(document.forms[0].lbDest.options[i].selected) {
			document.forms[0].lbSource.length++;
			document.forms[0].lbSource.options[(document.forms[0].lbSource.length)- 1].value = document.forms[0].lbDest.options[i].value;
			document.forms[0].lbSource.options[(document.forms[0].lbSource.length)- 1].text = document.forms[0].lbDest.options[i].text;
		}
		else {document.forms[0].lbDest.options[k].value =document.forms[0].lbDest.options[i].value;
			document.forms[0].lbDest.options[k].text =document.forms[0].lbDest.options[i].text;
			document.forms[0].lbDest.options[k].selected = false;
			k = k + 1;
			strlbSource+=document.forms[0].lbDest.options[i].value + ',';
		}
	}		
	document.forms[0].lbDest.length = k;
	document.forms[0].txtID.value=strlbSource;
}
// Check occupation for page submit action
function CheckOccupation(strMsg){
	if(document.forms[0].lbDest.length > 0){
		var strID;
		strID=document.forms[0].txtID.value;
		strID=strID.substring(0,strID.length-1);
		document.forms[0].txtID.value=strID;
	}else{
		alert(strMsg);
		return false;
	}
	return true;	
}
function Rechoose(){
	self.location.href='WStatIndex.aspx';
}
function OpenWin(url) {
	NewWin = window.open(url, "NewWin", "width=520,height=400,menubar=yes,resizable,scrollbars=yes,top=20,left=40,ScreenX=20,ScreenY=40");
	NewWin.focus()
}
function catchKeyPress(code, sender) {
testForEnter();
if(code == '13') {
    switch (sender.name) {
    case 'txtZipCPOA':                        
        document.getElementById('btnUpdateCPOA').click() ;                     
        break;
    case 'txtFirstName':
        document.getElementById('txtMiddleName').focus();
        break;
    case 'txtMiddleName':
        document.getElementById('txtLastName').focus();
        break;
        }    }                  
    }
function testForEnter() {    
    if (event.keyCode == 13) {        
        event.cancelBubble = true;		         
	    event.returnValue = false;   }
} 
function GenRanNum(strIdlength)
{
var str;
str='';
for(i = 1;i<=strIdlength;i++){ 
	str=str + (String)(parseInt(9 * Math.random()+48));		
      } 
 return(str);
}
function GenURL(strIdlength){
	document.images["anh1"].src='../WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src='../WChartDir.aspx?i=2&x='+GenRanNum(strIdlength);
}
function GenImage()
{
	document.images["anh1"].src='../WPrintBarCode.aspx';
}
function setFocusIt(control){	
	control.focus();
}
function CheckDate(f,strMSG) {
	val = f.value;
	if (val == "") return;
	iday = val.substring(0, val.indexOf("/"));
	imon = val.substring(val.indexOf("/") + 1, val.lastIndexOf("/"));
	iyear = val.substring(val.lastIndexOf("/") + 1, val.length);
	mDate = new Date(imon + "/" + iday + "/" + iyear);
	if (mDate.getDate() != iday || mDate.getMonth() != imon - 1) {
		alert("strMSG");
		f.value = "";
	}
}
