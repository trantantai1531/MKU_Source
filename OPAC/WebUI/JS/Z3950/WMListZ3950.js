///////////////////////////////////////
function CheckforExitVal(val,lbox) {
	var j=0;
	var instr='';
	var tmp='';
	for(j=0;j<lbox.length;j++) {
		instr=lbox.options[j].value;		
		tmp=instr.substring(1,instr.length);
		if((instr.toUpperCase()==val.toUpperCase())||(tmp.toUpperCase()==val.toUpperCase()))
			return true;
		}
	return false;
}
///////////////////////////////////////
function TrimTextForListZ3950(){
	var i=0;		
	var instr='';
	var pos=0;
	for (i = 0; i < document.forms[0].listZServerAdd.length; i++) {
		instr=document.forms[0].listZServerAdd.options[i].text;
		pos = instr.indexOf("(");		
		document.forms[0].listZServerAdd.options[i].text=instr.substring(0,pos);					
	}
}

function UpLoadListZServer(){
	var i=0;
	// add items into listZServerAdd
	for (i = 0; i < opener.document.forms[0].ListZ3950.length; i++) {
		if(CheckforExitVal(opener.document.forms[0].ListZ3950.options[i].value,document.forms[0].listZServerCur)) {
			document.forms[0].listZServerAdd.length++;		
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].value = opener.document.forms[0].ListZ3950.options[i].value;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].text = opener.document.forms[0].ListZ3950.options[i].text;					
		}
		else {
			document.forms[0].listZServerAdd.length++;		
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].value = '$'+opener.document.forms[0].ListZ3950.options[i].value;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].text = opener.document.forms[0].ListZ3950.options[i].text;					
		}
		
	}	
	//remove items out listZServerCur	
	if(document.forms[0].listZServerAdd.length>0) {
		var k=0;
		for(i=0;i<document.forms[0].listZServerCur.length;i++) {
			if(!CheckforExitVal(document.forms[0].listZServerCur.options[i].value,document.forms[0].listZServerAdd)) {
				document.forms[0].listZServerCur.options[k].value=document.forms[0].listZServerCur.options[i].value;
				document.forms[0].listZServerCur.options[k].text=document.forms[0].listZServerCur.options[i].text;
				k=k+1;
			}				
		}
		document.forms[0].listZServerCur.length=k;
	}
	//TrimTextForListZ3950();
}
///////////////////////////////////////
function TrimValueForListZ3950(){
	var i=0;		
	var strtemp="";
	for (i = 0; i < document.forms[0].listZServerAdd.length; i++) {
		strtemp=document.forms[0].listZServerAdd.options[i].value;
		if(strtemp.charAt(0)=='$'){
			document.forms[0].listZServerAdd.options[i].value=strtemp.substring(1,strtemp.length);			
		}
	}
}
//////////////////////////////////
function SetValueZHost() {
	var i=0;
	var strval='';
	var strname='';
	if(document.forms[0].listZServerAdd.length>0) {
		strval=document.forms[0].listZServerAdd.options[0].value;
		strname=document.forms[0].listZServerAdd.options[0].text;
		for (i = 1; i < document.forms[0].listZServerAdd.length; i++) {
			strval=strval+'|'+document.forms[0].listZServerAdd.options[i].value;
			strname=strname+'|'+document.forms[0].listZServerAdd.options[i].text;
		}
	}
	opener.document.forms[0].ArrZHost.value=strval;	
	opener.document.forms[0].ArrNameHost.value=strname;		
}

