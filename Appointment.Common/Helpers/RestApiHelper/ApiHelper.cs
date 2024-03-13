using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Common.Helpers.RestApiHelper
{
	public class ApiHelper
	{
		public static async Task<T> Get<T>(string baseUri, string url, Dictionary<string, string> header) where T : class
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				if(header!=null)
				{
                    foreach (var key in header.Keys)
                    {
                        client.DefaultRequestHeaders.Add(key, header[key]);
                    }
                }

				HttpResponseMessage response = await client.GetAsync("/api/" + url);
				if (response.IsSuccessStatusCode)
				{
					T result = await response.Content.ReadFromJsonAsync<T>();
					return result;
				}
				else
				{
					return null;
				}
			}
		}

		public static async Task<T> Post<T>(string baseUri, string url, object model, Dictionary<string, string> header) where T : class
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				if (header != null)
				{
					foreach (var key in header.Keys)
					{
						client.DefaultRequestHeaders.Add(key, header[key]);
					}
				}


				var myContent = JsonConvert.SerializeObject(model);
				var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
				var byteContent = new ByteArrayContent(buffer);
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				HttpResponseMessage response = await client.PostAsync("/api/" + url, byteContent);
				if (response.IsSuccessStatusCode)
				{
					string responseApi = await response.Content.ReadAsStringAsync();
					T result = await response.Content.ReadFromJsonAsync<T>();
					return result;
				}
				else
				{
					return null;
				}
			}
		}

    }
}
