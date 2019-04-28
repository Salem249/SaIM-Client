<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayAudioStreaming
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayAudioStreaming))
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdMute = New System.Windows.Forms.Button()
        Me.trcValume = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.VisTimer = New System.Windows.Forms.Timer(Me.components)
        Me.VisualisationBox = New System.Windows.Forms.PictureBox()
        Me.txtStream = New System.Windows.Forms.TextBox()
        CType(Me.trcValume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.VisualisationBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(98, 99)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdPlay.TabIndex = 0
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(179, 99)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdMute
        '
        Me.cmdMute.Location = New System.Drawing.Point(260, 99)
        Me.cmdMute.Name = "cmdMute"
        Me.cmdMute.Size = New System.Drawing.Size(75, 23)
        Me.cmdMute.TabIndex = 3
        Me.cmdMute.Text = "Mute"
        Me.cmdMute.UseVisualStyleBackColor = True
        '
        'trcValume
        '
        Me.trcValume.BackColor = System.Drawing.Color.White
        Me.trcValume.LargeChange = 3
        Me.trcValume.Location = New System.Drawing.Point(92, 123)
        Me.trcValume.Name = "trcValume"
        Me.trcValume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trcValume.Size = New System.Drawing.Size(45, 85)
        Me.trcValume.SmallChange = 2
        Me.trcValume.TabIndex = 5
        Me.trcValume.TickFrequency = 2
        Me.trcValume.Value = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.RadioButton7)
        Me.GroupBox1.Controls.Add(Me.RadioButton8)
        Me.GroupBox1.Controls.Add(Me.RadioButton6)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(92, 208)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Visualisation"
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(10, 111)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(53, 17)
        Me.RadioButton7.TabIndex = 11
        Me.RadioButton7.Text = "Wave"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(10, 157)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(80, 17)
        Me.RadioButton8.TabIndex = 12
        Me.RadioButton8.Text = "Wave Form"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(10, 180)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(70, 17)
        Me.RadioButton6.TabIndex = 10
        Me.RadioButton6.Text = "Line Peak"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 17)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Bean"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(8, 42)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton5.TabIndex = 9
        Me.RadioButton5.Text = "Line"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(10, 65)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.Text = "Dot"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(10, 134)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton4.TabIndex = 8
        Me.RadioButton4.Text = "Ellipse"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(10, 88)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(57, 17)
        Me.RadioButton3.TabIndex = 7
        Me.RadioButton3.Text = "Classic"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'VisTimer
        '
        '
        'VisualisationBox
        '
        Me.VisualisationBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.VisualisationBox.Location = New System.Drawing.Point(92, 0)
        Me.VisualisationBox.Name = "VisualisationBox"
        Me.VisualisationBox.Size = New System.Drawing.Size(282, 94)
        Me.VisualisationBox.TabIndex = 16
        Me.VisualisationBox.TabStop = False
        '
        'txtStream
        '
        Me.txtStream.Location = New System.Drawing.Point(157, 154)
        Me.txtStream.Name = "txtStream"
        Me.txtStream.Size = New System.Drawing.Size(179, 20)
        Me.txtStream.TabIndex = 17
        '
        'frmPlayAudioStreaming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(374, 211)
        Me.Controls.Add(Me.txtStream)
        Me.Controls.Add(Me.VisualisationBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.trcValume)
        Me.Controls.Add(Me.cmdMute)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdPlay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmPlayAudioStreaming"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Play Audio Streaming"
        CType(Me.trcValume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.VisualisationBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdMute As System.Windows.Forms.Button
    Friend WithEvents trcValume As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents VisTimer As System.Windows.Forms.Timer
    Friend WithEvents VisualisationBox As System.Windows.Forms.PictureBox
    Friend WithEvents txtStream As System.Windows.Forms.TextBox
End Class
