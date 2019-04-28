Public Class frmSendMessage
    Private username As String
    Public friendname As String
    Public Sub New(friendname As String)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        Me.username = frmMain.strLogin
        Me.friendname = friendname
        lblFriendName.Text = friendname

        Me.Text = "Chat ( " + frmMain.strLogin & " : Online)"
    End Sub
    Public Sub MessageRecieved(msg As String)
        Dim iLen As Integer = 0, iTotal As Integer = 0
        Dim str As String = friendname & " says: "
        iLen = str.Length
        iTotal = txtMessages.Text.Length

        txtMessages.AppendText(str)
        txtMessages.SelectionStart = iTotal
        txtMessages.SelectionLength = iLen

        txtMessages.SelectionColor = System.Drawing.Color.Red

        txtMessages.AppendText(msg & vbCr & vbLf)
        Me.Focus()
        txtMessageSend.Focus()
    End Sub
    Private Sub cmdSend_Click(sender As Object, e As System.EventArgs) Handles cmdSend.Click
        If txtMessageSend.Text.Trim() = "" Then
            Return
        End If

        Dim iLen As Integer = 0, iTotal As Integer = 0
        Dim str As String = username & " says : "
        Dim strParam As String() = New String(2) {}

        iLen = str.Length
        iTotal = txtMessages.Text.Length

        txtMessages.AppendText(str)
        txtMessages.SelectionStart = iTotal
        txtMessages.SelectionLength = iLen

        txtMessages.SelectionColor = System.Drawing.Color.Blue

        strParam(0) = friendname
        strParam(1) = username
        strParam(2) = txtMessageSend.Text

        txtMessages.AppendText(txtMessageSend.Text & vbCr & vbLf)
        txtMessageSend.Text = ""
        txtMessageSend.Focus()

        Dim xmlReg As New XmlFormat("MSG", strParam)
        If frmMain.WriteMsg(xmlReg.GetXml()) <> 0 Then
            xmlReg = Nothing
            MessageBox.Show("Can't Send Message.", "Error")
            Me.Close()
        End If
        xmlReg = Nothing
    End Sub

    Private Sub frmSendMessage_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        txtMessageSend.Focus()
    End Sub

    Private Sub frmSendMessage_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Close()
    End Sub

    Private Sub txtMessageSend_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMessageSend.KeyPress
        If e.KeyChar = ChrW(13) Then
            cmdSend_Click(sender, e)
        End If
    End Sub
    Private Overloads Sub Close()
        Me.Hide()
        txtMessages.Text = ""
        txtMessageSend.Text = ""
    End Sub
    Public Sub CloseChat()
        Close()
        MessageBox.Show(friendname & " has gone offline", "Closing chat window")
    End Sub
End Class