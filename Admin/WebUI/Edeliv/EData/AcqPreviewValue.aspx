<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqPreviewValue.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqPreviewValue" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">        
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />   
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  <script language="JavaScript">
  <!--
      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.closeDialog('Dialog_content');
                  break;
              case 'openrecord':
                  var obj = '<%=Request("id")%>';
                  if (obj != '') {
                      ChangeToModifyPage(obj);
                      top.closeDialog('Dialog_content');                      
                  }
                  break;
          }
      }
      function ChangeToModifyPage(val) {
          var strURL;
          strURL = "../../Catalogue/Catalogue/WCataModify.aspx?Clone=0&ItemID=" + val;
          top.main.Sentform.location.href = strURL;
      }
  //-->
  </script>
</head>
<body  class="backgroundbodywhite" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <table id="table2" width="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white">
        <tr>
            <td width="32px" align="right"><img src="../../Images/ComponentArt/Toolbar/images/FooterControls/document-preview.png"  style="border:none;display:block;vertical-align:top;" width="32px" height="32px"/>
            </td>
            <td align="left"><asp:label id="lblRowTitle" CssClass="titlerowtextread" Runat="server">Xem dữ liệu biên mục điện tử</asp:label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:datagrid id="grdProperty" runat="server" AutoGenerateColumns="False" Width="100%">
					<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
					<ItemStyle CssClass="lbGridCell"></ItemStyle>
					<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Nh&#227;n">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:HyperLink ID="lnkFieldCode" Runat="server" CssClass="lbLinkFunction">
									<%#DataBinder.Eval(Container.dataItem,"FieldCode")%>
								</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Ind" HeaderText="Chỉ thị">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Content" HeaderText="Nội dung trường">
							<HeaderStyle HorizontalAlign="Center" Width="90%"></HeaderStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid>
            </td>
        </tr>
        </table>
        <asp:Literal ID="infoPreview" runat="server" Text=""></asp:Literal>
        <div style="display:none">
            <span  id="span_catalogue" runat="server">Dữ liệu biên mục</span>
            <span  id="span_attribute" runat="server">Thuộc tính</span>
            <span  id="span_attach" runat="server">Thông tin gắn tệp</span>
            <span  id="span_attach_info" runat="server">Các tệp đã được tải lên</span>
            <span  id="span_access" runat="server">Truy cập</span>
            <span  id="span_access_free" runat="server">Tự do</span>
            <span  id="span_access_charge" runat="server">Thu phí</span>
            <span  id="span_security" runat="server">Mức độ mật</span>
            <span  id="span_doctype" runat="server">Dạng lưu trữ</span>
            <span  id="span_status" runat="server">Trạng thái</span>
            <span  id="span_collection_path" runat="server">Bộ sưu tập</span>
            <asp:dropdownlist id="ddlLabel" Width="0px" Visible="False" Runat="server">
				<asp:ListItem Value="0">Xoá bản ghi biên mục</asp:ListItem>
				<asp:ListItem Value="1">Xoá bản ghi dữ liệu căn cứ</asp:ListItem>
				<asp:ListItem Value="2">Hiển thị bản ghi</asp:ListItem>
				<asp:ListItem Value="3">Xem bản ghi dữ liệu biên mục</asp:ListItem>
				<asp:ListItem Value="4">Xem bản ghi dữ liệu căn cứ</asp:ListItem>
				<asp:ListItem Value="5">Không thể xoá bản ghi dữ liệu biên mục vì vẫn tồn tại mã xếp giá</asp:ListItem>
				<asp:ListItem Value="6">Đóng</asp:ListItem>
				<asp:ListItem Value="7">Xoá</asp:ListItem>
				<asp:ListItem Value="8">Sửa</asp:ListItem>
				<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="11">Xoá bản ghi dữ liệu biên mục (1 bản ghi)</asp:ListItem>
				<asp:ListItem Value="12">Xoá bản ghi dữ liệu căn cứ (1 bản ghi)</asp:ListItem>
				<asp:ListItem Value="13">Xoá bản ghi thành công!</asp:ListItem>
				<asp:ListItem Value="14">Bạn có muốn xóa bản ghi biên mục này không?</asp:ListItem>
				<asp:ListItem Value="15">Cancel</asp:ListItem>
			</asp:dropdownlist>
        </div>
    </form>
</body>
</html>
