namespace DotnetMathematics.Quaternion

open DotnetMathematics.LinAlg.Vectors
open DotnetMathematics.LinAlg.ExportedOperations


module Quaternion =
    type quaternion = float * vector

module TertiaryQuaternionOperations = 
    open Quaternion
    let mul(lamb: float) (q: quaternion): quaternion =
        quaternion(lamb * fst q, lamb * snd q)

module BinaryQuaternionOperations = 
    open Quaternion
    let add(q1: quaternion) (q2: quaternion): quaternion =  
        quaternion(fst q1 + fst q2, snd q1 + snd q2)

    let sub(q1: quaternion) (q2: quaternion): quaternion =
        quaternion(fst q1 - fst q2, snd q1 - snd q2)

    let product(q1: quaternion) (q2: quaternion): quaternion =
        let (xa, ya, za) = ((snd q1).Item(0), (snd q1).Item(1), (snd q1).Item(2))
        let (xb, yb, zb) = ((snd q1).Item(0), (snd q1).Item(1), (snd q1).Item(2))

        let real = (fst q1) * (fst q2) - xa * xb - ya * yb - za * zb
        let i = (fst q1 * xb + fst q2 * xa + ya * zb - yb * za)
        let j = (fst q1 * yb + fst q2 * ya + za * xb - zb * xa)
        let k = (fst q1 * zb + fst q2 * za + xa * yb - xb * ya)
        quaternion(real, new Vector([|i; j; k|]))

module SimplifiedQuaternionOperators =
    open BinaryQuaternionOperations
    open TertiaryQuaternionOperations
    open Quaternion

    let inline (+) (q1: quaternion) (q2: quaternion): quaternion = add q1 q2

    let inline (-) (q1: quaternion) (q2: quaternion): quaternion = sub q1 q2
    
    let inline (*) (q1: quaternion) (q2: quaternion): quaternion = product q1 q2

    let inline (*) (lamb: float) (q: quaternion) = mul lamb q

    let inline (*) (q: quaternion) (lamb: float) = mul lamb q

