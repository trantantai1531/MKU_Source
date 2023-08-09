function LoadBudgetInfor(BudgetName,BudgetCode,Purpose,Amount,Currency,Status)
{
	if (BudgetName != "")
		{
		parent.mainacq.document.forms[0].txtBudgetName.value = BudgetName;
		}
	if (BudgetCode != "")
		{
		parent.mainacq.document.forms[0].txtBudgetCode.value = BudgetCode;
		}
	if (Purpose != "")
		{
		parent.mainacq.document.forms[0].txtPurpose.value = Purpose;
		}
	if (Amount != "")
		{
		parent.mainacq.document.forms[0].txtAmount.value = Amount;
		}
	if (Currency != "")
		{
		
		for (i = 0; i < parent.mainacq.document.forms[0].ddlCurrency.options.length; i++) 
			{
				if (parent.mainacq.document.forms[0].ddlCurrency.options[i].value == Currency)
				{
					parent.mainacq.document.forms[0].ddlCurrency.options.selectedIndex = i;
					break;
				}	
			}
		}
	if (Status == 0)
		{
		parent.mainacq.document.forms[0].rdoStatus[0].checked = true;
		}
	if (Status == 1)
		{
			parent.mainacq.document.forms[0].rdoStatus[1].checked = true;
		}
	if (Status == 2)
		{
			parent.mainacq.document.forms[0].rdoStatus[2].checked = true;
		}
}