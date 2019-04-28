Imports Un4seen.Bass
Imports System.Threading

Public Class frmPlayAudioStreaming
    Public drawing As New Un4seen.Bass.Misc.Visuals
    Private eror As String = Nothing
    Private stream As Integer
    Private Voulme As Integer
    Private StrChcTHD As Thread
    Private StreamTHD As Thread
    Private strURL As String
    Private strStreamfrom As String

    Public Sub New(StreamFrom As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strURL = "http://Salem-VAIO-VMW7:8000/" & StreamFrom
        txtStream.Text = "You wont play stream from " & StreamFrom
        strStreamfrom = StreamFrom


    End Sub
    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click
        'Bass.BASS_Free()
        trcValume.Value = 3

        If Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero) Then
            ' create a stream channel from a file
            stream = Bass.BASS_StreamCreateURL(strURL, 0, BASSFlag.BASS_DEFAULT, Nothing, IntPtr.Zero)
            eror = Un4seen.Bass.Bass.BASS_ErrorGetCode

            If stream <> 0 Then
                ' play the stream channel
                VisTimer.Start()

                StreamTHD = New Thread(New ThreadStart(AddressOf play))
                StreamTHD.Start()
                cmdStop.Enabled = True
                cmdMute.Enabled = True
                trcValume.Enabled = True
                cmdPlay.Enabled = False
                txtStream.Text = "You now play stream from " & strStreamfrom

                StrChcTHD = New Thread(New ThreadStart(AddressOf StreamCheck))
                StrChcTHD.Start()
            Else
                MsgBox("There is no stream from this user")
                Bass.BASS_Free()
            End If

        End If
    End Sub

    Public Sub play()
        Try

            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 3 / 10)
            txtStream.Text = "You now play stream from " & strStreamfrom
            Bass.BASS_ChannelPlay(stream, False)
        Catch
            MsgBox("Stream error: " & Bass.BASS_ErrorGetCode())
            Bass.BASS_Free()
        End Try
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        StrChcTHD.Suspend()
        Bass.BASS_Free()
        cmdStop.Enabled = False
        cmdMute.Enabled = False
        trcValume.Enabled = False
        cmdPlay.Enabled = True
        txtStream.Text = "You stoped stream from " & strStreamfrom

    End Sub

    Private Sub cmdMute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMute.Click
        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0)
        trcValume.Value = 0
    End Sub

    Private Sub trcValume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trcValume.Scroll
        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, trcValume.Value / 10)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        cmdStop.Enabled = False
        cmdMute.Enabled = False
        trcValume.Enabled = False
    End Sub

    Private Sub StreamCheck()
        Thread.Sleep(2000)

        Dim stream2 As Integer = Bass.BASS_ChannelIsActive(stream)
        Dim i As Integer = 1
        While i <> 0
            stream2 = Bass.BASS_ChannelIsActive(stream)
            If stream2 = 0 Then
                MsgBox("Remote user stopped stream")
                cmdStop.Enabled = False
                cmdMute.Enabled = False
                trcValume.Enabled = False
                cmdPlay.Enabled = True
                cmdStop.PerformClick()
                Bass.BASS_Free()
                i = 0
                stream2 = Bass.BASS_ChannelIsActive(stream)
            End If
            stream2 = Bass.BASS_ChannelIsActive(stream)

        End While
    End Sub

    Private Sub frmPlayAudioStreaming_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Bass.BASS_Free()
    End Sub

    Private Sub VisTimer_Tick(sender As System.Object, e As System.EventArgs) Handles VisTimer.Tick
        Dim SpectrumImage As Image
        SpectrumImage = New Bitmap(VisualisationBox.Width, VisualisationBox.Height)
        Dim SpectrumRectangle As New Rectangle(VisualisationBox.Location.X, VisualisationBox.Location.Y, VisualisationBox.Width, VisualisationBox.Height)

        Dim g As Graphics = Graphics.FromImage(SpectrumImage)

        If RadioButton1.Checked Then
            Drawing.CreateSpectrumBean(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, 5, False, False, True)
            VisualisationBox.Image = SpectrumImage
        ElseIf RadioButton2.Checked Then
            Drawing.CreateSpectrumDot(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, 10, 5, False, False, True)
            VisualisationBox.Image = SpectrumImage
        ElseIf RadioButton3.Checked Then
            Drawing.CreateSpectrum(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, False, False, True)
            VisualisationBox.Image = SpectrumImage

        ElseIf RadioButton4.Checked Then
            Drawing.CreateSpectrumEllipse(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, 5, 5, False, False, True)
            VisualisationBox.Image = SpectrumImage
        ElseIf RadioButton5.Checked Then
            Drawing.CreateSpectrumLine(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, 10, 1, False, False, True)
            VisualisationBox.Image = SpectrumImage

        ElseIf RadioButton6.Checked Then
            Drawing.CreateSpectrumLinePeak(stream, g, SpectrumRectangle, Color.Green, Color.Red, Color.BlueViolet, Color.Black, 5, 5, 1, 10, False, False, True)
            VisualisationBox.Image = SpectrumImage

        ElseIf RadioButton7.Checked Then
            Drawing.CreateSpectrumWave(stream, g, SpectrumRectangle, Color.Green, Color.Red, Color.Black, 10, False, False, True)
            VisualisationBox.Image = SpectrumImage

        ElseIf RadioButton8.Checked Then
            Drawing.CreateWaveForm(stream, g, SpectrumRectangle, Color.Green, Color.Red, Color.BlueViolet, Color.Black, 10, False, False, True)
            VisualisationBox.Image = SpectrumImage

            'ElseIf RadioButton9.Checked Then
            '    Drawing.CreateSpectrumText(stream, g, SpectrumRectangle, Color.Blue, Color.Red, Color.Black, "                 you playing stream from salem", False, False, True)
            '    VisualisationBox.Image = SpectrumImage

        End If

    End Sub
End Class