window.Fun1 = function (index) {
    //calling c# method 
    var result = DotNet.invokeMethod("Section8_JSInterop", "ReturnArray", index);
    document.getElementById('p1').innerHTML += result;
}

window.Fun2 = function (number) {
    //calling c# method asynchronouly
    var result = DotNet.invokeMethodAsync("Section8_JSInterop", "CalculateSquareRootAsync", number);
    result.then(function (rzlt) {
        document.getElementById('p2').innerHTML = rzlt;    //when we will get result, it will receive in ''rzlt' parameter, 

    })
}

window.JSFunction = function (name) {
    //calling c# method 
    var result = DotNet.invokeMethod("Section8_JSInterop", "FunctionCaller", name);
}

window.CallClassMethod = function (obj) {
    //calling c# method 
    var result = obj.invokeMethod("SayHello", "this is string");
    alert(result);
}