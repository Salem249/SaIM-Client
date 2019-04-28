Imports System.Net.Sockets
Imports System.Threading
Imports Un4seen.Bass

Public Class frmMain
    'user defined variables.
    Public strNotify As String
    Public Shared strLogin As String
    Public bLogin As Boolean
    Public iFListCmd As Integer
    Public strFriendNotify As String
    Private clientSocket As sckClient
    Private Shared netStream As NetworkStream = Nothing
    Private thrd As Thread
    Private bClose As Boolean
    Private bShown As Boolean
    Private msgQueue As Queue
    Public fList As String() = Nothing
    Public strXmlElements As String() = Nothing
    Private strPassword As String = ""

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        bClose = True
        bShown = False
        bLogin = False
        iFListCmd = -1
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub toolbarClient_ButtonClick(sender As Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        If e.Button.Text.CompareTo("Chat") = 0 Then
            SendMessage()
            Return
        End If

        If e.Button.Text.CompareTo("About") = 0 Then
            About()
            Return
        End If

        If e.Button.Text.CompareTo("Add") = 0 Then
            AddFriend()
            Return
        End If


        If e.Button.Text.CompareTo("Login") = 0 Then
            Login("", 0)
            Return
        End If
        If e.Button.Text.CompareTo("Logout") = 0 Then
            Quit()
        End If
    End Sub

    Private Sub Quit()
        Dim strParam As String() = New [String](0) {}
        strParam(0) = strLogin
        Bass.BASS_Free()
        If bLogin Then
            Dim xmlQuit As New XmlFormat("QUIT", strParam)
            WriteMsg(xmlQuit.GetXml())
            xmlQuit = Nothing
        End If
        bClose = True


        If clientSocket Is Nothing Then
            Return
        End If
        If clientSocket.IsConnected() Then
            netStream.Close()
            clientSocket.Close()
        End If
        netStream = Nothing
        clientSocket = Nothing
        bClose = True

        Application.[Exit]()
        Return
    End Sub


    Private Sub frmMain_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not bShown Then
            Connect()
            bShown = True
            Login("", 0)
        End If
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If Me.Height < 500 Or Me.Height > 500 Then
            Me.Height = 500
        End If
        If Me.Width < 180 Or Me.Width > 180 Then
            Me.Width = 180
        End If
        treeFriendList.Width = 150
        treeFriendList.Height = statusBarClient.Height + 400
        'treeFriendList.Top = toolbarClient.Height + lblCopyrights.Height + 8
        'lblCopyrights.Width = treeFriendList.Width
        treeFriendList.Left = 8
    End Sub

    Private Sub ProcessLoginAction(frmLog As frmLogin)
        Dim strParam As String() = Nothing
        Dim action As Integer = frmLog.GetCmdAction()
        Dim xmlLog As XmlFormat

        Select Case action
            Case 0
                strParam = New [String](1) {}

                strParam = frmLog.GetLoginInfo()
                strLogin = strParam(0)

                xmlLog = New XmlFormat("AUTH", strParam)
                WriteMsg(xmlLog.GetXml())
                xmlLog = Nothing
                Exit Select
            Case -1
                'skip
                Exit Select
        End Select
    End Sub



    Private Sub Connect()
        clientSocket = New sckClient()
        Try
            clientSocket.Connect("salem-vaio-vmw7", 5555)
        Catch e As Exception
            'Try
            '    add second server
            'Catch

            MessageBox.Show(e.Message, "Connection Error")

            Application.Exit()
            Return
            'End Try
        End Try

        netStream = clientSocket.GetStream()


        thrd = New Thread(New ThreadStart(AddressOf ReadMsg))
        thrd.Start()
        bClose = False
    End Sub

    Private Sub ReadMsg()
        Dim bData As Byte
        Dim str As String = "", strEndTag As String = "</InstantMessenger>"
        Dim ch As Char() = strEndTag.ToCharArray()
        Dim bMatch As Boolean = False
        Dim i As Integer = 0, len As Integer = strEndTag.Length
        Dim bCharFound As Boolean = False
        While True
            Application.DoEvents()
            If bClose Then
                Return
            End If

            Try

                bCharFound = False
                While netStream.DataAvailable
                    If bClose Then
                        Return
                    End If
                    Application.DoEvents()
                    Dim chByte As Char

                    bData = CByte(netStream.ReadByte())

                    chByte = ChrW(bData)
                    If Not bCharFound Then
                        If chByte = " "c OrElse chByte = ControlChars.Cr OrElse chByte = ControlChars.Lf OrElse chByte = ControlChars.Tab Then
                            Continue While
                        Else
                            bCharFound = True
                        End If
                    End If

                    If (chByte = ch(i)) Then
                        i += 1
                    Else
                        i = 0
                    End If

                    str += (ChrW(bData)).ToString()

                    If i = len Then
                        bMatch = True
                        Exit While
                    End If
                End While

                If bMatch Then
                    bMatch = False
                    Dim streamXml As System.IO.StreamWriter
                    If System.IO.File.Exists(strLogin & "temp" & ".xml") Then
                        System.IO.File.Delete(strLogin & "temp" & ".xml")
                    End If
                    streamXml = System.IO.File.CreateText(strLogin & "temp" & ".xml")
                    streamXml.Write(str)
                    streamXml.Close()
                    str = ""
                    i = 0

                    Dim iCode As Integer = parseXml(strLogin & "temp" & ".xml")
                    If iCode <> -1 Then
                        processXml(iCode)
                    End If
                    If iCode = 1 Then
                        bClose = True
                        Return
                    End If
                End If
            Catch ex As Exception

                MessageBox.Show(ex.ToString(), "Session closed on error")
                bClose = True
                Return
            End Try
        End While
    End Sub

    Public Shared Function WriteMsg(strMsg As String) As Integer
        If netStream Is Nothing Then
            Return 1
        End If
        If Not netStream.CanWrite Then
            Return 1
        End If

        Dim len As Integer = strMsg.Length
        Dim chData As Char() = New [Char](len - 1) {}
        Dim bData As Byte() = New Byte(len - 1) {}

        chData = strMsg.ToCharArray()
        For i As Integer = 0 To len - 1
            bData(i) = CByte(AscW(chData(i)))
        Next
        Try
            netStream.Write(bData, 0, len)
        Catch
            bData = Nothing
            chData = Nothing
            Return 1
        End Try
        bData = Nothing
        chData = Nothing
        Return 0
    End Function

    Private Sub frmMain_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.FormClosing
        If bClose = True Then
            Return
        End If
        Quit()
    End Sub

    Private Function parseXml(strFile As String) As Integer
        Dim xmlDoc As New System.Xml.XmlDocument()
        Dim xNode As System.Xml.XmlNode

        strXmlElements = Nothing

        Try
            xmlDoc.Load(strFile)
            If xmlDoc.ChildNodes.Count < 2 Then
                Return (-1)
            End If
            xNode = xmlDoc.ChildNodes.Item(1)
            If xNode.Name.Trim().ToUpper().CompareTo("INSTANTMESSENGER") <> 0 Then
                Return (-1)
            End If

            If xNode.FirstChild.Name.ToUpper().CompareTo("AUTH") = 0 Then
                strXmlElements = New String(0) {}
                If xNode.FirstChild.ChildNodes.Item(0).Name.ToUpper().CompareTo("INT") = 0 Then
                    strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(0).InnerText.Trim()
                    Return 0
                Else
                    Return -1
                End If
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("FRIENDLIST") = 0 Then
                'strXmlElements = New String((xNode.FirstChild.ChildNodes.Count - 1) \ 3) {}
                strXmlElements = New String(xNode.FirstChild.ChildNodes.Count - 1) {}

                If xNode.FirstChild.ChildNodes.Count < 1 Then
                    Return (-1)
                Else
                    strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(0).InnerText
                End If

                Dim k As Integer = 1
                Dim j As Integer = 1
                While j < xNode.FirstChild.ChildNodes.Count
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(k) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    Else
                        Return -1
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j + 1).Name.ToUpper().CompareTo("PRESENCE") = 0 Then
                        strXmlElements(k + 1) = xNode.FirstChild.ChildNodes.Item(j + 1).InnerText
                    Else
                        Return -1
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j + 3).Name.ToUpper().CompareTo("STATUS") = 0 Then
                        strXmlElements(k + 2) = xNode.FirstChild.ChildNodes.Item(j + 3).InnerText.Trim()
                    Else
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j + 2).Name.ToUpper().CompareTo("SUBSCRIPTION") = 0 Then
                        strXmlElements(k + 3) = xNode.FirstChild.ChildNodes.Item(j + 2).InnerText.Trim()
                    Else
                        Return -1
                    End If
                    j += 4
                    k += 4
                End While
                Return 2
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("MSG") = 0 Then
                strXmlElements = New String(2) {}
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("TARGET") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("SOURCE") = 0 Then
                        strXmlElements(1) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("TEXT") = 0 Then
                        strXmlElements(2) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                Next
                If strXmlElements(0) = "" OrElse strXmlElements(1) = "" OrElse strXmlElements(2) = "" Then
                    'invalid xml
                    Return -1
                Else
                    Return 3
                End If

            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("ROSTER") = 0 Then
                Dim k As Integer = 0
                strXmlElements = New [String]((xNode.FirstChild.ChildNodes.Count) \ 2 - 1) {}

                Dim j As Integer = 0
                While j < xNode.FirstChild.ChildNodes.Count
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDID") = 0 Then
                        strXmlElements(k) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    Else
                        Return -1
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j + 1).Name.ToUpper().CompareTo("SUBSCRIPTION") = 0 Then
                        If xNode.FirstChild.ChildNodes.Item(j + 1).InnerText.ToUpper().CompareTo("NONE") = 0 Then
                            strXmlElements(k) += "0"
                        ElseIf xNode.FirstChild.ChildNodes.Item(j + 1).InnerText.ToUpper().CompareTo("FROM") = 0 Then
                            strXmlElements(k) += "1"
                        ElseIf xNode.FirstChild.ChildNodes.Item(j + 1).InnerText.ToUpper().CompareTo("TO") = 0 Then
                            strXmlElements(k) += "2"
                        ElseIf xNode.FirstChild.ChildNodes.Item(j + 1).InnerText.ToUpper().CompareTo("BOTH") = 0 Then
                            strXmlElements(k) += "3"
                        End If
                    Else
                        Return -1
                    End If
                    j += 2
                    k += 1
                End While
                Return 4
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("NOTIFYFRIENDS") = 0 Then
                strXmlElements = New [String](0) {}

                Dim strSts As String = ""
                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("USERNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("STATUS") = 0 Then
                        strSts = xNode.FirstChild.ChildNodes.Item(j).InnerText
                        If xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim().ToUpper().CompareTo("ON-LINE") = 0 Then
                            strXmlElements(0) = "1" & strXmlElements(0)
                        ElseIf xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim().ToUpper().CompareTo("SUBSCRIBE") = 0 Then
                            strXmlElements(0) = "2" & strXmlElements(0)
                        ElseIf xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim().ToUpper().CompareTo("SUBSCRIBED") = 0 Then
                            strXmlElements(0) = "3" & strXmlElements(0)
                        ElseIf xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim().ToUpper().CompareTo("UNSUBSCRIBE") = 0 Then
                            strXmlElements(0) = "4" & strXmlElements(0)
                        ElseIf xNode.FirstChild.ChildNodes.Item(j).InnerText.Trim().ToUpper().CompareTo("UNSUBSCRIBED") = 0 Then
                            strXmlElements(0) = "5" & strXmlElements(0)
                        Else
                            strXmlElements(0) = "0" & strXmlElements(0)

                        End If
                    End If
                Next
                Return 5
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("FRIENDSTATUS") = 0 Then
                strXmlElements = New String(0) {}

                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("STATUS") = 0 Then
                        strXmlElements(0) += xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("ONLINE") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText & strXmlElements(0)
                    End If
                Next
                Return 6
            ElseIf xNode.FirstChild.Name.ToUpper().CompareTo("DELETESTATUS") = 0 Then
                strXmlElements = New String(0) {}

                For j As Integer = 0 To xNode.FirstChild.ChildNodes.Count - 1
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("FRIENDNAME") = 0 Then
                        strXmlElements(0) = xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                    If xNode.FirstChild.ChildNodes.Item(j).Name.ToUpper().CompareTo("STATUS") = 0 Then
                        strXmlElements(0) += xNode.FirstChild.ChildNodes.Item(j).InnerText
                    End If
                Next
                Return 7

            End If
        Catch
            Return (-1)
        End Try
        Return -1
    End Function

    Private Sub processXml(iXmlType As Integer)
        Select Case iXmlType
            Case 0
                'login
                If strXmlElements(0) = "0" Then
                    bLogin = True

                    msgQueue = New Queue()

                    statusBarClient.Text = "Succesfuly Login."
                    'toolbarClient.Buttons(2).Text = "Logout"
                    menuSignIn.Text = "&Sign out"
                    menuLogin.Text = "&Action"
                    'toolbarClient.Buttons(2).ImageIndex = 9
                    Me.Text = strLogin & " (online)"

                ElseIf strXmlElements(0) = "1" Then
                    Me.Hide()
                    Login(strLogin, 1)
                ElseIf strXmlElements(0) = "2" Then
                    Me.Hide()
                    Login(strLogin, 2)
                ElseIf strXmlElements(0) = "-1" Then
                    MessageBox.Show("Closing Application", "Critical Error")
                    Application.[Exit]()
                End If
                Exit Select
            Case 2
                'FriendList
                If Not bLogin Then
                    Return
                End If
                iFListCmd = 0
                'set command for timer_event
                fList = strXmlElements
                Exit Select
            Case 3
                'MSG
                If Not bLogin Then
                    Return
                End If
                Dim frmMsg As frmSendMessage = Nothing
                frmMsg = GetMsgfrm(strXmlElements(1))
                frmMsg.MessageRecieved(strXmlElements(2))
                frmMsg.Show()
                frmMsg.BringToFront()
                Application.DoEvents()
                Exit Select
            Case 4
                'ROSTER
                iFListCmd = 6
                fList = strXmlElements
                Exit Select
            Case 5
                'NOTIFYFRIENDS
                iFListCmd = 1
                strFriendNotify = strXmlElements(0)
                Exit Select
            Case 6
                'frind status
                iFListCmd = 2
                strFriendNotify = strXmlElements(0)
                Exit Select
            Case 7
                'delete
                iFListCmd = 3
                strFriendNotify = strXmlElements(0)
                Exit Select
        End Select
    End Sub

    Public Sub CloseConnection()
        Try
            bClose = True
            bLogin = False
            iFListCmd = -1

            thrd = Nothing

            If netStream IsNot Nothing AndAlso netStream.CanRead Then
                netStream.Close()
            End If
            netStream = Nothing

            If clientSocket IsNot Nothing AndAlso clientSocket.IsConnected() Then
                clientSocket.Close()
            End If
            clientSocket = Nothing

        Catch
        End Try
    End Sub

    Private Function GetMsgfrm(strFriend As String) As frmSendMessage
        Dim objMsgFrm As Object() = Nothing
        Dim frmMsg As frmSendMessage = Nothing

        objMsgFrm = msgQueue.ToArray()
        For f As Integer = 0 To objMsgFrm.Length - 1
            frmMsg = DirectCast(objMsgFrm(f), frmSendMessage)
            If frmMsg.friendname.Trim().ToUpper().CompareTo(strFriend.ToUpper()) = 0 Then
                Return DirectCast(objMsgFrm(f), frmSendMessage)
            End If
        Next

        objMsgFrm = Nothing
        frmMsg = Nothing

        frmMsg = New frmSendMessage(strFriend)
        msgQueue.Enqueue(DirectCast(frmMsg, Object))
        Return frmMsg
    End Function

    Private Sub treeFriendList_DoubleClick(sender As Object, e As System.EventArgs) Handles treeFriendList.DoubleClick
        SendMessage()
    End Sub

    Private Sub timerIM_Tick(sender As Object, e As System.EventArgs) Handles timerIM.Tick
        Dim iCmd As Integer = iFListCmd, iLen As Integer = 0
        Dim sImg As String = "", sNotify As String = ""
        Dim frmChat As frmSendMessage = Nothing

        Try
            If iFListCmd <> -1 Then
                iFListCmd = -1

                Dim node As New TreeNode()
                Dim iImgIdx As Integer = 0
                node = Me.treeFriendList.TopNode

                Select Case iCmd
                    Case 0
                        'Friend list
                        'For i As Integer = 1 To fList.Length - 1
                        For i As Integer = 1 To fList.Length - 1 Step 4
                            'If fList(i).Substring(0, 1) = "0" Then
                            '    iImgIdx = 3
                            'Else
                            '    iImgIdx = 2
                            'End If
                            'AddFriendInTree(fList(i).Substring(1), iImgIdx)

                            If fList(i + 1) = "Subscribed" Then
                                If fList(i + 2) = "0" Then
                                    iImgIdx = 3
                                Else
                                    iImgIdx = 2
                                End If
                            Else
                                iImgIdx = 10
                            End If
                            AddFriendInTree(fList(i), iImgIdx)
                            If fList(i + 3).ToUpper = "TO" Then
                                AddConfirm(fList(i))
                            End If
                        Next
                        treeFriendList.TopNode.Expand()

                        Exit Select
                    Case 1
                        'notification
                        Dim img As Integer = 3

                        sNotify = strFriendNotify.Substring(0, 1)
                        If sNotify = "1" Then
                            img = 2
                        ElseIf sNotify = "0" Then
                            img = 3
                            frmChat = GetMsgfrm(strFriendNotify.Substring(1))
                            frmChat.CloseChat()
                        ElseIf sNotify = "5" Then
                            frmChat = GetMsgfrm(strFriendNotify.Substring(1))
                            frmChat.CloseChat()
                        Else
                            img = -1
                        End If

                        If img <> -1 Then
                            'replace icon
                            DelFriendFromTree(strFriendNotify.Substring(1))
                            AddFriendInTree(strFriendNotify.Substring(1), img)
                        End If
                        'popup form : this will notify friend's status.
                        Dim frmPop As New frmPopup(strFriendNotify.Substring(1), sNotify)
                        frmPop.Top = Screen.PrimaryScreen.WorkingArea.Bottom
                        frmPop.Left = Screen.PrimaryScreen.WorkingArea.Width - frmPop.Width
                        frmPop.Height = 40
                        frmPop.TopMost = True
                        frmPop.Show()

                        If sNotify = "2" Then
                            AddConfirm(strFriendNotify.Substring(1))
                        ElseIf sNotify = "4" Then
                            DelConfirm(strFriendNotify.Substring(1))
                        End If
                        Exit Select
                    Case 2
                        'add local friend
                        If strFriendNotify.Substring(strFriendNotify.Length - 1) = "0" Then
                            iImgIdx = 10

                            AddFriendInTree(strFriendNotify.Substring(1, strFriendNotify.Length - 2), iImgIdx)
                            treeFriendList.TopNode.Expand()
                        Else
                            MessageBox.Show("Can't Add " & strFriendNotify.Substring(1, strFriendNotify.Length - 2) & " as friend")
                        End If
                        Exit Select
                    Case 3
                        'del local friend
                        If strFriendNotify.Substring(strFriendNotify.Length - 1) = "0" Then
                            Dim strFrnd As String = strFriendNotify.Substring(0, strFriendNotify.Length - 1).ToUpper()
                            DelFriendFromTree(strFrnd)
                            frmChat = GetMsgfrm(strFrnd)
                            frmChat.CloseChat()
                        Else
                            MessageBox.Show("Can't Delete " & strFriendNotify.Substring(1, strFriendNotify.Length - 1) & " as friend")
                        End If
                        Exit Select
                    Case 6
                        'roster
                        For i As Integer = 0 To fList.Length - 1
                            iLen = fList(i).Length
                            sImg = fList(i).Substring(iLen - 1, 1)
                            If sImg <> "0" Then
                                AddFriendInTree(fList(i), 3)
                            Else
                                DelFriendFromTree(fList(i))

                            End If
                        Next
                        treeFriendList.TopNode.Expand()
                        Exit Select
                End Select
            End If

        Catch
        End Try
    End Sub

    Private Sub AddFriendInTree(strFriend As String, iImgIdx As Integer)
        For Each trNode As TreeNode In Me.treeFriendList.TopNode.Nodes
            If trNode.Text.ToUpper() = strFriend.ToUpper() Then
                Return
            End If
        Next

        Dim child As New TreeNode(strFriend, iImgIdx, iImgIdx)
        treeFriendList.TopNode.Nodes.Add(child)
        child = Nothing
    End Sub

    Private Sub DelFriendFromTree(strFriend As String)
        Dim node As New TreeNode()
        node = Me.treeFriendList.TopNode

        For Each trNode As TreeNode In node.Nodes
            If trNode.Text.ToUpper() = strFriend.ToUpper() Then
                treeFriendList.TopNode.Nodes.Remove(trNode)
                Return
            End If
        Next
    End Sub

    Private Sub AddConfirm(strFriend As String)

        Dim frmAddConfirm As AddConfirm = New AddConfirm(strFriend)
        frmAddConfirm.Show()
    End Sub

    Private Sub DelConfirm(strFriend As String)
        'الداله هذي مرات نحولها
        MessageBox.Show(strFriend.ToUpper() & " is requesting for deletion", "Request for deletion")
        Dim strParam As String() = New [String](1) {}
        strParam(0) = strLogin
        strParam(1) = strFriend
        Dim xmlAccept As New XmlFormat("UNSUBSCRIBEFRIEND", strParam)
        WriteMsg(xmlAccept.GetXml())
        xmlAccept = Nothing
    End Sub



    Private Sub menuAddFriend_Click(sender As Object, e As System.EventArgs) Handles menuAddFriend.Click
        AddFriend()
    End Sub

    Private Sub menuSendMsg_Click(sender As Object, e As System.EventArgs) Handles menuSendMsg.Click
        SendMessage()
    End Sub

    Private Sub menuDelFriend_Click(sender As Object, e As System.EventArgs) Handles menuDelFriend.Click
        DelFriend()
    End Sub

    Private Sub menuPlayStream_Click(sender As System.Object, e As System.EventArgs) Handles menuPlayStream.Click
        If treeFriendList.SelectedNode.ImageIndex <> 2 Then
            MsgBox("you can not play stream from OFF Line friend")
            Return
        Else
            Dim playstream As New frmPlayAudioStreaming(treeFriendList.SelectedNode.Text.Trim())
            playstream.Show()
        End If
    End Sub

    Private Sub menuAbout_Click(sender As Object, e As System.EventArgs) Handles menuAbout.Click
        About()
    End Sub

    Private Sub Login(strLog As String, iCmd As Integer)
        If bClose = True Then
            Return
        End If
        Dim frmLog As New frmLogin(strLog, iCmd)
        frmLog.ShowDialog()
        ProcessLoginAction(frmLog)
        frmLog = Nothing
    End Sub

    Private Sub About()
        Dim frmAb As New frmAbout()
        frmAb.ShowDialog()
        frmAb = Nothing
    End Sub

    Private Sub AddFriend()
        If Not bLogin Then
            Return
        End If

        Dim strFriendName As String = ""
        Dim frmAddFrnd As New frmAddFriend(strLogin, 0, "")
        frmAddFrnd.ShowDialog()
        strFriendName = frmAddFrnd.GetFriendName()
        frmAddFrnd = Nothing
        If strFriendName <> "" Then
            Dim strParam As String() = New String(1) {}
            strParam(0) = strLogin
            strParam(1) = strFriendName
            Dim xmlAdd As New XmlFormat("ADDFRIEND", strParam)

            WriteMsg(xmlAdd.GetXml())
            xmlAdd = Nothing
            strParam = Nothing
        End If
    End Sub

    Private Sub SendMessage()
        If Not bLogin Then
            Return
            MsgBox("error")
        End If

        Dim strFriendName As String = treeFriendList.SelectedNode.Text
        If strFriendName.Trim() = "" Then
            Return
        End If
        If strFriendName.CompareTo("Friends") = 0 Then
            Return
        End If
        If treeFriendList.SelectedNode.ImageIndex <> 2 Then
            MsgBox("you can not send msg to OFF Line friend")
            Return
        End If

        Dim frmMsg As frmSendMessage = Nothing
        frmMsg = GetMsgfrm(strFriendName)

        frmMsg.Show()

    End Sub

    Private Sub DelFriend()
        If Not bLogin Then
            Return
        End If

        If treeFriendList.SelectedNode.Text.Trim() = "" Then
            Return
        End If
        If treeFriendList.SelectedNode.Text.Trim().CompareTo("Friends") = 0 Then
            Return
        End If

        If treeFriendList.SelectedNode.Text.Trim().CompareTo("HelpDesk") = 0 Then
            Return
        End If


        Dim frmDel As New frmAddFriend(strLogin, 1, treeFriendList.SelectedNode.Text.Trim())
        frmDel.ShowDialog()

        Dim strParam As String() = New String(1) {}
        strParam(0) = strLogin
        strParam(1) = frmDel.GetFriendName()

        If strParam(1).Trim() = "" Then
            Return
        End If

        Dim xmlDel As New XmlFormat("DELETEFRIEND", strParam)
        WriteMsg(xmlDel.GetXml())
        frmDel = Nothing
        strParam = Nothing
    End Sub

    Private Sub menuAdd_Click(sender As Object, e As System.EventArgs) Handles menuAdd.Click
        AddFriend()
    End Sub

    Private Sub menuSend_Click(sender As Object, e As System.EventArgs) Handles menuSend.Click
        SendMessage()
    End Sub

    Private Sub menuDel_Click(sender As Object, e As System.EventArgs) Handles menuDel.Click
        DelFriend()
    End Sub

    Private Sub menuSignIn_Click(sender As Object, e As System.EventArgs) Handles menuSignIn.Click
        If menuSignIn.Text = "&Sign in" Then
            Login("", 0)
        Else
            Quit()
        End If
    End Sub

    Private Sub menuAbout_Click_1(sender As System.Object, e As System.EventArgs) Handles menuAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub MenuStartAudioStreaming_Click(sender As System.Object, e As System.EventArgs) Handles MenuStartAudioStreaming.Click
        frmStartAudioStreaming.Show()
    End Sub


End Class