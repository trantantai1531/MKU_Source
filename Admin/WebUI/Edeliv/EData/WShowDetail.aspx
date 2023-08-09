<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WShowDetail" CodeFile="WShowDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.Edeliv.clsWEData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../Js/jsmenu/milonic_src.js" type="text/javascript">		
		</script>
		<script language="javascript" type="text/javascript">
			if(ns4)_d.write("<scr"+"ipt type=text/javascript src=../Js/jsmenu/mmenuns4.js><\/scr"+"ipt>");		
			else _d.write("<scr"+"ipt type=text/javascript src=../Js/jsmenu/mmenudom.js><\/scr"+"ipt>"); 
		</script>
		<script language="javascript">
			_menuCloseDelay=500           // The time delay for menus to remain visible on mouse out
			_menuOpenDelay=150            // The time delay before menus open on mouse over
			_subOffsetTop=10              // Sub menu top offset
			_subOffsetLeft=-10            // Sub menu left offset


			with(menuStyle=new mm_style()){
			onbgcolor="#4F8EB6";
			oncolor="#ffffff";
			offbgcolor="#DCE9F0";
			offcolor="#515151";
			bordercolor="#296488";
			borderstyle="solid";
			borderwidth=1;
			separatorcolor="#2D729D";
			separatorsize="1";
			padding=5;
			fontsize="75%";
			fontstyle="normal";
			fontfamily="Times New Roman";
			pagecolor="black";
			pagebgcolor="#82B6D7";
			headercolor="#000000";
			headerbgcolor="#ffffff";
			subimage="arrow.gif";
			subimagepadding="2";
			overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color='#777777', Direction=135, Strength=5)";
			outfilter="randomdissolve(duration=0.3)";
			}

			var focusID;

			function ShowContextMenu(fileID) {
				focusID = fileID
				popup('partners','imgdoc' + fileID)
			}

			function DownloadLink() {
				parent.HiddenDownload.location.href='WDownload.aspx?FileID=' + focusID;
				return;
			}

			function ExternalEditLink() {
				self.location.href = "WEditFile.aspx?FieldID=" + focusID;
				//self.location.href = "EditFile.asp?FieldID=" + focusID;
				return;
			}

			with(milonic=new menuname("Partners")){
			style=menuStyle;
			aI("text=<%=ddlLabel.Items(103).Text%>;url=JavaScript:DownloadLink();status=;");
			aI("text=<%=ddlLabel.Items(104).Text%>;url=JavaScript:ExternalEditLink();status=;");
			}
			drawMenus();
		</script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResetValue();">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr class="lbPageTitle">
					<td><asp:label id="lblPageTitle" CssClass="lbPageTitle" Runat="server"> Quản lý tư liệu điện tử</asp:label></td>
				</tr>
			</table>
			<asp:table id="tblNavigator" runat="server" BorderWidth="0" CellSpacing="0" CellPadding="4"></asp:table>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td colSpan="2"><asp:label id="lblCurrentFolder" Runat="server" Visible="False">Thư mục hiện thời:</asp:label><asp:label id="lblImportFolder" Runat="server">Thư mục muốn nhập khẩu:</asp:label>&nbsp;<asp:label id="lblFolder" Runat="server" Visible="False" Font-Bold="True"></asp:label>
					</td>
				</tr>
				<tr>
					<td align="left"><asp:table id="tblHeader" runat="server" BorderWidth="0"></asp:table></td>
					<td vAlign="top" align="right"><asp:label id="lblView" Runat="server"><u>C</u>hế độ hiển thị: </asp:label><asp:dropdownlist id="ddlView" Runat="server" AutoPostBack="True">
							<asp:ListItem Value="0" Selected="True">Danh sách</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD align="left" colSpan="2"><asp:table id="tblPaging" runat="server"></asp:table></TD>
				</TR>
				<TR id="TRFunc1" runat="server">
					<TD align="left" colSpan="2"><asp:button id="btnDeleteLogical" runat="server" CssClass="lbButton" Text=" Bỏ khỏi CSDL" Width="104px"></asp:button><asp:button id="btnMove" runat="server" CssClass="lbButton" Text="Chuyển chỗ" Width="88px"></asp:button><asp:button id="btnSetSecretLevel" runat="server" CssClass="lbButton" Text="Cấp độ mật" Width="88px"></asp:button><asp:button id="btnSetCollection" runat="server" CssClass="lbButton" Text="Bộ sưu tập" Width="80px"></asp:button><asp:button id="btnChangeStat" runat="server" CssClass="lbButton" Text="Đổi trạng thái" Width="96px"></asp:button><asp:button id="btnFree" runat="server" CssClass="lbButton" Text="Free" Width="40px"></asp:button><asp:button id="btnCost" runat="server" CssClass="lbButton" Text="Charge" Width="50px"></asp:button><asp:button id="btnDelete" runat="server" CssClass="lbButton" Text="Xoá"></asp:button><br>
						<asp:button id="btnCatalogue" runat="server" CssClass="lbButton" Text="Biên mục" Width="72px"></asp:button><asp:button id="btnAttach" runat="server" CssClass="lbButton" Text="Gắn biểu ghi" Width="88px"></asp:button><asp:button id="btnRemoveAttach" runat="server" CssClass="lbButton" Text="Bỏ gắn biểu ghi" Width="112px"></asp:button><asp:button id="btnExport" runat="server" CssClass="lbButton" Text="Xuất khẩu" Width="96px"></asp:button><asp:button id="btnChangeMap" runat="server" CssClass="lbButton" Text="Chuyển thành bản đồ"
							Width="144px"></asp:button><asp:button id="btnChangeImage" runat="server" CssClass="lbButton" Text="Chuyển thành hình ảnh"
							Width="154px"></asp:button></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2"><asp:table id="tblResult" runat="server"></asp:table></TD>
				</TR>
				<TR id="TRFunc2" runat="server">
					<TD align="left" colSpan="2"><asp:button id="btnDeleteLogical2" runat="server" CssClass="lbButton" Text=" Bỏ khỏi CSDL" Width="104px"></asp:button><asp:button id="btnMove2" runat="server" CssClass="lbButton" Text="Chuyển chỗ" Width="88px"></asp:button><asp:button id="btnSetSecretLevel2" runat="server" CssClass="lbButton" Text="Cấp độ mật" Width="88px"></asp:button><asp:button id="btnSetCollection2" runat="server" CssClass="lbButton" Text="Bộ sưu tập" Width="80px"></asp:button><asp:button id="btnChangeStat2" runat="server" CssClass="lbButton" Text="Đổi trạng thái" Width="96px"></asp:button><asp:button id="btnFree2" runat="server" CssClass="lbButton" Text="Free" Width="40px"></asp:button><asp:button id="btnCost2" runat="server" CssClass="lbButton" Text="Charge" Width="50px"></asp:button><asp:button id="btnDelete2" runat="server" CssClass="lbButton" Text="Xoá"></asp:button><br>
						<asp:button id="btnCatalogue2" runat="server" CssClass="lbButton" Text="Biên mục" Width="72px"></asp:button><asp:button id="btnAttach2" runat="server" CssClass="lbButton" Text="Gắn biểu ghi" Width="88px"></asp:button><asp:button id="btnRemoveAttach2" runat="server" CssClass="lbButton" Text="Bỏ gắn biểu ghi"
							Width="112px"></asp:button><asp:button id="btnExport2" runat="server" CssClass="lbButton" Text="Xuất khẩu" Width="96px"></asp:button><asp:button id="btnChangeMap2" runat="server" CssClass="lbButton" Text="Chuyển thành bản đồ"
							Width="144px"></asp:button><asp:button id="btnChangeImage2" runat="server" CssClass="lbButton" Text="Chuyển thành hình ảnh"
							Width="154px"></asp:button></TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0px" Height="0px">
				<asp:ListItem Value="0">Tên tệp</asp:ListItem>
				<asp:ListItem Value="1">Kiểu tệp</asp:ListItem>
				<asp:ListItem Value="2">Kích thước</asp:ListItem>
				<asp:ListItem Value="3">Ngày nhập</asp:ListItem>
				<asp:ListItem Value="4">Ngày sửa cuối</asp:ListItem>
				<asp:ListItem Value="5">Nhập khẩu(i)</asp:ListItem>
				<asp:ListItem Value="6">Định dạng</asp:ListItem>
				<asp:ListItem Value="7">Trạng thái</asp:ListItem>
				<asp:ListItem Value="8">Mức độ mật</asp:ListItem>
				<asp:ListItem Value="9">Số lần tải về</asp:ListItem>
				<asp:ListItem Value="10">Biểu ghi thư mục liên kết</asp:ListItem>
				<asp:ListItem Value="11">Dữ liệu metadata</asp:ListItem>
				<asp:ListItem Value="12">Thuộc tính</asp:ListItem>
				<asp:ListItem Value="13">Được khai thác</asp:ListItem>
				<asp:ListItem Value="14">Đang xử lý</asp:ListItem>
				<asp:ListItem Value="15">Chờ duyệt</asp:ListItem>
				<asp:ListItem Value="16">Ngừng khai thác</asp:ListItem>
				<asp:ListItem Value="17">Tải về</asp:ListItem>
				<asp:ListItem Value="18">Tải về máy trạm và soạn thảo</asp:ListItem>
				<asp:ListItem Value="19">Thay đổi thuộc tính vật lý của file</asp:ListItem>
				<asp:ListItem Value="20">Thay đổi các thuộc tính cho file (thư mục)</asp:ListItem>
				<asp:ListItem Value="21">Trang</asp:ListItem>
				<asp:ListItem Value="22">Kiểu tệp ảnh</asp:ListItem>
				<asp:ListItem Value="23">Hệ màu</asp:ListItem>
				<asp:ListItem Value="24">Khuôn hình</asp:ListItem>
				<asp:ListItem Value="25">Độ phân giải</asp:ListItem>
				<asp:ListItem Value="26">Số màu</asp:ListItem>
				<asp:ListItem Value="27">Trường độ</asp:ListItem>
				<asp:ListItem Value="28">Album</asp:ListItem>
				<asp:ListItem Value="29">Nghệ sĩ</asp:ListItem>
				<asp:ListItem Value="30">BitRate</asp:ListItem>
				<asp:ListItem Value="31">Thể loại</asp:ListItem>
				<asp:ListItem Value="32">Số trang</asp:ListItem>
				<asp:ListItem Value="33">Người nhập</asp:ListItem>
				<asp:ListItem Value="34">Trong</asp:ListItem>
				<asp:ListItem Value="35">Tổng số file trong CSDL</asp:ListItem>
				<asp:ListItem Value="36">Tổng số file vật lý</asp:ListItem>
				<asp:ListItem Value="37">Chế độ hiển thị</asp:ListItem>
				<asp:ListItem Value="38">Danh sách</asp:ListItem>
				<asp:ListItem Value="39">Nhập khẩu từ file system</asp:ListItem>
				<asp:ListItem Value="40">Đồng bộ với file system</asp:ListItem>
				<asp:ListItem Value="41">Tải lên file</asp:ListItem>
				<asp:ListItem Value="42">Tạo thư mục con</asp:ListItem>
				<asp:ListItem Value="43">Đổi tên thư mục</asp:ListItem>
				<asp:ListItem Value="44">Xoá thư mục</asp:ListItem>
				<asp:ListItem Value="45">Cập nhật đường dẫn</asp:ListItem>
				<asp:ListItem Value="46">Nhập tên thư mục con cần tạo</asp:ListItem>
				<asp:ListItem Value="47">Đã thực hiện xong yêu cầu</asp:ListItem>
				<asp:ListItem Value="48">Nhập tên mới của thư mục</asp:ListItem>
				<asp:ListItem Value="49">Thư mục con đã được đổi tên</asp:ListItem>
				<asp:ListItem Value="50">Thư mục đã được đồng bộ:</asp:ListItem>
				<asp:ListItem Value="51">Bạn có chắc chắn muốn xóa thư mục không? Bấm OK để khẳng định.Bấm Cancel để huỷ bỏ</asp:ListItem>
				<asp:ListItem Value="52">Nhập đường dẫn của thư mục muốn nhập khẩu</asp:ListItem>
				<asp:ListItem Value="53">Bạn phải chọn ít nhất một tệp trước khi nhập khẩu</asp:ListItem>
				<asp:ListItem Value="54">Bạn phải chọn ít nhất một tệp trước khi bỏ khỏi CSDL</asp:ListItem>
				<asp:ListItem Value="55">Bạn có chắc chắn muốn bỏ khỏi CSDL các tệp được đánh dấu không.\n Các yêu cầu đặt mua gắn với file được chọn cũng sẽ bị xoá. \n Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="56">Bạn có chắc chắn muốn nhập khẩu các tệp được đánh dấu không. Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="57">Bạn phải chọn ít nhất một tệp trước khi đặt cấp độ mật</asp:ListItem>
				<asp:ListItem Value="58">Nhập cấp độ mật cần đặt cho các tệp lựa chọn (từ 0 đến 9)</asp:ListItem>
				<asp:ListItem Value="59">Bạn phải chọn ít nhất một tệp trước khi xoá</asp:ListItem>
				<asp:ListItem Value="60">Bạn có chắc chắn muốn xóa các tệp được đánh dấu không. Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="61">Nhập đường dẫn của thư mục đích:</asp:ListItem>
				<asp:ListItem Value="62">Thư mục đích không hợp lệ</asp:ListItem>
				<asp:ListItem Value="63">Đã thực hiện việc chuyển chỗ các tệp tới thư mục đích</asp:ListItem>
				<asp:ListItem Value="64">Bạn phải chọn ít nhất một tệp trước khi chuyển chỗ</asp:ListItem>
				<asp:ListItem Value="65">Bạn phải chọn ít nhất một tệp trước khi gắn biểu ghi</asp:ListItem>
				<asp:ListItem Value="66">Bạn phải chọn ít nhất một tệp trước khi bỏ gắn biểu ghi</asp:ListItem>
				<asp:ListItem Value="67">Nhập mã số biểu ghi</asp:ListItem>
				<asp:ListItem Value="68">Biểu ghi biên mục liên kết</asp:ListItem>
				<asp:ListItem Value="69">Chế độ khai thác</asp:ListItem>
				<asp:ListItem Value="70">Bạn phải chọn ít nhất một tệp trước khi sử dụng tính năng gắn với bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="71">Bạn phải chọn tệp trước khi sử dụng tính năng biên mục</asp:ListItem>
				<asp:ListItem Value="72">Xem chi tiết biểu ghi biên mục</asp:ListItem>
				<asp:ListItem Value="73">Bạn phải chọn ít nhất một tệp trước khi đổi trạng thái</asp:ListItem>
				<asp:ListItem Value="74">Nhập trạng thái cho các tệp lựa chọn (từ 1 đến 4) \n 1=Được khai thác, 2=Đang xử lý, 3=Chờ duyệt, 4=Ngừng khai thác</asp:ListItem>
				<asp:ListItem Value="75">Cập nhật thông tin ấn phẩm điện tử có thu phí</asp:ListItem>
				<asp:ListItem Value="76">Ấn phẩm điện tử truy cập tự do</asp:ListItem>
				<asp:ListItem Value="77">Bạn phải chọn ít nhất một tệp trước khi chuyển chế độ khai thác thành miễn phí</asp:ListItem>
				<asp:ListItem Value="78">Bạn có chắc chắn muốn chuyển chế độ khai thác cho các tệp được đánh dấu thành miễn phí không. Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="79">Bạn phải chọn ít nhất một tệp trước khi chuyển chế độ khai thác thành có thu phí</asp:ListItem>
				<asp:ListItem Value="80">Bạn có chắc chắn muốn chuyển chế độ khai thác cho các tệp được đánh dấu thành có thu phí không. Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="81">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="82">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="83">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="84">Bạn phải chọn ít nhất một tệp trước khi xuất khẩu</asp:ListItem>
				<asp:ListItem Value="85">Thư mục bạn lựa chọn không nằm trong các phạm vi thiết đặt cho cơ sở dữ liệu số.</asp:ListItem>
				<asp:ListItem Value="86">Không tìm thấy tệp nào trong dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="87">Bạn có chắc chắn muốn chuyển dạng tài liệu cho các tệp được đánh dấu thành bản đồ ảnh không (Chỉ áp dụng cho các tập tin ảnh).\n Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="88">Bạn phải chọn ít nhất một tệp trước khi chuyển dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="89">Bạn có chắc chắn muốn chuyển dạng tài liệu cho các tệp được đánh dấu thành hình ảnh không (Chỉ áp dụng cho các tập tin bản đồ ảnh).\n Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="90">thành công !</asp:ListItem>
				<asp:ListItem Value="91">Xuất hiện lỗi! Tên thư mục mới trùng với tên thư mục đã có !</asp:ListItem>
				<asp:ListItem Value="92">Bạn phải chọn ít nhất một tệp có gắn biểu ghi!</asp:ListItem>
				<asp:ListItem Value="93">Xoá file</asp:ListItem>
				<asp:ListItem Value="94">Chuyển chế độ khai thác file thành có thu phí</asp:ListItem>
				<asp:ListItem Value="95">Chuyển chế độ khai thác file thành miễn phí</asp:ListItem>
				<asp:ListItem Value="96">Thiết đặt cấp độ mật cho file</asp:ListItem>
				<asp:ListItem Value="97">Đổi trạng thái của file</asp:ListItem>
				<asp:ListItem Value="98">Chuyển chỗ tệp</asp:ListItem>
				<asp:ListItem Value="99">Gắn biểu ghi cho tệp</asp:ListItem>
				<asp:ListItem Value="100">Bỏ gắn biểu ghi cho tệp</asp:ListItem>
				<asp:ListItem Value="101">Chuyển định dạng file sang bản đồ số</asp:ListItem>
				<asp:ListItem Value="102">Chuyển định dạng file sang hình ảnh</asp:ListItem>
				<asp:ListItem Value="103">Tải về</asp:ListItem>
				<asp:ListItem Value="104">Chỉnh sửa trên máy trạm</asp:ListItem>
				<asp:ListItem Value="105">File đã tồn tại, nhấn OK nếu muốn copy đè lên file cũ</asp:ListItem>
				<asp:ListItem Value="106">Đã hoàn tất quá trình tải file lên</asp:ListItem>
				<asp:ListItem Value="107">Đã tạo mới thư mục con</asp:ListItem>
				<asp:ListItem Value="108">Đã cập nhật mức độ mật</asp:ListItem>
				<asp:ListItem Value="109">Cấp độ mật phải là số nguyên</asp:ListItem>
				<asp:ListItem Value="110">Sai kiểu dữ liệu. Đổi trạng thái không thành công.</asp:ListItem>
				<asp:ListItem Value="111">Dữ liệu vượt quá giới hạn cho phép. Đổi trạng thái không thành công.</asp:ListItem>
				<asp:ListItem Value="112">Tên thư mục không phù hợp.</asp:ListItem>
			</asp:dropdownlist><input id="hidFunc" type="hidden" runat="server"> <input id="hidLoc" type="hidden" runat="server">
			<input id="hidAttr" type="hidden" runat="server"> <input id="hidIDs" type="hidden" value="," runat="server">
			<input id="hidFolder" type="hidden" runat="server"> <input id="hidSecretLevel" type="hidden" runat="server">
			<input id="hidStatus" type="hidden" runat="server"> <input id="hidAction" type="hidden" name="hidAction" runat="server">
			<input id="hidChanged" type="hidden" name="hidChanged" runat="server"> <input id="hidLocCur" type="hidden" name="hidLocCur" runat="server">
			<input id="hidAttachedIDs" type="hidden" runat="server"> <input id="hidOverWrite" runat="server" type="hidden" value="0" name="hidOverWrite">
			<asp:Label ID="lblAlertJS" Runat="server" />
			<script language="javascript">				
				switch (document.forms[0].hidAction.value) {
					case "1":						
						if (document.forms[0].hidChanged.value=="1") {
							alert(document.forms[0].ddlLabel.options[49].text);
							parent.foldertree.location.href='clsWTreeView.aspx';
							}
						else
							alert(document.forms[0].ddlLabel.options[91].text);
						break;
					case "2":
						if (document.forms[0].hidChanged.value=="1") {
							alert(document.forms[0].ddlLabel.options[47].text);
							parent.foldertree.location.href='clsWTreeView.aspx';
							}
						else
							alert(document.forms[0].ddlLabel.options[91].text);
						break;
				}
			</script>
		</form>
	</body>
</HTML>
