<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OPersonal.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OPersonal" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <%--<link href="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%--<script type="text/javascript" src="/Resources/metro-4.2.39/js/metro.min.js"></script>
    <link rel="stylesheet" href="/Resources/metro-4.2.39/css/metro.min.css">
    <link rel="stylesheet" href="/Resources/metro-4.2.39/css/metro-colors.min.css">
    <link rel="stylesheet" href="/Resources/metro-4.2.39/css/metro-rtl.min.css">
    <link rel="stylesheet" href="/Resources/metro-4.2.39/css/metro-icons.min.css">--%>
    <%--<script src="JS/OPatronInfo.js" type="text/javascript"></script>--%>
    
    <style type="text/css">
        .head-tab{
            /*font-family: HeadFont;*/
            color:#1ba1e2;
            border-bottom: solid 2px #1ba1e2;
            /*font-weight: normal;
            font-size: 1.17em;
            border-collapse: separate;*/
        }
    </style>
    <style type="text/css">
        a#btnSearch:hover {
            background: #1D24FB none repeat scroll 0 0 !important;
            color: white !important;
            border-radius: 5px;
            border: 1px solid #024385;
            box-shadow: none;
            text-decoration:none;
        }
        a#btnSearch {
            background: #aacfea none repeat scroll 0 0;
            border-radius: 5px;
            border: 1px solid #aacfea !important;
            color: #2061a3;
            cursor: pointer;
            display: inline-block;
            padding: 2px 6px 3px 6px;
            vertical-align: top;
            min-width: 45px;
            font-size:15px;
        }
    </style>
    <style type="text/css">
        .table{
            margin:20px auto;
            width:80%;
        }
        .icon-container:hover{
            cursor:pointer;
            background-color:#BEDAEF;
        }
        .icon-container{
            padding: 5px 7px;
            border:1px solid #e0e0e0;
            display:inline;
        }
        .icon-container [class^="mif-"], [class*=" mif-"]
        {
            margin-top:-5px;
        }
        .save-container{
            display: inline-block;
            vertical-align: bottom;
        }
        .first-field-container{
            display:inline-block;
            width:120px;
            text-align: left;
        }
        .second-field-container{
            display:inline-block;
            width:80px;
            text-align: left;
        }
        .third-field-container{
            display:inline-block;
            width:100px;
            text-align: left;
        }
        .colon-container{
            display:inline-block;
            padding-right:5px;
        }
        .colon-container:before{
            content:":";
            font-size: 20px;
            font-weight: bold;
        }
        .content-container{
            display:inline-block;
        }
        .content-edit-container {
            vertical-align: auto;
        }
        .function-container{
            display:none;
        }
        .inline-block{
            display:inline-block;
        }
        .input-container{
            width:auto;
        }
        .btn-hide{
            visibility:hidden;
        }
        .button-control .button-form input, .button-control .button-form a
        {
            padding-top: 7px;
            border:1px solid #1ba1e2 !important;
            color:#000000 !important;
            padding-left:5px;
            padding-right:5px;
        }
        .btn-theme
        {
            background:#1ba1e2 !important;
        }
    </style>
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
<asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" ScriptMode="Release" />
<form id="form1" runat="server">
    <uc2:UHeader ID="UHeader1" runat="server" />
     <div id="divMain">
        <div class="web-size news-page ClearFix">
            <table width="100%" border="0">
                <tr>
                    <td valign="top"><h1 runat="server" id="h1Weblink"><span class="mif-user"></span>Trang cá nhân</h1></td>
                    <td align="right" valign="bottom" style="display:none">
                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <a href="ORegisterBooking.aspx" class="lbButton btn-theme">Đặt phòng</a>
                                </div>
                            </div>
                                                    
                        </div>
                    </td>
                </tr>
            </table>
            
            
            <div class="list-web">
                <asp:Literal runat="server" ID="ltrWeblink"></asp:Literal>
                <table id="tblPatron" width="100%" border="0">
                    <tr>
                        <td valign="top" width="100%" colspan="4">
                            <h3 class="head-title">
                                <asp:label id="Label1" Runat="server" Width="100%" >Thông tin cá nhân</asp:label>
                            </h3>
                            <div class="hid-value"><asp:HiddenField ID="hidDOB" runat="server" /></div>
                            <div class="hid-value"><asp:HiddenField ID="hidTelephone" runat="server" /></div>
                            <div class="hid-value"><asp:HiddenField ID="hidMobile" runat="server" /></div>
                            <div class="hid-value"><asp:HiddenField ID="hidEmail" runat="server" /></div>
                            <div class="hid-value"><asp:HiddenField ID="hidFacebook" runat="server" /></div>

                            <div class="hid-updated-value"><asp:HiddenField ID="hidDOBUpdated" runat="server" /></div>
                            <div class="hid-updated-value"><asp:HiddenField ID="hidTelephoneUpdated" runat="server" /></div>
                            <div class="hid-updated-value"><asp:HiddenField ID="hidMobileUpdated" runat="server" /></div>
                            <div class="hid-updated-value"><asp:HiddenField ID="hidEmailUpdated" runat="server" /></div>
                            <div class="hid-updated-value"><asp:HiddenField ID="hidFacebookUpdated" runat="server" /></div>

                            <div class="three-column">
                                <div class="three-column-form">
						            <img src="/" alt="" id="imgPatron" border="0" runat="server" style="width:75%;"/>
                                </div>
                                <div class="three-column-form">
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Họ và tên</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label ID="lblFullName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Giới tính</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblGender" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Ngày sinh</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>                    
                                                    <div class="content-container">
                                                        <asp:Label CssClass="value-content" id="lblDOB" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Số thẻ</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblCode" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Ngày cấp</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblValidDate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Ngày hết hạn</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblExpiredDate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Nhóm bạn đọc</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblGroupName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Khoa</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblFaculty" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Khóa</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblGrade" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Lớp</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label id="lblClass" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Số điện thoại</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label CssClass="value-content" id="lblTelephone" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Số di động</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label CssClass="value-content" id="lblMobile" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Email</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label CssClass="value-content" id="lblEmail" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <div class="first-field-container">
                                                        <span>Facebook</span>
                                                    </div>
                                                    <div class="colon-container">
                                                    </div>
                                                    <div class="content-container">
                                                        <asp:Label CssClass="value-content" id="lblFacebook" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="three-column-form">
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div class="row-detail">
                                                    <p>Mật khẩu cũ</p>
                                                    <div class="input-control">
                                                        <asp:TextBox ID="txtPasswordOld" TextMode="Password" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row-detail">
                                                    <p>Mật khẩu mới</p>
                                                    <div class="input-control">
                                                        <asp:TextBox ID="txtPasswordNew" TextMode="Password" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row-detail">
                                                    <p>Xác nhận mật khẩu mới</p>
                                                    <div class="input-control">
                                                        <asp:TextBox ID="txtPasswordNewRe" TextMode="Password" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row-detail">
                                                    <div class="button-control">
                                                        <div class="button-form">
                                                            <asp:Button CssClass="lbButton btn-theme" Text="Cập nhật" id="btnUpdate" runat="server"/>
                                                        </div>
                                                    </div>
                                                    
                                                </div>
                                             </td>   
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            
					    </td>
                    </tr>
                    <tr>
                        <td valign="top" width="100%" colspan="4">
                            <h3 class="head-title"><asp:label id="lblReserve" Runat="server" Width="100%" >Ấn phẩm đặt chổ</asp:label></h3>
					    </td>
                    </tr>
                    <tr>
					    <td valign="top" width="100%" colspan="4">
						    <asp:datagrid id="dgrReserve" Runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
							    <Columns>
								    <asp:TemplateColumn>
									    <HeaderStyle Width="2%"></HeaderStyle>
									    <ItemTemplate>
                                            <div class="checkbox-control">
                                                <asp:CheckBox ID="ckbItemID" Runat="server" Text=" "></asp:CheckBox>
                                                <asp:HiddenField ID="txtItemID" Runat ="server" Value='<%# Eval("ID") %>' />
                                            </div>										    
									    </ItemTemplate>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:TemplateColumn>
								    <asp:BoundColumn DataField="STT" HeaderText="STT">
									    <HeaderStyle Width="3%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
									    <HeaderStyle Width="30%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="DateCreate" HeaderText="Ngày đặt chổ">
									    <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="DateExpire" HeaderText="Hết hiệu lực">
									    <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="linkDelete" NavigateUrl='<%# String.Format("OPersonal.aspx?delete=reserve&ID={0}", Eval("ID"))%>' runat="server">Xóa</asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
							    </Columns>
						        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                <ItemStyle BackColor="White" ForeColor="#330099" />
                                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						    </asp:datagrid>                           
					    </td>
				    </tr>
                    <tr>
					    <td valign="top" width="100%" colspan="4">
                            <h3 class="head-title"><asp:label id="lblReservation" Runat="server" Width="100%" >Ấn phẩm đặt mượn</asp:label></h3>
					    </td>
				    </tr>
				    <tr>
					    <td valign="top" width="100%" colspan="4">
						    <asp:datagrid id="dgrReservation" Runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
							    <Columns>
								    <asp:TemplateColumn>
									    <HeaderStyle Width="2%"></HeaderStyle>
									    <ItemTemplate>
                                            <div class="checkbox-control">
                                                <asp:CheckBox ID="ckbItemID" Runat="server" Text=" "></asp:CheckBox>
                                                <asp:HiddenField ID="txtItemID" Runat ="server" Value='<%# Eval("ID") %>' />
                                            </div>										    
									    </ItemTemplate>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
								    </asp:TemplateColumn>
								    <asp:BoundColumn DataField="STT" HeaderText="STT">
									    <HeaderStyle Width="3%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="Title" HeaderText="Nhan đề">
									    <HeaderStyle Width="30%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB">
									    <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="LocationName" HeaderText="Kho">
									    <HeaderStyle Width="20%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="CreateDate" HeaderText="Ngày đặt mượn">
									    <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="ExpiredDate" HeaderText="Hết hiệu lực">
									    <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								    </asp:BoundColumn>
							    </Columns>
						        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                <ItemStyle BackColor="White" ForeColor="#330099" />
                                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						    </asp:datagrid>                           
					    </td>
				    </tr>
                    <tr >
                        <td>
                             <div class="checkbox-control">
                                <asp:CheckBox ID="ckbCheckAll" Runat="server" Text="Chọn tất"></asp:CheckBox>
                            </div>
                        </td>
                        <td colspan="3" align="right">
                            <div class="button-control" runat="server" id="divReservationDelete">
                                <div class="button-form">
                                    <asp:button id="btnReservationDelete" Runat="server" class="btn-icon">
                                    </asp:button><div class="btn-value"><span class="mif-bin"></span>Xoá</div>
                                </div>
                            </div>
                        </td>
                    </tr>
                     <tr >
                        <td valign="top" width="100%" colspan="4">
                         <asp:Button Text="ẤN PHẨM ĐANG MƯỢN" BorderStyle="None" ID="btnOnHolding" CssClass="head-tab" runat="server"           
                              OnClick="Tab1_Click" ></asp:Button>
                          <asp:Button Text="LỊCH SỬ MƯỢN - TRẢ" BorderStyle="None" ID="btnHolding" CssClass="head-tab"  runat="server"
                              OnClick="Tab2_Click" />
                          <asp:MultiView ID="MainView" runat="server" >
                            <asp:View ID="View1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True" EnableViewState="True">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="dgrOnHolding" EventName="PageIndexChanged" /></Triggers>
                                    <ContentTemplate>
                                        <asp:datagrid id="dgrOnHolding" Runat="server" Width="100%"  AllowPaging="True" PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True" PageSize="20" >
							            <Columns>
								            <asp:BoundColumn DataField="STT" HeaderText="STT">
									            <HeaderStyle Width="2%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								            </asp:BoundColumn>
								            <asp:BoundColumn DataField="Title" HeaderText="Nhan đề">
									            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB">
									            <HeaderStyle Width="12%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DateCirculation" HeaderText="Ngày mượn"  DataFormatString="{0:dd/MM/yyyy}">
									            <HeaderStyle Width="12%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DateExpired" HeaderText="Hạn trả"  DataFormatString="{0:dd/MM/yyyy}">
									            <HeaderStyle Width="12%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
									            <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Renew" HeaderText="Gia hạn">
									            <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								            </asp:BoundColumn>
							            </Columns>
						                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                        <ItemStyle BackColor="White" ForeColor="#330099" />
                                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						            </asp:datagrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                     
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                    <asp:datagrid  id="dgrHolding" runat="server" Width="100%" PagerStyle-Mode="NumericPages"
							AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
							<Columns>
								<asp:BoundColumn DataField="STT" HeaderText="STT"><HeaderStyle Width="3%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                </asp:BoundColumn>
								<asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                </asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB">
									<HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></HeaderStyle>
								    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CheckOutDate" HeaderText="Ngày mượn" DataFormatString="{0:dd/MM/yyyy}">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CheckInDate" HeaderText="Ngày trả" DataFormatString="{0:dd/MM/yyyy}">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OverdueDays" HeaderText="Quá hạn (ngày)">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OverdueFine" HeaderText="Tiền phạt" DataFormatString ="{0:0.#}">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                            <ItemStyle BackColor="White" ForeColor="#330099" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" Mode="NumericPages"/>
                            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						</asp:datagrid>       
                            </asp:View>    
                          </asp:MultiView>
                        </td>
                    </tr>
				  
                    <tr>
                        <td width="100%" colspan="4"><hr /></td>
                    </tr>

                    <tr>
                        <td width="100%" colspan="4" style="background:#990000; color:#FFFFCC; font-weight:bold; height:30px; padding-left:5px;"><asp:label id="lblHeaderNotePatron" Runat="server" Width="100%" >Ghi chú bạn đọc</asp:label></td>
                    </tr>

                    <tr>
                        <td width="100%" colspan="4"><asp:label id="lblNotePatron" Runat="server" Width="100%" ></asp:label></td>
                    </tr>

				    <tr style="display:none;">
					    <td width="100%" colspan="4"><asp:label id="lblILLRequest" Runat="server" Width="100%" >Ấn phẩm mưọn liên thư viện</asp:label></td>
				    </tr>
				    <tr style="display:none;">
					    <td width="100%" colspan="4"><asp:datagrid id="dgrILLRequest" Runat="server" Width="100%" AutoGenerateColumns="False" ShowHeader="False">
							    <Columns>
								    <asp:BoundColumn DataField="CheckBox">
									    <HeaderStyle Width="5%"></HeaderStyle>
								    </asp:BoundColumn>
								    <asp:BoundColumn DataField="Title">
									    <HeaderStyle Width="95%"></HeaderStyle>
								    </asp:BoundColumn>
							    </Columns>
						    </asp:datagrid></td>
				    </tr>
				    <tr style="display:none;">
					    <td colspan="4" width="100%"><h3 class="head-title"><asp:Label ID="lblInterestItem" Runat="server" Width="100%" >Ấn phẩm mới</asp:Label></h3></td>
				    </tr>
				    <tr style="display:none;">
					    <td colspan="4" width="100%">
						    <asp:HyperLink CssClass="lbLinkFunction" ID="hrfInterstItem" Runat="server" Width="100%" NavigateUrl="javascript:SubmitForm();">Chọn lĩnh vực quan tâm
						    </asp:HyperLink>
					    </td>
				    </tr>
				    <tr style="display:none;">
					    <td colspan="4" width="100%"><asp:DataGrid ID="dgrInterestItem" Runat="server" Width="100%" AutoGenerateColumns="False">
							    <Columns>
								    <asp:BoundColumn DataField="Content">
									    <HeaderStyle Width="100%"></HeaderStyle>
								    </asp:BoundColumn>
							    </Columns>
						    </asp:DataGrid></td>
				    </tr>
                </table>
            </div>
        </div>
     </div>
     <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
    <div style="display:none">
        <span id="spChooseDocument" runat="server">Vui lòng chọn ấn phẩm</span>
        <asp:Label ID="lblCheckOutDate" Runat="server" Visible="False">Ngày mượn: </asp:Label>
		<asp:Label ID="lblCheckInDate" Runat="server" Visible="False">Ngày trả: </asp:Label>
		<asp:Label ID="lblOverDueDate" Runat="server" Visible="False">Quá hạn: </asp:Label>
		<asp:Label ID="lblDate" Runat="server" Visible="False"> ngày</asp:Label>
		<asp:Label ID="lblCreatedDate" Runat="server" Visible="False">Ngày tạo y/c: </asp:Label>
		<asp:Label ID="lbldelILL" Runat="server" Visible="False">huỷ yêu cầu</asp:Label>
		<asp:Label ID="lblStatus" Runat="server" Visible="False"> Trạng thái: </asp:Label>
		<asp:Label ID="lblRenew" Runat="server" Visible="False">gia hạn </asp:Label>
		<asp:Label ID="lblOnHoldingB" Runat="server" Visible="False">sách đã được đặt chỗ </asp:Label>
		<asp:Label ID="lblNotRenew" Runat="server" Visible="False"> không có quyền gia hạn</asp:Label>
		<asp:Label ID="lblHour" Runat="server" Visible="False">giờ</asp:Label>
		<asp:Label ID="lblGetBefore" Runat="server" Visible="False">Lấy truớc: </asp:Label>
		<asp:Label ID="lblLibaryName" Runat="server" Visible="False">Thư viện: </asp:Label>
		<asp:Label ID="lblPosition" Runat="server" Visible="False">Bạn đứng thứ</asp:Label>
        <asp:Label ID="lblHeaderReserve" Runat="server" Visible="False">Ấn phẩm đặt chỗ</asp:Label>
        <asp:Label ID="lblHeaderReservation" Runat="server" Visible="False">Ấn phẩm đặt mượn</asp:Label>
        <asp:Label ID="lblHeaderOnHolding" Runat="server" Visible="False">Ấn phẩm đang mượn</asp:Label>
        <asp:Label ID="lblHeaderHolding" Runat="server" Visible="False">Lịch sử mượn - trả</asp:Label>
		<input type="hidden" runat="server" id="hdInterestObject" name="hdInterestObject"/>
        <input type="hidden" runat="server" id="hdInheritanceMap" name="hdInheritanceMap" value="||" />
        <input type="hidden" id="hdOpenedParentIDs" runat="server" name="hdOpenedParentIDs"/>
        <input type="hidden" id="hdAllwaysChecking" name="hdAllwaysChecking" runat="server" value="false"/>
        <input type="hidden" name="hdScrollTop" id="hdScrollTop" runat="server"/> 
        <input type="hidden" name="hdUpdateFlag" id="hdUpdateFlage" runat="server"/>
        <input type="hidden" name="hdCirIDRenew" id="hdCirIDRenew" runat="server" value="0"/>
        <asp:Button ID="btRenews" runat="server" Text="Gia hạn" />
        <asp:Label ID="lbRenewSuccess" runat="server" Text="Gia hạn thành công"></asp:Label>
        <asp:Label ID="lbRenewError" runat="server" Text="Gia hạn thất bại"></asp:Label>
        <asp:Label ID="lbChangePassSuccess" runat="server" Text="Thay đổi mật khẩu thành công"></asp:Label>
        <asp:Label ID="lbChangePassError" runat="server" Text="Thay đổi mật khẩu thất bại"></asp:Label>
        <asp:Label ID="lbPasswordOldNotTrue" runat="server" Text="Mật khẩu cũ chưa chính xác"></asp:Label>
        <asp:Label ID="lbPasswordReNotTrue" runat="server" Text="Mật khẩu xác nhận chưa trùng khớp"></asp:Label>
    </div>
    <script type="text/javascript">
        var changed=[false,false,false,false,false];
        
        $(".btn-edit").click(function(e){
            var index=$(".btn-edit").index(this);
            $("input[data-input]").eq(index).val($(".value-content").eq(index).html());
            $(".value-container").eq(index).hide();
            $(".function-container").eq(index).show();
        });

        $(".btn-save-container").click(function(e){
            var index=$(".btn-save-container").index(this);
            $(".value-container").eq(index).show();
            $(".function-container").eq(index).hide();
            $(".value-content").eq(index).html($("input[data-input]").eq(index).val());
            $(".hid-updated-value input").eq(index).val($("input[data-input]").eq(index).val());
            if($(".value-content").eq(index).html()!=$(".hid-value input").eq(index).val()){
                changed[index]=true;
            }
            else{
                changed[index]=false;
            }
            var isShow=false;
            let i=0;
            for(;i<5;i++){
                if(changed[i]){
                    isShow=true;
                    
                    break;
                }
            }
            if(isShow){
                $("#btnUpdate").css('visibility', 'visible');
            }
            else{
                $("#btnUpdate").css('visibility', 'hidden');
            }
        });

        $(".btn-cancel").click(function(e){
            var index=$(".btn-cancel").index(this);
            $(".value-container").eq(index).show();
            $(".function-container").eq(index).hide();
        });

        function SubmitRenew(intId)
        {
            var hdCirIDRenew = document.getElementById("hdCirIDRenew");
            hdCirIDRenew.value = intId;
            document.getElementById("btRenews").click();
        }
    </script>
</form>
</body>
</html>
