using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeKassaMerchant
{
    public class FreeKassaResponse
    {
        public string MERCHANT_ID { get; set; }
        public string AMOUNT { get; set; }
        public string intid { get; set; }
        public string MERCHANT_ORDER_ID { get; set; }
        public string P_EMAIL { get; set; }
        public string P_PHONE { get; set; }
        public string CUR_ID { get; set; }
        public string SIGN { get; set; }
    }
}
