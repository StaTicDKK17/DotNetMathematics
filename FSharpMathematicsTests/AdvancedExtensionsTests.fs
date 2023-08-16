module AdvancedExtensionsTests

open Xunit
open TestFunctions
open FSharpMathematics.Core

[<Fact>]
let ``Test Square Sub Matrix`` () =
    // random dimensions (m = 3)
    let ssmA1 = array2D [[ -3.40; -10.20; -11.28]
                         [ 18.44;   2.14;   1.34]
                         [ 19.13;  12.28;   2.98]]|> Matrix
    let ssmi1 = 0
    let ssmj1 = 1
    let ssmAv1 = array2D [[18.44;  1.34]
                          [19.13;  2.98]]|> Matrix
    let ssm1 = TestSquareSubMatrix ssmA1 ssmi1 ssmj1 ssmAv1
    let (_, res, _) = ssm1
    Assert.True res
    
    // random dimensions (m = 6)
    let ssmA2 = array2D [[ 17.69;  -5.75;   3.73; -10.81;  -2.62;  -5.39]
                         [ -2.19;  19.79;   3.80; -15.03;   5.44; -16.76]
                         [-15.64; -18.42;  10.80;  -1.88;   2.76;  15.08]
                         [  7.21; -18.64;  14.11; -16.26;  -8.52;  -0.61]
                         [ 16.31;   0.99;  11.75;   5.75; -16.35;  16.66]
                         [ -0.84;   9.85;  17.53;   4.76;   9.78; -10.27]]|> Matrix
    let ssmi2 = 4
    let ssmj2 = 2
    let ssmAv2 = array2D [[ 17.69;  -5.75; -10.81;  -2.62;  -5.39]
                          [ -2.19;  19.79; -15.03;   5.44; -16.76]
                          [-15.64; -18.42;  -1.88;   2.76;  15.08]
                          [  7.21; -18.64; -16.26;  -8.52;  -0.61]
                          [ -0.84;   9.85;   4.76;   9.78; -10.27]]|> Matrix
    let ssm2 = TestSquareSubMatrix ssmA2 ssmi2 ssmj2 ssmAv2
    let (_, res, _) = ssm2
    Assert.True res
    
    // random dimensions (m = 8)
    let ssmA3 = array2D [[ -3.10;  -8.53;  12.17;   3.32;  -8.38;   4.36; -14.53;  14.07]
                         [  0.56;  10.54;   1.01; -10.48;   7.89;   0.39;  -2.22;   9.40]
                         [ 13.94; -17.23; -15.67;  -7.13;  16.39;   2.86;  12.06;  16.14]
                         [  7.13;   5.81;  15.59; -14.29;  -0.40;  -8.20;   1.06;   7.73]
                         [-11.87; -15.22;  -9.70;   9.89; -18.06;   0.42;  19.86;  15.03]
                         [ 10.83;   6.92;  -8.81;  15.20;   2.64;   7.14;  11.26; -10.54]
                         [ -0.26;  15.35;  15.83; -13.04;   6.05; -18.26;  13.90;  14.04]
                         [ -0.59;  16.03;  16.18;   5.80;   8.76;  19.76;  -5.54; -11.25]]|> Matrix
    let ssmi3 = 1
    let ssmj3 = 6
    let ssmAv3 = array2D [[ -3.10;  -8.53;  12.17;   3.32;  -8.38;   4.36;  14.07]
                          [ 13.94; -17.23; -15.67;  -7.13;  16.39;   2.86;  16.14]
                          [  7.13;   5.81;  15.59; -14.29;  -0.40;  -8.20;   7.73]
                          [-11.87; -15.22;  -9.70;   9.89; -18.06;   0.42;  15.03]
                          [ 10.83;   6.92;  -8.81;  15.20;   2.64;   7.14; -10.54]
                          [ -0.26;  15.35;  15.83; -13.04;   6.05; -18.26;  14.04]
                          [ -0.59;  16.03;  16.18;   5.80;   8.76;  19.76; -11.25]]|> Matrix
    let ssm3 = TestSquareSubMatrix ssmA3 ssmi3 ssmj3 ssmAv3
    let (_, res, _) = ssm3
    Assert.True res


