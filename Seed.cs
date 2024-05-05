using InCaseIForgetMyCrochet.Models;

namespace InCaseIForgetMyCrochet;

public class Seed
{
    public static void Run()
    {
        using var db = new PatternDbContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Patterns.Add(new Pattern
        {
            Name = "Simple Scarf",
            Rows = Enumerable.Range(1, 10).Select(i => new Row
            {
                Instructions = Enumerable.Range(1, i).Select(j => new Instruction
                {
                    StitchType = StitchTypeAbbreviation.ch,
                    StitchCount = 1
                }).ToList()
            }).ToList()
        });
        db.SaveChanges();
    }
}
