using Newtonsoft.Json;

namespace GNB_EduardoMenaCiudad.Middleware
{
    public class ExceptionMessage
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
