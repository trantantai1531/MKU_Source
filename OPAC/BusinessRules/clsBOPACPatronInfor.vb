Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACPatronInfor
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strCardNo As String
        Private strFirstName As String
        Private strLastName As String
        Private strMiddleName As String
        Private strEducationLevel As String
        Private strAddress As String
        Private strPassword As String
        Private strTel As String
        Private strMobile As String
        Private strEmail As String
        Private intOccupationID As Integer
        Private strInterestedSubject As String = "BBK"
        Private intEducationID As Integer

        Private objDOPACPatronInfor As New clsDOPACPatronInfor
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        'Facebook Property
        Public Property Facebook() As String

        ' WorkPlace property
        Public Property WorkPlace() As String
        ' Education property
        Public Property EducationID() As Integer
            Get
                Return (intEducationID)
            End Get
            Set(ByVal Value As Integer)
                intEducationID = Value
            End Set
        End Property
        ' InterestedSubject Property
        Public Property InterestedSubject() As String
            Get
                Return (strInterestedSubject)
            End Get
            Set(ByVal Value As String)
                strInterestedSubject = Value
            End Set
        End Property

        ' CardNo Property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        ' IsCanBo Property
        Public Property IsCanBo() As String

        ' FirstName property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        ' LastName property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property
        ' MiddleName property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        ' EducationLevel property
        Public Property EducationLevel() As String
            Get
                Return strEducationLevel
            End Get
            Set(ByVal Value As String)
                strEducationLevel = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' Tel Property
        Public Property Tel() As String
            Get
                Return strTel
            End Get
            Set(ByVal Value As String)
                strTel = Value
            End Set
        End Property

        ' Mobile property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        ' OccupationID Property
        Public Property OccupationID() As Integer
            Get
                Return intOccupationID
            End Get
            Set(ByVal Value As Integer)
                intOccupationID = Value
            End Set
        End Property

        ' DOB property
        Public Property DOB() As String

        ' ValidDate property
        Public Property ValidDate() As String

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACPatronInfor object
            objDOPACPatronInfor.DBServer = strDBServer
            objDOPACPatronInfor.ConnectionString = strConnectionString
            objDOPACPatronInfor.Initialize()

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
        End Sub

        ' Purpose: Get Patron's Password
        ' Input: PatronCode
        ' Output: DataTable
        ' Created by: chuyenpt
        Public Function GetPatronForgotPassword() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                GetPatronForgotPassword = objBCDBS.ConvertTable(objDOPACPatronInfor.GetPasswordForgot)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetPatron
        ' Input: 
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function GetPatron() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                objDOPACPatronInfor.Password = objBCSP.ConvertItBack(strPassword)
                GetPatron = objBCDBS.ConvertTable(objDOPACPatronInfor.GetPatron)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetPatronByEmail() As DataTable
            Try
                objDOPACPatronInfor.Email = strEmail
                GetPatronByEmail = objDOPACPatronInfor.GetPatronByEmail()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetPatronOther() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                objDOPACPatronInfor.Password = objBCSP.ConvertItBack(strPassword)
                GetPatronOther = objDOPACPatronInfor.GetPatron()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatronNoPassword() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                GetPatronNoPassword = objDOPACPatronInfor.GetPatronNoPassword()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatronNoPasswordGTVT() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                objDOPACPatronInfor.Email = strEmail
                objDOPACPatronInfor.FirstName = strFirstName
                objDOPACPatronInfor.MiddleName = strMiddleName
                objDOPACPatronInfor.LastName = strLastName
                objDOPACPatronInfor.IsCanBo = IsCanBo
                GetPatronNoPasswordGTVT = objDOPACPatronInfor.GetPatronNoPasswordGTVT()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetPatronSSC
        ' Input: 
        ' Output: DataTable
        ' Created by: SonPQ
        Public Function GetPatronSSC() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                objDOPACPatronInfor.Password = objBCSP.ConvertItBack(strPassword)
                GetPatronSSC = objBCDBS.ConvertTable(objDOPACPatronInfor.GetPatronSSC)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatronInfo() As DataTable
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                GetPatronInfo = objBCDBS.ConvertTable(objDOPACPatronInfor.GetPatronInfo)
            Catch ex As Exception
                strErrorMsg = ex.Message
                GetPatronInfo = Nothing
            End Try
        End Function

        ' Purpose: Get All Occupation
        ' In:
        ' Out: Datatable
        ' Creator by: dgsoft2016
        Public Function GetOccupation() As DataTable
            Try
                GetOccupation = objBCDBS.ConvertTable(objDOPACPatronInfor.GetOccupation())
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        Public Function GetPatronGroup(ByVal intLibID As Integer) As DataTable
            Try
                GetPatronGroup = objDOPACPatronInfor.GetPatronGroup(intLibID)
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Purpose: Get All Education
        ' In:
        ' Out: Datatable
        ' Creator by: dgsoft2016
        Public Function GetEducation() As DataTable
            Try
                GetEducation = objBCDBS.ConvertTable(objDOPACPatronInfor.GetEducation())
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Purpose: UpdatePatron
        ' Input: some informations
        ' Output: 
        ' Created by: dgsoft2016
        Public Function UpdatePatron() As Integer
            Try
                objDOPACPatronInfor.CardNo = objBCSP.ConvertItBack(strCardNo)
                objDOPACPatronInfor.EducationID = intEducationID
                objDOPACPatronInfor.OccupationID = intOccupationID
                objDOPACPatronInfor.Facebook = Facebook
                objDOPACPatronInfor.DOB = DOB
                objDOPACPatronInfor.WorkPlace = objBCSP.ConvertItBack(WorkPlace)
                objDOPACPatronInfor.Address = objBCSP.ConvertItBack(strAddress)
                objDOPACPatronInfor.Tel = objBCSP.ConvertItBack(strTel)
                objDOPACPatronInfor.Mobile = objBCSP.ConvertItBack(strMobile)
                objDOPACPatronInfor.Password = objBCSP.ConvertItBack(strPassword)
                objDOPACPatronInfor.Email = objBCSP.ConvertItBack(strEmail)
                UpdatePatron = objDOPACPatronInfor.UpdatePatron()
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
                UpdatePatron = 0
            End Try
        End Function

        Public Function UpdatePasswordPatron() As Integer
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                objDOPACPatronInfor.Password = strPassword
                UpdatePasswordPatron = objDOPACPatronInfor.UpdatePasswordPatron()
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                UpdatePasswordPatron = 0
            End Try
        End Function

        ' Purpose: CreatePatron
        ' Input: 
        ' Output: 
        ' Created by: dgsoft2016
        Public Function ActiveAccount() As DataTable
            Try
                objDOPACPatronInfor.CardNo = CardNo
                objDOPACPatronInfor.ValidDate = objBCDBS.ConvertDateBack(ValidDate)
                objDOPACPatronInfor.DOB = objBCDBS.ConvertDateBack(DOB)
                objDOPACPatronInfor.Password = Password
                ActiveAccount = objBCDBS.ConvertTable(objDOPACPatronInfor.ActiveAccount)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetOnHolding
        ' Input: strCardNo
        ' Output: Datatable
        ' Created by: PhuongTT
        ' MD: 2014.10.12
        Public Function GetOnHolding(ByVal strCheckOutDate As String, ByVal strCheckInDate As String, ByVal strOverDueDate As String, ByVal strDate As String, ByVal strOnHolding As String, ByVal strRenew As String, ByVal strNotRenew As String) As DataTable
            Dim tblOnHolding As DataTable
            Dim tblRenew As DataTable
            Dim inti As Integer
            Dim bollFlage As Boolean
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                tblOnHolding = objBCDBS.ConvertTable(objDOPACPatronInfor.GetOnHolding, "Content")
                If Not tblOnHolding Is Nothing AndAlso tblOnHolding.Rows.Count > 0 Then
                    For inti = 0 To tblOnHolding.Rows.Count - 1
                        bollFlage = False ' Not Overdue
                        tblOnHolding.Rows(inti).Item("Content") = "<LI><a onclick='parent.showPopupDetail(" & tblOnHolding.Rows(inti).Item("ItemID") & ")' class='lblinkfunction' style='cursor:pointer;'><U>" & tblOnHolding.Rows(inti).Item("Content") & "</U></A></LI><BR>" & "Số ĐKCB: " & tblOnHolding.Rows(inti).Item("CopyNumber") & "<BR>" & strCheckOutDate & tblOnHolding.Rows(inti).Item("CODATE") & "<BR>" & strCheckInDate & tblOnHolding.Rows(inti).Item("CIDATE")
                        If Not IsDBNull(tblOnHolding.Rows(inti).Item("OVERDUEDAYS")) AndAlso CInt(tblOnHolding.Rows(inti).Item("OVERDUEDAYS")) > 0 Then
                            bollFlage = True ' Overdue -- > Renew
                            tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & " <BR> " & strOverDueDate & " <B> " & tblOnHolding.Rows(inti).Item("OVERDUEDAYS") & "</B> " & strDate
                        End If
                        ' Check for Renew 
                        objBCDBS.SQLStatement = "SELECT ID FROM Cir_tblHolding WHERE ItemID=" & tblOnHolding.Rows(inti).Item("ItemID")
                        tblRenew = objBCDBS.RetrieveItemInfor
                        If Not tblRenew Is Nothing AndAlso tblRenew.Rows.Count > 0 Then
                            tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & " <BR><I> " & strOnHolding & " </I>"
                        Else ' Renew here
                            ' Ban doc duoc khong duoc gia han thoai mai
                            If Not Len(CStr(tblOnHolding.Rows(inti).Item("Renewals"))) = 0 Then
                                ' Neu so lan da gia han chua vuot qua gioi han
                                If Not bollFlage Then
                                    If (Not IsDBNull(tblOnHolding.Rows(inti).Item("NOR")) AndAlso Not IsDBNull(tblOnHolding.Rows(inti).Item("Renewals"))) AndAlso (CInt(tblOnHolding.Rows(inti).Item("NOR")) > CInt(tblOnHolding.Rows(inti).Item("Renewals"))) Then
                                        If Not IsDBNull(tblOnHolding.Rows(inti).Item("TimeUnit")) AndAlso CInt(tblOnHolding.Rows(inti).Item("TimeUnit")) = 1 Then
                                            If DateDiff("d", Now, CDate(tblOnHolding.Rows(inti).Item("CODATE"))) <= 2 Then
                                                tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                            End If
                                        Else
                                            If DateDiff("h", Now, CDate(tblOnHolding.Rows(inti).Item("CODATE"))) <= 1 Then
                                                tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                            End If
                                        End If
                                    Else
                                        tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR> " & strNotRenew
                                    End If
                                End If
                            Else
                                ' Ban doc duoc gia han thoai mai
                                If bollFlage = False Then
                                    If Not IsDBNull(tblOnHolding.Rows(inti).Item("TimeUnit")) AndAlso CInt(tblOnHolding.Rows(inti).Item("TimeUnit")) = 1 Then
                                        If DateDiff("d", Now, CDate(tblOnHolding.Rows(inti).Item("CODATE"))) <= 2 Then

                                            tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                        End If
                                    Else
                                        If DateDiff("h", Now, CDate(tblOnHolding.Rows(inti).Item("CODATE"))) <= 1 Then
                                            tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                    GetOnHolding = tblOnHolding
                Else
                    GetOnHolding = Nothing
                End If
                strerrormsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetHoldingOther() As DataTable
            Try
            objDOPACPatronInfor.CardNo = strCardNo
            'GetHoldingOther =  objBCDBS.ConvertTable( objDOPACPatronInfor.GetHolding,"Content")
            GetHoldingOther =  objBCDBS.ConvertTableHoldingOther( objDOPACPatronInfor.GetHolding)
            intErrorCode = objDOPACPatronInfor.ErrorCode
            strErrorMsg = objDOPACPatronInfor.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
            
        End Function
        Public Function GetOnHoldingOther(ByVal strCheckOutDate As String, ByVal strCheckInDate As String, ByVal strOverDueDate As String, ByVal strDate As String, ByVal strOnHolding As String, ByVal strRenew As String, ByVal strNotRenew As String) As DataTable
            Dim tblOnHolding As DataTable
            Dim tblRenew As DataTable
            Dim inti As Integer
            Dim bollFlage As Boolean
            Dim tblResult As New DataTable("tblResult")
            Dim strSubRenew As String = ""
            tblResult.Columns.Add("STT")
            tblResult.Columns.Add("Title")
            tblResult.Columns.Add("CopyNumber")
            tblResult.Columns.Add("DateCirculation")
            tblResult.Columns.Add("DateExpired")
            tblResult.Columns.Add("Renew")
            tblResult.Columns.Add("Reserver")
            tblResult.Columns.Add("Note")

            Try
                objDOPACPatronInfor.CardNo = strCardNo
                tblOnHolding = objBCDBS.ConvertTable(objDOPACPatronInfor.GetOnHolding, "Content")
                'tblOnHolding = objDOPACPatronInfor.GetOnHolding
                If Not tblOnHolding Is Nothing AndAlso tblOnHolding.Rows.Count > 0 Then
                    For inti = 0 To tblOnHolding.Rows.Count - 1
                        Dim tblRow As DataRow = tblResult.NewRow()
                        tblRow.Item("STT") = inti + 1
                        tblRow.Item("Title") = ""
                        tblRow.Item("CopyNumber") = ""
                        tblRow.Item("DateCirculation") = ""
                        tblRow.Item("DateExpired") = ""
                        tblRow.Item("Renew") = ""
                        tblRow.Item("Reserver") = ""
                        tblRow.Item("Note") = ""

                        strSubRenew = ""
                        bollFlage = False ' Not Overdue

                        'tblOnHolding.Rows(inti).Item("Content") = "<LI><a onclick='parent.showPopupDetail(" & tblOnHolding.Rows(inti).Item("ItemID") & ")' class='lblinkfunction' style='cursor:pointer;'><U>" & tblOnHolding.Rows(inti).Item("Content") & "</U></A></LI><BR>" & "Số ĐKCB: " & tblOnHolding.Rows(inti).Item("CopyNumber") & "<BR>" & strCheckOutDate & tblOnHolding.Rows(inti).Item("CODATE") & "<BR>" & strCheckInDate & tblOnHolding.Rows(inti).Item("CIDATE")

                        tblRow.Item("Title") = tblRow.Item("Title") & "<a onclick='parent.showPopupDetail(" & tblOnHolding.Rows(inti).Item("ItemID") & ")' class='lblinkfunction' style='cursor:pointer;'><u>" & tblOnHolding.Rows(inti).Item("Content") & "</u></a>"
                        tblRow.Item("CopyNumber") = tblRow.Item("CopyNumber") & tblOnHolding.Rows(inti).Item("CopyNumber")
                        tblRow.Item("DateCirculation") = tblRow.Item("DateCirculation") & tblOnHolding.Rows(inti).Item("CODATE")
                        tblRow.Item("DateExpired") = tblRow.Item("DateExpired") & tblOnHolding.Rows(inti).Item("CIDATE")
                        If Not IsDBNull(tblOnHolding.Rows(inti).Item("OVERDUEDAYS")) AndAlso CInt(tblOnHolding.Rows(inti).Item("OVERDUEDAYS")) > 0 Then
                            bollFlage = True ' Overdue -- > Renew

                            'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & " <BR> " & strOverDueDate & " <B> " & tblOnHolding.Rows(inti).Item("OVERDUEDAYS") & "</B> " & strDate
                            tblRow.Item("Note") = tblRow.Item("Note") & " - " & strOverDueDate & " <B>" & tblOnHolding.Rows(inti).Item("OVERDUEDAYS") & "</B> " & strDate
                        End If
                        ' Check for Renew 
                        objBCDBS.SQLStatement = "SELECT ID FROM Cir_tblHolding WHERE ItemID=" & tblOnHolding.Rows(inti).Item("ItemID")
                        tblRenew = objBCDBS.RetrieveItemInfor
                        If Not tblRenew Is Nothing AndAlso tblRenew.Rows.Count > 0 Then
                            'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & " <BR><I> " & strOnHolding & " </I>"
                            tblRow.Item("Reserver") = tblRow.Item("Reserver") & strOnHolding
                        Else ' Renew here
                            ' Ban doc duoc khong duoc gia han thoai mai
                            If Not Len(CStr(tblOnHolding.Rows(inti).Item("Renewals"))) = 0 Then
                                ' Neu so lan da gia han chua vuot qua gioi han
                                If Not bollFlage Then
                                    If (Not IsDBNull(tblOnHolding.Rows(inti).Item("NOR")) AndAlso Not IsDBNull(tblOnHolding.Rows(inti).Item("Renewals"))) AndAlso (CInt(tblOnHolding.Rows(inti).Item("NOR")) < CInt(tblOnHolding.Rows(inti).Item("Renewals"))) Then
                                        If Not IsDBNull(tblOnHolding.Rows(inti).Item("TimeUnit")) AndAlso CInt(tblOnHolding.Rows(inti).Item("TimeUnit")) = 1 Then
                                            If DateDiff("d", Now, CDate(tblOnHolding.Rows(inti).Item("DueDate"))) <= 2 Then
                                                'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                                strSubRenew = tblOnHolding.Rows(inti).Item("RenewalPeriod") & ""
                                                If (tblOnHolding.Rows(inti).Item("TimeUnit") & "" = "1") Then
                                                    strSubRenew = strSubRenew & " Ngày"
                                                Else
                                                    strSubRenew = strSubRenew & " Giờ"
                                                End If
                                                tblRow.Item("Renew") = tblRow.Item("Renew") & "<a TARGET='hiddenbase' onclick='javascript:SubmitRenew(""" & tblOnHolding.Rows(inti).Item("CIRID") & """);' HREF='#ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & "(" & strSubRenew & ")" & " </a>"
                                            End If
                                        Else
                                            If DateDiff("h", Now, CDate(tblOnHolding.Rows(inti).Item("DueDate"))) <= 1 Then
                                                'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                                strSubRenew = tblOnHolding.Rows(inti).Item("RenewalPeriod") & ""
                                                If (tblOnHolding.Rows(inti).Item("TimeUnit") & "" = "1") Then
                                                    strSubRenew = strSubRenew & " Ngày"
                                                Else
                                                    strSubRenew = strSubRenew & " Giờ"
                                                End If
                                                tblRow.Item("Renew") = tblRow.Item("Renew") & "<a TARGET='hiddenbase' onclick='javascript:SubmitRenew(""" & tblOnHolding.Rows(inti).Item("CIRID") & """);' HREF='#ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & "(" & strSubRenew & ")" & " </a>"
                                            End If
                                        End If
                                    Else
                                        'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR> " & strNotRenew
                                        tblRow.Item("Renew") = tblRow.Item("Renew") & strNotRenew
                                    End If
                                End If
                            Else
                                ' Ban doc duoc gia han thoai mai
                                If bollFlage = False Then
                                    If Not IsDBNull(tblOnHolding.Rows(inti).Item("TimeUnit")) AndAlso CInt(tblOnHolding.Rows(inti).Item("TimeUnit")) = 1 Then
                                        If DateDiff("d", Now, CDate(tblOnHolding.Rows(inti).Item("DueDate"))) <= 2 Then
                                            'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                            strSubRenew = tblOnHolding.Rows(inti).Item("RenewalPeriod") & ""
                                            If (tblOnHolding.Rows(inti).Item("TimeUnit") & "" = "1") Then
                                                strSubRenew = strSubRenew & " Ngày"
                                            Else
                                                strSubRenew = strSubRenew & " Giờ"
                                            End If
                                            tblRow.Item("Renew") = tblRow.Item("Renew") & "<a TARGET='hiddenbase' onclick='javascript:SubmitRenew(""" & tblOnHolding.Rows(inti).Item("CIRID") & """);' HREF='#ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & "(" & strSubRenew & ")" & " </a>"
                                        End If
                                    Else
                                        If DateDiff("h", Now, CDate(tblOnHolding.Rows(inti).Item("DueDate"))) <= 1 Then
                                            'tblOnHolding.Rows(inti).Item("Content") = tblOnHolding.Rows(inti).Item("Content") & "<BR><A TARGET='hiddenbase' HREF='giahan.aspx?ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & " </A>"
                                            strSubRenew = tblOnHolding.Rows(inti).Item("RenewalPeriod") & ""
                                            If (tblOnHolding.Rows(inti).Item("TimeUnit") & "" = "1") Then
                                                strSubRenew = strSubRenew & " Ngày"
                                            Else
                                                strSubRenew = strSubRenew & " Giờ"
                                            End If
                                            tblRow.Item("Renew") = tblRow.Item("Renew") & "<a TARGET='hiddenbase' onclick='javascript:SubmitRenew(""" & tblOnHolding.Rows(inti).Item("CIRID") & """);' HREF='#ID=" & tblOnHolding.Rows(inti).Item("CIRID") & "'>" & strRenew & "(" & strSubRenew & ")" & " </a>"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        tblResult.Rows.Add(tblRow)
                    Next
                    GetOnHoldingOther = tblResult
                Else
                    GetOnHoldingOther = Nothing
                End If
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' Purpose: GetILLRequest
        ' Input: strCardNo
        ' Output: Datatable
        ' Created by: dgsoft2016
        Public Function GetILLRequest(ByVal strCreatedDate As String, ByVal strStatus As String, ByVal strDelILL As String) As DataTable
            Dim tblILLRequest As DataTable
            Dim inti As Integer
            Dim strURL As String
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                tblILLRequest = objBCDBS.ConvertTable(objDOPACPatronInfor.GetILLRequest)
                If Not tblILLRequest Is Nothing Then
                    If tblILLRequest.Rows.Count > 0 Then
                        For inti = 0 To tblILLRequest.Rows.Count - 1
                            ' Allows patron to ask library to cancel his/her request if the current status of request is either PENDING (2) or CONDITIONAL (5)
                            If Not IsDBNull(tblILLRequest.Rows(inti).Item("StatusID")) And (CInt(tblILLRequest.Rows(inti).Item("StatusID")) = 2 Or CInt(tblILLRequest.Rows(inti).Item("StatusID")) = 5) Then
                                tblILLRequest.Rows(inti).Item("CheckBox") = "<INPUT TYPE=" & """CheckBox""" & " NAME = " & """ckbDelILL""" & " VALUE=" & tblILLRequest.Rows(inti).Item("ID") & " RUNAT=" & """server""" & ">"
                            Else
                                tblILLRequest.Rows(inti).Item("CheckBox") = inti + 1 & "."
                            End If
                            tblILLRequest.Rows(inti).Item("Title") = "<U>" & tblILLRequest.Rows(inti).Item("Title") & "</U><BR> " & strCreatedDate & tblILLRequest.Rows(inti).Item("VCREATEDDATE") & " <BR> " & strStatus & " <B> " & tblILLRequest.Rows(inti).Item("DisplayState") & "</B>"
                            'Allows patron to delete his/her request if the current status of request is MEDIATED (20)
                            'If CInt(tblILLRequest.Rows(inti).Item("Status")) = 20 Then
                            '    strURL = "delrequest.aspx?ILLID=" & tblILLRequest.Rows(inti).Item("ID") & "&CardNo=" & strCardNo
                            '    tblILLRequest.Rows(inti).Item("Title") = tblILLRequest.Rows(inti).Item("Title") & "<A HREF=" & """javascript:OpenDelILL('" & strURL & "');""" & ">  " & strDelILL & "</A>"
                            'End If
                        Next
                        GetILLRequest = tblILLRequest
                    End If
                Else
                    GetILLRequest = Nothing
                End If
                strerrormsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Purpose: GetInterestItem
        ' Input: strInterestedSubject, strCardNo, Password
        ' Output: Datatable
        ' Created by: dgsoft2016
        Public Function GetInterestItem(ByRef field As String) As DataTable
            Dim arrParameterText(0), arrParameterValue(0) As String
            Dim strNumbers As String
            Dim tblInterestItem, tblIndexNumber As DataTable
            Dim inti, intn, intj As Integer
            Try
                ' Get BBK or DDC
                arrParameterText(0) = "USED_CLASSIFICATION"
                arrParameterValue = objBCDBS.GetSystemParameters(arrParameterText)
                strerrormsg = objBCDBS.ErrorMsg
                interrorcode = objBCDBS.ErrorCode
                If Not IsDBNull(arrParameterValue(0)) And arrParameterValue(0) = "8" Then
                    field = "DDC"
                Else ' default BBK
                    field = "BBK"
                End If
                ' Get total InterestedSubject
                objDOPACPatronInfor.CardNo = strCardNo
                objDOPACPatronInfor.Password = strPassword
                strInterestedSubject = ""
                If Not IsDBNull(objDOPACPatronInfor.GetPatronInterestedSubject(field).Rows(0).Item("InterestedSubject")) Then
                    strInterestedSubject = objDOPACPatronInfor.GetPatronInterestedSubject(field).Rows(0).Item("InterestedSubject")
                End If
                strerrormsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
                'Change format of this value for proccessing in future
                If strInterestedSubject <> "" Then
                    strInterestedSubject = "||" & Replace(strInterestedSubject, ",", "||") & "||"
                Else
                    strInterestedSubject = "||"
                End If
                If strInterestedSubject <> "||" Then
                    Dim objRecords() As String
                    Dim objcode() As String
                    strInterestedSubject = Trim(Replace(strInterestedSubject, "||", ","))
                    strInterestedSubject = Left(strInterestedSubject, Len(strInterestedSubject) - 1)
                    strInterestedSubject = Right(strInterestedSubject, Len(strInterestedSubject) - 1)
                    tblIndexNumber = objDOPACPatronInfor.GetIndexNumber(field, strInterestedSubject)
                    If Not tblIndexNumber Is Nothing And tblIndexNumber.Rows.Count > 0 Then
                        If field = "DDC" Then
                            For inti = 0 To tblIndexNumber.Rows.Count - 1
                                ReDim Preserve objcode(inti)
                                objcode(inti) = tblIndexNumber.Rows(inti).Item("Numbers")
                                'ReDim Preserve objcode(inti)
                                'If InStr(tblIndexNumber.Rows(inti).Item("Numbers"), ",") > 0 Then
                                '    intn = Cut(tblIndexNumber.Rows(inti).Item("Numbers"), objRecords)
                                '    If intn > 1 Then
                                '        For intj = 0 To intn - 1
                                '            ReDim Preserve objcode(inti)
                                '            objcode(inti) = objRecords(intj)
                                '            inti = inti + 1
                                '        Next
                                '    Else
                                '        objcode(inti) = objRecords(inti)
                                '    End If
                                'Else
                                '    objcode(inti) = tblIndexNumber.Rows(inti).Item("Numbers")
                                '    inti = inti + 1
                                'End If


                            Next
                        Else 'BBK

                        End If
                    End If
                    'arrParameterText(0) = "INTERESTED_CATEGORY_LIMIT"
                    'arrParameterValue = objBCDBS.GetSystemParameters(arrParameterText)
                    'strerrormsg = objBCDBS.ErrorMsg
                    'interrorcode = objBCDBS.ErrorCode
                    'If inti > CInt(arrParameterValue(0)) Then
                    '    inti = arrParameterValue(0)
                    'End If

                    strNumbers = ""
                    For inti = LBound(objcode) To UBound(objcode)
                        If UCase(field) = "DDC" Then
                            'Ca('t the^' na`y dde^? no' bao go^`m ca? li~nh vu+.c con
                            Do While Right(objcode(inti), 1) = "0" And objcode(inti) <> "0"
                                objcode(inti) = Left(objcode(inti), Len(objcode(inti)) - 1)
                            Loop
                        End If
                        strNumbers = strNumbers & objcode(inti) & ","
                    Next
                    If strNumbers <> "" Then
                        strNumbers = Left(strNumbers, Len(strNumbers) - 1)
                    End If
                    tblInterestItem = objBCDBS.ConvertTable(objDOPACPatronInfor.GetInterestItem(field, strNumbers, objBCDBS.ConvertDate(Now)), "Content")
                    strerrormsg = objDOPACPatronInfor.ErrorMsg
                    interrorcode = objDOPACPatronInfor.ErrorCode
                    If Not tblInterestItem Is Nothing And tblInterestItem.Rows.Count > 0 Then
                        For inti = 0 To tblInterestItem.Rows.Count - 1
                            tblInterestItem.Rows(inti).Item("Content") = "<LI><A HREF=" & "javascript:parent.showPopupDetail(" & tblInterestItem.Rows(inti).Item("ID") & ")>" & tblInterestItem.Rows(inti).Item("Content") & "</A></LI>"
                        Next
                    End If
                    GetInterestItem = tblInterestItem
                Else
                    GetInterestItem = Nothing
                End If

            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Purpose: GetReservation
        ' Input: strCardNo ,some information to display only
        ' Output: Datatable
        ' Created by: dgsoft2016
        Public Function GetReservation(ByVal strBefore As String, ByVal strHour As String, ByVal strDate As String, ByVal strLibraryName As String, ByVal strPosition As String) As DataTable
            Dim tblReservation As DataTable
            Dim tblLibLoc As DataTable
            Dim inti, intj As Integer
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                tblReservation = objBCDBS.ConvertTable(objDOPACPatronInfor.GetReservation, "Content")
                If Not tblReservation Is Nothing Then
                    If tblReservation.Rows.Count > 0 Then
                        For inti = 0 To tblReservation.Rows.Count - 1
                            tblReservation.Rows(inti).Item("Content") = "<A HREF='javascript:parent.showPopupDetail(" & tblReservation.Rows(inti).Item("ItemID") & ")'><U>" & tblReservation.Rows(inti).Item("Content") & "</U></A>"
                            If Not IsDBNull(tblReservation.Rows(inti).Item("InTurn")) And Not CInt(tblReservation.Rows(inti).Item("InTurn")) = 0 Then
                                tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strBefore & Hour(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & " " & strHour & ", " & strDate & Day(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Month(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Year(tblReservation.Rows(inti).Item("TIMEOUTDATE"))
                                If Not strdbserver = "ORACLE" Then
                                    objBCDBS.SQLStatement = "SELECT C.Symbol, L.Code  FROM HOLDING H JOIN HOLDING_LIBRARY L ON L.ID=H.LibID LEFT JOIN HOLDING_LOCATION C ON H.LocationID=C.ID WHERE H.ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND H.CopyNumber='" & tblReservation.Rows(inti).Item("CopyNumber") & "'"
                                Else
                                    objBCDBS.SQLStatement = "SELECT C.Symbol, L.Code  FROM HOLDING H, HOLDING_LIBRARY L, HOLDING_LOCATION C WHERE  H.LocationID=C.ID(+) AND L.ID=H.LibID AND H.ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND H.CopyNumber='" & tblReservation.Rows(inti).Item("CopyNumber") & "'"
                                End If
                                ' select Library and Location
                                tblLibLoc = Nothing
                                tblLibLoc = objBCDBS.RetrieveItemInfor
                                If Not tblLibLoc Is Nothing And tblLibLoc.Rows.Count > 0 Then
                                    For intj = 0 To tblLibLoc.Rows.Count - 1
                                        tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strLibraryName & ": " & tblLibLoc.Rows(intj).Item("Code") & ".Kho:" & tblLibLoc.Rows(intj).Item("Symbol")
                                    Next
                                End If
                            Else
                                objBCDBS.SQLStatement = "SELECT COUNT(ID) AS NOR FROM Cir_tblHolding WHERE ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND InTurn=0 AND ID < " & tblReservation.Rows(inti).Item("ID")
                                tblLibLoc = Nothing
                                tblLibLoc = objBCDBS.RetrieveItemInfor
                                If Not tblLibLoc Is Nothing And tblLibLoc.Rows.Count > 0 Then
                                    tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strPosition & ": " & tblLibLoc.Rows(0).Item("NOR") + 1
                                End If
                            End If
                        Next
                        GetReservation = tblReservation
                    End If
                Else
                    GetReservation = Nothing
                End If
                strerrormsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        Public Function GetReservationOther(ByVal strBefore As String, ByVal strHour As String, ByVal strDate As String, ByVal strLibraryName As String, ByVal strPosition As String) As DataTable
            Dim tblReservation As DataTable
            Dim tblLibLoc As DataTable
            Dim inti, intj As Integer
            Dim tblResult As New DataTable("tblResult")
            tblResult.Columns.Add("STT")
            tblResult.Columns.Add("Title")
            tblResult.Columns.Add("CopyNumber")
            tblResult.Columns.Add("CreateDate")
            tblResult.Columns.Add("ExpiredDate")
            tblResult.Columns.Add("LocationName")
            tblResult.Columns.Add("ID")
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                tblReservation = objBCDBS.ConvertTable(objDOPACPatronInfor.GetReservation, "Content")
                If Not tblReservation Is Nothing Then
                    If tblReservation.Rows.Count > 0 Then
                        For inti = 0 To tblReservation.Rows.Count - 1
                            Dim tblRow As DataRow = tblResult.NewRow()
                            tblRow.Item("STT") = inti + 1
                            tblRow.Item("Title") = ""
                            tblRow.Item("CopyNumber") = ""
                            tblRow.Item("CreateDate") = ""
                            tblRow.Item("ExpiredDate") = ""
                            tblRow.Item("LocationName") = ""
                            tblRow.Item("ID") = ""

                            'tblReservation.Rows(inti).Item("Content") = "<A HREF='javascript:parent.showPopupDetail(" & tblReservation.Rows(inti).Item("ItemID") & ")'><U>" & tblReservation.Rows(inti).Item("Content") & "</U></A>"

                            tblRow.Item("Title") = tblRow.Item("Title") & "<a HREF='javascript:parent.showPopupDetail(" & tblReservation.Rows(inti).Item("ItemID") & ")'><U>" & tblReservation.Rows(inti).Item("Content") & "</U></a>"
                            tblRow.Item("CopyNumber") = tblRow.Item("CopyNumber") & tblReservation.Rows(inti).Item("CopyNumber")
                            tblRow.Item("CreateDate") = tblRow.Item("CreateDate") & tblReservation.Rows(inti).Item("CreatedDate")
                            tblRow.Item("ExpiredDate") = tblRow.Item("ExpiredDate") & tblReservation.Rows(inti).Item("ExpiredDate")
                            tblRow.Item("LocationName") = tblRow.Item("LocationName") & tblReservation.Rows(inti).Item("LocationName")
                            tblRow.Item("ID") = tblRow.Item("ID") & tblReservation.Rows(inti).Item("ID")
                            'If Not IsDBNull(tblReservation.Rows(inti).Item("InTurn")) And Not CInt(tblReservation.Rows(inti).Item("InTurn")) = 0 Then
                            '    'tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strBefore & Hour(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & " " & strHour & ", " & strDate & Day(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Month(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Year(tblReservation.Rows(inti).Item("TIMEOUTDATE"))
                            '    tblRow.Item("Note") = tblRow.Item("Note") & "<BR> " & strBefore & Hour(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & " " & strHour & ", " & strDate & Day(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Month(tblReservation.Rows(inti).Item("TIMEOUTDATE")) & "/ " & Year(tblReservation.Rows(inti).Item("TIMEOUTDATE"))
                            '    If Not strDBServer = "ORACLE" Then
                            '        objBCDBS.SQLStatement = "SELECT C.Symbol, L.Code  FROM HOLDING H JOIN HOLDING_LIBRARY L ON L.ID=H.LibID LEFT JOIN HOLDING_LOCATION C ON H.LocationID=C.ID WHERE H.ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND H.CopyNumber='" & tblReservation.Rows(inti).Item("CopyNumber") & "'"
                            '    Else
                            '        objBCDBS.SQLStatement = "SELECT C.Symbol, L.Code  FROM Lib_tblHolding H, Lib_tblHoldingLibrary L, Lib_tblHoldingLocation C WHERE  H.LocationID=C.ID(+) AND L.ID=H.LibID AND H.ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND H.CopyNumber='" & tblReservation.Rows(inti).Item("CopyNumber") & "'"
                            '    End If
                            '    ' select Library and Location
                            '    tblLibLoc = Nothing
                            '    tblLibLoc = objBCDBS.RetrieveItemInfor
                            '    If Not tblLibLoc Is Nothing And tblLibLoc.Rows.Count > 0 Then
                            '        For intj = 0 To tblLibLoc.Rows.Count - 1
                            '            'tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strLibraryName & ": " & tblLibLoc.Rows(intj).Item("Code") & ".Kho:" & tblLibLoc.Rows(intj).Item("Symbol")
                            '            tblRow.Item("Note") = tblRow.Item("Note") & "<BR> " & strLibraryName & ": " & tblLibLoc.Rows(intj).Item("Code") & ".Kho:" & tblLibLoc.Rows(intj).Item("Symbol")
                            '        Next
                            '    End If
                            'Else
                            '    objBCDBS.SQLStatement = "SELECT COUNT(ID) AS NOR FROM Cir_tblHolding WHERE ItemID=" & tblReservation.Rows(inti).Item("ItemID") & " AND InTurn=0 AND ID < " & tblReservation.Rows(inti).Item("ID")
                            '    tblLibLoc = Nothing
                            '    tblLibLoc = objBCDBS.RetrieveItemInfor
                            '    If Not tblLibLoc Is Nothing And tblLibLoc.Rows.Count > 0 Then
                            '        'tblReservation.Rows(inti).Item("Content") = tblReservation.Rows(inti).Item("Content") & "<BR> " & strPosition & ": " & tblLibLoc.Rows(0).Item("NOR") + 1
                            '        tblRow.Item("NOR") = tblRow.Item("NOR") & tblLibLoc.Rows(0).Item("NOR") + 1
                            '    End If
                            'End If
                            tblResult.Rows.Add(tblRow)
                        Next
                    End If
                    GetReservationOther = tblResult
                Else
                    GetReservationOther = Nothing
                End If
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: DeleteReservation, NOTE: hien nay khong dung phan commen nua, vi store da lam het roi, de lai de tham khao, khong duoc xoa
        ' Input: strReservationItemIDs
        ' Output: 
        ' Created by: dgsoft2016
        Public Sub DeleteReservation(ByVal strReservationItemIDs As String)
            If strReservationItemIDs = "" Then
                Exit Sub
            End If
            ' Process here
            Dim arrItemIDs() As String
            Dim inti As Integer
            Try
                arrItemIDs = Split(strReservationItemIDs, ",")
                If UBound(arrItemIDs) >= 0 Then
                    For inti = 0 To UBound(arrItemIDs)
                        objDOPACPatronInfor.CardNo = strCardNo
                        ' xoa yeu cau giu cho
                        objDOPACPatronInfor.DeleteReservation(arrItemIDs(inti))
                        strerrormsg = objBCDBS.ErrorMsg
                        interrorcode = objBCDBS.ErrorCode
                    Next
                End If
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Sub
        ' Purpose: Update InterestedSubject
        ' In: intPatronID, strInterestedSubjectField (BBK or DDC), strInterestedSubjectValue
        ' Out:
        ' Creator: dgsoft2016
        Public Sub UpdateInterestedSubject(ByVal intPatronID As Integer, ByVal strInterestedSubjectField As String, ByVal strInterestedSubjectValue As String)
            Try
                objDOPACPatronInfor.UpdateInterestedSubject(intPatronID, strInterestedSubjectField, strInterestedSubjectValue)
                strerrormsg = objBCDBS.ErrorMsg
                interrorcode = objBCDBS.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Sub
        ' Purpose: Get Patron InterestedSubject 
        ' In: InterestedSubject(BBK or DDC default BBK), CardNo, Password
        ' Out: DataTable
        ' Creator: dgsoft2016
        Public Function GetPatronInterestedSubject(ByVal strInterestedSubject As String) As DataTable
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                objDOPACPatronInfor.Password = strPassword
                GetPatronInterestedSubject = objBCDBS.ConvertTable(objDOPACPatronInfor.GetPatronInterestedSubject(strInterestedSubject), "Content")
                strerrormsg = objDOPACPatronInfor.ErrorMsg
                interrorcode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function
        Function Cut(ByVal inVal As Integer, ByRef Records() As String) As Integer
            Dim Offset, Idx
            Trim(inVal)
            Idx = 0
            ReDim Records(Idx)
            If Not inVal = "" Then
                inVal = Replace(inVal, "'", "''")
            End If
            Do While Len(inVal) > 0
                Offset = InStr(inVal, ",")
                If Offset > 0 Then
                    Records(Idx) = Left(inVal, Offset - 1)
                    inVal = Right(inVal, Len(inVal) - Offset)
                Else
                    Records(Idx) = inVal
                    inVal = ""
                End If
                Idx = Idx + 1
                ReDim Preserve Records(Idx)
            Loop
            Cut = Idx
        End Function


        Public Function GetIsDownLoad_ByPatronCode() As Integer
            Try
                objDOPACPatronInfor.CardNo = strCardNo
                GetIsDownLoad_ByPatronCode = objDOPACPatronInfor.GetIsDownLoad_ByPatronCode()
                strErrorMsg = objDOPACPatronInfor.ErrorMsg
                intErrorCode = objDOPACPatronInfor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACPatronInfor Is Nothing Then
                    Call objDOPACPatronInfor.Dispose(True)
                    objDOPACPatronInfor = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace