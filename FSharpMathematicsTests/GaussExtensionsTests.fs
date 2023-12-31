﻿module GaussExtensionsTests

open FSharpMathematics.Core
open TestFunctions
open Xunit

[<Fact>]
let ``Test Row Replacement`` () =
    // random dimensions (m = 8, n = 2)
    let rrA1 = array2D [[0.5714523351; -0.007905179966];
                  [-1.012420413; -0.7572135039];
                  [-0.04952089971; 2.316840129];
                  [0.1063437767; -0.8505437839];
                  [0.654618789; -0.7415099431];
                  [-1.138717868; 0.6378043157];
                  [0.8023920584; 0.3339458901];
                  [-0.04954687344; 0.1822930071]] |> Matrix
    let rri1 = 6
    let rrf1 = 0.285723401832266
    let rrj1 = 2
    let rrAv1 = array2D [[0.5714523351; -0.007905179966];
                  [-1.012420413; -0.7572135039];
                  [-0.04952089971; 2.316840129];
                  [0.1063437767; -0.8505437839];
                  [0.654618789; -0.7415099431];
                  [-1.138717868; 0.6378043157];
                  [0.7882427785; 0.9959213333];
                  [-0.04954687344; 0.1822930071]] |> Matrix
    let rr1 = TestRowReplacement rrA1 rri1 rrf1 rrj1 rrAv1
    let (_, res, _) = rr1
    Assert.True res
    
    // random dimensions (m = 8, n = 8)
    let rrA2 = array2D [[-0.2425695772; 0.3964074291; 0.2970666867; 0.5475370448; -1.241788938; -0.8290674295; -0.3856002305; -1.09493804];
                      [-1.774080748; -1.279618411; -0.2079291248; -0.6428551547; -1.469420153; -0.5865172776; -0.8392558043; 0.08428419077];
                      [-1.644298937; -0.1053978915; 0.06971397684; 0.8078234294; -0.6469239374; 0.3366219627; -1.178085981; 1.172441686];
                      [0.298770533; 1.79533894; -1.392078864; -0.07352973435; -0.8403383872; -1.765853944; 0.03876298546; -0.411681581];
                      [-2.39814301; -0.06872328301; 0.6666384117; 0.3546196541; -0.3679760352; 1.37818191; -1.38340005; -0.3015369553];
                      [0.1729489066; 0.3159608404; -0.2033479602; -0.6906698345; 0.8278319937; 1.492335518; 0.8495741383; 0.6388300485];
                      [0.8463459268; 0.9344235533; -1.272271688; -1.502341909; -0.751011486; 1.722572805; -0.5750540217; -0.9678375877];
                      [-1.070199859; -0.8306515744; 1.481769633; 0.08863515279; -0.152996928; 0.0960764313; -0.1567727813; 0.02102785426]] |> Matrix
    let rri2 = 0
    let rrf2 = 0.514002081711778
    let rrj2 = 5
    let rrAv2 = array2D [[-0.1536734791; 0.5588119589; 0.1925454119; 0.1925313121; -0.8162815699; -0.0620038665; 0.05108264514; -0.7665780654];
                      [-1.774080748; -1.279618411; -0.2079291248; -0.6428551547; -1.469420153; -0.5865172776; -0.8392558043; 0.08428419077];
                      [-1.644298937; -0.1053978915; 0.06971397684; 0.8078234294; -0.6469239374; 0.3366219627; -1.178085981; 1.172441686];
                      [0.298770533; 1.79533894; -1.392078864; -0.07352973435; -0.8403383872; -1.765853944; 0.03876298546; -0.411681581];
                      [-2.39814301; -0.06872328301; 0.6666384117; 0.3546196541; -0.3679760352; 1.37818191; -1.38340005; -0.3015369553];
                      [0.1729489066; 0.3159608404; -0.2033479602; -0.6906698345; 0.8278319937; 1.492335518; 0.8495741383; 0.6388300485];
                      [0.8463459268; 0.9344235533; -1.272271688; -1.502341909; -0.751011486; 1.722572805; -0.5750540217; -0.9678375877];
                      [-1.070199859; -0.8306515744; 1.481769633; 0.08863515279; -0.152996928; 0.0960764313; -0.1567727813; 0.02102785426]] |> Matrix
    let rr2 = TestRowReplacement rrA2 rri2 rrf2 rrj2 rrAv2
    let (_, res, _) = rr2
    Assert.True res
    
    // random dimensions (m = 3, n = 4)
    let rrA3 = array2D [[-0.1728286053; -0.2786013458; -0.1078219463; -2.205008413];
                      [-0.5804969312; -0.8717499918; 2.653018118; -0.4181760449];
                      [1.419691297; -2.472183943; -0.2537203955; 0.5997307159]] |> Matrix
    let rri3 = 0
    let rrf3 = 0.36712545732368
    let rrj3 = 0
    let rrAv3 = array2D [[-0.236278386; -0.3808829923; -0.1474061276; -3.014523135];
                      [-0.5804969312; -0.8717499918; 2.653018118; -0.4181760449];
                      [1.419691297; -2.472183943; -0.2537203955; 0.5997307159]] |> Matrix
    let rr3 = TestRowReplacement rrA3 rri3 rrf3 rrj3 rrAv3
    let (_, res, _) = rr3
    Assert.True res

[<Fact>]
let ``Test Row Interchance`` () =
    // random dimensions (m = 2, n = 8)
    let riA1 = array2D [[2.084763777; -0.9206182549; 0.9260012211; -0.1511588181; -0.8712644553; 0.09442138781; -0.2635453439; -0.3439688666];
                      [-1.314966089; 1.348411269; 0.4084590302; -1.192429803; 0.5461324342; 1.137231571; 1.182766794; 1.215999069]] |> Matrix
    let rii1 = 0
    let rij1 = 0
    let riAv1 = array2D [[2.084763777; -0.9206182549; 0.9260012211; -0.1511588181; -0.8712644553; 0.09442138781; -0.2635453439; -0.3439688666];
                      [-1.314966089; 1.348411269; 0.4084590302; -1.192429803; 0.5461324342; 1.137231571; 1.182766794; 1.215999069]] |> Matrix
    let ri1 = TestRowInterchange riA1 rii1 rij1 riAv1
    let (_, res, _) = ri1
    Assert.True res
    
    // random dimensions (m = 2, n = 9)
    let riA2 = array2D [[-1.132698949; 0.3044155392; -1.424492903; -0.4719359521; 0.1933952497; -1.262836701; -0.9497347812; -0.3238368608; -0.6576721438];
                      [-0.08510071663; 0.212131006; -1.412123808; -0.16750788; -0.0563258269; 1.063502; 0.432285099; -0.4062299587; 0.7420405923]] |> Matrix
    let rii2 = 0
    let rij2 = 0
    let riAv2 = array2D [[-1.132698949; 0.3044155392; -1.424492903; -0.4719359521; 0.1933952497; -1.262836701; -0.9497347812; -0.3238368608; -0.6576721438];
                      [-0.08510071663; 0.212131006; -1.412123808; -0.16750788; -0.0563258269; 1.063502; 0.432285099; -0.4062299587; 0.7420405923]] |> Matrix
    let ri2 = TestRowInterchange riA2 rii2 rij2 riAv2
    let (_, res, _) = ri2
    Assert.True res
    
    // random dimensions (m = 3, n = 5)
    let riA3 = array2D [[-0.5491833701; -0.1445390187; -0.3552318413; 0.6889401497; 0.587036107];
                      [0.1527019976; -0.2231489269; 0.1065165995; -2.369237059; 0.6268779563];
                      [0.7045998332; -1.36693603; -0.3554696902; -0.1096535453; 0.5150025093]] |> Matrix
    let rii3 = 1
    let rij3 = 0
    let riAv3 = array2D [[0.1527019976; -0.2231489269; 0.1065165995; -2.369237059; 0.6268779563];
                      [-0.5491833701; -0.1445390187; -0.3552318413; 0.6889401497; 0.587036107];
                      [0.7045998332; -1.36693603; -0.3554696902; -0.1096535453; 0.5150025093]] |> Matrix
    let ri3 = TestRowInterchange riA3 rii3 rij3 riAv3
    let (_, res, _) = ri3
    Assert.True res

[<Fact>]
let ``Test Row Scaling`` () =
    // random dimensions (m = 5, n = 6)
    let rsA1 = array2D [[0.2133913322; 0.2288396827; -0.5849369952; -1.554861553; -0.8222718913; -2.50218543];
                      [1.662113969; 1.409225251; -1.601011371; -1.259348541; -1.346943746; 0.3962311272];
                      [0.3075094557; 1.907231696; 0.04744340438; -1.059808247; 1.630709072; 0.6092539387];
                      [-0.7165580859; 1.208010744; -1.313672564; -1.791376172; -0.04806524786; 0.6756112528];
                      [0.9951507354; -1.503788956; -0.7180113049; 0.803842189; 1.257871953; 0.3631860623]] |> Matrix
    let rsi1 = 2
    let rsf1 = 0.660388747072028
    let rsAv1 = array2D [[0.2133913322; 0.2288396827; -0.5849369952; -1.554861553; -0.8222718913; -2.50218543];
                      [1.662113969; 1.409225251; -1.601011371; -1.259348541; -1.346943746; 0.3962311272];
                      [0.2030757841; 1.25951435; 0.03133109037; -0.6998854402; 1.076901921; 0.4023444452];
                      [-0.7165580859; 1.208010744; -1.313672564; -1.791376172; -0.04806524786; 0.6756112528];
                      [0.9951507354; -1.503788956; -0.7180113049; 0.803842189; 1.257871953; 0.3631860623]] |> Matrix
    let rs1 = TestRowScaling rsA1 rsi1 rsf1 rsAv1
    let (_, res, _) = rs1
    Assert.True res
    
    // random dimensions (m = 7, n = 2)
    let rsA2 = array2D [[0.9218485477; 0.06320478325];
                      [-0.1131213466; 0.2016219566];
                      [-0.7162173797; 0.04537281858];
                      [-0.1039193761; -1.212406579];
                      [-1.867322155; -1.714999106];
                      [2.309404967; 1.017814566];
                      [-1.577651507; 0.128561645]] |> Matrix
    let rsi2 = 4
    let rsf2 = 0.736022499267022
    let rsAv2 = array2D [[0.9218485477; 0.06320478325];
                      [-0.1131213466; 0.2016219566];
                      [-0.7162173797; 0.04537281858];
                      [-0.1039193761; -1.212406579];
                      [-1.37439112; -1.262277928];
                      [2.309404967; 1.017814566];
                      [-1.577651507; 0.128561645]] |> Matrix
    let rs2 = TestRowScaling rsA2 rsi2 rsf2 rsAv2
    let (_, res, _) = rs2
    Assert.True res
    
    // random dimensions (m = 8, n = 3)
    let rsA3 = array2D [[-1.626963335; 2.121088171; 0.9347467071];
                      [-1.444974668; 0.4608046999; -0.614043905];
                      [-0.8619013222; -0.3404689007; 0.4007987945];
                      [0.890993801; 1.02315409; -0.2551926728];
                      [-1.393832661; -0.3241877353; 0.0189420965];
                      [0.2235317925; 0.5495694909; 0.8170142665];
                      [0.02882341438; -0.6813887285; -0.3773620112];
                      [0.4059974456; -2.444491808; -0.7772723807]] |> Matrix
    let rsi3 = 2
    let rsf3 = 0.159523562602477
    let rsAv3 = array2D [[-1.626963335; 2.121088171; 0.9347467071];
                      [-1.444974668; 0.4608046999; -0.614043905];
                      [-0.1374935695; -0.054312812; 0.06393685159];
                      [0.890993801; 1.02315409; -0.2551926728];
                      [-1.393832661; -0.3241877353; 0.0189420965];
                      [0.2235317925; 0.5495694909; 0.8170142665];
                      [0.02882341438; -0.6813887285; -0.3773620112];
                      [0.4059974456; -2.444491808; -0.7772723807]] |> Matrix
    let rs3 = TestRowScaling rsA3 rsi3 rsf3 rsAv3
    let (_, res, _) = rs3
    Assert.True res

[<Fact>]
let ``Test Forward Reduction`` () =
    // random dimensions (m = 3, n = 5)
    let frA1 = array2D [[0.3293962176; 0.6935955839; 0.09659822745; 0.7365780632; 0.0918902432];
                      [-1.098515958; 0.1506735135; -1.306204753; -0.01553304005; 0.46011967];
                      [-0.2153824764; 0.2451146366; -0.4705610486; 0.3800892186; 1.133439727]] |> Matrix
    let frAv1 = array2D [[0.3293962176; 0.6935955839; 0.09659822745; 0.7365780632; 0.0918902432];
                      [0.0; 2.463771771; -0.9840556555; 2.440909121; 0.7665679323];
                      [0.0; 0.0; -0.1283558116; 0.169562577; 0.9761531774]] |> Matrix
    let fr1 = TestForwardReduction frA1 frAv1
    let (_, res, _) = fr1
    Assert.True res
    
    // random dimensions (m = 9, n = 6)
    let frA2 = array2D [[0.2202080507; -0.7716343108; 0.4620331852; -1.423664573; -0.2188265965; 1.386991262];
                      [-1.110318774; 0.9619153981; -0.2436799097; 1.178137403; 0.5452153468; -1.864141869];
                      [-1.134347296; 2.775357302; -0.6461849997; -0.7192245188; -1.009504539; 1.765704579];
                      [-0.2675059784; 0.3051795363; -1.964641031; -1.188789848; 1.2464018; 0.3456569568];
                      [0.7521141541; 0.8050837604; 0.531549075; 1.374366337; 0.6105210333; -1.059727712];
                      [-1.948461463; -1.34999792; 2.17087673; -2.361992995; -1.050239972; 0.7078371424];
                      [-1.494719656; 0.9335968925; -0.02155308249; -0.8984259337; 0.5392576955; -0.396060336];
                      [3.089665479; 1.232642814; -0.05214520672; 1.816900905; -0.3942161669; 1.009601008];
                      [-0.9575953385; -0.9179591145; -0.4423422292; -0.6376319283; 1.660595826; -0.6656807465]] |> Matrix
    let frAv2 = array2D [[0.2202080507; -0.7716343108; 0.4620331852; -1.423664573; -0.2188265965; 1.386991262];
                      [0.0; -2.928769158; 2.085953898; -6.000171921; -0.5581379483; 5.12925566];
                      [0.0; 0.0; 0.8795276553; -5.595410498; -1.908140967; 6.80967526];
                      [0.0; 0.0; 0.0; -13.41558475; -2.920420511; 15.27499822];
                      [0.0; 0.0; 0.0; 0.0; 1.980539403; -1.396082602];
                      [0.0; 0.0; 0.0; 0.0; 0.0; -0.5566079623];
                      [0.0; 0.0; 0.0; 0.0; 0.0; 0.0];
                      [0.0; 0.0; 0.0; 0.0; 0.0; 0.0];
                      [0.0; 0.0; 0.0; 0.0; 0.0; 0.0]] |> Matrix
    let fr2 = TestForwardReduction frA2 frAv2
    let (_, res, _) = fr2
    Assert.True res
    
    // random dimensions (m = 2, n = 4)
    let frA3 = array2D [[0.5745557449; -0.8565305935; 2.144169394; 0.6245954223];
                      [2.258374436; -0.7956640398; 0.4406911563; 0.02856888667]] |> Matrix
    let frAv3 = array2D [[0.5745557449; -0.8565305935; 2.144169394; 0.6245954223];
                      [0.0; 2.571053313; -7.987276696; -2.426493738]] |> Matrix
    let fr3 = TestForwardReduction frA3 frAv3
    let (_, res, _) = fr3
    Assert.True res
    
    // edge case data for 'forwardReduction()'
    
    // dimensions (m = 3, n = 3)
    let ecFrA0 = array2D [[0.0; 2.0; 2.0];
                      [1.0; 0.0; 0.0];
                      [0.0; 4.0; 4.0]] |> Matrix
    let ecFrAv0 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 2.0; 2.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecFr0 = TestForwardReduction ecFrA0 ecFrAv0
    let (_, res, _) = ecFr0
    Assert.True res
    
    // dimensions (m = 3, n = 3)
    let ecFrA1 = array2D [[0.0; 0.0; 1.0];
                      [0.0; 1.0; 0.0];
                      [1.0; 0.0; 0.0]] |> Matrix
    let ecFrAv1 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 1.0]] |> Matrix
    let ecFr1 = TestForwardReduction ecFrA1 ecFrAv1
    let (_, res, _) = ecFr1
    Assert.True res
    
    // dimensions (m = 3, n = 3)
    let ecFrA2 = array2D [[5.0; 5.0; 0.0];
                      [1.0; 1.0; 0.0];
                      [0.0; 1.0; 0.0]] |> Matrix
    let ecFrAv2 = array2D [[5.0; 5.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecFr2 = TestForwardReduction ecFrA2 ecFrAv2
    let (_, res, _) = ecFr2
    Assert.True res
    
    // dimensions (m = 4, n = 5)
    let ecFrA3 = array2D [[0.0; 0.0; 0.0; 0.0; 1.0];
                      [0.0; 0.0; 4.0; 0.0; 1.0];
                      [0.0; 0.0; 1.0; 0.0; 0.0];
                      [0.0; 1.0; 0.0; 0.0; 0.0]] |> Matrix
    let ecFrAv3 = array2D [[0.0; 1.0; 0.0; 0.0; 0.0];
                      [0.0; 0.0; 4.0; 0.0; 1.0];
                      [0.0; 0.0; 0.0; 0.0; -0.25];
                      [0.0; 0.0; 0.0; 0.0; 0.0]] |> Matrix
    let ecFr3 = TestForwardReduction ecFrA3 ecFrAv3
    let (_, res, _) = ecFr3
    Assert.True res
    
    // dimensions (m = 3, n = 3)
    let ecFrA4 = array2D [[1.0; 0.0; 0.0];
                      [2.0; 1.0; 0.0];
                      [3.0; 2.0; 1.0]] |> Matrix
    let ecFrAv4 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 1.0]] |> Matrix
    let ecFr4 = TestForwardReduction ecFrA4 ecFrAv4
    let (_, res, _) = ecFr4
    Assert.True res
    
    // dimensions (m = 3, n = 3)
    let ecFrA5 = array2D [[1.0; 0.0; 0.0];
                      [2.0; 1.0; 0.0];
                      [3.0; 2.0; 0.0]] |> Matrix
    let ecFrAv5 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecFr5 = TestForwardReduction ecFrA5 ecFrAv5
    let (_, res, _) = ecFr5
    Assert.True res

