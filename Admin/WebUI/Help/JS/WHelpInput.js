function validate()
{
	if (document.forms[0].txtHelpTitle.value=='')
	{
		alert('Nhập tiêu đề trợ giúp');
		document.forms[0].txtHelpTitle.focus();
		return false;
	}	
		return true;

}

function confirm_delete()
{
	return confirm("Bạn có chắc muốn xóa không?");
}

function confirm_reset()
{
	return confirm("Bạn có chắc làm mới dữ liệu không?");
}
function Hideleft()
	{
		if(parent.document.getElementById("Allframe").cols=="24%,*") {
			parent.document.getElementById("Allframe").cols="0,*";			
			document.getElementById("bttHidden").value=">>";			
			}
		else { 
			parent.document.getElementById("Allframe").cols="24%,*";
			document.getElementById("bttHidden").value="<<";			
			}
	}		