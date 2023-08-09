var cfd;
function s(z,Z) {
	for(i=0;i<z.length;i++) {
		if(z[i]==Z)
			return true;
	}
	return false;
}
function setCookie(name, value, expires, path, domain, secure) {
	var curCookie = name + "=" + escape(value) +
		((expires) ? "; expires=" + expires.toGMTString() : "") +
		((path) ? "; path=" + path : "") +
		((domain) ? "; domain=" + domain : "") +
		((secure) ? "; secure" : "");
	document.cookie = curCookie;
}
function delCookie (NameOfCookie) {
  document.cookie = NameOfCookie + "=" + "; expires=Thu, 01-Jan-70 00:00:01 GMT";
}
function fixDate(date) {
	var b = new Date(0);
	var s1 = b.getTime();
	if (s1 > 0)
		date.setTime(date.getTime() - s1);
}
function re() {
	var result=null;
	while(p2!=ec) {
		result=er[p2++];
		if(!s(po,result.s4) && learned.indexOf(result.s4+",")==-1 && !result.replaced) {
			if(directEdit=="NO") {
				if(cfd!=null && cfd!=result.fd)
					parent.opener.updateForm(cfd,y9[cfd]);
			}
			cfd=result.fd;
			return result;
		}
		else
			result=null;
	}
	if(result!=null) {
		if(directEdit=="NO") {
			if(cfd!=null && cfd!=result.fd)
				parent.opener.updateForm(cfd,y9[cfd]);
		}
		cfd=result.fd;
	}
	return result;
}
function runChecker() {
	var oy=re();
	if(oy!=null) {
		document.forms[0].notFound.value=oy.s4;
		for(i=0;i<10;i++) {
			if(i<oy.c) {
				// assigning option fails in Opera
				document.forms[0].pp.options[i].value=oy.b[i].text;
				document.forms[0].pp.options[i].text=oy.b[i].text;
			} else {
				document.forms[0].pp.options[i].value="";
				document.forms[0].pp.options[i].text="";
			}
		}
		if(oy.c>0) {
			document.forms[0].replacement.value=oy.b[0].text;
			document.forms[0].pp.options[0].selected=true;
		} else {
			document.forms[0].replacement.value=oy.s4;
		}
		showErrorInContext(oy);
	} else {
		f();
	}
}
function qy(hg) {
	nw="09,z23at2a2"+er[hg].s4+"97.12ag1z2g";
	var whichError=er[hg];
	ui=y9[cfd].substring(0,whichError.ho);
	ui+=nw;
	ui+=y9[cfd].substring(whichError.ho+whichError.s4.length,y9[cfd].length);
	return ui;
}
function pbj() {
	var h="";
	h+="<HTML><HEAD><TITLE>Spell Checker Preview Window<\/TITLE>";
	h+="<STYLE type=\"text/css\">";
	h+="body {background:#dddddd; margin:2px; padding:0px;}";
	h+="p {margin-top:0;margin-bottom:0;}";
	h+="<\/STYLE>";
	h+="<\/HEAD>";
	h+="<BODY>";
	var pt=qy(p2-1);
	var start=0;
	if(er[p2-1].ho>150) {
		start=pt.lastIndexOf(" ",er[p2-1].ho-150);
		if(start==-1)
			start=0;
	}
	var end=pt.length;
	if(er[p2-1].ho+170<pt.length) {
		end=pt.indexOf(" ",er[p2-1].ho+170);
		if(end==-1)
			end=pt.length;
	}
	var drawEllipse=true;
	if(end==pt.length)
		drawEllipse=false;
	pt=pt.substring(start,end);
	pt=r3(pt,"<","&lt;");
	pt=r3(pt,">","&gt;");
	pt=r3(pt,"09,z23at2a2","<font color=blue><strong>");
	pt=r3(pt,"97.12ag1z2g","<\/strong><\/font>");
	pt=r3(pt,"\r","<BR>");
	h+="<font face=\"Verdana, Arial, Helvetica, sans-serif\" size=2>";
	if(start!=0)
		h+="... ";
	h+=pt;
	if(drawEllipse)
		h+=" ...";
	h+="<\/font>";
	h+="<\/BODY>";
	h+="<\/HTML>";
	return h;
}
function blt() {
	var h="";
	h+="<HTML><HEAD><TITLE>Spell Checker Preview Window<\/TITLE>";
	h+="<STYLE type=\"text/css\">";
	h+="body {background:#dddddd; margin:0px; padding:0px;}";
	h+="p {margin-top:0;margin-bottom:0;}";
	h+="<\/STYLE>";
	h+="<\/HEAD>";
	h+="<BODY>";
	h+="<TABLE height=100% width=100% cellpadding=0 cellspacing=0>";
	h+="<TR><TD align=center valign=center><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=2><b>Correction Preview<\/b><\/font><\/TD><\/TR>";
	h+="<\/TABLE>";
	h+="<\/BODY><\/HTML>";
	return h;
}
function showErrorInContext(wa) {
   if(directEdit=="NO") {
      parent.frames["preview"].location.href="javascript:parent.pbj()";
   } else {
      mcd(wa);
   }
}
function mcd(wa) {
   var ho=wa.ho;
   var lineCount=0;
   for(var i=y9[cfd].indexOf("\n",0);i!=-1 && i<ho;i=y9[cfd].indexOf("\n",i+1))
      lineCount++;
   var s4=wa.s4;
   var ez=eval("opener."+opener.getSpellCheckItem(cfd)).createTextRange();
   ez.move("character",ho-lineCount);
   ez.moveEnd("character",s4.length);
   ez.select();
}
function r3(string,text,by) {
	var strLength = string.length, txtLength = text.length;
	if ((strLength == 0) || (txtLength == 0)) return string;
	var i = string.indexOf(text);
	if ((!i) && (text != string.substring(0,txtLength))) return string;
	if (i == -1) return string;
	var newstr = string.substring(0,i) + by;
	if (i+txtLength < strLength)
		newstr += r3(string.substring(i+txtLength,strLength),text,by);
	return newstr;
}
function confirmReplacement() {
	if(confirmAfterReplace) {
		return confirm("You are replacing: '"+er[p2-1].s4+
			"' with a word that is not from the suggestions.\n"+
			"Your replacement HAS NOT been validated.  If you choose to\n"+
			"continue and you are not sure of the proper spelling of your\n"+
			"replacement then you should rerun the spell check to verify\n"+
			"your replacement.\n\nChoose Ok to continue the replacement or Cancel.");
	} else {
		return true;
	}
}
function u8() {
	var nw=document.forms[0].replacement.value;
	var validreplacement=s(v,nw);
	if(!validreplacement) {
		if(!confirmReplacement())
			return;
	}
	trunc(p2-1,nw);
	if(directEdit=="YES")
		opener.updateForm(cfd,y9[cfd]);
	runChecker();
}
function tru() {
	var nw=document.forms[0].replacement.value;
	var validreplacement=s(v,nw);
	if(!validreplacement) {
		if(!confirmReplacement())
			return;
	}
	for(var i=p2-1;i<ec;i++) {
		if(er[i].s4==er[p2-1].s4 && er[i].fd==er[p2-1].fd)
			trunc(i,nw);
	}
	if(directEdit=="YES")
		opener.updateForm(cfd,y9[cfd]);
	runChecker();
}

