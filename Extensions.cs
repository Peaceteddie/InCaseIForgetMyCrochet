using System.Text.Json;
using InCaseIForgetMyCrochet.Models;

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
    public static List<Row> MirrorPattern(this List<Row> rows)
    {
        rows.AddRange([.. rows.OrderByDescending(x => x.Id)]);
        return rows;
    }
}