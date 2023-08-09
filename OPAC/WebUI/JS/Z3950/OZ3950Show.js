/*
	LoadBack function
*/
function LoadBack(val){
	var pos;
	var Server;
	var Port;
	var db;
	var temp = val;
	if (val!=''){
		pos = temp.indexOf(":");
		Server = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
			
		pos = temp.indexOf("#");
		Port = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
		
		db = temp;
		
		top.document.forms[0].txtzServer.value = Server;
		top.document.forms[0].txtZPort.value = Port;
		top.document.forms[0].txtZDatabase.value = db;
	}
//self.close();
	top.closeShowServerList();
}
function show(zHost){
	pos = zHost.indexOf(":");
	host = zHost.substring(0,pos);
	zHost = zHost.substring(pos + 1);	
	pos = zHost.indexOf("#");
	port = zHost.substring(0,pos);
	zHost = zHost.substring(pos + 1);
	db = zHost;
	document.forms[0].action = 'OZ3950Show.aspx?Searched=MutilSearch';
	document.forms[0].txtzServer.value=host;
	document.forms[0].txtZPort.value=port;
	document.forms[0].txtzDatabase.value=db;	
	document.forms[0].submit();
}

function showRecordByPage(pg) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var raiseShowRecord = document.getElementById('raiseShowRecord');
    raiseShowRecord.click();
}
