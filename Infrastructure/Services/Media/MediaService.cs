using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Media
{
    public class MediaService : IMediaServicecs
    {
        private readonly HttpContext _httpContext;

        public MediaService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<string> AddFileAsync(IFormFile file,string name,string dest)
        {
            if (file == null || file.Length == 0)
                return string.Empty ;

            var filename= name+Path.GetExtension(file.FileName);  

            var filepath= Path.Combine("wwwroot",$"{dest}Images");

            using (var fileStream = new FileStream(Path.Combine(filepath,filename ), FileMode.OpenOrCreate))
            { 
               
                await file.CopyToAsync(fileStream);
            }
            var baseUrl = @$"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}/{dest}Images/";

            return baseUrl + filename;
        }

        public  Task DeleteFileAsync(string url)
        {
            if (File.Exists(url))
            {
                File.Delete(url);   
            } 
            return Task.CompletedTask;
        }

        public async Task<string> UpdateFileAsync(string url, IFormFile file, string name, string dest)
        {
            if (file == null || file.Length == 0) return url;

                await DeleteFileAsync(url);

           return await AddFileAsync(file, name, dest);

        }
    }
}
