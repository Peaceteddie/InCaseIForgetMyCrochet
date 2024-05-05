using InCaseIForgetMyCrochet.Models;
using Microsoft.EntityFrameworkCore;

namespace InCaseIForgetMyCrochet.Services;

public class PatternService()
{
    internal readonly Stack<Pattern> _saveRequests = new();

    public async Task<List<Pattern>> GetPatterns()
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

    public void SaveChanges()
    {
        using PatternDbContext _context = new();
        while (_saveRequests.Count > 0)
        {
            var pattern = _saveRequests.Pop();
            if (pattern == null) continue;
            _context.Update(pattern);
        }
        _context.SaveChanges();
    }
}