using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OtpVerification
{
    public class OtpVia
    {
        public string Code { get; set; }
        public string Url { get; set; }

        public OtpVia( string code, string url = default ) {
            Code = code;
            Url = url;
        }
        public override string ToString()
        {
            return $"Code:{Code},Url:{Url}";
        }
    }
}
