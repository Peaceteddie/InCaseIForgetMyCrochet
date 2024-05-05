using InCaseIForgetMyCrochet.Models;
using InCaseIForgetMyCrochet.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InCaseIForgetMyCrochet.Tests;
public class PatternServiceTests
{
    private readonly PatternService _patternService;

    public PatternServiceTests()
    {
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _patternService = new PatternService();
    }

    [Fact]
    public async Task ShouldSaveWhenFieldChanged()
    {
        // Setup
        using PatternDbContext context = new();
        var pattern = new Pattern
        {
            Name = "MyPattern"
        };

        // Act
        _patternService.HandleFieldChanged(pattern);
        await _patternService.SaveChangesAsync();

        // Assert
        Assert.Empty(_patternService._saveRequests);
        var savedPattern = await context.Patterns.FirstAsync();
        Assert.Equal(pattern.Name, savedPattern.Name);
    }
}