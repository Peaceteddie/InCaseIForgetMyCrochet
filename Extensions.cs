using System.Text.Json;

namespace InCaseIForgetMyCrochet;

public static class Extensions
{
    private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

    public static T Inspect<T>(this T obj)
    {
        Console.WriteLine(JsonSerializer.Serialize(obj, options));
        return obj;
    }

    public static T Inspect<T>(this T obj, string label)
    {
        Console.Write($"{label}: ");
        Console.WriteLine(JsonSerializer.Serialize(obj, options));
        return obj;
    }
}