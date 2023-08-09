<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRefuseTemplateMan"
    EnableViewState="False" EnableViewStateMac="False" CodeFile="WRefuseTemplateMan.aspx.vb"
    CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WRefuseTemplateMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" onload="document.forms[0].txtTitle.focus()">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <h1 class="main-head-form">
            <asp:Label ID="lblMainTitle" Width="100%" runat="server" CssClass="lbPagetitle">Soạn mẫu thư từ chối yêu cầu đặt mua </asp:Label></h1>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbFormat" runat="server"><U>K</U>huôn dạng: </asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlFormatName" Width="300px" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbNFormat" runat="server"><U>T</U>ên khuôn dạng:</asp:Label><asp:Label
                            ID="lblMan" runat="server" Font-Bold="True" ForeColor="Red" CssClass="text-input" ToolTip="Trường bắt buộc">(*)</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTitle" Width="500" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblOption2" runat="server">Chọn thông tin:</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlFootRequestInfo" Width="150px" runat="server">
                                <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                                <asp:ListItem Value="&lt;$NAME$&gt;">Người đặt </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1) </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2) </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực </asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia </asp:ListItem>
                                <asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ </asp:ListItem>
                                <asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Mô tả tài liệu đặt mua </asp:ListItem>
                                <asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày đặt </asp:ListItem>
                                <asp:ListItem Value="&lt;$DD$&gt;">Ngày </asp:ListItem>
                                <asp:ListItem Value="&lt;$MM$&gt;">Tháng </asp:ListItem>
                                <asp:ListItem Value="&lt;$YYYY$&gt;">Năm </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        Nội dung :</p>
                    <div class="input-control">
                        <div class="input-form ">
                             <asp:TextBox ID="txtHeader" CssClass="text-input" TabIndex="3" Width="100%" runat="server" Height="60px"
                    Columns="100" TextMode="MultiLine" Wrap="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h1 class="main-group-form">
            Những thông tin có khuôn và định dạng của khuôn</h1>
        <div class="two-column ClearFix">
            <div class="two-column-form ClearFix">
                <div class="span45">
                    <div class="row-detail">
                        <p> <asp:Label ID="lblAllCollums" runat="server">Cột <U>k</U>hông hiển thị</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                 <asp:ListBox ID="lsbAllCollums"  CssClass="area-input" runat="server" Rows="6" SelectionMode="Multiple">
                            </asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span1">
                    <div class="input-control button-list">
                        <div class="button-control">
                            <div class="button-form">
                                  <asp:Button ID="btnAdd" CssClass="btn-icon" runat="server" Text=">>"></asp:Button>
                           
                               <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                            </div>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnRemove" CssClass="btn-icon" runat="server" Text="<<"></asp:Button>
                                <div class="icon-btn">
                                    <span class="icon-arrow-left"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span45">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblCollum" Width="100%" runat="server">Cột <u>h</u>iển thị</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                 <asp:ListBox ID="lsbCollum" CssClass="area-input"  runat="server" Rows="6" SelectionMode="Multiple">
                            </asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="two-column-form ClearFix">
                 <div class="unit-4">
                    <div class="row-detail">
                        <p>
                             <asp:Label ID="lblCollumCaption" runat="server"><u>T</u>iêu đồ cột</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                     <asp:TextBox ID="txtCollumCaption" TabIndex="8" CssClass="area-input" runat="server" Columns="20"
                                TextMode="MultiLine" Wrap="False" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                           <asp:Label ID="lblCollumWidth" runat="server">Độ <u>r</u>ộng</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                  <asp:TextBox ID="txtCollumWidth" CssClass="area-input" runat="server" Columns="10" TextMode="MultiLine"
                                Wrap="False" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                             <asp:Label ID="lblAlign" runat="server">Căn <u>l</u>ề</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                  <asp:TextBox ID="txtAlign" CssClass="area-input" runat="server" Columns="10" TextMode="MultiLine"
                                Wrap="False" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblFormat" runat="server">Định dạng</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                 <asp:TextBox ID="txtFormat" CssClass="area-input" runat="server" Columns="10" TextMode="MultiLine"
                                Wrap="False" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <p>
                   <asp:Label ID="lblOption" runat="server">Chọn thông tin: </asp:Label></p>
            <div class="input-control">
                <div class="dropdown-form">
                   <asp:DropDownList
                    ID="ddlHeadRequestInfo1" Width="150px" runat="server">
                    <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                    <asp:ListItem Value="&lt;$NAME$&gt;">Người đặt </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1) </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2) </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực </asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia </asp:ListItem>
                    <asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ </asp:ListItem>
                    <asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Mô tả tài liệu đặt mua </asp:ListItem>
                    <asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày đặt </asp:ListItem>
                    <asp:ListItem Value="&lt;$DD$&gt;">Ngày </asp:ListItem>
                    <asp:ListItem Value="&lt;$MM$&gt;">Tháng </asp:ListItem>
                    <asp:ListItem Value="&lt;$YYYY$&gt;">Năm </asp:ListItem>
                </asp:DropDownList>
            
                </div>
            </div>
        </div>
        <div class="row-detail">
            <p>
                Cuối đơn :</p>
            <div class="input-control">
                <div class="input-form ">
                       <asp:TextBox ID="txtFooter" CssClass="text-input" TabIndex="10" Width="100%" runat="server" Height="60px"
                    Columns="100" TextMode="MultiLine" Wrap="true"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div class="button-control" style="text-align: center;">
                <div class="button-form">
                     <asp:Button ID="btnUpdate" runat="server" CssClass="form-btn" Text="Cập nhật(u)" Width="98px"></asp:Button>
               
                </div>
                <div class="button-form">
                    <asp:Button ID="btnPreview" runat="server" CssClass="form-btn" Text="Xem trước(p)" Width="100px"></asp:Button>
                  
                </div>
                <div class="button-form">
                    <asp:Button ID="btnDelete" runat="server" CssClass="form-btn" Text="Xóa(d)" Width="68px"></asp:Button>
                
                </div>
            </div>
        </div>
    </div>
    <table cellspacing="0" cellpadding="1" width="100%" border="0">
        <tr>
            <td valign="top" colspan="2">
                <%--<asp:label id="lblMainTitle" Width="100%" Runat="server" cssclass="lbPagetitle">Soạn mẫu thư từ chối yêu cầu đặt mua </asp:label>--%>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" width="20%">
                <%--<asp:label id="lbFormat" Runat="server"><U>K</U>huôn dạng: </asp:label>--%>
            </td>
            <td valign="top">
                <%--<asp:dropdownlist id="ddlFormatName" Width="300px" Runat="server"></asp:dropdownlist>--%>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <%--<asp:label id="lbNFormat" Runat="server"><U>T</U>ên khuôn dạng:</asp:label>--%>
            </td>
            <td valign="top">
                <%--<asp:textbox id="txtTitle" Width="500" Runat="server"></asp:textbox>--%>&nbsp;<%--<asp:label id="lblMan" Runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:label>--%>
            </td>
        </tr>
        <tr class="lbGroupTitle">
            <td colspan="2">
                <%--<asp:label id="lblLabel1" Runat="server" cssClass="lbGroupTitle">P<u>h</u>ần đầu thư: </asp:label>--%>
            </td>
        </tr>

        <tr class="lbGroupTitle">
            <td colspan="2">
                <asp:Label ID="lblIncudeCollums" runat="server" CssClass="lbGroupTitle"> Phần giữa thư gồm các cột:</asp:Label>
            </td>
        </tr>
        
        
        <tr class="lbGroupTitle">
            <td colspan="2">
                <asp:Label ID="lblFooter" Width="100%" runat="server" CssClass="lbGroupTitle"> Phần cuối thư:</asp:Label>
            </td>
        </tr>
        
       
    </table>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Bạn chưa nhập tên khuôn dạng!</asp:ListItem>
        <asp:ListItem Value="3">---------- Tạo mới ----------</asp:ListItem>
        <asp:ListItem Value="4">Cập nhật khuôn dạng thành công!</asp:ListItem>
        <asp:ListItem Value="5">Nhấn OK để khẳng định việc xoá mẫu này!</asp:ListItem>
        <asp:ListItem Value="6">Bạn chưa chọn khuôn dạng cần làm việc!</asp:ListItem>
        <asp:ListItem Value="7">Xoá khuôn dạng thành công!</asp:ListItem>
    </asp:DropDownList>
    <asp:ListBox ID="lsbTemp" Width="0px" runat="server" Height="0px" Enabled="False">
    </asp:ListBox>
    <input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
    <input id="txtCollum" type="hidden" name="txtCollum" runat="server">
    <asp:Label ID="lblInformationText" Width="638px" runat="server" Visible="False">Chọn thông tin,Người đặt, Đơn vị, Địa chỉ (1), Địa chỉ (2), Hộp thư, Thành phố, Khu vực, Quốc gia, Số tiền còn nợ, Mô tả tài liệu đặt mua, Ngày đặt, Ngày, Tháng, Năm</asp:Label>
    <asp:Label ID="lblInformationValue" runat="server" Visible="False">&lt;$0$&gt;, &lt;$NAME$&gt;,&nbsp; &lt;$DELIVNAME$&gt;, &lt;$DELIVXADDR$&gt;, &lt;$DELIVSTREET$&gt;, &lt;$DELIVBOX$&gt;, &lt;$DELIVCITY$&gt;, &lt;$DELIVREGION$&gt;, &lt;$DELIVCOUNTRY$&gt;, &lt;$DEBT$&gt;, &lt;$CREATEDDATE$&gt;,&lt;$EXPIREDDATE$&gt;, &lt;$DD$&gt;, &lt;$MM$&gt;,&lt;$YYYY$&gt;</asp:Label>
    <asp:Label ID="lblCollumText" runat="server" Visible="False">STT, Mô tả tài liệu, Kích cỡ, Giá, Đơn vị tiền tệ</asp:Label>
    <asp:Label ID="lblCollumValue" runat="server" Visible="False">&lt;$NO$&gt;, &lt;$NOTE$&gt;,&lt;$FILESIZE$&gt;, &lt;$PRICE$&gt;, &lt;$CURRENCY$&gt;</asp:Label>
    <input id="Hidden1" type="hidden" value="0" name="txtTemplate" runat="server">
    <input id="Hidden2" type="hidden" name="txtCollum" runat="server">
    <input id="hdCollumCaptionText" type="hidden" name="hdCollumCaptionText" runat="server">
    <input id="hdMax" type="hidden" name="hdMax" runat="server">
    </form>
</body>
</html>