[<Fact>]
let ``Test Backwards Reduction`` () =
    // random dimensions (m = 6, n = 8)
    let brA1 = array2D [[-0.4336651125; 1.178485222; 0.4623249816; -2.787207089; -0.5756444421; -0.2209331343; -0.06476223242; 1.515693894];
                      [0.0; -1.054517388; -0.3570241886; 3.166541593; 1.587647177; -0.7088208685; 0.3321960478; -3.212072577];
                      [0.0; 0.0; 1.414799064; -0.5449072204; 1.61598542; -2.234820865; 0.5866582559; -2.594424743];
                      [0.0; 0.0; 0.0; 7.334084849; 5.63820884; -1.484075861; 1.427891389; -7.190550079];
                      [0.0; 0.0; 0.0; 0.0; -4.504130616; 1.108608542; -2.046177402; 2.574342462];
                      [0.0; 2.220446049e-16; 0.0; 0.0; 0.0; -0.6297913889; 0.7924373674; -1.264886472]] |> Matrix
    let brAv1 = array2D [[1.0; 0.0; 0.0; 0.0; 0.0; 0.0; 2.072386754; -0.8353486125];
                      [0.0; 1.0; 0.0; 0.0; 0.0; 0.0; 0.8454714086; -0.3816845601];
                      [0.0; -4.595837075e-16; 1.0; 0.0; 0.0; 0.0; -1.803927858; 1.228708709];
                      [0.0; -4.631069476e-18; 0.0; 1.0; 0.0; 0.0; -0.1710778059; -0.5146575913];
                      [0.0; -8.677822276e-17; 0.0; 0.0; 1.0; 0.0; 0.1445931788; -0.07721565559];
                      [0.0; -3.525684994e-16; 0.0; 0.0; 0.0; 1.0; -1.258253735; 2.00842135]] |> Matrix
    let br1 = TestBackwardReduction brA1 brAv1
    let (_, res, _) = br1
    Assert.True res
    
    // random dimensions (m = 6, n = 9)
    let brA2 = array2D [[-0.7962844478; -1.273956049; 0.2994588705; 0.5395664535; -0.3279662183; 0.642711245; 0.285856715; 0.5078102771; -0.3513116465];
                      [0.0; 0.3827004264; -1.956914252; -1.865134452; 0.5814060624; -0.3592972201; -2.207049223; -0.5099039394; -0.2896766649];
                      [0.0; 0.0; -5.218613898; -3.975910194; 0.2611972541; -0.0369107144; -7.15444384; 1.282908999; -1.827350955];
                      [2.220446049e-16; 0.0; 0.0; -0.7162737093; -1.541572412; 1.024131445; -4.663612474; 7.462663866; -2.41713073];
                      [-1.679332119e-16; 0.0; 0.0; 0.0; 2.35084785; -2.803920791; 3.962692499; -10.18921292; 0.9546771763];
                      [-1.726857052e-16; 0.0; 0.0; 0.0; 0.0; 1.216177968; 0.3998755112; 0.4244781353; 3.13277311]] |> Matrix
    let brAv2 = array2D [[1.0; 0.0; 0.0; 1.246643944e-16; 0.0; 0.0; -1.604019396; -1.444169615; 3.4376293];
                      [1.811157122e-16; 1.0; 0.0; -1.45065854e-16; 0.0; 0.0; 1.368694263; 1.220742856; -1.454718625];
                      [-1.50207895e-17; 0.0; 1.0; 8.50971577e-17; 0.0; 0.0; -0.4390434754; 0.6887870763; 0.8326902431];
                      [5.215080228e-18; 0.0; 0.0; 1.0; 0.0; 0.0; 2.509167365; -1.48737534; -0.4287448872];
                      [-2.407911248e-16; 0.0; 0.0; 0.0; 1.0; 0.0; 2.077809027; -3.917978244; 3.478465654];
                      [-1.419904897e-16; 0.0; 0.0; 0.0; 0.0; 1.0; 0.3287968718; 0.3490263322; 2.575916678]] |> Matrix
    let br2 = TestBackwardReduction brA2 brAv2
    let (_, res, _) = br2
    Assert.True res
    
    // random dimensions (m = 4, n = 5)
    let brA3 = array2D [[0.8496190361; 0.674051592; 2.499733605; -1.218719927; -0.4338033696];
                      [0.0; -1.040492842; 1.363825208; -0.3197048702; 0.3026553575];
                      [0.0; 0.0; -5.99295485; 2.126804754; 0.7620811509];
                      [0.0; 0.0; 0.0; -1.194100591; 0.3908011971]] |> Matrix
    let brAv3 = array2D [[1.0; 0.0; 0.0; 0.0; 0.1398189505];
                      [0.0; 1.0; 0.0; 0.0; -0.5092328972];
                      [0.0; 0.0; 1.0; 0.0; -0.2433081249];
                      [0.0; 0.0; 0.0; 1.0; -0.327276613]] |> Matrix
    let br3 = TestBackwardReduction brA3 brAv3
    let (_, res, _) = br3
    Assert.True res
    
    // edge case data for 'backwardReduction()'
    
    // dimensions (m = 3, n = 3)
    let ecBrA0 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 2.0; 2.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecBrAv0 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 1.0; 1.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecBr0 = TestBackwardReduction ecBrA0 ecBrAv0
    let (_, res, _) = ecBr0
    Assert.True res
    
    // dimensions (m = 3, n = 3)
    let ecBrA1 = array2D [[5.0; 5.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecBrAv1 = array2D [[1.0; 0.0; 0.0];
                      [0.0; 1.0; 0.0];
                      [0.0; 0.0; 0.0]] |> Matrix
    let ecBr1 = TestBackwardReduction ecBrA1 ecBrAv1
    let (_, res, _) = ecBr1
    Assert.True res
    
    // dimensions (m = 4, n = 5)
    let ecBrA2 = array2D [[0.0; 1.0; 0.0; 0.0; 0.0];
                      [0.0; 0.0; 4.0; 0.0; 1.0];
                      [0.0; 0.0; 0.0; 0.0; -0.25];
                      [0.0; 0.0; 0.0; 0.0; 0.0]] |> Matrix
    let ecBrAv2 = array2D [[0.0; 1.0; 0.0; 0.0; 0.0];
                      [0.0; 0.0; 1.0; 0.0; 0.0];
                      [0.0; 0.0; 0.0; 0.0; 1.0];
                      [0.0; 0.0; 0.0; 0.0; 0.0]] |> Matrix
    let ecBr2 = TestBackwardReduction ecBrA2 ecBrAv2
    let (_, res, _) = ecBr2
    Assert.True res

[<Fact>]
let ``Test Gauss Elimination`` () =
    // random dimensions (m = 8, n = 8)
    let gelA1 = array2D [[1.22016327; 0.9715475447; 1.282897695; 0.4394711301; 0.7689194838; -1.214874819; -1.907626884; -0.06798960181];
                      [0.2912808241; -0.7639434618; 0.7660671888; -0.3153870365; -0.04020382697; -0.7088447006; 1.011096506; -1.52061831];
                      [0.914192924; -0.5833336198; -0.06042113705; 0.1573393013; 2.743100901; 0.8613337096; -2.049193967; 1.013532233];
                      [1.728771114; -0.2126335589; -0.2497204322; 0.5797884983; 1.125383129; -0.08733724091; 0.0415416019; -1.959579703];
                      [0.4725030208; -0.03167382831; -1.545485931; -0.2144750337; 1.028983034; -0.5422999805; 0.2695725419; -0.9111268281];
                      [0.109100323; 0.07958846144; -0.9131661079; -0.8166199148; 0.7114743791; -0.994201199; 0.9505404984; -1.084608625];
                      [2.345736454; -0.7999300715; -0.2108674184; -0.05949031575; -0.9647808804; -1.334333; -0.2907434303; -1.384671238];
                      [1.132912775; 1.266098306; -0.4052963446; 0.2732091338; -0.8593275986; 0.2959445964; 1.131030906; 0.6237057257]] |> Matrix
    let gelv1 = [|1.143308114; 0.2893668552; 0.3358615337; -0.0565276359; -2.113193026; -0.1389305892; 0.5123471432; -1.285665356|] |> Vector
    let gelAv1 = [|0.5509872694; 2.14830968; 1.247282381; -6.277875907; -1.398767099; 3.843610664; -2.673286248; -2.7658728|] |> Vector
    let gel1 = TestGaussElimination gelA1 gelv1 gelAv1
    let (_, res, _) = gel1
    Assert.True res
    
    // random dimensions (m = 8, n = 8)
    let gelA2 = array2D [[1.831943968; -0.6187882116; -0.7955710691; 1.081407476; -0.2008691885; 1.304104761; 0.9885276099; 0.03924724812];
                      [-0.7861523477; -0.2530793327; -1.421246809; -0.8094278594; -0.04415732564; -1.174663237; 0.04599991478; -0.2475812812];
                      [0.8078469307; -0.8211539078; -0.8583167381; 0.3612370032; 1.944286459; 0.4329785564; 1.438494787; -0.8885330748];
                      [0.3803865817; 1.151798238; 1.137702698; 0.8966256133; 0.6699931116; 0.570764337; -0.198422875; 0.1628920314];
                      [1.496096573; -0.6408467709; -0.3663841305; -0.4850983266; -1.027137157; 0.2811421436; 0.1523529683; -1.461749684];
                      [0.2364507759; -1.890015474; 0.6238952863; 0.5387726124; 0.1939891664; -0.3887557917; 0.4106619112; -0.1882104976];
                      [-0.1329458832; 0.04188718118; -1.839311949; 1.32965898; 0.01132138748; -0.5110757913; 1.226240576; 0.2870809063];
                      [0.6054661202; -1.595128684; -1.421768357; -0.2803536201; 1.09743792; 1.619218964; 1.262958577; 1.278525799]] |> Matrix
    let gelv2 = [|-0.6352252984; 0.4492326448; -0.3114962455; 0.4509955099; -0.1351854325; 0.2554029969; -0.9875905857; 0.1202341618|] |> Vector
    let gelAv2 = [|4.562735607; 1.684301836; 2.280288432; -3.46331578; 0.2855512307; -4.846659808; 3.87810177; 3.873184384|] |> Vector
    let gel2 = TestGaussElimination gelA2 gelv2 gelAv2
    let (_, res, _) = gel2
    Assert.True res
    
    // random dimensions (m = 6, n = 6)
    let gelA3 = array2D [[-0.4686776137; 0.9506137589; 1.045258484; -0.8030468135; 1.766797337; 0.5157999094];
                      [0.3405563939; -0.09407410629; -1.405957332; 0.6011082883; -0.4975024893; 0.2304169596];
                      [2.016820203; 0.2260583107; -0.8217546788; -0.2477261905; 1.246465431; 0.8432382291];
                      [0.8078590677; -0.004601699253; -0.4280307559; -0.2125860339; -0.3184570104; 0.816226747];
                      [0.9837813346; 0.1989740854; -0.1431536783; 1.940087654; -0.3355540503; 0.5728505096];
                      [0.9379978035; -0.294792999; 0.4916690554; -1.39533337; 1.034115861; -0.8836793867]] |> Matrix
    let gelv3 = [|0.6460249029; -0.2679580706; -0.242013098; 2.79435652; 0.2329041156; 0.3672616273|] |> Vector
    let gelAv3 = [|3.564592529; 12.64238179; 0.6343991235; -3.153736588; -6.416445401; -3.025403768|] |> Vector
    let gel3 = TestGaussElimination gelA3 gelv3 gelAv3
    let (_, res, _) = gel3
    Assert.True res