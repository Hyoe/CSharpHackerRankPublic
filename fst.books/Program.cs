using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fst.books
{

    /// <summary>
    /// Objective: fetch and display all of J.K. Rowling's books using google books api
    /// google books documentation - https://developers.google.com/books/docs/v1/using#WorkingVolumes 
    /// 
    /// Instructions:
    /// Create a C# Class to deserialize the json into
    /// Send a request to google books api search for J.K. Rowling as the author
    /// print out to the console each book's:
    ///     -title
    ///     -number of pages
    ///     -if it is epublished
    ///     -its average rating 
    /// 
    /// </summary>
    class Program
    {
        public class Rootobject
        {
            public Item[] items { get; set; }
        }

        public class Item
        {
            public Volumeinfo volumeInfo { get; set; }
            public Accessinfo accessInfo { get; set; }
        }

        public class Volumeinfo
        {
            public string title { get; set; }
            public int pageCount { get; set; }
            public float averageRating { get; set; }
        }

        public class Accessinfo
        {
            public Epub epub { get; set; }
        }

        public class Epub
        {
            public bool isAvailable { get; set; }
        }


        static async Task<string> GetBooksTask(string uri)
        {
            string result = string.Empty;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Task<string> responseContent = response.Content.ReadAsStringAsync();
                    result = await responseContent;
                }
            }
            return result;
        }

        static Rootobject DeserializeData(string responseContent)
        {
            Rootobject bookData = new Rootobject();
            bookData = JsonConvert.DeserializeObject<Rootobject>(responseContent);

            return bookData;
        }

        public static void Print(Rootobject bookData)
        {
            foreach (var item in bookData.items)
            {
                string ePub = item.accessInfo.epub.isAvailable == true ? "Yes" : "No";
                Console.WriteLine($"Title: {item.volumeInfo.title}");
                Console.WriteLine($"Page Count: {item.volumeInfo.pageCount}");
                Console.WriteLine($"Average Rating: {item.volumeInfo.averageRating}");
                Console.WriteLine($"EPub: {ePub}");
                Console.WriteLine("----------------------------------------------------------------");
            }
        }

        static void Main(string[] args)
        {
            var booksData = GetBooksTask("https://www.googleapis.com/books/v1/volumes?q=inauthor:j.k.%20Rowling").Result;
            var result = DeserializeData(booksData);
            Print(result);

            Console.ReadLine();
        }
    }
}
