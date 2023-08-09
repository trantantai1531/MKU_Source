/*
var alignLeft = -30;
var alignTop = 19;
var backcolor = "#008284";
var cationcolor = "#FFFFFF";
var width = "250";
var border = "0";
    
ns4 = (document.layers)? true:false
ie4 = (document.all)? true:false
var x = 0;
var y = 0;
var snow = 0;
var sw = 0;
var cnt = 0;
var dir = 1;

if (ie4)
{
    if (navigator.userAgent.indexOf('MSIE 6')>0) {
        var ie6 = true;
    }
    else {
        var ie6 = false;
        if (navigator.userAgent.indexOf('MSIE 5')>0) {
            var ie5 = true;
        }
        else {
            var ie5 = false;
        }
    }
}
else {
    var ie5 = false;
    var ie6 = false;
}

if ( (ns4) || (ie4) || (ie5) || (ie6) ) {
    if (ns4) over = document.overDiv
    if (ie4) over = overDiv.style
    document.onmousemove = mouseMove
    if (ns4) document.captureEvents(Event.MOUSEMOVE)
}

function (title) {
    createWinDow(1,title);
}

function CreateContextMenu(title) {
    createWinDow(1,title);
}

function HideTip() {
    if ( cnt >= 1 ) { sw = 0 };
    if ( (ns4) || (ie4) || (ie5) || (ie6) ) {
        if ( sw == 0 ) {
            snow = 0;
            hideObject(over);
        }
        else {
            cnt++;
        }
    }
}

function createWinDow(d, title) {
    var lenstr
    txt = "<TABLE CELLPADDING='3' WIDTH="+width
    txt = txt + " BORDER=0 CELLPADDING=" + border
    txt = txt + " CELLSPACING=0 BGCOLOR=\"" + backcolor
    txt = txt + "\" bordercolor=\"" + backcolor
    txt = txt + "\" bordercolorlight='#E6E6E6' bordercolordark='#000066'>"
    txt = txt + "<TR><TD><FONT STYLE=\"FONT-FAMILY: <%=Font%>; FONT-SIZE: 10pt;\" COLOR=\""+cationcolor
    txt = txt + "\">"+title+"</FONT></TD></TR></TABLE>"
    layerWrite(txt);
    dir = d;
    disp();
}

function disp() {
    if ( (ns4) || (ie4) || (ie5) || (ie6) ) {
        if (snow == 0)  {
            if (dir == 1) {
                moveTo(over, x + alignLeft, y + alignTop);
            } else {
                moveTo(over, x - alignLeft - width, y + alignTop);
            }
            showObject(over);
            snow = 1;
        }
    }
}

function mouseMove(e) {
    if (ns4) {x=e.pageX; y=e.pageY}
    if (ie4) {x=event.x; y=event.y}
    if (ie5) {x=event.x+document.body.scrollLeft; y=event.y+document.body.scrollTop;}
    if (ie6) {x=event.x+document.body.scrollLeft; y=event.y+document.body.scrollTop;}
    if (snow) {
        if (dir == 1) {
            moveTo(over,x+alignLeft,y+alignTop);
        } else {
            moveTo(over,x-alignLeft-width,y+alignTop);
        }
    }
}

function layerWrite(txt) {
        if (ns4) {
                var lyr = document.overDiv.document
                lyr.write(txt)
                lyr.close()
        }
        else if ( (ie4) || (ie5) || (ie6) ) document.all["overDiv"].innerHTML = txt
}

function showObject(obj) {
        if (ns4) obj.visibility = "show"
        else if ( (ie4) || (ie5) || (ie6) )obj.visibility = "visible"
}

function hideObject(obj) {
        if (ns4) obj.visibility = "hide"
        else if ( (ie4) || (ie5) || (ie6) ) obj.visibility = "hidden"
}

function moveTo(obj,xL,yL) {
        obj.left = xL
        obj.top = yL
}

function OpenWin(w, h, winname, url) {
    PopupWin = window.open(url, winname, "width=" + w + ",height=" + h + ",resizable,screenX=40,screenY=100,top=100,left=40,scrollbars=yes");
	PopupWin.focus();
}

function PickItem() {
	document.forms[0].func.value= "pick";
	document.forms[0].submit();
}

function DeleteItem() {
	if (confirm("<%=LabelStr(9)%>")) {
		document.forms[0].func.value= "delete";
		document.forms[0].submit();
	}
}

function UnregItem() {
	if (confirm("<%=LabelStr(87)%>")) {
		document.forms[0].func.value= "unreg";
		document.forms[0].submit();
	}
}

function CatalogItem() {
	OpenWin(500, 300, "CatFormWin", "");
	document.forms[0].action = "emenu.asp";
	document.forms[0].target = "CatFormWin";
	document.forms[0].submit();
}

function Upload() {
	OpenWin(600, 400, "AttachWin", "eupload.asp?Loc=<%=Replace(sl, "\", "\\")%>");
}

/*
function AttachItem() {
	document.forms[0].func.value = "attach";
	document.forms[0].DocID.value = prompt("<%=LabelStr(24)%>", "");
	document.forms[0].submit();
}

function MoveItem() {
	document.forms[0].func.value = "move";
	document.forms[0].importloc.value = prompt("<%=LabelStr(31)%>", "<%=Replace(sl, "\", "\\")%>");
	document.forms[0].submit();
}

function RemoveFolder() {
	if (confirm("<%=LabelStr(42)%>")) {
		document.forms[0].func.value = "removefolder";
		document.forms[0].submit();
	}
}

function DetachItem() {
	if (confirm("<%=LabelStr(28)%>")) {
		document.forms[0].func.value = "detach";
		document.forms[0].submit();
	}
}

function CreatePDF() {
	pdffile = prompt("<%=LabelStr(65)%>", "");
	if (pdffile != null) {
		document.forms[0].importloc.value = pdffile
		document.forms[0].func.value = "createpdf";
		document.forms[0].submit();
	}
}

function CreateSubFolder() {
	document.forms[0].func.value = "subfolder";
	subfoldername = prompt("<%=LabelStr(36)%>", "");
	if (subfoldername != null) {
		document.forms[0].importloc.value = subfoldername
		document.forms[0].submit();
	}
}

function RenameFolder() {
	document.forms[0].func.value = "renamefolder";
	document.forms[0].importloc.value = prompt("<%=LabelStr(39)%>", "");
	document.forms[0].submit();
}

function SetSecretLevel() {
	document.forms[0].func.value = "setsecretlevel";
	slevel = prompt("<%=LabelStr(70)%>", "");
	if (! isNaN(slevel)) {
		slevel = parseInt(slevel);
		if (slevel >= 0 && slevel <=9) {
			document.forms[0].importloc.value = slevel;
			document.forms[0].submit();
		}
	}
}

function AddToCollection() {
	document.forms[0].func.value = "collection";
	OpenWin(500, 120, "CollectionWin", "collview.asp");
}

function Import() {
	document.forms[0].func.value = "import";
	document.forms[0].importloc.value = prompt("<%=LabelStr(11)%>", "");
	document.forms[0].submit();
}


function ImportFiles() {
	if (confirm("<%=LabelStr(20)%>")) {
		document.forms[0].func.value = "importfiles";
		document.forms[0].submit();
	}
}

function FSSync() {
	document.forms[0].func.value = "sync";
	document.forms[0].submit();
}


_menuCloseDelay=500           // The time delay for menus to remain visible on mouse out
_menuOpenDelay=150            // The time delay before menus open on mouse over
_subOffsetTop=10              // Sub menu top offset
_subOffsetLeft=-10            // Sub menu left offset

with(menuStyle=new mm_style()){
onbgcolor="#4F8EB6";
oncolor="#ffffff";
offbgcolor="#DCE9F0";
offcolor="#515151";
bordercolor="#296488";
borderstyle="solid";
borderwidth=1;
separatorcolor="#2D729D";
separatorsize="1";
padding=5;
fontsize="75%";
fontstyle="normal";
fontfamily="<%=Font%>";
pagecolor="black";
pagebgcolor="#82B6D7";
headercolor="#000000";
headerbgcolor="#ffffff";
subimage="arrow.gif";
subimagepadding="2";
overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color='#777777', Direction=135, Strength=5)";
outfilter="randomdissolve(duration=0.3)";
}

var focusID;

function ShowContextMenu(fileID) {
	focusID = fileID
	popup('partners','imgdoc' + fileID)
}

function DownloadLink() {
	DownloadWin = window.open("", "DownloadWin", "");
	DownloadWin.focus();
	DownloadWin.location.href = "download.asp?ID=" + focusID;
	return;
}

function ExternalEditLink() {
	self.location.href = "editfile.asp?ID=" + focusID;
	return;
}

with(milonic=new menuname("Partners")){
style=menuStyle;
aI("text=<%=LabelStr(98)%>;url=JavaScript:DownloadLink();status=;");
aI("text=<%=LabelStr(99)%>;url=JavaScript:ExternalEditLink();status=;");
//aI("text=Anti Spam Tools;showmenu=Anti Spam;status=Anti Spam Solutions, as used by Milonic;");
}


drawMenus();

*/

