<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WBillTemplateMan" CodeFile="WBillTemplateMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBillTemplateMan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<BODY leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
        
        <div id="divBody">
        	<h1 class="main-head-form"><asp:label id="lblMainTitle" cssclass="lbPagetitle" Runat="server" Width="100%">
							Soạn mẫu hoá đơn thanh toán
						</asp:label></h1>
                        
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p><asp:label id="lbFormat" Runat="server"><U>K</U>huôn dạng: </asp:label></p>
                         <div class="input-control">
                            <div class="dropdown-form">
                              <asp:dropdownlist id="ddlFormatName" Runat="server" Width="300px"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p><asp:label id="lbNFormat" Runat="server"><U>T</U>ên khuôn dạng:</asp:label>	<asp:label id="lblMan" Runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:label></p>
                         <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox id="txtTitle" CssClass="text-input" Runat="server" Width="500"></asp:textbox>&nbsp;
					
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="two-column-form">
                    <div class="row-detail">
                        <p><asp:label id="lblOption" Runat="server">Chọn thông tin:</asp:label></p>
                         <div class="input-control">
                            <div class="dropdown-form">
                                <asp:dropdownlist id="ddlHeadRequestInfo1" Runat="server" Width="150px">
							<asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
							<asp:ListItem Value=" &lt;$NAME$&gt;">Người đặt</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1)</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2)</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
							<asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ</asp:ListItem>
							<asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Ngày đặt mua</asp:ListItem>
							<asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày hết hạn đặt</asp:ListItem>
							<asp:ListItem Value="&lt;$DD$&gt;">Ngày</asp:ListItem>
							<asp:ListItem Value="&lt;$MM$&gt;">Tháng</asp:ListItem>
							<asp:ListItem Value="&lt;$YYYY$&gt;">Năm</asp:ListItem>
						</asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Nội dung :</p>
                         <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox id="txtHeader" CssClass="text-input" tabIndex="3" Runat="server" Width="100%" Wrap="true" TextMode="MultiLine"
							Columns="100" Height="60px"></asp:textbox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <h1 class="main-group-form">Những thông tin có khuôn và định dạng của khuôn</h1>
            <div class="two-column ClearFix">
                <div class="two-column-form ClearFix">
                    <div class="span45">
                        <div class="row-detail">
                            <p><asp:label id="lblAllCollums" Runat="server">Cột <U> k</U>hông hiển thị</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                    <asp:listbox id="lsbAllCollums" Runat="server" CssClass="area-input" SelectionMode="Multiple" Rows="6"></asp:listbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="span1">
                        <div class="input-control button-list">
                            <div class="button-control">
                                <div class="button-form">
                                    
                                    <asp:button id="btnAdd" CssClass="btn-icon" Runat="server" Text=">>"></asp:button>
