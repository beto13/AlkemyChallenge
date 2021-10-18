using System.Threading.Tasks;

namespace MoviesApi.IServices
{
    public interface IFileManager
    {
        Task<string> UpdateFile(byte[] content, string extension, string container, string route, string contentType);
        Task DeleteFile(string container, string route);
        Task<string> AddFile(byte[] content, string extension, string container, string contentType);
    }
}
