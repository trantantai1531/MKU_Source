<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WOAIHavester.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WOAIHavester"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WOAIHavester</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ChangeFontType();document.forms[0].txtURLReSource.focus();"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="../Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2"><img border="0" src="../Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><img border="0" src="../Images/ImgViet/title_03.gif" width="40" height="40"></td>
								<td background="../Images/ImgViet/title_bg.gif" align="left"><asp:label id="lblTitleOaiHavester" CssClass="lbTitleHeader" Runat="server">OAI - PMH</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2" height="10"></td>
				</tr>
			</table>
			<table id="Table4" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<tr class="lbPageTitle">
					<td><asp:label id="lblHead" runat="server" CssClass="lbPageTitle">Kết nối OAI</asp:label><asp:label id="lblHeadResult" runat="server" CssClass="lbPageTitle">Kết quả tra cứu</asp:label></td>
				</tr>
				<tr id="TROAI">
					<td><asp:hyperlink id="lnkOAI" Runat="server" NavigateUrl="#OAIForm">Kết nối OAI</asp:hyperlink></td>
				</tr>
				<TR id="TRHead1">
					<TD><asp:label id="lblHeadDes" runat="server">Hãy nhập URL trỏ tới giao diện OAI (toàn bộ phần nằm trước dấu ?) hoặc chọn từ danh sách các nguồn tư liệu nhập sẵn dưới đây.<BR>Sau đó bấm chuột vào thao tác cần tiến hành (cần nhập đủ các tham số cần thiết)</asp:label></TD>
				</TR>
				<TR id="TRHead2">
					<TD><asp:label id="lblURLH" runat="server" Font-Bold="True">URL:</asp:label>&nbsp;<asp:label id="lblURLReVal" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR id="TRHead3">
					<TD><asp:label id="lblVerbH" runat="server" Font-Bold="True">Thao tác:</asp:label>&nbsp;<asp:label id="lblVerbVal" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR id="TRHead4">
					<TD><asp:label id="lblReponseH" runat="server" Font-Bold="True">Thời điểm trả lời:</asp:label>&nbsp;<asp:label id="lblResponseVal" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<tr class="lbPageTitle" id="TRInforReq">
					<td><asp:label id="lblDES" runat="server" CssClass="lbPageTitle">Mô tả nguồn lưu trữ</asp:label></td>
				</tr>
				<TR>
					<TD>
						<table id="tblError" width="100%" border="0">
							<tr class="lbPageTitle">
								<td colSpan="2"><asp:label id="lblError" runat="server" CssClass="lbPageTitle" Font-Bold="True">Lỗi xảy ra</asp:label></td>
							</tr>
							<TR>
								<TD width="30%"><asp:label id="lblErrorCode" runat="server" Font-Bold="True" Visible="False">Mã lỗi: </asp:label></TD>
								<TD><asp:label id="lblErrorCodeval" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblErrorDetail" runat="server" Font-Bold="True" Visible="False">Chi tiết: </asp:label></TD>
								<TD><asp:label id="lblErrorDetailVal" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR id="TRXML">
					<TD><asp:label id="lblXML" runat="server"></asp:label></TD>
				</TR>
				<TR id="TRToken1">
					<TD><asp:label id="lblToltalRec" runat="server" Font-Bold="True" Visible="False">Tổng số biểu ghi: </asp:label><asp:label id="lblToltalRecVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR id="TRToken2">
					<TD><asp:label id="lblCurrentRec" runat="server" Font-Bold="True" Visible="False">Xem từ biểu ghi số: </asp:label><asp:label id="lblCurrentRecVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR id="TRToken3">
					<TD><asp:hyperlink id="lnkNextRec" runat="server" Visible="False">Trang tiếp</asp:hyperlink></TD>
				</TR>
			</table>
			<table id="tblIdentify" width="100%" border="0">
				<TR>
					<TD align="right" width="25%"><asp:label id="lblrepositoryName" runat="server" Font-Bold="True" Visible="False">Tên nguồn:</asp:label></TD>
					<TD><asp:label id="lblrepositoryNameVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblbaseURL" runat="server" Font-Bold="True" Visible="False">Địa chỉ cơ sở:</asp:label></TD>
					<TD><asp:label id="lblbaseURLVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblprotocolVersion" runat="server" Font-Bold="True" Visible="False">phiên bản:</asp:label></TD>
					<TD><asp:label id="lblprotocolVersionVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbladminEmail" runat="server" Font-Bold="True" Visible="False">Email của người quản trị:</asp:label></TD>
					<TD><asp:label id="lbladminEmailVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblearliestDatestamp" runat="server" Font-Bold="True" Visible="False">Thời điểm bắt đầu có tư liệu:</asp:label></TD>
					<TD><asp:label id="lblearliestDatestampVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbldeleteRecord" runat="server" Font-Bold="True" Visible="False">Ghi chú về các bản ghi bị xóa:</asp:label></TD>
					<TD><asp:label id="lbldeleteRecordVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblgranularity" runat="server" Font-Bold="True" Visible="False">Khuôn dạng ngày tháng hỗ trợ</asp:label></TD>
					<TD><asp:label id="lblgranularityVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblcompression" runat="server" Font-Bold="True" Visible="False">Cách nén dữ liệu:</asp:label></TD>
					<TD><asp:label id="lblcompressionVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbldescription" runat="server" Font-Bold="True" Visible="False">Mô tả:</asp:label></TD>
					<TD><asp:label id="lbldescriptionVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbloai_identifier" runat="server" Font-Bold="True" Visible="False">oai-identifier:</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblscheme" runat="server" Font-Bold="True" Visible="False">scheme:</asp:label></TD>
					<TD><asp:label id="lblschemeVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblrepositoryIdentifier" runat="server" Font-Bold="True" Visible="False">repositoryIdentifier:</asp:label></TD>
					<TD><asp:label id="lblrepositoryIdentifierVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbldelimiter" runat="server" Font-Bold="True" Visible="False">delimiter:</asp:label></TD>
					<TD><asp:label id="lbldelimiterVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblsampleIdentifier" runat="server" Font-Bold="True" Visible="False">sampleIdentifier:</asp:label></TD>
					<TD><asp:label id="lblsampleIdentifierVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblcontent" runat="server" Font-Bold="True" Visible="False">content:</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblURLCon" runat="server" Font-Bold="True" Visible="False">URL:</asp:label></TD>
					<TD><asp:label id="lblURLConVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblTextCon" runat="server" Font-Bold="True" Visible="False">Text:</asp:label></TD>
					<TD><asp:label id="lblTextConVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblcollectionIcon" runat="server" Font-Bold="True" Visible="False">collectionIcon:</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblurlCol" runat="server" Font-Bold="True" Visible="False">URL:</asp:label></TD>
					<TD><asp:label id="lblurlColVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblLinkCol" runat="server" Font-Bold="True" Visible="False">Link :</asp:label></TD>
					<TD><asp:label id="lblLinkColVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblTitleCol" runat="server" Font-Bold="True" Visible="False">Title:</asp:label></TD>
					<TD><asp:label id="lblTitleColVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblWidthCol" runat="server" Font-Bold="True" Visible="False">Width:</asp:label></TD>
					<TD><asp:label id="lblWidthColVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblHeightCol" runat="server" Font-Bold="True" Visible="False">Heigth:</asp:label></TD>
					<TD><asp:label id="lblHeightColVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblmetadataRendering" runat="server" Font-Bold="True" Visible="False">metadataRendering:</asp:label></TD>
					<TD><asp:label id="lblmetadataRenderingVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
			<table width="100%" border="0">
				<tr id="TRListIdentifiers">
					<td><asp:datagrid id="dtgListIdentifiers" runat="server" Visible="False" AutoGenerateColumns="False"
							Width="100%">
							<Columns>
								<asp:BoundColumn DataField="identifier" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="datestamp" HeaderText="Ngày cập nhật"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr id="TRListMetadataFormats">
					<td><asp:datagrid id="dtgListMetadataFormats" runat="server" Visible="False" AutoGenerateColumns="False"
							Width="100%">
							<Columns>
								<asp:BoundColumn DataField="metadataPrefix" HeaderText="Tên khuôn dạng"></asp:BoundColumn>
								<asp:BoundColumn DataField="schema" HeaderText="Giản đồ"></asp:BoundColumn>
								<asp:BoundColumn DataField="metadataNamespace" HeaderText="Nguồn"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr id="TRLitSets">
					<td><asp:label id="lblListSet" Runat="server"></asp:label><asp:datagrid id="dtgListSets" runat="server" Visible="False" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblIDSet" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"set_Id") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="setSpec" ReadOnly="True" HeaderText="setSpec"></asp:BoundColumn>
								<asp:BoundColumn DataField="setName" ReadOnly="True" HeaderText="setName"></asp:BoundColumn>
								<asp:ButtonColumn Text="Chi tiết" HeaderText="Chi tiết" CommandName="Select"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr id="TRListRecord">
					<td><asp:label id="lblListRecord" runat="server"></asp:label></td>
				</tr>
			</table>
			<a name="#Detail"></a>
			<table id="tblListSetsDetail" width="100%" border="0">
				<tr>
					<td align="right" width="20%"><asp:label id="lblTitle" runat="server" Font-Bold="True" Visible="False">Nhan đề: </asp:label></td>
					<td><asp:label id="lblTitleVal" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblAuthor" runat="server" Font-Bold="True" Visible="False">Tác giả: </asp:label></TD>
					<TD><asp:label id="lblAuthorVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblDescriptionSet" runat="server" Font-Bold="True" Visible="False">Mô tả: </asp:label></TD>
					<TD><asp:label id="lblDescriptionSetVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblType" runat="server" Font-Bold="True" Visible="False">Kiểu: </asp:label></TD>
					<TD><asp:label id="lblTypeVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblcoverage" runat="server" Font-Bold="True" Visible="False">Phạm vi bao quát: </asp:label></TD>
					<TD><asp:label id="lblcoverageVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblSubject" runat="server" Font-Bold="True" Visible="False">Chủ đề: </asp:label></TD>
					<TD><asp:label id="lblSubjectVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblcontributor" runat="server" Font-Bold="True" Visible="False">Người đóng góp: </asp:label></TD>
					<TD><asp:label id="lblcontributorVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblrelation" runat="server" Font-Bold="True" Visible="False">Liên quan: </asp:label></TD>
					<TD><asp:label id="lblrelationVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
			<table id="tblRecordDetail" width="100%" border="0">
				<TR>
					<TD align="right" width="20%"><asp:label id="lblIDR" runat="server" Font-Bold="True" Visible="False">ID:</asp:label></TD>
					<TD><asp:label id="lblIDRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lbldatestampR" runat="server" Font-Bold="True" Visible="False">Ngày cập nhật: </asp:label></TD>
					<TD><asp:label id="lbldatestampRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblsetSpecR" runat="server" Font-Bold="True" Visible="False">Thư mục: </asp:label></TD>
					<TD><asp:label id="lblsetSpecRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<tr>
					<td align="right" width="20%"><asp:label id="lblTitleR" runat="server" Font-Bold="True" Visible="False">Nhan đề: </asp:label></td>
					<td><asp:label id="lblTitleRVal" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblPublisherR" runat="server" Font-Bold="True" Visible="False">Xuất bản:</asp:label></TD>
					<TD><asp:label id="lblPublisherRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblSubjecR" runat="server" Font-Bold="True" Visible="False">Chủ đề: </asp:label></TD>
					<TD><asp:label id="lblSubjecRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lbldescriptionR" runat="server" Font-Bold="True" Visible="False">Mô tả: </asp:label></TD>
					<TD><asp:label id="lbldescriptionRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lbldateR" runat="server" Font-Bold="True" Visible="False">Ngày tháng: </asp:label></TD>
					<TD><asp:label id="lbldateRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblTypeR" runat="server" Font-Bold="True" Visible="False"> Kiểu: </asp:label></TD>
					<TD><asp:label id="lblTypeRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblidentifierR" runat="server" Font-Bold="True" Visible="False">Địa chỉ: </asp:label></TD>
					<TD><asp:label id="lblidentifierRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lbllanguageR" runat="server" Font-Bold="True" Visible="False">Ngôn ngữ : </asp:label></TD>
					<TD><asp:label id="lbllanguageRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblcoverageR" runat="server" Font-Bold="True" Visible="False">Phạm vi bao quát : </asp:label></TD>
					<TD><asp:label id="lblcoverageRVal" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
			<a name="#OAIform"></a>
			<table width="100%" border="0">
				<tr class="lbPageTitle" id="TROAILink">
					<td><asp:label id="lblOAILink" Runat="server" CssClass="lbPageTitle">Kết nối OAI</asp:label></td>
				</tr>
				<TR id="TROAIHead">
					<TD><asp:label id="lblOAIHelp" runat="server">Hãy nhập URL trỏ tới giao diện OAI (toàn bộ phần nằm trước dấu ?) hoặc chọn từ danh sách các nguồn tư liệu nhập sẵn dưới đây.<BR>Sau đó bấm chuột vào thao tác cần tiến hành (cần nhập đủ các tham số cần thiết)</asp:label></TD>
				</TR>
				<tr>
					<td><asp:label id="lblRULCap" runat="server"><u>U</u>RL</asp:label>&nbsp;
						<asp:textbox id="txtURLReSource" runat="server" Width="456px"></asp:textbox></td>
				</tr>
				<TR>
					<TD><asp:label id="lblURLResource" runat="server">Danh <u>s</u>ách các nguồn tư liệu:</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:listbox id="lstURLResource" runat="server" Height="130px"></asp:listbox></TD>
				</TR>
			</table>
			<table id="Table3" width="100%" border="0">
				<tr class="lbPageTitle">
					<td style="HEIGHT: 18px" colSpan="2"><asp:label id="Label8" runat="server" CssClass="lbPageTitle">Thao tác</asp:label></td>
					<td style="HEIGHT: 18px"><asp:label id="Label9" runat="server" CssClass="lbPageTitle">Các tham số</asp:label></td>
				</tr>
				<TR>
					<TD><asp:hyperlink id="lnkIdentify" runat="server">Identify</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label1" runat="server"><u>f</u>rom :</asp:label></TD>
					<TD><asp:textbox id="txtfrom" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:hyperlink id="lnkListMetadataFormats" runat="server">List Metadata Formats</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label2" runat="server">unti<u>l</u> :</asp:label></TD>
					<TD><asp:textbox id="txtUntil" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:hyperlink id="lnkListSets" runat="server">List Sets</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label3" runat="server"><u>m</u>etadataPrefix :</asp:label></TD>
					<TD><asp:textbox id="txtmetadataPrefix" runat="server">oai_dc</asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:hyperlink id="lnkListIdentifiers" runat="server">List Identifiers</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label4" runat="server"><u>i</u>dentifier :</asp:label></TD>
					<TD><asp:textbox id="txtidentifier" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:hyperlink id="lnkListRecords" runat="server">List Records</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label5" runat="server">se<u>t</u> :</asp:label></TD>
					<TD><asp:textbox id="txtSET" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:hyperlink id="lnkGetRecord" runat="server">Get Record</asp:hyperlink></TD>
					<TD align="right"><asp:label id="Label6" runat="server"><u>r</u>esumptionToken :</asp:label></TD>
					<TD><asp:textbox id="txtresumptionToken" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right"><asp:label id="Label7" runat="server">Khuôn dạng: </asp:label></TD>
					<TD><asp:radiobutton id="optParse" runat="server" Checked="True" GroupName="ParseFormat" Text="<u>P</u>hân tách"></asp:radiobutton><asp:radiobutton id="optXML" runat="server" GroupName="ParseFormat" Text="<u>X</u>ML"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right"></TD>
					<TD><INPUT id="txtVerb" type="hidden" name="txtVerb" runat="server"> <INPUT id="txtShowInforReq" type="hidden" value="0" name="txtShowInforReq" runat="server">
						<INPUT id="txtError" type="hidden" value="0" name="txtError" runat="server"> <INPUT id="txtListSetsDetail" type="hidden" value="0" name="txtListSetsDetail" runat="server">
						<INPUT id="txtRecordDetail" type="hidden" value="0" name="txtRecordDetail" runat="server">
						<input id="txtToken1" type="hidden" value="0" name="txtToken1" runat="server"> <input id="txtToken2" type="hidden" value="0" name="txtToken2" runat="server">
						<input id="txtToken3" type="hidden" value="0" name="txtToken3" runat="server">
						<asp:label id="lblMsg" runat="server" Visible="False">Chưa chọn URL!</asp:label></TD>
					<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
						<asp:ListItem Value="0">ID:</asp:ListItem>
						<asp:ListItem Value="1">Ngày cập nhật:</asp:ListItem>
						<asp:ListItem Value="2">Tác giả:</asp:ListItem>
						<asp:ListItem Value="3">Chủ đề:</asp:ListItem>
						<asp:ListItem Value="4">Địa chỉ:</asp:ListItem>
						<asp:ListItem Value="5">Đơn vị xuất bản:</asp:ListItem>
						<asp:ListItem Value="6">Ngày tháng:</asp:ListItem>
						<asp:ListItem Value="7">Kiểu:</asp:ListItem>
						<asp:ListItem Value="8">Khuôn dạng:</asp:ListItem>
						<asp:ListItem Value="9">Nguồn:</asp:ListItem>
						<asp:ListItem Value="10">Ngôn ngữ:</asp:ListItem>
						<asp:ListItem Value="11">Quyền:</asp:ListItem>
						<asp:ListItem Value="12">Metadata ID:</asp:ListItem>
						<asp:ListItem Value="13">Người đóng góp:</asp:ListItem>
						<asp:ListItem Value="14">Mô tả:</asp:ListItem>
						<asp:ListItem Value="15">Phạm vi bao quát:</asp:ListItem>
					</asp:DropDownList></TR>
			</table>
			<script language='javascript'>
				// Actions header
				if (document.forms[0].txtVerb.value!='')
				{
					TRHead1.style.display = "none"
					TROAI.style.display = ""
					TROAIHead.style.display = ""
					TRHead2.style.display = ""
					TRHead3.style.display = ""
					TRHead4.style.display = ""
				}
				else
				{
					TRHead1.style.display = ""
					TROAI.style.display = "none"
					TROAIHead.style.display = "none"
					TRHead2.style.display = "none"
					TRHead3.style.display = "none"
					TRHead4.style.display = "none"
				}
				// XML
				if (document.forms[0].optXML.checked == true)
				{
					TRXML.style.display = "";
					TRInforReq.style.display = "none";
				}
				else
				{
					TRXML.style.display = "none";
					TRInforReq.style.display = "";
				}
				
				// Token 1 (Total rec)
				if (document.forms[0].txtToken1.value==0)
				{
					TRToken1.style.display = "none";
				}
				else
				{
					TRToken1.style.display = "";
				}
				
				// Token 2 (Current rec)
				if (document.forms[0].txtToken2.value==0)
				{
					TRToken2.style.display = "none";
				}
				else
				{
					TRToken2.style.display = "";
				}
				
				// Token 3 (Next rec)
				if (document.forms[0].txtToken3.value==0)
				{
					TRToken3.style.display = "none";
				}
				else
				{
					TRToken3.style.display = "";
				}
				
				// Identify
				if (document.forms[0].txtVerb.value!='Identify')
				{
					tblIdentify.style.display="none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						tblIdentify.style.display="";
					}
					else
					{
						tblIdentify.style.display="none";
					}
				}
							
				// Infor request
				if (document.forms[0].txtShowInforReq.value!=1)
				{
					TRInforReq.style.display = "none";
				}
				else
				{
					TRInforReq.style.display = "";
				}
				
				// Display OAI link
				if (document.forms[0].txtVerb.value!='')
				{
					TROAILink.style.display = "";
				}
				else
				{
					TROAILink.style.display = "none";
				}
				
				// ListSets Details
				if (document.forms[0].txtListSetsDetail.Value != 1)
				{
					tblListSetsDetail.style.display = "none";
				}
				else
				{ 
					if(document.forms[0].optXML.checked == false)
					{
						tblListSetsDetail.style.display = "";
					}
					else
					{
						tblListSetsDetail.style.display = "none";
					}
				}
				
				// Record Details
				if (document.forms[0].txtRecordDetail.Value != 1)
				{
					tblRecordDetail.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						tblRecordDetail.style.display = "";
					}
					else
					{
						tblRecordDetail.style.display = "none";
					}
				}
				
				// List Identifiers
				if (document.forms[0].txtVerb.value!='ListIdentifiers')
				{
					TRListIdentifiers.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						TRListIdentifiers.style.display = "";
					}
					else
					{
						TRListIdentifiers.style.display = "none";
					}
				}
				// List MetadataFormats
				if (document.forms[0].txtVerb.value!='ListMetadataFormats')
				{
					TRListMetadataFormats.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						TRListMetadataFormats.style.display = "";
					}
					else
					{
						TRListMetadataFormats.style.display = "none";
					}
				}
				// Lit Sets
				if (document.forms[0].txtVerb.value!='ListSets')
				{
					TRLitSets.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						TRLitSets.style.display = "";
					}
					else
					{
						TRLitSets.style.display = "none";
					}
				}
				
				// List Record
				if (document.forms[0].txtVerb.value!='ListRecords')
				{
					TRListRecord.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						TRListRecord.style.display = "";
						TRToken1.style.display = "none";
						TRToken2.style.display = "none";
						TRToken3.style.display = "none";
					}
					else
					{
						TRListRecord.style.display = "none";
					}
				}
				
				// GetRecord
				if (document.forms[0].txtVerb.value!='GetRecord')
				{
					tblRecordDetail.style.display = "none";
				}
				else 
				{
					if(document.forms[0].optXML.checked == false)
					{
						tblRecordDetail.style.display = "";
					}
					else
					{
						tblRecordDetail.style.display = "none";
					}
				}
											
				// error
				if (document.forms[0].txtError.value!=1)
				{
					tblError.style.display="none";
				}
				else
				{
					tblError.style.display="";
					tblRecordDetail.style.display = "none";
					TRInforReq.style.display = "none"
				}
			</script>
		</form>
	</body>
</HTML>
