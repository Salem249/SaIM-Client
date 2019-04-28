<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.labelJabber = New System.Windows.Forms.Label()
        Me.lblCopyrights = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'labelJabber
        '
        Me.labelJabber.AutoSize = True
        Me.labelJabber.ForeColor = System.Drawing.Color.White
        Me.labelJabber.Image = CType(resources.GetObject("labelJabber.Image"), System.Drawing.Image)
        Me.labelJabber.Location = New System.Drawing.Point(54, 38)
        Me.labelJabber.Name = "labelJabber"
        Me.labelJabber.Size = New System.Drawing.Size(137, 13)
        Me.labelJabber.TabIndex = 1
        Me.labelJabber.Text = "salem_ali2006@yahoo.com"
        Me.labelJabber.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCopyrights
        '
        Me.lblCopyrights.AutoSize = True
        Me.lblCopyrights.ForeColor = System.Drawing.Color.Transparent
        Me.lblCopyrights.Image = CType(resources.GetObject("lblCopyrights.Image"), System.Drawing.Image)
        Me.lblCopyrights.Location = New System.Drawing.Point(80, 9)
        Me.lblCopyrights.Name = "lblCopyrights"
        Me.lblCopyrights.Size = New System.Drawing.Size(78, 13)
        Me.lblCopyrights.TabIndex = 2
        Me.lblCopyrights.Text = "Salem ali salem"
        Me.lblCopyrights.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(232, 60)
        Me.Controls.Add(Me.labelJabber)
        Me.Controls.Add(Me.lblCopyrights)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelJabber As System.Windows.Forms.Label
    Private WithEvents lblCopyrights As System.Windows.Forms.Label
End Class
