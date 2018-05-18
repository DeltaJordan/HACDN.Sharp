using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace HACDN.Sharp.Network
{
    public class WebClientHelper : WebClient
    {
        public X509CertificateCollection ClientCertificates { get; } = new X509CertificateCollection();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest contactUrl = base.GetWebRequest(address);
            if (contactUrl is HttpWebRequest)
            {
                HttpWebRequest wr = (HttpWebRequest)contactUrl;
                if (this.ClientCertificates != null && this.ClientCertificates.Count > 0)
                {
                    wr.ClientCertificates.AddRange(this.ClientCertificates);
                }
            }

            return contactUrl;
        }
    }
}

