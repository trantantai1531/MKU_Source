<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UFooter.ascx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.UFooter" %>
<style>
    #divFooter
    {
        background: #003366;
    }
    #divFooter > p 
    {
        color: white;
        text-align: center;
    }
    #divFooter > .first 
    {
        font-size: 18px;
    }
    .footer-info
    {
        height:70px;
    }
    .footer-counter
    {
        color: #fff;
        font-size: 14px;
        top: -65px;
        text-align: right;
        z-index: 9999;
        position: relative;
        right: 15px;
    }
    @media screen and (max-width: 992px)
    {
        .footer-counter
        {
            top:75px;
            right:0;
            background:#003366;
            text-align:center;
        }
    }
    @media screen and (max-width: 686px)
    {
        .footer-counter
        {
            top:110px;
        }
    }
</style>

<div id="footer" class="web-size">
    <div class="footer-info">
        <footer>
            <div id="divFooter" class="ClearFix">
                <p class="first"> TRƯỜNG ĐẠI HỌC CỬU LONG </p> 
                <p>
                    <span style="color:whitesmoke">
                        <i class="fa fa-home"></i>
                        <b>Địa chỉ:</b> Quốc lộ 1A, xã Phú Quới, huyện Long Hồ, tỉnh Vĩnh Long
                    </span>
                </p>
                <p>
                    <span style="color:whitesmoke">
                        <i class="fa fa-phone"></i>
                        <b>Điện thoại:</b> 02703 832 538
                    </span>
                </p>
                <p>
                    <span style="color:whitesmoke">
                        <i class="fa fa-envelope"></i>
                        <b>Website:</b> http://mku.edu.vn/
                    </span>
                </p>
            </div>
        </footer>
    </div>
    <div class="footer-counter">
        <p>Đang truy cập: <%=Application("OnlineCounters")%></p>
        <p>Tổng truy cập: <asp:Label ID="lbTotal" runat="server" Text="0"></asp:Label></p>
        <p>Hôm qua: <asp:Label ID="lbLastDay" runat="server" Text="0"></asp:Label></p>
        <p>Tuần trước: <asp:Label ID="lbLastWeek" runat="server" Text="0"></asp:Label></p>
        <p>Tháng trước: <asp:Label ID="lbLastMonth" runat="server" Text="0"></asp:Label></p>
    </div>
</div>