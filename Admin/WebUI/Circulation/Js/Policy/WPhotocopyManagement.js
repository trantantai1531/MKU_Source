function ValidNew(strMsg){
	if (CheckNull(document.forms[0].txtCardNo)){
		alert(strMsg);
		document.forms[0].txtCardNo.focus();
		return false;
	}else{
		if (CheckNull(document.forms[0].txtCopyNumber)){
			alert(strMsg);
			document.forms[0].txtCopyNumber.focus();
			return false;
		}else{
			if (!CheckNum(document.forms[0].txtPageCount)){
				alert(strMsg);
				document.forms[0].txtPageCount.focus();
				return false;
			}else{
				if (! CheckNum(document.forms[0].txtPaidAmount)){
					alert(strMsg);
					document.forms[0].txtPaidAmount.focus();
					return false;
				}else{
					if (CheckNull(document.forms[0].txtInputer)){
						alert(strMsg);
						document.forms[0].txtInputer.focus();
						return false;
					}else{
						if (document.forms[0].ddlTypeID.options[document.forms[0].ddlTypeID.options.selectedIndex].value==0){
							alert(strMsg);
							document.forms[0].ddlTypeID.focus();
							return false;
						}else{
							return true;
						}					
					}					
				}				
			}			
		}		
	}
}

function GetPrice(){
	var strIDs;
	var strPrice;
	var intPgCount;
	var dblPrice;
	var intIDselected;
	var intIndex;
	var intCount;
	strPrice=document.forms[0].txtHidDataPrice.value;
	strIDs=document.forms[0].txtHidDataTypeID.value;
	alert(strPrice + '--' + strIDs);
	intIDselected=document.forms[0].ddlTypeID.options[document.forms[0].ddlTypeID.options.selectedIndex].value;
	if(document.forms[0].txtPageCount.value!=''){
		intPgCount=document.forms[0].txtPageCount.value;
	}else{
		intPgCount=0;
	}
	arrIDs=strIDs.split(';');
	arrPrice=strPrice.split(';');
	for(intCount=0; intCount<=arrIDs.length; intCount++)	{
		if(arrIDs[intCount]==intIDselected){
			intIndex=intCount;
			break;
		}
	}
	alert(arrPrice[intIndex]);
	dblPrice=parseFloat(arrPrice[intIndex]) * intPgCount;
	document.forms[0].txtAmount.value=dblPrice;
}

function NewPhotoType(){
	var url;
	url='WPhotocopyPrice.aspx';
	openModal(url,'newphotoType',550,350,100,100,'yes','',0)
	//openModal(url,'newphotoType',wWidth,wHeight,wLeft,wTop,wScrollbar,strOthers,Modal))
}
function CheckUpdate(field,strNote) {
	if (CheckNull(field+'txtPatronCodeGrid')) {
		alert(strNote);
		eval(field+'txtPatronCodeGrid').focus();
		return false;	
	}
	if (CheckNull(field+'txtCopyNumberGrid')) {
		alert(strNote);
		eval(field+'txtCopyNumberGrid').focus();
		return false;	
	}
	return true;
}
function SetPricePhoto() {
	var arrTypeID=document.forms[0].txtHidDataTypeID.value.split(";");
	var arrTypePrice=document.forms[0].txtHidDataPrice.value.split(";");
	var intID=document.forms[0].ddlTypeID.options[document.forms[0].ddlTypeID.selectedIndex].value;
	
	if(intID==0) {
		document.forms[0].txtAmount.value="";
		return false;
	}
	
	var inti;	
	for(inti=0;inti<arrTypeID.length;inti++) {
		if(arrTypeID[inti]==intID) {
			document.forms[0].txtAmount.value=arrTypePrice[inti]*document.forms[0].txtPageCount.value;			
			return false;			
		}
	}		
}