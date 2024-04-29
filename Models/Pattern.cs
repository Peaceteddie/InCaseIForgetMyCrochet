
using System.ComponentModel.DataAnnotations;

namespace InCaseIForgetMyCrochet.Models;

public class Pattern
{
    [Key] public int Id { get; set; }
    [Required] public required string Name { get; set; }
    public List<Instruction> Instructions { get; set; } = [];
}

public class Instruction
{
    [Key] public int Id { get; set; }
    [Required] public int StitchCount { get; set; }
    [Required] public required string StitchType { get; set; }
}