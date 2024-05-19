using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace InCaseIForgetMyCrochet.Tests;
public class StitchEditorTests
{
    private ITestOutputHelper Helper;

    public StitchEditorTests(ITestOutputHelper helper)
    {
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        Helper = helper;
    }

    [Fact]
    public async Task MirrorPatternDown_OnClick_SavesCorrectChanges()
    {
        var pattern = new Pattern
        {
            Rows =
                Enumerable
                .Range(0, 2)
                .Select(i => Enumerable.Range(0, i + 1)
                .Select(j => new Instruction())
                .ToList())
                .Select(i => new Row { Instructions = i })
                .ToList()
        };
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.Patterns.Add(pattern);
        _context.SaveChanges();

        var patternId = pattern.Id;
        var freshPattern = await _context.Patterns.FirstAsync(c => c.Id == patternId);
        freshPattern = MirrorPatternDown(freshPattern);
        _context.SaveChanges();

        var updatedPattern = await _context.Patterns.FirstAsync(c => c.Id == patternId);
        Assert.Equal(4, updatedPattern.Rows.Count);
        Assert.Single(updatedPattern.Rows[0].Instructions);
        Assert.Equal(2, updatedPattern.Rows[1].Instructions.Count);
        Assert.Equal(2, updatedPattern.Rows[2].Instructions.Count);
        Assert.Single(updatedPattern.Rows[3].Instructions);
        Assert.All(updatedPattern.Rows, row => Assert.All(row.Instructions, instruction => Assert.Equal(StitchTypeAbbreviation.ch, instruction.StitchType)));
        Assert.True(updatedPattern.Rows.Aggregate(true, (acc, row) => acc && (acc = row.Instructions.Select(i => i.Id).Distinct().Count() == row.Instructions.Count).Inspect()));
    }

    static Pattern MirrorPatternDown(Pattern Pattern)
    {
        var reversedRows = Pattern.Rows
        .Select(r => r.Clone())
        .Reverse()
        .ToList();

        Pattern.Rows.AddRange(reversedRows);
        return Pattern;
    }
}