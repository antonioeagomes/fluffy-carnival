using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.Models;
using RestSharp;

namespace client
{
    public static class PokemonService
    {
        private static readonly string baseUrl = "http://localhost:5000/api/";

        private static readonly RestClientOptions options = new RestClientOptions(baseUrl)
        {
            ThrowOnAnyError = true,
            MaxTimeout = 1000
        };
        private static readonly RestClient client = new RestClient(options);

        public static async Task<List<Pokemon>?> List()
        {
            var request = new RestRequest("pokemon", Method.Get);
            var response = await client.GetAsync<List<Pokemon>>(request);

            return response;
        }

        public static async Task<Pokemon?> GetById(int id)
        {
            var request = new RestRequest($"pokemon/{id}", Method.Get);
            var response = await client.GetAsync<Pokemon>(request);
            return response;
        }

        public static async Task<Pokemon?> GetByName(string name)
        {
            var request = new RestRequest($"pokemon/get/{name}", Method.Get);
            var response = await client.GetAsync<Pokemon>(request);
            return response;
        }

    }
}