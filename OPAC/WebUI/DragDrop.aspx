<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DragDrop.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.DragDrop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
	<script src="js/ui/draggable.js"></script>
	<script src="js/ui/droppable.js"></script>
     <style>
      #draggable, #draggable2 { width: 100px; height: 100px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; border: 1px solid #999; }
      #droppable { width: 150px; height: 150px; padding: 0.5em; float: left; margin: 10px; border: 1px solid #999; }
      </style>
      <script>
          $(document).ready(function () {
              $("#draggable").draggable({ revert: "valid" });
              $("#draggable2").draggable({ revert: "invalid" });

              $("#droppable").droppable({
                  activeClass: "ui-state-default",
                  hoverClass: "ui-state-hover",
                  drop: function (event, ui) {
                      $(this)
              .addClass("ui-state-highlight")
              .find("p")
                .html("Dropped!");
                  }
              });
          });
      </script>
</head>
<body  class="metro"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <form id="form1" runat="server">
    <header data-load="OTop.aspx"></header>
    <div id="draggable" class="ui-widget-content">
      <p>I revert when I'm dropped</p>
    </div>
 
    <div id="draggable2" class="ui-widget-content">
      <p>I revert when I'm not dropped</p>
    </div>
 
    <div id="droppable" class="ui-widget-header">
      <p>Drop me here</p>
    </div>
 
    </form>
</body>
</html>
