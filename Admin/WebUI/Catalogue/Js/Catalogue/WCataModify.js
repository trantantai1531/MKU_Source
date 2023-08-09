/*
	OnLoad function
	Purpose: execute when this form has been loaded
*/
function ShowCopynumber() {	
	var intFormID = parseFloat(document.forms[0].txtFormID.value);
	var intHolding = parseFloat(document.forms[0].txtHolding.value);
	var intItemID = parseFloat(document.forms[0].txtItemID.value);			
	parent.Workform.location.href = 'WCopyNumber.aspx?FormID=' + intFormID + '&ItemID=' + intItemID + '&HoldingsInCatalogNew=0';
}

/*
	OnLoad function
	Purpose: execute when this form has been loaded
*/

function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
    function (m, key, value) {
        vars[key] = value;
    });
    return vars;
}

function OnLoad() {	
	var intFormID = parseFloat(document.forms[0].txtFormID.value);
	var intHolding = parseFloat(document.forms[0].txtHolding.value);
	var strAddedFieldCodes = document.forms[0].txtAddedFieldCodes.value;
	var strUsedFieldCodes = document.forms[0].txtUsedFieldCodes.value;	
	parent.document.getElementById('frmMain').setAttribute('rows','*,28');
	if (intFormID > 0) {
        //PhuongTT 2014.10.27
	    var intItemID = 0;
        var objItemID = document.forms[0].txtItemID;
        if (objItemID) {
            intItemID = parseFloat(objItemID.value);
        }
        var IsCopy = getUrlVars()["IsCopy"];
        parent.Workform.location.href = 'WCata.aspx?FormID=' + intFormID + '&FieldCodes=' + strUsedFieldCodes + '&AddedFieldCodes=' + strAddedFieldCodes + '&intItemID=' + intItemID.toString() + '&IsCopy=' + IsCopy;
		if (eval("document.forms[0].btnHolding")) {
			document.forms[0].btnHolding.enable='false';
		}
	}
}
function ResetSubmitForm() {
	document.forms[0].target = "_self";
	document.forms[0].action = "WCataModify.aspx";
}
/*
	MoveFirst function
	Purpose: move to the first item
*/
function MoveFirst() {	
	if (parseFloat(document.forms[0].txtCurrentRec.value)==1) {
		alert(strLabel23);
		return false;
	} else {
		ResetSubmitForm()
		parent.Workform.focus(); 
		self.focus(); 
		if (document.forms[0].txtModifiedFieldCodes.value != '') { 
			if (confirm(strLabel22)) {
				document.forms[0].txtFunc.value='begin';
				document.forms[0].txtCurrentRec.value=1;
				document.forms[0].submit();
			} else {
				parent.Workform.focus();
			} 
		} else {
			document.forms[0].txtFunc.value='begin';
			document.forms[0].txtCurrentRec.value=1;
			document.forms[0].submit();
		}
	}
}

/*
	MovePrev function
	Purpose: move to the previous item of the current item
*/
function MovePrev() {
	if (parseFloat(document.forms[0].txtCurrentRec.value)==1) {
		alert(strLabel23);
		return false;
	} else {
		ResetSubmitForm()
		parent.Workform.focus();
		self.focus();
		if (document.forms[0].txtModifiedFieldCodes.value != '') {
			if (confirm(strLabel22)) {
				document.forms[0].txtFunc.value='prev';
				document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) - 1;
				document.forms[0].submit();
			} else {
				parent.Workform.focus();
			} 
		} else {
			document.forms[0].txtFunc.value='prev';
			document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) - 1;
			document.forms[0].submit();
		}
	}
}


