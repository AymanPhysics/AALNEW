Imports System.IO
Imports System.Management
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text

Class MainWindow

    Private Sub StudentCode_TextChanged(sender As Object, e As TextChangedEventArgs) Handles Activation.TextChanged
        If Decrypt(Activation.Text).Substring(6) = ProtectionSerial() Then
            Try
                Try
                    Dim st As New StreamWriter("Activation.dll")
                    st.WriteLine(Activation.Text)
                    st.Flush()
                    st.Close()
                    st.Dispose()
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
            Window_Loaded(Nothing, Nothing)
        End If
    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim s As String = ""
        Try
            Dim st As New StreamReader("Activation.dll")
            s = Decrypt(st.ReadLine)
            st.Close()
            st.Dispose()
        Catch
        End Try


        If s.Length > 6 AndAlso s.Substring(6) = ProtectionSerial() Then

            Dim f As New Form2
            f.StudentCode = s.Substring(0, 6)
            f.url = Decrypt("Drp6g9rEhRtc+OM6a42WMPvsNhTwJ12M91UrF0T2sICAlX2zW+UNEzXHd8g2YP0C")
            f.Show()
            Close()
        Else
            Serial.Text = ProtectionSerial()
        End If



    End Sub


    Public Function ProtectionSerial() As String
        Return (Physics_BaseBoard() & Physics_processorId())
    End Function


    Public Function Physics_processorId() As String
        Dim s As String = ""
        Dim search As New ManagementObjectSearcher(New SelectQuery("Win32_processor"))
        For Each info As ManagementObject In search.Get()
            Try
                s &= info("processorId").ToString()
            Catch ex As Exception
            End Try
        Next
        Return s.ToUpper.Trim()
    End Function


    Public Function Physics_BaseBoard() As String
        Dim s As String = ""
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard")
        For Each wmi_HD As ManagementObject In searcher.Get()
            If wmi_HD("Product") <> Nothing Then
                s &= wmi_HD.Properties("Product").Value.ToString().Trim()
            End If
        Next
        searcher.Dispose()
        s = s.Split(".")(s.Split(".").Length - 1)
        Return s.ToUpper.Trim()
    End Function


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
End Class
