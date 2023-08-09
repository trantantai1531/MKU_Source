//method Find Index
//return Index if found out or -1 if not found
function FindIndex(b) {
var a=new Array('<$NUMBER$>','<$TOTALNUMBER$>','<$ISSUEDATE$>','<$LESSAMOUNT$>','<$PRICE$>','<$SPECIALTITLE$>','<$SPECIALISSUE$>');
	for (k = 0; k < a.length; k++) {
		if (a[k] == b) {
			return k;
		}	
	}
	return - 1;
}
//upload data to form WClaimTemplateManagement.aspx
function LoadBackData(strTitle,strHeader,strPageHeader,strCollums,strCollumCaption,strCollumWidth,strCollumAlign,strFormat,strTableColor,strOddColor,strEventColor,strPageFooter,strFooter){
		//DecryptionTags();
		parent.Workform.document.forms[0].txtCaption.value=strTitle;
		parent.Workform.document.forms[0].txtHeader.value=strHeader;
		parent.Workform.document.forms[0].txtPageHeader.value=strPageHeader;
		parent.Workform.document.forms[0].hidCollum.value=strCollums;
		parent.Workform.document.forms[0].txtCollumCaption.value=strCollumCaption;
		parent.Workform.document.forms[0].txtCollumWidth.value=strCollumWidth;
		parent.Workform.document.forms[0].txtAlign.value=strCollumAlign;
		parent.Workform.document.forms[0].txtFormat.value=strFormat;
		parent.Workform.document.forms[0].txtTableColor.value=strTableColor;
		parent.Workform.document.forms[0].txtOddColor.value=strOddColor;
		parent.Workform.document.forms[0].txtEventColor.value=strEventColor;
		parent.Workform.document.forms[0].txtPageFooter.value=strPageFooter;
		parent.Workform.document.forms[0].txtFooter.value=strFooter;
	for(i=0;i<parent.Workform.document.forms[0].lsbTemp.options.length;i++){
	parent.Workform.document.forms[0].lsbAllCollums.options.length=i+1;
	parent.Workform.document.forms[0].lsbAllCollums.options[i].value=parent.Workform.document.forms[0].lsbTemp.options[i].value;
	parent.Workform.document.forms[0].lsbAllCollums.options[i].text=parent.Workform.document.forms[0].lsbTemp.options[i].text;
	}
	parent.Workform.document.forms[0].lsbCollum.options.length=0;
	if(strCollums.length>0){
		var ArrStrSelectCollum;
		ArrStrSelectCollum=strCollums.split('<~>');
		for(i = 0;i<ArrStrSelectCollum.length;i++){
		var index;
			index=-1;
			index=FindIndex(ArrStrSelectCollum[i]);
			if(index>=0){
				parent.Workform.document.forms[0].lsbCollum.options.length++;
				parent.Workform.document.forms[0].lsbCollum.options[parent.Workform.document.forms[0].lsbCollum.options.length-1].value=parent.Workform.document.forms[0].lsbTemp.options[index].value;
				parent.Workform.document.forms[0].lsbCollum.options[parent.Workform.document.forms[0].lsbCollum.options.length-1].text=parent.Workform.document.forms[0].lsbTemp.options[index].text;
				parent.Workform.document.forms[0].lsbAllCollums.options[index].value='--';
			}				
		}
		for(i=0,k=0;i<parent.Workform.document.forms[0].lsbAllCollums.options.length;i++){
			if(parent.Workform.document.forms[0].lsbAllCollums.options[i].value!='--'){
				parent.Workform.document.forms[0].lsbAllCollums.options[k].value=parent.Workform.document.forms[0].lsbAllCollums.options[i].value;
				parent.Workform.document.forms[0].lsbAllCollums.options[k].text=parent.Workform.document.forms[0].lsbAllCollums.options[i].text;
				k = k + 1 ;
				}
		}
		parent.Workform.document.forms[0].lsbAllCollums.options.length=k;		
	}
}
//refesh all controls on WClaimTemplateManagement
function RefeshPage()
{	
	parent.Workform.document.forms[0].txtCaption.value='';
	parent.Workform.document.forms[0].txtHeader.value='';
	parent.Workform.document.forms[0].txtPageHeader.value='';
	parent.Workform.document.forms[0].txtCollumCaption.value='';
	parent.Workform.document.forms[0].txtCollumWidth.value='';
	parent.Workform.document.forms[0].txtAlign.value='';
	parent.Workform.document.forms[0].txtFormat.value='';
	parent.Workform.document.forms[0].txtTableColor.value='';
	parent.Workform.document.forms[0].txtOddColor.value='';
	parent.Workform.document.forms[0].txtEventColor.value='';
	parent.Workform.document.forms[0].txtPageFooter.value='';
	parent.Workform.document.forms[0].txtFooter.value='';
	parent.Workform.document.forms[0].lsbCollum.options.length=0;	
	parent.Workform.document.forms[0].hidCollum.value='';
	for(i=0;i<parent.Workform.document.forms[0].lsbTemp.options.length;i++){
		parent.Workform.document.forms[0].lsbAllCollums.length=i+1;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].value=parent.Workform.document.forms[0].lsbTemp.options[i].value;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].text=parent.Workform.document.forms[0].lsbTemp.options[i].text;
	}
	parent.Workform.document.forms[0].txtCaption.focus();
}