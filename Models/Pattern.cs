using System.ComponentModel.DataAnnotations;

namespace InCaseIForgetMyCrochet.Models;

public class Pattern
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = "";
    public List<Row> Rows { get; set; } = [];
}

public class Row
{
    [Key] public int Id { get; set; }
    [Required] public List<Instruction> Instructions { get; set; } = [];
}

public class Instruction
{
    [Key] public int Id { get; set; }
    [Required] public int StitchCount { get; set; }
    [Required] public StitchTypeAbbreviation StitchType { get; set; }
}

