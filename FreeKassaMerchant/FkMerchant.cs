using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FreeKassaMerchant
{
    public class FkMerchant
    {
        /// <summary>
        /// Метод для FREE-KASSA.RU
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Secret1"></param>
        /// <returns></returns>
        public string GetSignatureRequest(FreeKassaRequestForm model, string Secret1)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(model.m + ":" + model.oa + ":" + Secret1 + ":" + model.o));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Метод для FREEKASSA.RU
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Secret1"></param>
        /// <returns></returns>
        public string GetSignatureRequest2(FreeKassaRequestForm model, string Secret1)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(model.m + ":" + model.oa + ":" + Secret1 + ":" + "RUB:" + model.o));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public string GetSignatureResponse(NameValueCollection nvc, string Secret2)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(nvc.Get("MERCHANT_ID") + ":" + nvc.Get("AMOUNT") + ":" + Secret2 + ":" + nvc.Get("MERCHANT_ORDER_ID")));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
