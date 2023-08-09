<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ORegisterBooking.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ORegisterBooking" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="Resources/StyleSheet/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />
    <link href="Resources/StyleSheet/bootstrap-slider.min.css" rel="stylesheet" />
    <script src="JS/bootstrap-datepicker.min.js"></script>
    <script src="JS/bootstrap-datepicker.vi.min.js"></script>
    <script src="JS/bootstrap-slider.min.js" type="text/javascript"></script>
    <style type="text/css">
        .slider {
            width: 100% !important;
        }
        .slider.slider-horizontal .slider-tick-label-container .slider-tick-label
        {
            padding-top:0;
        }
        .slider .tooltip.top
        {
            display:none;
            margin-top:0;
        }
        input
        {
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
            margin: 0;
        }
        .input-group {
            position: relative;
            display: table;
            border-collapse: separate;
        }
        .form-control {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        .input-group .form-control
        {
            position: relative;
            z-index: 2;
            float: left;
            width: 100%;
            margin-bottom: 0;
            display: table-cell;
        }
        .input-group .form-control:first-child
        {
            border-top-right-radius: 0;
            border-bottom-right-radius: 0;
        }

        .input-group-addon {
            padding: 6px 12px;
            font-size: 14px;
            font-weight: 400;
            line-height: 1;
            color: #555;
            text-align: center;
            background-color: #eee;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 1%;
            white-space: nowrap;
            vertical-align: middle;
            display: table-cell;
        }
        .input-group-addon:last-child
        {
            border-top-left-radius: 0;
            border-bottom-left-radius: 0;
            border-left: 0;
        }
        .list-room li
        {
            width:100%;
            padding-top:50px;
            padding-bottom:50px;
            cursor:pointer;
            margin-bottom:5px;
            text-align:center;
        }
        .list-room li label
        {
            color:#fff;
            cursor:pointer;
        }
        .button-control .button-form input
        {
            padding-top: 7px;
            border:1px solid #1ba1e2 !important;
        }
        .btn-theme
        {
            background:#1ba1e2 !important;
        }
        .table-info td
        {
            padding:5px 0px;
        }
        .list-room li.active
        {
            background:#1ba1e2;
        }
        #ListTimesBusy
        {
            color:#f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size news-page ClearFix">
                <h1><span class="icon-calendar"></span>Đặt phòng họp</h1>
                <div class="row-detail">
                    <table class="table-info" border="0" style="border-collapse:collapse;">
                        <tr>
                            <td><b>Họ tên</b></td>
                            <td><span>: </span><asp:Label ID="lbFullName" CssClass="control-label" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>MSSV</b></td>
                            <td><span>: </span><asp:Label ID="lbPatronCode" CssClass="control-label" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Email</b></td>
                            <td><span>: </span><asp:Label ID="lbEmail" CssClass="control-label" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <h1>Danh sách phòng</h1>
                            <div class="list-room">
                                <ul>
                                    <asp:Repeater ID="RepeaterListRoom" runat="server">
                                        <ItemTemplate>
                                            <li class='<%#Eval("Active") %>' onclick="SelectRoom(this, '<%#Eval("RoomID") %>');">
                                                <label class=""><%#Eval("RoomName") %></label>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <h1>Chọn thời gian</h1>
                        </div>
                        <div class="row-detail">
                            <p>Chọn ngày</p>
                            <div class="input-group date" data-provide="datepicker">
                                <input type="text" class="form-control" id="txtDate">
                                <div class="input-group-addon">
                                    <span class="icon-calendar"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Danh sách giờ bận</p>
                            <p id="ListTimesBusy" runat="server"></p>
                        </div>
                        <div class="row-detail">
                            <p>Chọn thời gian</p>
                            <div style="padding:0 10px;">
                                <input id="slide-times" class="rangeTimes" type="text" 
                                data-slider-value="[<%=If(Date.Now.Hour >= 16, 8, If(Date.Now.Hour = 15, If(Date.Now.Minute > 0, 8, Date.Now.Hour + 1), Date.Now.Hour)) %>, <%=If(Date.Now.Hour >= 16, 10, If(Date.Now.Hour > 15, If(Date.Now.Minute > 0, 10, Date.Now.Hour + 3), Date.Now.Hour + 2)) %>]" 
                                data-slider-ticks="[8, 9, 10, 11, 12, 13, 14, 15, 16, 17]" 
                                data-slider-ticks-labels='["8", "9", "10", "11", "12", "13", "14", "15", "16", "17"]' 
                                data-slider-lock-to-ticks="false"/>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Loại phòng</p>
                            <div class="input-control">
                                <div class="input-dropdownlist">
                                    <asp:DropDownList ID="ddlTypeRoom" runat="server">
                                        <asp:ListItem Value="0">Phòng học nhóm</asp:ListItem>
                                        <asp:ListItem Value="1">Phòng họp</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" >
                            <p>Mục đích sử dụng <span style="color:#f00;"> *</span></p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="tb-text" TextMode="MultiLine" ID="txtUses" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" >
                            <p>Yêu cầu khác</p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="tb-text" TextMode="MultiLine" ID="txtRequestOther" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" >
                            <p>Số người <span style="color:#f00;"> *</span></p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="tb-text" ID="txtCount" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" >
                            <p>ID các thành viên <span style="color:#f00;"> *</span></p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="tb-text" ID="txtListCode" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="text-align:right;">
                            <p>&nbsp;</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <input type="button" class="lbButton btn-theme" value="Đặt phòng" onclick="RegisterBooking()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row-detail">
                    <h1>Lịch sử đặt phòng</h1>
                    <div class="table-striped">
                        <asp:GridView ID="GridViewHistory" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" />
                                <asp:BoundField DataField="RoomName" HeaderText="Tên phòng" ReadOnly="true" />
                                <asp:BoundField DataField="BookingDate" HeaderText="Ngày" />
                                <asp:BoundField DataField="TimeStart" HeaderText="Từ giờ" />
                                <asp:BoundField DataField="TimeEnd" HeaderText="Đến giờ" />
                                <asp:TemplateField HeaderText="Tình trạng">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelStatus" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label>
                                        <asp:HiddenField ID="hidStatus" runat="server" Value='<%#Eval("Status") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DateCreate" HeaderText="Ngày đã đặt" ReadOnly="true"/>
                                <asp:CommandField ButtonType="Button" ShowEditButton="True" UpdateText="Cập nhật" CancelText="Hủy" EditText="Sửa" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            
            <div style="display:none;">
                <asp:HiddenField ID="hidDate" runat="server" Value="" />
                <asp:HiddenField ID="hidRoom" runat="server" Value="" />
                <asp:HiddenField ID="hidTimes" runat="server" Value=""></asp:HiddenField>
                <asp:Label ID="lbMsgValidBusyTime" runat="server" Visible="false" Text="Thời gian đăng ký phòng đã bận. Xem danh sách giờ bận và chọn thời gian khác."></asp:Label>
                <asp:Label ID="lbMsgSuccess" runat="server" Visible="false" Text="Đặt phòng thành công"></asp:Label>
                <asp:Label ID="lbMsgValidCheckInTime" Visible="false" runat="server" Text="Chỉ được đặt phòng 2 tiếng/lần"></asp:Label>
                <asp:DropDownList ID="ddlStatus" runat="server" Visible="false">
                    <asp:ListItem Value="-1">Từ chối</asp:ListItem>
                    <asp:ListItem Value="0">Chờ duyệt</asp:ListItem>
                    <asp:ListItem Value="1">Đã duyệt</asp:ListItem>
                    <asp:ListItem Value="2">Đã hết hạn/Đã kết thúc</asp:ListItem>
                </asp:DropDownList>
                <asp:Button Text="" id="btnUpdate" runat="server"/>
                <asp:Label ID="lbSubjectEmail" runat="server" Visible="false" Text="Đặt phòng họp - {0} - {1}"></asp:Label>
                <span id="MsgValid">Vui lòng nhập các thông tin bắt buộc!</span>
                <div id="ContentMail" runat="server">
                    <p><b>Thông tin yêu cầu đặt phòng họp</b></p>
                    <table border="0">
                        <tr>
                            <td>Họ tên</td>
                            <td>: <$FullName$></td>
                        </tr>
                        <tr>
                            <td>Mã bạn đọc</td>
                            <td>: <$Code$></td>
                        </tr>
                        <tr>
                            <td>Email</td>
                            <td>: <$Email$></td>
                        </tr>
                        <tr>
                            <td>Ngày</td>
                            <td>: <$BookingDate$></td>
                        </tr>
                        <tr>
                            <td>Thời gian</td>
                            <td>: <$TimeRange$></td>
                        </tr>
                        <tr>
                            <td>Phòng</td>
                            <td>: <$RoomName$></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <script type="text/javascript">
            $(document).ready(function () {
                $(".rangeTimes").slider({
                    value: [<%=If(Date.Now.Hour >= 16, 8, If(Date.Now.Hour = 15, If(Date.Now.Minute > 0, 8, Date.Now.Hour + 1), Date.Now.Hour)) %>, <%=If(Date.Now.Hour >= 16, 10, If(Date.Now.Hour > 15, If(Date.Now.Minute > 0, 10, Date.Now.Hour + 3), Date.Now.Hour + 2)) %>],
                    ticks: [8, 9, 10, 11, 12, 13, 14, 15, 16, 17],
                    ticks_labels: ["8", "9", "10", "11", "12", "13", "14", "15", "16", "17"],
                    lock_to_ticks: false
                });
                var slider = new Slider(".rangeTimes", {
                    value: [<%=If(Date.Now.Hour >= 16, 8, If(Date.Now.Hour = 15, If(Date.Now.Minute > 0, 8, Date.Now.Hour + 1), Date.Now.Hour)) %>, <%=If(Date.Now.Hour >= 16, 10, If(Date.Now.Hour > 15, If(Date.Now.Minute > 0, 10, Date.Now.Hour + 3), Date.Now.Hour + 2)) %>],
                    ticks: [8, 9, 10, 11, 12, 13, 14, 15, 16, 17],
                    ticks_labels: ["8", "9", "10", "11", "12", "13", "14", "15", "16", "17"],
                    lock_to_ticks: false
                });

                $('.date').datepicker({
                    format: 'dd/mm/yyyy',
                    startDate: '<%= String.Format("{0:dd/MM/yyyy}", If(Date.Now.Hour >= 16, Date.Now.AddDays(1), If(Date.Now.Hour = 15, If(Date.Now.Minute > 0, Date.Now.AddDays(1), Date.Now), Date.Now)))%>',
                    autoclose: true
                });
                $(".date").datepicker("setDate", "<%= String.Format("{0:dd/MM/yyyy}", If(Date.Now.Hour >= 16, Date.Now.AddDays(1), If(Date.Now.Hour = 15, If(Date.Now.Minute > 0, Date.Now.AddDays(1), Date.Now), Date.Now)))%>");
                $("#hidTimes").val($(".rangeTimes").val());
            });
            
            $("#txtDate").on("change", function ()
            {
                var hidDate = document.getElementById("hidDate");
                hidDate.value = this.value;
                
                var hidRoom = document.getElementById("hidRoom");

                var strServiceURL = "<%= Page.ResolveUrl("~/eService.asmx/GetTimeBusyInRoom")%>?strDate=" + this.value + "&intRoomID=" + hidRoom.value;
                $.ajax({
                    url: strServiceURL,
                    type: 'GET',
                    success: function (json) {
                        let strReturn = $(json).text();
                        let arrSplit = strReturn.split(",");
                        $("#ListTimesBusy").html("");
                        for(let i=0;i<arrSplit.length; i++)
                        {
                            if (i == 0)
                            {
                                $("#ListTimesBusy").append("<b>" + arrSplit[i].trim() + "</b>");
                            }
                            else
                            {
                                $("#ListTimesBusy").append(", <b>" + arrSplit[i].trim() + "</b>");
                            }
                        }
                        $('.datepicker').hide();
                    },
                    error: function (xhr, status, error) {
                        //alert('L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u.');
                        //console.log(error);
                        console.log(error);
                    }
                });
                
            });

            function RegisterBooking()
            {
                if(CheckValid())
                {
                    var btnUpdate = document.getElementById("btnUpdate");
                    btnUpdate.click();
                }
                else
                {
                    alert(document.getElementById("MsgValid").innerText);
                }
            }

            $(".rangeTimes").on("change", function () {
                var valTimes = this.value;
                $('#hidTimes').val(valTimes);
            });
            
            function CheckValid()
            {
                var txtUses = document.getElementById("txtUses").value;
                var txtCount = document.getElementById("txtCount").value;
                var txtListCode = document.getElementById("txtListCode").value;

                if(txtUses == '' || txtCount == '' || txtListCode == '')
                {
                    if (txtUses == '')
                    {
                        document.getElementById("txtUses").focus();
                        return false;
                    }
                    if (txtCount == '') {
                        document.getElementById("txtCount").focus();
                        return false;
                    }
                    if (txtListCode == '') {
                        document.getElementById("txtListCode").focus();
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }

            function SelectRoom(obj, val)
            {
                var y = document.getElementsByClassName("list-room");
                $(y).find(".active").removeClass("active");
                obj.classList.add("active");

                var hidRoom = document.getElementById("hidRoom");
                hidRoom.value = val;

                var hidDate = document.getElementById("hidDate");

                var strServiceURL = "<%= Page.ResolveUrl("~/eService.asmx/GetTimeBusyInRoom")%>?strDate=" + hidDate.value + "&intRoomID=" + hidRoom.value;
                $.ajax({
                    url: strServiceURL,
                    type: 'GET',
                    success: function (json) {
                        let strReturn = $(json).text();
                        let arrSplit = strReturn.split(",");
                        $("#ListTimesBusy").html("");
                        for(let i=0;i<arrSplit.length; i++)
                        {
                            if (i == 0)
                            {
                                $("#ListTimesBusy").append("<b>" + arrSplit[i].trim() + "</b>");
                            }
                            else
                            {
                                $("#ListTimesBusy").append(", <b>" + arrSplit[i].trim() + "</b>");
                            }
                        }
                    },
                    error: function (xhr, status, error) {
                        //alert('L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u.');
                        //console.log(error);
                        console.log(error);
                    }
                });
                
            }
        </script>
    </form>
</body>
</html>
