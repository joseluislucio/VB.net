Imports System.Globalization

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim firstSpace, secondSpace, currentPosition As Integer
        Dim server, port, user, password, filename As String
        Dim listOfServers As List(Of String) = New List(Of String)

        filename = "C:\Users\pepo\Dropbox\Qviart\" & Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        Dim rawData As String = New System.Net.WebClient().DownloadString("https://docs.google.com/document/d/1CiYpWvLGyro-lXRHABpFC1jgD4XeACmNhas6UTSH3AQ")
        currentPosition = InStr(1, rawData, "\nC: ") ' Find first server inside downloaded raw data
        For index As Integer = 1 To 9
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
            secondSpace = InStr(currentPosition, rawData, "C:") - 2
            password = Mid(rawData, firstSpace + 1, (secondSpace - firstSpace - 1))
            currentPosition = secondSpace
            listOfServers.Add(server)
            listOfServers.Add(port)
            listOfServers.Add(user)
            listOfServers.Add(password)
        Next

        Dim seqc As Process
        seqc = New Process()
        'seqc = Process.Start("C:\seqc\seqc.exe")
        seqc = Process.Start("C:\Utils\Server Editor\Server Editor.exe")
        System.Threading.Thread.Sleep(500) ' Launch the app and wait 0.500 sec to load
        AppActivate(seqc.Id) ' Set focus to the app
        My.Computer.Keyboard.SendKeys("~", True)
        System.Threading.Thread.Sleep(200)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        For index = 0 To 8
            My.Computer.Keyboard.SendKeys("~", True)
            System.Threading.Thread.Sleep(200)
            My.Computer.Keyboard.SendKeys("{DOWN}{TAB}", True)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 0))
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 1))
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 2))
            My.Computer.Keyboard.SendKeys("^v{TAB}", True)
            System.Threading.Thread.Sleep(100)
            System.Windows.Forms.Clipboard.SetText(listOfServers.ElementAt(index * 4 + 3))
            My.Computer.Keyboard.SendKeys("^v{TAB}~", True)

            System.Threading.Thread.Sleep(500)
        Next
        My.Computer.Keyboard.SendKeys("{TAB}{TAB}{TAB}~", True)
        System.Threading.Thread.Sleep(500)
        System.Windows.Forms.Clipboard.SetText(filename)
        My.Computer.Keyboard.SendKeys("^v~", True)
        seqc.Kill()
        Close()
    End Sub

End Class
