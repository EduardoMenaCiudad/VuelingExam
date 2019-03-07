namespace GNB_EduardoMenaCiudad.Entities
{
    public interface ITransaction
    {
        decimal Amount { get; set; }
        string Currency { get; set; }
        string Sku { get; set; }
    }
}