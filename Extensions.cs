using System.Text.Json;
using InCaseIForgetMyCrochet;
using InCaseIForgetMyCrochet.Models;
using Microsoft.VisualBasic;

public static class Extensions
{

    /// <summary>
    /// Inspects the object and writes it to the console
    /// </summary>
    /// <typeparam name="T">The type of the object to inspect</typeparam>
    /// <param name="obj">The object to inspect</param>
    /// <returns>The object that was inspected</returns>
    /// <remarks>
    /// This method is only available in DEBUG builds
    /// </remarks>
    /// <example>
    /// <code>
    /// var pattern = new Pattern();
    /// pattern.Inspect();
    /// </code>
    /// </example>
#if DEBUG
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
#endif

    public static IEnumerable<StitchTypeAbbreviation> StitchTypes
    => Enum.GetValues<StitchTypeAbbreviation>();
    public static void Log(this Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
    /// <summary>
    /// Saves the changes of the <paramref name="Pattern"/> in the <paramref name="Context"/> database
    /// </summary>
    /// <param name="Pattern">The pattern to save</param>
    /// <param name="Context">The database context to save the pattern to</param>
    /// <returns></returns>
    /// <exception cref="Exception">Thrown when an exception occurs while saving the changes</exception>
    /// <remarks>
    /// If the <paramref name="Context"/> is not provided, a new instance of <see cref="PatternDbContext"/> is created
    /// </remarks>
    /// <example>
    /// <code>
    /// var pattern = new Pattern();
    /// await pattern.SaveChangesAsync();
    /// </code>
    /// </example>
    /// <example>
    /// <code>
    /// var pattern = new Pattern();
    /// var context = new PatternDbContext();
    /// await pattern.SaveChangesAsync(context);
    /// </code>
    /// </example>
    public static async Task SaveChangesAsync(this Pattern Pattern, PatternDbContext? Context)
    {
        try
        {
            Context ??= new PatternDbContext();

            Context.Update(Pattern);
            await Context.Entry(Pattern).ReloadAsync();
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while saving changes: {ex.Message}");
        }
    }
}