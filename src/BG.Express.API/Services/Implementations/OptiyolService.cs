using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using BG.Express.API.Settings;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BG.Express.API.Services;
using BG.Express.API.Exceptions;


namespace BG.Express.API.Services.Implementations
{
    public class OptiyolService : IOptiyolService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<OptiyolService> _logger;
        private readonly OptiyolServiceSettings _optiyolServiceSettings;
        public OptiyolService(
            IHttpClientFactory clientFactory,
            ILogger<OptiyolService> logger,
            OptiyolServiceSettings optiyolServiceSettings)
        {
            this._clientFactory = clientFactory;
            this._logger = logger;
            this._optiyolServiceSettings = optiyolServiceSettings;
        }

        public async Task<GetGeocodesResponse> GetGeocodes(GetGeocodesRequest request)
        {
            foreach (var location in request.Locations)
            {
                location.LocationAddress = location.LocationAddress.Replace(',', ' ');
            }

            using var client = _clientFactory.CreateClient("optiyolservice");
        
            using var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"location/v1/get-geocodes/?company_id={_optiyolServiceSettings.CompanyId}", content);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Geocode servisinden hata döndü {responseBody}");
            }

            return JsonConvert.DeserializeObject<GetGeocodesResponse>(responseBody);
        }


    }
}
