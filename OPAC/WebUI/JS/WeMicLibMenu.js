
function ActionPage(i){
	switch (i){
		case 0: // all type
			parent.Workform.location.href='WAllType.aspx';
			break;
		case 1: // book
			parent.Workform.location.href='WBook.aspx';
			break;
		case 2: // Article
			parent.Workform.location.href='WArticles.aspx';
			break;
		case 3: // Theses
			parent.Workform.location.href='WTheses.aspx';
			break;
		case 4: // Magazine
			parent.Workform.location.href='WMagazine.aspx';
			break;			
		case 5: // Film
			parent.Workform.location.href='WFilms.aspx';
			break;			
		case 6: // Graphic
			parent.Workform.location.href='WGraph.aspx';
			break;			
		case 7: // Ebook
			parent.Workform.location.href='WFullText.aspx';
			break;						
		case 8: // Z3950
			parent.Workform.location.href='Z3950/WZ3950Client.aspx';
			break;			
		case 9: // ILL
			parent.Workform.location.href='ILL/WILLIndex.aspx';
			break;			
		case 10: // EDelive
			parent.Workform.location.href='Edelivery/WEDelivRequest.aspx';
			break;
		case 12: // OAI
			parent.Workform.location.href='OAIPMH/WOAIHavester.aspx';
			break;			
		case 13: // Maps
			parent.Workform.location.href='WMaps.aspx';
			break;			
		case 14: //Edata
			parent.Workform.location.href='WEdataSearch.aspx';
			break;			
		case 15: //GIS Map
			parent.Workform.location.href='../GisTheme/Container.asp';
			break;			
		case 16: //SubjBrowse
		    parent.Workform.location.href = 'WSubjBrowse.aspx';
		    break;
		case 17: //SubjBrowse
		    parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=1';
            break;
        case 18: //SubjBrowse
            parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=2';
            break;
        case 19: //SubjBrowse
            parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=3';
            break;
        case 20: //SubjBrowse
            parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=4';
            break;
        case 21: //SubjBrowse
            parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=5';
            break;
        case 22: //SubjBrowse
            parent.Workform.location.href = 'WSubjBrowse.aspx?DicID=6';
            break;
		
	}			
	//self.location.href='WeMicLibMenu.aspx';
}

// Open Forum function (Open the forum eMicLib 60 site)
function OpenForum()
{
	if (document.forms[0].hidForum.value!='#')
	{
		window.open(document.forms[0].hidForum.value,'Forums');		
	}
	else
	{
		alert('Function is not available now');
	}
}