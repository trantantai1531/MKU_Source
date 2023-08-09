/* 
	IsCreateForm 
	Purpose: redirect to another form to create new worksheet
	Creator: Oanhtn
	CreatedDate: 12/03/2004
*/
function IsCreateForm() {
	self.location.href='WMarcFrame.aspx';
	parent.Sentform.location.href='WMarcSend.aspx';
}

/* 
	IsCreateForm 
	Purpose: redirect to another form to create/modify/delete user's field
	Creator: Oanhtn
	CreatedDate: 18/03/2004
*/
function ModifyField(intFunc, strMess1, strMess2) {
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
		if (intFunc==0) {
			parent.Sentform.location.href = "WMarcFieldSend.aspx?Func=0";
			self.location.href = "WMarcFieldNew.aspx";
		} else if (intFunc==1){
			parent.Sentform.location.href = "WMarcFieldSend.aspx?Func=1";
			self.location.href = "WMarcFieldModify.aspx";
		} else {
			parent.Sentform.location.href = "WMarcFieldSend.aspx?Func=2";
			self.location.href = "MarcFieldDelete.aspx";
		}
	} else {
		return;
	}
}
