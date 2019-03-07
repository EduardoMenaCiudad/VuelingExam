using System.IO;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.FileReaders
{
    public class FileReader : IFileReader
    {
        public async Task<string> ReadFileAsync(string path)
        {
            if (File.Exists(path))
            {
                return await File.ReadAllTextAsync(path);
            }

            return await Task.FromResult(string.Empty);
        }

        public async Task WriteFileAsync(string path, string content)
        {
            await File.WriteAllTextAsync(path, content);
        }
    }
}
