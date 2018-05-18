using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HACDN.Sharp.Network;

namespace HACDN.Sharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();

            this.DragEnter += this.MainForm_DragEnter;
            this.DragDrop += this.MainForm_DragDrop;

            this.stripDownloadInfo.VisibleChanged += this.StripDownloadInfo_VisibleChanged;

            this.btnDownload.Click += this.BtnDownload_Click;

            this.tbTitleId.TextChanged += this.TbTitleId_TextChanged;

            this.stripDownloadInfo.Visible = false;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            int index = 0;
            while (index < data.Length)
            {
                this.tbDeviceId.Text = File.OpenText(data[index]).ReadToEnd().Substring(1347, 16);
                checked { ++index; }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            e.Effect = DragDropEffects.Copy;
        }


        private void Client_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.stripDownloadInfo.Visible = true;

            double bytesIn = Convert.ToDouble(e.BytesReceived);
            double asMiB = bytesIn / 1048576;
            double totalBytes = Convert.ToDouble(e.TotalBytesToReceive);
            double totalasMiB = totalBytes / 1048576;

            this.lblCurrentBytes.Text = asMiB > 1024 ? $"{bytesIn / 1073741824:##.##}GB" : $"{asMiB:##.#)}MB";
            this.lblTotalBytes.Text = totalasMiB > 1024 ? $"{totalBytes / 1073741824:##.##}GB" : $"{totalBytes:##.#}MB";
            
            int percentage = (int)(bytesIn / totalBytes * 100);

            this.pbDownloadProgress.Value = percentage;

            if (percentage == 100)
            {
                MessageBox.Show("Game downloaded successfully.");
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbDeviceId.Text == "")
                {
                    MessageBox.Show("You must input your device ID.");

                    return;
                }

                if (File.Exists("nx_tls_client_cert.pfx") && File.Exists("hactool.exe") && File.Exists("keys.txt"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
                    X509Certificate2 clientCert = new X509Certificate2("nx_tls_client_cert.pfx", "switch");

                    string titleId = this.tbTitleId.Text;
                    string version = this.tbVersion.Text;
                    string deviceId = this.tbDeviceId.Text;

                    string metaUrl = "https://atum.hac.lp1.d4c.nintendo.net/t/a/" + titleId + "/" + version;

                    HttpWebRequest getMetaNcaid = (HttpWebRequest)WebRequest.Create(metaUrl);
                    getMetaNcaid.ClientCertificates.Add(clientCert);
                    getMetaNcaid.Method = "HEAD";
                    getMetaNcaid.UserAgent = "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + deviceId + "; eid:lp1)";

                    string metaNcaurl;

                    using (HttpWebResponse parseMetaNcaid = (HttpWebResponse)getMetaNcaid.GetResponse())
                    {
                        metaNcaurl = "https://atum.hac.lp1.d4c.nintendo.net/c/a/" + parseMetaNcaid.GetResponseHeader("x-nintendo-content-id");
                    }

                    HttpWebRequest getMetaNca = (HttpWebRequest)WebRequest.Create(metaNcaurl);
                    getMetaNca.ClientCertificates.Add(clientCert);
                    getMetaNca.UserAgent = "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + deviceId + "; eid:lp1)";

                    using (HttpWebResponse parseMetaNca = (HttpWebResponse)getMetaNca.GetResponse())
                    {
                        Stream responseStream = parseMetaNca.GetResponseStream();

                        if (responseStream == null)
                        {
                            MessageBox.Show("Failed to get response stream from NCA.");
                            return;
                        }

                        using (responseStream)
                        using (BinaryReader metaNca = new BinaryReader(responseStream))
                        {
                            File.WriteAllBytes(version, metaNca.ReadBytes(100000));
                        }
                    }

                    Process.Start("hactool.exe", " -k keys.txt " + version + " --section0dir=CNMT");

                    while (!File.Exists("CNMT/Application_" + titleId + ".cnmt"))
                    {
                        using (BinaryReader openCnmt = new BinaryReader(File.Open("CNMT/Application_" + titleId + ".cnmt", FileMode.Open)))
                        {
                            string ncaid = ByteArrayToString(openCnmt.ReadBytes(194)).Substring(160, 32);
                            string ncaurl = "https://atum.hac.lp1.d4c.nintendo.net/c/c/" + ncaid;

                            using (WebClientHelper getNca = new WebClientHelper())
                            {
                                getNca.ClientCertificates.Add(clientCert);
                                getNca.Headers.Set("User-Agent", "NintendoSDK Firmware/5.0.2-0 (platform:NX; did:" + deviceId + "; eid:lp1)");
                                Uri adr = new Uri(ncaurl);
                                Directory.CreateDirectory("Games/" + titleId);
                                getNca.DownloadProgressChanged += this.Client_ProgressChanged;
                                getNca.DownloadFileTaskAsync(adr, "Games/" + titleId + "/" + ncaid + ".nca");
                                File.Delete(version);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This function requires your console-unique client cert (nx_tls_client_cert.pfx), hactool and a filled keys.txt file.");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Invalid title ID.");
            }
        }

        private void TbTitleId_TextChanged(object sender, EventArgs e)
        {
            this.tbVersion.Enabled = this.tbDeviceId.Text.Length >= 16 && this.tbTitleId.Text.Substring(13, 3) == "800";
        }

        private void StripDownloadInfo_VisibleChanged(object sender, EventArgs e)
        {
            this.Height = this.stripDownloadInfo.Visible ? this.stripDownloadInfo.Height + 95 : 95;
        }

        private static bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static string ByteArrayToString(byte[] byteIn)
        {
            StringBuilder hexIn = new StringBuilder(byteIn.Length * 2);
            foreach (byte byteVal in byteIn)
            {
                hexIn.AppendFormat("{0:x2}", byteVal);
            }

            return hexIn.ToString();
        }
    }
}

