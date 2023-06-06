namespace Scripting
{
    public interface ILocalization
    {
        string Translate(string key, params object[] args);
    }
}