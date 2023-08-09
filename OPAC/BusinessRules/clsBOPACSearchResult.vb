Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACSearchResult
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strItemIDs As String
        Private intCurrentPage As Integer
        Private intRecordPerPage As Integer

        Private objDPatron As New clsDOPACPatronInfor
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDOPACSR As New clsDOPACSearchResult

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ItemIDs property 
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' CurrentPage property
        Public Property CurrentPage() As Integer
            Get
                Return intCurrentPage
            End Get
            Set(ByVal Value As Integer)
                intCurrentPage = Value
            End Set
        End Property

        ' RecordPerPage property
        Public Property RecordPerPage() As Integer
            Get
                Return intRecordPerPage
            End Get
            Set(ByVal Value As Integer)
                intRecordPerPage = Value
            End Set
        End Property

        ' Initialize method
        Public Sub Initialize()
            ' Init objDPatron object
            objDPatron.DBServer = strDBServer
            objDPatron.ConnectionString = strConnectionString
            objDPatron.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            'Init objDOPACSR object
            objDOPACSR.DBServer = strDBServer
            objDOPACSR.ConnectionString = strConnectionString
            objDOPACSR.Initialize()

        End Sub

        ' Purpose: Get all informations from Database by ItemIDs 
        ' Input: array Field name to select
        ' Output: DataTable

        Public Function GetItemResults(ByVal arrFields() As String) As DataTable
            Dim strFields As String = ""
            Dim intCount As Integer = 0
            Dim strSQL As String = ""
            Dim strDefaultField As String

            Try
                strDefaultField = ",022,100,245,250,260,300,490,700,773," ' add field here
                strSQL = "SELECT ID AS ItemID,'' AS Content,'' AS Field FROM Lib_tblItem WHERE ID IN (" & strItemIDs & ")"
                If IsArray(arrFields) Then
                    For intCount = 0 To UBound(arrFields)
                        If InStr(strDefaultField, "," & LCase(arrFields(intCount)) & ",") > 0 Then
                            strSQL = strSQL & " UNION SELECT ItemID,Content,'" & arrFields(intCount) & "' AS Field FROM"
                            Select Case LCase(arrFields(intCount))
                                Case "022"
                                    strSQL = strSQL & " FIELD000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='022' "
                                Case "100"
                                    strSQL = strSQL & " FIELD100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='100' "
                                Case "245"
                                    strSQL = strSQL & " FIELD200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='245' "
                                Case "250"
                                    strSQL = strSQL & " FIELD200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='250' "
                                Case "260"
                                    strSQL = strSQL & " FIELD200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='260' "
                                Case "300"
                                    strSQL = strSQL & " FIELD300S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='300' "
                                Case "490"
                                    strSQL = strSQL & " FIELD400S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='490' "
                                Case "700"
                                    strSQL = strSQL & " FIELD700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='700' "
                                Case "773"
                                    strSQL = strSQL & " FIELD700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode='773' "
                                    ' case .... Add field here
                            End Select
                        End If
                    Next
                    strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM HOLDING WHERE ItemID IN (" & strItemIDs & ")"
                    objBCDBS.SQLStatement = strSQL
                    Me.SQL = strSQL
                    'Exit Function
                    GetItemResults = objBCDBS.ConvertTable(objBCDBS.RetrieveItemInfor(False), "Content")
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetFulltextResults
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function GetFulltextResults(ByVal strURL As String) As DataTable
            Try
                GetFulltextResults = objBCDBS.ConvertTable(objDOPACSR.GetFulltextResults(strURL), "Content")
                strerrormsg = objDOPACSR.ErrorMsg
                interrorcode = objDOPACSR.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function


        ' Purpose: Get all informations from Database by ItemIDs 
        ' Input: array Field name to select
        ' Output: DataTable
        ' Created by: PhuongTT
        ' CreateDateP: 2014/08/19
        Public Function GetItemResultsByFields(ByVal arrFields() As String, Optional ByVal availableHolding As Boolean = False, Optional ByVal strReplaceWord As String = "", Optional ByVal strBGColor As String = "#60a917 !important", Optional ByVal bolEbooksFulltext As Boolean = False, Optional ByVal bolHodingFree As Boolean = True) As DataTable
            Dim strFields As String = ""
            Dim intCount As Integer = 0
            Dim strSQL As String = ""
            Dim strDefaultField As String
            Dim dtResult As DataTable = Nothing
            Try
                strDefaultField = ",022,100,110,245,250,260,082,090,490,700,710,773,856," ' add field here
                strSQL = "SELECT ID AS ItemID, isnull(CoverPicture,'') AS Content, 'COVER' AS Field FROM Lib_tblItem WHERE ID IN (" & strItemIDs & ")"
                If IsArray(arrFields) Then
                    For intCount = 0 To UBound(arrFields)
                        If InStr(strDefaultField, "," & LCase(arrFields(intCount)) & ",") > 0 Then
                            'strSQL = strSQL & " UNION SELECT ItemID,Content,'" & arrFields(intCount) & "' AS Field FROM"
                            strSQL = strSQL & " UNION SELECT ItemID, ("
                            strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                            'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                            strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                            strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                            strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                            Select Case LCase(arrFields(intCount))
                                Case "022"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '022' "
                                Case "100"
                                    strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '100' "
                                Case "110"
                                    strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '110' "
                                Case "245"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '245' "
                                Case "250"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '250' "
                                Case "260"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '260' "
                                Case "082"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '082' "
                                Case "090"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '090' "
                                Case "490"
                                    strSQL = strSQL & " Lib_tblField400S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '490' "
                                Case "700"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '700' "
                                Case "710"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '710' "
                                Case "773"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '773' "
                                Case "856"
                                    strSQL = strSQL & " Lib_tblField800S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '856' "
                                    ' case .... Add field here
                            End Select
                        End If
                    Next
                    'Ranking
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(AVG(b.Ranking) as nvarchar)  AS Content, 'RANKING' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblComment b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Views
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(sum(b.Counter) as nvarchar)  AS Content, 'VIEWS' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblViews b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Du lieu dien tu
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID,isnull(c.icon,'') + ';' + cast(isnull(a.FormatId,0) as nvarchar) +  ';' + cast(isnull(b.id,0) as nvarchar) +  ';' + cast(isnull(a.id,0) as nvarchar) AS Content,'EDATA' AS Field FROM Lib_tblItem a JOIN Lib_tblItemFile b ON a.ID = b.ItemID and b.viewer = 1 and b.status = 0 JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Du lieu bao in/tap chi dien tu
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(c.icon,'') AS Content,'EMAGAZINE' AS Field FROM Lib_tblItem a INNER JOIN Lib_tblItemMagNumber b ON  a.ID = b.ItemID INNER JOIN Lib_tblItemMagNumberDetail d on b.Id = d.MagId JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Dang tai lieu
                    'strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.icon,'') + isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a JOIN CAT_DIC_ITEM_TYPE b on a.TypeID = b.ID  WHERE  a.ID IN (" & strItemIDs & ")"
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a INNER JOIN Cat_tblDic_ItemType b on a.TypeID = b.ID  WHERE a.ID IN (" & strItemIDs & ")"
                    'Thu vien
                    strSQL = strSQL & " UNION SELECT distinct IT.ID AS ItemID, ISNULL(SL.Name,'') as Content,'LIBRARY' AS Field FROM Sys_tblLibrary SL INNER JOIN Sys_tblLibraryType SLT ON SL.LibTypeId = SLT.Id JOIN Lib_tblItem IT ON SL.ID = IT.LibId WHERE IT.ID IN (" & strItemIDs & ")"
                    'Tom tat ebooks
                    If bolEbooksFulltext Then
                        'strSQL &= " UNION SELECT ItemID,("
                        'strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) -1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        'strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        'strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                        strSQL &= " UNION SELECT IT.ID AS ItemID, (CAST(MIN(IFFP.LinkPage) AS NVARCHAR(4000)) + '@PHUONGTT@' + MIN("
                        strSQL &= "substring(IFFP.Contents,1, case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;""><I>' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</I></span>'"
                        strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then IFFP.Contents else substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(IFFP.Contents)-CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        strSQL &= ")) AS Content,'BRIEF' AS Field FROM Lib_tblItemFileFulltextPage IFFP JOIN Lib_tblItemFile IFS ON IFFP.FileId = IFS.ID JOIN Lib_tblItem IT ON IFS.ItemID = IT.ID WHERE CONTAINS(IFFP.Contents,'""" & strReplaceWord.Trim & """') AND IT.ID IN (" & strItemIDs & ")"
                        strSQL &= " GROUP BY IT.ID"
                    End If
                    'Ma xep gia
                    If availableHolding Then
                        'strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM HOLDING WHERE ItemID IN (" & strItemIDs & ")" ' And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        If bolHodingFree Then
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ") And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        Else
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ")"
                        End If
                    End If

                    objBCDBS.SQLStatement = strSQL
                    Me.SQL = strSQL
                    'Exit Function
                    dtResult = objBCDBS.ConvertTable(objBCDBS.RetrieveItemInfor(False), "Content")
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function

        Public Function GetItemResultsByFieldsOther(ByVal arrFields() As String, Optional ByVal availableHolding As Boolean = False, Optional ByVal strReplaceWord As String = "", Optional ByVal strBGColor As String = "#60a917 !important", Optional ByVal bolEbooksFulltext As Boolean = False, Optional ByVal bolHodingFree As Boolean = True) As DataTable
            Dim strFields As String = ""
            Dim intCount As Integer = 0
            Dim strSQL As String = ""
            Dim strDefaultField As String
            Dim dtResult As DataTable = Nothing
            Try
                strDefaultField = ",022,100,110,245,250,260,082,090,490,653,700,710,773,856," ' add field here
                strSQL = "SELECT ID AS ItemID, isnull(CoverPicture,'') AS Content, 'COVER' AS Field FROM Lib_tblItem WHERE ID IN (" & strItemIDs & ")"
                If IsArray(arrFields) Then
                    For intCount = 0 To UBound(arrFields)
                        If InStr(strDefaultField, "," & LCase(arrFields(intCount)) & ",") > 0 Then
                            'strSQL = strSQL & " UNION SELECT ItemID,Content,'" & arrFields(intCount) & "' AS Field FROM"
                            strSQL = strSQL & " UNION SELECT ItemID, ("
                            strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                            'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                            strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                            strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                            strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                            Select Case LCase(arrFields(intCount))
                                Case "022"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '022' "
                                Case "100"
                                    strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '100' "
                                Case "110"
                                    strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '110' "
                                Case "245"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '245' "
                                Case "250"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '250' "
                                Case "260"
                                    strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '260' "
                                Case "082"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '082' "
                                Case "090"
                                    strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '090' "
                                Case "490"
                                    strSQL = strSQL & " Lib_tblField400S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '490' "
                                Case "653"
                                    strSQL = strSQL & " Lib_tblField600S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '653' "
                                Case "700"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '700' "
                                Case "710"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '710' "
                                Case "773"
                                    strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '773' "
                                Case "856"
                                    strSQL = strSQL & " Lib_tblField800S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '856' "
                                    ' case .... Add field here
                            End Select
                        End If
                    Next
                    'Ranking
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(AVG(b.Ranking) as nvarchar)  AS Content, 'RANKING' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblComment b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Views
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(sum(b.Counter) as nvarchar)  AS Content, 'VIEWS' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblViews b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Du lieu dien tu
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID,isnull(c.icon,'') + ';' + cast(isnull(a.FormatId,0) as nvarchar) +  ';' + cast(isnull(b.id,0) as nvarchar) +  ';' + cast(isnull(a.id,0) as nvarchar) AS Content,'EDATA' AS Field FROM Lib_tblItem a JOIN Lib_tblItemFile b ON a.ID = b.ItemID and b.viewer = 1 and b.status = 0 JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Du lieu bao in/tap chi dien tu
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(c.icon,'') AS Content,'EMAGAZINE' AS Field FROM Lib_tblItem a INNER JOIN Lib_tblItemMagNumber b ON  a.ID = b.ItemID INNER JOIN Lib_tblItemMagNumberDetail d on b.Id = d.MagId JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Dang tai lieu
                    'strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.icon,'') + isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a JOIN CAT_DIC_ITEM_TYPE b on a.TypeID = b.ID  WHERE  a.ID IN (" & strItemIDs & ")"
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a INNER JOIN Cat_tblDic_ItemType b on a.TypeID = b.ID  WHERE a.ID IN (" & strItemIDs & ")"
                    'Thu vien
                    strSQL = strSQL & " UNION SELECT distinct IT.ID AS ItemID, ISNULL(SL.Name,'') as Content,'LIBRARY' AS Field FROM Sys_tblLibrary SL INNER JOIN Sys_tblLibraryType SLT ON SL.LibTypeId = SLT.Id JOIN Lib_tblItem IT ON SL.ID = IT.LibId WHERE IT.ID IN (" & strItemIDs & ")"
                    'Tom tat ebooks
                    If bolEbooksFulltext Then
                        'strSQL &= " UNION SELECT ItemID,("
                        'strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) -1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        'strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        'strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                        strSQL &= " UNION SELECT IT.ID AS ItemID, (CAST(MIN(IFFP.LinkPage) AS NVARCHAR(4000)) + '@PHUONGTT@' + MIN("
                        strSQL &= "substring(IFFP.Contents,1, case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;""><I>' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</I></span>'"
                        strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then IFFP.Contents else substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(IFFP.Contents)-CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        strSQL &= ")) AS Content,'BRIEF' AS Field FROM Lib_tblItemFileFulltextPage IFFP JOIN Lib_tblItemFile IFS ON IFFP.FileId = IFS.ID JOIN Lib_tblItem IT ON IFS.ItemID = IT.ID WHERE CONTAINS(IFFP.Contents,'""" & strReplaceWord.Trim & """') AND IT.ID IN (" & strItemIDs & ")"
                        strSQL &= " GROUP BY IT.ID"
                    End If
                    'Ma xep gia
                    If availableHolding Then
                        'strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM HOLDING WHERE ItemID IN (" & strItemIDs & ")" ' And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        If bolHodingFree Then
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ") And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        Else
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ")"
                        End If
                    End If

                    objBCDBS.SQLStatement = strSQL
                    Me.SQL = strSQL
                    'Exit Function
                    dtResult = objBCDBS.RetrieveItemInfor(False)

                    For i As Integer = 0 To dtResult.Rows.Count - 1
                        Dim row As DataRow = dtResult.Rows(i)
                        If (row.Item("Field").ToString() = "245") Then
                            Dim content245 As String = row.Item("Content")
                            Dim split() As String = content245.Split("$")
                            If (split.Length > 1) Then
                                If (content245.Contains("$a")) Then
                                    Dim tmpResult As String = ""
                                    If split.Length = 2 Then
                                        tmpResult = tmpResult & split(0) & "$" & split(1)
                                    Else
                                        tmpResult = tmpResult & split(0) & "$" & split(1).Substring(0, split(1).Length - 2)
                                    End If
                                    tmpResult = tmpResult.Trim()
                                    dtResult.Rows(i).Item("Content") = tmpResult
                                End If
                            End If
                        End If
                    Next

                    dtResult = objBCDBS.ConvertTable(dtResult, "Content")
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function

        Public Function GetItemResultsByFieldsOther(ByVal arrFields() As String, ByVal strTypeSarch As String, Optional ByVal availableHolding As Boolean = False, Optional ByVal strReplaceWord As String = "", Optional ByVal strBGColor As String = "#60a917 !important", Optional ByVal bolEbooksFulltext As Boolean = False, Optional ByVal bolHodingFree As Boolean = True, Optional ByRef dtbOutAuthor As DataTable = Nothing) As DataTable
            Dim strFields As String = ""
            Dim intCount As Integer = 0
            Dim strSQL As String = ""
            Dim strDefaultField As String
            Dim dtResult As DataTable = Nothing
            Try
                strDefaultField = ",022,100,110,245,250,260,082,090,490,653,700,710,773,856," ' add field here
                strSQL = "SELECT ID AS ItemID, isnull(CoverPicture,'') AS Content, 'COVER' AS Field FROM Lib_tblItem WHERE ID IN (" & strItemIDs & ")"
                If IsArray(arrFields) Then
                    For intCount = 0 To UBound(arrFields)
                        If InStr(strDefaultField, "," & LCase(arrFields(intCount)) & ",") > 0 Then
                            If strTypeSarch = "fulltext" Then
                                strSQL = strSQL & " UNION SELECT ItemID, ("
                                strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                Select Case LCase(arrFields(intCount))
                                    Case "022"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '022' "
                                    Case "100"
                                        strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '100' "
                                    Case "110"
                                        strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '110' "
                                    Case "245"
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '245' "
                                    Case "250"
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '250' "
                                    Case "260"
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '260' "
                                    Case "082"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '082' "
                                    Case "090"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '090' "
                                    Case "490"
                                        strSQL = strSQL & " Lib_tblField400S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '490' "
                                    Case "653"
                                        strSQL = strSQL & " Lib_tblField600S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '653' "
                                    Case "700"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '700' "
                                    Case "710"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '710' "
                                    Case "773"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '773' "
                                    Case "856"
                                        strSQL = strSQL & " Lib_tblField800S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '856' "
                                        ' case .... Add field here
                                End Select
                            Else
                                Select Case LCase(arrFields(intCount))
                                    Case "022"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '022' "
                                    Case "100"
                                        'If (strTypeSarch = "author") Then
                                        '    strSQL = strSQL & " UNION SELECT ItemID, ("
                                        '    strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                        '    strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                        '    strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                        '    strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        'Else
                                        '    strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        'End If
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '100' "
                                    Case "110"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField100S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '110' "
                                    Case "245"
                                        If (strTypeSarch = "title" Or strTypeSarch = "author") Then
                                            strSQL = strSQL & " UNION SELECT ItemID, ("
                                            strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                            strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                            strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                            strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        Else
                                            strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        End If
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '245' "
                                    Case "250"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '250' "
                                    Case "260"
                                        If (strTypeSarch = "publishyear") Then
                                            strSQL = strSQL & " UNION SELECT ItemID, ("
                                            strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                            strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                            strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                            strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        Else
                                            If strTypeSarch = "publisher" Then
                                                strSQL = strSQL & " UNION SELECT ItemID, ("
                                                strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                                strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                                strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                                strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                            Else
                                                strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                            End If
                                        End If
                                        strSQL = strSQL & " Lib_tblField200S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '260' "
                                    Case "082"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '082' "
                                    Case "090"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField000S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '090' "
                                    Case "490"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField400S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '490' "
                                    Case "653"
                                        If strTypeSarch = "keyword" Then
                                            strSQL = strSQL & " UNION SELECT ItemID, ("
                                            strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "', CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                                            strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))), case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                                            strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                                            strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        Else
                                            strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        End If
                                        strSQL = strSQL & " Lib_tblField600S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '653' "
                                    Case "700"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '700' "
                                    Case "710"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '710' "
                                    Case "773"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField700S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '773' "
                                    Case "856"
                                        strSQL = strSQL & " UNION SELECT ItemID, Content,'" & arrFields(intCount) & "' AS Field FROM"
                                        strSQL = strSQL & " Lib_tblField800S WHERE ItemID IN (" & strItemIDs & ") AND FieldCode = '856' "
                                        ' case .... Add field here
                                End Select
                            End If

                        End If
                    Next
                    'Ranking
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(AVG(b.Ranking) as nvarchar)  AS Content, 'RANKING' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblComment b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Views
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID, cast(sum(b.Counter) as nvarchar)  AS Content, 'VIEWS' AS Field FROM Lib_tblItem a INNER JOIN Opac_tblViews b on a.ID = b.ItemID WHERE  a.ID IN (" & strItemIDs & ") GROUP BY a.ID "
                    'Du lieu dien tu
                    strSQL = strSQL & " UNION SELECT a.ID AS ItemID,isnull(c.icon,'') + ';' + cast(isnull(a.FormatId,0) as nvarchar) +  ';' + cast(isnull(b.id,0) as nvarchar) +  ';' + cast(isnull(a.id,0) as nvarchar) AS Content,'EDATA' AS Field FROM Lib_tblItem a JOIN Lib_tblItemFile b ON a.ID = b.ItemID and b.viewer = 1 and b.status = 0 JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Du lieu bao in/tap chi dien tu
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(c.icon,'') AS Content,'EMAGAZINE' AS Field FROM Lib_tblItem a INNER JOIN Lib_tblItemMagNumber b ON  a.ID = b.ItemID INNER JOIN Lib_tblItemMagNumberDetail d on b.Id = d.MagId JOIN Cat_tblDicFormat c on a.FormatID = c.ID WHERE a.ID IN (" & strItemIDs & ") "
                    'Dang tai lieu
                    'strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.icon,'') + isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a JOIN CAT_DIC_ITEM_TYPE b on a.TypeID = b.ID  WHERE  a.ID IN (" & strItemIDs & ")"
                    strSQL = strSQL & " UNION SELECT distinct a.ID AS ItemID,isnull(b.TypeName,'')  AS Content,'ETYPE' AS Field FROM Lib_tblItem a INNER JOIN Cat_tblDic_ItemType b on a.TypeID = b.ID  WHERE a.ID IN (" & strItemIDs & ")"
                    'Thu vien
                    strSQL = strSQL & " UNION SELECT distinct IT.ID AS ItemID, ISNULL(SL.Name,'') as Content,'LIBRARY' AS Field FROM Sys_tblLibrary SL INNER JOIN Sys_tblLibraryType SLT ON SL.LibTypeId = SLT.Id JOIN Lib_tblItem IT ON SL.ID = IT.LibId WHERE IT.ID IN (" & strItemIDs & ")"
                    'Tom tat ebooks
                    If bolEbooksFulltext Then
                        'strSQL &= " UNION SELECT ItemID,("
                        'strSQL = strSQL & "substring(Content,1, case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) -1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;"">' + substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        'strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then Content else substring(Content,CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(Content)-CHARINDEX('" & strReplaceWord & "',CAST(Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        'strSQL = strSQL & ") as Content,'" & arrFields(intCount) & "' AS Field FROM"
                        strSQL &= " UNION SELECT IT.ID AS ItemID, (CAST(MIN(IFFP.LinkPage) AS NVARCHAR(4000)) + '@PHUONGTT@' + MIN("
                        strSQL &= "substring(IFFP.Contents,1, case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) - 1 end )"
                        'strSQL = strSQL & "+ '<span style=""background-color:" & strBGColor & ";color:white;""><I>' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</I></span>'"
                        strSQL = strSQL & "+ '<span class=""hightlight-text"">' + substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))),case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then 0 else len('" & strReplaceWord & "') end) + '</span>'"
                        strSQL = strSQL & "+ case CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) when 0 then IFFP.Contents else substring(IFFP.Contents,CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "'),len(IFFP.Contents)-CHARINDEX('" & strReplaceWord & "',CAST(IFFP.Contents COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))+ len('" & strReplaceWord & "')) end"
                        strSQL &= ")) AS Content,'BRIEF' AS Field FROM Lib_tblItemFileFulltextPage IFFP JOIN Lib_tblItemFile IFS ON IFFP.FileId = IFS.ID JOIN Lib_tblItem IT ON IFS.ItemID = IT.ID WHERE CONTAINS(IFFP.Contents,'""" & strReplaceWord.Trim & """') AND IT.ID IN (" & strItemIDs & ")"
                        strSQL &= " GROUP BY IT.ID"
                    End If
                    'Ma xep gia
                    If availableHolding Then
                        'strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM HOLDING WHERE ItemID IN (" & strItemIDs & ")" ' And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        If bolHodingFree Then
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ") And InUsed = 0 AND Acquired = 1 AND InCirculation = 1"
                        Else
                            strSQL = strSQL & " UNION SELECT ItemID,CopyNumber AS Content ,'MXG' AS Field FROM Lib_tblHolding WHERE ItemID IN (" & strItemIDs & ")"
                        End If
                    End If

                    objBCDBS.SQLStatement = strSQL
                    Me.SQL = strSQL
                    'Exit Function
                    dtResult = objBCDBS.RetrieveItemInfor(False)

                    For i As Integer = 0 To dtResult.Rows.Count - 1
                        Dim row As DataRow = dtResult.Rows(i)
                        If (row.Item("Field").ToString() = "245") Then
                            Dim content245 As String = row.Item("Content")
                            Dim split() As String = content245.Split("$")
                            If (split.Length > 1) Then
                                If (content245.Contains("$c")) Then
                                    Dim tmpResult As String = ""
                                    For j As Integer = 0 To split.Length - 1
                                        If (Not (String.IsNullOrEmpty(split(j)))) Then
                                            If Not (split(j)(0) = "c") Then
                                                tmpResult = tmpResult & "$" & split(j)
                                            Else
                                                If Not (IsNothing(dtbOutAuthor)) Then
                                                    dtbOutAuthor.Rows.Add(row.Item("ItemID"), split(j).Substring(1))
                                                End If
                                            End If
                                        End If
                                    Next
                                    tmpResult = tmpResult.Trim()
                                    If (tmpResult(0) = "$" AndAlso tmpResult(1) = "<") Then
                                        dtResult.Rows(i).Item("Content") = tmpResult.Substring(1, tmpResult.Length - 1)
                                    Else
                                        dtResult.Rows(i).Item("Content") = tmpResult.Substring(0, tmpResult.Length - 1)
                                    End If
                                End If
                            End If
                        End If
                    Next

                    dtResult = objBCDBS.ConvertTable(dtResult, "Content")
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDPatron Is Nothing Then
                    Call objDPatron.Dispose(True)
                    objDPatron = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDOPACSR Is Nothing Then
                    objDOPACSR.Dispose(True)
                    objDOPACSR = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace
