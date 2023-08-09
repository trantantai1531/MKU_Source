/*
	OpenArticle function
	Purpose: open article index page in main frame
*/
function OpenArticle() {
	parent.Workform.location.href="Article/WShowIssueInfor.aspx";
}

/*
	OpenAcquisition function
	Purpose: open acquisition index page in main frame
*/
function OpenAcquisition() {
	parent.Workform.location.href="Acquisition/WAcqIndex.aspx";
}

/*
	OpenClaim function
	Purpose: open claim index page in main frame
*/
function OpenClaim() {
	parent.Workform.location.href="Claim/WClaimIndex.aspx";
}

/*
	OpenStatistic function
	Purpose: open statistic index page in main frame
*/
function OpenStatistic() {
	parent.Workform.location.href="Statistics/WStatIndex.aspx";
}

/*
	OpenSearch function
	Purpose: open search form
*/
function OpenSearch() {
	parent.Workform.location.href="WSearch.aspx?URL=Acquisition/WCreateIssue.aspx";
}

/*
	OpenQuickView function
	Purpose: open search form
*/
function OpenQuickView() {
	parent.Workform.location.href="WSerialQuickView.aspx";
}