/*
	SetAttributes function
	Purpose: set attributes for selected file
*/
function SetAttributes(strPath, strComment){
	strAttributes = prompt(strComment + '\n' + 'A=Archive, R=ReadOnly, H=Hidden, S=System, (space)=None:', '');
	if ((strAttributes) && (strAttributes!="")) {
		document.forms[0].hidFunc.value = "SetAttributes";
		document.forms[0].hidLoc.value = strPath;
		document.forms[0].hidAttr.value = strAttributes;
		document.forms[0].submit();
	}
}

/*
	ImportFromFS function
	Purpose: Import from file system
*/
function ImportFromFS(strPath, strComment){
	strFolder = prompt(strComment, '');
	if ((strFolder) && (strFolder!="")) {
		document.forms[0].hidFunc.value = "ImportFromFS";
		document.forms[0].hidLoc.value = strPath;
		document.forms[0].hidFolder.value = strFolder;
		document.forms[0].submit();
	}
}
/*	
	CreateFolder function
	Purpose: xu ly chuoi nhap vao
*/
function CheckNameofFolder(strFormat){
		if ( strFormat.indexOf("'") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf(":") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("=") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("!") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("$") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("#") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("@") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("  ") >= 0 )		
			{
				return false;
			}
		return true;
}
/*
	CreateFolder function
	Purpose: Create new folder
*/
function CreateFolder(strPath, strComment,strMsg,strMsgErr){
	strFolderName = prompt(strComment, '');
	if ((strFolderName) && (strFolderName!="")) {
		if (CheckNameofFolder(strFolderName)) {
			document.forms[0].hidFunc.value = "CreateFolder";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName				
			document.forms[0].submit();
		}
		else {
			alert(strMsgErr);
			return false;
		}
	}
}

