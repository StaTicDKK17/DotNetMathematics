module TestFunctions

open FSharpMathematics.Core
open BasicExtensions
open GaussExtensions
open AdvancedExtensions

let Tolerance = 1e-3

let compareVectorDimensions (v : Vector) (w : Vector) =
    v.Size = w.Size

// compute L1-distance between arguments. If less than
// Tolerance, they are considered equal.
// v and w must have same size
let CompareVectors (v : Vector) (w : Vector) =
    if compareVectorDimensions v w then
        let vec = Array.zip (v.ToArray()) (w.ToArray())
        let sum = Array.fold (fun acc (v', w') -> acc + abs (v' - w')) 0.0 vec
        (sum / float v.Size) < Tolerance && not (System.Double.IsNaN(sum))
    else
        failwith "ERROR: Vector dimensions must be equal"; false

let compareMatrixDimensions (A : Matrix) (B : Matrix) =
    A.M_Rows = B.M_Rows && A.N_Cols = B.N_Cols

// compute L1-distance between arguments. If less than
// Tolerance, they are considered equal.
// A and B must have same dimensions
let CompareMatrices (A : Matrix) (B : Matrix) =
    if compareMatrixDimensions A B then
        let mat = Array.zip 
                    (A.ToArray() |> Seq.cast<float> |> Seq.toArray) 
                    (B.ToArray() |> Seq.cast<float> |> Seq.toArray)
        let sum = Array.fold (fun acc (a', b') -> acc + abs (a' - b')) 0.0 mat
        (sum / float (A.M_Rows * A.N_Cols)) < Tolerance && not (System.Double.IsNaN(sum))
    else
        failwith "ERROR: Matrix dimensions must be equal"; false

// display a message followed by [PASSED] or [FAILED]
let OutMessage (taskName : string) (subTaskName : string) (status : bool) : string =
    let s = (sprintf "%s %s" taskName subTaskName)
    let res = if status then "[PASSED]" else "[FAILED]"
    sprintf "%-50s %s" s res

// All the tests have the same structure.
// *) check that the implemented method runs
// *) if applicable, check that the result has expected size/dimensions
// *) check that the result has the expected value(s)
// Only if all the tests are successful, the method returns true

let TestRowReplacement (A : Matrix) (i : int) (f : float) (j : int) (expected : Matrix) =
    let taskName = "ElementaryRowReplacement(Matrix, int, float, int)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    let provideContext (Av : Matrix) =
        let l1 = "\n" + (OutMessage taskName "Values" false) + "\n"
        let l2 = "********** Input Matrix **********"
        let l3 = sprintf "\n%A" (A.ToArray())
        let l4 = sprintf "\n\n********** Line to be replaced %i, adding %f multiple of line % i **********\n" i f j
        let l5 = "\n\n******** Actual results ********\n"
        let l6 = sprintf "\n%A\n" (Av.ToArray())
        let l7 = "\n\n********** Expected result **********"
        let l8 = sprintf "\n\n%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8


    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==============================================================================="

    try
        let Av = GaussOps.ElementaryRowReplacement C i f j
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" status
            result <- result + provideContext Av
        else
            result <- result + "\n" + OutMessage taskName "Dims" status
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" status
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" status
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-------------------------------------------------------------------------------\n"
    taskName,status,result


let TestRowInterchange (A : Matrix) (i : int) (j : int) (expected : Matrix) =
    let taskName = "ElementaryRowInterchange(Matrix, int, int)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    let provideContext (Av : Matrix) =
        let l1 = "\n" + OutMessage taskName "Values" false
        let l2 = "\n" + sprintf "\n********** Input Matrix **********\n"
        let l3 = "\n" + sprintf "%A" (A.ToArray())
        let l4 = "\n" + sprintf "\n********** Lines to be interchanged: (%i, %i) **********\n" i j
        let l5 = "\n" + sprintf "\n********** Actual result **********\n"
        let l6 = "\n" + sprintf "%A" (Av.ToArray())
        let l7 = "\n" + sprintf "\n****** Expected result ******\n"
        let l8 = "\n" + sprintf "%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "========================================================================"

    try
        let Av = GaussOps.ElementaryRowInterchange C i j
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message


    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "------------------------------------------------------------------------\n"
    taskName,status,result



