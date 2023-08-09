<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WAccountDetail" CodeFile="WAccountDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>WAccountDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body leftMargin="0" topMargin="0" onload="if (eval('document.forms[0].txtCustomerCode')) {document.forms[0].txtCustomerCode.focus();}; if (eval('document.forms[0].txtRate')) {ChangeRate('VND');}">
		<form id="Form1" method="post" runat="server">
		    <div id="divBody">
                <asp:label id="lblHeader" Runat="server" cssclass="main-head-form">Quản lý thu phí mua ấn phẩm điện tử</asp:label>
        	  	<div class="two-column ClearFix">
            	<div class="row-detail">
                    <asp:label id="lblDetails" Runat="server" Cssclass="lbSubformTitle">Chi tiết</asp:label>
                    <asp:label id="lblUnSeetledSum" Runat="server" Cssclass="lbSubformTitle">Tổng phải thu: </asp:label><asp:label id="lblUnSettledAmount" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="lbSetCur" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label>
                    <asp:label id="lblSeetledSum" Runat="server" Cssclass="lbSubformTitle">Tổng thu: </asp:label><asp:label id="lblSettledAmount" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="lbUnSetCur" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label>
                    <asp:label id="lblRemain" Runat="server" Cssclass="lbSubformTitle">Còn lại: </asp:label><asp:label id="lblRemainAmount" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="lblRemainCur" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label>
                    
                </div>
                <div class="chuaxacdinh">
                    <asp:label Cssclass="lbGroupTitle" id="lblSettledTitle" Runat="server">Khai báo khoản thu</asp:label>
                    <asp:label id="lblReportTitle" Runat="server" Visible="False" Cssclass="lbGroupTitle">Báo cáo</asp:label>
                    <asp:hyperlink id="lnkSettled" Runat="server" CssClass="lbLinkFunction">Khai báo khoản thu </asp:hyperlink><asp:hyperlink id="lnkReport" Runat="server" CssClass="lbLinkFunction">Báo cáo</asp:hyperlink>
                    <div id="TR1" runat="server">
                           <asp:label id="lblCustomerCode" Runat="server" CssClass="lbLabel">Mã tài khoản:</asp:label>
					<asp:textbox id="Textbox1" Runat="Server" CssClass="lbTextBox" Width="72px" AutoPostBack="True"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkCheckDebt" Runat="server" CssClass="lbLinkFunction">Kiểm tra nợ</asp:hyperlink>
					<asp:Label Runat="server" CssClass="lbLabel" id="lblDebt">Số tiền nợ:</asp:Label>
					<asp:textbox id="txtDebt" Runat="server" CssClass="lbTextBox" Enabled="False">0</asp:textbox>
                    </div>
                    <div id="TR2" runat="server">
                           <asp:label id="lblAmount" Runat="server" CssClass="lbLabel">Số tiền thực phải trả:</asp:label>
					<asp:textbox id="txtAmount" Runat="Server" CssClass="lbTextBox" Width="104px">0</asp:textbox>&nbsp;<asp:dropdownlist id="ddlCurrency" Runat="server"></asp:dropdownlist>
					<asp:label id="lblReason" Runat="server" CssClass="lbLabel">Lí do:</asp:label>
					<asp:textbox id="txtReason" Runat="server" CssClass="lbTextBox" Width="100%" TextMode="MultiLine"
							Rows="3"></asp:textbox>
                    </div>
                    <div id="TR3" runat="server">
                         
                   
					<asp:label id="lblRate" Runat="server" CssClass="lbLabel">Tỉ giá (so với VND):</asp:label>
					<asp:textbox id="txtRate" Runat="Server" CssClass="lbTextBox" Width="56px"></asp:textbox>
                    </div>
                 <div id="TR4" runat="server">
                     <asp:label id="lblDate" Runat="server" CssClass="lbLabel">Ngày thu:</asp:label>
					<asp:textbox id="txtDate" Runat="Server" CssClass="lbTextBox" Width="72px"></asp:textbox>&nbsp;<span>/</span>&nbsp;<asp:textbox id="txtYear" Runat="server" Width="50px"></asp:textbox>
						<asp:hyperlink id="lnkDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink>
					
					<asp:button id="btnAction" Runat="server" Text="Thực hiện" cssClass="lbButton"></asp:button>&nbsp;
						<asp:button id="btnCancel" Runat="server" cssClass="lbButton" text="Huỷ bỏ"></asp:button>
                 </div>
               
			
					
				
                </div>
                <asp:textbox id="txtCustomerCode" Runat="Server" CssClass="lbTextBox" Width="72px" AutoPostBack="True"></asp:textbox>
                <div class="row-detail">
                    <asp:label id="lblFineDetails" Runat="server" Font-Size="13">Các khoản chi trả:</asp:label><asp:label id="lblReportDetails" Runat="server" Visible="False" Font-Size="13">Báo cáo các khoản trong:</asp:label>
						<asp:dropdownlist id="ddlFineType" runat="server">
							<asp:ListItem Selected="True" Value="1">Các khoản thu</asp:ListItem>
							<asp:ListItem Value="2">Các khoản phải thu</asp:ListItem>
						</asp:dropdownlist>
                </div>
                <div class="row-detail">
                	<div class="span3">
                      	<div class="pad5">
                      		<p>Báo cáo các quan trọng</p>
                        </div>
                 	</div>
                    <div class="span2">
               			<div class="pad5">
                         	<p> Người thu: </p>
                        	<div class="input-form ">
                                <asp:textbox id="txtCustomerCodeToFil" Runat="server" Width=""></asp:textbox>
                            </div>
               			 </div>
                    </div>
                    <div class="span1">
                		<div class="pad5">
                            <p>Thời gian:</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlMonth" Runat="server">
							<asp:ListItem Value="0" Selected="True">Trong tháng: </asp:ListItem>
							<asp:ListItem Value="1">Tháng 1</asp:ListItem>
							<asp:ListItem Value="2">Tháng 2</asp:ListItem>
							<asp:ListItem Value="3">Tháng 3</asp:ListItem>
							<asp:ListItem Value="4">Tháng 4</asp:ListItem>
							<asp:ListItem Value="5">Tháng 5</asp:ListItem>
							<asp:ListItem Value="6">Tháng 6</asp:ListItem>
							<asp:ListItem Value="7">Tháng 7</asp:ListItem>
							<asp:ListItem Value="8">Tháng 8</asp:ListItem>
							<asp:ListItem Value="9">Tháng 9</asp:ListItem>
							<asp:ListItem Value="10">Tháng 10</asp:ListItem>
							<asp:ListItem Value="11">Tháng 11</asp:ListItem>
							<asp:ListItem Value="12">Tháng 12</asp:ListItem>
						</asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span1">
                        <div class="pad5">
                            <p> Tháng</p>
                            <div class="input-form ">
                                <input type="text" class="text-input">
                            </div>
                        </div>
                    </div>
                    <div class="span2">
                        <div class="pad5">
                            <p>Thực hiện lệnh:</p>
                            <div class="button-control inline-box">
                                  <div class="button-form">
                                        <asp:button id="btnFilter" Runat="server" CssClass="lbButton" Text="Lọc"></asp:button>
                                  </div>
                                  <div class="button-form">
                                        <asp:button id="btnPrint" Runat="server" CssClass="lbButton" Text="In"></asp:button>
                                  </div>
                            </div>
                        </div>
                    </div>
                    <div class="ClearFix"></div>
                    <div class="table-form">
                        <asp:datagrid id="dgtResult" Runat="server" Width="90%" AllowPaging="False" AutoGenerateColumns="False" Height="140px">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Ngày thu">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FROMDATE")%>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>'/>
										<asp:HyperLink Runat="server" CssClass="lbLinkFunction" ID="lnkCalendarDisplay">Lịch</asp:HyperLink>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mã tài khoản">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lý do">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtReasonDisplay" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblAmountDisplay" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtAmountDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Đơn vị TT">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblCurrency" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Visible="False" runat="server" id="txtCurrencyHid" Text='<%# DataBinder.Eval(Container.DataItem, "Currency") %>'>
										</asp:TextBox>
										<asp:DropDownList ID="ddlCurrencyDisplay" Runat="server"></asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tỉ giá" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="6%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblRateDisplay" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" id="txtRateDisplay" cssClass="lbTextBox" Text='<%# DataBinder.Eval(Container.DataItem, "Rate") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thành tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblTotal" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Total")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thanh toán" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblPaid" Runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" 
 CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
								<asp:ButtonColumn HeaderText="Xoá" ItemStyle-HorizontalAlign="Center" Text="&lt;img src=&quot;../../images/delete.gif&quot; border=&quot;0&quot;&gt;" 
 CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
                        <div class="lbGridPager" id="TRSumary" align="right" runat="server">
                        <asp:label id="lblSumaryTemp" runat="server">Tổng: </asp:label><asp:label id="lblSumary" runat="server" CssClass="lbAmount"></asp:label>
                            </div>
                        <asp:table id="tblReport" Runat="server" CssClass="lbGrid" CellPadding="2" CellSpacing="1"></asp:table>
                    </div>
            	</div>
            </div>
        </div>
			<input id="hidToday" type="hidden" name="hidToday" runat="server"> <input id="hidCurrency" type="hidden" name="hidCurrency" runat="server">
			<INPUT id="hidIDs" type="hidden" runat="server" NAME="hidIDs">
            <asp:DropDownList ID="ddlLabel" Runat="server" Visible="false" Width="0" Height="0">
							<asp:ListItem Value="0">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
							<asp:ListItem Value="1">Bảng cân đối các khoản thu và phải thu</asp:ListItem>
							<asp:ListItem Value="2">Ngày</asp:ListItem>
							<asp:ListItem Value="3">Diễn giải</asp:ListItem>
							<asp:ListItem Value="4">Thu</asp:ListItem>
							<asp:ListItem Value="5">Phải thu</asp:ListItem>
							<asp:ListItem Value="6">Tỉ giá hạch toán</asp:ListItem>
							<asp:ListItem Value="7">Số tiền</asp:ListItem>
							<asp:ListItem Value="8">Đơn vị TT</asp:ListItem>
							<asp:ListItem Value="9">Tỉ giá thực tế</asp:ListItem>
							<asp:ListItem Value="10">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
							<asp:ListItem Value="11">Tổng</asp:ListItem>
							<asp:ListItem Value="12">Số dư</asp:ListItem>
							<asp:ListItem Value="13">Số tiền nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="14">Tỉ giá phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="15">Số tiền nhập vào phải là kiểu số nguyên dương!</asp:ListItem>
							<asp:ListItem Value="16">Tỉ giá nhập vào phải là kiểu số nguyên dương!</asp:ListItem>
							<asp:ListItem Value="17">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
							<asp:ListItem Value="18">Các trường không được bỏ trống!</asp:ListItem>
							<asp:ListItem Value="19">Tài khoản khách hàng không tồn tại hoặc bị khoá</asp:ListItem>
							<asp:ListItem Value="20">Giao dịch đã được ghi nhận!</asp:ListItem>
							<asp:ListItem Value="21">Giao dịch thất bại!</asp:ListItem>
							<asp:ListItem Value="22">Cập nhật thành công!</asp:ListItem>
							<asp:ListItem Value="23">Cập nhật thất bại!</asp:ListItem>
							<asp:ListItem Value="24">Thanh toán cho danh sách ấn phẩm điện tử sau:</asp:ListItem>
							<asp:ListItem Value="25">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="26">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="27">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="28">Cập nhật khoản thu (phải thu)</asp:ListItem>
							<asp:ListItem Value="29">Xoá khoản thu (phải thu)</asp:ListItem>
							<asp:ListItem Value="30">Ấn OK để khẳng định thao tác xoá!</asp:ListItem>
						</asp:DropDownList>
		</form>
		<script language = javascript>
		    document.forms[0].txtCustomerCodeToFil.focus();
		</script>
	</body>
