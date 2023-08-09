/*
	OpenLibMan function
	Purpose: open Libbrary index page in main frame
*/
function OpenLibMan() {
	parent.Workform.location.href="WLibMan.aspx";
	parent.Sentform.location.href="Nothing.htm";
}

/*
	OpenIRMan function
	Purpose: open ILL Incoming Request index page in main frame
*/
function OpenIRMan() {
	parent.Sentform.location.href="WRequestTaskBar.aspx?ReqType=1";
}
/*
	Open create OR function
	Purpose: open ILL Outgoing Request index page in main frame
*/
function OpenCreateOR() {	
	parent.Workform.location.href="ORMan/WORCreate.aspx";
	parent.Sentform.location.href="Nothing.htm";
}
/* 
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
	parent.Sentform.location.href="Nothing.htm";
}

/*
	Statistic function
	Purpose: open Statistic index page in main frame
*/
function OpenStatistic() {
	parent.Workform.location.href="Statistic/WStatisticMain.aspx";
	parent.Sentform.location.href="Nothing.htm";
}

/*
	OpenIndex function
	Purpose: open Libbrary index page in main frame
*/
function OpenIndex() {
	parent.Workform.location.href="WILLMain.aspx";
	parent.Sentform.location.href="Nothing.htm";
}