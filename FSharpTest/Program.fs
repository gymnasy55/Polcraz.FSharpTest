// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.RegularExpressions
open FParsec

type GeoCoord = {
    lat: float
    long: float
}

type ComplexNumber = {
    real: float
    imaginary: float
}
    
type Color = {
    r: int
    g: int
    b: int
}
    
type Booster =
    | Bomb of int
    | Move of int
    | Rainbow of Color
    
type InventoryItem =
    | Empty
    | Coins of int
    | Energy of int
    | Booster of Booster
    
type Figure =
    | Circle of float
    | Square of float
    | Rectangle of float * float
    
type Result<'TData, 'TError> =
    | Succeed of 'TData
    | Error of 'TError
    
// type Option<'a> =
//     | Some of 'a
//     | None

// type CustomerId = int
// type OrderId = int
    
type CustomerId = CustomerId of int
type OrderId = OrderId of int

type Address = { Street: string; City: string }
type Customer = { ID: int; Name: string; Address: Address }

type Name = { first: string; last: string }

[<EntryPoint>]
let main argv =
    let twoToFive = [2; 3; 4; 5]
    let oneToFive = 1 :: twoToFive
    let zeroToFive = [0; 1] @ twoToFive
    
    let range = [2 .. 5]
    let odds = [1 .. 2 .. 15]
    let square = [for i in 1..5 do yield i * i]
    
//    printfn "twoToFive = %A" twoToFive
//    printfn "oneToFive = %A" oneToFive
//    printfn "zeroToFive = %A" zeroToFive
//    printfn "range = %A" range
//    printfn "odds = %A" odds
//    printfn "square = %A" square

    let letters = ['b' .. 'g']
    let myList = [
        for a in 1 .. 2 do
            for b in 3 .. 4 do
                yield [a; b]
    ] 
    let anotherList = [
        for a in 1 .. 2 do
            for b in 3 .. 4 do
                yield! [a; b]
    ]
    
//    printfn "letters = %A" letters
//    printfn "myList = %A" myList
//    printfn "anotherList = %A" anotherList
    
    let square x = x * x
    let addFive x = x + 5
    
    let evens list =
        let isEven x = x % 2 = 0
        List.filter isEven list
    
    let sumOfSquaresTo100 =
        List.sum (List.map square [1..100])
    
//    printfn "%i" <| square 3
//    printfn "%i" <| addFive 3
//    printfn "%A" <| evens [1..5])   
//    printfn "%i" sumOfSquaresTo100
    
    let twoTuple = 1, 2
    let threeTuple = "a", 1, true
    let x, y = twoTuple
    
//    printfn "%A and %A" x y
//    printfn "%A" threeTuple
    
    let genericTupleFn aTuple =
        let x, y = aTuple
        printfn "x is %A and y is %A" x y
       
//    genericTupleFn (3, "str")
//    genericTupleFn ('a', [])
    
    let myComplexNumber = {
        real= 1.1
        imaginary = 2.2
    }
    
    let myGeoCoord = {
        lat = 1.1
        long = 2.2
    }
    
    let x = myGeoCoord.lat
    let y = myGeoCoord.long
    
//    printfn "%A" myComplexNumber
//    printfn "%A" myGeoCoord
    
    let g1 = {
        lat = 1.1
        long = 2.2
    }
    let g2 = { g1 with lat = 99.9 }
    let g3 = { lat = 1.1; long = 2.2 }
    
//    printfn "%A" g1
//    printfn "%A" g2
//    printfn "%b" <| g1 = g2
//    printfn "%b" <| g1 = g3
//    printfn "%b" <| Object.ReferenceEquals(g1, g3)
    
    let coinsItem = Coins 5
    let rainbow = Rainbow {r = 255; g = 0; b = 0}
    let boosterItem = Booster rainbow
    let emptyItem = Empty
    
//    printfn "%A" coinsItem
//    printfn "%A" rainbow
//    printfn "%A" boosterItem
//    printfn "%A" emptyItem
    
    let circle = Circle 15.0
    let square = Square 10.0
    let rectangle = Rectangle (11.0, 5.0)
    let anotherCircle = Circle 15.0
    
    let area figure =
        let area = 0.0
        area
        