/*
	RenameFolder function
	Purpose: Rename the existing folder
*/
function RenameFolder(strPath, strComment, strMsg,strMsgErr){
	strFolderName = prompt(strComment, '');
	if ((strFolderName) && (strFolderName!="")) {
		if (CheckNameofFolder(strFolderName)) {
			document.forms[0].hidFunc.value = "RenameFolder";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName;
			document.forms[0].submit();		
		}
		else {
			alert(strMsgErr);
			return false;
		}
	}
}

/*
	RenameFolder function
	Purpose: Rename the existing folder
*/
function Synchronize(strPath, strMsg){
	if ((strPath) && (strPath!="")) {
		document.forms[0].hidFunc.value = "Synchronize";
		document.forms[0].hidLoc.value = strPath;
		//alert(strMsg + ' ' + strPath)
		document.forms[0].submit();
	}
}

/*
	RemoveFolder function
	Purpose: Remove the existing folder
*/
function RemoveFolder(strPath, strMsg) {
	if (confirm(strMsg)) {
		document.forms[0].hidFunc.value = "RemoveFolder";
		document.forms[0].hidLoc.value = strPath;
		parent.location.href='WEDataManager.aspx';
		document.forms[0].submit();
	}
}

/*
	ClickMe function
	Purpose: archive/unarrchive file values
*/
function ClickMe(obj) {
	var strTemp; 
	strTemp = document.forms[0].hidIDs.value;
	if (obj.checked) {
		strTemp = strTemp + obj.value + ",";
	} else {
		strTemp = strTemp.replace("," + obj.value + ",", ",");
	}
	document.forms[0].hidIDs.value = strTemp;
}

/*
	SetSecretLevel function
	Purpose: Check the input box is null before Set the secret level for the selected files
*/
function SetSecretLevel(strMsg, strComment,strIsNumber){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		strSetLevel = prompt(strComment, '');
		if ((strSetLevel) && (strSetLevel!="") && !isNaN(strSetLevel)) 
		{
			if (parseFloat(strSetLevel) >= 0 && parseFloat(strSetLevel) <= 9)
			{
				document.forms[0].hidFunc.value = "SetSecretLevel";
				document.forms[0].hidSecretLevel.value = strSetLevel;
				document.forms[0].submit();
			}
			else
			{
				return false;
			}
		}
		else
		if (isNaN(strSetLevel)){
			alert(strIsNumber);
			return false;
		}else
		{
			return false;
		}
	}
	return;
}

