<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCataForm" CodeFile="WCataForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCataForm</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <script src="../../js/jquery-1.10.2.js" type="text/javascript"></script>
        <script src="../../js/jquery-ui.js" type="text/javascript"></script>
        <link href="../../js/jquery-ui.css"   rel="Stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript">
            $(function () {
                //Author
                var txt100_a = document.getElementById("txt100_a");
                if (txt100_a) {
                    $(txt100_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:1}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }
                //Author
                var txt110_a = document.getElementById("txt110_a");
                if (txt110_a) {
                    $(txt110_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:1}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }
                //Publisher
                var txt260_b = document.getElementById("txt260_b");
                if (txt260_b) {
                    $(txt260_b).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:2}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }
                //Publisher year
                var txt260_c = document.getElementById("txt260_c");
                if (txt260_c) {
                    $(txt260_c).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:9}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }

                //Keyword
                var txt653_a = document.getElementById("txt653_a");
                if (txt653_a) {
                    $(txt653_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:3}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }

                //Subject heading
                var txt650_a = document.getElementById("txt650_a");
                if (txt650_a) {
                    $(txt650_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:5}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }

                //Language
                var txt041_a = document.getElementById("txt041_a");
                if (txt041_a) {
                    $(txt041_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:6}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[0]
                                        }
                                    }))
                                }
                            });
                        },
                        minLength: 1
                    });
                }


                //DDC
                var txt082_a = document.getElementById("txt082_a");
                if (txt082_a) {
                    $(txt082_a).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:8}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('@@@')[1] + ' : ' + item.split('@@@')[0],
                                            val: item.split('@@@')[1]
                                        }
                                    }))
                                }
                            });
                        },
                        select: function (e, i) {
                            e.preventDefault();
                            $(txt082_a).val(i.item.val);
                        },
                        minLength: 1
                    });
                }
            });
    </script>
    <style type="text/css">
        .input-control .dropdown-form
        {
            padding-top:1px;
            padding-bottom:1px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="center-form">
                <h1 class="main-head-form">Biên mục sơ lược</h1>
                <div class="main-form">
                    <asp:HyperLink ID="lnkListCataQueu" runat="server"> Danh sách biên mục sơ lược</asp:HyperLink>
                    <div class="ClearFix">
                        <div class="col-left-6">
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Ấn phẩm theo đơn đặt :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlAcqPO_ITEM" runat="server"></asp:DropDownList><input id="txtCodePO" type="hidden" size="1" name="txtCodePO" runat="server"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Kiểu bản ghi :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlRecType" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Dạng tài liệu :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlItemType" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Kiểu tài liệu :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                               <asp:dropdownlist id="ddlLoanType" runat="server" ></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Mẫu biên mục :</p>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFormID" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>ISBN [020$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt020_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Ngôn ngữ [041$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt041_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Tác giả [100$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt100_a" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Tác giả tập thể [110$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt110_a" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <span>Nhan đề chính [245$a] : &nbsp;</span><asp:Label ID="lblComment" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label><br />
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt245_a" CssClass="text-input" runat="server" ToolTip="Trường bắt buộc phải nhập dữ liệu"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Số thứ tự của tập [245$n] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt245_n" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Nhan đề song song [245$b] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt245_b_ss" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Phụ đề [245$b] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt245_b_pd" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Thông tin trách nhiệm [245$c] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt245_c" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Lần xuất bản [250$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt250_a" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>
                                            Nhà XB [260$b] :
                                        <asp:HyperLink ID="lnkHelp" runat="server" CssClass="lbLinkFunction"> Giúp</asp:HyperLink>
                                        </p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt260_b" CssClass="text-input" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Số trang [300$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt300_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <p>Khuôn khổ [300$c] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt300_c" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="row-detail">
                                        <p>Mục từ bổ trợ chủ đề - Thuật ngữ chủ điểm [650$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt650_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="row-detail">
                                        <p>Thuật ngữ chỉ mục - Không kiểm soát [653$a] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt653_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Text="Cập nhật(c)"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Đặt lại(d)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-right-4">
                            <div class="row-detail">
                                <p>Cấp thư mục :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLevelDir" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Vật mang tin :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlMedium" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Độ mật :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLevelSec" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>ISSN [022$a] :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txt022_a" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Phân loại DDC [082$a] :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txt082_a" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Tên tập [245$p] :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txt245_p" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Nơi XB [260$a]:</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txt260_a" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Năm XB [260$c] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt260_c" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <p>Đặc điểm vật lý [300$b] :</p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txt300_b" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row-detail">
                                <p>Tư liệu đi kèm [300$e] :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txt300_e" CssClass="text-input" runat="server" Width=""></asp:TextBox>
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
                                                <asp:TextBox ID="txtAdditionalBy" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            

                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnZ3950" CssClass="form-btn" runat="server" Text="Tải về qua Z39.50(z)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

        <input type="hidden" size="1" name="quantity">
        <input type="hidden" size="1" name="reason">
        <input type="hidden" size="1" name="itemID">
        <input type="hidden" size="1" name="price">
        <input type="hidden" size="1" name="languageID">
        <input type="hidden" name="hidLanguage" id="hidLanguage">
        <input type="hidden" size="1" name="CountryPubID">
        <input type="hidden" name="hidCountryPub" id="hidCountryPub">
        <input type="hidden" name="hidUnitPrice" id="hidUnitPrice" value="0">


        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Trường nhan đề bắt buộc!</asp:ListItem>
            <asp:ListItem Value="3">---------- Chọn ấn phẩm ----------</asp:ListItem>
            <asp:ListItem Value="4">Cập nhật thành công</asp:ListItem>
            <asp:ListItem Value="5">---Chọn mẫu biên mục---</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa chọn mẫu biên mục.</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
