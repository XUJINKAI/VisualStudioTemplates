namespace Autofac.Extension
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string str);
    }
}
