<%@ Page Language="vb" AutoEventWireup="false" Inherits="main" CodeFile="main.aspx.vb" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Dialog_alert.ascx" TagName="Dialog_alert" TagPrefix="uc1" %>
<%@ Register Src="Dialog_Confirm.ascx" TagName="Dialog_Confirm" TagPrefix="uc2" %>
<%@ Register Src="Dialog_Content.ascx" TagName="Dialog_Content" TagPrefix="uc3" %>
<%@ Register Src="Dialog_Content_Child.ascx" TagName="Dialog_Content_Child" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <link href="images/design/ssc-icon.png" rel="shortcut icon"/>
        <title>Thư viện điện tử eMicLib</title>
        <link href="Resources/StyleSheet/style.css" type="text/css" rel="stylesheet" />
        <link href="Resources/default.css" rel="stylesheet" />
        <link href="Resources/main.css" rel="stylesheet" />
        <link href="Resources/iconFont.css" rel="stylesheet" />
        <script language="JavaScript" type="text/javascript" src="js/Public.js"></script>
       
        <script type="text/javascript">
        <!--
            var ua = navigator.userAgent.toLowerCase();
            var m = ua.match(/(^|\s)(firefox|safari|opera|msie|chrome|trident)[\/:\s]([\d\.]+)/) || ["", "", "0.0"];
            var name = m[2] || "";
            var version = parseInt((ua.match(/\sversion\/([\d\.]+)/i) || ["", m[3]])[1]) || 0;
            if (name ='msie'  && version <= 8) {
                RedirecBox();
            }
            function RedirecBox() {
                var ask = window.confirm("Bạn có muốn cập nhật phiên bản IE mới để chương trình hoạt động tốt hơn");
                if (ask) {

                    document.location.href = "http://www.microsoft.com/en-us/download/internet-explorer-11-for-windows-7-details.aspx";

                }
            }
    function MainContent_onPaneResize(sender, e) {
        var myIframe = document.getElementById('main');
        myIframe.style.height = e.get_pane().get_height() + 'px';
        myIframe.style.width = e.get_pane().get_width() + 'px';
    }
    function showDialogInfo(control, model, icon, info, description) {
        toggle(control, model, icon, info, description);
    }
    function showDialogConfirmInfo(control, model, icon, info, description, OutlineControl) {
        toggle_confirm(control, model, icon, info, description, OutlineControl);
    }
    function showDialogContent(control, model, info, width, height) {
        toggle_content(control, model, info, width, height);
    }
    function showDialogContentFix(control, model, info, OffsetX, OffsetY, width, height) {
        toggle_content_fix(control, model, info, OffsetX, OffsetY, width, height);
    }
    function showDialogContentChild(control, model, info, width, height) {
        toggle_content_child(control, model, info, width, height);
    }
    function closeDialog(dialog) {
        toggle_close(dialog);
    }
    function OpenWindowRegisterNum(add, DocId, MagId) {
        var iHeight = getHeightByBrowse();
        var iWidth = getWidthByBrowse();
        var WindowRegisterNum = $find("<%= WindowRegisterNum.ClientID %>");
        WindowRegisterNum.set_navigateUrl('<%=Page.ResolveUrl("~/Serial/Acquisition/acqMagRegisterNumberFrame.aspx") %>' + '?add=' + add + '&DocId=' + DocId + '&MagId=' + MagId);
        WindowRegisterNum.setSize(960, iHeight*80/100);
        WindowRegisterNum.show();
    }

    function onClientCloseRadWindows() {
        var WindowRegisterNum = $find("<%= WindowRegisterNum.ClientID %>");
                WindowRegisterNum.close(null);
            }


            function OpenWindowTableOfContents(MagId) {
                var iHeight = getHeightByBrowse();
                var iWidth = getWidthByBrowse();
                var WindowTableOfContents = $find("<%= WindowTableOfContents.ClientID %>");
                WindowTableOfContents.set_navigateUrl('<%=Page.ResolveUrl("~/Serial/Acquisition/eMagazine/AcqMagazineTableOfContentsFrame.aspx") %>' + '?MagId=' + MagId);
                WindowTableOfContents.setSize(960, iHeight * 80 / 100);
                WindowTableOfContents.show();
            }

            function onClientCloseRWTableOfContents() {
                var WindowTableOfContents = $find("<%= WindowTableOfContents.ClientID %>");
                WindowTableOfContents.close(null);
            }

            function OpenWindowTableOfContentsEditor(addnew, magDetailId) {
                var iHeight = getHeightByBrowse();
                iHeight = (iHeight * 2) / 3;
                var iWidth = getWidthByBrowse();
                iWidth = (iWidth * 2) / 3;
                var WindowTableOfContentsEditor = $find("<%= WindowTableOfContentsEditor.ClientID %>");
                WindowTableOfContentsEditor.set_navigateUrl('<%=Page.ResolveUrl("~/Serial/Acquisition/eMagazine/AcqMagazineTableOfContentsAddFrame.aspx") %>' + '?addnew=' + addnew + '&magDetailId=' + magDetailId);
                WindowTableOfContentsEditor.setSize(960, iHeight * 80 / 100);
                WindowTableOfContentsEditor.show();
            }

            function onClientCloseRWTableOfContentsEditor() {
                var WindowTableOfContentsEditor = $find("<%= WindowTableOfContentsEditor.ClientID %>");
                WindowTableOfContentsEditor.close(null);
            }

            function logOut() {
                top.location.href = "Index.aspx?out=ok";
            }

            function ChangeLanguage(lang) {
                var Language;
                if (lang == 'vie') {
                    Language = "Language=vie";
                }
                else {
                    Language = "Language=eng";
                }

                var pHeader, pMain, pFooter;

                pHeader = String(self.document.location);
                if (pHeader != null)
                    if (pHeader.indexOf("?") > 0)
                        self.document.location.href = String(pHeader) + "&" + Language;
                    else
                        self.document.location.href = String(pHeader) + "?" + Language;

                pMain = String(parent.main.document.location);
                if (pMain != null)
                    if (pMain.indexOf("?") > 0)
                        parent.main.document.location.href = String(pMain) + "&" + Language;
                    else
                        parent.main.document.location.href = String(pMain) + "?" + Language;

                pFooter = String(parent.footer.document.location);
                if (pFooter != null)
                    if (pFooter.indexOf("?") > 0)
                        parent.footer.document.location.href = String(pFooter) + "&" + Language;
                    else
                        parent.footer.document.location.href = String(pFooter) + "?" + Language;

            }


            //-->
        </script>
    </telerik:RadCodeBlock>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
        <!-- Header go ----------------------------------------------------------------------->
        <table style="width: 100%; height: 69px;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 101px; background-color: #024385;">
                    <div style="padding-left: 5px; padding-top: 5px; float: left;">
                        <a href="http://thessc.vn/">
                            <img id="Img1" src="~/Images/design/Logo.png" runat="server" height="50" width="86" />
                        </a>
                    </div>
                    <div id="loginstatus">
                        <div style="padding-top: 5px; padding-left: 8px; float: right; width: 16px">
                            <img id="ImgUser" src="~/Images/RibbonBar/User/User.png" runat="server" />
                        </div>
                        <div style="float: right; width: 250px; color: White;">
                            <img id="imgVieLanguage" style="display: none" src="~/Images/RibbonBar/Language/Flag_of_Vietnam.png" runat="server"
                                class="imageHandle" onclick="ChangeLanguage('vie');" />
                            <img id="imgEngLanguage" style="display: none" src="~/Images/RibbonBar/Language/Flag_of_England.png" runat="server"
                                class="imageHandle" onclick="ChangeLanguage('eng');" />
                            <asp:Literal ID="ltlogin" runat="server" />&nbsp;(<asp:LinkButton ID="lkbLogout"
                                runat="server" CausesValidation="False" OnClientClick="logOut();return false;" CssClass="status-login">Thoát</asp:LinkButton>)
                        </div>
                        <div>
                        </div>
                    </div>
                </td>
                <td colspan="2" style="background-color: #024385;">
                    <div style="color: #b4141e; font-family: HeadFont; font-weight: normal; margin-top: -4px; font-size: 2.91em;">
                        HỆ THỐNG QUẢN LÝ THƯ VIỆN ĐIỆN TỬ
                    </div>

                </td>
            </tr>
        </table>
        <!-- Header no ----------------------------------------------------------------------->
        <table id="table1" style="width: 100%;" cellpadding="0px" cellspacing="0px" border="0px">
            <tr style="display: none">
                <td>
                    <asp:Button ID="OutlineControl" runat="server" />
                    <uc1:Dialog_alert ID="Dialog_alert1" runat="server" />
                    <uc4:Dialog_Content_Child ID="Dialog_Content_Child1" runat="server" />
                    <uc2:Dialog_Confirm ID="Dialog_Confirm1" runat="server" />
                    <uc3:Dialog_Content ID="Dialog_Content1" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 100%;">
                    <ComponentArt:Splitter runat="server" ID="SplitterMain" FillHeight="true" FillWidth="true"
                        ImagesBaseUrl="Resources/Skin/arcticwhite/Splitter/Images/">
                        <Layouts>
                            <ComponentArt:SplitterLayout>
                                <Panes Orientation="Vertical" SplitterBarCollapseImageUrl="splitter_verCol.gif" SplitterBarCollapseHoverImageUrl="splitter_verColHover.gif"
                                    SplitterBarExpandImageUrl="splitter_verExp.gif" SplitterBarExpandHoverImageUrl="splitter_verExpHover.gif"
                                    SplitterBarCollapseImageWidth="116" SplitterBarCollapseImageHeight="5" SplitterBarCssClass="VerticalSplitterBar"
                                    SplitterBarCollapsedCssClass="CollapsedVerticalSplitterBar" SplitterBarActiveCssClass="ActiveSplitterBar"
                                    SplitterBarWidth="5">
                                    <ComponentArt:SplitterPane PaneContentId="HeaderContent" Width="100%" Height="137"
                                        MinHeight="145" AllowResizing="false" AllowScrolling="false" />
                                    <ComponentArt:SplitterPane PaneContentId="MainContent" Width="100%" Height="99%"
                                        AllowResizing="false" AllowScrolling="false">
                                        <ClientEvents>
                                            <PaneResize EventHandler="MainContent_onPaneResize" />
                                        </ClientEvents>
                                    </ComponentArt:SplitterPane>
                                </Panes>
                            </ComponentArt:SplitterLayout>
                        </Layouts>
                        <Content>
                            <ComponentArt:SplitterPaneContent ID="HeaderContent">
                               
                                        <div class="top-menu">
                                            <iframe src="WHeader.aspx" frameborder="0" height="148px" id="header" width="100%"
                                                name="header" scrolling="no"></iframe>
                                        </div>
                                 
                            </ComponentArt:SplitterPaneContent>
                            <ComponentArt:SplitterPaneContent ID="MainContent">
                               
                                        <div id="divMain">
                                            <iframe src="WNothing.aspx?home=1" frameborder="0" id="main" width="100%" name="main"
                                                scrolling="auto"></iframe>
                                        </div>
                                  
                            </ComponentArt:SplitterPaneContent>
                        </Content>
                    </ComponentArt:Splitter>
                </td>
            </tr>
        </table>
        <!-- Footer go ----------------------------------------------------------------------->
        <table style="width: 100%; height: 30px; display: none" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div id="divFooter">
                        <div class="footer-form">
                            <div class="footer-info">
                                <table>
                                    <tr>
                                        <td>
                                            <h5>Địa chỉ: 159 Ter Nam Kỳ Khởi Nghĩa, Phường 07, Quận 03,  Tp.HCM.</h5>
                                        </td>
                                        <td>
                                            <h5>Điện thoại: (08) 3930 2323 <span>|</span>Fax: (08) 3930 1828</h5>
                                        </td>
                                        <td>
                                            <h5>
                                                <a target="_blank" href="http://www.thessc.vn">www.thessc.vn</a><span>-</span><a
                                                    target="_blank" href="mailto:info@thessc.vn">Email: info@thessc.vn</a></h5>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <!-- Footer no ----------------------------------------------------------------------->
        <div style="position: absolute; top: 0px; left: 0px; visibility: hidden;">
            <telerik:RadWindow runat="server" Width="800px" Height="300px" VisibleStatusbar="False"
                ID="WindowRegisterNum" Modal="True" Behavior="Close, Move" InitialBehavior="None"
                IconUrl="/Resources/Skin/arcticwhite/Toolbar/images/FooterControls/folderDisplay.png"
                Title="Đăng ký số" ReloadOnShow="true" Animation="Resize">
            </telerik:RadWindow>
            <telerik:RadWindow runat="server" Width="800px" Height="300px" VisibleStatusbar="False"
                ID="WindowTableOfContents" Modal="True" Behavior="Close, Move" InitialBehavior="None"
                IconUrl="/Resources/Skin/arcticwhite/Toolbar/images/FooterControls/Bookmark.png"
                Title="Biên mục mục lục" ReloadOnShow="true" Animation="Resize">
            </telerik:RadWindow>
            <telerik:RadWindow runat="server" Width="800px" Height="300px" VisibleStatusbar="False"
                ID="WindowTableOfContentsEditor" Modal="True" Behavior="Close, Move" InitialBehavior="None"
                IconUrl="/Resources/Skin/arcticwhite/Toolbar/images/FooterControls/Bookmark.png"
                Title="Thêm/sửa chi tiết mục lục" ReloadOnShow="true" Animation="Resize">
            </telerik:RadWindow>
        </div>
    </form>
</body>
</html>
