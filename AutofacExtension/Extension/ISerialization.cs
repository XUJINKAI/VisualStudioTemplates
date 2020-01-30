namespace Autofac.Extension
{
    public interface ISerialization
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string str);
    }
}
