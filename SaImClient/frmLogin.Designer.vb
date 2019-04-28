<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.grpBxLogin = New System.Windows.Forms.GroupBox()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLoginName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.grpBxLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBxLogin
        '
        Me.grpBxLogin.BackgroundImage = CType(resources.GetObject("grpBxLogin.BackgroundImage"), System.Drawing.Image)
        Me.grpBxLogin.Controls.Add(Me.cmdLogin)
        Me.grpBxLogin.Controls.Add(Me.txtPassword)
        Me.grpBxLogin.Controls.Add(Me.txtLoginName)
        Me.grpBxLogin.Controls.Add(Me.lblPassword)
        Me.grpBxLogin.Controls.Add(Me.lblName)
        Me.grpBxLogin.Location = New System.Drawing.Point(12, 12)
        Me.grpBxLogin.Name = "grpBxLogin"
        Me.grpBxLogin.Size = New System.Drawing.Size(248, 112)
        Me.grpBxLogin.TabIndex = 4
        Me.grpBxLogin.TabStop = False
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(97, 81)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(72, 25)
        Me.cmdLogin.TabIndex = 4
        Me.cmdLogin.Text = "&Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(112, 48)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(112, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtLoginName
        '
        Me.txtLoginName.Location = New System.Drawing.Point(112, 24)
        Me.txtLoginName.MaxLength = 20
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(112, 20)
        Me.txtLoginName.TabIndex = 1
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.White
        Me.lblPassword.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.Location = New System.Drawing.Point(32, 51)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 13)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "Password"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.White
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.Location = New System.Drawing.Point(32, 27)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Login Name"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(271, 138)
        Me.Controls.Add(Me.grpBxLogin)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.grpBxLogin.ResumeLayout(False)
        Me.grpBxLogin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBxLogin As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLoginName As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
End Class
