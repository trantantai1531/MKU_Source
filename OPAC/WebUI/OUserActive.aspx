<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OUserActive.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OUserActive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>   
    <script type="text/javascript">
        function onRaiseActive() {
            var txtSothe = document.getElementById('txtSothe');
            if (txtSothe.value.toString().trim() == '') {
                var spEmptyCard = document.getElementById('spEmptyCard');
                parent.showNotify(1, spEmptyCard.innerHTML);
                showInvalidInfo(spEmptyCard.innerHTML);
                return;
            }
            var txtNgaycap = document.getElementById('txtNgaycap');
            if (txtNgaycap.value.toString().trim() == '') {
                var spEmptyIssuaDate = document.getElementById('spEmptyIssuaDate');
                parent.showNotify(1, spEmptyIssuaDate.innerHTML);
                showInvalidInfo(spEmptyIssuaDate.innerHTML);
                return;
            }
            else {
                if (!CheckDate(txtNgaycap, 'dd/mm/yyyy')) {
                    var spInvalidIssuaDate = document.getElementById('spInvalidIssuaDate');
                    parent.showNotify(1, spInvalidIssuaDate.innerHTML);
                    showInvalidInfo(spInvalidIssuaDate.innerHTML);
                    return;
                }
            }
            var txtNgaysinh = document.getElementById('txtNgaysinh');
            if (txtNgaysinh.value.toString().trim() == '') {
                var spEmptyBirthday = document.getElementById('spEmptyBirthday');
                parent.showNotify(1, spEmptyBirthday.innerHTML);
                showInvalidInfo(spEmptyBirthday.innerHTML);
                return;
            }
            else {
                if (!CheckDate(txtNgaysinh, 'dd/mm/yyyy')) {
                    var spInvalidBirthday = document.getElementById('spInvalidBirthday');
                    parent.showNotify(1, spInvalidBirthday.innerHTML);
                    showInvalidInfo(spInvalidBirthday.innerHTML);
                    return;
                }
            }
            var txtMatkhau = document.getElementById('txtMatkhau');
            if (txtMatkhau.value.toString().trim() == '') {
                var spEmptyPassword = document.getElementById('spEmptyPassword');
                parent.showNotify(1, spEmptyPassword.innerHTML);
                showInvalidInfo(spEmptyPassword.innerHTML);
                return;
            }
            if (txtMatkhau.value.toString().trim().length < 4) {
                var spInvalidPasswordLength = document.getElementById('spInvalidPasswordLength');
                parent.showNotify(1, spInvalidPasswordLength.innerHTML);
                showInvalidInfo(spInvalidPasswordLength.innerHTML);
                return;
            }
            var txtMatkhau1 = document.getElementById('txtMatkhau1');
            if (txtMatkhau1.value.toString().trim() != txtMatkhau.value.toString().trim()) {
                var spInvalidPasswordRule = document.getElementById('spInvalidPasswordRule');
                parent.showNotify(1, spInvalidPasswordRule.innerHTML);
                showInvalidInfo(spInvalidPasswordRule.innerHTML);
                txtMatkhau1.value = "";
                txtMatkhau.focus();
                return;
            }
            onSubmitActive();
        }
        function showInvalidInfo(mes) {
            var spInfo = document.getElementById('spInfo');
            spInfo.innerHTML = mes;
        }
        function onSubmitActive() {
            var onSubmit = document.getElementById('onSubmit');
            onSubmit.click();
        }

        function CheckDate(objDateField, strDateFormat) {
            var bolReturn = true;
            strDateFormat = strDateFormat.toLowerCase();
            mdateval = eval(objDateField).value;
            switch (strDateFormat) {
                case 'dd/mm/yyyy':
                    if (mdateval != "") {
                        mday = mdateval.substring(0, mdateval.indexOf("/"));
                        mmonth = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"));
                        myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
                        mdate = new Date(mmonth + "/" + mday + "/" + myear);
                        cday = mdate.getDate();
                        cmonth = mdate.getMonth() + 1;
                        cyear = mdate.getYear();
                        if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4) || (myear.length > 4) || (myear < 1753)) {
                            eval(objDateField).value = "";
                            eval(objDateField).focus();
                            bolReturn = false;
                        }
                        break;
                    }
                case 'mm/dd/yyyy':
                    if (mdateval != "") {
                        mmonth = mdateval.substring(0, mdateval.indexOf("/"));
                        mday = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"))
                        myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
                        mdate = new Date(mmonth + "/" + mday + "/" + myear);
                        cday = mdate.getDate();
                        cmonth = mdate.getMonth() + 1;
                        cyear = mdate.getYear();
                        if (parseFloat(mday) != parseFloat(cday) || parseFloat(mmonth) != parseFloat(cmonth) || (myear != cyear) || (myear.length != 4) || (myear < 1753)) {
                            eval(objDateField).value = "";
                            eval(objDateField).focus();
                            bolReturn = false;
                        }
                        break;
                    }
            }
            return bolReturn;
        }
    </script>
