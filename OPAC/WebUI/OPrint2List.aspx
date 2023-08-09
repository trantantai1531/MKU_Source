<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OPrint2List.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OPrint2List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/styles/FullFooter.css" type="text/css" rel="StyleSheet"></link>
    <script type="text/javascript">
      <!--
        function processPrintOptions() {
            var txtReportTitle = document.getElementById('txtReportTitle');
            var intOrder = 1; // $("input:checked").val();
            var rdTitle = document.getElementById('rdTitle');
            if (rdTitle.checked) {
                intOrder = 1;
            }
            else {
                var rdAuthor = document.getElementById('rdAuthor');
                if (rdAuthor.checked) {
                    intOrder = 2;
                }
                else {
                    intOrder = 3;
                }
            }
            var a = document.createElement("a");
            a.href = "OPrint.aspx?orderBy=" + intOrder.toString() + "&reportTitle=" + txtReportTitle.value;
            a.target = "_blank";
            document.body.appendChild(a);
            a.click();
        }
      //-->
      </script>
</head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <form id="form1" runat="server">
        <div id="divMain">
            <div class="web-size ClearFix">
                <h1 class="head-title"><span id="spLblExport2file" runat="server">Danh sách biên mục</span></h1>
                 <div class="input-control">
                    <div class="input-form">
                        <input type="text" class="tb-text" runat="server" value="Danh sách của tôi" id="txtReportTitle"/>
                    </div>
                </div>
                <div  style="padding: 20px 0px 10px 0px;">
                    <h2><span id="spOrder" runat="server">Sắp xếp theo:</span></h2>
                </div>
                <div class="radio-control">
                    <input type="radio" id="rdTitle" runat="server" name="rr" value="1" checked>
                    <label for="rdTitle"><span class="mif-spell-check"></span>&nbsp;Nhan đề</label>
                    <br />
                    <input type="radio" id="rdAuthor"  runat="server" name="rr" value="2">
                    <label for="rdAuthor"><span class="mif-users"></span>&nbsp;Tác giả</label>
                    <br />
                    <input type="radio" id="rdCallNo"  runat="server" name="rr" value="3">
                    <label for="rdCallNo"><span class="mif-barcode"></span>&nbsp;Mã xếp giá</label>
                </div>
                 <div class="col-left">
                    <span class="popup-modul">
                        <a class="btn-read" onclick="processPrintOptions()" title="Xem trước khi in" style="cursor:pointer;"><span class="icon-zoom-in">Xem trước khi in&nbsp;</span></a>&nbsp;&nbsp;
                    </span>
                </div>
                <footer class="site-footer editor-footer">
                    <div class="footer-left">
                        &nbsp;<a onclick="parent.showPopupMyList();" class="button mini-button embed-builder-button" style="cursor:pointer;">
                            <span id="spBackMyList" runat="server"  class="icon-arrow-left">&nbsp;Trở lại</span>
                        </a>
                    </div>
                </footer>
            </div>
        </div>        
    </form>
</body>
</html>
