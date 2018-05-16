Imports System.IO
Imports System.IO.File
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports System.Text
Public Class Form1
    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Function ConvertToASCIIUsingRegex(inputValue As String) As String
        Return Regex.Replace(inputValue, "[^\w ]", String.Empty)
    End Function
    Public Shared Function ByteArrayToString(ByVal ByteIn As Byte()) As String
        Dim HexIn As StringBuilder = New StringBuilder(ByteIn.Length * 2)
        For Each ByteVal As Byte In ByteIn
            HexIn.AppendFormat("{0:x2}", ByteVal)
        Next
        Return HexIn.ToString()
    End Function
    Public Class WebClient2
        Inherits System.Net.WebClient

        Private _ClientCertificates As New System.Security.Cryptography.X509Certificates.X509CertificateCollection
        Public ReadOnly Property ClientCertificates() As System.Security.Cryptography.X509Certificates.X509CertificateCollection
            Get
                Return Me._ClientCertificates
            End Get
        End Property
        Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
            Dim ContactURL = MyBase.GetWebRequest(address)
            If TypeOf ContactURL Is HttpWebRequest Then
                Dim WR = DirectCast(ContactURL, HttpWebRequest)
                If Me._ClientCertificates IsNot Nothing AndAlso Me._ClientCertificates.Count > 0 Then
                    WR.ClientCertificates.AddRange(Me._ClientCertificates)
                End If
            End If
            Return ContactURL
        End Function
    End Class
    Public Sub Client_ProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        Status_Bar.Visible = True
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim asMiB As Double = bytesIn / 1048576
        Dim asGiB As Double = bytesIn / 1073741824
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim totalasMiB As Double = totalBytes / 1048576
        Dim totalasGiB As Double = totalBytes / 1073741824
        Dim percentage As Double = bytesIn / totalBytes * 100
        If asMiB > 1024 Then
            AmountDownloaded.Text = Format$(asGiB, "0.00") + "GB"
        Else
            AmountDownloaded.Text = Format$(asMiB, "0.0") + "MB"
        End If
        If totalasMiB > 1024 Then
            TotalFileSize.Text = Format$(totalasGiB, "0.00") + "GB"
        Else
            TotalFileSize.Text = Format$(totalasMiB, "0.0") + "MB"
        End If
        PercentDownloaded.Text = Format$(percentage, "0.0") + "% done"
        If percentage = 100 Then
            MsgBox("Game downloaded successfully.")
        End If
    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        Try
            If DID_Input.Text = "" Then
                MsgBox("You must input your device ID.")
            Else
                If Exists("nx_tls_client_cert.pfx") = True AndAlso Exists("hactool.exe") = True AndAlso Exists("keys.txt") = True Then
                    ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
                    Dim ClientCert As New X509Certificate2("nx_tls_client_cert.pfx", "switch")
                    Dim TID As String = TitleID_Input.Text
                    Dim VER As String = Version_Input.Text
                    Dim DID As String = DID_Input.Text
                    Dim MetaURL As String = "https://atum.hac.lp1.d4c.nintendo.net/t/a/" + TID + "/" + VER
                    Dim GetMetaNCAID As HttpWebRequest = WebRequest.Create(MetaURL)
                    GetMetaNCAID.ClientCertificates.Add(ClientCert)
                    GetMetaNCAID.Method = "HEAD"
                    GetMetaNCAID.UserAgent = "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + DID + "; eid:lp1)"
                    Dim ParseMetaNCAID As HttpWebResponse = GetMetaNCAID.GetResponse
                    Dim MetaNCAURL As String = "https://atum.hac.lp1.d4c.nintendo.net/c/a/" + ParseMetaNCAID.GetResponseHeader("x-nintendo-content-id")
                    Dim GetMetaNCA As HttpWebRequest = WebRequest.Create(MetaNCAURL)
                    GetMetaNCA.ClientCertificates.Add(ClientCert)
                    GetMetaNCA.UserAgent = "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + DID + "; eid:lp1)"
                    Dim ParseMetaNCA As HttpWebResponse = GetMetaNCA.GetResponse
                    Dim MetaNCA As BinaryReader = New BinaryReader(ParseMetaNCA.GetResponseStream)
                    WriteAllBytes(VER, MetaNCA.ReadBytes(100000))
                    Process.Start("hactool.exe", " -k keys.txt " + VER + " --section0dir=CNMT")
CheckCMNT:
                    If Exists("CNMT/Application_" + TID + ".cnmt") Then
                        Dim OpenCNMT As New System.IO.BinaryReader(File.Open("CNMT/Application_" + TID + ".cnmt", FileMode.Open))
                        Dim NCAID As String = ByteArrayToString(OpenCNMT.ReadBytes(194)).Substring(160, 32)
                        Dim NCAURL As String = "https://atum.hac.lp1.d4c.nintendo.net/c/c/" + NCAID
                        Dim GetNCA As New WebClient2
                        GetNCA.ClientCertificates.Add(ClientCert)
                        GetNCA.Headers.Set("User-Agent", "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + DID + "; eid:lp1)")
                        Dim Adr As New Uri(NCAURL)
                        System.IO.Directory.CreateDirectory("Games/" + TID)
                        AddHandler GetNCA.DownloadProgressChanged, AddressOf Client_ProgressChanged
                        GetNCA.DownloadFileTaskAsync(Adr, ("Games/" + TID + "/" + NCAID + ".nca"))
                        Delete(VER)
                    Else
                        GoTo CheckCMNT
                    End If
                Else
                    MsgBox("This function requires your console-unique client cert (nx_tls_client_cert.pfx), hactool and a filled keys.txt file.")
                End If
            End If

        Catch ex As WebException
            MsgBox("Invalid title ID.")
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TitleID_Input.TextChanged
        Try
            If TitleID_Input.Text.Substring(13, 3) = "800" Then
                Version_Input.Enabled = True
                Version_Label.Enabled = True
            Else
                Version_Input.Enabled = False
                Version_Label.Enabled = False
            End If
        Catch Input As ArgumentOutOfRangeException
        End Try
    End Sub
End Class