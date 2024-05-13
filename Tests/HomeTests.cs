using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InCaseIForgetMyCrochet.Tests;
public class PatternServiceTests
{

    public PatternServiceTests()
    {
        using PatternDbContext _context = new();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

    }

    [Fact]
    public async Task ShouldSaveWhenFieldChanged()
    {
    }
}