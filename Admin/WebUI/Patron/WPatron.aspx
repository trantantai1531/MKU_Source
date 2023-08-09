<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WPatron" CodeFile="WPatron.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPatron</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/style.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		    var PatronAdd = new Array();
		</script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
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
	</HEAD>
	<BODY onkeypress="microsoftKeyPress()" leftMargin="0" topMargin="0" onload="var curtab = 0; document.forms[0].txtFirstName.focus();">
		<FORM id="Form1" method="post" runat="server">
			<table id="tblMain" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="7"><asp:label id="lblPageTitle" runat="server" CssClass="main-head-form">Cập nhật thông tin bạn đọc</asp:label></TD>
				</TR>
				<tr>
					<td align="right"><asp:label id="lblFirstName" runat="server"><U>H</U>ọ và tên: <p class="error-star">(*)</p></asp:label></td>
					<td colSpan="5"><nobr><asp:textbox id="txtFirstName" onfocus="ChangeTab(0)" Width="130px" Runat="server"></asp:textbox><asp:textbox id="txtLastName" onfocus="ChangeTab(1)" Width="90px" Runat="server"></asp:textbox>&nbsp;
							<asp:radiobutton id="optMale" runat="server" Text="<u>N</u>am" GroupName="Gender" Checked="True"></asp:radiobutton><asp:radiobutton id="optFeMale" runat="server" Text="<u>N</u>ữ" GroupName="Gender"></asp:radiobutton></nobr></td>
				    <TD align="center" rowSpan="5">&nbsp;<IMG id="imgPatron" alt="" src="../Images/Card/Empty.gif" runat="server"/>
					</TD>
				</tr>
				<TR>
					<td align="right" width="6%"><asp:label id="lblDOB" runat="server"><U>N</U>gày sinh:</asp:label></td>
					<td><asp:textbox id="txtDOB" onfocus="ChangeTab(4)" runat="server" Width="100px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDOB" runat="server">Lịch</asp:hyperlink></td>
					<td align="right"><asp:label id="lblEthnic" runat="server"><u>D</u>ân tộc:</asp:label></td>
					<td colSpan="3"><asp:dropdownlist id="ddlEthnic" onfocus="ChangeTab(5)" runat="server"></asp:dropdownlist>&nbsp;<asp:hyperlink id="lnkAddEthnic" runat="server">Thêm</asp:hyperlink></td>
				</TR>
				<tr>
					<td align="right" width="4%"><asp:label id="lblCode" runat="server"><u>S</u>ố thẻ:<p class="error-star">(*)</p></asp:label></td>
					<td><asp:textbox id="txtCode" onfocus="ChangeTab(6)" runat="server" Width="100px"></asp:textbox><asp:button id="btnGenCard" style="display: none" runat="server" Width="100px" Text="Sinh giá trị"></asp:button></td>
					<td align="right"><span><u>N</u>hóm bạn đọc:<p class="error-star">(*)</p></span></td>
					<td colSpan="3"><asp:dropdownlist id="ddlPatronGroup" onfocus="ChangeTab(7)" runat="server"></asp:dropdownlist>&nbsp;<asp:hyperlink id="lnkDetailPatronGroup" runat="server">Xem</asp:hyperlink></td>
				</tr>
				<TR>
					<TD align="right"><asp:label id="lblLastIssuedDate" runat="server"><U>N</U>gày cấp:<p class="error-star">(*)</p></asp:label></TD>
					<TD><asp:textbox id="txtLastIssuedDate" onfocus="ChangeTab(8)" runat="server" Width="100px"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkLastIssuedDate" runat="server">Lịch</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblValidDate" runat="server"><U>N</U>gày hiệu lực:</asp:label>
						<asp:textbox id="txtValidDate" onfocus="ChangeTab(9)" runat="server" Width="100px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkValidDate" runat="server">Lịch</asp:hyperlink></TD>
					<TD align="right">
						<asp:label id="lblExpiredDate" runat="server"><U>N</U>gày hết hạn:</asp:label></TD>
					<TD colSpan="3">
						<asp:textbox id="txtExpiredDate" onfocus="ChangeTab(10)" runat="server" Width="100px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkExpiredDate" runat="server">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblEducationLevel" runat="server">Trình <u>đ</u>ộ:</asp:label></TD>
					<td><asp:dropdownlist id="ddlEducation" onfocus="ChangeTab(11)" runat="server" Width="300px"></asp:dropdownlist>&nbsp;<asp:hyperlink id="lnkAddEducation" runat="server">Thêm</asp:hyperlink></td>
					<td align="right"><asp:label id="lblOccupation" runat="server">Nghề ngh<u>i</u>ệp:</asp:label></td>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlOccupation" onfocus="ChangeTab(12)" runat="server" Width="70%"></asp:dropdownlist>&nbsp;<asp:hyperlink id="lnkAddOccupation" runat="server">Thêm</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblWorkPlace" runat="server" Width="88px">Nơi làm <u>v</u>iệc:</asp:label></TD>
					<TD colSpan="5"><asp:textbox id="txtWorkPlace" onfocus="ChangeTab(13)" runat="server" Width="385px"></asp:textbox></TD>
					<TD align="center"><asp:hyperlink id="lnkPatronImage" runat="server">Ảnh</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="lnkRemovePatronImage" class="lbLinkFunction" href="#lnkPatronImage" onclick="RemoveImageClick()">Xóa ảnh</a></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblCollege" runat="server"><u>T</u>rường:</asp:label></TD>
					<TD colSpan="6"><asp:dropdownlist id="ddlCollege" onfocus="ChangeTab(14)" runat="server"></asp:dropdownlist>&nbsp;
						<asp:hyperlink id="lnkAddCollege" runat="server">Thêm</asp:hyperlink>&nbsp;&nbsp;
						<asp:label id="lblFaculty" runat="server"><u>K</u>hoa:</asp:label><asp:dropdownlist id="ddlFaculty" onfocus="ChangeTab(15)" runat="server"></asp:dropdownlist>&nbsp;
						<asp:hyperlink id="lnkAddFaculty" runat="server">Thêm</asp:hyperlink>&nbsp;
						<asp:label id="lblGrade" runat="server"><u>K</u>hóa:</asp:label><asp:textbox id="txtGrade" onkeypress="return isNumber(event)" onfocus="ChangeTab(16)" runat="server" Width="75px"></asp:textbox>&nbsp;
						<asp:label id="lblClass" runat="server"><u>L</u>ớp:</asp:label><asp:textbox id="txtClass" onfocus="ChangeTab(17)" runat="server" Width="65px"></asp:textbox></TD>
				</TR>
				<TR class="lbSubFormTitle">
					<td align="left" colSpan="2"><asp:label id="lblCPOA" runat="server" cssclass="lbSubFormTitle" Visible="false">Địa chỉ</asp:label></td>
					<TD align="right" colSpan="6" style="display:none"><asp:button id="btnFirst" runat="server" Width="26px"  Text="|<"></asp:button><asp:button id="btnPrevious" runat="server" Width="26px" Text="<"></asp:button>&nbsp;<asp:textbox id="txtCurrentRecord" runat="server" Width="32px" Enabled="False">0</asp:textbox>&nbsp;<asp:label id="lblOf" runat="server" CssClass="lbLabel">trong</asp:label>
						<asp:textbox id="txtTotalRecord" runat="server" Width="32px" Enabled="False">0</asp:textbox><asp:button id="btnNext" runat="server" Width="26px" Text=">"></asp:button><asp:button id="btnLast" runat="server" Width="26px" Text=">|"></asp:button><asp:button id="btnNew" runat="server" Width="26px" Text=">*"></asp:button><asp:button id="btnDelete" runat="server" Width="26px" Text="X"></asp:button>&nbsp;</NOBR></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblAddress" runat="server"><u>Ð</u>ịa chỉ:</asp:label></TD>
					<TD colSpan="3"><asp:textbox id="txtAddress" onfocus="ChangeTab(18)" runat="server" Width="385px"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblCity" runat="server">Thành <u>p</u>hố:</asp:label></TD>
					<TD colSpan="2"><asp:textbox id="txtCity" onfocus="ChangeTab(19)" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblProvince" runat="server">T<u>ỉ</u>nh:</asp:label></TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlProvince" onfocus="ChangeTab(20)" runat="server"></asp:dropdownlist>&nbsp;<asp:hyperlink id="lnkAddProvince" runat="server">Thêm</asp:hyperlink>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCountry" runat="server">Nướ<u>c</u>:</asp:label><asp:dropdownlist id="ddlCountry" onfocus="ChangeTab(21)" runat="server"></asp:dropdownlist>&nbsp;
						<asp:hyperlink id="lnkAddCountry" runat="server" Visible="False">Thêm</asp:hyperlink></TD>
					<TD align="right" style="display:none"><asp:label id="lblZip" runat="server" Width="68px"><u>M</u>ã vùng:</asp:label></TD>
					<TD width="89" colSpan="2" style="display:none"><nobr><asp:textbox id="txtZip" onfocus="ChangeTab(22)" runat="server" Width="44px"></asp:textbox>&nbsp;
							<asp:checkbox id="cbxActive" runat="server" CssClass="lbCheckbox" Text="Đị<u>a</u> chỉ chính"></asp:checkbox></nobr></TD>
				</TR>
				<TR class="lbSubFormTitle">
					<TD align="left" colSpan="7"><asp:label id="lblOtherInfor" runat="server" cssclass="lbSubFormTitle">Thông tin khác</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblTelephone" runat="server"><u>Đ</u>iện thoại:</asp:label></TD>
					<TD><asp:textbox id="txtTelephone" onfocus="ChangeTab(24)" runat="server" Width="120px"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblMobile" runat="server" Visible="false">Mo<u>b</u>ile:</asp:label></TD>
					<TD width="143" style=""><asp:textbox id="txtMobile" onfocus="ChangeTab(25)" runat="server" Width="120px" Visible="false"></asp:textbox></TD>
					<TD align="right"></TD>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblEmail" runat="server"><u>E</u>mail:</asp:label></TD>
					<TD>
                        <asp:textbox id="txtEmail" onfocus="ChangeTab(26)" runat="server" Width="300px"></asp:textbox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:label id="lblFacebook" runat="server"><u>F</u>acebook:</asp:label>
                        <asp:textbox id="txtFacebook" onfocus="ChangeTab(27)" runat="server" Width="250px"></asp:textbox>
					</TD>
					<TD align="right"><asp:label id="Label1" runat="server"><u>S</u>ố chứng minh thư:</asp:label></TD>
					<TD width="143"><asp:textbox id="txtIDCard" runat="server" Width="150px"></asp:textbox></TD>
					<TD align="right"></TD>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="right" valign="top"><asp:label id="lblNote" runat="server">G<u>h</u>i chú:</asp:label></TD>
					<TD colSpan="6"><asp:textbox id="txtNote" style="border: 1px solid rgb(153, 153, 153);" onfocus="ChangeTab(28)" runat="server" Width="648px" Height="200px" TextMode="MultiLine"
							Rows="5"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"><asp:button id="btnUpdate" runat="server" CssClass="lbButton" Width="98px" Text="Cập nhật(u)"></asp:button>&nbsp;
					    <INPUT class="lbButton" id="btnReset" type="reset" value="Đặt lại(r)" name="btnReset" runat="server"/>&nbsp;
						<asp:HyperLink id="btnSearch" runat="server" CssClass="lbButton" Width="102px" Text="Tìm kiếm(f)"></asp:HyperLink>&nbsp;&nbsp;&nbsp;
						<asp:checkbox id="cbxSetDefault" runat="server" Text="<U>G</U>iữ lại các giá trị hiện thời" Visible="false"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD></TD>
				    <TD width="515" colSpan="7"><INPUT id="hidAddress" type="hidden" name="hidAddress" runat="Server"/>&nbsp;
					    <INPUT id="hidCity" type="hidden" name="hidCity" runat="Server"/>&nbsp; <INPUT id="hidCountryIndex" type="hidden" name="hidCountryIndex" runat="Server"/>&nbsp;
					    <INPUT id="hidProvinceIndex" type="hidden" name="hidProvinceIndex" runat="Server"/>&nbsp;
					    <INPUT id="hidZip" type="hidden" name="hidZipIndex" runat="Server"/>&nbsp; <INPUT id="hidActive" type="hidden" name="hidActive" runat="Server"/>&nbsp;
					    <INPUT id="hidCountry" type="hidden" value="0" name="hidCountry" runat="Server"/>
					    <INPUT id="hidProvince" type="hidden" value="0" name="hidProvince" runat="Server"/>
					    <INPUT id="hidCurrActive" type="hidden" name="hidCurrActive" runat="Server"/>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7">
					    <P><INPUT id="hidEthnic" type="hidden" value="0" name="hidEthnic" runat="Server"/> <INPUT id="hidPatronGroup" type="hidden" value="0" name="hidPatronGroup" runat="Server"/>
						    <INPUT id="hidEducation" type="hidden" value="0" name="hidEducation" runat="Server"/>
						    <INPUT id="hidOccupation" type="hidden" value="0" name="hidOccupation" runat="Server"/>
						    <INPUT id="hidCollege" type="hidden" value="0" name="hidCollege" runat="Server"/>
						    <INPUT id="hidFaculty" type="hidden" value="0" name="hidFaculty" runat="Server"/>
						</P>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"><INPUT id="hidCode" type="hidden" name="hidCode" runat="Server"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"></TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập đủ thông tin cần thiết cho bạn đọc</asp:ListItem>
				<asp:ListItem Value="3">Bạn phải chọn 1 địa chỉ liên lạc chính</asp:ListItem>
				<asp:ListItem Value="4">Thời gian không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Ngày hiệu lực</asp:ListItem>
				<asp:ListItem Value="6">Ngày hết hạn</asp:ListItem>
				<asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
				<asp:ListItem Value="8">Phải có địa chỉ chính!</asp:ListItem>
				<asp:ListItem Value="9">không được để trống!</asp:ListItem>
				<asp:ListItem Value="10">Sai định dạng ngày!</asp:ListItem>
				<asp:ListItem Value="11">Ngày hiệu lực không được nhỏ hơn ngày cấp!</asp:ListItem>
				<asp:ListItem Value="12">Địa chỉ không được để trống!</asp:ListItem>
				<asp:ListItem Value="13">Phải chọn nước!</asp:ListItem>
				<asp:ListItem Value="14">------ Chọn ------</asp:ListItem>
				<asp:ListItem Value="15">Số thẻ phải được chọn!</asp:ListItem>
				<asp:ListItem Value="16">Cập nhật có lỗi, trùng số thẻ hoặc địa chỉ email!</asp:ListItem>
				<asp:ListItem Value="17">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="18">Thêm mới có lỗi, trùng số thẻ hoặc địa chỉ email!</asp:ListItem>
				<asp:ListItem Value="19">Thêm mới thành công!</asp:ListItem>
				<asp:ListItem Value="20">Bạn phải chọn địa chỉ một địa chỉ chính</asp:ListItem>
				<asp:ListItem Value="21">Bạn đang ở bản ghi đầu tiên!</asp:ListItem>
				<asp:ListItem Value="22">Bạn đang ở bản ghi cuối cùng!</asp:ListItem>
				<asp:ListItem Value="23">Bạn chưa nhập số thẻ bạn đọc!</asp:ListItem>
				<asp:ListItem Value="24">Bạn chưa chọn trường!</asp:ListItem>
				<asp:ListItem Value="25">Cập nhật thông tin thẻ bạn đọc</asp:ListItem>
				<asp:ListItem Value="26">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="27">Đã tồn tại địa chỉ chính thức!!!</asp:ListItem>
				<asp:ListItem Value="28">Tồn tại ít nhất 2 địa chỉ chính, chỉ cho phép 1 địa chỉ chính!!!</asp:ListItem>
				<asp:ListItem Value="29">Ngày hết hạn không được nhỏ hơn ngày hiệu lực!</asp:ListItem>
				<asp:ListItem Value="30">Số thẻ không được chứa các ký tự đặc biệt!</asp:ListItem>
			</asp:dropdownlist>
            <input id="hidAddressInfor" type="hidden" runat="server"> 
            <input id="hidCheckedID" type="hidden" runat="server">
			<input id="hidPatronID" type="hidden" value="0" runat="server"> 
            <input id="hidIsFirstChoiceActiveAddr" type="hidden" value="0" name="hidIsFirstChoiceActiveAddr" runat="server">
			<asp:label id="lblJS" runat="server"></asp:label>
			<input type="hidden" id="hidCurrentRecord" runat="server" value="0">

            <script type="text/javascript">
                function RemoveImageClick()
                {
                    document.getElementById("hidCode").value = "";
                    document.getElementById("imgPatron").setAttribute("src", "../Images/Card/Empty.gif");
                }
                function isNumber(evt) {
                    evt = (evt) ? evt : window.event;
                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                        alert("Chỉ đc nhập số");
                        document.getElementById("txtGrade").focus();
                        return false;
                    }
                    return true;
                }
            </script>
		</FORM>
	</BODY>
</HTML>