//    printfn "Area of circle is %f" <| area circle
//    printfn "Area of square is %f" <| area square
//    printfn "Area of rectangle is %f" <| area rectangle
//    printfn "%b" <| circle = anotherCircle
//    printfn "%b" <| Object.ReferenceEquals(circle, anotherCircle)
    
    let divideTenBy a =
        if a <> 0 then
            Succeed (10 / a)
        else
            Error "Invalid denominator"
    
    let a = 5
    let b = 0
    
//    printfn "10 / %d = %A" a <| divideTenBy a
//    printfn "10 / %d = %A" b <| divideTenBy b
    
    let optionalStr = Some "string"
    let anotherStr = None

    let checkInput input =
        if Option.isSome input then
            let value = Option.get input
            printfn "valid input: %s" value
        else
            printfn "invalid input"

//    checkInput optionalStr
//    checkInput anotherStr

    let printOrderId (OrderId orderId) =
        printfn "The order id is %i" orderId
        
    let customerId = CustomerId 1
    let orderId = OrderId 2
    
//    printOrderId orderId
    
    let area figure =
        match figure with
        | Square side -> side * side
        | Rectangle (width, height) -> width * height
        | Circle radius -> Math.PI * radius * radius
    
//    printfn "Area of circle is %f" <| area circle
//    printfn "Area of square is %f" <| area square
//    printfn "Area of rectangle is %f" <| area rectangle
    
    let listMatcher aList =
        match aList with
        | [] -> "the list is empty"
        | [first] -> sprintf "the list has one element %A" first
        | [first; second] -> sprintf "list is %A and %A" first second
        | _ -> "the list has more than two elements"
    
//    printfn "%s" <| listMatcher [1..4]
//    printfn "%s" <| listMatcher [1; 2]
//    printfn "%s" <| listMatcher [1]
//    printfn "%s" <| listMatcher []
    
    let a, b, _ = (1, 2, 3)
    
    let elem1 :: elem2 :: rest = [1..10]
    
    let sign value =
        match value with
        | 0 -> 0
        | x when x < 0 -> -1
        | _ -> 1
    
//    printfn "Sign of %i = %i" 0 <| sign 0
//    printfn "Sign of %i = %i" 10 <| sign 10
//    printfn "Sign of %i = %i" -2 <| sign -1
    
    let customer1 = {
        ID = 1
        Name = "Bob"
        Address = {
            Street = "123 Main"
            City = "NY"
        }
    }
    
    let { Name = name1 } = customer1
    let { ID = id2; Name = name2 } = customer1
    let { Name = name3; Address = { Street = street3 } } = customer1
    
//    printfn "The customer is called %s" name1
//    printfn "The customer is called %s has id %i" name2 id2
//    printfn "The customer is called %s and lives on %s" name3 street3
    
    let bob = { first = "bob"; last = "smith" }
    
    let f1 name =
        let { first = f; last = l } = name
        sprintf "first=%s; last=%s" f l
    
    let f2 { first = f; last = l } =
        sprintf "first=%s; last=%s" f l
    
//    printfn "%s" <| f1 bob
//    printfn "%s" <| f2 bob
    
    let bob2 = "bob", "smith"
    
    let f12 name =
        let (f, l) = name
        sprintf "first=%s; last=%s" f l
        
    let f22 (f, l) =
        sprintf "first=%s; last=%s" f l
        
//    printfn "%s" <| f12 bob2
//    printfn "%s" <| f22 bob2
    
    let names = ["bob"; "smith"; "igor"; "ivanov"]
    
    let f13 listNames =
        let f :: l :: _ = listNames
        sprintf "first=%s; last=%s" f l
        
    let f23 (f :: l :: _) =
        sprintf "first=%s; last=%s" f l
     
//    printfn "%s" <| f13 names
//    printfn "%s" <| f23 names   
    
    let (|Int|_|) (str: string) =
        match Int32.TryParse(str) with
        | (true, int) -> Some(int)
        | _ -> None
     
    let (|Bool|_|) (str: string) =
        match Boolean.TryParse(str) with
        | (true, bool) -> Some(bool)
        | _ -> None
        
    let parse str =
        match str with
        | Int i -> sprintf "The value is an int '%i'" i
        | Bool b -> sprintf "The value is a bool '%b'" b
        | _ -> sprintf "The value '%s' is smth else" str
    
