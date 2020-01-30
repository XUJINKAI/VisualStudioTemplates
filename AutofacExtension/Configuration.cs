namespace AutofacApp
{
    public interface ISubConfig
    {
        string Sub { get; set; }
    }

    public class SubConfig : ISubConfig
    {
        public string Sub { get; set; }
    }

    public class Configuration
    {
        public Configuration()
        {
            SubConfig = new SubConfig();
        }

        public string Echo { get; set; }

        public ISubConfig SubConfig { get; set; }
    }
}
