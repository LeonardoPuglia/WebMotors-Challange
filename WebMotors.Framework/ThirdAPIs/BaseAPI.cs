using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Framework.ThirdAPIs
{
    public class BaseAPI
    {
        public BaseAPI(HttpClient client)
        {
            _client = client; 
        }

        public HttpClient _client { get; set; }
        public HttpClient Client
        {
            get { return _client; }
        }

        protected virtual async Task<TModel> ExecuteGetApiAsync<TModel>(string path) where TModel : class
        {
            try
            {
                var response = await Client.GetAsync(path);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseBody))
                    throw new ArgumentNullException("Reponse conveted in null");

                var result = JsonConvert.DeserializeObject<TModel>(responseBody);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        protected virtual async Task<TModel>  ExecuteApiAsync<TModel>(Func<Task<TModel>> fn) where TModel : class
        {
            try
            {
                var result = await fn();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
