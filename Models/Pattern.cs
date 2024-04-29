
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
    // int Id, int StitchCount, string StitchType
    [Key] public int Id { get; set; }
    public int StitchCount = 0;
    public string StitchType = "";
}