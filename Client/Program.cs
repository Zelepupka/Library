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

            var client = await LibraryClient.GetAppClientAsync();
            var response = await LibraryApi.GetAllBooks(client);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var userClient = await LibraryClient.GetUserClientAsync();
            var bookId = new Guid("685cfd67-2c2a-428a-b07c-08d94cf24d7c");
            var ratingResponce = await LibraryApi.SetRating(1, bookId,userClient);
            Console.WriteLine(ratingResponce.Content.ReadAsStringAsync());
            Console.ReadKey();
        }
    }
}
