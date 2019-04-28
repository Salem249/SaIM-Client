<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Friends", 5, 5)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.treeFriendList = New System.Windows.Forms.TreeView()
        Me.contextMenuIM = New System.Windows.Forms.ContextMenu()
        Me.menuAddFriend = New System.Windows.Forms.MenuItem()
        Me.menuSendMsg = New System.Windows.Forms.MenuItem()
        Me.menuDelFriend = New System.Windows.Forms.MenuItem()
        Me.menuPlayStream = New System.Windows.Forms.MenuItem()
        Me.imageListClient = New System.Windows.Forms.ImageList(Me.components)
        Me.statusBarClient = New System.Windows.Forms.StatusBar()
        Me.timerIM = New System.Windows.Forms.Timer(Me.components)
        Me.mainMenuIM = New System.Windows.Forms.MainMenu(Me.components)
        Me.menuLogin = New System.Windows.Forms.MenuItem()
        Me.menuSignIn = New System.Windows.Forms.MenuItem()
        Me.MenuStartAudioStreaming = New System.Windows.Forms.MenuItem()
        Me.menuFriends = New System.Windows.Forms.MenuItem()
        Me.menuAdd = New System.Windows.Forms.MenuItem()
        Me.menuDel = New System.Windows.Forms.MenuItem()
        Me.menuHelp = New System.Windows.Forms.MenuItem()
        Me.menuAbout = New System.Windows.Forms.MenuItem()
        Me.menuSend = New System.Windows.Forms.MenuItem()
        Me.menuMessage = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'treeFriendList
        '
        Me.treeFriendList.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.treeFriendList.ContextMenu = Me.contextMenuIM
        Me.treeFriendList.ImageIndex = 0
        Me.treeFriendList.ImageList = Me.imageListClient
        Me.treeFriendList.Location = New System.Drawing.Point(-6, 2)
        Me.treeFriendList.Name = "treeFriendList"
        TreeNode1.ImageIndex = 5
        TreeNode1.Name = ""
        TreeNode1.SelectedImageIndex = 5
        TreeNode1.Text = "Friends"
        Me.treeFriendList.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.treeFriendList.SelectedImageIndex = 0
        Me.treeFriendList.Size = New System.Drawing.Size(192, 192)
        Me.treeFriendList.TabIndex = 2
        '
        'contextMenuIM
        '
        Me.contextMenuIM.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAddFriend, Me.menuSendMsg, Me.menuDelFriend, Me.menuPlayStream})
        '
        'menuAddFriend
        '
        Me.menuAddFriend.Index = 0
        Me.menuAddFriend.Text = "&Add Friend"
        '
        'menuSendMsg
        '
        Me.menuSendMsg.Index = 1
        Me.menuSendMsg.Text = "&Send Message"
        '
        'menuDelFriend
        '
        Me.menuDelFriend.Index = 2
        Me.menuDelFriend.Text = "&Delete Friend"
        '
        'menuPlayStream
        '
        Me.menuPlayStream.Index = 3
        Me.menuPlayStream.Text = "&Play Stream"
        '
        'imageListClient
        '
        Me.imageListClient.ImageStream = CType(resources.GetObject("imageListClient.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageListClient.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListClient.Images.SetKeyName(0, "Msn_Buddy-Away.ico")
        Me.imageListClient.Images.SetKeyName(1, "Msn_Buddy-1min..ico")
        Me.imageListClient.Images.SetKeyName(2, "Msn_Buddy.ico")
        Me.imageListClient.Images.SetKeyName(3, "Msn_Buddy-Offline.ico")
        Me.imageListClient.Images.SetKeyName(4, "Msn_Buddy-Busy.ico")
        Me.imageListClient.Images.SetKeyName(5, "Msn_Messenger-2.ico")
        Me.imageListClient.Images.SetKeyName(6, "Msn_Buddy-mobile.ico")
        Me.imageListClient.Images.SetKeyName(7, "Msn_Buddy-web.ico")
        Me.imageListClient.Images.SetKeyName(8, "Msn_Butterfly.ico")
        Me.imageListClient.Images.SetKeyName(9, "Msn_Messenger.ico")
        Me.imageListClient.Images.SetKeyName(10, "Msn_Buddy-WaiteConfirm.png")
        '
        'statusBarClient
        '
        Me.statusBarClient.Location = New System.Drawing.Point(0, -16)
        Me.statusBarClient.Name = "statusBarClient"
        Me.statusBarClient.Size = New System.Drawing.Size(208, 16)
        Me.statusBarClient.TabIndex = 4
        '
        'timerIM
        '
        Me.timerIM.Enabled = True
        Me.timerIM.Interval = 200
        '
        'mainMenuIM
        '
        Me.mainMenuIM.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLogin, Me.menuFriends, Me.menuHelp})
        '
        'menuLogin
        '
        Me.menuLogin.Index = 0
        Me.menuLogin.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSignIn, Me.MenuStartAudioStreaming})
        Me.menuLogin.Text = "&Login"
        '
        'menuSignIn
        '
        Me.menuSignIn.Index = 0
        Me.menuSignIn.Text = "&Sign in"
        '
        'MenuStartAudioStreaming
        '
        Me.MenuStartAudioStreaming.Index = 1
        Me.MenuStartAudioStreaming.Text = "&Start Audio streaming"
        '
        'menuFriends
        '
        Me.menuFriends.Index = 1
        Me.menuFriends.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAdd, Me.menuDel})
        Me.menuFriends.Text = "&Friends"
        '
        'menuAdd
        '
        Me.menuAdd.Index = 0
        Me.menuAdd.Text = "&Add Friend"
        '
        'menuDel
        '
        Me.menuDel.Index = 1
        Me.menuDel.Text = "&Del Friend"
        '
        'menuHelp
        '
        Me.menuHelp.Index = 2
        Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAbout})
        Me.menuHelp.Text = "&Help"
        '
        'menuAbout
        '
        Me.menuAbout.Index = 0
        Me.menuAbout.Text = "&About"
        '
        'menuSend
        '
        Me.menuSend.Index = 0
        Me.menuSend.Text = "&Send Message"
        '
        'menuMessage
        '
        Me.menuMessage.Index = -1
        Me.menuMessage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSend})
        Me.menuMessage.Text = "&Message"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(208, 0)
        Me.Controls.Add(Me.treeFriendList)
        Me.Controls.Add(Me.statusBarClient)
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenuIM
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SaIM"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents treeFriendList As System.Windows.Forms.TreeView
    Friend WithEvents statusBarClient As System.Windows.Forms.StatusBar
    Friend WithEvents contextMenuIM As System.Windows.Forms.ContextMenu
    Friend WithEvents menuAddFriend As System.Windows.Forms.MenuItem
    Friend WithEvents menuSendMsg As System.Windows.Forms.MenuItem
    Friend WithEvents menuDelFriend As System.Windows.Forms.MenuItem
    Friend WithEvents imageListClient As System.Windows.Forms.ImageList
    Friend WithEvents timerIM As System.Windows.Forms.Timer
    Friend WithEvents mainMenuIM As System.Windows.Forms.MainMenu
    Friend WithEvents menuLogin As System.Windows.Forms.MenuItem
    Friend WithEvents menuSignIn As System.Windows.Forms.MenuItem
    Friend WithEvents menuFriends As System.Windows.Forms.MenuItem
    Friend WithEvents menuAdd As System.Windows.Forms.MenuItem
    Friend WithEvents menuDel As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents menuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents menuSend As System.Windows.Forms.MenuItem
    Friend WithEvents menuMessage As System.Windows.Forms.MenuItem
    Friend WithEvents MenuStartAudioStreaming As System.Windows.Forms.MenuItem
    Friend WithEvents menuPlayStream As System.Windows.Forms.MenuItem

End Class
