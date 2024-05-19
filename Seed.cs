using InCaseIForgetMyCrochet.Models;

namespace InCaseIForgetMyCrochet;

public class Seed
{
    public static void Clear()
    {
        using var db = new PatternDbContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }

    public static void Run()
    {
        using var db = new PatternDbContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Patterns.Add(new Pattern
        {
            Name = "Simple Scarf",
            Rows = Enumerable.Range(0, 9).Select(i => new Row
            {
                Index = i,
                Instructions = Enumerable.Range(0, i + 1).Select(j => new Instruction
                {
                    Index = j,
                    StitchType = StitchTypeAbbreviation.ch,
                }).ToList()
            }).ToList()
        });
        db.SaveChanges();
    }
}