//    printfn "%s" <| parse "1234"
//    printfn "%s" <| parse "true"
//    printfn "%s" <| parse "abcd"
    
    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if (m.Success) then Some m.Groups.[1].Value else None
    
    let testRegex str =
        match str with
        | Regex "http://(.*?)/(.*)" host -> sprintf "The value is a url and the host is %s" host
        | Regex ".*?@(.*)" host -> sprintf "The value is an email and the host is %s" host
        | _ -> sprintf "The value '%s' is smth else" str
        
//    printfn "%s" <| testRegex "http://google.com/test"
//    printfn "%s" <| testRegex "alice@test.com"
    
    let (|Even|Odd|) n =
        if n % 2 = 0 then
            Even
        else
            Odd
            
    let test n =
        match n with
        | Even -> sprintf "%i is even" n    
        | Odd -> sprintf "%i is odd" n
        
//    printfn "%s" <| test 5
//    printfn "%s" <| test 6
    
    let (|Contains|) (value: string) (text: string) =
        text.Contains(value)
    
    let testString = function
        | Contains "kitty" true -> "Text contains 'kitty'"
        | Contains "doggy" true -> "Text contains 'doggy'"
        | _ -> "Text neither contains 'kitty' nor 'doggy'"
    
//    printfn "%s" <| testString "I have a pet kitty"
//    printfn "%s" <| testString "I have a pet"
    
    let addOne x = x + 1
    
    let add (x, y) = x + y
    
//    printfn "%i" <| addOne 2
//    printfn "%i" <| add(2, 3)
//    (2, 3) |> add |> printfn "%i"
    
    let add2 x y = x + y
    
//    printfn "%i" <| add2 2 3
    
    let add3 x =
        let subAdd y =
            x + y
        subAdd
    
//    printfn "%i" <| add3 2 3
    
    let x = 6
    let y = 99
    let intermediateFn = (+) x
    
    let z = intermediateFn y
    let add4 = (+) x y
    let result = x + y
    
//    printfn "%i" z
//    printfn "%i" add4
//    printfn "%i" result
    
    let add43 = (+) 43
    let twoIsLessThan = (<) 2
    let printer = printfn "printing param = %i"
    
//    printfn "%i" <| add43 1
//    printfn "%i" <| add43 3
//    printfn "%A" <| List.map add43 [1..3]
//    
//    List.iter printer [1..3]
    
    let addWithLogger logger x y =
        let result = x + y
        logger "x + y" result
        result
    
    let consoleLogger argName argValue =
        printfn "%s = %A" argName argValue
    
    let addAndLog = addWithLogger consoleLogger
    
//    addAndLog 1 2
//    addAndLog 42 99
    
    let list1 = List.map (fun i -> i + 1) [0..3]
    let list2 = List.filter (fun i -> i > 1) [0..3]
    let list3 = List.sortBy (fun i -> -i) [0..3]
    
//    printfn "%A" list1
//    printfn "%A" list2
//    printfn "%A" list3
    
    let result =
        [1..10]
        |> List.map (fun i -> i + 1)
        |> List.filter (fun i -> i > 5)
    
//    printfn "%A" result
   
    let add n x = x + n
    let times n x = x * n
    let add1Times2 = add 1 >> times 2
    let add5Times3 = add 5 >> times 3
    
//    printfn "%i" <| add1Times2 2
//    printfn "%i" <| add5Times3 3
    
    let (.*%) x y = x + y + 1
    let ( *+* ) x y = x * y * 2
    
//    printfn "%i" <| 2 .*% 3
//    printfn "%i" <| 2 *+* 4
     
    let parse parser input =
        match run parser input with
        | Success(result, _, _) -> sprintf "Success: %A" result 
        | Failure(errorMsg, _, _) -> sprintf "Failure: %A" errorMsg 
     
    let str s = pstring s
    let floatBetweenBrackets = str "[" >>. pfloat .>> str "]"
    
//   printfn "%s" <| parse floatBetweenBrackets "[1.23]"
//   printfn "%s" <| parse floatBetweenBrackets "[[1.23]"
    
    0