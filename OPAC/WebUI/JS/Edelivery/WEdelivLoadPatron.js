
// LoafPatronInfor function
function LoadPatronInfor(FullName,ContactName,Email,Telephone,WorkPlace,PatronCode)
{
	if (FullName != "")
		{
			parent.Workform.document.forms[0].txtFullName.value = FullName
		}
	if (ContactName != "")
		{
			parent.Workform.document.forms[0].txtContactName.value = ContactName
		}
	if (Email != "")
		{
			parent.Workform.document.forms[0].txtEmailAddress.value = Email
		}
	if (Telephone != "")
		{
			parent.Workform.document.forms[0].txtPhone.value = Telephone
		}
	if (WorkPlace != "")
		{
			parent.Workform.document.forms[0].txtWorkPlace.value = WorkPlace
		}
	if (PatronCode != "")
		{
			parent.Workform.document.forms[0].txtEdelivUserName.value = PatronCode
		}
	
}