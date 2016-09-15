Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '╔══════════╦════════════════════════════════════════════════╦═════════╦══════╗ 
        '║ FUNCTION ║ Form1_Load                                     ║ VERSION ║ 1.00 ║
        '╠══════════╩════════════════════════════════════════════════╩═════════╩══════╣
        '║ DESCRIPTION: Make a micro key press to avoid system lock                   ║
        '║ PARAMETERS: None                                                           ║
        '║ RETURNED VALUES: None                                                      ║
        '╚════════════════════════════════════════════════════════════════════════════╝
        Do
            My.Computer.Keyboard.SendKeys("{NUMLOCK}{NUMLOCK}", True)
            System.Threading.Thread.Sleep(60000)
        Loop
    End Sub
End Class
