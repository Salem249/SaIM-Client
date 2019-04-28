Imports Un4seen.Bass
Imports System.Net.Sockets

Public Class frmLogin
    Private action As Integer
    '0 : login,  -1 : cancel
    Private iCode As Integer
    Private bMsgShow As Boolean
    Dim objfrmMain As frmMain
    Public Shared strLoginName As String
    Private bClose As Boolean
    Private clientSocket As sckClient
    Private Shared netStream As NetworkStream = Nothing



    Public Sub New(strLogin As String, iCode As Integer)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        action = -1
        txtLoginName.Text = strLogin
        Me.iCode = iCode
        bMsgShow = False
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As System.EventArgs) Handles cmdLogin.Click
        If txtLoginName.Text.Trim() = "" Then
            MessageBox.Show("Login can't be empty")
            txtLoginName.Focus()
            Return
        End If

        If txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Password can't be empty")
            txtPassword.Focus()
            Return
        End If
        strLoginName = txtLoginName.Text
        action = 0
        Me.Close()
    End Sub
    Public Function GetLoginInfo() As String()
        Dim strReturn As String() = New String(1) {}
        strReturn(0) = txtLoginName.Text.Trim()
        strReturn(1) = txtPassword.Text.Trim()

        Return strReturn
    End Function

    Public Function GetCmdAction() As Integer
        Dim act As Integer = action
        action = -1
        'clear last action
        Return act
    End Function

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bMsgShow Then
            Return
        End If
        bMsgShow = True

        If iCode = 1 Then
            MessageBox.Show("Invlaid Login Name", "Error")
            txtLoginName.Focus()
        ElseIf iCode = 2 Then
            MessageBox.Show("Invlaid Password", "Error")
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtLoginName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoginName.KeyPress
        If (AscW(e.KeyChar)) = 13 Then
            cmdLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If (AscW(e.KeyChar)) = 13 Then
            cmdLogin_Click(sender, e)
        End If
    End Sub

End Class