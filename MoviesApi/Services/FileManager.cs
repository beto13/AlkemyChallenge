using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MoviesApi.IServices;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class FileManager : IFileManager
    {
        private readonly IWebHostEnvironment webHostEnviroment;
        private readonly IHttpContextAccessor httpContextAccesor;

        public FileManager(
            IWebHostEnvironment webHostEnviroment, 
            IHttpContextAccessor httpContextAccesor)
        {
            this.webHostEnviroment = webHostEnviroment;
            this.httpContextAccesor = httpContextAccesor;
        }
        public async Task<string> AddFile(byte[] content, string extension, string container, string contentType)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{extension}";
                string folder = Path.Combine(webHostEnviroment.WebRootPath, container);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string route = Path.Combine(folder, fileName);
                await File.WriteAllBytesAsync(route, content);
                var url = $"{httpContextAccesor.HttpContext.Request.Scheme}://{httpContextAccesor.HttpContext.Request.Host}";
                var urlBD = Path.Combine(url, container, fileName).Replace("\\", "/");

                return urlBD;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al Agregar Archivo" + Ex.Message);
            }
        }

        public async Task DeleteFile(string container, string route)
        {
            try
            {
                if (route != null)
                {
                    var fileName = Path.GetFileName(route);
                    string directory = Path.Combine(webHostEnviroment.ContentRootPath, container, fileName);

                    if (File.Exists(directory))
                        File.Delete(directory);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al Editar Archivo" + Ex.Message);
            }
        }

        public async Task<string> UpdateFile(byte[] content, string extension, string container, string route, string contentType)
        {
            try
            {
                await DeleteFile(container, route);

                return await AddFile(content, extension, container, contentType);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al Editar Archivo" + Ex.Message);
            }
        }
    }
}
