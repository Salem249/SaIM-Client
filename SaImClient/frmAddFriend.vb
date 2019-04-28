Public Class frmAddFriend
    Private strFriendName As String
    Public Sub New(strLogin As String, iAction As Integer, strFriend As String)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        txtUserName.Text = strLogin
        strFriendName = ""

        If iAction = 0 Then
            Me.Text = "Add Friend"
            cmdAddFriend.Text = "&Add Friend"
        Else
            Me.Text = "Delete Friend"
            cmdAddFriend.Text = "&Del Friend"
            txtFriendName.Text = strFriend
            txtFriendName.Enabled = False
        End If
    End Sub
    Public Function GetFriendName() As String
        Return strFriendName
    End Function

    Private Sub cmdAddFriend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddFriend.Click
        strFriendName = txtFriendName.Text.Trim()
        If txtFriendName.Text.Trim() = "" Then
            MessageBox.Show("Friend name can't be empty", "Error")
            txtFriendName.Focus()
        ElseIf txtFriendName.Text.Trim = txtUserName.Text.Trim Then
            MessageBox.Show("you can't add your self", "Error")
            txtFriendName.Focus()
        Else
            Me.Close()
        End If
    End Sub
End Class