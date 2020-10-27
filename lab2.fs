open System

//1
let Fn1()=
    let Func (a, b, c) = (a,b,c)
    let Func_int (a, b, c) = (a+1,b+1,c+1)
    let Func_float (a, b, c) = (a+1.0,b+1.0,c+1.0)
    let Func_string (a, b, c) = (a.ToString(),b.ToString(),c.ToString())
    let q1 = Func(1,2,3)
    let q2 = Func(1,2,3)
    let q3 = Func(1,2,3)
    let q4 = Func(1,2,3)
    printfn "%A" q1
    printfn "%A" q2
    printfn "%A" q3
    printfn "%A" q4

//2
let Fn2()=
    let Func_gen(a,b,c, func)= func(a,b,c)
    let sum_int(a,b,c)=Func_gen(a,b,c,fun(a,b,c)->a+b+c)
    let sum_float(a,b,c)=Func_gen(a,b,c,fun(a,b,c)->a+b+c+0.0)
    let sum_string(a,b,c)=Func_gen(a,b,c,fun(a,b,c)->a+b+c+"")
    let q1 = sum_int(1,2,3)
    let q2 = sum_float(1.0,2.0,3.0)
    let q3 = sum_string("a","b","c")
    printfn "%A" q1
    printfn "%A" q2
    printfn "%A" q3
//3 list comprehension 
let Fn3()=
    let list = [ for a in 1 .. 10 do if a%2=0 then yield (a) ,(a * a),(a * a * a) ]
    printfn "The list: %A" list
//4_1
let Fn4()=
    let rec List_fn1(lst:int list):int list=
            if lst.IsEmpty then []
            else (lst.Head*lst.Head)::List_fn1(lst.Tail)
    let list2  = List_fn1([1..3])
    printfn "The list: %A" list2
    //4_2
    let rec List_fn2 = function
        |[]->[]
        |x::xs -> x*x::List_fn2(xs)
    let list3  = List_fn1([1..3])
    printfn "The list: %A" list3
//5 Последовательно примените к списку функции map, sort, filter, fold, zip,
//функции агрегирования.
//5_1 
let Fn5()=
    let list4_1 =  (List.sum(List.sort((List.map (fun x->x+2+1)(List.filter(fun x->x%2=0) ([2;3;5;6;7;2;3;5;7;8;10;11;13]))))))
    printfn "The list: %A" list4_1
//5_2
    let list4_2 =  (List.fold(fun acc x->acc+x+1) 0 (List.sort((List.map (fun x->x+2)(List.filter(fun x->x%2=0) ([2;3;5;6;7;2;3;5;7;8;10;11;13]))))))
    printfn "The list: %A" list4_2
//5_3
    let list4_3 = List.zip ([2;3;5;6;7;2;3;5;7]) (List.sort((List.map (fun x->x+2)([2;3;5;6;7;2;3;5;7]))))
    printfn "The list: %A" list4_3
//6 
let Fn6()=
//6_1
    let list5_1 =  [2;3;5;6;7;2;3;5;7;8;10;11;13] |> List.filter(fun x->x%2=0) |> List.map (fun x->x+2+1) |> List.sort |> List.sum
    printfn "The list: %A" list5_1
//6_2
    let list5_2 =  [2;3;5;6;7;2;3;5;7;8;10;11;13] |> List.filter(fun x->x%2=0) |> List.map (fun x->x+2) |> List.sort |> List.fold(fun acc x->acc+x+1) 0
    printfn "The list: %A" list5_2
//6_3
    let list5_3 = [2;3;5;6;7;2;3;5;7] |> List.map (fun x->x+2) |> List.sort |> List.zip [2;3;5;6;7;2;3;5;7]
    printfn "The list: %A" list5_3
//7
//7_1
let Fn7()=
    let Func_7_1 = List.filter(fun x->x%2=0) >> List.map (fun x->x+2+1) >> List.sort >> List.sum
    let list6_1 = Func_7_1 [2;3;5;6;7;2;3;5;7;8;10;11;13]
    printfn "The list: %A" list6_1
//7_2
    let Func_7_2 = List.filter(fun x->x%2=0) >> List.map (fun x->x+2) >> List.sort >> List.fold(fun acc x->acc+x+1) 0
    let list6_2 = Func_7_1 [2;3;5;6;7;2;3;5;7;8;10;11;13]
    printfn "The list: %A" list6_2
//7_3
    let Func_7_3  = List.map (fun x->x+2) >>  List.sort >> List.zip [2;3;5;6;7;2;3;5;7]
    let list6_3 = Func_7_3 [2;3;5;6;7;2;3;5;7]
    printfn "The list: %A" list6_3

let menu()=
    let mutable x = 0
    let mutable work = true 
    while work do
        printfn "==================== MENU ====================
        1 - Задание 1
        2 - Задание 2
        3 - С использованием list comprehension для четных элементов вернуть элемент, квадрат и куб в виде списка
        4 - Задание 4
        5 - 3 комбинации map, sort, filter, fold, zip, функции агрегирования
        6 - Реализуйте предыдущий пункт с использованием оператора потока « |> »
        7 - Реализуйте предыдущий пункт с использованием оператора композиции функций « >> »
=============================================="
        x <- int32(System.Console.ReadLine())
        match x with
            | 1 -> Fn1()
            | 2 -> Fn2()
            | 3 -> Fn3()
            | 4 -> Fn4()
            | 5 -> Fn5()
            | 6 -> Fn6()
            | 7 -> Fn7()
            | 8 -> work<-false
    
menu()