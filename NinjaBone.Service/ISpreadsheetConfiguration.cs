namespace NinjaBone.Service
{
    public interface ISpreadsheetConfiguration
    {
        string Username { get; }
        string Password { get; }
        string SpreadsheetKey { get; }
    }
}