
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.Integration
Imports System.Windows.Threading
Imports jsreport.Types
Imports Microsoft.Web.WebView2.Core

Class Form2

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public StudentCode As String
    Public url As String

    WithEvents t As New DispatcherTimer With {.Interval = New TimeSpan(0, 0, 0, 2), .IsEnabled = True}

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SetWindowDisplayAffinity(ByVal hWnd As IntPtr, ByVal dwAffinity As UInteger) As UInteger
    End Function

    Private Function AlwaysGoodCertificate() As Object
        Return True
    End Function


    Dim frm As New MSG
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ServicePointManager.Expect100Continue = True
        ServicePointManager.DefaultConnectionLimit = 9999
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3

        SetWindowDisplayAffinity(New Interop.WindowInteropHelper(Me).Handle, 1)

        AddHandler webView.KeyDown, AddressOf webView_KeyDown

        webView.Source = New Uri(url)

        AddHandler frm.Closed, AddressOf frm_Closed
        frm.lblName.Content = StudentCode
        frm.ResizeMode = ResizeMode.NoResize
        frm.WindowStartupLocation = WindowStartupLocation.Manual
        frm.Topmost = True
        frm.ShowInTaskbar = False
        frm.ShowActivated = True
        frm.Show()


        AddHandler t.Tick, AddressOf t_tick
    End Sub

    Private Sub webView_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.Key = System.Windows.Input.Key.LeftAlt OrElse e.Key = System.Windows.Input.Key.RightAlt) Then
            e.Handled = True
            Forms.SendKeys.SendWait("%")
        End If
    End Sub

    Private Sub t_tick(sender As Object, e As EventArgs)
        Dim h As Double = ActualHeight
        Dim w As Double = ActualWidth
        Dim r As Double = Rnd()
        Dim r2 As Double = Rnd()

        frm.Left = w * r
        frm.Top = h * r2

    End Sub

    Public Function Decrypt(ByVal cipherText As String) As String

        Dim passPhrase As String
        Dim saltValue As String
        Dim hashAlgorithm As String
        Dim passwordIterations As Integer
        Dim initVector As String
        Dim keySize As Integer
        passPhrase = "Education"        ' can be any string
        saltValue = "Phy123!@#)(*098"        ' can be any string
        hashAlgorithm = "SHA1"             ' can be "MD5"
        passwordIterations = 55                  ' can be any number
        initVector = "@1B2h**&^%F^5421" ' must be 16 bytes
        keySize = 256                ' can be 192 or 128


        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(cipherText)
        Dim password As PasswordDeriveBytes
        password = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte()
        keyBytes = password.GetBytes(keySize / 8)
        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform
        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream(cipherTextBytes)
        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)
        Dim decryptedByteCount As Integer
        decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        memoryStream.Close()
        cryptoStream.Close()
        Return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

    End Function

    Dim IsClosing As Boolean = False
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        IsClosing = True
        frm.Close()
    End Sub
    Private Sub frm_Closed(sender As Object, e As EventArgs)
        If Not IsClosing Then Close()
    End Sub

    Private Async Sub webView_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles webView.CoreWebView2InitializationCompleted
        If webView.CoreWebView2 Is Nothing Then Return

        InitializeBrowser()

        With webView.CoreWebView2.Settings
            .AreDefaultContextMenusEnabled = False
            .AreDevToolsEnabled = False
            .IsStatusBarEnabled = False
            AddHandler webView.CoreWebView2.NewWindowRequested, AddressOf CoreWebView2_NewWindowRequested
        End With
    End Sub


    Private Async Sub InitializeBrowser()
        If webView.CoreWebView2 Is Nothing Then Return
        With webView.CoreWebView2.Environment
            Dim tempPath As String = System.IO.Path.GetTempPath()
            Dim webView2Environment = Await CoreWebView2Environment.CreateAsync(Nothing, tempPath)
            Await webView.EnsureCoreWebView2Async(webView2Environment)
            webView.Source = New Uri(url)
        End With

    End Sub

    Private Sub CoreWebView2_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs)
        e.NewWindow = webView.CoreWebView2
    End Sub

    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.LeftAlt OrElse e.Key = Key.RightAlt OrElse e.Key = Key.LeftCtrl OrElse e.Key = Key.RightCtrl Then
            e.Handled = True
        End If
    End Sub

    Private Sub Window_PreviewKeyDown(sender As Object, e As KeyEventArgs)
        If e.SystemKey = Key.LeftAlt OrElse e.SystemKey = Key.RightAlt OrElse e.SystemKey = Key.LeftCtrl OrElse e.SystemKey = Key.RightCtrl Then
            e.Handled = True
        End If
    End Sub

    Private Sub Window_PreviewMouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        e.Handled = True
    End Sub

    Private Sub Window_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        e.Handled = True
    End Sub
End Class
