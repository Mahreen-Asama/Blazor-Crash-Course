window.Fun1 = function (index) {
    //calling c# method 
    var result = DotNet.invokeMethod("Section8_JSInterop", "ReturnArray", index);
    document.getElementById('p1').innerHTML += result;
}