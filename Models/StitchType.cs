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
}