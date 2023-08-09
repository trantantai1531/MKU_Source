/*
	GetNextIssue function
	Purpose: get information of the next IssueNo
*/
function GetNextIssue() {
    document.forms[0].txtIssueNo.value = parseInt(document.forms[0].hidLastIssueNo.value) + 1;
    document.forms[0].txtOvIssueNo.value = parseInt(document.forms[0].hidLastOvIssueNo.value) + 1;
    document.getElementById("txtIssueNo").setAttribute("value", parseInt(document.forms[0].hidLastIssueNo.value) + 1);
    document.getElementById("txtOvIssueNo").setAttribute("value", parseInt(document.forms[0].hidLastOvIssueNo.value) + 1);
    console.log(parseInt(document.forms[0].hidLastIssueNo.value) + 1);
    console.log(parseInt(document.forms[0].hidLastOvIssueNo.value) + 1);
}

/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAll() 
{
	if (CheckNull(document.forms[0].txtIssueNo)) {
		document.forms[0].txtIssueNo.focus();
		return false;
		}
	else 
	{
		if (CheckNull(document.forms[0].txtIssuedDate)) {
			document.forms[0].txtIssuedDate.focus();
			return false;
			}
		else 
		{
			if (CheckNull(document.forms[0].txtPrice)) {
				document.forms[0].txtPrice.focus();
				return false;
				}
			else 
			{
				if (document.forms[0].txtOvIssueNo.value != ''){
				    if (parseInt(document.forms[0].txtIssueNo.value) > parseInt(document.forms[0].txtOvIssueNo.value)) {
						document.forms[0].txtIssueNo.value='';
						document.forms[0].txtIssueNo.focus();
						return false;
					}
					else
					{
					    return true;
					}
				}
				else 
				{
					return true;
				}
			}
		}	
	}
}
/*
	ResetAll function
	Purpose: reset all controls
*/
function ResetAll() {
	document.forms[0].txtVolumeByPublisher.value='';	
	document.forms[0].txtIssuedDate.value='';	
	document.forms[0].txtPhysDetail.value='';	
	document.forms[0].txtCopies.value='0';	
	document.forms[0].txtSpecialTitle.value='';	
	document.forms[0].txtPrice.value='0';	
	document.forms[0].txtNote.value='';	
	document.forms[0].txtSummary.value='';	
	document.forms[0].chkSpecialIssue.checked = false;
	return false;
}
