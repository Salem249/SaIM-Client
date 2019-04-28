Public Class AddConfirm
    Private strFriend As String
    Private objFrm As New frmMain
    Public Sub New(strFriend As String)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        Me.strFriend = strFriend

        lblMessage.Text = strFriend.ToUpper() & " has requested you to view your online status"
    End Sub
    Private Sub cmdAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAccept.Click
        Accept("0")
        Me.Close()
    End Sub

    Private Sub cmdDecline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDecline.Click
        Accept("1")
        Me.Close()
    End Sub

    Private Sub Accept(strCode As String)
        Me.Hide()
        Dim strParam As String() = New [String](2) {}
        strParam(0) = frmMain.strLogin
        strParam(1) = strFriend.ToLower()
        strParam(2) = strCode
        Dim xmlAccept As New XmlFormat("ACCEPTFRIEND", strParam)
        frmMain.WriteMsg(xmlAccept.GetXml())
        xmlAccept = Nothing
    End Sub

    Private Sub AddConfirm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

End Class