using InCaseIForgetMyCrochet.Components.Pages;
using InCaseIForgetMyCrochet.Models;
using InCaseIForgetMyCrochet.Services;
using Xunit;

namespace InCaseIForgetMyCrochet.Tests;
public class PatternServiceTests
{
    private readonly PatternService _patternService;

    public PatternServiceTests()
    {
        _patternService = new PatternService();
    }

    [Fact]
    public void ShouldSaveWhenFieldChanged()
    {
        var pattern = new Pattern
        {
            Name = "MyPattern"
        };
        _patternService.HandleFieldChanged(pattern);
        _patternService.SaveChanges();
        Assert.Empty(_patternService._saveRequests);
    }

}