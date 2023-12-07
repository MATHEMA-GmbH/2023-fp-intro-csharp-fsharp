module Examples1FSharp.Example01ValueObject.People

type Person1 = {
    FirstName: string
    LastName: string
}

type Person2 = private {
    FirstName: string
    LastName: string
}

module Person2 =
    let isValid (fn: string) (ln: string) =
        fn.Length > 1 && ln.Length > 1
        
    let create (fn: string) (ln: string) =
        if isValid fn ln then
            Some { FirstName = fn; LastName = ln }
        else
            None
            
    let value (p: Person2) = (p.FirstName, p.LastName)
    let FirstName (p: Person2) = p.FirstName