let TestRowScaling (A : Matrix) (i : int) (f : float) (expected : Matrix) =
    let taskName = "ElementaryRowScaling(Matrix, int, float)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    let provideContext (Av : Matrix) =
        let l1 = "\n" + OutMessage taskName "Values" false
        let l2 = "\n" + sprintf "\n****** Input Matrix ******\n"
        let l3 = "\n" + sprintf "%A" (A.ToArray())
        let l4 = "\n" + sprintf "\n****** Line to be scaled %i, scale factor %f ******\n" i f
        let l5 = "\n" + sprintf "\n****** Actual result ******\n"
        let l6 = "\n" + sprintf "%A" (Av.ToArray())
        let l7 = "\n" + sprintf "\n****** Expected result ******\n"
        let l8 = "\n" + sprintf "%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "======================================================================"

    try
        let Av = GaussOps.ElementaryRowScaling C i f
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "----------------------------------------------------------------------\n"
    taskName,status,result

let TestForwardReduction (A : Matrix) (expected : Matrix) =
    let taskName = "ForwardReduction(Matrix)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"

    let provideContext (Av : Matrix) =
        let l1 = "\n" + OutMessage taskName "Values" false
        let l2 = "\n" + sprintf "\n********** Input Matrix A **********\n"
        let l3 = "\n" + sprintf "%A" (A.ToArray())
        let l4 = "\n" + sprintf "\n********** Actual result **********\n"
        let l5 = "\n" + sprintf "%A" (Av.ToArray())
        let l6 = "\n" + sprintf "\n********** Expected result **********\n"
        let l7 = "\n" + sprintf "%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7
    try
        let Av = GaussOps.ForwardReduction C
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestBackwardReduction (A : Matrix) (expected : Matrix) =
    let taskName = "BackwardReduction(Matrix)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"

    let provideContext (Av : Matrix) =
        let l1 = "\n" + OutMessage taskName "Values" false
        let l2 = "\n" + sprintf "\n********** Input Matrix **********\n"
        let l3 = "\n" + sprintf "%A" (A.ToArray())
        let l4 = "\n" + sprintf "\n********** Actual result **********\n"
        let l5 = "\n" + sprintf "%A" (Av.ToArray())
        let l6 = "\n" + sprintf "\n********** Expected result **********\n"
        let l7 = "\n" + sprintf "%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7

    try
        let Av = GaussOps.BackwardReduction C
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestGaussElimination (A : Matrix) (v : Vector) (expected : Vector) =
    let taskName = "GaussElimination(Matrix, Vector)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"

    let provideContext (Av : Vector) =
        let l1 =  "\n" + OutMessage taskName "Values" false
        let l2 =  "\n" + sprintf "\n********** Input Matrix **********\n"
        let l3 =  "\n" + sprintf "%A" (A.ToArray())
        let l4 =  "\n" + sprintf "\n********** Input Vector **********\n"
        let l5 =  "\n" + sprintf "%A" (v.ToArray())
        let l6 =  "\n" + sprintf "\n********** Actual result **********\n"
        let l7 =  "\n" + sprintf "%A" (Av.ToArray())
        let l8 = "\n" + sprintf "\n********** Expected result **********\n"
        let l9 =  "\n" + sprintf "%A\n" (expected.ToArray())
        l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8 + l9


    try
        let Av = GaussOps.GaussElimination C v
        if not (compareVectorDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareVectors Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + provideContext Av
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message


    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result


// All the tests have the same structure.
// *) check that the implemented method runs
// *) if applicable, check that the result has expected size/dimensions
// *) check that the result has the expected value(s)
// Only if all the tests are successful, the method returns true

let TestMatrixAugmentation (A : Matrix) (v : Vector) (expected : Matrix) =
    let taskName = "AugmentRight(Matrix, Vector)"
    let mutable status = true
    let mutable result = ""
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==========================================================="
    
    try
        let Av = BasicOps.AugmentRight A v
        if status then
            try
                if not (CompareMatrices Av expected) then
                    result <- result + "\n" + OutMessage taskName "Values" false
                    status <- false
                else
                    result <- result + "\n" + OutMessage taskName "Values" true
                result <- result + "\n" + OutMessage taskName "Dims" true
            with
            | _ -> result <- result + "\n" + OutMessage taskName "Dims" false
                   status <- false
    with
    | _ -> result <- result + "\n" + OutMessage taskName "Run" false
           status <- false 

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestMatrixVectorProduct (A : Matrix) (v : Vector) (expected : Vector) =
    let taskName = "MatVecProduct(Matrix, Vector)"
    let mutable status = true
    let mutable result = ""
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==========================================================="
    
    try
        let Av : Vector = BasicOps.MatVecProduct A v
        if status then
            try
                if not (CompareVectors Av expected) then
                    result <- result + "\n" + OutMessage taskName "Values" false
                    result <- result + "\n" + sprintf "\n****** Input Matrix ******\n"
                    result <- result + "\n" + sprintf "%A" (A.ToArray())
                    result <- result + "\n" + sprintf "\n****** Input Vector ******\n"
                    result <- result + "\n" + sprintf "%A" (v.ToArray())
                    result <- result + "\n" + sprintf "\n****** Actual result ******\n"
                    result <- result + "\n" + sprintf "%A" (Av.ToArray())
                    result <- result + "\n" + sprintf "\n****** Expected result ******\n"
                    result <- result + "\n" + sprintf "%A\n" (expected.ToArray())
                    status <- false
                else
                    result <- result + "\n" + OutMessage taskName "Values" true
                result <- result + "\n" + OutMessage taskName "Dims" true
            with
            | _ -> result <- result + "\n" + OutMessage taskName "Dims" false
                   status <- false
    with
    | _ -> result <- result + "\n" + OutMessage taskName "Run" false
           status <- false

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestMatrixMatrixProduct (A : Matrix) (B : Matrix) (expected : Matrix) =
    let taskName = "MatrixProduct(Matrix, Matrix)"
    let mutable status = true
    let mutable result = ""
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==========================================================="
    
    try
        let ML : Matrix = BasicOps.MatrixProduct A B
        if status then
            try
                if not (CompareMatrices ML expected) then
                    result <- result + "\n" + OutMessage taskName "Values" false
                    result <- result + "\n" + sprintf "\n****** Input Matrix A ******\n"
                    result <- result + "\n" + sprintf "%A" (A.ToArray())
                    result <- result + "\n" + sprintf "\n****** Input Matrix B ******\n"
                    result <- result + "\n" + sprintf "%A" (B.ToArray())
                    result <- result + "\n" + sprintf "\n****** Actual result ******\n"
                    result <- result + "\n" + sprintf "%A" (ML.ToArray())
                    result <- result + "\n" + sprintf "\n****** Expected result ******\n"
                    result <- result + "\n" + sprintf "%A\n" (expected.ToArray())
                    status <- false
                else
                    result <- result + "\n" + OutMessage taskName "Values" true
                result <- result + "\n" + OutMessage taskName "Dims" true
            with
            | _ -> result <- result + "\n" + OutMessage taskName "Dims" false
                   status <- false
    with
    | _ -> result <- result + "\n" + OutMessage taskName "Run" false
           status <- false

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestTranspose (A : Matrix) (expected : Matrix) =
    let taskName = "Transpose(Matrix)"
    let mutable status = true
    let mutable result = ""
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"
    
    try
        let MT : Matrix = BasicOps.Transpose A
        if status then
            try
                if not (CompareMatrices MT expected) then
                    result <- result + "\n" + OutMessage taskName "Values" false
                    result <- result + "\n" + sprintf "\n****** Input Matrix A ******\n"
                    result <- result + "\n" + sprintf "%A" (A.ToArray())
                    result <- result + "\n" + sprintf "\n****** Actual result ******\n"
                    result <- result + "\n" + sprintf "%A" (MT.ToArray())
                    result <- result + "\n" + sprintf "\n****** Expected result ******\n"
                    result <- result + "\n" + sprintf "%A\n" (expected.ToArray())
                    status <- false
                else
                    result <- result + "\n" + OutMessage taskName "Values" true
                result <- result + "\n" + OutMessage taskName "Dims" true
            with
            | _ -> result <- result + "\n" + OutMessage taskName "Dims" false
                   status <- false
    with
    | _ -> result <- result + "\n" + OutMessage taskName "Run" false
           status <- false

    if status then
        result <- result + "\n" + OutMessage taskName "All" true
    
    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestVectorNorm (v : Vector) (expected : float) =
    let taskName = "VectorNorm(Vector)"
    let mutable status = true
    let mutable result = ""
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"
    
    try
        let nv : float = BasicOps.VectorNorm(v)
        if status then
            if abs (nv - expected) > Tolerance || (System.Double.IsNaN(nv)) then
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + "\n" + sprintf "\n****** Input Vector ******\n"
                result <- result + "\n" + sprintf "%A" (v.ToArray())
                result <- result + "\n" + sprintf "\n****** Actual result ******\n"
                result <- result + "\n" + sprintf "%A" (nv)
                result <- result + "\n" + sprintf "\n****** Expected result ******\n"
                result <- result + "\n" + sprintf "%A\n" (expected)
                status <- false
            else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | _ -> result <- result + "\n" + OutMessage taskName "Run" false
           status <- false

    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result

let TestSquareSubMatrix (A : Matrix) (i : int) (j : int) (expected : Matrix) =
    let taskName = "SquareSubMatrix(Matrix, int, int)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    let provideContext (Av : Matrix) =
        let mutable l = [] : string list
        l <- l @ ["\n" + (sprintf "\n****** Input Matrix ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (A.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** line and columns to remove (%d, %d) ******\n" i j)]
        l <- l @ ["\n" + (sprintf "\n****** Actual result ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (Av.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Expected result ******\n")]
        l <- l @ ["\n" + (sprintf "%A\n" (expected.ToArray()))]
        l |> String.concat("")
    
    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==========================================================="
    
    try
        let Av = AdvancedOps.SquareSubMatrix C i j
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)

        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + (provideContext Av)
            else
                result <- result + "\n" + OutMessage taskName "Values" true
              
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message
            
    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName, status, result


