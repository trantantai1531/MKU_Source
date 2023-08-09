function LoadUserInfor(UserID, Name, UserName, ParentID, SSCID, AcqModule, SerModule, CirModule, PatModule, CatModule, ILLModule, DELModule, AdmModule, CirLocs, AcqLocs, SerLocs, Rights) {
	// UserID
	if (UserID != "") {
		parent.Workform.document.forms[0].hidUserID.value = UserID;
	}
		
	// FullName
	if (Name != "") {
		parent.Workform.document.forms[0].txtFullName.value = Name;
	}
	// UserName
	if (UserName != "") {
		parent.Workform.document.forms[0].txtUserName.value = UserName;
	}
	
	// ParentID
	if (ParentID != "") {
		parent.Workform.document.forms[0].hidParentID.value = ParentID;
    }

   
	
	// Acquisition module
		for (i = 0; i < parent.Workform.document.forms[0].ddlAcq.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlAcq.options[i].value == AcqModule) {
				parent.Workform.document.forms[0].ddlAcq.options.selectedIndex = i;
				break;
			}	
		}
	
	// Serial module
		for (i = 0; i < parent.Workform.document.forms[0].ddlSerial.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlSerial.options[i].value == SerModule) {
				parent.Workform.document.forms[0].ddlSerial.options.selectedIndex = i;
				break;
			}	
		}
			
	// Circulation module
		for (i = 0; i < parent.Workform.document.forms[0].ddlCirculation.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlCirculation.options[i].value == CirModule) {
				parent.Workform.document.forms[0].ddlCirculation.options.selectedIndex = i;
				break;
			}	
		}
		
	// Patron module
		for (i = 0; i < parent.Workform.document.forms[0].ddlPatron.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlPatron.options[i].value == PatModule) {
				parent.Workform.document.forms[0].ddlPatron.options.selectedIndex = i;
				break;
			}	
		}
	
	// Catalogue module
		for (i = 0; i < parent.Workform.document.forms[0].ddlCatalogue.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlCatalogue.options[i].value == CatModule) {
				parent.Workform.document.forms[0].ddlCatalogue.options.selectedIndex = i;
				break;
			}	
		}
			
	// ILL module
		for (i = 0; i < parent.Workform.document.forms[0].ddlILL.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlILL.options[i].value == ILLModule) {
				parent.Workform.document.forms[0].ddlILL.options.selectedIndex = i;
				break;
			}	
		}
			
	 //EDELIV module
		for (i = 0; i < parent.Workform.document.forms[0].ddlEdeliv.options.length; i++) {
			if (parent.Workform.document.forms[0].ddlEdeliv.options[i].value == DELModule) {
				parent.Workform.document.forms[0].ddlEdeliv.options.selectedIndex = i;
				break;
			}	
		}
	// ADMIN module
		if (eval('parent.Workform.document.forms[0].ddlAdmin'))
		{
			for (i = 0; i < parent.Workform.document.forms[0].ddlAdmin.options.length; i++) {
				if (parent.Workform.document.forms[0].ddlAdmin.options[i].value == AdmModule) {
					parent.Workform.document.forms[0].ddlAdmin.options.selectedIndex = i;
					break;
				}	
			}
		}
			
	parent.Workform.document.forms[0].hidUpdate.value = 1;
	parent.Workform.document.forms[0].hidCirRights.value = CirLocs;
	parent.Workform.document.forms[0].hidAcqRights.value = AcqLocs;
	parent.Workform.document.forms[0].hidSerRights.value = SerLocs;
	parent.Workform.document.forms[0].hidRights.value = Rights;
	
}