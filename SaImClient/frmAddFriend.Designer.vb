<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddFriend
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddFriend))
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cmdAddFriend = New System.Windows.Forms.Button()
        Me.txtFriendName = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(119, 25)
        Me.txtUserName.MaxLength = 20
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(136, 20)
        Me.txtUserName.TabIndex = 5
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(3, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(68, 13)
        Me.label2.TabIndex = 6
        Me.label2.Text = "User Name"
        '
        'cmdAddFriend
        '
        Me.cmdAddFriend.Location = New System.Drawing.Point(119, 85)
        Me.cmdAddFriend.Name = "cmdAddFriend"
        Me.cmdAddFriend.Size = New System.Drawing.Size(88, 24)
        Me.cmdAddFriend.TabIndex = 7
        Me.cmdAddFriend.Text = "&Add Friend"
        '
        'txtFriendName
        '
        Me.txtFriendName.Location = New System.Drawing.Point(119, 59)
        Me.txtFriendName.MaxLength = 20
        Me.txtFriendName.Name = "txtFriendName"
        Me.txtFriendName.Size = New System.Drawing.Size(136, 20)
        Me.txtFriendName.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(3, 62)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(110, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Enter Friend Name"
        '
        'frmAddFriend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(282, 113)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.cmdAddFriend)
        Me.Controls.Add(Me.txtFriendName)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmAddFriend"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Friend"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cmdAddFriend As System.Windows.Forms.Button
    Friend WithEvents txtFriendName As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
End Class
