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
        StitchTypeAbbreviation.ch => "#F7E7CE",
        StitchTypeAbbreviation.sc => "#FFC8A2",
        StitchTypeAbbreviation.dc => "#FFA07A",
        StitchTypeAbbreviation.hdc => "#FF7F50",
        StitchTypeAbbreviation.tr => "#FF6347",
        StitchTypeAbbreviation.slst => "#FF4500",
        StitchTypeAbbreviation.inc => "#FFD700",
        StitchTypeAbbreviation.dec => "#FFD700",
        StitchTypeAbbreviation.sp => "#FFD700",
        StitchTypeAbbreviation.st => "#FFD700",
        StitchTypeAbbreviation.rep => "#FFD700",
        StitchTypeAbbreviation.tog => "#FFD700",
        StitchTypeAbbreviation.yo => "#FFD700",
        StitchTypeAbbreviation.blo => "#FFD700",
        StitchTypeAbbreviation.flo => "#FFD700",
        StitchTypeAbbreviation.dtr => "#FFD700",
        StitchTypeAbbreviation.fpdc => "#FFD700",
        StitchTypeAbbreviation.bpsc => "#FFD700",
        _ => throw new NotImplementedException()
    };

}