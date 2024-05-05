using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;

namespace InCaseIForgetMyCrochet.Services;

public class PatternService()
{
    internal readonly Stack<Pattern> _saveRequests = new();

    public async Task<List<Pattern>> GetPatternsAsync()
    {
        using PatternDbContext _context = new();
        return await _context.Patterns
            .Include(p => p.Rows)
            .ThenInclude(r => r.Instructions)
            .ToListAsync();
    }

    public void HandleFieldChanged(Pattern pattern)
    {
        _saveRequests.Push(pattern);
    }

    public async Task SaveChangesAsync()
    {
        using PatternDbContext _context = new();
        while (_saveRequests.Count > 0)
        {
            var pattern = _saveRequests.Pop();
            _context.Patterns.Update(pattern);
        }
        await _context.SaveChangesAsync();
    }
}