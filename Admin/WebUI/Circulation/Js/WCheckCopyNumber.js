/*
	SubmitForm function
	Purpose: submit form to CheckOut
	Creator: Oanhtn
	CreatedDate: 30/08/2004
*/
function SubmitForm() {
	document.forms[0].target='CheckOutMain';
	document.forms[0].action = 'CheckOut/WCheckOutResult.aspx';
	document.forms[0].submit();
}