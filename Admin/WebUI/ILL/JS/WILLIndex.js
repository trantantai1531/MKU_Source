/*
	OpenIRMan function
	Purpose: open ILL Incoming Request index page in main frame
*/
function OpenIRMan() {
	parent.Sentform.location.href="WRequestTaskBar.aspx?ReqType=1";
}

/*
	OpenORMan function
	Purpose: open ILL Outgoing Request index page in main frame
*/
function OpenORMan() {
	parent.Sentform.location.href="WRequestTaskBar.aspx?ReqType=2";
}
/* 
	OpenTools function
	Purpose: open ILL Tools index page in main frame
*/
function OpenToolsMan(){
	parent.Workform.location.href="ToolsMan/WToolsManMain.aspx";	
}