![Alt text](Images/title.png?raw=true "Title")
# Argon framework
Is a new programming languaje that is easy to use. With basic functionalities for starters. Writed on c#. You can develop plugins in js or modify the Argon core.
Based in MScript for scripts *.arns.

## Syntax
A free code organization. You have to use ";" and define parameters with "". You can organize like this three examples or other ways
```
Instruction "Parameter","Parameter";

Instruction "Parameter" "Parameter";

Instruction ("Parameter","Parameter");
```
Argon brings some functions integrated but you can add your own instructions to Argon core to extend his functions
| Function | Aruments | Details |
| ---------------- | ------------------ | ---------------- |
| print | Text (String)  | Print text in screen |
| print.line  | Text (String)  | Print text in screen and \n |
| font | Color (String)  | Change font color |
| start | FileName (String), ExecutionArgs (String)  | Start a process |
| file.write | FileName (String), Text (String)  | Write an string on a file |
| file.write.line | FileName (String), Text (String)  | Write in a line an string on a file |
| file.read | FileName (String), Variable (Var)  | Read the file |
| file.read.line | FileName (String), Variable (Var)  | Read one line in file |
| var | VariableName (Var), Value (String/Int)  | Create a var to save data |
| function | FunctionName (Function)  | Call to a function |
| function.external | ExternalFile (Arns)  | Call to an external function |
| function.open | FunctionName (Function)  | Open declare of a function |
| function.close | FunctionName (Function)  | Close declare of a function |
| if | ValueA (String/Int), Comparrator (Enum), ValueB (String/Int), Function (Function)  | Conditional |
| network.download.text | Url (String) | Download text of a web |
| network.download.file | Url (String), File (String) | Download a file of a url |
| math.sum | Number (Int), Number (Int), Variable (Var) | Sum 2 numbers |
| math.rest | Number (Int), Number (Int), Variable (Var) | Rest 2 numbers |
| math.multiply | Number (Int), Number (Int), Variable (Var) | Multiply 2 numbers |
| math.divide | Number (Int), Number (Int), Variable (Var) | Divide 2 numbers |
| math.sqrt | Number (Int), Variable (Var) | Sqrt 2 numbers |
| join | Text (String), Text (String), Variable (Var) | Join 2 strings |
| js.run | JSFileName (String), Variable (Var) | Run an .js with node |
| js.run.args |  JSFileName (String), ExecutionArgs (String), Variable (Var) | Run an .js containing arguments with node |
| js.run.print |  JSFileName (String) | Run an .js containing arguments with node amd print them |
| js.run.args.print |  JSFileName (String), ExecutionArgs (String) | Run an .js containing arguments with node and print them |
| wait |  Number (Int) | Wait a lapse of time |
| input |  Variable (Var) | Get text introduced in terminal |


To call variable, if their use is not explicit, you can called using this structure similar like php
```
 Instruction "$Variable";
```
## Wait
Remind that this is only an a experimental version in development. There have bugs and a few things to use. 
More things are comming soon.

## Requirements
- Windows / Linux / MacOS
- .Net Framework +4.0 or Mono
- Node.js (Any version) with npm

## Alert
Some plugins in .js was added to complete the argon functionality. These plugins will be integrated in the Argon c# code
