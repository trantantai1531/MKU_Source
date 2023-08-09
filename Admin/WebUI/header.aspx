<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.header" CodeFile="header.aspx.vb" %>
<HTML>
	<HEAD>
		<title>header</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        
		<script language="javascript">
			function replaceSubstring(inputString, fromString, toString) {
			// Goes through the inputString and replaces every occurrence of fromString with toString
			temp = inputString;
				if(fromString == "") {
					return(inputString);
				}
					if(toString.indexOf(fromString) == -1) {// If the string being replaced is not a part of the replacement string (normal situation)
						while(temp.indexOf(fromString) != -1){
							var toTheLeft = temp.substring(0,temp.indexOf(fromString));
							var toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
							temp = toTheLeft + toString + toTheRight;
						}
				}else {// String being replaced is part of replacement string (like "+" being replaced with "++") - prevent aninfinite loop
					var midStrings = Array("~","`","_", "^","#");
					var midStringLen = 1;
					var midString = "";// Find a string that doesn't exist in the inputString to be usedas an "inbetween" string
					while (midString == "") {
						for (var i=0; i < midStrings.length; i++) {
							var tempMidString = "";
								for (var j=0; j < midStringLen; j++) { 
									tempMidString += midStrings[i]; }
								if (fromString.indexOf(tempMidString) == -1) {
									midString = tempMidString;
									i = midStrings.length + 1;
								}
						}
					}
					// Keep on going until we build an "inbetween" string that doesn't exist
					// Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
					while (temp.indexOf(fromString) != -1) {
						var toTheLeft = temp.substring(0, temp.indexOf(fromString));
						var toTheRight =temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
						temp = toTheLeft + midString + toTheRight;
					}
				// Next, replace the "inbetween" string with the "toString"
					while (temp.indexOf(midString) != -1) {
						var toTheLeft = temp.substring(0,temp.indexOf(midString));
						var toTheRight = temp.substring(temp.indexOf(midString)+midString.length,temp.length);
						temp = toTheLeft + toString + toTheRight;
					}
				}
			// Ends the check to see if the string being replaced is part of the replacement string or not
				return temp;
				// Send the updated string back to the user
			}
			

			// MenuClear function
			// Purpose: Clear all hover button
			function MenuClear(){
				var arrIDs;
				// Change the two menu to the standard	
				if (document.forms[0].hidClick.value.indexOf(',') != -1)
				{
					var intTemp;
					arrIDs = document.forms[0].hidClick.value.split(",");				
					
					intTemp = parseFloat(arrIDs[0]);
										
						if (parseFloat(arrIDs[0])>=11)
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/bg_header.gif)';
						}
					eval('menu' + arrIDs[1]).style.backgroundImage='url(Images/header_04.gif)';
				}
				else
				{
					if (document.forms[0].hidClick.value!=0)
					{
						var intTemp;
						intTemp = parseFloat(document.forms[0].hidClick.value);
										
						if (document.forms[0].hidClick.value>=11)
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/bg_header.gif)';
						}
					}
				}
				document.forms[0].hidClick.value = 0;
			}

			//=====================================================================
			//=====================================================================

			// Menu Change function
			// Purpose: Display again the button images when click to other menu
			function MenuChange(intMenu){
				var arrIDs;
				// Change the two menu to the standard	
				if (document.forms[0].hidClick.value.indexOf(',') != -1)
				{
					arrIDs = document.forms[0].hidClick.value.split(",");
					
					if (parseFloat(arrIDs[0])!=intMenu)
					{
						var intTemp;
						intTemp = parseFloat(arrIDs[0]);
										
						if (parseFloat(arrIDs[0])>=11)
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/bg_header.gif)';
						}
					}
					eval('menu' + arrIDs[1]).style.backgroundImage='url(Images/header_04.gif)';
				}
				else
				{
					if (document.forms[0].hidClick.value!=0)
					{
						var intTemp;
						intTemp = parseFloat(document.forms[0].hidClick.value);
										
						if (document.forms[0].hidClick.value>=11)
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intTemp).style.backgroundImage='url(Images/bg_header.gif)';
						}
					}
				}
			}

			// MenuClick
			// Purpose: Change the color of the new menu and keep them until other click event handled
			function MenuClick(intMenu){
				var arrIDs;
			
				if (intMenu!=0)
				{			
					if (intMenu == 12) 
					{
						if (document.forms[0].hidClick.value.indexOf(',') == -1)
						{
							if (document.forms[0].hidClick.value!=0 && document.forms[0].hidClick.value!=11)
							{
								document.forms[0].hidClick.value = document.forms[0].hidClick.value + ',' + intMenu;
							}
							else
							{
								document.forms[0].hidClick.value = intMenu;
							}
						}
						else
						{
							if (document.forms[0].hidClick.value.indexOf(11) != -1)
							{
								document.forms[0].hidClick.value = replaceSubstring(document.forms[0].hidClick.value,'11','12');
								menu11.style.backgroundImage='url(Images/header_04.gif)';
							}
						}
					}
					else if (intMenu == 11) 
					{
						if (document.forms[0].hidClick.value.indexOf(',') == -1)
						{
							if (document.forms[0].hidClick.value!=0 && document.forms[0].hidClick.value!=12)
							{
								document.forms[0].hidClick.value = document.forms[0].hidClick.value + ',' + intMenu;
							}
							else
							{
								document.forms[0].hidClick.value = intMenu;
							}
						}
						else
						{
							if (document.forms[0].hidClick.value.indexOf('12') != -1)
							{
								document.forms[0].hidClick.value = replaceSubstring(document.forms[0].hidClick.value,'12','11');
								menu12.style.backgroundImage='url(Images/header_04.gif)';
							}
						}
					}
					else
					{
						document.forms[0].hidClick.value = intMenu;
					}
					
					// Remove hover for all 2 buttons
					if (document.forms[0].hidClick.value.indexOf(',') != -1)
					{
						arrIDs = document.forms[0].hidClick.value.split(",");
						eval('menu' + parseFloat(arrIDs[1])).style.backgroundImage='url(Images/header_b2.gif)';
					}
					else // Remove hover for almost other case
					{
						if (document.forms[0].hidClick.value>=11)
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b2.gif)';
						}
						else
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b1.gif)';
						}
					}
				}
			}

			// MenuHover 
			// Purpose: Change the color of the button hovered (The click button not have to change)
			function MenuHover(intMenu){
				var arrIDs;
				if (document.forms[0].hidClick.value.indexOf(',') != -1)
				{
					arrIDs = document.forms[0].hidClick.value.split(",");
					if (intMenu!=0 && intMenu!=arrIDs[0] && intMenu!=arrIDs[1])
					{								
						if (intMenu>=11)
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b2.gif)';				
						}
						else
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b1.gif)';
						}
					}
				}
				else
				{
					if (intMenu!=0 && intMenu!=document.forms[0].hidClick)
					{								
						if (intMenu>=11)
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b2.gif)';				
						}
						else
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_b1.gif)';
						}
					}
				}
			}

			// MenuOut
			// Purpose: Clear the color of the button (Change for the UnClick button)
			function MenuOut(intMenu){
				var arrIDs;
				if (document.forms[0].hidClick.value.indexOf(',') != -1)
				{
					arrIDs = document.forms[0].hidClick.value.split(",");
					if(intMenu!=arrIDs[0] && intMenu!=arrIDs[1])
					{						
						if (intMenu>=11)
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/bg_header.gif)';
						}
					}
				}
				else
				{
					if(document.forms[0].hidClick.value!=intMenu)
					{						
						if (intMenu>=11)
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/header_04.gif)';
						}
						else
						{
							eval('menu' + intMenu).style.backgroundImage='url(Images/bg_header.gif)';
						}
					}
				}
			}
		</script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="1" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" id="tblHeader">
				<tr>
					<td width="100%"><IMG height="1" src="images/dot_01.gif" width="1" border="0"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" id="tblMain">
				<tr>
				    <td width="2" background="Images/header_02.gif"></td>
					<td id="menu1" width="30" background="Images/libol60.png" height="20"></td>
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu2" background="images/bg_header.gif" onmouseover="MenuHover(2)" onclick="MenuChange(2);Admin_Click();MenuClick(2);"
						onmouseout="MenuOut(2);">
						<p align="center"><asp:hyperlink id="lnkAdmin" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Quản lý</asp:hyperlink></p>
					</td>
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu6" background="images/bg_header.gif" onmouseover="MenuHover(6)" onclick="MenuChange(6);Acquisition_Click();MenuClick(6);"
						onmouseout="MenuOut(6);">
						<p align="center"><asp:hyperlink id="lnkAcquisition" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Bổ sung</asp:hyperlink></p>
					</td>
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu4" background="images/bg_header.gif" onmouseover="MenuHover(4)" onclick="MenuChange(4);Catalogue_Click();MenuClick(4);"
						onmouseout="MenuOut(4);">
						<p align="center"><asp:hyperlink id="lnkCatalogue" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Biên mục</asp:hyperlink></p>
					</td>
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu7" background="images/bg_header.gif" onmouseover="MenuHover(7)" onclick="MenuChange(7);Serial_Click();MenuClick(7);"
						onmouseout="MenuOut(7);">
						<p align="center"><asp:hyperlink id="lnkSerial" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Định kỳ</asp:hyperlink></p>
					</td>		
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu3" background="images/bg_header.gif" onmouseover="MenuHover(3)" onclick="MenuChange(3);Patron_Click();MenuClick(3);"
						onmouseout="MenuOut(3);">
						<p align="center"><asp:hyperlink id="lnkPatron" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Bạn đọc</asp:hyperlink></p>
					</td>					
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu5" background="images/bg_header.gif" onmouseover="MenuHover(5)" onclick="MenuChange(5);Circulation_Click();MenuClick(5);"
						onmouseout="MenuOut(5);">
						<p align="center"><asp:hyperlink id="lnkCirculation" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Mượn trả</asp:hyperlink></p>
					</td>			
							
					<td width="2" background="Images/header_02.gif"></td>
					<td id="menu10" background="images/bg_header.gif" onmouseover="MenuHover(10)" onclick="MenuChange(10);Opac_Click();MenuClick(10);"
						onmouseout="MenuOut(10);">
						<p align="center"><asp:hyperlink id="lnkOPAC" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">OPAC</asp:hyperlink></p>
					</td>
					<td width="1" background="Images/header_02.gif" style="display:none;"></td>
					<td id="menu11" background="images/header_04.gif" onmouseover="MenuHover(11)" onclick="MenuClick(11);MenuChange(11);Help_Click();"
						onmouseout="MenuOut(11);" style="display:none;">
						<p align="center"><asp:hyperlink id="lnkHelp" runat="server" CssClass="lbLinkheader" NavigateUrl="#">Trợ giúp</asp:hyperlink></p>
					</td>
					<td width="1" background="Images/header_02.gif" style="display:none;"></td>
					<td id="menu12" background="images/header_04.gif" onmouseover="MenuHover(12)" onclick="Setting_Click(12);MenuClick(12);"
						onmouseout="MenuOut(12);" style="display:none;">
						<p align="center"><asp:hyperlink id="lnkSetting" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Thiết đặt</asp:hyperlink></p>
					</td>
					<td width="1" background="Images/header_02.gif" style="display:none;"></td>
					<td id="menu13" background="images/header_04.gif" onmouseover="MenuHover(13)" onclick="MenuChange(13);Logout_Click();MenuClick(13);"
						onmouseout="MenuOut(13);">
						<p align="center"><asp:hyperlink id="lnkLogOut" runat="server" NavigateUrl="#" Cssclass="lbLinkheader">Thoát</asp:hyperlink></p>
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidClick" value="0"> <input id="hidLanguage" runat="server" type="hidden" NAME="hidLanguage">
		</form>
		<script language="javascript">
		    MenuChange(4); Catalogue_Click(); MenuClick(4);
		</script>
	</body>
</HTML>
