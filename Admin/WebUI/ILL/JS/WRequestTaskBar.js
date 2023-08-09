function FilterInData()
{
	parent.Workform.location.href = 'WFilter.aspx?Type=1';
	document.forms[0].btnFilter.disabled=true;
	document.forms[0].ddlAction.disabled=true;
	document.forms[0].btnAction.disabled=true;
	document.forms[0].btnFilter.disabled=true;
	document.forms[0].btnCancelFilter.disabled=true;
}	

function FilterOutData()
{
	parent.Workform.location.href = 'WFilter.aspx?Type=2';
	document.forms[0].btnFilter.disabled=true;
	if (eval(document.forms[0].btnCreate))
	{
		document.forms[0].btnCreate.disabled=true;
	}
	document.forms[0].ddlAction.disabled=true;	
	document.forms[0].btnAction.disabled=true;
	document.forms[0].btnFilter.disabled=true;
	document.forms[0].btnCancelFilter.disabled=true;
}

function Act()
{
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 1)
	{
		// dinh vi an pham
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRSetItemLocation.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRSetIem',620,500,100,50);
		else
		// Duyet, sua lai
		{
			parent.Workform.location.href = 'ORMan/WORCreate.aspx?clone=0&ILLID=' + document.forms[0].hidRequestID.value ;
			parent.Sentform.location.href = 'ORMan/WORCreateTaskBar.aspx?CreateNew=0';
		}
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 2)
	{	// in nhan dong goi
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRPackage.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRSetIem',550,300,100,50);
		else
		// nhan ban
		{
			parent.Workform.location.href = 'ORMan/WORCreate.aspx?Update=1&clone=1&ILLID=' + document.forms[0].hidRequestID.value ;
			//parent.Sentform.location.href = 'ORMan/WORCreateTaskBar.aspx?CreateNew=0';
		}
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 3)
	{
		// Dat dk cho muon
		if (document.forms[0].hidReqType.value == 1)
				OpenWindow('IRMan/WIRSetCondition.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRSetCondition',550,300,50,50);
		// gui yeu cau				
		else
				OpenWindow('ORMan/WORSendReq.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORSendReq',600,180,50,50);
		
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 4)
	{
		// Khong cung cap (de nghi gui lai)
		if (document.forms[0].hidReqType.value == 1)
				OpenWindow('IRMan/WIRSendRetry.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRSendRetry',500,270,50,50);
		// huy bo yeu cau
		else
				OpenWindow('ORMan/WORCancelReq.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORCancelReq',450,200,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 5)
	{
		// Khong cung cap
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRNotSupplied.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRNotSupplied',650,300,50,50);
		else
			// sua chua
			{
				parent.Workform.location.href = 'ORMan/WORCreate.aspx?clone=2&ILLID=' + document.forms[0].hidRequestID.value ;
				parent.Sentform.location.href = 'ORMan/WORCreateTaskBar.aspx?CreateNew=0';
			}
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 6)
	{
		// Se cung cap
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRwillSupply.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRwillSupply',600,280,50,50);
		// Lich su yeu cau
		else
			OpenWindow('ORMan/WORHisRequest.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORHisRequest',500,280,50,50);
			
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 7)
	{
		// Tinh chi phi muon
		if (document.forms[0].hidReqType.value == 1)
			alert("No support !");
			//OpenWindow('WRequestPrintPack.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WRequestSendFile',510,250,100,50);
		// Tu choi yeu cau
		else
			OpenWindow('ORMan/WORDenied.aspx?IllID=' + document.forms[0].hidRequestID.value,'WORDenied',450,120,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 8)
	{
		// Giao hang
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRShipMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRShipMess',700,650,50,10);
		// Tra loi thong bao dieu kien
		else
			OpenWindow('ORMan/WORAcceptCond.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORAcceptCond',500,280,50,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 9)
	{
		// Huy bo yeu cau
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRCancel.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRCancel',500,280,50,50);
		
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 10)
	{	
		// Gia han	
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRExtend.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRExtend',500,280,50,50);
		else
		// Nhan duoc
			OpenWindow('ORMan/WORReceipt.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORReceipt',500,300,50,50);
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 11)
	{
		// Doi lai an pham
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRRecalMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRRecallMess',400,210,50,50);
		else
		// Gia han
			OpenWindow('ORMan/WORRenew.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORRenew',500,350,50,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 12)
	{
		// Thong bao qua han
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIROverdueMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIROverdueMess',500,250,50,50);
		else
		// Doi trang thai
			OpenWindow('ORMan/WORChangeStatus.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORChangeStatus',500,320,50,50);
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 13)
	{
		// Ghi nhan hoan tra
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRRefundMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRRefundMess',400,240,50,50);
		else
		// thong bao cho ban doc
			OpenWindow('ORMan/WORPatronMess.aspx?IllID=' + document.forms[0].hidRequestID.value,'WORPatronMess',500,150,50,50);
		
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 14)
	{
		if (document.forms[0].hidReqType.value == 2) 
			OpenWindow('ORMan/WORReturn.aspx?IllID=' + document.forms[0].hidRequestID.value,'WORReturn',600,200,50,50);
			
	}
	
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 15)
	{
		// Lich su yeu cau
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRRequestHistory.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRRequestHistory',500,280,50,50);
		else
		// Bao mat
			OpenWindow('ORMan/WORLost.aspx?IllID=' + document.forms[0].hidRequestID.value,'WORLost',500,230,50,50);
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 16)
	{	
		// Doi trang thai
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRChangeStatus.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRChangeStatus',500,300,100,50);
		else
		// Gui thong diep
			OpenWindow('ORMan/WORSendMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORSendMess',500,280,50,50);
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 17)
	{	
		// Bao mat
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRLostMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRLostMess',400,230,50,50);
		else
			// Hoi trang thai
			OpenWindow('ORMan/WORAskStatus.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORAskStatus',500,280,50,50);
			
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 18)
	{	
		// Gui thong diep
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRSendMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRSendMess',500,210,50,50);
		else
			// Xoa
			OpenWindow('ORMan/WORDelete.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORDelete',500,80,50,50);
	}

	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 19)
	{	
		// Hoi trang thai
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRAskstatus.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRAskstatus',500,210,50,50);
		else
			// Chuyen tm thich hop
			parent.Hiddenbase.location.href = 'ORMan/WChangeFolder.aspx?ILLID=' + document.forms[0].hidRequestID.value;
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 20)
	{	
		// Xoa
		if (document.forms[0].hidReqType.value == 1)
			OpenWindow('IRMan/WIRDelete.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WIRDelete',400,120,50,50);
		else
			// Dinh vi an pham
			OpenWindow('ORMan/WORSetIem.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORSetIem',620,500,100,50);
	}
	
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 21)
	{
		// Chuyen sang thu muc thich hop
		if (document.forms[0].hidReqType.value == 1) 
			parent.Hiddenbase.location.href = 'IRMan/WIRChangeFolder.aspx?ILLID=' + document.forms[0].hidRequestID.value;
		else
			// Thong bao wa han
			OpenWindow('ORMan/WORDueMess.aspx?ILLID=' + document.forms[0].hidRequestID.value,'WORDueMess',500,200,50,50);
	}	
}

function Create(){	
	//parent.Workform.location.href = 'ORMan/WORCreate.aspx';
	parent.Sentform.location.href = 'ORMan/WORCreateTaskBar.aspx';
}

function OnLoad(){
	parent.document.getElementById('frmSubMain').setAttribute('rows',rows="*,28");
}