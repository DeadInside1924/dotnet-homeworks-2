module Hw5.MaybeBuilder

type MaybeBuilder() =
    member builder.Bind(a, f): Result<'e,'d> =
        match a with
        | Ok x -> f x
        | Error err -> Error err
        
    member builder.Return x: Result<'a,'b> =
        Ok x
let maybe = MaybeBuilder()