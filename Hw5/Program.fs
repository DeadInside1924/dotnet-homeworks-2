module Hw5.Program

open Hw5

let errorToString (error)=
    match error with
    | Message.WrongArgLength -> "There must be only 3 arguments!"
    | Message.WrongArgFormat -> "One of numbers was incorrect!";
    | Message.WrongArgFormatOperation -> "Wrong operation! "
    | Message.DivideByZero -> "Division by 0!"
    
let calculate (a,operation:Hw5.Calculator.CalculatorOperation, b) =
    Hw5.Calculator.calculate a operation b
    
[<EntryPoint>]
let main (args: string[]) =
    let parsed = Hw5.Parser.parseCalcArguments args
    match parsed with 
    | Ok num -> printf $"{calculate num}"
    | Error err -> printf $"Error occured: {errorToString err}"
    0