[<Fact>]
let ``Test Determinant`` () =
    // random dimensions (m = 2)
    let detA1 = array2D [[ 3.11; -9.92]
                         [ 7.89;  7.45]]|> Matrix
    let detAv1 = 101.43830000
    let det1 = TestDeterminant detA1 detAv1
    let (_, res, _) = det1
    Assert.True res
    
    // random dimensions (m = 4)
    let detA2 = array2D [[-17.10; -10.70;   2.03; -10.53]
                         [ -8.34;  16.85;  -6.51;  19.99]
                         [ 14.55;   6.12;   5.96;   4.24]
                         [ -4.03;  -5.91; -18.33; -13.62]]|> Matrix
    let detAv2 = 28291.65678309
    let det2 = TestDeterminant detA2 detAv2
    let (_, res, _) = det2
    Assert.True res
    
    // random dimensions (m = 4)
    let detA3 = array2D [[ -3.75;  -9.52; -14.10;   4.23]
                         [ -5.95; -13.74;  11.07;  -7.55]
                         [-17.57;   5.72;   9.36;   5.75]
                         [-11.86;  19.37;  11.85; -12.11]]|> Matrix
    let detAv3 = -115453.22934438
    let det3 = TestDeterminant detA3 detAv3
    let (_, res, _) = det3
    Assert.True res
    
    // Test data for determinant. For TAs
    // dimension (m = 1)
    let detA4 = array2D [[0.00]] |> Matrix
    let detAv4 = 0.00
    let det4 = TestDeterminant detA4 detAv4
    let (_, res, _) = det4
    Assert.True res
    
    // dimension (m = 1)
    let detA5 = array2D [[2.00]] |> Matrix
    let detAv5 = 2.00
    let det5 = TestDeterminant detA5 detAv5
    let (_, res, _) = det5
    Assert.True res
    
    // dimension (m = 3)
    let detA6 = array2D [[ 0.00; 10.00;  0.00]
                         [ 1.00;  0.00;  0.00]
                         [ 0.00;  0.00;  1.00]]|> Matrix
    let detAv6 = -10.00
    let det6 = TestDeterminant detA6 detAv6
    let (_, res, _) = det6
    Assert.True res

[<Fact>]
let ``Test Gram-Schmidt`` () =
    // Gram-Schmidt test: maximal rank matrices m > n
    // random dimensions (m = 6, n = 2)
    let grsA1 = array2D [[ 15.38;  11.60]
                         [ 15.00;  -7.77]
                         [ 13.82;  -2.59]
                         [  1.54;   9.28]
                         [  8.84; -16.97]
                         [ 10.96;  17.01]]|> Matrix
    let grsAv1Q = array2D [[ 0.52654698;  0.34873621]
                           [ 0.51353736; -0.31131101]
                           [ 0.47313909; -0.13086199]
                           [ 0.05272317;  0.31205185]
                           [ 0.30264469; -0.60644111]
                           [ 0.37522463;  0.54698855]]|> Matrix
    let grsAv1R = array2D [[29.20916979;  2.62829107]
                           [ 0.00000000; 29.29458117]]|> Matrix
    let grsAv1 = (grsAv1Q, grsAv1R)
    let grs1 = TestGramSchmidt grsA1 grsAv1
    let (_, res, _) = grs1
    Assert.True res
    
    // random dimensions (m = 4, n = 3)
    let grsA2 = array2D [[  7.92;   3.37;   8.04]
                         [  2.80; -16.38;  -2.74]
                         [  2.23; -10.35;  10.33]
                         [ 17.75;  10.75;  15.91]]|> Matrix
    let grsAv2Q = array2D [[ 0.40073573;  0.01694384;  0.07213336]
                           [ 0.14167425; -0.82618516; -0.54528184]
                           [ 0.11283342; -0.53033962;  0.83359104]
                           [ 0.89811353;  0.18939609; -0.05089662]]|> Matrix
    let grsAv2R = array2D [[19.76364845;  7.51674977; 18.28828321]
                           [ 0.00000000; 21.11503665; -0.06514072]
                           [ 0.00000000;  0.00000000;  9.87525463]]|> Matrix
    let grsAv2 = (grsAv2Q, grsAv2R)
    let grs2 = TestGramSchmidt grsA2 grsAv2
    let (_, res, _) = grs2
    Assert.True res
    
    // random dimensions (m = 4, n = 3)
    let grsA3 = array2D [[ -0.30;  -6.14;  19.11]
                         [  5.35; -13.33; -11.68]
                         [  5.78;  19.94;   9.48]
                         [ 18.17; -18.76; -13.96]]|> Matrix
    let grsAv3Q = array2D [[-0.01514708; -0.23354271;  0.96314313]
                           [ 0.27012286; -0.34139463; -0.19940160]
                           [ 0.29183367;  0.89107580;  0.17969339]
                           [ 0.91740793; -0.18679250;  0.01745260]]|> Matrix
    let grsAv3R = array2D [[ 19.80580218; -14.89914406; -13.48492717]
                           [  0.00000000;  27.25702123;  10.57950995]
                           [  0.00000000;   0.00000000;  22.19453104]]|> Matrix
    let grsAv3 = (grsAv3Q, grsAv3R)
    let grs3 = TestGramSchmidt grsA3 grsAv3
    let (_, res, _) = grs3
    Assert.True res