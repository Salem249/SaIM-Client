Imports System.Threading
Public Class frmPopup
    Private bActivate As Boolean
    Private strFriend As String = ""
    Public Sub New(strLoginName As [String], sNotify As String)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()



        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        lblUserName.Text = strLoginName

        pictureOffLine.Visible = False
        pictureOnLine.Visible = False

        Select Case sNotify.ToCharArray()(0)
            Case "0"c
                pictureOffLine.Visible = True
                lblMessage.Text = "Log-out"
                Exit Select
            Case "1"c
                pictureOnLine.Visible = True
                lblMessage.Text = "Log-in"
                Exit Select
            Case "2"c
                lblMessage.Text = "requesting for addition"
                Exit Select
            Case "3"c
                lblMessage.Text = "has added you in his list"
                Exit Select
            Case "4"c
                lblMessage.Text = "requesting for deletion"
                Exit Select
            Case "5"c
                lblMessage.Text = "has deleted you from the friend list"
                Exit Select
        End Select
        bActivate = False
    End Sub
    Private Sub popupMsg()
        Dim height As Integer = 0
        Me.Top = Screen.PrimaryScreen.WorkingArea.Bottom
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        height = 70

        bActivate = True
        For i As Integer = 0 To height - 1
            Me.Top = Screen.PrimaryScreen.WorkingArea.Height - i
            Me.Height = i
            Thread.Sleep(20)
        Next

        Thread.Sleep(5000)

        For i As Integer = 0 To height - 1
            Me.Top = Screen.PrimaryScreen.WorkingArea.Height + i - height
            Me.Height -= 1
            Thread.Sleep(20)
        Next
        Me.Close()
    End Sub

    Private Sub frmPopup_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If bActivate = False Then
            Me.Top = Screen.PrimaryScreen.WorkingArea.Bottom

            Dim thrMsg As New Thread(New ThreadStart(AddressOf popupMsg))
            thrMsg.Start()
        End If
    End Sub
End Class