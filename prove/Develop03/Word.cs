public class Word
{
    // attributes
    private readonly string _text;
    private bool _isHidden;

    // constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // behaviors
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayString()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
