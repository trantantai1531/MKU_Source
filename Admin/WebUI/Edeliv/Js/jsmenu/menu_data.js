
/*
Milonic DHTML Menu - JavaScript Website Navigation System.
Copyright 2004 (c) Milonic Solutions Limited. All Rights Reserved.
Version 5+ Data File structure is the property of Milonic Solutions Ltd and must only be used in Milonic DHTML Products
This is a commercial software product, please visit http://www.milonic.com/ for more information.
See http://www.milonic.com/license.php for Commercial License Agreement
All Copyright statements must always remain in place in all files at all times
*******  PLEASE NOTE: THIS IS NOT FREE SOFTWARE, IT MUST BE LICENSED FOR ALL USE  ******* 
*/

_menuCloseDelay=500           // The time delay for menus to remain visible on mouse out
_menuOpenDelay=150            // The time delay before menus open on mouse over
_subOffsetTop=10              // Sub menu top offset
_subOffsetLeft=-10            // Sub menu left offset



with(menuStyle=new mm_style()){
onbgcolor="#4F8EB6";
oncolor="#ffffff";
offbgcolor="#DCE9F0";
offcolor="#515151";
bordercolor="#296488";
borderstyle="solid";
borderwidth=1;
separatorcolor="#2D729D";
separatorsize="1";
padding=5;
fontsize="75%";
fontstyle="normal";
fontfamily="Verdana, Tahoma, Arial";
pagecolor="black";
pagebgcolor="#82B6D7";
headercolor="#000000";
headerbgcolor="#ffffff";
subimage="arrow.gif";
subimagepadding="2";
overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color='#777777', Direction=135, Strength=5)";
outfilter="randomdissolve(duration=0.3)";
}


with(milonic=new menuname("Samples")){
style=menuStyle;
overflow="scroll";
aI("text=Horizontal Navigational Menu;url=/menusample1.php;");
aI("text=Vertical Navigational Menu;url=/menusample2.php;");
aI("text=All Horizontal Menus;url=/menusample25.php;");
aI("text=Using The Popup Menu Function Fixed Position;url=/menusample3.php;");
aI("text=Using The Popup Menu Function Positioned by Images;url=/menusample24.php;");
aI("text=Image Map Sample;url=/menusample4.php;");
aI("text=Multiple Styles;url=/menusample5.php;");
aI("text=Menus and Tool Tips;url=/menusample6.php;");
aI("text=Multiple Colored Menus;url=/menusample7.php;");
aI("text=Menu Items as Headers;url=/menusample8.php;");
aI("text=Windows XP Style Menus;url=/menusample12.php;");
aI("text=Windows 98 Style Menus;url=/menusample13.php;");
aI("text=Relative Positioning (Table Bound);url=/menusample9.php;");
aI("text=Follow Scrolling;url=/menusample10.php;");
aI("text=Opening Windows & Frames;url=/menusample11.php;");
aI("text=Hiding DIVs when displaying menus;url=/menusample14.php;");
aI("text=Activating MouseOver & MouseOut Functions;url=/menusample15.php;");
aI("text=Dynamic Dragable Menus;url=/menusample22.php;");
aI("text=Positioning with screenposition & offsets;url=/menusample23.php;");
aI("text=100% Width Span Menu;url=/menusample26.php;");
aI("text=Context Right Click Menu;url=/menusample27.php;");
aI("text=Static Images Sample;url=/menusample16.php;");
aI("text=Rollover/swap Images;url=/menusample17.php;");
aI("text=Menus built from images;url=/menusample18.php;");
aI("text=Images as Menu Backgrounds;url=/menusample19.php;");
aI("text=Background Menu Item Images;url=/menusample20.php;");
}

with(milonic=new menuname("Milonic")){
style=menuStyle;
aI("text=Product Purchasing Page;url=http://milonic.com/cbuy.php;");
aI("text=Contact Us;url=http://milonic.com/contactus.php;");
aI("text=Newsletter Subscription;url=http://milonic.com/newsletter.php;");
aI("text=FAQ;url=http://milonic.com/menufaq.php;");
aI("text=Discussion Forum;url=http://milonic.com/forum/;");
aI("text=Software License Agreement;url=http://milonic.com/license.php;");
aI("text=Privacy Policy;url=http://milonic.com/privacy.php;");
}

with(milonic=new menuname("Partners")){
style=menuStyle;
aI("text=(aq) Web Hosting;url=http://www.a-q.co.uk/;status=(aq) Web Server Hosting & Services;");
aI("text=SMS 2 Email;url=http://www.sms2email.com/;");
aI("text=WebSmith;url=websmith;");
}

with(milonic=new menuname("Links")){
style=menuStyle;
aI("text=Apache Web Server;url=http://www.apache.org/;status=Apache Web Server, the basis of Milonic's Web Site;");
aI("text=MySQL Database Server;url=http://ww.mysql.com/;status=MySQL, Milonic's Prefered Choice of Database Server;");
aI("text=PHP - Development;url=http://www.php.net/;status=PHP - Web Server Scripting as used by Milonic;");
aI("text=phpBB Web Forum System;url=http://www.phpbb.net/;status=PHP Based Web Forum, Milonic's Recommended Forum Software;");
aI("text=Anti Spam Tools;showmenu=Anti Spam;status=Anti Spam Solutions, as used by Milonic;");
}

with(milonic=new menuname("Anti Spam")){
style=menuStyle;
aI("text=Spam Cop;url=http://www.spamcop.net/;");
aI("text=Mime Defang;url=http://www.mimedefang.org/;");
aI("text=Spam Assassin;url=http://www.spamassassin.org/;");
}

with(milonic=new menuname("My Milonic")){
style=menuStyle;
aI("text=Login;url=http://milonic.com/login.php;");
aI("text=Licenses;url=http://milonic.com/mylicenses.php;");
aI("text=Invoices;url=http://milonic.com/myinvoices.php;");
aI("text=Make Support Request;url=http://milonic.com/reqsupport.php;");
aI("text=View Support Requests;url=http://milonic.com/mysupport.php;");
aI("text=Your Details;url=http://milonic.com/mydetails.php;");
}

drawMenus();

