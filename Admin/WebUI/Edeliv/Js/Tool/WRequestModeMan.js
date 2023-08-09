// Edit_List function	
	function Edit_List()
	{
		var myString=new String(document.forms[0].lstRequestMode.value);
		if (myString != "") {
			if (myString == 0) {
				document.forms[0].btnAddNew.disabled=false;
				document.forms[0].btnUpdate.disabled=true;
				document.forms[0].btnDelete.disabled=true;
			} else {
				if (myString < 4) {
					document.forms[0].btnAddNew.disabled=true;
					document.forms[0].btnUpdate.disabled=true;			
					document.forms[0].btnDelete.disabled=true;
				}
				else {
					document.forms[0].btnAddNew.disabled=true;
					document.forms[0].btnUpdate.disabled=false;			
					document.forms[0].btnDelete.disabled=false;
				}
			}
		}
		else {
				document.forms[0].btnAddNew.disabled=false;
				document.forms[0].btnUpdate.disabled=true;
				document.forms[0].btnDelete.disabled=true;
			}
	}