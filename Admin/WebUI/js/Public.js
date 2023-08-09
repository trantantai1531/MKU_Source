var curtab = 1;

function setIframeHeight(iframeName) {
    var iframeWin = window.frames[iframeName];
    var iframeEl = document.getElementById ? document.getElementById(iframeName) : document.all ? document.all[iframeName] : null;
    if (iframeEl && iframeWin) {
        iframeEl.style.height = "auto"; // helps resize (for some) if new doc shorter than previous  
        var docHt = getDocHeight(iframeWin.document);
        // need to add to height to be sure it will all show
        if (docHt) iframeEl.style.height = docHt + 20 + "px";
    }
    else {
        iframeEl.style.height = "auto";
        var docHt = getDocHeight(iframeWin.document);
        if (docHt) iframeEl.style.height = docHt + 20 + "px";
    }
}

function getDocHeight(doc) {
    var docHt = 0, sh, oh;
    if (doc.height) docHt = doc.height;
    else if (doc.body) {
        if (doc.body.scrollHeight) docHt = sh = doc.body.scrollHeight;
        if (doc.body.offsetHeight) docHt = oh = doc.body.offsetHeight;
        if (sh && oh) docHt = Math.max(sh, oh);
    }
    return docHt;
}

function getObject(objectID) {
    if (document.all != null) {
        return document.all[objectID];
    } else if (document.getElementById) {
        return document.getElementById(objectID);
    }
}

function setIframeavailHeight(iframeName) {
    var iframeWin = window.frames[iframeName];
    var iframeEl = document.getElementById ? document.getElementById(iframeName) : document.all ? document.all[iframeName] : null;
    if (iframeEl && iframeWin) {
        iframeEl.style.height = window.screen.availHeight - 227;
    }
    else
        iframeEl.style.height = window.screen.availHeight - 227;
}

function toggle(obj, modal, icon, dialogtitle, dialogvalue) {
    if (Dialog.get_isShowing()) {
        Dialog.Close();
    }
    else {
        Dialog.beginUpdate();
        Dialog.set_value(dialogvalue);
        Dialog.set_title(dialogtitle);

        Dialog.set_showTransition(0);
        Dialog.set_closeTransition(0);
        Dialog.set_animationType('None');
        Dialog.set_animationPath('Direct');
                
        Dialog.set_modal(modal);

        arricon = new Array(9);
        arricon[0] = "pencil.png";
        arricon[1] = "arrow.gif";
        arricon[2] = "search.gif";
        arricon[3] = "x.png";
        arricon[4] = "Input.gif";
        arricon[5] = "Cancel.gif";
        arricon[6] = "Updated.png";
        arricon[7] = "Refresh.png";
        arricon[8] = "select_text.png";
        Dialog.set_icon(arricon[icon]);
        Dialog.set_x(null);
        Dialog.set_y(null);
        Dialog.endUpdate();

        Dialog.contentUrl = obj;

        Dialog.Show();
    }
}

function toggle_confirm(obj, modal, icon, dialogtitle, dialogvalue, Outline) {
    if (Dialog_confirm.get_isShowing()) {
        Dialog_confirm.Close();
    }
    else {
        Dialog_confirm.beginUpdate();
        Dialog_confirm.set_value(dialogvalue);
        Dialog_confirm.set_title(dialogtitle);

        if (Outline == true) {
            Dialog_confirm.set_showTransition(0);
            Dialog_confirm.set_closeTransition(0);
            Dialog_confirm.set_animationSlide(3);
            Dialog_confirm.set_animationDirectionElement('OutlineControl');
            Dialog_confirm.set_animationType('Outline');
            Dialog_confirm.set_animationPath('Direct');
            Dialog_confirm.set_animationDuration(200);
            Dialog_confirm.set_transitionDuration(200);
        }
        else {
            Dialog_confirm.set_showTransition(0);
            Dialog_confirm.set_closeTransition(0);
            Dialog_confirm.set_animationType('None');
            Dialog_confirm.set_animationPath('Direct');
        }
            
        Dialog_confirm.set_modal(modal);

        arricon = new Array(9);
        arricon[0] = "pencil.png";
        arricon[1] = "arrow.gif";
        arricon[2] = "search.gif";
        arricon[3] = "x.png";
        arricon[4] = "Input.gif";
        arricon[5] = "Cancel.gif";
        arricon[6] = "Updated.png";
        arricon[7] = "Refresh.png";
        arricon[8] = "select_text.png";
        Dialog_confirm.set_icon(arricon[icon]);
        Dialog_confirm.set_x(null);
        Dialog_confirm.set_y(null);
        Dialog_confirm.endUpdate();

        Dialog_confirm.contentUrl = obj;

        Dialog_confirm.Show();
    }
}

