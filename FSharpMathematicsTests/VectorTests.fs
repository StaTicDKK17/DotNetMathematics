module VectorTests

open Xunit
open FSharpMathematics.Core

[<Fact>]
let ``Test Vector Float multiplication`` () =
    let v1 = Vector 0
    
    let r1 = v1 * 1.0

    Assert.True (r1.Size = 0)

    let v2 = Vector ([|1.0; 2.0; 3.0|])
    let r2 = v2 * 1.0

    let mutable i = 0
    for element in r2.ToArray() do
        Assert.True (v2.Item (i) = element)
        i <- i + 1
    i <- 0

    let v3 = Vector (v2)
    let r3 = v3 * 2.5

    for element in r3.ToArray() do
        Assert.True (v3.Item (i) * 2.5 = element)
        i <- i + 1
    i <- 0

    let v4 = Vector (xs = null)
    Assert.Throws<System.ArgumentNullException> (fun () -> let r4 = v4 * 3.0
                                                           ())

[<Fact>]
let ``Test Float Vector multiplication`` () =
    let v1 = Vector 0
    
    let r1 = 1.0 * v1

    Assert.True (r1.Size = 0)

    let v2 = Vector ([|1.0; 2.0; 3.0|])
    let r2 = 1.0 * v2

    let mutable i = 0
    for element in r2.ToArray() do
        Assert.True (v2.Item (i) = element)
        i <- i + 1
    i <- 0

    let v3 = Vector (v2)
    let r3 = 2.5 * v3

    for element in r3.ToArray() do
        Assert.True (v3.Item (i) * 2.5 = element)
        i <- i + 1
    i <- 0

    let v4 = Vector (xs = null)
    Assert.Throws<System.ArgumentNullException> (fun () -> let r4 = 3.0 * v4
                                                           ())

[<Fact>]
let ``Test Vector Addition`` () =
    let v1 = Vector 0
    let v2 = Vector 0
    let r1 = v1 + v2

    Assert.True (r1.Size = 0)

    let v3 = Vector([|1.0; 2.0; 3.0|])
    let v4 = Vector([|1.0; 2.0; 3.0|])
    let r2 = v3 + v4

    let mutable i = 0
    for element in r2.ToArray() do
        Assert.True (v3.Item (i) * 2.0 = element)
        i <- i + 1
    i <- 0
    let v5 = Vector([|6.0; 3.0; 7.0|])
    let v6 = Vector([|1.0; 2.0; 3.0|])
    let e1 = Vector([|7.0; 5.0; 10.0|])
    let r3 = v5 + v6

    for element in r3.ToArray() do
        Assert.True (e1.Item (i) = element)
        i <- i + 1
    i <- 0

[<Fact>]
let ``Test Vector Vector Multiplication`` () =
    let v1 = Vector 0
    let v2 = Vector 0

    let r1 = v1 * v2

    Assert.True (0.0 = r1)

    let v3 = Vector (xs = null)
    let v4 = Vector (xs = null)

    Assert.Throws<System.ArgumentNullException> (fun () -> let r2 = v3 * v4
                                                           ())
    
    let v5 = Vector ([|1.0; 2.0; 3.0|])
    let v6 = Vector ([|4.5; 6.0;|])

    Assert.Throws<System.ArgumentException> (fun () -> let r3 = v5 * v6
                                                       ())

    let v7 = Vector ([|1.0; 1.0; 1.0;|])
    let v8 = Vector ([|1.0; 1.0; 1.0;|])

    let r4 = v7 * v8

    Assert.True (3.0 = r4)