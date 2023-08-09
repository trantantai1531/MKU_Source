<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WSearchItemCode" CodeFile="WSearchItemCode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSearchItemCode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="document.forms[0].txtTitle.focus()"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="2" width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="center" colSpan="4"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle main-head-form">Tìm kiếm biểu ghi biên mục</asp:label></td>
				</tr>
				<tr align="center">
					<td align="right" width="14%"><asp:label id="lblTitle" runat="server" CssClass="lbLabel"><u>N</u>han đề chính:</asp:label></td>
					<td align="left" width="30%"><asp:textbox id="txtTitle" runat="server" CssClass="lbTextbox" Width="216px"></asp:textbox></td>
					<TD align="right" width="13%"><asp:label id="lblAuthor" runat="server" CssClass="lbLabel"><u>T</u>ác giả:</asp:label></TD>
					<TD align="left" width="43%"><asp:textbox id="txtAuthor" runat="server" CssClass="lbTextbox" Width="262px"></asp:textbox></TD>
				</tr>
				<TR align="center">
					<TD align="right" width="14%"><asp:label id="lblCopyNumber" runat="server" CssClass="lbLabel">ĐK<u>C</u>B:</asp:label></TD>
					<TD align="left" width="30%"><asp:textbox id="txtCopyNumber" runat="server" CssClass="lbTextbox" Width="216px"></asp:textbox></TD>
					<TD align="right" width="13%"><asp:label id="lblPublisher" runat="server" CssClass="lbLabel">Nhà xuất <u>b</u>ản:</asp:label></TD>
					<TD align="left" width="43%"><asp:textbox id="txtPublisher" runat="server" CssClass="lbTextbox" Width="262px"></asp:textbox></TD>
				</TR>
				<TR align="center">
					<TD align="right" width="14%"><asp:label id="lblISBN" runat="server" CssClass="lbLabel"><u>I</u>SBN:</asp:label></TD>
					<TD align="left" width="30%"><asp:textbox id="txtISBN" runat="server" CssClass="lbTextbox" Width="216px"></asp:textbox></TD>
					<TD align="right" width="13%"><asp:label id="lblYear" runat="server" CssClass="lbLabel">Năm <u>x</u>uất bản:</asp:label></TD>
					<TD align="left" width="43%"><asp:textbox id="txtYear" runat="server" CssClass="lbTextbox" Width="262px"></asp:textbox></TD>
				</TR>
                <tr>
                    <TD align="right" width="14%"><asp:label id="lblItemCode" runat="server" CssClass="lbLabel"><u>M</u>ã tài liệu:</asp:label></TD>
					<TD align="left" width="30%"><asp:textbox id="txtItemCode" runat="server" CssClass="lbTextbox" Width="216px"></asp:textbox></TD>
                    <TD align="right" width="14%"><asp:label id="lblItemInfor" runat="server" CssClass="lbLabel"><u>T</u>hông tin bản ghi:</asp:label></TD>
					<TD align="left" width="30%">
                        <asp:DropDownList runat="server" ID="ddlItemInfor">
                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                            <asp:ListItem Value="1">Bản ghi chưa xếp giá</asp:ListItem>
                        </asp:DropDownList>
					</TD>
                </tr>
                <tr>
                    <td align="right" width="14%">
                        <asp:label id="lblItemType" runat="server" CssClass="lbLabel"><u>D</u>ạng tài liệu:</asp:label>
                    </td>
                    <td align="left" width="30%">
                        <asp:dropdownlist id="ddlItemType" runat="server" Width="216px" Height="32px" EnableViewState="true">
                        </asp:dropdownlist>
                    </td>
                    <td>&nbsp;</td>
                    <td align="left">
                        <asp:button id="btnSearch" runat="server" CssClass="lbButton" Text="Tìm (f)"></asp:button>&nbsp;
                        <asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)"></asp:button>&nbsp;
                        <asp:button id="btnExport" runat="server" CssClass="lbButton" Text="Xuất file(x)"></asp:button>
                    </td>
                </tr>
			</table>
			<table width="100%" border="0">
				<TR>
					<TD align="center"><asp:label id="lblNotFound" runat="server" Visible="False">Không tìm thấy bản ghi biên mục nào thoả mãn điều kiện tìm kiếm</asp:label><asp:label id="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:label>&nbsp;
						<asp:label id="lblResult" runat="server" Visible="False" cssClass="lbAmount"></asp:label>&nbsp;
						<asp:label id="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:label></TD>
				</TR>
				<TR>
					<td align="center">
					    <div class="table-form">
					    <asp:datagrid id="DgrResult" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
							AllowPaging="True">
							<Columns>
								<asp:TemplateColumn HeaderText="M&#227; t&#224;i liệu">
									<ItemTemplate>
										<asp:HyperLink Runat="server" ID="lnkItemCode" CssClass="lbLinkFunction">
											<%# DataBinder.Eval(Container, "DataItem.Code") %>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="TITLE" HeaderText="Nhan đề">
									<HeaderStyle Width="80%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="LblID" text='<%# DataBinder.Eval(Container.dataItem,"ItemID") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                         </div>
					</td>
				</TR>
			</table>
		    <input id="hidIDs" type="hidden" name="hidIDs" runat="server"/>
		    <asp:dropdownlist id="ddlLabel" Width="0" Visible="False" Height="0" Runat="server">
				<asp:ListItem Value="0">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">bản ghi</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
                </asp:dropdownlist>
			</form>
	</body>
</HTML>
