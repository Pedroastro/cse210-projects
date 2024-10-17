public class Video
{
    private string _title;
    private string _author;
    private double _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, double length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public string GetVideoInformation()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length}\n";
    }

    public string GetCommentsInformation()
    {   
        string commentInformation = "Comments:\n";
        foreach (Comment comment in _comments)
        {
            commentInformation += $"{comment.GetCommentInformation()}\n";
        }
        return commentInformation;
    }

    public int CommentsCount()
    {
        return _comments.Count;
    }
}