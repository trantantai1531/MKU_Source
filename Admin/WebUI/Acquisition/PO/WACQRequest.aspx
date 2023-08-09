<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQRequest" CodeFile="WACQRequest.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt mua ấn phẩm đơn bản</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        #Background{
            position:fixed;
            top:0;
            left:0;
            bottom:0;
            right:0;
            overflow:hidden;
            padding:0;
            margin:0;
            background-color:#f0f0f0;
            filter:alpha(opacity=80);
            opacity:0.8;
            z-index:99999;
        }
        #Progress {
          position: fixed;
          top: 40%;
          left:40%;
          width: 20%;
          height: 20%;
          z-index:100000;
          background-color: #ddd;
          border:1px solid Gray;
          background-image:url('/images/loading.gif');
          background-repeat:no-repeat;
          background-position:center;
        }

        #myBar {
          position: absolute;
          width: 0%;
          height: 100%;
          background-color: #4CAF50;
        }

        #label {
          text-align: center;
          line-height: 30px;
          color: white;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <h1 class="main-head-form">Lập yêu cầu bổ sung ấn phẩm đơn bản</h1>
                    <div class="three-column ClearFix">
                        <div class="three-column-form">
                            <div class="row-detail">
                                <p>Nhan đề : <asp:Label ID="lblNote1" Runat="server" style="display: none" ForeColor="red" ToolTip="Trường bắt buộc">(*)</asp:Label> <p class="error-star">(*)</p>&nbsp;<asp:hyperlink id="lnkCheckExists" runat="server" Width="80px">Kiểm tra</asp:hyperlink> </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtTitle"  runat="server" ></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Nhà xuất bản :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtPublisher"  runat="server" ></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Ngôn ngữ :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlLanguage" runat="server" Width=""></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Nước xuất bản :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlCountry" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Đơn giá :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtUnitPrice" runat="server"  MaxLength="10">0</asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Người lập yêu cầu :</p>
                                <div class="input-control control-disabled">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtRequester"  runat="server"  Enabled="False"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="three-column-form">
                            <div class="row-detail">
                                <p>Tác giả :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtAuthor" runat="server"></asp:textbox>

                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Năm xuất bản :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtPubYear" runat="server" ></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Dạng tài liệu :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                               <asp:dropdownlist id="ddlItemType" runat="server" ></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Kiểu tài liệu :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                               <asp:dropdownlist id="ddlLoanType" runat="server" ></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Số lượng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtRequestedCopies" runat="server"  MaxLength="5">1</asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Ghi chú :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtNote" runat="server" ></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="three-column-form">
                            <div class="row-detail">
                                <p>Lần xuất bản :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtEdition" runat="server" Width=""></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>ISBN:</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input" id="txtISBN" runat="server" Width=""></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Vật mang tin :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlMedium" runat="server" Width=""></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Mức độ quan trọng :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlUrgency" runat="server">
							                        <asp:ListItem Value="1">Bình thường</asp:ListItem>
							                        <asp:ListItem Value="2">Cao</asp:ListItem>
							                        <asp:ListItem Value="3">Rất cao</asp:ListItem>
						                        </asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Đơn vị tính :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:dropdownlist id="ddlCurrency" runat="server"></asp:dropdownlist>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Nguồn bổ sung</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlAcqSource" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Lý do bổ sung :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:textbox CssClass="text-input" id="txtAdditionalBy" runat="server" Width=""></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control" style="text-align: center">
                            <div class="button-form">
                               <asp:button id="btnInsert" runat="server" Text="Lập yêu cầu(u)" CssClass="form-btn"></asp:button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnReset" runat="server" Text="Đặt lại(r)" CssClass="form-btn"></asp:button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnZ3950" runat="server" Text="Tải về qua Z3950(z)" CssClass="form-btn"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content-form">
                    <h1 class="main-head-form">Import danh sách yêu cầu bổ sung ấn phẩm đơn bản</h1>
                    <div class="row-detail">
                        <p>Đường dẫn file:</p>                       
                            
                        <div class="input-control">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnImportData" runat="server" CssClass="form-btn" OnClientClick="return myFunction()" Text="Import data" />
                            &nbsp <asp:Button ID="btnDownloadFile" runat="server" CssClass="form-btn" Text="Download file mẫu" />  
                            <p style="vertical-align:text-bottom;margin:2px 0px 0px 150px">Kiểm tra dữ liệu trước khi Import:</p>
                            <asp:Button runat="server" ID="btnCheckFile" CssClass="form-btn" Text="Kiểm tra"/>       
                        </div>

                        <div class="input-control" id="message" style="display:none">
                            Đang xử lý vui lòng chờ
                            <p><asp:Label ID="LabelUpdateProgress" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="input-control" id="Div1" runat="server">
                            <asp:Label ID="lbSuccess" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lbTotalInput" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblErrorDataCat" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblErrorItemHolding" runat="server" Text=""></asp:Label><br />
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
        

        <asp:DropDownList ID="ddlLabel" runat="server" Visible="false" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Lỗi trong quá trình xử lý</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật dữ liệu thành công</asp:ListItem>
            <asp:ListItem Value="4">Bản ghi không được cập nhật nếu giá trị trường này trống</asp:ListItem>
            <asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật bản ghi có nhan đề: </asp:ListItem>
            <asp:ListItem Value="7">Bạn không được cấp quyền sử dụng tính năng này. </asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="ddlLabelImport" runat="server" Visible="false" Width="0">
            <asp:ListItem Value="0">Tổng số dòng nhập từ file Excel: </asp:ListItem>
            <asp:ListItem Value="1">Nhập khẩu dữ liệu: </asp:ListItem>
            <asp:ListItem Value="2">Số dòng đã thực hiện thành công: </asp:ListItem>
            <asp:ListItem Value="3">Những dòng không import được dữ liệu: </asp:ListItem>
            <asp:ListItem Value="4">File không đúng định dạng theo mẫu</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="ddlColumnFileImport" runat="server" Visible="false" Width="0">
            <asp:ListItem Value="STT">STT</asp:ListItem>
            <asp:ListItem Value="Title">Nhan đề</asp:ListItem>
            <asp:ListItem Value="Author">Tác giả</asp:ListItem>
            <asp:ListItem Value="Publisher">Nhà XB</asp:ListItem>
            <asp:ListItem Value="PubYear">Năm XB</asp:ListItem>
            <asp:ListItem Value="Edition">Lần xuất bản</asp:ListItem>
            <asp:ListItem Value="ISBN">ISBN</asp:ListItem>
            <asp:ListItem Value="Language">Ngôn ngữ</asp:ListItem>
            <asp:ListItem Value="Country">Nước xuất bản</asp:ListItem>
            <asp:ListItem Value="ItemType">Dạng tài liệu</asp:ListItem>
            <asp:ListItem Value="LoanType">Kiểu tư liệu</asp:ListItem>
            <asp:ListItem Value="Urgency">Mức độ quan trọng</asp:ListItem>
            <asp:ListItem Value="Medium">Vật mang tin</asp:ListItem>
            <asp:ListItem Value="RequestedCopies">Số lượng</asp:ListItem>
            <asp:ListItem Value="UnitPrice">Đơn giá</asp:ListItem>
            <asp:ListItem Value="Currency">Đơn vị tính</asp:ListItem>
            <asp:ListItem Value="Requester">Người lập yêu cầu</asp:ListItem>
            <asp:ListItem Value="AdditionalBy">Lý do bổ sung</asp:ListItem>
            <asp:ListItem Value="Note">Ghi chú</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="ddlLanguageFind" runat="server" Visible="false" Width="0"></asp:DropDownList>
        <asp:DropDownList ID="ddlCountryFind" runat="server" Visible="false" Width="0"></asp:DropDownList>
        <asp:DropDownList ID="ddlItemTypeFind" runat="server" Visible="false" Width="0"></asp:DropDownList>
        <asp:DropDownList ID="ddlMediumFind" runat="server" Visible="false" Width="0"></asp:DropDownList>

        <input id="txtRequestID" type="hidden" name="txtRequestID" runat="server" style="z-index: 101; left: 0px; position: absolute; top: 440px"/>
    </form>
</body>
</html>
