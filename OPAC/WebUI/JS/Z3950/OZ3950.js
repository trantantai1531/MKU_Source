function CheckForSubmit(strNote, strErrNum) {
	if((document.forms[0].txtFieldValue1.value!="")&&(document.forms[0].txtzServer.value!="")&&(document.forms[0].txtZPort.value!="")&&(document.forms[0].txtZDatabase.value!="")) {
		if(CheckNumBer(document.forms[0].txtZPort,strErrNum)) {
		    //SetArrSearched('','','z3950');
		    ////alert("okay");
			//document.forms[0].action = "OZ3950Show.aspx";				
			//document.forms[0].submit();	
			parent.showWaiting();
			return true;				
		}
	}
	else {
		if(document.forms[0].txtzServer.value=="") {
		    parent.showNotify('warning', parent.strWarningBegin + 'Chưa nhập tên máy chủ Z39.50.' + parent.strWarningEnd);
			document.forms[0].txtzServer.focus();			
			}
		else 
		if(document.forms[0].txtZPort.value=="") {
		    parent.showNotify('warning', parent.strWarningBegin + 'Chưa nhập Cổng dịch vụ.' + parent.strWarningEnd);
			document.forms[0].txtZPort.focus();			
			}
		else 
		if(document.forms[0].txtZDatabase.value=="") {
		    parent.showNotify('warning', parent.strWarningBegin + 'Chưa nhập tên cơ sở dữ liệu.' + parent.strWarningEnd);
			document.forms[0].txtZDatabase.focus();			
			}
		else 		
		if((document.forms[0].txtFieldValue1.value=="") && (document.forms[0].txtFieldValue2.value=="") && (document.forms[0].txtFieldValue3.value=="")) {
		    parent.showNotify('warning', parent.strWarningBegin + strNote + parent.strWarningEnd);
				document.forms[0].txtFieldValue1.focus();			
			}		
			else {
				//document.forms[0].action = "OZ3950Show.aspx";				
				//document.forms[0].submit();
				parent.showWaiting();				
				return true;
			}
		
	}
	return false;
}

function fnShowServerList() {
    //window.scrollTo(0, 10);
    //$('#popupZServerList').bPopup();
    $.magnificPopup.open({
        items: {
            src: 'OZ3950ServerList.aspx'
        },
        tLoading: 'Loading...',
        type: 'iframe'
    });
}

function closeShowServerList() {
    //var bPopup = $('#popupZServerList').bPopup();
    //bPopup.close();
    $.magnificPopup.close();
}

function ResetAll() {
    document.forms[0].reset();
    return false;
}