module Hw5.Parser

open System
open Hw5.Calculator
open Hw5.MaybeBuilder

let isArgLengthSupported (args:string[]): Result<'a,'b> =
    match args <> null && args.Length = 3 with
    | true -> Ok(args)
    | _ -> Error Message.WrongArgLength
    
let (|CalculatorOperation|_|) operation =
    match operation with 
    | Calculator.divide -> Some CalculatorOperation.Divide
    | Calculator.multiply -> Some CalculatorOperation.Multiply
    | Calculator.add -> Some CalculatorOperation.Add
    | Calculator.substract -> Some CalculatorOperation.Substract
    | _ -> None
    
let parseOperation (arg1:'a,operation:string, arg2:'b): Result<('a * CalculatorOperation * 'b), Message>= 
    match operation with
    | CalculatorOperation op -> Ok(arg1, op, arg2)
    | _ -> Error Message.WrongArgFormatOperation
    
let (|Double|_|) str =
   match Double.TryParse(str:string) with
   | (true,value) -> Some(value)
   | _ -> None
   
let parseArgs (args: string[]): Result<('a * string * 'b), Message> =
    match args[0] with 
    | Double a1 -> match args[2] with
                   | Double a2 -> Ok(a1, args[1], a2)
                   | _ -> Error Message.WrongArgFormat
    | _ -> Error Message.WrongArgFormat

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isDividingByZero (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), Message> =
    if(operation = CalculatorOperation.Divide && float arg2 = 0)
        then Error Message.DivideByZero
    else
        Ok (arg1, operation, arg2)
    
let parseCalcArguments (args: string[]): Result<'a, 'b> =
    maybe
        {
            let! checkArgscount = isArgLengthSupported args
            let! parsedArgs = parseArgs checkArgscount
            let! parseOperation = parseOperation parsedArgs
            let! checkedDivisionByZerro = isDividingByZero parseOperation
            return checkedDivisionByZerro
        }