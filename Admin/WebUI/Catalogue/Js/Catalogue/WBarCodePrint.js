/**********************************************************************************/
/**********************	 	 WBarcodePrint Js file		***************************/
/**********************************************************************************/
//Purpose: kiem tra va gan cac gia tri cho phan in ma vach
//Creator: sondp
//CreatedDate: 24/02/2005

//btnPrevious Click
function PreviousClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
alert(Cpage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<=1){
				CPage=1;
			}
			else{
				CPage=CPage-1;
			}
		}
	}
	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WBarCodePrint.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
//btnNext Click
function NextClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if (CPage>=MaxPage) {
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1){CPage=1;
			}
			else CPage=CPage+1;
		}
	}
	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WBarCodePrint.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
//txtCurrentPage Change
function CurrentPageChange(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1){
				CPage=1;
			}		
		}	
	}	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WBarCodePrint.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
function BindStoreData(LibraryID){
	document.forms[0].hdStore.value=0;
	if(LibraryID==0){ // Delete store here
		document.forms[0].ddlStore.options.length=0;		
	}
	else{ // Bind Store
		document.forms[0].ddlStore.options.length=0;
		for(i=0;i<ID.length;i++){
			if(LibraryID==LibID[i]){
				document.forms[0].ddlStore.options.length++;
				document.forms[0].ddlStore.options[document.forms[0].ddlStore.options.length-1].value=ID[i];
				document.forms[0].ddlStore.options[document.forms[0].ddlStore.options.length-1].text=Symbol[i];
			}
		}
		if(document.forms[0].ddlStore.options.length>0){
			document.forms[0].hdStore.value=document.forms[0].ddlStore.options[0].value;
		}
		else{
			document.forms[0].hdStore.value=0;
		}
	}
	return false;
}
//se lam sach cac control tren form, dua chung ve trang thai ban dau khi nut reset duoc nhan
function ResetForm(){
//Phan dieu kien loc
	document.forms[0].ddlLibrary.options[0].selected=true;
	document.forms[0].ddlStore.options.length=0;
	document.forms[0].optCodeItem.checked=false;
	document.forms[0].hdStore.value=0;
	document.forms[0].txtFromCodeItem.value='';
	document.forms[0].txtToCodeItem.value='';
	document.forms[0].optCopyNumber.checked=true;
	document.forms[0].txtFromCopyNumber.value='';
	document.forms[0].txtToCopyNumber.value='';
	document.forms[0].optElse.checked=false;
	document.forms[0].txtElse.value='';
//Phan noi dung in
	document.forms[0].ckbShelf.checked=false;
	document.forms[0].ckbItemCode.checked=false;
	document.forms[0].ckbCopyNumber.checked=true;
	document.forms[0].hrfChoice.value=1;
//Phan khuon dang ma vach
	document.forms[0].ddlType.options[3].selected=true;
	document.forms[0].txtHeight.value=70;
	document.forms[0].txtWidth.value=1;
	document.forms[0].ddlRotation.options[0].selected=true;
	document.forms[0].txtRowSpace.value=0;
	document.forms[0].txtColSpace.value=0;
	document.forms[0].txtColNumber.value=1;
	document.forms[0].txtPage.value=20;
	return false;
}