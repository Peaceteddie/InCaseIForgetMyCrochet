using System.ComponentModel.DataAnnotations;

namespace InCaseIForgetMyCrochet.Models;

public class Pattern
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; } = "";
    public List<Row> Rows { get; set; } = [];

    public Pattern Clone()
    {
        return new Pattern
        {
            Name = this.Name,
            Rows = this.Rows.Select(r => r.Clone()).ToList()
        };
    }
}

public class Row
{
    [Key] public int Id { get; set; }
    [Required] public int Index { get; set; }
    [Required] public List<Instruction> Instructions { get; set; } = [];

    public Row Clone()
    {
        return new Row
        {
            Instructions = this.Instructions.Select(i => i.Clone()).ToList()
        };
    }
}

public class Instruction
{
    [Key] public int Id { get; set; }
    [Required] public int Index { get; set; }
    [Required] public StitchTypeAbbreviation StitchType { get; set; }

    public Instruction Clone()
    {
        return new Instruction
        {
            StitchType = this.StitchType
        };
    }
}

