<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OLogin.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OLogin" %>

<!DOCTYPE html>

<html>
<head>
    <title>Trường Đại Học Cửu Long</title>
    <style type="text/css">
        .tieude_tbc {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            color: #000066;
            width: 100%;
            border-bottom: 1px dotted;
            padding: 10px 0;
        }
        .nomargin {
            margin: 0px;
        }
        .FromLogin{
                width: 400px;
                margin: 10px auto 10px auto;
                border: #00F 1px solid;
                -webkit-border-radius: 5px;
                -moz-border-radius: 5px;
                border-radius: 5px;
                padding-bottom: 20px;
                font-family: Tahoma,Verdana,Arial;
                color: initial;
        }
        .th{
            border: dotted;
        }
        .titleHeader{
            font-weight: bold;
        }
        .lable{
            color: initial;
        }
        .buton{
            width:100px;
            height:27px;
            font-size:inherit;
        }
        .input{
            height:25px;
            width:100%;
        }
    </style>
     <script type="text/javascript">
         function onRaiseLogin() {
             var txtSothe = document.getElementById('txtSothe');
             if (txtSothe.value.toString().trim() == '') {
                 var spEmptyCard = document.getElementById('spEmptyCard');
                 parent.showNotify(1, spEmptyCard.innerHTML);
                 showInvalidInfo(spEmptyCard.innerHTML);
                 return;
             }
             //var txtMatkhau = document.getElementById('txtMatkhau');
             //if (txtMatkhau.value.toString().trim() == '') {
             //    var spEmptyPassword = document.getElementById('spEmptyPassword');
             //    parent.showNotify(1, spEmptyPassword.innerHTML);
             //    showInvalidInfo(spEmptyPassword.innerHTML);
             //    return;
             //}
             onSubmitLogin();
         }
         function showInvalidInfo(mes) {
             var spInfo = document.getElementById('spInfo');
             spInfo.innerHTML = mes; 
         }
         function onSubmitLogin() {
             var onSubmit = document.getElementById('onSubmit');
             onSubmit.click();
         }
         function setFrameTitle() {
             var spPopupLogin = parent.document.getElementById('spPopupLogin');
             if (spPopupLogin) {
                 var spSetPassword = document.getElementById('spSetPassword');
                 spPopupLogin.innerHTML = spSetPassword.innerHTML;
             }
         }
         //console.log(window.location);
         //if (window.location.pathname.indexOf('OLoginRequestGV') === 1) { console.log(123); $('.guide').hide(); }
    </script>
    <%--<script src="https://apis.google.com/js/platform.js" async defer></script>
    <script src="https://apis.google.com/js/api:client.js"></script>
    <script>
        var googleUser = {};
        var startApp = function() {
            gapi.load('auth2', function(){
                auth2 = gapi.auth2.init({
                    client_id: '<%=ConfigurationSettings.AppSettings("ClientId_Google") %>',
                    scope: 'profile email'
                });
                attachSignin(document.getElementById('customBtn'));
            });
        };

        function attachSignin(element) {
            auth2.attachClickHandler(element, {},
                function (googleUser) {
                    var strEmail = googleUser.getBasicProfile().getEmail();
                    var hidEmail = document.getElementById("hidEmail");
                    hidEmail.value = strEmail;
                    document.getElementById("btnLoginForGoogle").click();
                }, function (error) {
                    alert(JSON.stringify(error, undefined, 2));
                });
        }
        
    </script>--%>
