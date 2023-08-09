<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OLibrarySubject.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OLibrarySubject" %>

<%@ Register Src="UFooter.ascx" TagName="UFooter" TagPrefix="uc1" %>
<%@ Register Src="UHeader.ascx" TagName="UHeader" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/OBrowse.js"></script>
    <script language="JavaScript" type="text/javascript" src="Resources/StyleSheet/ssc/java/metro.js"></script>
    <style>
        .treeview .leaf .icon {
            display: none;
        }

        #txtSearchVocabulary {
            background: #fff none repeat scroll 0 0;
            border: 1px solid #e2e2e2;
            color: #333;
            margin: 5px 0 6px;
            padding: 5px;
            width: 300px;
        }

        .ui-autocomplete {
            max-height: 140px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
            /* add padding to account for vertical scrollbar */
            padding-right: 20px;
        }
        /* IE 6 doesn't support max-height
 * we use height instead, but this forces the menu to always be this tall
 */
        * html .ui-autocomplete {
            height: 100px;
        }
    </style>
</head>
<body class="metro" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px" id="top">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size sort-page ClearFix">
                <h1><span class="mif-brightness-auto"></span>TRA CHỦ ĐỀ</h1>
                <h2>Nhập vào chủ đề cần tìm kiếm:</h2>
                <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
                <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
                <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
                    rel="Stylesheet" type="text/css" />
                <script type="text/javascript">
                    $(function () {

                        $("[id$=txtSearchVocabulary]").autocomplete({
                            source: function (request, response) {
                                var type = $('#dllDictionaryType').val();
                                $.ajax({
                                    url: '<%=ResolveUrl("~/OLibrarySubject.aspx/GetSubject")%>',
                                    data: "{ 'prefix': '" + request.term + "'}",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                label: item.split('------')[0],
                                                val: item.split('------')[1]
                                            }
                                        }));
                                    },
                                    error: function (response) {
                                        alert(response.responseText);
                                    },
                                    failure: function (response) {
                                        alert(response.responseText);
                                    }
                                });
                            },

                            scrollHeight: 250,
                            select: function (e, i) {

                                $("#txtSearchVocabulary").val(i.item.value);
                                $("#lblMean").html(i.item.value);


                            },
                            minLength: 1
                        });
                    });
                </script>
                <b>Chủ đề :</b>
                <asp:TextBox ID="txtSearchVocabulary" runat="server" />
                <asp:Button ID="btnSearchVocabulary" runat="server" Text="Tra Cứu" />
                <br />


                <asp:Label ID="Label1" runat="server" Text="Chủ đề đã chọn: " Font-Bold="True"></asp:Label>

                <asp:Label ID="lblMean" runat="server" Text=""></asp:Label>

            </div>


            <div class="sort-result">
                <asp:Literal runat="server" ID="ltrList"></asp:Literal>
            </div>
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>

    </form>
</body>
</html>


