const os = require('os');
switch(process.argv[2]){
    case "-osname":getOSName();break;
    case "-osversion":getOSVersion();break;
    case "-memoryfree":getFreemem(); break;
    case "-memorytotal":getTotalmem(); break;
    case "-os":getOS(); break;
    case "-hostname":getHostname(); break;
}
function getOSName(){
    console.log(os.platform);
}
function getOSVersion(){
    console.log(os.release);
}
function getFreemem(){
    console.log(os.freemem);
}
function getOS(){
    console.log(os.platform + " " + os.release);
}
function getTotalmem(){
    console.log(os.totalmem);
}
function getHostname(){
    console.log(os.hostname);
}