using System.Diagnostics;

namespace SCG;
public static class DictWriter
{
    public static void setValue<T>(Dictionary<string, object>? dict, string key, T value)
    {
        if (dict is not null)
            dict[key] = value;
    }
    public static void setValue(Dictionary<string, object>? dict, string key, string value)
    {
        if (dict is not null)
            dict[key] = value;
    }
    public static void setValue(Dictionary<string, object>? dict, string key, byte[] value)
    {
        if (dict is not null)
            dict[key] = value;
    }

    public static void setValueArray(Dictionary<string, object>? dict, params (string key, string value)[] entries)
    {
        if (dict is null) return;

        foreach (var (key, value) in entries)
            dict[key] = value;
    }

   
}
