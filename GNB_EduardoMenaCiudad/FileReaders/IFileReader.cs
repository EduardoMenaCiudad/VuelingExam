using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.FileReaders
{
    public interface IFileReader
    {
        Task<string> ReadFileAsync(string path);
        Task WriteFileAsync(string path, string content);
    }
}
