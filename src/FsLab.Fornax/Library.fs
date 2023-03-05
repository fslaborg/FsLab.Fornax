namespace FsLab.Fornax

[<AutoOpen>]
module internal Helpers =

    [<AutoOpen>]
    module List =

        let tryFindDefault (predicate: 'T -> bool) (defaultValue: 'T) (list: 'T List) =
            list
            |> List.tryFind predicate
            |> Option.defaultValue defaultValue