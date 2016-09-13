Imports System.Globalization

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim firstSpace, secondSpace, currentPosition As Integer
        Dim server, port, user, password, filename, serverEditor As String
        Dim listOfServers As List(Of String) = New List(Of String)
        'filename = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Dropbox\Qviart\" & Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        filename = System.AppDomain.CurrentDomain.BaseDirectory() & Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        serverEditor = System.AppDomain.CurrentDomain.BaseDirectory() & "Server Editor Qviart Combo.exe"
        Dim rawData As String = New System.Net.WebClient().DownloadString("https://docs.google.com/document/d/1CiYpWvLGyro-lXRHABpFC1jgD4XeACmNhas6UTSH3AQ")
        currentPosition = InStr(1, rawData, "\nC: ") ' Find first server inside downloaded raw data

        For index As Integer = 0 To 7 'Change to 8 before release
            firstSpace = InStr(currentPosition, rawData, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, rawData, " ")
            server = Mid(rawData, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, rawData, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, rawData, " ")
            port = Mid(rawData, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, rawData, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, rawData, " ")
            user = Mid(rawData, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, rawData, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, rawData, "\n")
            password = Mid(rawData, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            listOfServers.Add(server)
            listOfServers.Add(port)
            listOfServers.Add(user)
            listOfServers.Add(password)
        Next

        Dim seqc As Process
        seqc = New Process()
        seqc = Process.Start(serverEditor)
        System.Threading.Thread.Sleep(2000) ' Launch the app and wait 0.500 sec to load
        AppActivate(seqc.Id) ' Set focus to the app
        My.Computer.Keyboard.SendKeys("~", True)
        System.Threading.Thread.Sleep(200)
        AppActivate(seqc.Id)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        For index = 0 To 7 'Change to 8 before release 
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("~", True)
            System.Threading.Thread.Sleep(200)
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("{DOWN}{TAB}", True)
            AppActivate(seqc.Id)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 0))
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 1))
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 2))
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 3))
            AppActivate(seqc.Id)
            My.Computer.Keyboard.SendKeys("^v{TAB}~", True)
            System.Threading.Thread.Sleep(500)
        Next
        AppActivate(seqc.Id)
        My.Computer.Keyboard.SendKeys("{TAB}{TAB}{TAB}~", True)
        System.Threading.Thread.Sleep(500)
        System.Windows.Forms.Clipboard.SetText(filename)
        AppActivate(seqc.Id)
        My.Computer.Keyboard.SendKeys("^v~", True)
        seqc.Kill()
        Close()
    End Sub

End Class
