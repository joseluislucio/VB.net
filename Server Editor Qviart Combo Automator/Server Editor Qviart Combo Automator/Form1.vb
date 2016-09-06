Imports System.Globalization

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim firstSpace, secondSpace, currentPosition As Integer
        Dim server, port, user, password, filename As String
        Dim listOfServers As List(Of String) = New List(Of String)

        currentPosition = 1
        '        filename = "C:\Users\lucijose\Dropbox\Qviart\" & Date.Today.Year & Date.Today.Month & Date.Today.Day
        filename = "C:\Users\lucijose\Dropbox\Qviart\" & Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)



        Dim cccam As String = New System.Net.WebClient().DownloadString("https://docs.google.com/document/d/1CiYpWvLGyro-lXRHABpFC1jgD4XeACmNhas6UTSH3AQ")

        currentPosition = InStr(1, cccam, "\nC: ")
        For index As Integer = 1 To 9
            firstSpace = InStr(currentPosition, cccam, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, cccam, " ")
            server = Mid(cccam, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, cccam, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, cccam, " ")
            port = Mid(cccam, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, cccam, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, cccam, " ")
            user = Mid(cccam, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            firstSpace = InStr(currentPosition, cccam, " ")
            currentPosition = firstSpace + 1
            secondSpace = InStr(currentPosition, cccam, "C:") - 2
            password = Mid(cccam, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            listOfServers.Add(server)
            listOfServers.Add(port)
            listOfServers.Add(user)
            listOfServers.Add(password)
        Next

        Dim seqc As Process
        seqc = New Process()
        seqc = Process.Start("C:\seqc\seqc.exe")
        System.Threading.Thread.Sleep(500) ' Wait 1 sec and hit enter on main screen
        AppActivate(seqc.Id)

        My.Computer.Keyboard.SendKeys("~", True)
        System.Threading.Thread.Sleep(200)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        For index = 0 To 8

            My.Computer.Keyboard.SendKeys("~", True)
            System.Threading.Thread.Sleep(200)
            My.Computer.Keyboard.SendKeys("{DOWN}", True)
            My.Computer.Keyboard.SendKeys("{TAB}", True)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 0))
            My.Computer.Keyboard.SendKeys("^v", True)
            My.Computer.Keyboard.SendKeys("{TAB}", True)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 1))
            My.Computer.Keyboard.SendKeys("^v", True)
            My.Computer.Keyboard.SendKeys("{TAB}", True)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 2))
            My.Computer.Keyboard.SendKeys("^v", True)
            My.Computer.Keyboard.SendKeys("{TAB}", True)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 3))
            My.Computer.Keyboard.SendKeys("^v", True)
            My.Computer.Keyboard.SendKeys("{TAB}", True)
            My.Computer.Keyboard.SendKeys("~", True)
            System.Threading.Thread.Sleep(500)
        Next
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("~", True)
        System.Threading.Thread.Sleep(500)
        System.Windows.Forms.Clipboard.SetText(filename)
        My.Computer.Keyboard.SendKeys("^v", True)
        My.Computer.Keyboard.SendKeys("~", True)
        seqc.Kill()
        Close()
    End Sub
End Class
