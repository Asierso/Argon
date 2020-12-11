const { exec } = require('child_process');

var open;
const args = process.argv;
try{
 open = require('open');
 open(args[2]);
}
catch{
    exec("npm install open",null,function (){
        open = require('open');
        open(args[2]);
    });
}