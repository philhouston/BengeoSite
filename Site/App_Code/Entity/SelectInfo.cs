using System;

/// <summary>
///     Summary description for Class1
/// </summary>
public class SelectInfo : IComparable
{
    private string _display = "";
    private string _reference = "";

    public SelectInfo(string paramReference, string paramDisplay)
    {
        _reference = paramReference;
        _display = paramDisplay;
    }

    public string Reference
    {
        get { return _reference; }
        set { _reference = value; }
    }

    public string Display
    {
        get { return _display; }
        set { _display = value; }
    }

    #region IComparable Members

    public int CompareTo(object obj)
    {
        var compareObj = obj as SelectInfo;
        if (compareObj == null)
        {
            return 0;
        }
        if (compareObj.Reference == Reference)
        {
            return 1;
        }
        return 0;
    }

    #endregion
}