function trunc(hg, nw) {
	var whichError=er[hg];
	ui=y9[cfd].substring(0,whichError.ho);
	ui+=nw;
	ui+=y9[cfd].substring(parseFloat(whichError.ho) + parseFloat(whichError.s4.length),y9[cfd].length);
	y9[cfd]=ui;
	whichError.replaced=true;
	var ro=(parseFloat(nw.length) - parseFloat(whichError.s4.length));
	for(var i=hg+1;i<ec && er[i].fd==er[hg].fd;i++) {
		er[i].ho = parseFloat(er[i].ho) + parseFloat(ro);
	}
}
function f() {
	if(directEdit=="NO"){
		parent.opener.updateForm(cfd,y9[cfd]);
		parent.close();
	} else {
		if (cfd) {
			var ez=eval("opener."+opener.getSpellCheckItem(cfd)).createTextRange();
			ez.moveStart("textedit",1);
			ez.moveEnd("textedit",1);
			ez.select();
		}
		self.close();		
	}
}
function cx() {
	runChecker();
}
function vb() {
	po[po.length]=er[p2-1].s4;
	runChecker();
}
function uu() {
	if(document.forms[0].pp.selectedIndex>=er[p2-1].c) {
		document.forms[0].pp.selectedIndex=er[p2-1].c-1;
	}
	if(document.forms[0].pp.selectedIndex!=-1)
		document.forms[0].replacement.value=document.forms[0].pp.options[document.forms[0].pp.selectedIndex].text;
}
function autoUpdate() {
	if(document.forms[0].pp.selectedIndex!=-1) {
		uu();
		u8();
	}
}
function i12() {
	var now = new Date();
	fixDate(now);
	now.setTime(now.getTime() + 10 * 365 * 24 * 60 * 60 * 1000);
	learned+=er[p2-1].s4+",";
	setCookie("learned",learned,now);
	runChecker();
}
function y7() {
	if(confirmAfterLearn){
		if(confirm("You are adding '"+er[p2-1].s4+"' to your personal dictionary! Choose Ok to continue or Cancel to abort.")) {
			i12();
		}
	} else {
		i12();
	}
}
