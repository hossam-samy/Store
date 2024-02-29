using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMediaServicecs
    {
        Task<string>AddFileAsync(IFormFile file,string name,string dest);
        Task DeleteFileAsync(string url);

        Task<string> UpdateFileAsync(string url,IFormFile file,string name,string dest);


    }
}
