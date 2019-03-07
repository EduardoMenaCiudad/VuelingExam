namespace GNB_EduardoMenaCiudad.Serializers
{
    public interface ISerializer<From, To>
    {
        To Serialize(From from);
        From Serialize(To from);
    }
}
