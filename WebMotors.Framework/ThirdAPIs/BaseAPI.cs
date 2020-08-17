using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Exceptions;

namespace WebMotors.Framework.ThirdAPIs
{
    public abstract class BaseAPI
    {
        public BaseAPI(HttpClient client)
        {
            _client = client; 
        }

        private HttpClient _client { get; set; }
        protected HttpClient Client
        {
            get { return _client; }
        }

        protected  async Task<TModel> ExecuteGetApiAsync<TModel>(string path) where TModel : class
        {
            try
            {
                var response = await Client.GetAsync(path);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseBody))
                    throw new InternalServerErrorException("External WebMotors API - Response retornou nulo.");

                var result = JsonConvert.DeserializeObject<TModel>(responseBody);

                return result;
            }
            catch (Exception ex)
            {

                throw new InternalServerErrorException($"Houve um erro ao acessar a API externa: {ex.Message}");
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

                throw new InternalServerErrorException($"Houve um erro ao acessar a API externa: {ex.Message}");
            }
        }
    }
}