function toggle_close(dialog) {
    if (eval(dialog+".get_isShowing()")) {
        eval(dialog+".Close()");
    }
}

function toggle_content(obj, modal, dialogtitle, intOffsetX, intOffsetY) {
    if (Dialog_content.get_isShowing()) {
        Dialog_content.Close();
    }
    else {
        Dialog_content.beginUpdate();
        Dialog_content.set_title(dialogtitle);

        Dialog_content.set_showTransition(0);
        Dialog_content.set_closeTransition(0);
        Dialog_content.set_animationType('None');
        Dialog_content.set_animationPath('Direct');
         
        Dialog_content.set_modal(modal);

        Dialog_content.set_contentUrl(obj); 
        
        var intWidth;
        intWidth = window.screen.availWidth;
        var intHeight
        intHeight = window.screen.availHeight;

        var dialogDiv = document.getElementById(Dialog_content.get_id());
        var dialogIFrame = document.getElementById(Dialog_content.get_id() + '_IFrame');
        
        Dialog_content.Width = intWidth - parseInt(intOffsetX * 2);
        Dialog_content.Height = intHeight - 110 - parseInt(intOffsetY * 2);
        dialogDiv.style.width = (intWidth - parseInt(intOffsetX * 2)) + "px";
        dialogDiv.style.height = (intHeight - 110 - parseInt(intOffsetY * 2)) + "px";
        dialogIFrame.style.width = (intWidth - 30 - parseInt(intOffsetX * 2)) + "px";
        dialogIFrame.style.height = (intHeight - 140 - parseInt(intOffsetY * 2)) + "px";
        dialogIFrame.setAttribute("name", "maincontent");
        
        var intY;
        if (parseInt(intOffsetY) > 120)
            intY = parseInt(intHeight / 5);
        else
            intY = parseInt(intOffsetY);
        
        Dialog_content.OffsetX = intOffsetX;
        Dialog_content.OffsetY = intY;
        
        Dialog_content.set_x(null);
        Dialog_content.set_y(null);

        Dialog_content.endUpdate();

        Dialog_content.Show();
        
    }
}


