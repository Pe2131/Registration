using Common.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.String
{
   public static class IpInformation
    {
        public async static Task<IpInfo_ViewModel> GetInfoAsync(this string ip)
        {
            try
            {

                var httpClient = HttpClientFactory.Create();
                HttpResponseMessage response =await httpClient.GetAsync($"http://ipapi.co/{ip}/json/?key=c5hnEEd9MvQpRsHoAb2eGPxlAmYqou6Eheu6avoDjhROq7CRfF");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IpInfo_ViewModel>(content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