</head>
<body  class="metro"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <form  method="post" action="OUserActive.aspx?comment=<%=Request("comment")%>">
        <div class="container">
            <div class="grid fluid">
                <p></p>
                <div class="row">
                    <div class="span2">
                        <label>Số thẻ</label>
                    </div>
                    <div class="span10">
                        <div class="input-control text warning-state" data-role="input-control" style="width:90%;">
	                        <input type="text" placeholder="Nhập số thẻ"  autofocus="" id="txtSothe" name="txtSothe">
	                        <button class="btn-clear" tabindex="-1" type="button"></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="span2">
                        <label>Ngày cấp</label>
                    </div>
                    <div class="span10">
                        <div class="input-control text warning-state" data-role="input-control" style="width:90%;">
	                        <input type="text" placeholder="Nhập ngày cấp (dd/mm/yyyy)" id="txtNgaycap" name="txtNgaycap">
	                        <button class="btn-clear" tabindex="-1" type="button"></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="span2">
                        <label>Ngày sinh</label>
                    </div>
                    <div class="span10">
                        <div class="input-control text warning-state" data-role="input-control" style="width:90%;">
	                        <input type="text" placeholder="Nhập ngày sinh (dd/mm/yyyy)"  id="txtNgaysinh" name="txtNgaysinh">
	                        <button class="btn-clear" tabindex="-1" type="button"></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="span2">
                        <label>Mật khẩu</label>
                    </div>
                    <div class="span10">
                        <div class="input-control password warning-state" data-role="input-control"  style="width:90%;">
                            <input type="password" placeholder="Nhập mật khẩu" id="txtMatkhau" name="txtMatkhau">
                            <button class="btn-reveal" tabindex="-1" type="button"></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="span2">
                        <label>Gõ lại mật khẩu</label>
                    </div>
                    <div class="span10">
                        <div class="input-control password warning-state" data-role="input-control"  style="width:90%;">
                            <input type="password" placeholder="Gõ lại mật khẩu" id="txtMatkhau1" name="txtMatkhau1">
                            <button class="btn-reveal" tabindex="-1" type="button"></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="span6">
                        <button class="image-button bg-darkGreen fg-white image-left place-right" onclick="onRaiseActive();return false;">
                            Nhập
                            <i class="icon-floppy bg-green fg-white"></i>
                        </button>
                        <button id="onSubmit" name="onSubmit" style="display:none;"></button>  
                    </div>
                    <div class="span6">
                        <button class="image-button bg-darkGreen fg-white image-left" type="reset">
                            Đặt lại
                            <i class="icon-spin bg-green fg-white"></i>
                        </button>
                    </div>
                </div>
                <p></p>
                <div class="row">
                    <div class="span12">
                        <p style="text-align:center;">
                            <span id="spInfo"  runat="server" style="color:Red;font-weight:bold;"></span>
                        </p>
                    </div>
                </div>
            </div>
        </div>        
    </form>
    <form id="form1" runat="server">
        <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
            <span id="spEmptyCard" runat="server">Số thẻ là rỗng</span> 
            <span id="spEmptyIssuaDate" runat="server">Ngày cấp là rỗng</span> 
            <span id="spInvalidIssuaDate" runat="server">Ngày cấp không hợp lệ</span> 
            <span id="spEmptyBirthday" runat="server">Ngày sinh là rỗng</span>         
            <span id="spInvalidBirthday" runat="server">Ngày sinh không hợp lệ</span> 
            <span id="spEmptyPassword" runat="server">Mật khẩu là rỗng</span> 
            <span id="spInvalidPasswordLength" runat="server">Mật khẩu phải dài hơn 4 kí tự!</span> 
            <span id="spInvalidPasswordRule" runat="server">Mật khẩu không trùng nhau</span> 
            <span id="spSetPassSuccess" runat="server">Đặt mật khẩu thành công.</span> 
             <span id="spSetPasstFail" runat="server">Đặt mật khẩu không thành công.</span> 
        </div>
    </form>
</body>
</html>
