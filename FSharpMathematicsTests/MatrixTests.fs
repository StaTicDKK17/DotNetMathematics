module MatrixTests

open Xunit
open FSharpMathematics.Core

[<Fact>]
let ``Test Matrix Size`` () =
    let M1 = Matrix(3, 3)
    Assert.True (M1.Size = (3, 3))

    let M2 = Matrix(1, 100)
    Assert.True (M2.Size = (1, 100))

    let M3 = Matrix(420, 69)
    Assert.True (M3.Size = (420, 69))

