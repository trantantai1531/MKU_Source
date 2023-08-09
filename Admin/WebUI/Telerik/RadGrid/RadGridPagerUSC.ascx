<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RadGridPagerUSC.ascx.vb" Inherits="Telerik_RadGridPagerUSC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<style type="text/css">
    .radGridPager 
    {
            display: inline-block;
            background-color: #F0A30A;
            height: 24px;
            margin-left: 6px;
            padding-top: 8px;
            color: white !important;
            text-align: center;
            width: 32px !important;
            margin-top: -10px;
            margin-bottom: 10px;
            
    }
    .txtCurrentPager 
    {
            font-size: 15px;
            height: 32px;
            margin-right: -5px;
            text-align: center;
            width: 32px;
            margin-top: 10px;
       
    }
    
</style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
<script>
    $(document).ready(function () {
        var textPageSize = document.getElementById('<%=tbRecordsPerPage.ClientID%>'); //Set selected

     setTimeout(function () {
         var comboxbox = $find('<%=rcbPageSize.ClientID %>');
              var itemLocation = comboxbox.findItemByText(textPageSize.value);

              itemLocation.select();
              return false;
          }, 100);
 });
      function load_<%=uniqueKey %>() {
        var textPageSize = document.getElementById('<%=tbRecordsPerPage.ClientID%>'); //Set selected

        setTimeout(function () {
            var comboxbox = $find('<%=rcbPageSize.ClientID %>');
            var itemLocation = comboxbox.findItemByText(textPageSize.value);

            // itemLocation.select();
        }, 5000);
    }
    
    function RadComboBox1_SelectedIndexChanged_<%=uniqueKey %>(sender, args) {
       
        var a = $("#<%=uniqueKey %>").parents(".RadGrid_Office2010Black").attr("id");
  
        var tableView = $find(a).get_masterTableView();

        var comboxbox = $find('<%=rcbPageSize.ClientID %>');
        var textPageSize = document.getElementById("<%=tbRecordsPerPage.ClientID%>");
        tableView.set_pageSize(comboxbox.get_value());
        textPageSize.value = comboxbox.get_value();


    }
</script>
<div style="font-size:medium" >
         <input type="hidden"  id="<%=uniqueKey %>">
<table border="0" cellpadding="5" width="100%" align="center" style="table-layout:fixed">
    <tr style="display: table-row; vertical-align: inherit">
        <td style="border-style: none; border-color: #ececec; font-size: medium">

         
            <asp:LinkButton ID="lbtnFirstPage" runat="server"
                CommandName="Page"
                CausesValidation="false"
                CommandArgument="First"
                CssClass="radGridPager">
      <<
            </asp:LinkButton>
       
        
            <asp:Label ID="lblFirstPage" runat="server"  Text="<<" CssClass="radGridPager" />
            &nbsp;
       
        
            <asp:LinkButton ID="lbtnPreviousPage" runat="server"
                CommandName="Page"
                CausesValidation="false"
                CommandArgument="Prev"
                CssClass="radGridPager">
      <
            </asp:LinkButton>
            <asp:Label runat="server" ID="lblPrevPage" SkinID="Title" Text="<" CssClass="radGridPager" />
            &nbsp;
           
    
     <asp:TextBox ID="tbPageNumber" runat="server" 
           OnTextChanged="tbPageNumber_TextChanged"  CssClass="txtCurrentPager"
          Text='<%# CType(Container, GridPagerItem).OwnerTableView.CurrentPageIndex + 1 %>' AutoPostBack="True" />
            &nbsp;
      /
      <asp:Label runat="server" ID="lblRowCount"  Text='<%# DataBinder.Eval(Container, "Paging.PageCount") %>' />
            &nbsp;
            <asp:LinkButton ID="lbtnNextPage" runat="server"
                CommandName="Page"
                CausesValidation="false"
                CommandArgument="Next"
                CssClass="radGridPager">
      >
            </asp:LinkButton>
            <asp:Label runat="server" ID="lblNextPage"  Text=">" CssClass="radGridPager"  />
            &nbsp;
            <asp:LinkButton ID="lbtnLastPage" runat="server"
                CommandName="Page"
                CausesValidation="false"
                CommandArgument="Last"
                CssClass="radGridPager">
      >>
            </asp:LinkButton>
   
           <asp:Label runat="server" ID="lblLastPage"  Text=">>" CssClass="radGridPager" />      
            <asp:Label ID="lbldash_1" runat="server" SkinID="Title" Text="( " />
            <asp:Label ID="lblRecordsCount" runat="server" SkinID="Title" Text='<%# Integer.Parse(DataBinder.Eval(Container, "OwnerTableView.Items.Count").ToString())%>'/>           
            <asp:Label ID="lbldash_2" runat="server" SkinID="Title" Text="/" />
            <asp:Label ID="lblNumOfRecords" SkinID="Title" runat="server" Text='<%# DataBinder.Eval(Container, "Paging.DataSourceCount") %>' />
            <asp:Label ID="lblRecrods" SkinID="Title" runat="server" Text="Records )" />
      <div style="float: right; margin-top: 15px; height: 100%">   
      <div style="display: inline-block;margin-top: 3px">
           <asp:Label ID="lblRecordsPerPage"  runat="server" Text="Page Size "/>
           </div>
           <div style="display: none">
            <asp:TextBox ID="tbRecordsPerPage" runat="server" 
                Columns="1" OnTextChanged="tbRecordsPerPage_TextChanged"
                Text='<%# DataBinder.Eval(Container, "Paging.PageSize") %>'
                AutoPostBack="true" ClientIDMode="Static" />
                </div>   
            <telerik:RadComboBox ID="rcbPageSize" runat="server" Width="55px" Skin="Metro"    >
            </telerik:RadComboBox>
        
      </div> 
        </td>
       
        


    </tr>
</table>
</div>