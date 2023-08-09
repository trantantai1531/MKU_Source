<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OExport2FileUI.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OExport2FileUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/styles/FullFooter.css" type="text/css" rel="StyleSheet"></link>
    <script type="text/javascript">
      <!--
        function processExport2File() {
            var intType = 1; 
            var rdWord = document.getElementById('rdWord');
            if (rdWord.checked) {
                intType = 1;
            }
            else {
                intType = 2;
            }
            var a = document.createElement("a");
            a.href = "OExport2File.aspx?intType=" + intType.toString();
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
                <h1 class="head-title"><span id="spLblExport2file" runat="server">Xuất ra file</span></h1>
                <div class="radio-control">
                    <input type="radio" id="rdWord" runat="server" name="rr" value="1" checked>
                    <label for="rdWord"><span class="icon-file-word"></span>&nbsp;Microsoft Word</label>
                    <br />
                    <input type="radio" id="rdPDF"  runat="server" name="rr">
                    <label for="rdPDF"><span class="icon-file-pdf"></span>&nbsp;PDF</label>
                </div>
                 <div class="col-left">
                    <span class="popup-modul">
                        <a class="btn-read" onclick="processExport2File()" title="Xuất ra file" style="cursor:pointer;"><span class="icon-files">Xuất ra file&nbsp;</span></a>&nbsp;&nbsp;
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
