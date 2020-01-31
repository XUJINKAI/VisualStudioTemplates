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

    public class AppSetting
    {
        public AppSetting()
        {
            SubConfig = new SubConfig();
        }

        public string Echo { get; set; }

        public ISubConfig SubConfig { get; set; }
    }
}
