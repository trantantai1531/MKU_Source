<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckPatronCode" CodeFile="WCheckPatronCode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckPatronCode</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .lbGridHeader {
            background: #cccccc none repeat scroll 0 0;
            color: #2061a3;
            text-align: center;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .main-group-form
        {
            margin:0; padding:3px 0px 3px 5px; margin-bottom:5px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr class="lblPageTitle">
                <td colspan="2">
                    <asp:Label ID="lblPageTitle" runat="server" Width="100%" CssClass="lbPageTitle">Kiểm tra bạn đọc</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" height="5"></td>
            </tr>
            <tr valign="top">
                <td width="160" align="center">
                    <img alt="" id="imgPatronImage" style="height:4cm" runat="server" src="../Images/Card/Empty.gif" border="0">
                </td>
                <td align="left">
                    <ul>
                        <li><asp:Label ID="lblFullName" runat="server" CssClass="lbFunctionTitle"></asp:Label>&nbsp;&nbsp;<asp:HyperLink ID="lnkDetailInfor" runat="server">Thông tin chi tiết</asp:HyperLink></li>
                        <li>Ngày sinh: <asp:Label ID="lblDOB" runat="server"></asp:Label></li>
                        <li>Ngày hiệu lực: <asp:Label ID="lblValidDate" runat="server"></asp:Label></li>
                        <li>Ngày hết hạn thẻ: <asp:Label ID="lblExpiredDate" runat="server"></asp:Label></li>
                        <li>Nhóm: <asp:Label ID="lblPatronGroup" runat="server"></asp:Label></li>
                        <li>Nợ: <asp:Label ID="lblDebt" runat="server"></asp:Label> <asp:HyperLink ID="lnkRenew" runat="server">&nbsp;Gia hạn thẻ</asp:HyperLink><br></li>
                        <li>Ghi chú: <asp:Label ID="lblNote" runat="server"></asp:Label>&nbsp;&nbsp;</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
        <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr align="center" class="lbGridHeader">
                <td class="lbSubFormTitle" align="center" width="30%">
                    <asp:Label ID="lblLoanHome" CssClass="lbSubFormTitle" runat="server">Mượn về nhà</asp:Label>
                </td>
                <td class="lbSubFormTitle" align="center" width="30%">
                    <asp:Label ID="lblLoanLib" CssClass="lbSubFormTitle" runat="server">Mượn tại chỗ</asp:Label>
                </td>
                <td class="lbSubFormTitle" align="center" width="40%">
                    <asp:Label ID="lblLoanQuotaOut" CssClass="lbSubFormTitle" runat="server">Mượn ngoài hạn ngạch</asp:Label>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <ul>
                        <li>Hạn ngạch: <asp:Label ID="lblQuotaHome" runat="server"></asp:Label></li>
                        <li>Đang mượn: <asp:Label ID="lblOnLoanHome" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOnLoanHome" runat="server">Chi tiết</asp:HyperLink></li>
                        <li>Quá hạn: <asp:Label ID="lblOverdueHome" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOverdueHome" runat="server">Chi tiết</asp:HyperLink></li>
                        <li>Còn được mượn: <asp:Label ID="lblRemainHome" runat="server"></asp:Label></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li>Hạn ngạch: <asp:Label ID="lblQuotaLib" runat="server"></asp:Label></li>
                        <li>Đang mượn: <asp:Label ID="lblOnLoanLib" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOnLoanLib" runat="server">Chi tiết</asp:HyperLink></li>
                        <li>Quá hạn: <asp:Label ID="lblOverdueLib" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOverdueLib" runat="server">Chi tiết</asp:HyperLink></li>
                        <li>Còn được mượn: <asp:Label ID="lblRemainLib" runat="server"></asp:Label></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li>Đang mượn: <asp:Label ID="lblOnLoanQuotaOut" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOnLoanQuotaOut" runat="server">Chi tiết</asp:HyperLink></li>
                        <li>Quá hạn: <asp:Label ID="lblOverdueQuotaOut" runat="server"></asp:Label>&nbsp;<asp:HyperLink ID="lnkOverdueQuotaOut" runat="server">Chi tiết</asp:HyperLink></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="display:none;">
                    Các kho bạn đọc có quyền mượn: <asp:Label ID="lblLocation" runat="server" Width="100%" CssClass="lbPageTitle"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellSpacing="0" cellPadding="2" width="100%" border="0">
			<tr>
				<td><asp:label runat="server" CssClass="main-group-form" BackColor="Silver" width="100%">Ấn phẩm đang mượn</asp:label></td>
			</tr>
			<tr>
				<td>
					<asp:datagrid id="dtgResult" runat="server" Width="100%" AllowCustomPaging="False" HeaderStyle-HorizontalAlign="Center"
						AutoGenerateColumns="False" ItemStyle-VerticalAlign="Top">
						<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
						<Columns>
							<asp:BoundColumn DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-Width="12%"></asp:BoundColumn>
							<asp:BoundColumn DataField="Title" HeaderText="Nhan đề" ReadOnly="true" ItemStyle-Wrap="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="CHECKOUTDATE" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="Ngày mượn" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
							<asp:BoundColumn DataField="DUEDATE" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" HeaderText="Ngày trả" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="RenewCount" HeaderText="Gia hạn" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
						    <asp:TemplateColumn HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%">
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckOutDate" Text='<%# DataBinder.Eval(Container.DataItem, "Note")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hidLoanID" Value='<%# DataBinder.Eval(Container.DataItem, "ID")%>' runat="server"/>
                                    <asp:TextBox ID="txtLoanNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
						    </asp:TemplateColumn>
						    <asp:EditCommandColumn ItemStyle-Width="5%" ButtonType="LinkButton" HeaderText="Sửa" UpdateText="&lt;img src=&quot;../images/update.gif&quot; border=&quot;0&quot;&gt;"
                                    CancelText="&lt;img src=&quot;../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="lbLinkFunction"></ItemStyle>
                                </asp:EditCommandColumn>
                            <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
						</Columns>
					</asp:datagrid>
				</td>
			</tr>
		</table>
		<asp:DropDownList ID="ddlLabelLoanDetail" Runat="server" Visible="False" Width="0">
			<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
			<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			<asp:ListItem Value="2">về nhà</asp:ListItem>
			<asp:ListItem Value="3">tại chỗ</asp:ListItem>
			<asp:ListItem Value="4">ngoài hạn ngạch</asp:ListItem>
		</asp:DropDownList>
        <asp:Label ID="lblMsg1" runat="server" ForeColor="Red" Visible="False">Số thẻ không tồn tại</asp:Label>
        <asp:Label ID="lblMsg2" runat="server" ForeColor="Red" Visible="False">Thẻ đã hết hạn</asp:Label>
        <asp:Label ID="lblMsg3" runat="server" ForeColor="Red" Visible="False">Hết hạn ngạch</asp:Label>
        <asp:Label ID="lblMsg4" runat="server" ForeColor="Red" Visible="False">Thẻ đang bị khoá</asp:Label>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Quá hạn: </asp:ListItem>
            <asp:ListItem Value="3">(d)</asp:ListItem>
            <asp:ListItem Value="4">Hạn trả mở</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
