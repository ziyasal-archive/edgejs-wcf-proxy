var edge = require('edge');
var path = require('path');

var proxy = edge.func(path.join(__dirname, 'proxy.cs'));

proxy({url: "net.tcp://localhost:17339", useTcp: true}, function (error, result) {
    if (error) throw error;
    console.log(result);
});