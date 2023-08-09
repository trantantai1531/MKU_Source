function LoadPatronInfor(LibrarySymbol,Name,Email,Phone,Code,Note,EDelivMode,EDelivTSAddr,PostDelivName,
	PostDelivXAddr,	PostDelivStreet,PostDelivBox,PostDelivCity,PostDelivRegion,PostDelivCountry,PostDelivCode
	,strBillDelivName,strBillDelivXAddr,strBillDelivStreet,strBillDelivBox
	,strBillDelivCity,strBillDelivRegion,strBillDelivCountry,strBillDelivCode,strEncodingScheme,intLocalLib,intDel)
{
	// LibrarySymbol
	if (LibrarySymbol != "")
		{
			parent.Workform.document.forms[0].txtSymbol.value = LibrarySymbol;
		}
	else
		{
			parent.Workform.document.forms[0].txtSymbol.value = "";
		}
	// Name		
	if (Name != "")
		{
			parent.Workform.document.forms[0].txtName.value = Name;
		}
		else
		{
			parent.Workform.document.forms[0].txtName.value = "";
		}
	// Email		
	if (Email != "")
		{
			parent.Workform.document.forms[0].txtEmailAddress.value = Email;
		}
		else
		{
			parent.Workform.document.forms[0].txtEmailAddress.value = "";
		}
	// Phone			
	if (Phone != "")
		{
			parent.Workform.document.forms[0].txtPhone.value = Phone;		
		}
		else
		{
			parent.Workform.document.forms[0].txtPhone.value = "";		
		}
	// Code				
	if (Code != "")
		{
			parent.Workform.document.forms[0].txtCode.value = Code;		
		}
		else
		{
			parent.Workform.document.forms[0].txtCode.value = "";		
		}
	// Note				
	if (Note != "")
		{
			parent.Workform.document.forms[0].txtNote.value = Note;		
		}
		else
		{
			parent.Workform.document.forms[0].txtNote.value = "";
		}
	// EDelivMode						
	if (EDelivMode != "")
		{
			parent.Workform.document.forms[0].txtEDelivMode.value = EDelivMode;		
		}
		else
		{
			parent.Workform.document.forms[0].txtEDelivMode.value = "";		
		}
	// EDelivTSAddr						
	if (EDelivTSAddr != "")
		{
			parent.Workform.document.forms[0].txtEDelivTSAdd.value = EDelivTSAddr;
		}
		else
		{
			parent.Workform.document.forms[0].txtEDelivTSAdd.value = "";
		}										
	// PostDelivName						
	if (PostDelivName != "")
		{
			parent.Workform.document.forms[0].txtDelivName.value = PostDelivName;		
			parent.Workform.document.forms[0].hidPostDelivName.value = PostDelivName;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivName.value = "";		
			parent.Workform.document.forms[0].hidPostDelivName.value = "";
		}
	// PostDelivXAddr						
	if (PostDelivXAddr != "")
		{
			parent.Workform.document.forms[0].txtDelivXAddr.value = PostDelivXAddr;		
			parent.Workform.document.forms[0].hidPostDelivXAddr.value = PostDelivXAddr;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivXAddr.value = "";		
			parent.Workform.document.forms[0].hidPostDelivXAddr.value = "";
		}
	// PostDelivStreet						
	if (PostDelivStreet != "")
		{
			parent.Workform.document.forms[0].txtDelivStreet.value = PostDelivStreet;		
			parent.Workform.document.forms[0].hidPostDelivStreet.value = PostDelivStreet;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivStreet.value = "";		
			parent.Workform.document.forms[0].hidPostDelivStreet.value = "";
		}
	// PostDelivBox						
	if (PostDelivBox != "")
		{
			parent.Workform.document.forms[0].txtDelivBox.value = PostDelivBox;		
			parent.Workform.document.forms[0].hidPostDelivBox.value = PostDelivBox;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivBox.value = "";		
			parent.Workform.document.forms[0].hidPostDelivBox.value = "";
		}
	// PostDelivCity						
	if (PostDelivCity != "")
		{
			parent.Workform.document.forms[0].txtDelivCity.value = PostDelivCity;		
			parent.Workform.document.forms[0].hidPostDelivCity.value = PostDelivCity;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivCity.value = "";		
			parent.Workform.document.forms[0].hidPostDelivCity.value = "";
		}
	// PostDelivRegion						
	if (PostDelivRegion != "")
		{
			parent.Workform.document.forms[0].txtDelivRegion.value = PostDelivRegion;		
			parent.Workform.document.forms[0].hidPostDelivRegion.value = PostDelivRegion;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivRegion.value = "";		
			parent.Workform.document.forms[0].hidPostDelivRegion.value = "";
		}
	// PostDelivCountry						
	if (PostDelivCountry != "")
		{
			for (i = 0; i < parent.Workform.document.forms[0].ddlCountry.options.length; i++) 
			{
				if (parent.Workform.document.forms[0].ddlCountry.options[i].value == PostDelivCountry) 
				{
					parent.Workform.document.forms[0].ddlCountry.options.selectedIndex = i;
					break;
				}	
			}
			parent.Workform.document.forms[0].hidPostDelivCountry.value = PostDelivCountry;		
		}
		else
		{
			parent.Workform.document.forms[0].ddlCountry.options.selectedIndex = 0;
			parent.Workform.document.forms[0].hidPostDelivCountry.value = "";		
		}
	// PostDelivCode						
	if (PostDelivCode != "")
		{
			parent.Workform.document.forms[0].txtDelivCode.value = PostDelivCode;		
			parent.Workform.document.forms[0].hidPostDelivCode.value = PostDelivCode;
		}
		else
		{
			parent.Workform.document.forms[0].txtDelivCode.value = "";		
			parent.Workform.document.forms[0].hidPostDelivCode.value = "";
		}
	// strBillDelivName							
	if (strBillDelivName != "")
		{
			parent.Workform.document.forms[0].hidBillDelivName.value = strBillDelivName;		
		}
		else
		{
			parent.Workform.document.forms[0].hidBillDelivName.value = "";		
		}							
	// strBillDelivXAddr						
	if (strBillDelivXAddr != "")
		{
			parent.Workform.document.forms[0].hidBillDelivXAddr.value = strBillDelivXAddr;		
		}
		else
		{
			parent.Workform.document.forms[0].hidBillDelivXAddr.value = "";		
		}
	// strBillDelivStreet						
	if (strBillDelivStreet != "")
		{
			parent.Workform.document.forms[0].hidBillDelivStreet.value = strBillDelivStreet;		
			
		}
		else
		{
			parent.Workform.document.forms[0].hidBillDelivStreet.value = "";		
		}							
	// strBillDelivBox						
	if (strBillDelivBox != "")
		{
			parent.Workform.document.forms[0].hidBillDelivBox.value = strBillDelivBox;		
		}
		else
		{
			parent.Workform.document.forms[0].hidBillDelivBox.value = "";
		}
	// PostDelivCity						
	if (PostDelivCity != "")
		{
			parent.Workform.document.forms[0].hidBillDelivCity.value = PostDelivCity;
		}
		else
		{
			parent.Workform.document.forms[0].hidBillDelivCity.value = "";
		}
	// strBillDelivRegion						
	if (strBillDelivRegion != "")
		{
			parent.Workform.document.forms[0].hidBillDelivRegion.value = strBillDelivRegion;		
		}
	else
		{
			parent.Workform.document.forms[0].hidBillDelivRegion.value = "";		
		}						
	// strBillDelivCountry						
	if (strBillDelivCountry != "")
		{
			parent.Workform.document.forms[0].hidBillDelivCountry.value = strBillDelivCountry;		
		}
	else
		{
			parent.Workform.document.forms[0].hidBillDelivCountry.value = "";
		}							
	// strBillDelivCode						
	if (strBillDelivCode != "")
		{
			parent.Workform.document.forms[0].hidBillDelivCode.value = strBillDelivCode;		
		}
	else
		{
			parent.Workform.document.forms[0].hidBillDelivCode.value = "";		
		}
		// strEncodingScheme						
	if (strEncodingScheme != "")
		{
				for (i = 0; i < parent.Workform.document.forms[0].ddlEncodingSchema.options.length; i++) 
			{
				if (parent.Workform.document.forms[0].ddlEncodingSchema.options[i].value == strEncodingScheme) 
				{
					parent.Workform.document.forms[0].ddlEncodingSchema.options.selectedIndex = i;
					break;
				}	
			}
		}
	if (intDel == 0) {
		if (intLocalLib==0) {
			parent.Workform.document.forms[0].btnDelete.disabled=false;
			}
		else {
			parent.Workform.document.forms[0].btnDelete.disabled=true;
		}
	}
}