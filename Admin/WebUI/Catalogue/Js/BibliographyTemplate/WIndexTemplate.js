/* 
	UpdateForm function
	Purpose: redirect to another form to create/modify one MarcForm
	Creator: Oanhtn
	CreatedDate: 07/05/2004
*/
function UpdateForm(intFormID) {
	if (intFormID == 0) { // new a MarcForm
		self.location.href='WMarcFrame.aspx';
		parent.Sentform.location.href='WMarcSend.aspx';
	} else { // update current MarcForm
		self.location.href='WMarcFrame.aspx';
		parent.Sentform.location.href='WMarcSend.aspx?FormID=' + intFormID;
	}
}

/*
	UpdateField function
	Purpose: redirect to another form to create/modify/delete user's field
	Creator: Oanhtn
	CreatedDate: 08/05/2004
*/
function UpdateField(strFieldCode, strMess1, strMess2) {
	var strUrl;
	var blnSwitched;
	strUrl = parent.Sentform.location.href;
	blnSwitched = true;
	if (strUrl.indexOf("WMarcSent.aspx") >= 0 ||  strUrl.indexOf("WMarcModi.aspx") >= 0) {
		if (! confirm(strMess1)) {
			blnSwitched = false;
		}
	}
	if (strUrl.indexOf("WMarcSend.aspx") >= 0 ||  strUrl.indexOf("WMarcModfm.aspx") >= 0) {
		if (! confirm(strMess2)) {
			blnSwitched = false;
		}
	}
	if (blnSwitched) {
		if (strFieldCode=="0") {
			self.location.href = "WMarcFieldCreate.aspx";
			parent.Sentform.location.href = "WMarcFieldSend.aspx?FieldCode=0";
		} else {
			self.location.href = "WMarcFieldModify.aspx?FieldCode=" + strFieldCode;
			parent.Sentform.location.href = "WMarcFieldSend.aspx?FieldCode=" + strFieldCode;
//		} else {
//			self.location.href = "MarcFieldDelete.aspx";
		}
	} else {
		return;
	}
}
