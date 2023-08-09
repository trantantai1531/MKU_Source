<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WImportPatronExcel" CodeFile="WImportPatronExcel.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt giá trị ngầm định</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="2" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="row-detail">
                <h1 class="main-head-form">Import Dữ liệu từ file excel</h1>
                <h1 class="main-group-form">Nhập file excel cần import</h1>
                <div class="two-column">
                    <p>Đường dẫn file:</p>
                    <div>
                        <div class="input-control">

                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnImportData" runat="server"  CssClass="form-btn" Text="Import data" OnClientClick="myFunction()" />
                            &nbsp <asp:Button ID="btnDownloadFile" runat="server" CssClass="form-btn" Text="Download file mẫu" />
                        </div>
                        <div class="input-control" id="message" style="display: none;">
                            Đang xử lý vui lòng chờ
                        </div>
                    </div>

                </div>
                <div class="two-column-form">
                    <div class="table-form">
                    </div>

                </div>
                <h3>Tổng số bạn đọc từ file excel: <asp:Label ID="TotalPatronFromExcel" runat="server"></asp:Label></h3>
                <h3>Tổng số bạn đọc nhập thành công: <asp:Label ID="TotalPatronSuccess" runat="server"></asp:Label></h3>
                <h3>Tổng số bạn đọc nhập thất bại: <asp:Label ID="TotalPatronError" runat="server"></asp:Label></h3> 
                <h3>Tổng số bạn đọc trùng lặp: <asp:Label ID="TotalPatronLoop" runat="server"></asp:Label></h3>     
                <div style="padding: 10px 20px" id="SuccessInfor" runat="server" visible="false">
                    <h3>Danh sách bạn đọc nhập thành công:</h3>
                    <asp:GridView ID="gvPatronList" runat="server" Autogeneratecolumns=false>
                        <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                        <Columns>                    
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="5%"/>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>      
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Mã số bạn đọc" HeaderText="Mã số bạn đọc" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Tên bạn đọc" HeaderText="Tên bạn đọc" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Ghi chú" HeaderText="Ghi chú" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>                    
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="padding: 10px 20px" id="errorInfor" runat="server" visible="false">
                    <h3>Danh sách bạn đọc nhập không thành công:</h3>
                    <asp:GridView ID="gvPatronErrorList"  runat="server" Autogeneratecolumns=false>
                        <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                        <Columns>                    
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="5%"/>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>      
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Mã số bạn đọc" HeaderText="Mã số bạn đọc" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Tên bạn đọc" HeaderText="Tên bạn đọc" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="STT trên file" HeaderText="STT trên file" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>     
                            <asp:BoundField HeaderStyle-HorizontalAlign="Left" DataField="Ghi chú" HeaderText="Ghi chú" ReadOnly="true">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
        <input id="hidID" type="hidden" runat="server" />
        <input id="hidError" type="hidden" runat="server" name="hidError" value="0" />
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="3">Cả hai chỉ thị dữ liệu không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Không tồn tại</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật dữ liệu thành công
                !</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">

        function myFunction() {
            if (document.getElementById("FileUpload1").value != "") {
                var message = document.getElementById("message");
                console.log(document.getElementById("FileUpload1").value);
                message.style.display = null;
                return true;

            } else {
                alert("Vui lòng chọn file upload");
                return false;
            };
               
        }
    </script>
</body>
</html>