function toggle_content_child(obj, modal, dialogtitle, intOffsetX, intOffsetY) {
    if (Dialog_content_child.get_isShowing()) {
        Dialog_content_child.Close();
    }
    else {
        Dialog_content_child.beginUpdate();
        Dialog_content_child.set_title(dialogtitle);

        Dialog_content_child.set_showTransition(0);
        Dialog_content_child.set_closeTransition(0);
        Dialog_content_child.set_animationType('None');
        Dialog_content_child.set_animationPath('Direct');

        Dialog_content_child.set_modal(modal);

        Dialog_content_child.set_contentUrl(obj);

        var intWidth;
        intWidth = window.screen.availWidth;
        var intHeight
        intHeight = window.screen.availHeight;

        var dialogDiv = document.getElementById(Dialog_content_child.get_id());
        var dialogIFrame = document.getElementById(Dialog_content_child.get_id() + '_IFrame');

        Dialog_content_child.Width = intWidth - parseInt(intOffsetX * 2);
        Dialog_content_child.Height = intHeight - 110 - parseInt(intOffsetY * 2);
        dialogDiv.style.width = (intWidth - parseInt(intOffsetX * 2)) + "px";
        dialogDiv.style.height = (intHeight - 110 - parseInt(intOffsetY * 2)) + "px";
        dialogIFrame.style.width = (intWidth - 30 - parseInt(intOffsetX * 2)) + "px";
        dialogIFrame.style.height = (intHeight - 140 - parseInt(intOffsetY * 2)) + "px";

        var intY;
        if (parseInt(intOffsetY) > 120)
            intY = parseInt(intHeight / 5);
        else
            intY = parseInt(intOffsetY);

        Dialog_content_child.OffsetX = intOffsetX;
        Dialog_content_child.OffsetY = intY;

        Dialog_content_child.set_x(null);
        Dialog_content_child.set_y(null);

        Dialog_content_child.endUpdate();

        Dialog_content_child.Show();

    }
}


function toggle_content_fix(obj, modal, dialogtitle, intOffsetX, intOffsetY, intWidth, intHeight) {
    if (Dialog_content.get_isShowing()) {
        Dialog_content.Close();
    }
    else {
        Dialog_content.beginUpdate();
        Dialog_content.set_title(dialogtitle);

        Dialog_content.set_showTransition(0);
        Dialog_content.set_closeTransition(0);
        Dialog_content.set_animationType('None');
        Dialog_content.set_animationPath('Direct');

        Dialog_content.set_modal(modal);

        Dialog_content.set_contentUrl(obj);

        var dialogDiv = document.getElementById(Dialog_content.get_id());
        var dialogIFrame = document.getElementById(Dialog_content.get_id() + '_IFrame');

        var contintOffsetX; // = parseInt(intOffsetX * 2);
        contintOffsetX = 0;


        Dialog_content.Width = intWidth - contintOffsetX;
        Dialog_content.Height = intHeight - contintOffsetX;
        dialogDiv.style.width = (intWidth - contintOffsetX) + "px";
        dialogDiv.style.height = (intHeight - contintOffsetX) + "px";
        dialogIFrame.style.width = (intWidth - 30 - contintOffsetX) + "px";
        dialogIFrame.style.height = (intHeight - 30 - contintOffsetX) + "px";


        Dialog_content.set_offsetX(intOffsetX);
        Dialog_content.set_offsetY(intOffsetY - 30);

        Dialog_content.set_x(null);
        Dialog_content.set_y(null);

        Dialog_content.endUpdate();

        Dialog_content.Show();

    }
}

function toggle_table_of_content(obj, modal, dialogtitle, intOffsetX, intOffsetY, intWidth, intHeight) {
    if (Dialog_Content_Table_Of_Contents.get_isShowing()) {
        Dialog_Content_Table_Of_Contents.Close();
    }
    else {
        Dialog_Content_Table_Of_Contents.beginUpdate();
        Dialog_Content_Table_Of_Contents.set_title(dialogtitle);

        Dialog_Content_Table_Of_Contents.set_showTransition(0);
        Dialog_Content_Table_Of_Contents.set_closeTransition(0);
        Dialog_Content_Table_Of_Contents.set_animationType('None');
        Dialog_Content_Table_Of_Contents.set_animationPath('Direct');

        Dialog_Content_Table_Of_Contents.set_modal(modal);

        Dialog_Content_Table_Of_Contents.set_contentUrl(obj);

        var dialogDiv = document.getElementById(Dialog_Content_Table_Of_Contents.get_id());
        var dialogIFrame = document.getElementById(Dialog_Content_Table_Of_Contents.get_id() + '_IFrame');

        var contintOffsetX;// = parseInt(intOffsetX * 2);
        contintOffsetX = 0;
        
        
        Dialog_Content_Table_Of_Contents.Width = intWidth - contintOffsetX;
        Dialog_Content_Table_Of_Contents.Height = intHeight - 110 - contintOffsetX;
        dialogDiv.style.width = (intWidth - contintOffsetX) + "px";
        dialogDiv.style.height = (intHeight - 110 - contintOffsetX) +  "px";
        dialogIFrame.style.width = (intWidth - 30 - contintOffsetX) + "px";
        dialogIFrame.style.height = (intHeight - 140 - contintOffsetX) + "px";


        Dialog_Content_Table_Of_Contents.set_offsetX(intOffsetX);
        Dialog_Content_Table_Of_Contents.set_offsetY(intOffsetY-30);

        Dialog_Content_Table_Of_Contents.set_x(null);
        Dialog_Content_Table_Of_Contents.set_y(null);

        Dialog_Content_Table_Of_Contents.endUpdate();

        Dialog_Content_Table_Of_Contents.Show();

    }
}



