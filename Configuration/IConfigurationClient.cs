namespace Configuration
{
    public interface IConfigurationClient
    {
        string GetValue(string name);
    }
}
