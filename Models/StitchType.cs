namespace InCaseIForgetMyCrochet.Models;

public enum StitchType
{
    ChainStitch,
    SingleCrochet,
    DoubleCrochet,
    HalfDoubleCrochet,
    TrebleCrochet,
    SlipStitch,
    Increase,
    Decrease,
    Space,
    Stitch,
    Repeat,
    Together,
    YarnOver,
    BackLoopOnly,
    FrontLoopOnly,
    DoubleTrebleCrochet,
    FrontPostDoubleCrochet,
    BackPostSingleCrochet
}

public enum StitchTypeAbbreviation
{
    ch,
    sc,
    dc,
    hdc,
    tr,
    slst,
    inc,
    dec,
    sp,
    st,
    rep,
    tog,
    yo,
    blo,
    flo,
    dtr,
    fpdc,
    bpsc
}

public static class StitchTypeExtensions
{
    public static StitchType ToStitchType(this StitchTypeAbbreviation abbreviation) =>
        abbreviation switch
        {
            StitchTypeAbbreviation.ch => StitchType.ChainStitch,
            StitchTypeAbbreviation.sc => StitchType.SingleCrochet,
            StitchTypeAbbreviation.dc => StitchType.DoubleCrochet,
            StitchTypeAbbreviation.hdc => StitchType.HalfDoubleCrochet,
            StitchTypeAbbreviation.tr => StitchType.TrebleCrochet,
            StitchTypeAbbreviation.slst => StitchType.SlipStitch,
            StitchTypeAbbreviation.inc => StitchType.Increase,
            StitchTypeAbbreviation.dec => StitchType.Decrease,
            StitchTypeAbbreviation.sp => StitchType.Space,
            StitchTypeAbbreviation.st => StitchType.Stitch,
            StitchTypeAbbreviation.rep => StitchType.Repeat,
            StitchTypeAbbreviation.tog => StitchType.Together,
            StitchTypeAbbreviation.yo => StitchType.YarnOver,
            StitchTypeAbbreviation.blo => StitchType.BackLoopOnly,
            StitchTypeAbbreviation.flo => StitchType.FrontLoopOnly,
            StitchTypeAbbreviation.dtr => StitchType.DoubleTrebleCrochet,
            StitchTypeAbbreviation.fpdc => StitchType.FrontPostDoubleCrochet,
            StitchTypeAbbreviation.bpsc => StitchType.BackPostSingleCrochet,
            _ => throw new NotImplementedException()
        };
    public static StitchTypeAbbreviation ToAbbreviation(this StitchType stitchType) =>
        stitchType switch
        {
            StitchType.ChainStitch => StitchTypeAbbreviation.ch,
            StitchType.SingleCrochet => StitchTypeAbbreviation.sc,
            StitchType.DoubleCrochet => StitchTypeAbbreviation.dc,
            StitchType.HalfDoubleCrochet => StitchTypeAbbreviation.hdc,
            StitchType.TrebleCrochet => StitchTypeAbbreviation.tr,
            StitchType.SlipStitch => StitchTypeAbbreviation.slst,
            StitchType.Increase => StitchTypeAbbreviation.inc,
            StitchType.Decrease => StitchTypeAbbreviation.dec,
            StitchType.Space => StitchTypeAbbreviation.sp,
            StitchType.Stitch => StitchTypeAbbreviation.st,
            StitchType.Repeat => StitchTypeAbbreviation.rep,
            StitchType.Together => StitchTypeAbbreviation.tog,
            StitchType.YarnOver => StitchTypeAbbreviation.yo,
            StitchType.BackLoopOnly => StitchTypeAbbreviation.blo,
            StitchType.FrontLoopOnly => StitchTypeAbbreviation.flo,
            StitchType.DoubleTrebleCrochet => StitchTypeAbbreviation.dtr,
            StitchType.FrontPostDoubleCrochet => StitchTypeAbbreviation.fpdc,
            StitchType.BackPostSingleCrochet => StitchTypeAbbreviation.bpsc,
            _ => throw new NotImplementedException()
        };

    // match pastel colors in hex format to each stitch type abbreviation. So take all the stitch type abbreviations and match them to a pastel color in hex format. using the formula for the pastel colors and human perception of color.
    public static string ToPastelColor(this StitchTypeAbbreviation abbreviation) =>
    abbreviation switch
    {
        StitchTypeAbbreviation.ch => "hsl(18,    100%,   80%);",
        StitchTypeAbbreviation.sc => "hsl(36,    100%,   80%);",
        StitchTypeAbbreviation.dc => "hsl(54,    100%,   80%);",
        StitchTypeAbbreviation.hdc => "hsl(72,    100%,   80%);",
        StitchTypeAbbreviation.tr => "hsl(90,    100%,   80%);",
        StitchTypeAbbreviation.slst => "hsl(108,   100%,   80%);",
        StitchTypeAbbreviation.inc => "hsl(126,   100%,   80%);",
        StitchTypeAbbreviation.dec => "hsl(144,   100%,   80%);",
        StitchTypeAbbreviation.sp => "hsl(162,   100%,   80%);",
        StitchTypeAbbreviation.st => "hsl(180,   100%,   80%);",
        StitchTypeAbbreviation.rep => "hsl(198,   100%,   80%);",
        StitchTypeAbbreviation.tog => "hsl(216,   100%,   80%);",
        StitchTypeAbbreviation.yo => "hsl(234,   100%,   80%);",
        StitchTypeAbbreviation.blo => "hsl(252,   100%,   80%);",
        StitchTypeAbbreviation.flo => "hsl(270,   100%,   80%);",
        StitchTypeAbbreviation.dtr => "hsl(288,   100%,   80%);",
        StitchTypeAbbreviation.fpdc => "hsl(306,   100%,   80%);",
        StitchTypeAbbreviation.bpsc => "hsl(324,   100%,   80%);",
        _ => throw new NotImplementedException()
    };

}