<div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    
                                </div>
                            </div>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:button id="btnRemove" CssClass="btn-icon" Runat="server" Text="<<"></asp:button>
                                 <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="span45">
                        <div class="row-detail">
                            <p><asp:label id="lblCollum" Runat="server" Width="100%">Cột <u> h</u>iển thị</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                    <asp:listbox id="lsbCollum" Runat="server" CssClass="area-input" SelectionMode="Multiple" Rows="6"></asp:listbox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="two-column-form ClearFix">
                    
                    
                    <div class="unit-4">
                        <div class="row-detail">
                            <p><asp:label id="lblCollumCaption" Runat="server"><u> T</u>iêu đề cột</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                   <asp:textbox id="txtCollumCaption" tabIndex="8" Runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
										Columns="20" Rows="5"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="unit-4">
                        <div class="row-detail">
                            <p><asp:label id="lblCollumWidth" Runat="server">Độ <u> r</u>ộng</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                   <asp:textbox id="txtCollumWidth" Runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
										Columns="10" Rows="5"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="unit-4">
                        <div class="row-detail">
                            <p><asp:label id="lblAlign" Runat="server">Căn <u>l</u>ề</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                  <asp:textbox id="txtAlign" Runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine" Columns="10"
										Rows="5"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="unit-4">
                        <div class="row-detail">
                            <p><asp:label id="lblFormat" Runat="server">Định dạng</asp:label></p>
                             <div class="input-control">
                                <div class="input-form ">
                                   <asp:textbox id="txtFormat" Runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine" Columns="10"
										Rows="5"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="row-detail">
                <p><asp:label id="lblOption2" Runat="server">Chọn thông tin:</asp:label></p>
                 <div class="input-control">
                    <asp:dropdownlist id="ddlFootRequestInfo" Runat="server" >
							<asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
							<asp:ListItem Value=" &lt;$NAME$&gt;">Người đặt</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1)</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2)</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
							<asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
							<asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ</asp:ListItem>
							<asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Mô tả tài liệu đặt mua</asp:ListItem>
							<asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày đặt</asp:ListItem>
							<asp:ListItem Value="&lt;$DD$&gt;">Ngày</asp:ListItem>
							<asp:ListItem Value="&lt;$MM$&gt;">Tháng</asp:ListItem>
							<asp:ListItem Value="&lt;$YYYY$&gt;">Năm</asp:ListItem>
						</asp:dropdownlist>
                </div>
            </div>
            <div class="row-detail">
                <p>Cuối đơn :</p>
                 <div class="input-control">
                    <div class="input-form ">
                      <asp:textbox id="txtFooter" CssClass="text-input" tabIndex="10" Runat="server" Width="100%" Wrap="true" TextMode="MultiLine"
							Columns="100" Height="60px"></asp:textbox>
                    </div>
                </div>
            </div>

            <div class="row-detail">
                <div class="button-control" style="text-align:center;">
                    <div class="button-form">
                        <asp:button id="btnUpdate"  CssClass="form-btn" Runat="server" Width="98px" Text="Cập nhật(u)"></asp:button>
                     
                    </div>
                    <div class="button-form">
                     
						<asp:button id="btnPreview"  CssClass="form-btn" Runat="server" Width="100px" Text="Xem trước(p)">  </asp:button>
                    </div>
                    <div class="button-form">
                       <asp:button id="btnDelete"  CssClass="form-btn" Runat="server" Width="68px" Text="Xóa(d)"></asp:button>
                    </div>
                </div>
            </div>
        </div>
        
        

			<TABLE cellSpacing="0" cellPadding="1" width="100%" border="0">
			
				<TR class="lbGroupTitle">
					<TD vAlign="top" width="20%" colSpan="2"><asp:label id="lblLabel1" Runat="server" Width="100%" cssclass="lbGroupTitle">P<u>h</u>ần đầu thư:</asp:label></TD>
				</TR>
				
				
				<TR class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblIncudeCollums" Runat="server" Width="100%" cssclass="lbGroupTitle">Phần giữa thư gồm các cột:</asp:label></TD>
				</TR>
				
				
				<TR class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblFooter" Runat="server" Width="100%" cssclass="lbGroupTitle">Phần cuối thư:</asp:label></TD>
				</TR>
				
				
				
			</TABLE>
            
            

			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập tên khuôn dạng!</asp:ListItem>
				<asp:ListItem Value="3">Cập nhật khuôn dạng thành công!</asp:ListItem>
				<asp:ListItem Value="4">Nhấn OK để khẳng định việc xoá mẫu này!</asp:ListItem>
				<asp:ListItem Value="5">---------- Tạo mới -----------</asp:ListItem>
				<asp:ListItem Value="6">Bạn chưa chọn khuôn dạng cần làm việc!</asp:ListItem>
			</asp:dropdownlist>
            
            
            
            <asp:listbox id="lsbTemp" Runat="server" Width="0px" Height="0px"></asp:listbox><input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
			<input id="txtCollum" type="hidden" name="txtCollum" runat="server">
			<asp:label id="lblAddNewFormat" Runat="server" Visible="False">---------- Khuôn dạng mới ---------- </asp:label><asp:label id="lblCollumText" Runat="server" Visible="False">STT, Mô tả tài liệu, Kích cỡ, Giá, Đơn vị tiền tệ</asp:label><asp:label id="lblCollumValue" Runat="server" Visible="False">&lt;$NO$&gt;, &lt;$NOTE$&gt;,&lt;$FILESIZE$&gt;, &lt;$PRICE$&gt;, &lt;$CURRENCY$&gt;</asp:label><input id="Hidden1" type="hidden" value="0" name="txtTemplate" runat="server">
			<input id="Hidden2" type="hidden" name="txtCollum" runat="server"> <input id="hdCollumCaptionText" type="hidden" name="hdCollumCaptionText" runat="server">
			<input id="hdMax" type="hidden" name="hdMax" runat="server">
		</form>
		<script language = javascript>
			document.forms[0].txtTitle.focus();
		</script>
	</BODY>
</HTML>
