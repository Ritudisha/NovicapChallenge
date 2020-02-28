using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Novicap
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice();
            var directory = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var jsonPath = directory + @"\Novicap\ProductConfig.json";
            Console.WriteLine("Your Total Amount is : " + invoice.GetInvoice(args.ToList(), jsonPath));
        }
    }
}