function Esc(inval, utf) {
    inval = escape(inval);
    if (utf == 0) {
        return inval;
    }
    outval = "";
    while (inval.length > 0) {
        p = inval.indexOf("%");
        if (p >= 0) {
            if (inval.charAt(p + 1) == "u") {
                outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 2, p + 6)));
                inval = inval.substring(p + 6, inval.length);
            } else {
                outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 1, p + 3)));
                inval = inval.substring(p + 3, inval.length);
            }
        } else {
            outval = outval + inval;
            inval = "";
        }
    }
    return outval;
}
function JStoURLEncode(c) {
    if (c < 0x80) {
        return Hexamize(c);
    } else if (c < 0x800) {
        return Hexamize(0xC0 | c >> 6) + Hexamize(0x80 | c & 0x3F);
    } else if (c < 0x10000) {
        return Hexamize(0xE0 | c >> 12) + Hexamize(0x80 | c >> 6 & 0x3F) + Hexamize(0x80 | c & 0x3F);
    } else if (c < 0x200000) {
        return Hexamize(0xF0 | c >> 18) + Hexamize(0x80 | c >> 12 & 0x3F) + Hexamize(0x80 | c >> 6 & 0x3F) + Hexamize(0x80 | c & 0x3F);
    } else {
        return '?'		// Invalid character
    }
}

function Hexamize(n) {
    hexstr = "0123456789ABCDEF";
    return "%" + hexstr.charAt(parseInt(n / 16)) + hexstr.charAt(n % 16);
}

function MicrosoftKeyPress(obj) {
    if (window.event.keyCode == 13) {
        if (eval("document.forms[0]." + obj + (curtab + 1))) {
            eval("document.forms[0]." + obj + (curtab + 1) + ".focus()");
        }
        window.event.keyCode = 27;
    }
}

function MicrosoftKeyPressServer(obj) {
    if (window.event.keyCode == 13) {
        if (eval(document.getElementById(obj + (curtab + 1)))) {
            document.getElementById(obj + (curtab + 1)).focus();
        }        
        window.event.keyCode = 27;
    }
}

function ReplaceAll(Source, stringToFind, stringToReplace) {
    var temp = Source;
    var index = temp.indexOf(stringToFind);
    while (index != -1) {
        temp = temp.replace(stringToFind, stringToReplace);
        index = temp.indexOf(stringToFind);
    }
    return temp;
}


//Check Date of dateobjects.
function CheckValidDate(objDateField, strDateFormat) {
    strDateFormat = strDateFormat.toLowerCase();
    mdateval = eval(objDateField).value;
    switch (strDateFormat) {
        case 'dd/mm/yyyy':
            if (mdateval != "") {
                var objar = mdateval.split('/');
                if (objar.length != 3) {
                    return false;
                }
                mday = mdateval.substring(0, mdateval.indexOf("/"));
                mmonth = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"));
                myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
                if (mday.length > 2 || mmonth.length > 2) {
                    return false;
                }
                mdate = new Date(mmonth + "/" + mday + "/" + myear);
                cday = mdate.getDate();
                cmonth = mdate.getMonth() + 1;
                cyear = mdate.getYear();
                if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4) || (myear.length > 4) || (myear < 1753)) {
                    return false;
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
                    return false;
                }
                break;
            }
    }
    return true;
}


