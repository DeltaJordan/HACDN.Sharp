Imports System.IO
Imports System.IO.File
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Security
Imports System.Security.Cryptography
Imports System.Net.Security
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Text

Public Class Form1
    ' Allow self-signed certificates
    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Function ConvertToASCIIUsingRegex(inputValue As String) As String
        Return Regex.Replace(inputValue, "[^\w ]", String.Empty)
    End Function
    Public Shared Function ByteArrayToString(ByVal ba As Byte()) As String
        Dim hex As StringBuilder = New StringBuilder(ba.Length * 2)
        For Each b As Byte In ba
            hex.AppendFormat("{0:x2}", b)
        Next

        Return hex.ToString()
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            ' Makes sure both boxes are filled
            If TextBox1.Text = "" Or ComboBox1.Text = "..." Then

                MsgBox("Please enter a title ID and select a region!")

            Else
RunScript:
                ' Enable the controls
                PictureBox1.Enabled = True
                RichTextBox1.Enabled = True
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                Label3.Enabled = True
                Label4.Enabled = True
                Label5.Enabled = True
                Label6.Enabled = True
                Label7.Enabled = True
                Label8.Enabled = True
                Button2.Enabled = True
                ' Send cert-signed HTTPS GET requests to shogun
                ' Force no certificate validation
                ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
                ' Define the "TID" variable as the text in TextBox1 (The title ID field)
                Dim TID As String = TextBox1.Text
                ' Define the "REG" variable as the region chosen from the combo box
                Dim REG As String = ComboBox1.Text
                ' Generate the ID pair URL based on inputs
                Dim GetIDPair As String = "https://bugyo.hac.lp1.eshop.nintendo.net/shogun/v1/contents/ids?shop_id=4&lang=en&country=" + REG + "&type=title&title_ids=" + TID
                ' Use the cert "ShopN.p12" with the password "shop"
                Dim Cert As New X509Certificate2("ShopN.p12", "shop")
                ' Create the web request
                Dim request As HttpWebRequest = WebRequest.Create(GetIDPair)
                ' Add the cert to the request
                request.ClientCertificates.Add(Cert)
                ' Get the response
                Dim response As HttpWebResponse = request.GetResponse
                ' Parse the response as a text stream
                Dim Rd As StreamReader = New StreamReader(response.GetResponseStream)
                ' Read the entire response
                Dim IDPair As String = Rd.ReadToEnd
                ' Return the NSU ID only and write it to Label3
                Label3.Text = IDPair.Substring(19, 14)
                ' Define the NSU ID as Label3's text
                Dim NSUID As String = Label3.Text
                ' Generate the JSON URL based on inputs
                Dim GetInfo As String = "https://bugyo.hac.lp1.eshop.nintendo.net/shogun/v1/titles/" + NSUID + "?shop_id=4&lang=en&country=" + REG
                ' Create the web request
                Dim request2 As HttpWebRequest = WebRequest.Create(GetInfo)
                ' Add the cert to the request
                request2.ClientCertificates.Add(Cert)
                ' Get the response
                Dim response2 As HttpWebResponse = request2.GetResponse
                ' Parse the response as a text stream
                Dim Rd2 As StreamReader = New StreamReader(response2.GetResponseStream)
                ' Read the entire response
                Dim Info As String = Rd2.ReadToEnd
                ' Parse the returned JSON
                Dim jResults As JObject = JObject.Parse(Info)
                ' Check to see if the title is public
                If jResults("public_status").ToString() = "public" Then
                    ' Gets the game name from the "formal_name" object
                    TextBox3.Text = jResults("formal_name").ToString()
                    ' Gets the description from the "description" object
                    RichTextBox1.Text = jResults("description").ToString()
                    ' Gets the release date from the "release_date_on_eshop" object
                    TextBox4.Text = jResults("release_date_on_eshop").ToString()
                    ' Gets the publisher name from the "name" field in the "publisher" object
                    TextBox5.Text = jResults("publisher")("name").ToString()
                    ' Generates a rip-ready name
                    TextBox2.Text = ConvertToASCIIUsingRegex(jResults("formal_name").ToString()) + " (" + jResults("release_date_on_eshop").ToString() + ")(" + jResults("publisher")("name").ToString() + ")[Switch]"
                    ' Gets the image ID from the "hero_banner_url" object
                    Dim IMGID As String = jResults("hero_banner_url").ToString()
                    ' Generate the full image URL.
                    Dim GetImg As String = "https://bugyo.hac.lp1.eshop.nintendo.net/" + IMGID + "?w=640"
                    ' Opens a request to the URL
                    Dim request3 As HttpWebRequest = WebRequest.Create(GetImg)
                    ' Add certificate to request
                    request3.ClientCertificates.Add(Cert)
                    ' Get the response
                    Dim response3 As HttpWebResponse = request3.GetResponse
                    ' Parse the response, reading as binary data
                    Dim Rd3 As BinaryReader = New BinaryReader(response3.GetResponseStream)
                    ' Save the image data as temp.jpg
                    WriteAllBytes("temp.jpg", Rd3.ReadBytes(8008135))
                    ' Display the saved image the picture box
                    PictureBox1.ImageLocation = "temp.jpg"
                    Try
                        ' If colours are defined, set form and controls to them
                        ' Read colours from the "dominant_colors" object
                        Dim GetBC = jResults("dominant_colors")(0).ToString()
                        Dim NewBC = ColorTranslator.FromHtml("#" + GetBC)
                        Dim GetFC = jResults("dominant_colors")(1).ToString()
                        Dim NewFC = ColorTranslator.FromHtml("#" + GetFC)
                        Dim GetSC = jResults("dominant_colors")(2).ToString()
                        Dim NewSC = ColorTranslator.FromHtml("#" + GetSC)
                        Me.BackColor = NewBC
                        Label1.ForeColor = NewFC
                        Label2.ForeColor = NewFC
                        Label3.ForeColor = NewFC
                        Label4.ForeColor = NewFC
                        Label5.ForeColor = NewFC
                        Label6.ForeColor = NewFC
                        Label7.ForeColor = NewFC
                        Label8.ForeColor = NewFC
                        Button1.ForeColor = NewFC
                        Button2.ForeColor = NewFC
                        TextBox1.ForeColor = NewFC
                        TextBox2.ForeColor = NewFC
                        TextBox3.ForeColor = NewFC
                        TextBox4.ForeColor = NewFC
                        TextBox5.ForeColor = NewFC
                        RichTextBox1.ForeColor = NewFC
                        ComboBox1.ForeColor = NewFC
                        TextBox1.BackColor = NewBC
                        TextBox2.BackColor = NewBC
                        TextBox3.BackColor = NewBC
                        TextBox4.BackColor = NewBC
                        TextBox5.BackColor = NewBC
                        RichTextBox1.BackColor = NewBC
                        Button1.BackColor = NewBC
                        Button2.BackColor = NewBC
                        ComboBox1.BackColor = NewBC

                    Catch NoColor As System.NullReferenceException
                        ' If there's a title with no colour, reset all to default
                        Me.BackColor = DefaultBackColor
                        Label1.ForeColor = DefaultForeColor
                        Label2.ForeColor = DefaultForeColor
                        Label3.ForeColor = DefaultForeColor
                        Label4.ForeColor = DefaultForeColor
                        Label5.ForeColor = DefaultForeColor
                        Label6.ForeColor = DefaultForeColor
                        Label7.ForeColor = DefaultForeColor
                        Label8.ForeColor = DefaultForeColor
                        Button1.ForeColor = DefaultForeColor
                        Button2.ForeColor = DefaultForeColor
                        TextBox1.ForeColor = DefaultForeColor
                        TextBox2.ForeColor = DefaultForeColor
                        TextBox3.ForeColor = DefaultForeColor
                        TextBox4.ForeColor = DefaultForeColor
                        TextBox5.ForeColor = DefaultForeColor
                        RichTextBox1.ForeColor = DefaultForeColor
                        ComboBox1.ForeColor = DefaultForeColor
                        TextBox1.BackColor = DefaultBackColor
                        TextBox2.BackColor = DefaultBackColor
                        TextBox3.BackColor = DefaultBackColor
                        TextBox4.BackColor = DefaultBackColor
                        TextBox5.BackColor = DefaultBackColor
                        RichTextBox1.BackColor = DefaultBackColor
                        Button1.BackColor = DefaultBackColor
                        Button2.BackColor = DefaultBackColor
                        ComboBox1.BackColor = DefaultBackColor
                    End Try

                Else
                    ' If it returns a non-public or cartridge-only title (e.g. Labo, Skylanders, etc.)
                    MsgBox("This title exists, but isn't listed on the eShop.")
                End If
            End If
        Catch ex As System.ArgumentOutOfRangeException
            Try
                ' If it detects an ID ending in "800", assume it's an update and replace it with "000"
                If TextBox1.Text.Substring(13, 3) = "800" Then
                    MsgBox("This is an update ID!" + vbNewLine + "Because I'm nice, I'll give you the base title ID." + vbNewLine + "BUT DON'T DO THIS AGAIN!!!")
                    TextBox1.Text = TextBox1.Text.Remove(13, 3)
                    TextBox1.AppendText("000")
                    GoTo RunScript
                    ' Assume 32-char string is a rights ID
                ElseIf TextBox1.TextLength = 32 Then
                    MsgBox("This is a rights ID!" + vbNewLine + "Because I'm nice, I'll give you the base title ID." + vbNewLine + "BUT DON'T DO THIS AGAIN!!!")
                    TextBox1.Text = TextBox1.Text.Remove(13, 19)
                    TextBox1.AppendText("000")
                    GoTo RunScript
                Else
                    MsgBox("Invalid input! Please check the title ID and region.")
                End If
            Catch idiot As System.ArgumentOutOfRangeException
                MsgBox("Invalid input! Please check the title ID and region.")
            End Try
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Checks to make sure the cert exists
        If File.Exists("ShopN.p12") Then
        Else
            MsgBox("Please put the eShop certificate (ShopN.p12) in this folder.")
            Close()
        End If
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Delete the temporary image when the program is closed
        File.Delete("temp.jpg")
    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If File.Exists("nx_tls_client_cert.pfx") Then
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim Cli As New X509Certificate2("nx_tls_client_cert.pfx", "switch")
            Dim Req1 As String = "https://tagaya.hac.lp1.eshop.nintendo.net/tagaya/hac_versionlist"
            Dim ree1 As HttpWebRequest = WebRequest.Create(Req1)
            ree1.ClientCertificates.Add(Cli)
            ree1.GetResponse()
            Dim TID As String = TextBox1.Text
            Dim Req2 As String = "https://superfly.hac.lp1.d4c.nintendo.net/v1/a/" + TID + "/dv"
            Dim ree2 As HttpWebRequest = WebRequest.Create(Req1)
            ree2.ClientCertificates.Add(Cli)
            ree2.GetResponse()
            Dim GetImg As String = "https://atumn.hac.lp1.d4c.nintendo.net/t/a/" + TID + "/0"
            Dim request4 As HttpWebRequest = WebRequest.Create(GetImg)
            request4.ClientCertificates.Add(Cli)
            Dim response4 As HttpWebResponse = request4.GetResponse
            Dim Rd4 As BinaryReader = New BinaryReader(response4.GetResponseStream)
            WriteAllBytes("0", Rd4.ReadBytes(response4.ContentLength))
            If File.Exists("keys.txt") Then
                Process.Start("hactool.exe", " -k keys.txt 0 --section0dir=CNMT")
                Thread.Sleep(5000)
                Dim OpenCNMT As New System.IO.BinaryReader(File.Open("CNMT/Application_" + TextBox1.Text + ".cnmt", FileMode.Open))
                Dim GetNCA As String = "https://atumn.hac.lp1.d4c.nintendo.net/c/c/" + ByteArrayToString(OpenCNMT.ReadBytes(496)).Substring(160, 32)
                Dim request5 As HttpWebRequest = WebRequest.Create(GetNCA)
                request5.ClientCertificates.Add(Cli)
                Dim response5 As HttpWebResponse = request5.GetResponse
                Dim Rd5 As BinaryReader = New BinaryReader(response5.GetResponseStream)
                System.IO.Directory.CreateDirectory("Games")
                System.IO.Directory.CreateDirectory("Games/" + ConvertToASCIIUsingRegex(TextBox3.Text))
                WriteAllBytes("Games/" + ConvertToASCIIUsingRegex(TextBox3.Text) + "/" + GetNCA.Substring(43, 32) + ".nca", Rd5.ReadBytes(response5.ContentLength))
                File.Delete("0")
                MsgBox("Successfully downloaded game NCA!")
            Else
                MsgBox("Unable to decrypt the CNMT, please make sure there is a filled keys.txt file present.")
            End If
        Else
                MsgBox("This function requires your console-unique client cert (nx_tls_client_cert.pfx), hactool and a filled keys.txt file.")
        End If

    End Sub
End Class