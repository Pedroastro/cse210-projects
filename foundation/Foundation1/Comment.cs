public class Comment
{
    private string _username;
    private string _text;

    public Comment(string username, string text)
    {
        _username = username;
        _text = text;
    }

    public string GetCommentInformation()
    {
        return $"{_username} commented: {_text}";
    }
}