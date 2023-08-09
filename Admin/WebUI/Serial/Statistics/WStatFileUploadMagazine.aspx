<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatFileUploadMagazine.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.WStatFileUploadMagazine" %>

<%@ Import Namespace="eMicLibAdmin.WebUI" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatFileUpload</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

    
    <%
        Dim strLanguage As String = "vie"
        Select Case clsSession.GlbLanguage
            Case "tcvn", "vni", "vie"
                strLanguage = "vie"
            Case Else
                strLanguage = clsSession.GlbLanguage
        End Select

        If strLanguage = "" Or strLanguage = "vie" Then
            Response.Write("<script language='javascript'>var language = 'vie';var imgDir='../../Common/Calendar/';</script>")
        Else
            Response.Write("<script language='javascript'>var language = '" & strLanguage & "';var imgDir='" & strLanguage & "/Common/Calendar/';</script>")
        End If
    %>
    <style type="text/css">
        .table-form td
        {
            white-space: nowrap;
            max-width: 200px;
            overflow-x: auto;
        }
    </style>
    <script type="text/javascript" src="../../Common/Calendar/PopCalendar1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form"><asp:Label ID="lblTitle" runat="server" CssClass="lbPageTitle">Báo cáo upload file báo tạp chí</asp:Label></h1>
            <div class="three-column ClearFix">
                <div class="three-column-form">
                        <div class="two-column ClearFix">
                            <div class="two-column-form">
                                <div class="row-detail" align="right">
                                    <p>Từ ngày :<asp:hyperlink id="lnkCheckInDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="lbTextBox" Width="90px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>    
                            <div class="two-column-form">
                                <div class="row-detail" align="center">
                                    <p>Đến ngày :<asp:hyperlink id="lnkCheckInDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                            <asp:TextBox ID="txtDateTo" runat="server" CssClass="lbTextBox" Width="90px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                       </div>
                    </div>
                 <div class="three-column-form">
                     <div class="two-column ClearFix">
                            <div class="two-column-form">
                                  <div class="row-detail" align="left">
                                        <p>Nhan đề tạp chí:</p>
                                        <div class="input-control">
                                            <asp:TextBox runat="server" ID="txtContent" Width="300px"></asp:TextBox>
                                        </div>
                                    </div>
                                 </div>
                                <div class="two-column-form">
                                    <div class="row-detail" align="right">
                                        <p >Số Tạp chí:</p>
                                        <div class="input-control">
                                            <asp:TextBox runat="server" Width="80px" ID="txtNumber" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                        </div>
                    </div>

                <div class="three-column-form" align="left">
                    <div class="two-column ClearFix">
             
                        <div class="row-detail">
                            <br/>
                            <div class="button-control inline-box">
                                <div class="button-form">
                                    <asp:Button ID="btnStatic" runat="server" CssClass="lbButton" Width="98px" Text="Thống kê(s)">
                                    </asp:Button>&nbsp;
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnExportWord" runat="server" CssClass="lbButton" Width="100px"  Text="Xuất word"/>
                                </div>
                            </div>
                                
                        </div>
                    </div>
                </div>
            </div>
            <div class="ClearFix">
                <div class="table-form">
                    <asp:GridView ID="dtgStatis" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="100">
                        <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="5%"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Content" HeaderText="Tên tạp chí" ReadOnly="true">
                                <HeaderStyle Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Number" HeaderText="Số tạp chí" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FileName" HeaderText="Tên file" ReadOnly="true" >
                                <HeaderStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateCreate" HeaderText="Thời gian" ReadOnly="true" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="CountPages" HeaderText="Số trang" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate ><div align="center">Không có file nào được tải trong khoảng thời gian này!</div> </EmptyDataTemplate> 
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
			<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
		    <asp:ListItem Value="1">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="2">Xoá bản ghi thành công!</asp:ListItem>
            <asp:ListItem Value="3">Chọn biểu ghi bị lỗi xử lý cần xóa!</asp:ListItem>
		</asp:DropDownList>
        <asp:HiddenField ID="hidListIDCheck" runat="server" />
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Nhan đề tạp chí</asp:ListItem>
            <asp:ListItem Value="2">Số tạp chí</asp:ListItem>
            <asp:ListItem Value="3">Tên file</asp:ListItem>
            <asp:ListItem Value="4">Thời gian</asp:ListItem>
            <asp:ListItem Value="5">Số Trang</asp:ListItem>
        </asp:DropDownList>
        <div style="display:none">
            <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số: " />
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="ĐẠI HỌC GIAO THÔNG - VẬN TẢI<BR/>TP.HỒ CHÍ MINH" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="BÁO CÁO UPLOAD FILE " />
            <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="" />
        </div>
    </form>
    <script type="text/javascript">
        function checkId(id)
        {
            var listId = document.getElementById("hidListIDCheck").value;
            if(listId == "")
            {
                document.getElementById("hidListIDCheck").value = id;
            }
            else
            {
                if (listId.indexOf(id) >= 0)
                {
                    var arr = listId.split(",");
                    var index;
                    var strValue = "";
                    for (index = 0; index < arr.length; ++index)
                    {
                        if (arr[index] != id)
                        {
                            if (strValue == "") {
                                strValue = strValue + arr[index];
                            }
                            else {
                                strValue = strValue + "," + arr[index];
                            }
                        }
                    }
                    document.getElementById("hidListIDCheck").value = strValue;
                }
                else
                {
                    document.getElementById("hidListIDCheck").value = document.getElementById("hidListIDCheck").value + "," + id;
                }
            }
        }

        function alertDelete()
        {
            if (confirm('Bạn có chắc muốn xóa?'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
</body>
</html>
