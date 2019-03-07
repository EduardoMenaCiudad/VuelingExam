namespace GNB_EduardoMenaCiudad.Entities
{
    public class ExchangeRate : IExchangeRate
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
    }
}
