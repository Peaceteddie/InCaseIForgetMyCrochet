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
            Name = "Sphere",
            Instructions =
            [
                new Instruction { StitchCount = 10, StitchType = "sc" },
                new Instruction { StitchCount = 11, StitchType = "sc" },
                new Instruction { StitchCount = 12, StitchType = "sc" },
                new Instruction { StitchCount = 13, StitchType = "sc" },
                new Instruction { StitchCount = 14, StitchType = "sc" },
                new Instruction { StitchCount = 15, StitchType = "sc" },
                new Instruction { StitchCount = 14, StitchType = "sc" },
                new Instruction { StitchCount = 13, StitchType = "sc" },
                new Instruction { StitchCount = 12, StitchType = "sc" },
                new Instruction { StitchCount = 11, StitchType = "sc" },
                new Instruction { StitchCount = 10, StitchType = "sc" }
            ]
        });
        db.Patterns.Add(new Pattern
        {
            Name = "Granny Square",
            Instructions = [
                new Instruction { StitchCount = 3, StitchType = "dc" },
                new Instruction { StitchCount = 3, StitchType = "dc" },
                new Instruction { StitchCount = 3, StitchType = "dc" },
                new Instruction { StitchCount = 3, StitchType = "dc" }
                ]
        });
        db.SaveChanges();
    }
}
