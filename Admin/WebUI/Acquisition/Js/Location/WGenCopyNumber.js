	function Prev(strNote,strNotNum) {
		if (isNaN(document.forms[0].txtPageIndex.value)) {
			alert(strNotNum);
			document.forms[0].txtPageIndex.focus();
			return false;
			}
		if (parseInt(document.forms[0].txtPageIndex.value) > 1) {
			document.forms[0].txtPageIndex.value = parseInt(document.forms[0].txtPageIndex.value) - 1; 
			GotoSubmit();
		} else {
			alert(strNote);
		}
		document.forms[0].txtPageIndex.focus();
		return false;
	}

	function Next(Pcount,strNote,strNotNum) {		
		if (isNaN(document.forms[0].txtPageIndex.value)) {
			alert(strNotNum);
			document.forms[0].txtPageIndex.focus();
			return false;
			}
		if (parseInt(document.forms[0].txtPageIndex.value) < Pcount) {
			document.forms[0].txtPageIndex.value = parseInt(document.forms[0].txtPageIndex.value) + 1; 
			GotoSubmit();			
		} else {
			alert(strNote);
		}
		document.forms[0].txtPageIndex.focus();
		return false;
	}
	function GotoSubmit() {		
		document.forms[0].action="WGenCopyNumListR.aspx";
		document.forms[0].submit(); 	
		}
	
