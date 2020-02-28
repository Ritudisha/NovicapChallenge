using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Novicap
{
    public class Invoice
    {
        private static List<ProductConfigModel> CheckoutNewProductConfig(string jsonFile)
        {
            var content = File.ReadAllText(jsonFile);
            var jsonObject = JArray.Parse(content);
            return jsonObject.ToObject<List<ProductConfigModel>>();
        }

        public decimal GetInvoice(List<string> products, string productConfig)
        {
            
            var configs = CheckoutNewProductConfig(productConfig);
            
            var temp = products.Join(configs, x => x, x => x.Code, (product, config) => config)
                                    .GroupBy(x => x);
            if (products.Any(x => !temp.Any(y => y.Key.Code == x)))
                throw new Exception("One of more of the Product codes is or are invalid");

            var productRates = temp
                                    .Select(x => new { product = x.Key, count = x.Count() })
                                    .Select(x =>
                                    {
                                        try
                                        {
                                            switch (x.product.DiscountType)
                                            {
                                                case DiscountType.Type1:
                                                    var discountType1Object = x.product.DiscountObject.ToObject<Type1DiscountModel>();
                                                    return discountType1Object.GetAmount(x.product.Price, x.count);

                                                case DiscountType.Type2:
                                                    var discounType2tObject = x.product.DiscountObject.ToObject<Type2DiscountModel>();
                                                    return discounType2tObject.GetAmount(x.product.Price, x.count);

                                                case DiscountType.None:
                                                default:
                                                    return x.count * x.product.Price;
                                            }

                                        }
                                        catch
                                        {
                                            throw new Exception("Invalid Product config");
                                        }
                                    }).ToList();

            return productRates.Sum();
        }

    }
}
