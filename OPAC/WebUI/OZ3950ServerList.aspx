<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OZ3950ServerList.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OZ3950ServerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
</head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <form id="form1" runat="server">
    <div id="divMain">
        <div class="web-size sort-page ClearFix">
            <div id="dialog-form" title="Danh sách máy chủ">
                <div id="TabbedPanels1" class="TabbedPanels">
                    <%--<h2>Danh sách máy chủ Z39.50</h2>--%>
                    <div class="TabbedPanelsContentGroup">
                    <div class="TabbedPanelsContent">
                        <div class="popup-modul">
                            <h3 class="HeadStyles">Thư viện</h3>
                            <div class="divPage">
                                <ul class="ClearFix">
                                    <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                                </ul>
                            </div>
                            <ul class="list-search">
                                <asp:Literal runat="server" ID="ltrServerList"></asp:Literal>
                            </ul>
                            <div class="divPage">
                                <ul class="ClearFix">
                                    <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
        <div style="display:none">
            <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
             <span id="spRecordItem" runat="server">Mục</span>
            <span id="spRecordTo" runat="server">đến</span>
            <span id="spRecordOf" runat="server">của</span>
            <span id="spPreviousPage" runat="server">Trang trước</span>
            <span id="spNextPage" runat="server">Trang tiếp</span>
            <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
        </div>
    </form>
</body>
</html>
