function LoadPatronInfor(FullName,ContactName,Email,Telephone,Fax,Note,UserName,Password,DelivName,
	DelivXAddr,	DelivStreet,DelivBox,DelivCity,DelivRegion,DelivCountry,strDelivCode,Debt,Approved,SecretLevel)
{
	parent.Workform.document.forms[0].txtSecretLevel.value = SecretLevel;
	if (FullName != "")
		{
		parent.Workform.document.forms[0].txtFullName.value = FullName;
		}
	if (ContactName != "")
		{
		parent.Workform.document.forms[0].txtContactName.value = ContactName;
		}
	if (Email != "")
		{
		parent.Workform.document.forms[0].txtEmailAddress.value = Email;
		}
	if (Telephone != "")
		{
		parent.Workform.document.forms[0].txtPhone.value = Telephone;
		}
	if (Fax != "")
		{
		parent.Workform.document.forms[0].txtFaxNumber.value = Fax;
		}
	if (Note != "")
		{
		parent.Workform.document.forms[0].txtNote.value = Note;
		}
	if (UserName != "")
		{
		parent.Workform.document.forms[0].txtEdelivUserName.value = UserName;
		}
	if (Password != "")
		{
		parent.Workform.document.forms[0].txtEdelivPassword.value = Password;
		parent.Workform.document.forms[0].txtRetypePassword.value = Password
		}
	if (DelivName != "")
		{
		parent.Workform.document.forms[0].txtWorkPlace.value = DelivName;
		}
	if (DelivXAddr != "")
		{
		parent.Workform.document.forms[0].txtDepartment.value = DelivXAddr;
		}
	if (DelivStreet != "")
		{
		parent.Workform.document.forms[0].txtAddress.value = DelivStreet;
		}
	if (DelivBox != "")
		{
		parent.Workform.document.forms[0].txtBox.value = DelivBox;
		}
	if (DelivCity != "")
		{
		parent.Workform.document.forms[0].txtCity.value = DelivCity;
		}
	if (DelivRegion != "")
		{
		parent.Workform.document.forms[0].txtArea.value = DelivRegion;
		}
	if (DelivCountry != "")
		{
			for (i = 0; i < parent.Workform.document.forms[0].ddlCountry.options.length; i++) 
			{
				if (parent.Workform.document.forms[0].ddlCountry.options[i].value == DelivCountry) 
				{
					parent.Workform.document.forms[0].ddlCountry.options.selectedIndex = i;
					break;
				}	
			}
		}
	if (strDelivCode != "")
	{
		parent.Workform.document.forms[0].txtPostalCode.value = strDelivCode;
	}
	
	if (Debt != "")
	{
		parent.Workform.document.forms[0].txtDebt.value = Debt;
	}	
	if (Approved == 'False')
	{
		parent.Workform.document.forms[0].chkStatus.checked = false;									
	}
	else
	{
		parent.Workform.document.forms[0].chkStatus.checked = true;									
	}		
}