/*
	MoveNext function
	Purpose: move to the next item of the current item
*/
function MoveNext() {
	if (parseFloat(document.forms[0].txtCurrentRec.value) == parseFloat(document.forms[0].txtTotalRec.value)){
		alert(strLabel24);
		return false;
	} 
	ResetSubmitForm()
	parent.Workform.focus();
	self.focus();
	if (document.forms[0].txtModifiedFieldCodes.value != '') {
		if (confirm(strLabel22)) {
			document.forms[0].txtFunc.value='next';
			document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) + 1;
			document.forms[0].submit();
		} else {
			parent.Workform.focus();
		}
	} else {		
		document.forms[0].txtFunc.value='next';
		document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) + 1;
		document.forms[0].submit();
	}
}

/*
	MoveLast function
	Purpose: move to the last item
*/
function MoveLast() {
	parent.Workform.focus();
	self.focus();	
	if (parseFloat(document.forms[0].txtCurrentRec.value) == parseFloat(document.forms[0].txtTotalRec.value)) {
		alert(strLabel24);
		return false;
	} else {
		ResetSubmitForm()
		if (document.forms[0].txtModifiedFieldCodes.value != '') {
			if (confirm(strLabel22)) {
				document.forms[0].txtFunc.value='end';
				document.forms[0].txtCurrentRec.value=document.forms[0].txtTotalRec.value;
				document.forms[0].submit();
			} else {
				parent.Workform.focus();
			}
		} else {
			document.forms[0].txtFunc.value='end';
			document.forms[0].txtCurrentRec.value=document.forms[0].txtTotalRec.value;
			document.forms[0].submit();
		}
	}
}

/*
	NewItem function
	Purpose: navigate to addnew item form
*/
function NewItem() {
	parent.Workform.focus();
	self.focus();
	if (document.forms[0].txtModifiedFieldCodes.value != '') {
		if (confirm(strLabel22)) {
			parent.Workform.location.href='WMarcFormSelect.aspx';
			self.location.href='../WNothing.htm';
		} else {
			parent.Workform.focus();
		}
	} else {
		parent.Workform.location.href='WMarcFormSelect.aspx';
		self.location.href='../WNothing.htm';
	}
}

/*
	FilterItem function
	Purpose: navigate to filter form
*/
function FilterItem() {
	parent.Workform.focus();
	self.focus();
	parent.document.getElementById('frmMain').setAttribute('rows','*,28');
	if (document.forms[0].txtModifiedFieldCodes.value != '') {
		if (confirm(strLabel22)) {
			self.location.href='WControlbar.aspx?CurrentRec=' + document.forms[0].txtCurrentRec.value + '&ItemID=' + document.forms[0].txtItemID.value;
		} else {
			parent.Workform.focus();
		}
	} else {
		self.location.href='WControlbar.aspx?CurrentRec=' + document.forms[0].txtCurrentRec.value + '&ItemID=' + document.forms[0].txtItemID.value;
	}
}

/*
	MoveTo function
	Purpose: move to the user' selected item
*/	
function MoveTo(obj) {	
	if (!CheckNum(obj)) {
		alert(strLabel25);
		return false;
	} else {
		ResetSubmitForm()	
		if ((parseFloat(document.forms[0].txtCurrentRec.value) > parseFloat(document.forms[0].txtTotalRec.value)) || (parseFloat(document.forms[0].txtCurrentRec.value) < 1)) {
			alert(strLabel25); 
			return false;
		} else {
			if (parseFloat(document.forms[0].txtCurrentRec.value) == parseFloat(document.forms[0].txtTotalRec.value)) {
				alert(strLabel24);
				return false;
			} else {
				if (parseFloat(document.forms[0].txtCurrentRec.value)==1) {
					alert(strLabel23);
					return false;
				} else {
					parent.Workform.focus();
					self.focus();
					if (document.forms[0].txtModifiedFieldCodes.value != '') {
						if (confirm(strLabel22)) {
							document.forms[0].txtFunc.value='move';
							document.forms[0].submit();
						} else {
							parent.Workform.focus();
						}
					} else {
						document.forms[0].txtFunc.value='move';
						document.forms[0].submit();
					}
				}
			}
		}
	}
}
