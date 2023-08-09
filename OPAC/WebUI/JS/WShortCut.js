function ActionPage(i){
	switch (i){
		case 0: // FeedBack
			parent.Workform.location.href='WFeedBack.aspx';
			break;
		case 1: // Home Page
			parent.Workform.location.href='WMain.aspx';
			break;
		case 2: // Personal Page
			parent.Workform.location.href='WPersonalPage.aspx';
			break;
		case 3: // Help
//			parent.Workform.location.href='WTheses.aspx';
			break;
	}		
	self.location.href='WShortCut.aspx';
}