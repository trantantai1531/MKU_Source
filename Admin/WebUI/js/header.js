// Admin_Click
function Admin_Click()
{
	parent.main.location.href='Admin/WMainIndex.aspx';
}

// Patron_Click
function Patron_Click()
{
	parent.main.location.href='Patron/WIndex.aspx';
}
// Catalogue_Click
function Catalogue_Click()
{
	parent.main.location.href='Catalogue/WMainFrame.aspx';
}
// Circulation_Click
function Circulation_Click()
{
	parent.main.location.href='Circulation/WIndex.aspx';
}
// Acquisition_Click
function Acquisition_Click()
{
	parent.main.location.href='Acquisition/WACQIndex.aspx';
}
// Serial_Click
function Serial_Click()
{
	parent.main.location.href='Serial/WMainIndex.aspx';
}
// Edeliv_Click
function Edeliv_Click()
{
	parent.main.location.href='Edeliv/WMainIndex.aspx';
}
// ILL_Click
function ILL_Click()
{
	parent.main.location.href='ILL/WILLMainIndex.aspx';
}

// Logout_Click
function Logout_Click()
{	
	top.location.href='Index.aspx?out=ok';
}

// Index_Click
function Index_Click()
{
	parent.main.location.href='WIntroduction.aspx';
}
//Help_Click
function Help_Click()
{
	window.open('Help/WHelpOverView.aspx');
}
	
// Setting_Click
function Setting_Click()
{
	if (document.forms[0].hidClick.value.indexOf(',') == -1)
		{
			if (document.forms[0].hidClick.value!=0 && document.forms[0].hidClick.value<11)
			{
				if (document.forms[0].hidClick.value!=6)
				{
					parent.main.Workform.location.href='Common/WManRef.aspx';
				}
				else
				{
					parent.main.mainacq.location.href='Common/WManRef.aspx';
				}
			}
		}
	
}

// function Help_Click()

// Opac_Click
function Opac_Click()
{
	//parent.location.href='../Opac/Windex.aspx';
    window.open('../eLibraryOpac/Windex.aspx');
}