</HTML>

<%--
	<TABLE id="Table1" cellSpacing="2" cellPadding="0" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="4"><asp:label id="lblHeader" Runat="server" cssclass="lbPageTitle">Quản lý thu phí mua ấn phẩm điện tử</asp:label></TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD colSpan="4">
						<table id="table3" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="left" width="50%"><asp:label Cssclass="lbGroupTitle" id="lblSettledTitle" Runat="server">Khai báo khoản thu</asp:label><asp:label id="lblReportTitle" Runat="server" Visible="False" Cssclass="lbGroupTitle">Báo cáo</asp:label></TD>
								<TD align="right" colSpan="2"><asp:hyperlink id="lnkSettled" Runat="server" CssClass="lbLinkFunction">Khai báo khoản thu </asp:hyperlink>&nbsp;<asp:label id="lblTemp1" Runat="server">| </asp:label>&nbsp;<asp:hyperlink id="lnkReport" Runat="server" CssClass="lbLinkFunction">Báo cáo</asp:hyperlink>&nbsp;</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR id="TR1" runat="server" class="lbControlBar">
					<TD align="right" width="20%"><asp:label id="lblCustomerCode" Runat="server" CssClass="lbLabel">Mã tài khoản:</asp:label></TD>
					<TD width="30%"><asp:textbox id="txtCustomerCode" Runat="Server" CssClass="lbTextBox" Width="72px" AutoPostBack="True"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkCheckDebt" Runat="server" CssClass="lbLinkFunction">Kiểm tra nợ</asp:hyperlink></TD>
					<TD align="right" width="10%" Runat="server" Class="lbLabel"><asp:Label Runat="server" CssClass="lbLabel" id="lblDebt">Số tiền nợ:</asp:Label></TD>
					<TD width="40%"><asp:textbox id="txtDebt" Runat="server" CssClass="lbTextBox" Enabled="False">0</asp:textbox></TD>
				</TR>
				<TR id="TR2" runat="server">
					<TD align="right"><asp:label id="lblAmount" Runat="server" CssClass="lbLabel">Số tiền thực phải trả:</asp:label></TD>
					<TD><asp:textbox id="txtAmount" Runat="Server" CssClass="lbTextBox" Width="104px">0</asp:textbox>&nbsp;<asp:dropdownlist id="ddlCurrency" Runat="server"></asp:dropdownlist></TD>
					<TD align="right"><asp:label id="lblReason" Runat="server" CssClass="lbLabel">Lí do:</asp:label></TD>
					<TD rowSpan="2"><asp:textbox id="txtReason" Runat="server" CssClass="lbTextBox" Width="100%" TextMode="MultiLine"
							Rows="3"></asp:textbox></TD>
				</TR>
				<TR id="TR3" runat="server">
					<TD align="right"><asp:label id="lblRate" Runat="server" CssClass="lbLabel">Tỉ giá (so với VND):</asp:label></TD>
					<TD><asp:textbox id="txtRate" Runat="Server" CssClass="lbTextBox" Width="56px"></asp:textbox></TD>
				</TR>
				<TR id="TR4" runat="server">
					<TD align="right"><asp:label id="lblDate" Runat="server" CssClass="lbLabel">Ngày thu:</asp:label></TD>
					<TD><asp:textbox id="txtDate" Runat="Server" CssClass="lbTextBox" Width="72px"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:button id="btnAction" Runat="server" Text="Thực hiện" cssClass="lbButton"></asp:button>&nbsp;
						<asp:button id="btnCancel" Runat="server" cssClass="lbButton" text="Huỷ bỏ"></asp:button></TD>
				</TR>
				<TR class="lbSubformTitle">
					<TD align="left" colSpan="4">
						<table id="table2" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<TR class="lbSubformTitle">
								<TD class="lbSubTitle" width="25%"><asp:label id="Label1" Runat="server" Cssclass="lbSubformTitle">Chi tiết</asp:label></TD>
								<TD width="25%"><asp:label id="Label2" Runat="server" Cssclass="lbSubformTitle">Tổng phải thu: </asp:label>&nbsp;<asp:label id="Label3" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="Label4" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label></TD>
								<TD width="25%"><asp:label id="Label5" Runat="server" Cssclass="lbSubformTitle">Tổng thu: </asp:label>&nbsp;<asp:label id="Label6" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="Label7" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label></TD>
								<TD width="25%"><asp:label id="Label8" Runat="server" Cssclass="lbSubformTitle">Còn lại: </asp:label>&nbsp;<asp:label id="Label9" Runat="server" CssClass="lbAmount"></asp:label><asp:label id="Label10" Runat="server" Cssclass="lbSubformTitle"> VND</asp:label></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD class="lbSubTitle" style="WIDTH: 355px" colSpan="2"><asp:label id="Label11" Runat="server" Font-Size="13">Các khoản chi trả:</asp:label><asp:label id="Label12" Runat="server" Visible="False" Font-Size="13">Báo cáo các khoản trong:</asp:label>&nbsp;
						<asp:dropdownlist id="Dropdownlist1" runat="server">
							<asp:ListItem Selected="True" Value="1">Các khoản thu</asp:ListItem>
							<asp:ListItem Value="2">Các khoản phải thu</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right" colSpan="2"><asp:label id="lblCustomerCodeToFil" Runat="server">Người đặt mua:</asp:label>&nbsp;<asp:textbox id="Textbox1" Runat="server" Width="72px"></asp:textbox>&nbsp;
						<asp:dropdownlist id="Dropdownlist2" Runat="server">
							<asp:ListItem Value="0" Selected="True">Trong tháng: </asp:ListItem>
							<asp:ListItem Value="1">Tháng 1</asp:ListItem>
							<asp:ListItem Value="2">Tháng 2</asp:ListItem>
							<asp:ListItem Value="3">Tháng 3</asp:ListItem>
							<asp:ListItem Value="4">Tháng 4</asp:ListItem>
							<asp:ListItem Value="5">Tháng 5</asp:ListItem>
							<asp:ListItem Value="6">Tháng 6</asp:ListItem>
							<asp:ListItem Value="7">Tháng 7</asp:ListItem>
							<asp:ListItem Value="8">Tháng 8</asp:ListItem>
							<asp:ListItem Value="9">Tháng 9</asp:ListItem>
							<asp:ListItem Value="10">Tháng 10</asp:ListItem>
							<asp:ListItem Value="11">Tháng 11</asp:ListItem>
							<asp:ListItem Value="12">Tháng 12</asp:ListItem>
						</asp:dropdownlist>&nbsp;
						<asp:label id="Label13" Runat="server">/</asp:label>&nbsp;
						<asp:textbox id="txtYear" Runat="server" Width="50px"></asp:textbox>&nbsp;<asp:button id="Button1" Runat="server" CssClass="lbButton" Text="Lọc"></asp:button>&nbsp;<asp:button id="Button2" Runat="server" CssClass="lbButton" Text="In"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:datagrid id="Datagrid1" Runat="server" Width="90%" AllowPaging="False" AutoGenerateColumns="False" Height="140px">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Ngày thu">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FROMDATE")%>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>'/>
										<asp:HyperLink Runat="server" CssClass="lbLinkFunction" ID="lnkCalendarDisplay">Lịch</asp:HyperLink>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mã tài khoản">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lý do">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtReasonDisplay" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblAmountDisplay" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" cssClass="lbTextBox" id="txtAmountDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Đơn vị TT">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblCurrency" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Visible="False" runat="server" id="txtCurrencyHid" Text='<%# DataBinder.Eval(Container.DataItem, "Currency") %>'>
										</asp:TextBox>
										<asp:DropDownList ID="ddlCurrencyDisplay" Runat="server"></asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tỉ giá" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="6%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblRateDisplay" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
										</asp:label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" runat="server" id="txtRateDisplay" cssClass="lbTextBox" Text='<%# DataBinder.Eval(Container.DataItem, "Rate") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thành tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblTotal" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Total")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thanh toán" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblPaid" Runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" 
 CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
								<asp:ButtonColumn HeaderText="Xoá" ItemStyle-HorizontalAlign="Center" Text="&lt;img src=&quot;../../images/delete.gif&quot; border=&quot;0&quot;&gt;" 
 CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR class="lbGridPager" id="TRSumary" align="right" runat="server">
					<TD class="lbSubTitle" align="right" colSpan="4"><asp:label id="lblSumaryTemp" runat="server">Tổng: </asp:label><asp:label id="lblSumary" runat="server" CssClass="lbAmount"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:table id="tblReport" Runat="server" CssClass="lbGrid" CellPadding="2" CellSpacing="1"></asp:table></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:DropDownList ID="ddlLabel" Runat="server" Visible="false" Width="0" Height="0">
							<asp:ListItem Value="0">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
							<asp:ListItem Value="1">Bảng cân đối các khoản thu và phải thu</asp:ListItem>
							<asp:ListItem Value="2">Ngày</asp:ListItem>
							<asp:ListItem Value="3">Diễn giải</asp:ListItem>
							<asp:ListItem Value="4">Thu</asp:ListItem>
							<asp:ListItem Value="5">Phải thu</asp:ListItem>
							<asp:ListItem Value="6">Tỉ giá hạch toán</asp:ListItem>
							<asp:ListItem Value="7">Số tiền</asp:ListItem>
							<asp:ListItem Value="8">Đơn vị TT</asp:ListItem>
							<asp:ListItem Value="9">Tỉ giá thực tế</asp:ListItem>
							<asp:ListItem Value="10">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
							<asp:ListItem Value="11">Tổng</asp:ListItem>
							<asp:ListItem Value="12">Số dư</asp:ListItem>
							<asp:ListItem Value="13">Số tiền nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="14">Tỉ giá phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="15">Số tiền nhập vào phải là kiểu số nguyên dương!</asp:ListItem>
							<asp:ListItem Value="16">Tỉ giá nhập vào phải là kiểu số nguyên dương!</asp:ListItem>
							<asp:ListItem Value="17">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
							<asp:ListItem Value="18">Các trường không được bỏ trống!</asp:ListItem>
							<asp:ListItem Value="19">Tài khoản khách hàng không tồn tại hoặc bị khoá</asp:ListItem>
							<asp:ListItem Value="20">Giao dịch đã được ghi nhận!</asp:ListItem>
							<asp:ListItem Value="21">Giao dịch thất bại!</asp:ListItem>
							<asp:ListItem Value="22">Cập nhật thành công!</asp:ListItem>
							<asp:ListItem Value="23">Cập nhật thất bại!</asp:ListItem>
							<asp:ListItem Value="24">Thanh toán cho danh sách ấn phẩm điện tử sau:</asp:ListItem>
							<asp:ListItem Value="25">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="26">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="27">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="28">Cập nhật khoản thu (phải thu)</asp:ListItem>
							<asp:ListItem Value="29">Xoá khoản thu (phải thu)</asp:ListItem>
							<asp:ListItem Value="30">Ấn OK để khẳng định thao tác xoá!</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>--%>