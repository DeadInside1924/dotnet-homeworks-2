module Hw5.Calculator

open System

type CalculatorOperation =
    | Add = 0
    | Substract = 1
    | Multiply = 2
    | Divide = 3

[<Literal>]
let add = "+"

[<Literal>]
let substract = "-"

[<Literal>]
let multiply = "*"

[<Literal>]
let divide = "/"

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline calculate value1 operation value2: 'a =
    match operation with
    |CalculatorOperation.Add -> value1 + value2
    |CalculatorOperation.Substract -> value1 - value2
    |CalculatorOperation.Multiply -> value1 * value2
    |CalculatorOperation.Divide -> value1 / value2