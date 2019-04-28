<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopup))
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.pictureOnLine = New System.Windows.Forms.PictureBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.pictureOffLine = New System.Windows.Forms.PictureBox()
        Me.panel1.SuspendLayout()
        CType(Me.pictureOnLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureOffLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.pictureOnLine)
        Me.panel1.Controls.Add(Me.lblMessage)
        Me.panel1.Controls.Add(Me.lblUserName)
        Me.panel1.Controls.Add(Me.pictureOffLine)
        Me.panel1.Location = New System.Drawing.Point(17, 14)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(168, 48)
        Me.panel1.TabIndex = 5
        '
        'pictureOnLine
        '
        Me.pictureOnLine.Image = CType(resources.GetObject("pictureOnLine.Image"), System.Drawing.Image)
        Me.pictureOnLine.Location = New System.Drawing.Point(8, 0)
        Me.pictureOnLine.Name = "pictureOnLine"
        Me.pictureOnLine.Size = New System.Drawing.Size(24, 16)
        Me.pictureOnLine.TabIndex = 1
        Me.pictureOnLine.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(8, 24)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(160, 16)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(32, 8)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(120, 16)
        Me.lblUserName.TabIndex = 2
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pictureOffLine
        '
        Me.pictureOffLine.Image = CType(resources.GetObject("pictureOffLine.Image"), System.Drawing.Image)
        Me.pictureOffLine.Location = New System.Drawing.Point(8, 0)
        Me.pictureOffLine.Name = "pictureOffLine"
        Me.pictureOffLine.Size = New System.Drawing.Size(24, 24)
        Me.pictureOffLine.TabIndex = 0
        Me.pictureOffLine.TabStop = False
        '
        'frmPopup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(206, 84)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(20, 50)
        Me.Name = "frmPopup"
        Me.ShowInTaskbar = False
        Me.Text = "frmPopup"
        Me.panel1.ResumeLayout(False)
        CType(Me.pictureOnLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureOffLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents pictureOnLine As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents pictureOffLine As System.Windows.Forms.PictureBox
End Class
