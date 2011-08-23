namespace NinjaBone
{
    public interface ISpreadsheetConfiguration
    {
        string Username { get; }
        string Password { get; }
        string SpreadsheetKey { get; }
    }
}