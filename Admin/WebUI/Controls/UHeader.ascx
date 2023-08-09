<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UHeader.ascx.vb" Inherits="eMicLibAdmin.WebUI.Controls_UHeader" %>
<script type="text/javascript">

    if (window.parent.location.toString().indexOf("main") < 1) {


        window.location.href = "main.aspx";
    }

    function ClientButtonToggledHandler(sender, args) {
        var currentActiveElement = document.getElementsByClassName("active");
        for (var i = 0; i < currentActiveElement.length; i++) {
            currentActiveElement[i].className = currentActiveElement[i].className.replace(/\active\b/, '');
        }
        var activeItem = args.get_button()._element;
        activeItem.className = activeItem.className + " active";
        var value = args.get_button().get_value();
        var vHref = value.substr(1);
        var vType = value.substr(0, 1);
        var vTarget = "main";
        if (vHref.toString().toLowerCase().indexOf("/catalogue/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/serial/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/patron/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/circulation/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/admin/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/ill/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/edeliv/") >= 0) {
            vTarget = "Workform";
        }
        else if (vHref.toString().toLowerCase().indexOf("/acquisition/") >= 0) {
            vTarget = "mainacq";
        }

        console.log(vHref);
        if (vHref.indexOf("WCheckOutIndex.aspx") != -1) {
            window.parent.document.title = "Thư viện điện tử eMicLib - ghi mượn";
           
        } else if (vHref.indexOf("WCheckInIndex.aspx") != -1) {
           
            window.parent.document.title = "Thư viện điện tử eMicLib - ghi trả";
        } else {
           
            window.parent.document.title = "Thư viện điện tử eMicLib";
        }

        switch (vType) {
            case '1':
                var a = document.createElement('a');
                a.href = vHref;
                a.target = vTarget;
                document.body.appendChild(a);
                a.click();
                break;
            case '2':
                var a = document.createElement('a');
                a.href = vHref;
                a.target = '_blank';
                document.body.appendChild(a);
                a.click();
                break;
        }

    }

    function ClientSelectedTabChangedHandler(sender, args) {

        var value = args.get_tab().get_value();
        var vHref = value.substr(1);
        var vType = value.substr(0, 1);

        console.log(vHref);
        if (vHref.indexOf("WCheckOutIndex.aspx") != -1) {
            window.parent.document.title = "Thư viện điện tử eMicLib - ghi mượn";
          
        } else if (vHref.indexOf("WCheckInIndex.aspx") != -1) {
           
            window.parent.document.title = "Thư viện điện tử eMicLib - ghi trả";
        } else {
          
            window.parent.document.title = "Thư viện điện tử eMicLib";
        }
        switch (vType) {
            case '1':
                var b = document.createElement('a');

                b.href = vHref;
                b.target = 'main';
                document.body.appendChild(b);

                b.click();

                break;
            case '2':
                var b = document.createElement('a');
                b.href = vHref;
                b.target = '_blank';
                document.body.appendChild(b);
                b.click();
                break;
        }
    }

    function logOut() {
        top.location.href = "Index.aspx?out=ok";
    }

</script>
<link href="Resources/StyleSheet/iconFont.css" rel="stylesheet" />

<link href="/Resources/style.css" type="text/css" rel="stylesheet" />
<asp:UpdatePanel ID="upnHeader" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <%--<div id="loginstatus">
            <div style="padding-top: 1px; padding-left: 8px; float: right; width: 16px">
                <img id="ImgUser" src="~/Images/RibbonBar/User/User.png" runat="server" />
            </div>
            <div style="float: right; width: 250px">
                <asp:Literal ID="ltlogin" runat="server" />&nbsp;(<asp:LinkButton ID="lkbLogout"
                    runat="server" CausesValidation="False" OnClientClick="logOut()" CssClass="status-login" >Thoát</asp:LinkButton>)
            </div>
        </div>--%>
        <div class="menu-form">
            <div id="header" class="top-menu" runat="server">
            </div>

        </div>
    </ContentTemplate>
</asp:UpdatePanel>
