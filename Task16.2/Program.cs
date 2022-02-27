using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Task16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string e = "124125";
            double cost = 0;            
            string path = "D:/Курсы/2035_АВТОМАТИЗАЦИЯ BIM ПРОЕКТИРОВАНИЯ/Task16/Task16/bin/Products.json";
            const int n = 5;

            StreamReader sr = new StreamReader(path);
            
                for (int i = 0; i < n; i++)
                {                    
                    Good good = JsonSerializer.Deserialize<Good>(sr.ReadLine());
                    if (good.GoodPrice > cost)
                    {
                        cost = good.GoodPrice;
                        e = good.GoodName;
                    }
                }

            

            Console.WriteLine("Самый дорогой товар - {0}", e);
            Console.ReadKey();
        }
    }
    class Good
    {
        [JsonPropertyName("Код товара")]
        public int GoodCode { get; set; }
        [JsonPropertyName("Наименование")]
        public string GoodName { get; set; }
        [JsonPropertyName("Цена")]
        public double GoodPrice { get; set; }
    }
}
