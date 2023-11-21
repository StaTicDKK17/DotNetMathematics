module SetTests

open NUnit.Framework
open DotnetMathematics.Set.BinaryOperations
open DotnetMathematics.Set.Creation

[<TestFixture>]
type TestClass () =
    
    [<Test>]
    member this.TestSetCreationSize () =
        let s = Set.create_set 5
        Assert.Equals 