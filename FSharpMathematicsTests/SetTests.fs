module SetTests

open NUnit.Framework
open DotnetMathematics.Set.BinaryOperations
open DotnetMathematics.Set.SetCreation

[<TestFixture>]
type TestClass () =
    
    [<Test>]
    member this.TestSetCreationSize () =
        let s = create_set 5
        Assert.Equals 