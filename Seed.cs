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
            Rows = Enumerable.Range(0, 10).Select(i => new Row
            {
                Instructions =
                Enumerable.Range(0, 10).Select(i => new Instruction
                {
                    StitchCount = 10,
                    StitchType = StitchTypeAbbreviation.ch
                }).ToList()
            }).ToList()

        });
        db.SaveChanges();
    }
}
