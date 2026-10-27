public class Reference
{
    // attributes
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // constructors
    public Reference(string book, int chapter, int verse)
    {
        Set(book, chapter, verse, verse);
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Set(book, chapter, startVerse, endVerse);
    }

    // behaviors
    public void Set(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string Get()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
