/**************************************************************************
************************ WSimple Search Result TaskBar Js file ************
**************************************************************************/
function NextAction(){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){
		if (parseInt(document.forms[0].hidCurRec.value) < intPatronTotal-1){
			document.forms[0].hidCurRec.value=parseInt(document.forms[0].hidCurRec.value)+1;
		}else{
			document.forms[0].hidCurRec.value=intPatronTotal-1;
		}
		document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value)+1;
		parent.result.location.href='WSimpleSearchResult.aspx?IndexID=' + document.forms[0].hidCurRec.value;
	}
}

function BackAction(){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){
		if (parseInt(document.forms[0].hidCurRec.value) > 0){
			document.forms[0].hidCurRec.value=parseInt(document.forms[0].hidCurRec.value)-1;
		}else{
			document.forms[0].hidCurRec.value=0;
		}
		document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value)+1;
		parent.result.location.href='WSimpleSearchResult.aspx?IndexID=' + document.forms[0].hidCurRec.value;	
	}
}

function FirstAction(){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){
		document.forms[0].hidCurRec.value=0;
		document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value)+1;
		parent.result.location.href='WSimpleSearchResult.aspx?IndexID=' + document.forms[0].hidCurRec.value;	
	}
}

function EndAction(){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){
		document.forms[0].hidCurRec.value=intPatronTotal-1;
		document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value) + 1;
		parent.result.location.href='WSimpleSearchResult.aspx?IndexID=' + document.forms[0].hidCurRec.value;			
	}
}

function Action(strNote,strNote1){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){		
		if (CheckNum(document.forms[0].txtRec)) {
			var intRec=parseInt(document.forms[0].txtRec.value);
			if (intRec>0 && intRec < intPatronTotal){
				document.forms[0].hidCurRec.value=intRec-1;				
				parent.result.location.href='WSimpleSearchResult.aspx?IndexID=' + document.forms[0].hidCurRec.value;				
			}else {
				alert(strNote1);
				document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value) + 1;
			}
		}
		else { 
			alert(strNote);		
			document.forms[0].txtRec.value=parseInt(document.forms[0].hidCurRec.value) + 1;
		}
	}
	return false;
}

function NewClick(){
	parent.parent.Workform.location.href='WPatron.aspx';
}

function EditClick(){
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){		
		var intRec=parseInt(document.forms[0].hidCurRec.value);
		parent.parent.Workform.location.href='WPatron.aspx?TypeSearch=1&IndexID=' + intRec;
	}
}

function SearchClick(){
	parent.parent.Workform.location.href='WSimpleSearch.aspx';
}

function DeleteClick(strQuestion){	
	var intPatronTotal=parseInt(document.forms[0].hidPatronTotal.value);	
	if (intPatronTotal>0){		
		if (confirm(strQuestion)){
			var intRec=parseInt(document.forms[0].hidCurRec.value);
			self.location.href='WSimpleSearchResultTaskBar.aspx?IndexIDdel=' + intRec;
			parent.result.location.href='WSimpleSearchResult.aspx';
		}else{
			return false;
		}
	}
}

function ResetPassClick(strQuestion) {
    var intPatronTotal = parseInt(document.forms[0].hidPatronTotal.value);
    if (intPatronTotal > 0) {
        if (confirm(strQuestion)) {
            var intRec = parseInt(document.forms[0].hidCurRec.value);
            self.location.href = 'WSimpleSearchResultTaskBar.aspx?IndexIDReset=' + intRec;
            parent.result.location.href = 'WSimpleSearchResult.aspx';
        } else {
            return false;
        }
    }
}