using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Library.ApiClient;


namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://localhost:5001/";
            var client = await LibraryClient.GetAppClientAsync("client","secret","api1", url);
            var response = await LibraryApi.GetAllBooks(client, "https://localhost:5001/api/getbooks");

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var userClient = await LibraryClient.GetUserClientAsync("user","userSecret","ConsoleUser@mail.ru","Console1!",url);
            var bookId = "685cfd67-2c2a-428a-b07c-08d94cf24d7c";
            var ratingResponse = await LibraryApi.SetRating(1, bookId ,userClient,url);
            Console.ReadKey();
        }
    }
}
