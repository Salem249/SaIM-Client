Imports Un4seen.Bass.Misc
Imports Un4seen.Bass
Imports System.Threading

Public Class frmStartAudioStreaming
    Private StreamTHD As Thread
    Private Stream As Integer
    Private length As Integer
   



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartStrreaming.Click
        If txtFileName.Text.Trim = "" Then
            MsgBox("You must choose file", MsgBoxStyle.OkOnly, "ERROR")
        Else
            Application.DoEvents()
          
            StreamTHD = New Thread(New ThreadStart(AddressOf send_Stream))
            StreamTHD.Start()


        End If
    End Sub

    Private Sub send_Stream()
        Dim eror As String = Nothing
        'Dim FrmLogin As frmLogin
        Dim strMountPoint As String = frmLogin.strLoginName

        If Un4seen.Bass.Bass.LoadMe() = False Then
            MsgBox(Un4seen.Bass.Bass.BASS_ErrorGetCode, MsgBoxStyle.OkOnly, "Error")
            statusBarStartStreaming.Text = "Error" & Un4seen.Bass.Bass.BASS_ErrorGetCode
            Exit Sub
        End If

        Un4seen.Bass.Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero, Nothing)

        Stream = Un4seen.Bass.Bass.BASS_StreamCreateFile(txtFileName.Text, 0, 0, BASSFlag.BASS_STREAM_DECODE)
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode

        If stream = 0 Then
            '' Stream = 0 error
            MsgBox("StreamCreatefileError" & Un4seen.Bass.Bass.BASS_ErrorGetCode, MsgBoxStyle.OkOnly, "Error")
            statusBarStartStreaming.Text = "Error" & Un4seen.Bass.Bass.BASS_ErrorGetCode
        End If

       

        Dim lame As New EncoderLAME(stream)
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode


        lame.InputFile = Nothing
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        lame.OutputFile = Nothing
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        lame.LAME_Bitrate = CInt(EncoderLAME.BITRATE.kbps_128)
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        lame.LAME_Mode = EncoderLAME.LAMEMode.Default
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        lame.LAME_TargetSampleRate = Int(EncoderLAME.SAMPLERATE.Hz_44100)
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode

        lame.LAME_Quality = EncoderLAME.LAMEQuality.Quality
        eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        'lame.Start(Nothing, IntPtr.Zero, False)
        'eror = Un4seen.Bass.Bass.BASS_ErrorGetCode
        If Not lame.Start(Nothing, IntPtr.Zero, False) Then
            MsgBox("LameStartError" & Un4seen.Bass.Bass.BASS_ErrorGetCode)
            statusBarStartStreaming.Text = "Error" & Un4seen.Bass.Bass.BASS_ErrorGetCode
        End If



        Dim icecast As New ICEcast(lame)
        icecast.ServerAddress = "127.0.0.1"
        icecast.ServerPort = 8000
        icecast.Username = "salem"
        icecast.Password = "icecast"
        icecast.MountPoint = "/" & frmLogin.strLoginName
        icecast.StreamName = frmLogin.strLoginName
        icecast.StreamGenre = frmLogin.strLoginName
        icecast.PublicFlag = True
        icecast.SongTitle = frmLogin.strLoginName

        If icecast.Connect() Then
            If icecast.Login() Then
                If icecast.IsConnected() Then
                    Dim m_BroadCast As New BroadCast(icecast)

                    m_BroadCast.AutoReconnect = True
                    m_BroadCast.ReconnectTimeout = 5

                    length = CInt(Un4seen.Bass.Bass.BASS_ChannelSeconds2Bytes(Stream, 5))
                    Dim data(length) As Byte
                    Dim length2 As Integer
                    statusBarStartStreaming.Text = "Stream started"
                    For x As Integer = 0 To length
                        length2 = Un4seen.Bass.Bass.BASS_ChannelGetData(Stream, data, length)
                    Next

                End If
            Else
                MsgBox("Error in login with streaming server", MsgBoxStyle.OkOnly, "error")
                statusBarStartStreaming.Text = "Error" & Un4seen.Bass.Bass.BASS_ErrorGetCode

            End If

        Else
            MsgBox("Error in conection with streaming server", MsgBoxStyle.OkOnly, "error")
            statusBarStartStreaming.Text = "Error" & Un4seen.Bass.Bass.BASS_ErrorGetCode

        End If
        Return
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFile.Click
        dlgOpenFile.ShowDialog()
        txtFileName.Text = dlgOpenFile.FileName
    End Sub

    Private Sub cmdStopStrreaming_Click(sender As System.Object, e As System.EventArgs) Handles cmdStopStrreaming.Click
        length = 0
        Bass.BASS_ChannelStop(Stream)
        Bass.BASS_Free()
        statusBarStartStreaming.Text = "Stream stoped"
    End Sub

    
End Class