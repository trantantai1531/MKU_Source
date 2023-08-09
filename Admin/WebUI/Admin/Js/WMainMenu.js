/*
	OpenUser function
	Purpose: open User index page in main frame
*/
function OpenUser() {	
	parent.Workform.location.href="WIndexUser.aspx";
}

function OpenAdmin() {	
	parent.Workform.location.href="WAdminQuickView.aspx";
}
/*
	OpenLog function
	Purpose: open Log index page in main frame
*/
function OpenLog() {
	parent.Workform.location.href="WIndexLog.aspx";
}

/*
	OpenParametter function
	Purpose: open Parameter manager index page in main frame
*/
function OpenParametter() {
	parent.Workform.location.href="WSetSysParam.aspx";
}

/*
	OpenLangMan function
	Purpose: Man language
*/
function OpenLangMan() {
	parent.Workform.location.href="WManLanguageFrame.aspx";
}


/*
	OpenDatabase function
	Purpose: Mananage Database connections
*/
function OpenDatabase() {
	parent.Workform.location.href="WIndexDatabase.aspx";
}

function ChangePass() {
    parent.Workform.location.href = "WChangePersonalInfo.aspx";
}

function OpenPerm() {
    parent.Workform.location.href = "WGetUsers.aspx";
}