let TestDeterminant (A : Matrix) (expected : float) =
    let taskName = "Determinant(Matrix)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)

    let provideContext (Av : float) = 
        let mutable l = [] : string list
        l <- l @ ["\n" + (sprintf "\n****** Input Matrix ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (A.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Actual result ******\n")]
        l <- l @ ["\n" + (sprintf "%.05f" Av)]
        l <- l @ ["\n" + (sprintf "\n****** Expected result ******\n")]
        l <- l @ ["\n" + (sprintf "%.05f\n" expected)]
        l |> String.concat("")

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "==========================================================="
    
    try
        let Av = AdvancedOps.Determinant C
        if abs (Av - expected) > Tolerance || (System.Double.IsNaN(Av)) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Values" false
            result <- result + (provideContext Av)    
        else
                result <- result + "\n" + OutMessage taskName "Values" true
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" status + "\n" + ex.Message
    
    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result




let TestSetColumn (A : Matrix) (v : Vector) (j : int) (expected : Matrix) =
    let taskName = "SetColumn(Matrix, Vector, int)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)
    
    
    let provideContext (Av : Matrix) = 
        let mutable l = [] : string list
        l <- l @ ["\n" + (OutMessage taskName "Values" false)]
        l <- l @ ["\n" + (sprintf "\n****** Input Matrix A ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (A.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Input Vector v ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (v.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Index of column to be set: %i ******\n" j)]
        l <- l @ ["\n" + (sprintf "\n****** Actual result ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (Av.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Expected result ******\n")]
        l <- l @ ["\n" + (sprintf "%A\n" (expected.ToArray()))]
        l |> String.concat("")

    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"
    
    try
        let Av = AdvancedOps.SetColumn C v j
        if not (compareMatrixDimensions Av expected) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext Av)
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices Av expected) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + (provideContext Av)
        
            else
                result <- result + "\n" + OutMessage taskName "Values" true
            
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" false + "\n" + ex.Message
    
    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result





