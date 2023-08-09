<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCataloguePropertyPopup.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataloguePropertyPopup" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
    <head>
        <title></title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    </head>
    <body leftmargin="0" topmargin="0">
        <form id="form1" runat="server">
            <div id="divBody">
                <div class="main-body">
                    <h2 class="main-head-form">Xem bản ghi dữ liệu biên mục</h2>
                    <div class="irow-detail">
                        <div class="table-form">
                            <asp:DataGrid ID="grdProperty" CssClass="table-control" runat="server" AutoGenerateColumns="False" Width="100%">
                                <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                                <ItemStyle CssClass="lbGridCell"></ItemStyle>
                                <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Nh&#227;n">
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkFieldCode" runat="server" CssClass="lbLinkFunction">
											        <%#DataBinder.Eval(Container.dataItem,"FieldCode")%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Ind" HeaderText="Chỉ thị">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Content" HeaderText="Nội dung trường">
                                        <HeaderStyle HorizontalAlign="Center" Width="90%"></HeaderStyle>
                                    </asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
