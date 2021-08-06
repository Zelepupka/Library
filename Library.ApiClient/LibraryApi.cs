using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Library.ApiClient
{
    public static class LibraryApi
    {
        public static async Task<HttpResponseMessage> GetAllBooks(HttpClient client)
        {
             var response = await client.GetAsync("https://localhost:5001/api/getbooks");
             return response;
        }

        public static async Task<HttpResponseMessage> SetRating(int value, string bookId,HttpClient client)
        {
            HttpContent http = new StringContent(bookId.ToString());
            var response = await client.PostAsync($"https://localhost:5001/api/SetRating?bookId={bookId}&value={value}", http);
            return response;
        }
    }
}