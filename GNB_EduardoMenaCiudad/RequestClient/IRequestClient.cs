using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.RequestClient
{
    public interface IRequestClient
    {
        Task<string> GetAsync(string url);
    }
}
