using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenter.Presentation.Models
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public DateTime access_date { get; set; }
    }
}