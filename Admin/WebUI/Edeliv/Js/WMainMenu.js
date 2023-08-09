/*
	OpenCustomer function
	Purpose: open Customer index page in main frame
*/
function OpenCustomer() {
	parent.Workform.location.href="Customer/WCustomerMan.aspx";
	parent.Sentform.location.href="WNothing.htm";
}

/*
	OpenRequest function
	Purpose: open Request index page in main frame
*/
function OpenRequest() {
	parent.Sentform.location.href="Request/WRequestTaskBar.aspx";
}

/*
	OpenTool function
	Purpose: open Tool index page in main frame
*/
function OpenTool() {
	parent.Workform.location.href="Tool/WToolIndex.aspx";
	parent.Sentform.location.href="WNothing.htm";
}

/*
	OpenAccount function
	Purpose: open Account index page in main frame
*/
function OpenAccount() {
	parent.Workform.location.href="Account/WAccountIndex.aspx";
	parent.Sentform.location.href="WNothing.htm";
}

/*
	OpenStatistic function
	Purpose: open Statistic form
*/
function OpenStatistic() {
	parent.Workform.location.href="Statistic/WStatIndex.aspx";
	parent.Sentform.location.href="WNothing.htm";
}

/*
	OpenEdata function
	Purpose: open Edata Index form
*/
function OpenEdata() {
	parent.Workform.location.href="EData/WEdataMain.aspx";
	parent.Sentform.location.href="WNothing.htm";
}

/*
	OpenQuickView function
	Purpose: open quick view form
*/
function OpenQuickView() {
	parent.Workform.location.href="WEdelivQuickView.aspx";
}