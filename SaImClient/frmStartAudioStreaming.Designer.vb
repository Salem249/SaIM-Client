<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartAudioStreaming
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartAudioStreaming))
        Me.cmdStartStrreaming = New System.Windows.Forms.Button()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.cmdOpenFile = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.cmdStopStrreaming = New System.Windows.Forms.Button()
        Me.statusBarStartStreaming = New System.Windows.Forms.StatusBar()
        Me.SuspendLayout()
        '
        'cmdStartStrreaming
        '
        Me.cmdStartStrreaming.Location = New System.Drawing.Point(96, 50)
        Me.cmdStartStrreaming.Name = "cmdStartStrreaming"
        Me.cmdStartStrreaming.Size = New System.Drawing.Size(85, 23)
        Me.cmdStartStrreaming.TabIndex = 0
        Me.cmdStartStrreaming.Text = "Start Stream"
        Me.cmdStartStrreaming.UseVisualStyleBackColor = True
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.Filter = "MP3 Files|*.MP3"
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.Location = New System.Drawing.Point(12, 13)
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.Size = New System.Drawing.Size(75, 23)
        Me.cmdOpenFile.TabIndex = 1
        Me.cmdOpenFile.Text = "open file"
        Me.cmdOpenFile.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(96, 15)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(176, 20)
        Me.txtFileName.TabIndex = 2
        '
        'cmdStopStrreaming
        '
        Me.cmdStopStrreaming.Location = New System.Drawing.Point(187, 50)
        Me.cmdStopStrreaming.Name = "cmdStopStrreaming"
        Me.cmdStopStrreaming.Size = New System.Drawing.Size(85, 23)
        Me.cmdStopStrreaming.TabIndex = 4
        Me.cmdStopStrreaming.Text = "Stop Stream"
        Me.cmdStopStrreaming.UseVisualStyleBackColor = True
        '
        'statusBarStartStreaming
        '
        Me.statusBarStartStreaming.Location = New System.Drawing.Point(0, 84)
        Me.statusBarStartStreaming.Name = "statusBarStartStreaming"
        Me.statusBarStartStreaming.Size = New System.Drawing.Size(284, 22)
        Me.statusBarStartStreaming.TabIndex = 5
        '
        'frmStartAudioStreaming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(284, 106)
        Me.Controls.Add(Me.statusBarStartStreaming)
        Me.Controls.Add(Me.cmdStopStrreaming)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.cmdOpenFile)
        Me.Controls.Add(Me.cmdStartStrreaming)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmStartAudioStreaming"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Audio Streaming"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdStartStrreaming As System.Windows.Forms.Button
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdOpenFile As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmdStopStrreaming As System.Windows.Forms.Button
    Friend WithEvents statusBarStartStreaming As System.Windows.Forms.StatusBar

End Class