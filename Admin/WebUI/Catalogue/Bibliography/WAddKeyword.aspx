<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WAddKeyword.aspx.vb" Inherits="eMicLibAdmin.WebUI.Cataloguer.WAddKeyword" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAddKeyword</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script src="../../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Danh mục từ khóa</h1>
                <div class="two-column ClearFix">
                    <%--<div class="span4">
                        <div class="row-detail">
                            <p>Từ khóa</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:TextBox ID="txtKeywordAdd" runat="server"></asp:TextBox>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnAddKeyword" CssClass="form-btn" runat="server" Text="Thêm mới" />
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div class="span4">
                        <div class="row-detail">
                            <p>Tìm kiếm</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:TextBox ID="txtKeywordSearch" runat="server"></asp:TextBox>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnSearchKeyword" CssClass="form-btn" runat="server" Text="Tìm kiếm" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
            <div style="clear:left;"></div>
            <div class="input-control">
                <div class="table-form">
                    <asp:GridView ID="dtgPolicy" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="100">
                        <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                                <HeaderStyle Width="5%"/>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Từ khóa">
                                <HeaderStyle Width="85%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblKeyWord" Text='<%# Eval("DisplayEntry")%>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hidID" Value='<%# Eval("ID")%>' runat="server" />
                                    <asp:TextBox ID="txtKeywordModify" Text='<%# Eval("DisplayEntry")%>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="#" onclick="ClickKeyword('<%# Eval("ID")%>','<%# Eval("DisplayEntry")%>')">
                                        <img src="../../images/002_007.png" alt="chọn" />
                                    </a>
                                </ItemTemplate>
                                <EditItemTemplate>

                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" ShowCancelButton="true"
                                    UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                                <HeaderStyle Width="10%" />
                            </asp:CommandField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div> 
            </div>
        </div>
    </form>
    
    <script type="text/javascript">
        function ClickKeyword(intKeywordID,strDisplayEntry)
        {
            location.href = "WAddKeyword.aspx?intKeywordID=" + intKeywordID + "&strDisplayEntry=" + strDisplayEntry;
            
        }
    </script>
</body>
</html>
