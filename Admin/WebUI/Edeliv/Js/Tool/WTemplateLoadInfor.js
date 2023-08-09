
//method Find Index
//return Index if found out or -1 if not found
function FindIndex(b) {
var a=new Array('<$NO$>', '<$NOTE$>','<$FILESIZE$>', '<$PRICE$>', '<$CURRENCY$>');
	for (k = 0; k < a.length; k++) {
		if (trim(a[k]) == trim(b)) {
			return k;
		}	
	}
	return - 1;
}

//upload data to form WBillTemplateMan.aspx
function LoadBackData(strTitle,strHeader,strCollums,strCollumCaption,strCollumWidth,strCollumAlign,strCollumFormat,strFooter){	
	//DecryptionTags();
	parent.Workform.document.forms[0].txtTitle.value=strTitle;
	parent.Workform.document.forms[0].txtHeader.value=strHeader;
	parent.Workform.document.forms[0].txtCollum.value=strCollums;
	parent.Workform.document.forms[0].txtCollumCaption.value=strCollumCaption;
	parent.Workform.document.forms[0].txtCollumWidth.value=strCollumWidth;
	parent.Workform.document.forms[0].txtAlign.value=strCollumAlign;
	parent.Workform.document.forms[0].txtFormat.value=strCollumFormat;
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

//upload data to form WBillTemplateMan.aspx
function LoadBackDataPack(strTitle,strContents){	
	//DecryptionTags();
	parent.Workform.document.forms[0].txtTitle.value=strTitle;
	parent.Workform.document.forms[0].txtContents.value=strContents;
}

//refesh all controls on WClaimTemplateManagement
function RefeshPagePack()
{	
	parent.Workform.document.forms[0].txtTitle.value='';
	parent.Workform.document.forms[0].txtContents.value='';
}


//refesh all controls on WClaimTemplateManagement
function RefeshPage()
{	
	parent.Workform.document.forms[0].txtTitle.value='';
	parent.Workform.document.forms[0].txtHeader.value='';
	parent.Workform.document.forms[0].txtCollumCaption.value='';
	parent.Workform.document.forms[0].txtCollumWidth.value='';
	parent.Workform.document.forms[0].txtAlign.value='';
	parent.Workform.document.forms[0].txtFormat.value='';
	parent.Workform.document.forms[0].txtFooter.value='';
	parent.Workform.document.forms[0].lsbCollum.options.length=0;	
	parent.Workform.document.forms[0].txtCollum.value='';
	for(i=0;i<parent.Workform.document.forms[0].lsbTemp.options.length;i++){
		parent.Workform.document.forms[0].lsbAllCollums.length=i+1;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].value=parent.Workform.document.forms[0].lsbTemp.options[i].value;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].text=parent.Workform.document.forms[0].lsbTemp.options[i].text;
	}
	parent.Workform.document.forms[0].txtTitle.focus();
}