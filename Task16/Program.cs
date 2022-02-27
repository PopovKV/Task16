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

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = "";
            string path = "D:/Курсы/2035_АВТОМАТИЗАЦИЯ BIM ПРОЕКТИРОВАНИЯ/Task16/Task16/bin/Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            const int n = 5;
            Good[] Good = new Good[n];

            for (int i = 0; i < n; i++)
            {
                Good good = new Good()
                {
                    GoodCode = Convert.ToInt32(Console.ReadLine()),
                    GoodName = Console.ReadLine(),
                    GoodPrice = Convert.ToDouble(Console.ReadLine())
                };
                Good[i] = good;
                jsonstring += JsonSerializer.Serialize(good, options) + "\n";
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(jsonstring);
            }

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
