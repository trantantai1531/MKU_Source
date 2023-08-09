

function Update_cl(msg1,msg2){
	if (CheckNull(document.forms[0].txt245_a)){
		alert(msg1);
		document.forms[0].txt245_a.focus();
	}
	else {
		if (document.forms[0].ddlFormID.options[document.forms[0].ddlFormID.selectedIndex].value==0) {
			alert(msg2);
			document.forms[0].ddlFormID.focus();
		}else{
			document.forms[0].action='WCatawork.aspx'; 
			document.forms[0].submit();
		}
	}
	return false;
}

function BookChange(){
	var BookID;
	
	BookID=document.forms[0].ddlAcqPO_ITEM.options[document.forms[0].ddlAcqPO_ITEM.selectedIndex].value;
	if (BookID==0){
		document.forms[0].txt245_a.value='';
		document.forms[0].txt245_b_ss.value='';
		document.forms[0].txt245_b_pd.value='';
		document.forms[0].txt245_c.value='';
		document.forms[0].txt245_p.value='';
		document.forms[0].txt245_n.value='';
		document.forms[0].txt020_a.value='';
		document.forms[0].txt022_a.value = '';
		document.forms[0].txt041_a.value = '';
		document.forms[0].txt082_a.value = '';
		document.forms[0].txt100_a.value = '';
		document.forms[0].txt110_a.value = '';
		document.forms[0].txt260_a.value='';
		document.forms[0].txt260_c.value='';
		document.forms[0].txt260_b.value='';
		document.forms[0].txt250_a.value='';
		document.forms[0].txt300_a.value='';
		document.forms[0].txt300_b.value='';
		document.forms[0].txt300_c.value='';
		document.forms[0].txt300_e.value='';
		document.forms[0].txtCodePO.value='';
		document.forms[0].hidLanguage.value='';
		document.forms[0].hidCountryPub.value='';
		document.forms[0].languageID.value='';
		document.forms[0].CountryPubID.value = '';
		document.forms[0].hidUnitPrice.value = '0';
		document.forms[0].ddlMedium.options.selectedIndex = 0;
		document.forms[0].ddlItemType.options.selectedIndex = 0;
		document.forms[0].ddlLoanType.options.selectedIndex = 0;
		document.forms[0].ddlAcqSource.options.selectedIndex = 0;
		document.forms[0].txtAdditionalBy.value = '';
	}else{
		document.forms[0].txtCodePO.value=document.forms[0].ddlAcqPO_ITEM.options[document.forms[0].ddlAcqPO_ITEM.selectedIndex].text;
		parent.hiddenbase.location.href = 'WBookChanged.aspx?BookID='+ BookID; 
	}
}

function Check245(){
//Esc(document.forms[0].txtTitle.value,'unicode') 
	//parent.hiddenbase.location.href = 'WBookChanged.aspx?str245=' + document.forms[0].txt245_a.value ;
	parent.hiddenbase.location.href = 'WBookChanged.aspx?str245=' + Esc(document.forms[0].txt245_a.value,'unicode');
	return false;
}

function CheckISBN(){
	parent.hiddenbase.location.href = 'WBookChanged.aspx?strISBN=' + document.forms[0].txt020_a.value;
	document.forms[0].txt100_a.focus();
}

function ShowPub(){
	var stURL;
	stURL= 'WFilterPublisher.aspx?val=' + Esc(document.forms[0].txt260_b.value,1);
	openModal(stURL,'publisher',365,256,200,150,'no','',0)
}

function Z3950_action(){
	var strURL;
	strURL='WZForm.aspx?tocat=1';
	openModal(strURL,'ZWin',700,500,50,100,'',0);
}

function ShowListCat(){
	var strURL;
	strURL='WItemQueue.aspx';
	//popUp = window.open(strURL,'abc', 'width=700,height=300,left=0,top=0,menubar=yes,resizable=no,scrollbars=yes');
	openModal(strURL,'ZWin',600,350,100,150,'yes','yes',0);
}

