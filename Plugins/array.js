const argv = process.argv;
let realArgs = "";
function printArray(){
    argv.forEach((element,index) => {
       if(index > 1){
           console.log(element);
       }
    });
}
printArray();