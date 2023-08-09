function ReLoadAllForm(Typing,FontType){	
	top.header.location.href=top.header.location.href;
	top.menu.location.href=top.menu.location.href;			
	parent.Workform.location.href=parent.Workform.location.href;
	parent.Hiddenbase.location.href=parent.Hiddenbase.location.href;
	self.location.href = self.location.href;	
}

function LogOut(){
	parent.HiddenSaveIDs.document.forms[0].txtSaveID.value='';	
	parent.HiddenSaveIDs.document.forms[0].txtDocIDTemps.value='0';	
	parent.HiddenSaveIDs.document.forms[0].submit();
	self.location.href = 'WHeader.aspx?out=OK';
}

function LogIn(){
	parent.HiddenSaveIDs.document.forms[0].txtSaveID.value='';	
	parent.HiddenSaveIDs.document.forms[0].txtDocIDTemps.value='0';	
	parent.HiddenSaveIDs.document.forms[0].submit();
	self.location.href = 'WHeader.aspx';
	parent.Workform.location.href='WPersonalPageLogin.aspx';
}

function ActionPage(i){
	switch (i){
		case 0: // FeedBack
			parent.Workform.location.href='WFeedBack.aspx';
			break;
		case 1: // Home Page
			parent.Workform.location.href='WMain.aspx';
			break;
		case 2: // Personal Page
			parent.Workform.location.href='WPersonalPage.aspx';
			break;
		case 3: // Help
//			parent.Workform.location.href='WTheses.aspx';
			break;
	}		
	//self.location.href='WShortCut.aspx';
}