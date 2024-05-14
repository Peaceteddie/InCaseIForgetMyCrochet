using InCaseIForgetMyCrochet.Components.StitchEditor;
using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;
using Xunit;

namespace InCaseIForgetMyCrochet.Tests;
public class StitchEditorTests
{

    public StitchEditorTests()
    {
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

    }

    [Fact]
    public async Task MirrorPattern_OnClick_SaveChanges()
    {
        var pattern = new Pattern
        {
            Rows =
            [
                new Row {Instructions= [new Instruction {Id = 1, StitchCount =1, StitchType = StitchTypeAbbreviation.sc}]},
                new Row {Instructions= [new Instruction {Id = 2, StitchCount =2, StitchType = StitchTypeAbbreviation.sc}]},
                new Row {Instructions= [new Instruction {Id = 3, StitchCount =3, StitchType = StitchTypeAbbreviation.sc}]},
            ]
        };
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.Patterns.Add(pattern);
        _context.SaveChanges();

        var patternId = pattern.Id;
        var freshPattern = await _context.Patterns.FirstAsync(c => c.Id == patternId);
        freshPattern.Rows.MirrorPattern();
        _context.SaveChanges();

        var updatedPattern = await _context.Patterns.FirstAsync(c => c.Id == patternId);
        Assert.Equal(6, updatedPattern.Rows.Count);
        Assert.Equal(1, updatedPattern.Rows[0].Instructions[0].StitchCount);
        Assert.Equal(2, updatedPattern.Rows[1].Instructions[0].StitchCount);
        Assert.Equal(3, updatedPattern.Rows[2].Instructions[0].StitchCount);
        Assert.Equal(3, updatedPattern.Rows[3].Instructions[0].StitchCount);
        Assert.Equal(2, updatedPattern.Rows[4].Instructions[0].StitchCount);
        Assert.Equal(1, updatedPattern.Rows[5].Instructions[0].StitchCount);
        Assert.All(updatedPattern.Rows, row => Assert.All(row.Instructions, instruction => Assert.Equal(StitchTypeAbbreviation.sc, instruction.StitchType)));
    }
}