///////////////////////////////////////
function DownloadListZServer(){
	TrimValueForListZ3950();
	var i=0;
	// add items into listZServerAdd
	opener.document.forms[0].ListZ3950.length=0;
	for (i = 0; i < document.forms[0].listZServerAdd.length; i++) {
		opener.document.forms[0].ListZ3950.length++;
		opener.document.forms[0].ListZ3950.options[(opener.document.forms[0].ListZ3950.length)- 1].value = document.forms[0].listZServerAdd.options[i].value;
		opener.document.forms[0].ListZ3950.options[(opener.document.forms[0].ListZ3950.length)- 1].text = document.forms[0].listZServerAdd.options[i].text;//+'('+document.forms[0].listZServerAdd.options[i].value+')';						
	}
	SetValueZHost();
	self.close();		
}
////////////////////////////////////////////
function AddItem(){
	var k = 0;
	var i=0;
	for (i = 0; i < document.forms[0].listZServerCur.length; i++) {
		if(document.forms[0].listZServerCur.options[i].selected) {
			document.forms[0].listZServerAdd.length++;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].value = document.forms[0].listZServerCur.options[i].value;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].text = document.forms[0].listZServerCur.options[i].text;		
		}
		else {document.forms[0].listZServerCur.options[k].value =document.forms[0].listZServerCur.options[i].value;
			document.forms[0].listZServerCur.options[k].text =document.forms[0].listZServerCur.options[i].text;
			document.forms[0].listZServerCur.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].listZServerCur.length = k;
}
// Called when remove Item from listbox listZServerAdd
function RemoveItem(){
	var k=0;              
	var i=0;
	for (i = 0; i < document.forms[0].listZServerAdd.length; i++) {	
		if(document.forms[0].listZServerAdd.options[i].selected) {
			var tmp=document.forms[0].listZServerAdd.options[i].value;			
			if(tmp.charAt(0)!='$') {
				document.forms[0].listZServerCur.length++;
				document.forms[0].listZServerCur.options[(document.forms[0].listZServerCur.length)- 1].value = document.forms[0].listZServerAdd.options[i].value;
				document.forms[0].listZServerCur.options[(document.forms[0].listZServerCur.length)- 1].text = document.forms[0].listZServerAdd.options[i].text;	
			}
		}
		else {document.forms[0].listZServerAdd.options[k].value =document.forms[0].listZServerAdd.options[i].value;
		document.forms[0].listZServerAdd.options[k].text =document.forms[0].listZServerAdd.options[i].text;
		document.forms[0].listZServerAdd.options[k].selected = false;		
		k=k+1;
		}
	}			
	document.forms[0].listZServerAdd.length = k;
}
//////////////////////////////////////////////////////
function AddNewItem(strNote) {
	var instr=document.forms[0].txtAddnew.value;
	var pos;	
	var Namelib;
	var Valuelib;	
	if (instr!=''){
		pos = instr.indexOf("(");
		Namelib=instr.substring(0,pos);
		instr = instr.substring(pos + 1);
		pos = instr.indexOf(")");		
		Valuelib = '$'+instr.substring(0,pos);		
		if(CheckforExitVal(instr.substring(0,pos),document.forms[0].listZServerAdd)) {
			alert(strNote);			
		}
		else {
			document.forms[0].listZServerAdd.length++;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].value = Valuelib ;
			document.forms[0].listZServerAdd.options[(document.forms[0].listZServerAdd.length)- 1].text = Namelib;						
		}
	}
}
///////////////////////////////////////////////

function RepairItem(strNote) {
	var instr=document.forms[0].txtAddnew.value;
	var pos;	
	var Namelib;
	var Valuelib;	
	if (instr!=''){
		pos = instr.indexOf("(");
		Namelib=instr.substring(0,pos);
		instr = instr.substring(pos + 1);
		pos = instr.indexOf(")");
		Valuelib = '$'+instr.substring(0,pos);
		var i=0;		
		for (i = 0; i < document.forms[0].listZServerAdd.length; i++) {
			if(document.forms[0].listZServerAdd.options[i].selected) {
				instr=document.forms[0].listZServerAdd.options[i].value;				
				if(instr.charAt(0)!='$') {				
					alert(strNote);
				}
				else {
						document.forms[0].listZServerAdd.options[i].value = Valuelib ;
						document.forms[0].listZServerAdd.options[i].text = Namelib;			
				}				
				break;				
			}		
		}		
	}
}

function SetTextItem() {	
	var i=0;
	for (i = 0; i < document.forms[0].listZServerAdd.length; i++) 
		if(document.forms[0].listZServerAdd.options[i].selected) {
			var instr='';
			instr=document.forms[0].listZServerAdd.options[i].value;
			if(instr.charAt(0)!='$')
				document.forms[0].txtAddnew.value = document.forms[0].listZServerAdd.options[i].text + '(' + document.forms[0].listZServerAdd.options[i].value + ')';
			else {				
				document.forms[0].txtAddnew.value = document.forms[0].listZServerAdd.options[i].text + '(' + instr.substring(1,instr.length) + ')';
			}
			break;
		}	
}
