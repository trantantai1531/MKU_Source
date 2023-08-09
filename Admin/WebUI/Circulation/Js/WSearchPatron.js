function EventKeyPress()
{
	if (event.keyCode==13)
	{
		document.forms[0].btnSearch.focus();
	}
}
function EventOnChange()
{
	document.forms[0].btnSearch.focus();
}