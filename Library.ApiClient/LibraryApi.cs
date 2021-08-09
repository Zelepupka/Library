using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Library.ApiClient
{
    public static class LibraryApi
    {
        public static async Task<HttpResponseMessage> GetAllBooks(HttpClient client,string url)
        {
             var response = await client.GetAsync(url);
             return response;
        }

        public static async Task<HttpResponseMessage> SetRating(int value, string bookId,HttpClient client,string url)
        {
            HttpContent http = new StringContent(bookId.ToString());
            var response = await client.PostAsync($"{url}?bookId={bookId}&value={value}", http);
            return response;
        }
    }
}