/*
	SetSecretLevel function
	Purpose: Check the input box is null before change the status for the selected files
*/
function ChangeStat(strMsg, strComment,strNotOK1,strNotOK2){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		strStatus = prompt(strComment, '');
		if ((strStatus) && (strStatus!="") && !isNaN(strStatus)) 
		{
			if (parseFloat(strStatus) >= 1 && parseFloat(strStatus) <= 4)
			{
				document.forms[0].hidFunc.value = "ChangeStatus";
				document.forms[0].hidStatus.value = strStatus;
				document.forms[0].submit();
			}
			else
			{
				alert(strNotOK2);
				return false;
			}
		}
		else
		if (isNaN(strStatus)){
			 alert(strNotOK1);
			 return false;
		}
		else
		{
		 return false;
		}
	}
	return;
}

/*
	DeleteLogical function
	Purpose: Check the input box is null before delete the logical files
*/
function DeleteLogical(strMsg, strConfirm){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "DeleteLogical";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}


/*
	Move function
	Purpose: Move file to another folder
*/
function Move(strPath, strComment, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		strFolderName = prompt(strComment, '');
		if ((strFolderName) && (strFolderName!="")) {
			document.forms[0].hidFunc.value = "Move";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName;
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}


/*
	Delete function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Delete(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "Delete";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeFree function
	Purpose: Check the input box is null before changing the file to the free cost
*/
function ChangeFree(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeFree";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeCost function
	Purpose: Check the input box is null before changing the file to the not free cost
*/
function ChangeCost(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeCost";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	Catalogue function
	Purpose: Check the radio button is null before delete the logical and physical files
*/
function Catalogue(strMsg){
var strTemp;
var arrIDs;
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
	}
	else
	{
		strTemp = document.forms[0].hidIDs.value;
		arrIDs = strTemp.split(",");
		OpenWindow('WCatalogue.aspx?objID='+ arrIDs[arrIDs.length - 2],'WCatalogue',780,450,50,25);
	}
}

/*
	Attach function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Attach(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		    strFolderName = prompt(strConfirm, '');
		    //if ((strFolderName) && (strFolderName!="") && !isNaN(strFolderName)) 
		    if (strFolderName!="") 
			{
				alert(strFolderName);
				document.forms[0].hidFunc.value = "Attach";
				document.forms[0].hidFolder.value = strFolderName;
				document.forms[0].submit();
			}
			else
			{
				return false;
			}
	}
	return;
}

/*
	Detach function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Detach(strConfirm, strMsg,strMsg1){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		var arrDetach=document.forms[0].hidIDs.value.split(",");
		var i;
		var strDetachIDs=document.forms[0].hidAttachedIDs.value;				
		for(i=0;i<arrDetach.length;i++) {
			if (strDetachIDs.indexOf("," + arrDetach[i] + ",")>-1) {
				document.forms[0].hidFunc.value = "Detach";
				document.forms[0].submit();
				return;				
			}
		}
		alert(strMsg1);
		return false;
	}
	return;
}

/*
	SetCollection function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function SetCollection(strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		return true;
	}
}

/*
	Export function
	Purpose: Check the input box is null before Export record(s) to XML file
*/
function Export(strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		return true;
	}
}

/*
	ImportToFS function
	Purpose: Check the input box is null before import from file system
*/
function ImportToFS(strPath, strMsg, strMsgConfirm){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strMsgConfirm)) {
			document.forms[0].hidFunc.value = "ImportFiles";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ClickMe function
	Purpose: check/uncheck all checkbox
*/
function MarkAll(obj, intMax) {
	var intIndex;
	document.forms[0].hidIDs.value = ',';
	if (eval("document.forms[0].chkFile0")) {
		for (intIndex=0; intIndex<intMax; intIndex++) {
			eval("document.forms[0].chkFile" + intIndex + ".checked = obj.checked");
			ClickMe(eval("document.forms[0].chkFile" + intIndex));
		}
	}
}


/*
	ResetValue function
	Purpose: Reset the value
*/
function ResetValue(){
	var intIndex;
	
	for (intIndex = 0; intIndex<50; intIndex++) {
		if (eval("document.forms[0].chkFile" + intIndex) && eval("document.forms[0].chkFile" + intIndex).checked)
		{
			eval("document.forms[0].chkFile" + intIndex).checked = false;
		}
	}	
}

/*
	DownLoad function
	Purpose: Refresh the page
*/
function DownLoad(strFile){
		document.forms[0].hidFunc.value = "DownLoad";
		document.forms[0].hidLoc.value = strFile;
		document.forms[0].submit();
}

/*
	ChangeToMap function
	Purpose: Check the input box is null before change the item to map type
*/
function ChangeToMap(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeToMap";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeToImage function
	Purpose: Check the input box is null before change the item to imâge type
*/
function ChangeToImage(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeToImage";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}


