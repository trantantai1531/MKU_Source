/***************************************************************************************
*									WORCreate											*
****************************************************************************************/
function Submitform(){
	parent.Workform.document.forms[0].action='WORCreate.aspx?Create=1';
	parent.Workform.document.forms[0].submit();
	return(false);
}
// reset parent.Workform
function Resetform(){
	parent.Workform.document.forms[0].reset();
	return(false);
}
