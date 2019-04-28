Imports System.Net.Sockets

Public Class sckClient
    Inherits System.Net.Sockets.TcpClient
    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    ' this function will return the connection status
    ' of socket by using protected prpoperty Active.
    Public Function IsConnected() As Boolean
        Return MyBase.Active
    End Function
End Class
