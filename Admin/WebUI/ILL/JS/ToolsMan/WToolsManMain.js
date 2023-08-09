/******************************************************
			ToolsMan main page
*****************************************************/

/* Notice:
	id=1: WEDelMode.aspx
	id=2: WCopyPayPhyType.aspx?Mode=PHYSICAL
	id=3: WPhyDelAddr.aspx
	id=4: WCopyPayPhyType.aspx?Mode=PAYMENTTYPE
	id=5: WCopyPayPhyType.aspx?Mode=COPYRIGHT
	id=6: WDenyReason.aspx
	id=7: WZ3950.aspx
*/
function ViewURL(id, w, h){
	if (id==1){URL='WEDelMode.aspx'};
	if (id==2){URL='WCopyPayPhyType.aspx?Mode=PHYSICAL'};
	if (id==3){URL='WPhyDelAddr.aspx'};
	if (id==4){URL='WCopyPayPhyType.aspx?Mode=PAYMENTTYPE'};
	if (id==5){URL='WCopyPayPhyType.aspx?Mode=COPYRIGHT'};	
	if (id==6){URL='WDenyReason.aspx'};
	if (id==7){URL='WZ3950.aspx'};
	var st="height=" + h + ", width=" + w + ",menubar=no,scrollbars=yes,resizable,screenX=120,screenY=120,top=120,left=120";	
	ILLWin = window.open(URL, "Toollist",st);	
	ILLWin.focus();

}