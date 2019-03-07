namespace GNB_EduardoMenaCiudad.Entities
{
    public interface IExchangeRate
    {
        string From { get; set; }
        decimal Rate { get; set; }
        string To { get; set; }
    }
}