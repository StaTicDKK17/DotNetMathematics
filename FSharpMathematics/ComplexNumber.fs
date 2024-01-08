namespace DotnetMathematics.ComplexNumber

module ComplexNumber =
    type complex = float * float

module UnaryComplexNumberOperations =
    open ComplexNumber
    let square(c: complex): complex =
        complex(fst c ** 2 - snd c ** 2, 2.0 * fst c * snd c)

    let conjugate(c: complex): complex =
        complex(fst c, -snd c)

    let absolute_value(c: complex): float = 
        fst c ** 2 + snd c ** 2 |> sqrt

module BinaryComplexNumberOperations = 
    open ComplexNumber
    let add(c1: complex) (c2: complex): complex =
        complex(fst c1 + fst c2, snd c1 + snd c2)

    let sub(c1: complex) (c2: complex): complex =
        complex(fst c1 - fst c2, snd c1 - snd c2)

    let product(c1: complex) (c2: complex): complex =
        complex(fst c1 * fst c2 - snd c1 * snd c2, fst c1 * snd c2 + snd c1 * fst c2)

    let quotient(c1: complex) (c2: complex): complex =
        let real = (fst c1 * fst c2 + snd c1 * snd c2) / (fst c2 ** 2 + snd c2 ** 2)
        let imaginary = (snd c1 * fst c2 - fst c1 * snd c2) / (fst c2 ** 2 + snd c2 ** 2)
        complex(real, imaginary)

module TertiaryComplexNumberOperations = 
    open ComplexNumber
    let scalar_mul(lamb: float) (c: complex): complex =
        complex(lamb * fst c, lamb * snd c)

module Rotor =
    open ComplexNumber

    let create(angle: float) =
        complex(cos angle, sin angle)

