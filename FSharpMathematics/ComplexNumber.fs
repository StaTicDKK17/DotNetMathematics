namespace DotnetMathematics

module ComplexNumber =
    type complex = 
        {   Re: double
            Im: double
        }

        static member (+) (left: complex, right: complex) =
            { Re = left.Re + right.Re; Im = left.Im + right.Im }

        static member (-) (left: complex, right: complex) = 
            { Re = left.Re - right.Re; Im = left.Im - right.Im }

        static member (*) (left: complex, right: complex) =
            { Re = left.Re * right.Re - left.Im * right.Im; Im = left.Re * right.Im + left.Im * right.Re}

        static member (/) (left: complex, right: complex) =
            {
                Re = (left.Re * right.Re + left.Im * right.Im) / (right.Re ** 2 + right.Im ** 2);
                Im = (left.Im * right.Re - left.Re * right.Im) / (right.Re ** 2 + right.Im ** 2)
            }
           
        static member (*) (left: float, right: complex) =
            {
                Re = left * right.Re;
                Im = left * right.Im
            }

        static member (*) (left: complex, right: float) =
            {
                Re = right * left.Re;
                Im = right * left.Im
            }
module UnaryComplexNumberOperations =
    open ComplexNumber
    let square(c: complex): complex =
        {
            Re = c.Re ** 2 - c.Im ** 2;
            Im = 2.0 * c.Re * c.Im
        }

    let conjugate(c: complex): complex =
        {
            Re = c.Re;
            Im = -c.Im;
        }

    let absolute_value(c: complex): float = 
        c.Re ** 2 + c.Im ** 2 |> sqrt

module Rotor =
    open ComplexNumber

    let create(angle: float) =
        {
            Re = cos angle;
            Im = sin angle
        }