function getFlashMovieObject(movieName) {
    if (window.document[movieName]) {
        return window.document[movieName];
    }

    if (document.embeds && document.embeds[movieName]) {
        return document.embeds[movieName];
    }
    else {
        return document.getElementById(movieName);
    }
}








/*----------------------------- PhuongNT -------------------*/

function CheckDate(objDateField, strDateFormat, strMsg) {
    //Check Date of dateobjects.
    //User:NVK
    //Date:29/8/2003
    strDateFormat = strDateFormat.toLowerCase();
    mdateval = eval(objDateField).value;
    switch (strDateFormat) {
        case 'dd/mm/yyyy':
            if (mdateval != "") {
                var objar = mdateval.split('/');
                if (objar.length != 3) {
                    alert(strMsg);
                    return false;
                }
                mday = mdateval.substring(0, mdateval.indexOf("/"));
                mmonth = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"));
                myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
                if (mday.length > 2 || mmonth.length > 2) {
                    alert(strMsg);
                    return false;
                }
                mdate = new Date(mmonth + "/" + mday + "/" + myear);
                cday = mdate.getDate();
                cmonth = mdate.getMonth() + 1;
                cyear = mdate.getYear();
                if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4) || (myear.length > 4) || (myear < 1753)) {
                    alert(strMsg);
                    eval(objDateField).value = "";
                    eval(objDateField).focus();
                    return false;
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
                    alert(strMsg);
                    eval(objDateField).value = "";
                    eval(objDateField).focus();
                    return false;
                }
                break;
            }
    }
    return true;
}

function detectBrowser() {
    var browser = navigator.appName;
    //var b_version=navigator.appVersion;
    //var version=parseFloat(b_version);
    if (browser == "Microsoft Internet Explorer")
    { return 1; }
    //"Mozilla Firefox"
    if (browser == "Netscape")
    { return 2; }
    if (browser == "Opera")
    { return 3; }
}
function getHeightByBrowse() {
    var iBrowse = detectBrowser()
    switch (iBrowse) {
        case 1:
            return self.document.documentElement.clientHeight;
            break;
        case 2:
            return window.innerHeight;
            break;
        case 3:
            return window.innerHeight;
            break;
        default:
            return self.document.documentElement.clientHeight;
    }
}
function getWidthByBrowse() {
    var iBrowse = detectBrowser()
    switch (iBrowse) {
        case 1:
            return self.document.documentElement.clientWidth;
            break;
        case 2:
            return window.innerWidth;
            break;
        case 3:
            return window.innerWidth;
            break;
        default:
            return self.document.documentElement.clientWidth;

    }
}
function alertSize() {
    var myWidth = 0, myHeight = 0;
    if (typeof (window.innerWidth) == 'number') {
        //Non-IE
        myWidth = window.innerWidth;
        myHeight = window.innerHeight;
    } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
        //IE 6+ in 'standards compliant mode'
        myWidth = document.documentElement.clientWidth;
        myHeight = document.documentElement.clientHeight;
    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
        //IE 4 compatible
        myWidth = document.body.clientWidth;
        myHeight = document.body.clientHeight;
    }
    window.alert('Width = ' + myWidth);
    window.alert('Height = ' + myHeight);
}
/*-----------------END PhuongNT -------------------*/

// Cancels the default context menu browser event 
function CancelContextMenu(evt) {
    evt = (evt == null) ? window.event : evt;
    evt.cancelBubble = true;
    evt.returnValue = false;
    evt.preventDefault(); //Firefox
    return false;
}