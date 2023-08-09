<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCata" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCata.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN">
<html>
	<HEAD  runat="server">
		<title>Trang biên mục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <style>
            .lbTextbox {
                border: 1px solid #c7c7c7;
            }
        </style>
        <script src="../../js/jquery-1.10.2.js" type="text/javascript"></script>
        <script src="../../js/jquery-ui.js" type="text/javascript"></script>
        <link href="../../js/jquery-ui.css"   rel="Stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript">
            $(function () {
                //Author
                var tag100 = document.getElementById("tag100$a");
                if (tag100) {
                    $(tag100).autocomplete({
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
                var tag110 = document.getElementById("tag110$a");
                if (tag110) {
                    $(tag110).autocomplete({
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
                var tag700 = document.getElementById("tag700$a");
                if (tag700) {
                    $(tag700).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag700).val(i.item.label);
                            u('700$a');
                            UpdateRecord('700$a', 0);
                        },
                        minLength: 1
                    });
                }
                //Author
                var tag710 = document.getElementById("tag710$a");
                if (tag710) {
                    $(tag710).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag710).val(i.item.label);
                            u('710$a');
                            UpdateRecord('710$a', 0);
                        },
                        minLength: 1
                    });
                }
                //Publisher
                var tag260b = document.getElementById("tag260$b");
                if (tag260b) {
                    $(tag260b).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag260b).val(i.item.label);
                            u('260$b');
                            UpdateRecord('260$b', 0);
                        },
                        minLength: 1
                    });
                }
                //Publisher year
                var tag260c = document.getElementById("tag260$c");
                if (tag260c) {
                    $(tag260c).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag260c).val(i.item.label);
                            u('260$c');
                            UpdateRecord('260$c', 0);
                        },
                        minLength: 1
                    });
                }
                //Series
                var tag490 = document.getElementById("tag490$a");
                if (tag490) {
                    $(tag490).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:4}",
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag490).val(i.item.label);
                            u('490$a');
                            UpdateRecord('490$a', 0);
                        },
                        minLength: 1
                    });
                }

                //Keyword
                var tag653 = document.getElementById("tag653$a");
                if (tag653) {
                    $(tag653).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag653).val(i.item.label);
                            u('653$a');
                            UpdateRecord('653$a', 0);
                        },
                        minLength: 1
                    });
                }

                //Subject heading
                var tag650 = document.getElementById("tag650$a");
                if (tag650) {
                    $(tag650).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            var vals = i.item.label.split("--");
                            if (vals[0]) {
                                $(tag650).val(vals[0]);
                                u('650$a');
                                UpdateRecord('650$a', 0);
                            }
                        },
                        minLength: 1
                    });
                }

                //Language
                var tag041 = document.getElementById("tag041$a");
                if (tag041) {
                    $(tag041).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag041).val(i.item.label);
                            u('041$a');
                            UpdateRecord('041$a', 0);
                        },
                        minLength: 1
                    });
                }

                //NML
                var tag060 = document.getElementById("tag060$a");
                if (tag060) {
                    $(tag060).autocomplete({
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
                        select: function (e, i) {
                            e.preventDefault();
                            $(tag060).val(i.item.label);
                            u('060$a');
                            UpdateRecord('060$a', 0);
                        },
                        minLength: 1
                    });
                }

                //DDC
                var tag082 = document.getElementById("tag082$a");
                if (tag082) {
                    $(tag082).autocomplete({
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
                            $(tag082).val(i.item.val);
                            u('082$a');
                            UpdateRecord('082$a', 0);
                        },
                        minLength: 1
                    });
                }
                //Medium Type
                var tag925 = document.getElementById("tag925");
                if (tag925) {
                    $(tag925).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:11}",
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
                            $(tag925).val(i.item.val);
                        },
                        minLength: 1
                    });
                }
                //Item Type
                var tag927 = document.getElementById("tag927");
                if (tag927) {
                    $(tag927).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: '<%=ResolveUrl("~/AutoComplete.asmx/AutocompleteDictionary")%>',
                                data: "{ 'prefixText': '" + request.term + "',dicId:10}",
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
                            $(tag927).val(i.item.val);
                        },
                        minLength: 1
                    });
                }

                //tag852$t
                var tag852 = document.getElementById("tag852$t");
                if (tag852 != null) {
                    document.getElementById("tag852$t").readOnly = true;
                }
            });
    </script>
	</HEAD>
	<body leftMargin="4" topMargin="4" rightmargin="3" onload="self.focus(); RestoreValue(); ReverdValue()"
		onKeyPress="microsoftKeyPress()">
		<form id="Form1" method="post" runat="server">
            <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
			<TABLE id="Table1" cellPadding="1" width="100%" border="0">
				<TR vAlign="bottom">
					<TD align="left" style="HEIGHT: 26px">
						<asp:label id="lblGroupBy" runat="server">Nhóm theo:</asp:label>
						<asp:hyperlink id="lnkGroup" runat="server">&nbsp;Nhóm</asp:hyperlink>&nbsp;|&nbsp;<asp:hyperlink id="lnkFunction" runat="server">Chức năng</asp:hyperlink>&nbsp;&nbsp;<asp:hyperlink id="lnkShowFieldName" runat="server">Hiện tên trường</asp:hyperlink>&nbsp;|&nbsp;<asp:hyperlink id="lnkShowGroupName" runat="server">Hiện tên nhóm</asp:hyperlink>
					<TD align="right" width="45%" style="HEIGHT: 26px">
						<asp:RadioButton id="optNew" GroupName="optNew" runat="server" Text="Mớ<U>i</U>" Checked="True"></asp:RadioButton>&nbsp;
						<asp:RadioButton id="optRenew" GroupName="optNew" runat="server" Text="<U>H</U>ồi cố"></asp:RadioButton>&nbsp;
						<asp:DropDownList id="ddlMarcForm" runat="server" AutoPostBack="False"></asp:DropDownList>
						<asp:Button id="btnChangeWS" runat="server" Text="Chuyển(c)" Width="74px"></asp:Button></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:Table id="tblResult" runat="server" CellPadding="1" CellSpacing="0" Width="100%"></asp:Table>
						<asp:Label id="lblContent" runat="server" Width="100%"></asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<input type="hidden" runat="server" id="txtJsmsg1" name="txtJsmsg1"> <input type="hidden" runat="server" id="txtJsmsg2" name="txtJsmsg2">
						<input type="hidden" runat="server" id="txtJsmsg3" name="txtJsmsg3"> <input type="hidden" runat="server" id="txtJsmsg4" name="txtJsmsg4">
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Hiện tên trường</asp:ListItem>
				<asp:ListItem Value="3">Tắt tên trường</asp:ListItem>
				<asp:ListItem Value="4">Hiện tên vùng</asp:ListItem>
				<asp:ListItem Value="5">Tắt tên vùng</asp:ListItem>
				<asp:ListItem Value="6">Giá trị trường phải là số</asp:ListItem>
				<asp:ListItem Value="7">Ngày tháng nhập vào không hợp lệ (khuôn dạng đúng dd/mm/yyyy)</asp:ListItem>
				<asp:ListItem Value="8">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="9">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="10">Chọn tệp</asp:ListItem>
				<asp:ListItem Value="11">Chỉ dẫn đầu biểu ghi</asp:ListItem>
				<asp:ListItem Value="12">Từ điển</asp:ListItem>
				<asp:ListItem Value="13">Trợ giúp</asp:ListItem>
				<asp:ListItem Value="14">Gắn tệp</asp:ListItem>
				<asp:ListItem Value="15">Sinh giá trị</asp:ListItem>
				<asp:ListItem Value="16">Từ chuẩn</asp:ListItem>
				<asp:ListItem Value="17">TVQG Cutter (Nhan đề)</asp:ListItem>
				<asp:ListItem Value="18">TVQG Cutter (Tác giả)</asp:ListItem>
				<asp:ListItem Value="19">Dịch chuyển tới thẻ</asp:ListItem>
				<asp:ListItem Value="20">Trường bắt buộc phải nhập dữ liệu</asp:ListItem>
				<asp:ListItem Value="21">Liên kết</asp:ListItem>
				<asp:ListItem Value="22">Phân loại</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</html>