</head>
<body  style="margin-top:15px;margin-left:0px;margin-right:0px;margin-bottom:0px;background:white">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form method="post" action="OLogin.aspx?comment=<%=Request("comment")%>&patron=<%=Request("patron")%>&viewer=<%=Request("viewer")%>&RequestLogin=<%=Request("RequestLogin")%>">
            <table class="FromLogin" border="0" cellspacing="2" cellpadding="2">
            <thead><tr><th colspan="2" class="tieude_tbc">Đăng nhập vào trang Thư viện</th></tr></thead>
              
            <tbody><tr>
              <td width="36%" rowspan="2" align="left" class="nomargin" style="background:url(./Images/Icons/login.png) no-repeat center">&nbsp;</td>
              <td class="lable" width="64%" height="54" ><labe >Số thẻ:<br/>
              <input class="input" name="txtSothe" type="text" id="txtSothe" size="25"></labe></td>
            </tr>
            <tr>
              <td class="lable" height="51"><label>Mật khẩu:<br/>
              <input class="input" name="txtMatkhau" type="password" id="txtMatkhau" size="25"></label></td>
            </tr>
            <tr>
              <td height="35" align="center" valign="middle">&nbsp;</td>
              <td height="35" align="left">
                <button class="buton" onclick="onRaiseLogin();return false;" style="float:left;">Đăng nhập</button>
                <%--<div class="g-signin2" id="customBtn" data-height="27" style="float:left; margin-left:15px; margin-top:-1px;"></div>--%>
              </td>  
            </tr>
            <tr>
                <td colspan="2">
                    <p style="text-align:center;">
                    <span id="spInfo"  runat="server" style="color:Red;font-weight:bold;">
                        <label runat="server" id="lblShowText"></label> 
                    </span>
                    </p>
                </td>
            </tr>
        </tbody></table>        
          <div id="name"></div>
          <script>startApp();</script>
    </form>
    <div class="guide" style="width:500px;margin:auto; line-height:180%; text-align:justify; display:none;">
        <h4 class="titleHeader">Hướng dẫn:</h4>
         <p>- Sinh viên và Cán bộ giảng viên dùng tài khoản là số thẻ thư viện (mật khẩu = số thẻ) để đăng nhập.</p> 
    </div>
    <div class="guide" style="width:500px;margin:auto; line-height:180%; text-align:justify; display:none;">
        <label style="cursor:default;">- Nếu bạn quên mật khẩu hoặc muốn đổi mật khẩu hãy <a href="OUserActive.aspx?comment=<%=Request("comment")%>" onclick="setFrameTitle()">Bấm vào đây</a></label> 
        <p></p>
    </div>
    <form id="form1" runat="server">
        <div style="display:none">
            <asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Số thẻ hoặc mật khẩu không hợp lệ !</asp:ListItem>
				<asp:ListItem Value="1">Hiện tại thẻ này đang bị khoá !</asp:ListItem>
				<asp:ListItem Value="2">Số thẻ không được để trống !</asp:ListItem>
				<asp:ListItem Value="3">Mật khẩu không được để trống !</asp:ListItem>
				<asp:ListItem Value="4">Hiện tại thẻ này đã hết hạn sử dụng !</asp:ListItem>
                <asp:ListItem Value="5">Vui lòng chọn đúng cách đăng nhập ( GV hoặc SV) !</asp:ListItem>
			</asp:DropDownList>
            <span id="spSetPassword" runat="server">Đặt mật khẩu</span>
            <span id="spEmptyCard" runat="server">Số thẻ là rỗng</span> 
            <span id="spEmptyPassword" runat="server">Mật khẩu là rỗng</span> 
            <input type="hidden" runat="server" id="hidEmail" name="hidEmail" value="" />
            <asp:Button ID="btnLoginForGoogle" runat="server" Text="btnLoginForGoogle" />
        </div>
    </form>
    <script type="text/javascript">
        //console.log(window.location.href.indexOf('gv'));
        if (window.location.href.indexOf('isGV') === -1) {
            $('.guide').show();
        }
    </script>
    <script type="text/javascript">
      //  function onSignIn(googleUser) {
      //    // Useful data for your client-side scripts:
      //    var profile = googleUser.getBasicProfile();
      //    if (profile != null)
      //    {
      //        var strEmail = profile.getEmail();
      //        var hidEmail = document.getElementById("hidEmail");
      //        hidEmail.value = strEmail;
      //        document.getElementById("btnLoginForGoogle").click();
      //    }
      //}
    </script>
</body>
</html>
