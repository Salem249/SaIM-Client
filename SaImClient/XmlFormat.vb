

Public Class XmlFormat
    Private strXml As String
    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    'overloaded constructor
    Public Sub New(strType As String, param As String())
        strXml = "<?xml version='1.0' encoding='utf-8'?><InstantMessenger>"

        If strType.ToUpper().CompareTo("AUTH") = 0 Then
            AuthXML(param)
        ElseIf strType.ToUpper().CompareTo("MSG") = 0 Then
            MessageXML(param)
        ElseIf strType.ToUpper().CompareTo("ADDFRIEND") = 0 Then
            AddFriendXML(param)
        ElseIf strType.ToUpper().CompareTo("DELETEFRIEND") = 0 Then
            DeleteFriendXML(param)
        ElseIf strType.ToUpper().CompareTo("ACCEPTFRIEND") = 0 Then
            AcceptFriendXML(param)
        ElseIf strType.ToUpper().CompareTo("UNSUBSCRIBEFRIEND") = 0 Then
            UnsubscribeFriendXML(param)
        ElseIf strType.ToUpper().CompareTo("QUIT") = 0 Then
            QuitXML(param)
        End If

        strXml += "</InstantMessenger>"
    End Sub

    Private Sub AuthXML(param As [String]())
        strXml += "<Auth>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "<Password>" & param(1) & "</Password>"
        strXml += "</Auth>"
    End Sub

    Private Sub QuitXML(param As [String]())
        strXml += "<Quit>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "</Quit>"
    End Sub

    Private Sub MessageXML(param As [String]())
        strXml += "<MSG>"
        strXml += "<Target>" & param(0) & "</Target>"
        strXml += "<Source>" & param(1) & "</Source>"
        strXml += "<Text>" & param(2) & "</Text>"
        strXml += "</MSG>"
    End Sub

    Private Sub AddFriendXML(param As [String]())
        strXml += "<AddFriend>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "<FriendName>" & param(1) & "</FriendName>"
        strXml += "</AddFriend>"
    End Sub

    Private Sub DeleteFriendXML(param As [String]())
        strXml += "<DeleteFriend>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "<FriendName>" & param(1) & "</FriendName>"
        strXml += "</DeleteFriend>"
    End Sub

    Private Sub AcceptFriendXML(param As [String]())
        strXml += "<AcceptFriend>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "<FriendName>" & param(1) & "</FriendName>"
        strXml += "<Status>" & param(2) & "</Status>"
        strXml += "</AcceptFriend>"
    End Sub

    Private Sub UnsubscribeFriendXML(param As [String]())
        strXml += "<UnsubscribeFriend>"
        strXml += "<UserName>" & param(0) & "</UserName>"
        strXml += "<FriendName>" & param(1) & "</FriendName>"
        strXml += "</UnsubscribeFriend>"
    End Sub

    Public Function GetXml() As String
        Return strXml
    End Function
End Class