function UpData(intPOID, intUnitPrice, strTitle, intPubYear, strPublisher, strISSN, strISBN, strType, strMedium, strAuthor, strEdition, strISOCodeLang, strISOCode, intBookID, strLanguage, strCountry, intLoanType, intAcqSource, strAdditionalBy) {
	var lenMedium;
	var lenType;
	var lenLoanType;
	var lenAcqSource;
	var strTemp;
	parent.mainacq.document.forms[0].txt245_a.value=strTitle;
	parent.mainacq.document.forms[0].txt020_a.value=strISBN;
	parent.mainacq.document.forms[0].txt022_a.value=strISSN;
	parent.mainacq.document.forms[0].txt100_a.value=strAuthor;
	parent.mainacq.document.forms[0].txt260_c.value=intPubYear;
	parent.mainacq.document.forms[0].txt260_b.value=strPublisher;
	parent.mainacq.document.forms[0].txt250_a.value=strEdition;
	parent.mainacq.document.forms[0].hidLanguage.value=strLanguage;
	parent.mainacq.document.forms[0].hidCountryPub.value=strCountry;
	parent.mainacq.document.forms[0].languageID.value=strISOCodeLang;
	parent.mainacq.document.forms[0].CountryPubID.value = strISOCode;
	parent.mainacq.document.forms[0].hidUnitPrice.value = intUnitPrice;
	parent.mainacq.document.forms[0].txtAdditionalBy.value = strAdditionalBy;
	lenType=parent.mainacq.document.forms[0].ddlItemType.options.length;
	lenMedium = parent.mainacq.document.forms[0].ddlMedium.options.length;
	lenLoanType = parent.mainacq.document.forms[0].ddlLoanType.options.length;
	lenAcqSource = parent.mainacq.document.forms[0].ddlAcqSource.options.length;
	for (i=0;i<lenMedium;i++){
		strTemp=parent.mainacq.document.forms[0].ddlMedium.options[i].value;
		strTemp=strTemp.substring(0,strTemp.indexOf(":"));		
		if (strTemp==strMedium) {
			parent.mainacq.document.forms[0].ddlMedium.options.selectedIndex = i;
		break;
		}
	}
	for (i=0;i<lenType;i++){
		strTemp=parent.mainacq.document.forms[0].ddlItemType.options[i].value;
		strTemp=strTemp.substring(0,strTemp.indexOf(":"));		
		if (strTemp==strType) {
			parent.mainacq.document.forms[0].ddlItemType.options.selectedIndex = i;
		break;
		}
	}
	for (i = 0; i < lenLoanType; i++) {
	    strTemp = parent.mainacq.document.forms[0].ddlLoanType.options[i].value;
	    if (strTemp == intLoanType) {
	        parent.mainacq.document.forms[0].ddlLoanType.options.selectedIndex = i;
	        break;
	    }
	}
	for (i = 0; i < lenAcqSource; i++) {
	    strTemp = parent.mainacq.document.forms[0].ddlAcqSource.options[i].value;
	    if (strTemp == intAcqSource) {
	        parent.mainacq.document.forms[0].ddlAcqSource.options.selectedIndex = i;
	        break;
	    }
	}
	//parent.hiddenbase.location.href='WCheckcat.aspx?POCode=' + intPOID + '&ID=' + intBookID + '&bold=245&val=' + Esc(strTitle, 1);
	//alert('WCheckcat.aspx?POCode=' + intPOID + '&ID=' + intBookID + '&bold=245&val=' + Esc(strTitle, 1));
}

function fReset(){
	return false;
}
function OpenZ3950() {
	var ItemType=document.forms[0].ddlItemType.options[document.forms[0].ddlItemType.selectedIndex].text;
	var pos=ItemType.indexOf(":");
	ItemType=ItemType.substring(0,pos);
	var FormID=document.forms[0].ddlFormID.options[document.forms[0].ddlFormID.selectedIndex].value;
	var ItemMedium=document.forms[0].ddlMedium.options[document.forms[0].ddlMedium.selectedIndex].text;
	pos=ItemMedium.indexOf(":");
	ItemMedium=ItemMedium.substring(0,pos);
	var Level=document.forms[0].ddlLevelSec.options[document.forms[0].ddlLevelSec.selectedIndex].value;
	OpenWindow('../../Common/WZForm.aspx?opener=WCataForm.aspx&TypeCode=' + ItemType + '&FormID='+FormID+'&Medium='+ItemMedium+'&Level='+Level,'ZWin',800,450,50,100); 
	return false;
}
function Unload(strTitle){
	parent.mainacq.location.href = 'WCataForm.aspx?strTitle=' + strTitle ; 
	self.close();
	return false;
}