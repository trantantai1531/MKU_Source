<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OSend2Email.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OSend2Email" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/styles/FullFooter.css" type="text/css" rel="StyleSheet"></link>
    <script type="text/javascript">
      <!--
        function processSend2Email() {
            var txtEmail = document.getElementById('txtEmail');
            if (ValidateEmail(txtEmail)) {
                var a = document.createElement("a");
                a.href = "OSendEmail.aspx?EmailTo=" + txtEmail.value;
                a.target = "_blank";
                document.body.appendChild(a);
                a.click();
            }
            else {
                var spEmailInValid = document.getElementById('spEmailInValid');
                parent.showNotifyCart('error', spEmailInValid.innerHTML);
            }
        }

        function ValidateEmail(inputText) {
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (inputText.value.match(mailformat)) {
                return true;
            }
            else {
                return false;
            }
        } 
      //-->
      </script>
</head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <form id="form1" runat="server">
        <div id="divMain">
            <div class="web-size ClearFix">
                <h1 class="head-title"><span id="spLblExport2file" runat="server">Gửi đến email</span></h1>
                <div class="input-control">
                    <div class="input-form">
                        <input type="text" class="tb-text" runat="server" id="txtEmail"/>
                    </div>
                </div>
                 <div class="col-left">
                    <span class="popup-modul">
                        <a class="btn-read" onclick="processSend2Email()" title="Gửi email" style="cursor:pointer;"><span class="icon-mail">Gửi email&nbsp;</span></a>&nbsp;&nbsp;
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
        <div style="display:none">
            <span id="spEmailInValid" runat="server">Email nhập vào không hợp lệ...</span>
        </div>
    </form>
</body>
</html>
