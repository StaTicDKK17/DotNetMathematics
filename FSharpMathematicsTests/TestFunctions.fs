module TestFunctions

open FSharpMathematics.Core
open BasicExtensions

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