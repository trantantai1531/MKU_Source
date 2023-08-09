<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OComment.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script type="text/javascript">
        function raiseWarning() {
            alert("Bình luận không thể để trống. Vui lòng chia sẽ vài dòng suy nghĩa của bạn về tài liệu này.");
        }
    </script>
</head>
<body  class="metro"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px" id="top">
    <form method="post" action="OComment.aspx">
        <label  style="cursor:default;"><span class="icon-comments-4"></span> Bình luận</label>
        <div class="balloon right">
	        <div class="tab-control padding20">		
                <div class="input-control textarea"><textarea data-transform="input-control" placeholder="Viết bình luận" style="margin: 0px; width: 100%; height: 100px;" id="txtComment" name="txtComment"></textarea></div>
                <button class="image-button bg-darkGreen fg-white image-left">
                    Gửi bình luận
                    <i class="icon-comments-5 bg-green fg-white"></i>
                </button>
	        </div>
        </div>
    </form>
</body>
</html>
