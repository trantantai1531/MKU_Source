<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OMap.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OMap" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script type="text/javascript" src="http://google-maps-utility-library-v3.googlecode.com/svn/tags/markerclusterer/1.0/src/markerclusterer.js"></script>
     <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
     <script src="js/ui/jquery.js"></script>
     <script src="js/ui/core.js"></script>
	 <script src="js/ui/widget.js"></script>
	 <script src="js/ui/mouse.js"></script>
     <script src="js/metro.min.js"></script>
     <script type="text/javascript" src="js/gmaps.js"></script>
     <script type="text/javascript">
         var map;
         var latitudeLoc = 0;
         var longitudeLoc = 0;
         var latitudeVN = 15.943086862716888;
         var longitudeVN = 106.989990234375;
         $(document).ready(function () {
             map = new GMaps({
                 el: '#map',
                 lat: latitudeVN,
                 lng: longitudeVN,
                 zoomControl: true,
                 zoom: 6,
                 zoomControlOpt: {
                     style: 'SMALL',
                     position: 'TOP_LEFT'
                 },
                 panControl: false,
                 streetViewControl: false,
                 mapTypeControl: false,
                 overviewMapControl: false,
                 markerClusterer: function (map) {
                     return new MarkerClusterer(map);
                 }
             });
             var opt = { minZoom: 6 };
             map.setOptions(opt);
             showAllMarker();             

             $('#geocoding_form').submit(function (e) {
                 e.preventDefault();
                 GMaps.geocode({
                     address: $('#address').val().trim(),
                     callback: function (results, status) {
                         if (status == 'OK') {
                             var latlng = results[0].geometry.location;
                             map.setCenter(latlng.lat(), latlng.lng());
                             map.setZoom(10); //8
                             /*map.addMarker({
                             lat: latlng.lat(),
                             lng: latlng.lng()
                             });*/
                         }
                     }
                 });
             });




             map.addControl({
                 position: 'top_right',
                 content: 'Trang chủ',
                 style: {
                     margin: '5px',
                     padding: '1px 6px',
                     border: 'solid 1px #717B87',
                     background: '#fff'
                 },
                 events: {
                     click: function () {
                         resetLocation();
                     }
                 }
             });


             map.addControl({
                 position: 'top_right',
                 content: 'Vị trí của bạn',
                 style: {
                     margin: '5px',
                     padding: '1px 6px',
                     border: 'solid 1px #717B87',
                     background: '#fff'
                 },
                 events: {
                     click: function () {
                         //setLocation();
                         GMaps.geolocate({
                             success: function (position) {
                                 latitudeLoc = position.coords.latitude;
                                 longitudeLoc = position.coords.longitude;
                                 map.setZoom(15);
                                 map.setCenter(position.coords.latitude, position.coords.longitude);
                             },
                             error: function (error) {
                                 //alert('Geolocation failed: ' + error.message);
                             },
                             not_supported: function () {
                                 alert("Trình duyệt của bạn không hỗ trợ tìm đường dẫn vị trí hiện tại.");
                             },
                             always: function () {
                                 // alert("Done!");
                             }
                         });
                     }
                 }
             });



         });

         function showCollection(siteId,collectionID) {
             self.location.href = "OShow.aspx?Site=" + siteId.toString() + "&DicID=14&BrowseId=" + collectionID.toString();
         }

         function gotoDocType(siteId, DocTypeID) {
             self.location.href = "OShow.aspx?Site=" + siteId.toString() + "&DicID=10&BrowseId=" + DocTypeID.toString();
         }

         function showAllMarker() {
             var serviceURL = 'eService.asmx/showAllMarker';
             var str = '';
             var intLibId = 0;
             var i = 0;
             var ilatitude = 0;
             var ilongitude = 0;
             var strLibrary = '';
             var jqxhrshowAllMarker = jQuery.ajax({
                 url: serviceURL,
                 type: 'GET',
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'json',
                 success: function (json) {
                     if (json.length > 0) {
                         for (i = 0; i < json.length; i++) {
                             if (intLibId == json[i].LibId) {
                                 //alert('==' + i.toString() + ' - ' + intLibId + ':' + json[i].LibId);
                                 str = str + '<a href="javascript:gotoDocType(' + json[i].LibId + ',' + json[i].DocTypeID + ');" class="list">';
                                 str = str + '<div class="list-content">';
                                 str = str + json[i].iconDocType + '&nbsp;';
                                 str = str + json[i].DocTypeName + ': ' + '<b>' +  json[i].ICOUNT + '</b>';
                                 str = str + '</div>';
                                 str = str + '</a>';
                             }
                             else {
                                 if (i > 0) {
                                     str = str + '</div>';
                                     //alert(str);
                                     map.addMarker({
                                         lat: ilatitude,
                                         lng: ilongitude,
                                         icon: 'Images/Library/gmapsLibraryP.png',
                                         title: strLibrary,
                                         infoWindow: {
                                             content: str
                                         }
                                     });
                                 }
                                 str = '<p><h6><a href="OIndex.aspx?Site=' + json[i].LibId + '">' + json[i].LibName + '</a><h6><address>' + json[i].LibAddress + '</address></p>';
                                 str = str + '<hr />';
                                 str = str + '<div class="listview-outlook">';
                                 str = str + '<a href="javascript:gotoDocType(' + json[i].LibId + ',' + json[i].DocTypeID + ');" class="list">';
                                 str = str + '<div class="list-content">';
                                 str = str + json[i].iconDocType +'&nbsp;';
                                 str = str + json[i].DocTypeName + ': ' + '<b>' + json[i].ICOUNT + '</b>';
                                 str = str + '</div>';
                                 str = str + '</a>';                                 
                                 //alert('>' + i.toString() + ' - ' + intLibId + ':' + json[i].LibId);
                             }
                             intLibId = json[i].LibId;
                             ilatitude = json[i].latitude;
                             ilongitude = json[i].longitude;
                             strLibrary = json[i].LibName;
                             /*
                             if (json[i].Cover) {
                             //str = str + '<p class="description padding20 bg-grayLighter">';
                             str = str + '<div class="tile quadro double-vertical">';
                             str = str + '<div class="tile-content">';
                             str = str + '<img src="' + json[i].Cover + '" onClick="javascript:showCollection(' + json[i].LibId + ',' + json[i].collectionID + ');"></img>';
                             if (json[i].DisplayEntry) {
                             str = str + '<div class="brand bg-dark opacity">';
                             str = str + '<span class="text">';
                             str = str + json[i].DisplayEntry;
                             str = str + '</span>';
                             str = str + '</div>';
                             }
                             str = str + '</div>';
                             str = str + '</div>';
                             //str = str + '</p>';
                             }
                             str = str + '<hr />';
                             str = str + '<div class="listview-outlook">';
                             str = str + '<a href="#" class="list">';
                             str = str + '<div class="list-content">';
                             str = str + '<span class="icon-book" style="background: red;color: white;padding: 5px;border-radius: 50%"></span>&nbsp;';
                             str = str + '<b>Bai trich:</b> 50';
                             str = str + '</div>';
                             str = str + '</a>';
                             str = str + '<a href="#" class="list">';
                             str = str + '<div class="list-content">';
                             str = str + '<span class="icon-pictures" style="background: green;color: white;padding: 5px;border-radius: 50%"></span>&nbsp;';
                             str = str + '<b>Bai trich:</b> 50';
                             str = str + '</div>';
                             str = str + '</a>';
                             str = str + '<a href="#" class="list">';
                             str = str + '<div class="list-content">';
                             str = str + '<span class="icon-film" style="background: blue;color: white;padding: 5px;border-radius: 50%"></span>&nbsp;';
                             str = str + '<b>Bai trich:</b> 50';
                             str = str + '</div>';
                             str = str + '</a>';
                             str = str + '<a href="#" class="list">';
                             str = str + '<div class="list-content">';
                             str = str + '<span class="icon-music" style="background: brown;color: white;padding: 5px;border-radius: 50%"></span>&nbsp;';
                             str = str + '<b>Bai trich:</b> 50';
                             str = str + '</div>';
                             str = str + '</a>';
                             str = str + '</div>';*/
                         }
                         str = str + '</div>';
                         map.addMarker({
                             lat: ilatitude,
                             lng: ilongitude,
                             icon: 'Images/Library/gmapsLibraryP.png',
                             title: strLibrary,
                             infoWindow: {
                                 content: str
                             }
                         });
                     }
                 },
                 error: function () {
                     //jQuery('#lstTableOfContentsAll').append('<li><p>L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u</p></li>'), jQuery('#lstTableOfContentsAll').listview('refresh');
                 }
             });
             jqxhrshowAllMarker.complete(function () {
             });
         }

         function resetLocation() {
             map.setCenter(latitudeVN, longitudeVN);
             map.setZoom(6);
         }

         function gotoLibrary(libId) {
             self.location.href = "OIndex.aspx?Site=" + libId.toString();
         }

         function changLanguage(val) {
             var Language = "Lang=" + val;
             var url = String(location.href);
             url = url.replace('Lang=', 'L=').replace('#', '');
             if (url != null)
                 if (url.indexOf("?") > 0)
                     url = String(url) + "&" + Language;
                 else
                     url = String(url) + "?" + Language;
             location.href = url;
         }

         function moveMarker(dlLatitude, dlLongitude) {
             map.setCenter(dlLatitude, dlLongitude);
             map.setZoom(19); //8
         }

  </script>
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
 <div class="navigation-bar" id="navHeader" runat="server" visible="false">
    <div class="navigation-bar-content container" style="height:55px;">
        <div class="grid fluid">
            <div class="row">                 
                 <div  class='span10'>
                   <div id="divWelcome" runat="server"><h3  class="fg-white"><img src="images/Imgviet/WhiteLogo.png" border="0" />&nbsp;Chào mừng đến với thư viện số - Hán Nôm</h3></div>
                </div> 
            </div>
        </div>
    </div>
    </div>
  <div class="container">
        <div class="grid fluid">    
            <div class="row">
                <div  class="span9">
                    <form method="post" id="geocoding_form">
                        <div class="element input-element">
                            <div class="input-control text" data-role="input-control"  id="divSearch" runat="server">
                                    <input type="text" placeholder="Nhập thông tin tìm kiếm của bạn ở đây" id="address" name="address" value=""/>
				                    <button class="btn-search" id="btSearch" type="submit" value="Tìm kiếm"></button>
			                </div>
                        </div>
                    </form>
                </div>
                <div class="span3">
                    <div  class="element place-right" style="margin-top:10px;">
                        <span id="spLanguage" runat="server"><B>Ngôn ngữ:</B></span>
                        <a class="dropdown-toggle" href="#" title="Thay đổi ngôn ngữ" runat="server" id="lnkChangLanguage">
					        <img src="images/Language/vie.png" style="height:22px;width:22px;text-align:center;vertical-align:text-top;margin-top:-3px;" id="imgFlag" runat="server"/>
				        </a>
				        <ul class="dropdown-menu place-right" data-role="dropdown">
                            <asp:Literal runat="server" ID="ltrLanguage"></asp:Literal>   
				        </ul>
                    </div>  
                </div>
            </div>       
            <div class="row">
                <div  class="span9">
                    <div id="map" style="margin-top:-25px;"></div> 
                </div>
                <div class="span3"  style="vertical-align:text-top;margin-top:-25px;">
                    <div id="divlibrary" class="scrollBarMap">
                        <asp:Literal runat="server" ID="lrtLibrary"></asp:Literal>
                    </div>                                     
                </div>
                
	        </div>
        </div>
    </div>
    <div class="page-footer" style="display:none;">
        <div class="page-footer-content">
            <uc1:UFooter ID="UFooter1" runat="server" />
        </div>
    </div> 
    <div style="display:none">
        <span id="spLanguageVietNamese" runat="server">Tiếng Việt</span>
        <span id="spLanguageEnglish" runat="server">Tiếng Anh</span>
        <span id="spFinish" runat="server">Hoàn thành...</span>
        <span id="spLibrary" runat="server">Địa điểm đã số hóa Hán Nôm</span>
    </div>

     
</body>
</html>
