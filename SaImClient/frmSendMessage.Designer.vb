<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendMessage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendMessage))
        Me.txtMessages = New System.Windows.Forms.RichTextBox()
        Me.txtMessageSend = New System.Windows.Forms.TextBox()
        Me.lblFriendName = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtMessages
        '
        Me.txtMessages.BackColor = System.Drawing.Color.White
        Me.txtMessages.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessages.Location = New System.Drawing.Point(11, 48)
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ReadOnly = True
        Me.txtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtMessages.Size = New System.Drawing.Size(363, 189)
        Me.txtMessages.TabIndex = 6
        Me.txtMessages.Text = ""
        '
        'txtMessageSend
        '
        Me.txtMessageSend.Location = New System.Drawing.Point(12, 261)
        Me.txtMessageSend.MaxLength = 255
        Me.txtMessageSend.Name = "txtMessageSend"
        Me.txtMessageSend.Size = New System.Drawing.Size(308, 20)
        Me.txtMessageSend.TabIndex = 8
        '
        'lblFriendName
        '
        Me.lblFriendName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFriendName.Location = New System.Drawing.Point(128, 15)
        Me.lblFriendName.Name = "lblFriendName"
        Me.lblFriendName.Size = New System.Drawing.Size(192, 16)
        Me.lblFriendName.TabIndex = 9
        Me.lblFriendName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.White
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label1.Location = New System.Drawing.Point(45, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(77, 13)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Friend Name"
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(326, 261)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(48, 20)
        Me.cmdSend.TabIndex = 11
        Me.cmdSend.Text = "&Send"
        '
        'frmSendMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(386, 292)
        Me.Controls.Add(Me.txtMessages)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.txtMessageSend)
        Me.Controls.Add(Me.lblFriendName)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmSendMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chat Window"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMessages As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMessageSend As System.Windows.Forms.TextBox
    Friend WithEvents lblFriendName As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSend As System.Windows.Forms.Button
End Class
