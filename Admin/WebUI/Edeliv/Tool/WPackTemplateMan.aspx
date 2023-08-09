<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WPackTemplateMan"
    CodeFile="WPackTemplateMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPackTemplateMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtTitle.focus()">
  
    <form id="Form1" method="post" runat="server">
      <div id="divBody">
        <h1 class="main-head-form">
            <asp:Label ID="lbCaption" runat="server" CssClass="lbPageTitle" Width="100%">Soạn mẫu nhãn đóng gói</asp:Label></h1>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbFormat" runat="server"><U>K</U>huôn dạng: </asp:Label></p>
                    <div class="input-control">
                        
                              <div class="dropdown-form">
                            <asp:DropDownList ID="ddlFormatName" runat="server" CssClass="lbdropdrownlist" Width="300px">
                            </asp:DropDownList>
                            </div>
                      
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbNFormat" runat="server"><U>T</U>ên khuôn dạng:</asp:Label><asp:Label
                            ID="lblMan" runat="server" ToolTip="Trường bắt buộc" ForeColor="Red" Font-Bold="True">(*)</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTitle" runat="server" Width="424px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblOption" runat="server">Chọn thông tin :</asp:Label></p>
                    <p>
                        <asp:Label ID="lbLocation" runat="server">Nơ<U>i</U> nhận:</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="lbdropdrownlist" Width="150px">
                                <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVNAME$&gt;">Tên đơn vị</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ(dòng 1)</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ(dòng 2)</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành Phố</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCODE$&gt;">Mã bưu điện</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbRequest" runat="server"><U>Y</U>êu cầu :</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlRequestInfo" AccessKey="Y" runat="server" CssClass="lbdropdrownlist"
                                Width="150px">
                                <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                                <asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Ngày gửi </asp:ListItem>
                                <asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày hết hạn </asp:ListItem>
                                <asp:ListItem Value="&lt;$NAME$&gt;">Người đặt</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbOther" runat="server">K<U>h</U>ác :</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlOther" AccessKey="h" runat="server" CssClass="lbdropdrownlist"
                                Width="150px">
                                <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                                <asp:ListItem Value="&lt;$DD$&gt;">Ngày </asp:ListItem>
                                <asp:ListItem Value="&lt;$MM$&gt;">Tháng</asp:ListItem>
                                <asp:ListItem Value="&lt;$YYYY$&gt;">Năm</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbContent" runat="server"><U>N</U>ội dung khuôn dạng:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtContents" runat="server" Width="600px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            	<asp:button id="btnUpdate" CssClass="form-btn" Runat="server" Text="Cập nhật(u)"></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnPreview" CssClass="form-btn" runat="server" Text="Xem thử(p)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Đặt lại(r)"></asp:Button>
                        </div>
                        <div class="button-form">
                           <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xóa(d)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    
    
    
    
    
    
    
    

    <table cellspacing="0" cellpadding="3" width="100%" border="0">
        <tr>
            <td valign="top" align="right" width="20%">
                <%--<asp:label id="lbFormat" Runat="server"><U>K</U>huôn dạng: </asp:label>--%>
            </td>
            <td valign="top" align="left">
                <%--<asp:dropdownlist id="ddlFormatName" Runat="server" CssClass="lbdropdrownlist" Width="300px"></asp:dropdownlist>--%>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" width="20%">
                <%--<asp:label id="lbNFormat" Runat="server"><U>T</U>ên khuôn dạng:</asp:label>--%>
            </td>
            <td valign="top" align="left">
                <%--<asp:TextBox id="txtTitle" runat="server" Width="424px"></asp:TextBox>--%>&nbsp;
                <%--<asp:label id="lblMan" Runat="server" ToolTip="Trường bắt buộc" ForeColor="Red" Font-Bold="True">(*)</asp:label>--%>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" width="20%">
                <%--<asp:label id="lbContent" Runat="server"><U>N</U>ội dung khuôn dạng:</asp:label>--%>
            </td>
            <td valign="top" align="left">
                <%--<asp:textbox id="txtContents" Runat="server" Width="600px" Rows="10" TextMode="MultiLine"></asp:textbox>--%>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" width="20%">
                <%--<asp:label id="lblOption" Runat="server">Chọn thông tin :</asp:label>--%>
            </td>
            <td valign="top" align="left">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td valign="top" align="left">
                            <%--<asp:label id="lbLocation" Runat="server">Nơ<U>i</U> nhận:</asp:label>--%>
                        </td>
                        <td valign="top" align="left">
                            <%--<asp:label id="lbRequest" Runat="server"><U>Y</U>êu cầu :</asp:label>--%>
                        </td>
                        <td valign="top" align="left">
                            <%--<asp:label id="lbOther" Runat="server">K<U>h</U>ác :</asp:label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px" valign="top" align="left">
                            <%--<asp:dropdownlist id="ddlLocation" Runat="server" CssClass="lbdropdrownlist" Width="150px">
										<asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVNAME$&gt;">Tên đơn vị</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ(dòng 1)</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ(dòng 2)</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành Phố</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
										<asp:ListItem Value="&lt;$DELIVCODE$&gt;">Mã bưu điện</asp:ListItem>
									</asp:dropdownlist>--%>
                        </td>
                        <td style="height: 22px" valign="top" align="left">
                            <%--<asp:dropdownlist id="ddlRequestInfo" accessKey="Y" Runat="server" CssClass="lbdropdrownlist" Width="150px">
										<asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
										<asp:ListItem VALUE="&lt;$CREATEDDATE$&gt;">Ngày gửi </asp:ListItem>
										<asp:ListItem VALUE="&lt;$EXPIREDDATE$&gt;">Ngày hết hạn </asp:ListItem>
										<asp:ListItem VALUE="&lt;$NAME$&gt;">Người đặt</asp:ListItem>
									</asp:dropdownlist>--%>
                        </td>
                        <td style="height: 22px" valign="top" align="left">
                            <%--<asp:dropdownlist id="ddlOther" accessKey="h" Runat="server" CssClass="lbdropdrownlist" Width="150px">
										<asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
										<asp:ListItem VALUE="&lt;$DD$&gt;">Ngày </asp:ListItem>
										<asp:ListItem VALUE="&lt;$MM$&gt;">Tháng</asp:ListItem>
										<asp:ListItem VALUE="&lt;$YYYY$&gt;">Năm</asp:ListItem>
									</asp:dropdownlist>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="lbControlBar">
            <td width="20%">
            </td>
            <td>
                <%--	<asp:button id="btnUpdate" Runat="server" Text="Cập nhật(u)"></asp:button>--%>&nbsp;<%--<asp:Button
                    ID="btnPreview" runat="server" CssClass="lbButton" Text="Xem thử(p)"></asp:Button>--%>&nbsp;<%--<asp:Button
                        ID="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)"></asp:Button>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <%-- <asp:Button ID="btnDelete" runat="server" Text="Xóa(d)"></asp:Button>--%>
            </td>
        </tr>
    </table>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Nhấn OK để khẳng định việc xoá mẫu này!</asp:ListItem>
        <asp:ListItem Value="3">Bạn chưa nhập tên khuôn dạng!</asp:ListItem>
        <asp:ListItem Value="4">Cập nhật khuôn dạng thành công!</asp:ListItem>
        <asp:ListItem Value="5">---------- Tạo mới ----------</asp:ListItem>
        <asp:ListItem Value="6">Bạn chưa chọn khuôn dạng cần làm việc!</asp:ListItem>
    </asp:DropDownList>
    <input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
    <asp:Label ID="lblInforLocationText" runat="server" Visible="False">Chọn thông tin, Tên đơn vị, Địa chỉ(dòng 1), Địa chỉ(dòng 2), Hộp thư, Thành Phố, Khu vực, Quốc gia, Mã bưu điện</asp:Label>
    <asp:Label ID="lblInforLocationValue" runat="server" Visible="False">&lt;$0$&gt;, &lt;$DELIVNAME$&gt;, &lt;$DELIVXADDR$&gt;, &lt;$DELIVSTREET$&gt;, &lt;$DELIVBOX$&gt;, &lt;$DELIVCITY$&gt;, &lt;$DELIVREGION$&gt;, &lt;$DELIVCOUNTRY$&gt;, &lt;$DELIVCODE$&gt;</asp:Label>
    <asp:Label ID="lblInfoRequestText" runat="server" Visible="False">Chọn thông tin, Ngày gửi, Ngày hết hạn, Người đặt</asp:Label><asp:Label
        ID="lblInfoRequestValue" runat="server" Visible="False">&lt;$0$&gt;, &lt;$CREATEDDATE$&gt;, &lt;$EXPIREDDATE$&gt;, &lt;$NAME$&gt;</asp:Label>
    <asp:Label ID="lblInfoOtherText" runat="server" Visible="False">Chọn thông tin, Ngày, Tháng, Năm</asp:Label><asp:Label
        ID="lblInfoOtherValue" runat="server" Visible="False">&lt;$0$&gt;, &lt;$DD$&gt;, &lt;$MM$&gt;, &lt;$YYYY$&gt;</asp:Label></form>
</body>
</html>
