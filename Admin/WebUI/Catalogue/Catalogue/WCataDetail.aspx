<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataDetail" CodeFile="WCataDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCataDetail</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,39');">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="two-column-form">
                <h1 class="main-head-form">Hàng đợi chờ biên mục chi tiết</h1>
                <div class="row-detail">
                    <p>Thời gian nhập :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlInputTime" runat="server" Width="" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="grdFItem" CssClass="table-control" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True">
                            <Columns>
                                <asp:TemplateColumn HeaderText="Bi&#234;n mục">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRadio" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoChoice") %>
                                            <label for="rdoChoice"></label>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetail.aspx?ModeSort=0'&gt;Nhan đề&lt;/A&gt;">
                                    <HeaderStyle ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkContent" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Content")%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Code" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetail.aspx?ModeSort=1'&gt;M&#227; t&#224;i liệu&lt;/A&gt;">
                                    <HeaderStyle ></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Reviewer" HeaderText="Người bi&#234;n mục">
                                    <HeaderStyle ></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CREATEDDATE" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetail.aspx?ModeSort=2'&gt;Ng&#224;y nhập&lt;/A&gt;">
                                    <HeaderStyle ></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Reviewed" HeaderText="Reviewed"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" ID="lblCheckBox" runat="server">    </input>
											<%# DataBinder.Eval(Container.dataItem,"chkChoice") %>
                                            <label for="Choice"></label>
                                    
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
         <%--   <div class="row-detail">
                <div class="button-control inline-box">
                    <div class="button-form">
                        <input type="button" value="Cập nhật" class="form-btn" />
                    </div>
                    <div class="button-form">
                        <input type="button" value="Đóng" class="form-btn" />
                    </div>
                </div>
            </div>--%>
        </div>
        <input id="hidColSort" type="hidden" name="hidColSort" runat="server"/>&nbsp;
        <input id="hidIDs" type="hidden" name="hidIDs" runat="server"/>
        <input id="hidID" type="hidden" name="hidID" runat="server"/>
        <asp:DropDownList ID="ddlLabel" Width="0" Height="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Tất cả: </asp:ListItem>
            <asp:ListItem Value="1">Tháng: </asp:ListItem>
            <asp:ListItem Value="2">-----</asp:ListItem>
            <asp:ListItem Value="3">Chưa biên mục chi tiết: </asp:ListItem>
            <asp:ListItem Value="4">Đã biên mục chi tiết: </asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Đang tải dữ liệu. Xin vui lòng chờ trong chốc lát...</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            ReCheckbox();
        </script>
    </form>
</body>
</html>