let TestGramSchmidt (A : Matrix)  (expected : Matrix * Matrix) =
    let taskName = "GramSchmidt(Matrix)"
    let mutable status = true
    let mutable result = ""
    // Would otherwise overwrite A
    let C = new Matrix(A)
    let eQ, eR = expected

    let provideContext (Av : Matrix * Matrix) = 
        let mutable l = [] : string list
        l <- l @ ["\n" + (OutMessage taskName "Values" false)]
        l <- l @ ["\n" + (sprintf "\n****** Input Matrix A ******\n")]
        l <- l @ ["\n" + (sprintf "%A" (A.ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Actual result (fst) ******\n")]
        l <- l @ ["\n" + (sprintf "%A" ((fst Av).ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Actual result (snd) ******\n")]
        l <- l @ ["\n" + (sprintf "%A" ((snd Av).ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Expected result (fst) ******\n")]
        l <- l @ ["\n" + (sprintf "%A\n" ((fst expected).ToArray()))]
        l <- l @ ["\n" + (sprintf "\n****** Expected result (snd) ******\n")]
        l <- l @ ["\n" + (sprintf "%A\n" ((snd expected).ToArray()))]
        l |> String.concat("")


    result <- result + "\n" + sprintf "Tests for the %s function" taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------"
    
    try
        let aQ, aR = AdvancedOps.GramSchmidt C
        if not (compareMatrixDimensions eQ aQ) || not (compareMatrixDimensions eR aR) then
            status <- false
            result <- result + "\n" + OutMessage taskName "Dims" false
            result <- result + (provideContext (aQ, aR))
        else
            result <- result + "\n" + OutMessage taskName "Dims" true
            if not (CompareMatrices eQ aQ) || not (CompareMatrices eR aR) then
                status <- false
                result <- result + "\n" + OutMessage taskName "Values" false
                result <- result + (provideContext (aQ, aR))    
            else
                result <- result + "\n" + OutMessage taskName "Values" true
                
    with
    | ex -> status <- false
            result <- result + "\n" + OutMessage taskName "Run" false + "\n" + ex.Message
           
    if status then
        result <- result + "\n" + OutMessage taskName "All" true

    result <- result + "\n" + sprintf "\nEnd of test for the %s function." taskName
    result <- result + "\n" + sprintf "-----------------------------------------------------------\n"
    taskName,status,result