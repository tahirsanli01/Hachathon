using Appointment.Common.Entities.Dtos.RequestNumber;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sequential.Handler.Business;
using System.Buffers.Text;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Sequential.Handler.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private HttpClient _httpClient;
        private IWebHostEnvironment _environment;
        private RequestNumberPublish _requestNumberPublish;

        public HomeController(HttpClient httpClient, IWebHostEnvironment environment, RequestNumberPublish requestNumberPublish)
        {
            _httpClient = httpClient;
            _environment = environment;
            _requestNumberPublish = requestNumberPublish;
        }

        [HttpPost(Name = "GetRequestNumber")]
        public async Task<IActionResult> GetRequestNumber(RequestNumber requestNumber)
        {
            _requestNumberPublish.Publish(requestNumber);
            return Ok();
        }

        [HttpPost(Name = "CompareImage")]
        public async Task<IActionResult> CompareImage(RequestCompareImage request)
        {
            _httpClient.BaseAddress = new Uri("http://127.0.0.1:105/");
            var imageName = Guid.NewGuid().ToString().Replace("-", "");


            var path1 = System.IO.Path.Combine(_environment.ContentRootPath, "wwwroot", imageName + "1.jpeg");
            var path2 = System.IO.Path.Combine(_environment.ContentRootPath, "wwwroot", imageName + "2.jpeg");

            using (MemoryStream imageStream = new MemoryStream())
            {
                byte[] picture1Bytes = System.Convert.FromBase64String(request.Picture1);
                imageStream.Write(picture1Bytes, 0, picture1Bytes.Length);
                FileStream fs = System.IO.File.Create(path1);
                imageStream.WriteTo(fs);
                fs.Flush();
                fs.Dispose();
            }

            using (MemoryStream imageStream = new MemoryStream())
            {
                byte[] picture2Bytes = System.Convert.FromBase64String(request.Picture2);
                imageStream.Write(picture2Bytes, 0, picture2Bytes.Length);
                FileStream fs = System.IO.File.Create(path2);
                imageStream.WriteTo(fs);
                fs.Flush();
                fs.Dispose();
            }

            var result = await _httpClient.GetStringAsync($"compare?identity={request.Identity}&pic1={path1}&pic2={path2}");
            return Ok(result);
        }
    }
}