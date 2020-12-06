## Argon / Open ARN
# Multiplatform application core
Based in MScript for scripts *.arns.

## Syntax
A free code organization. You have to use ";" and define parameters with "". You can organize like this three examples or other ways
```
Instruction "Parameter","Parameter";

Instruction "Parameter" "Parameter";

Instruction ("Parameter","Parameter");
```
Argon brings some functions integrated but you can add your own instructions to Argon core to extend his functions
| Funtion | Aruments |
| ---------------- | ------------------ |
| print | Text (String)  |
| print.line  | Text (String)  |
| font | Color (String)  |
| start | FileName (String), ExecutionArgs (String)  |
| file.write | FileName (String), Text (String)  |
| file.write.line | FileName (String), Text (String)  |
| file.read | FileName (String), Variable (Var)  |
| file.read.line | FileName (String), Variable (Var)  |
| var | VariableName (Var), Value (String/Int)  |
| function | FunctionName (Function)  |
| function.external | ExternalFile (Arns)  |
| function.open | FunctionName (Function)  |
| function.close | FunctionName (Function)  |
| if | ValueA (String/Int), Comparrator (Enum), ValueB (String/Int), Function (Function)  |
| network.download.text | Url (String) |
| network.download.file | Url (String), File (String) |
| math.sum | Number (Int), Number (Int), Variable (Var) |
| math.rest | Number (Int), Number (Int), Variable (Var) |
| math.multiply | Number (Int), Number (Int), Variable (Var) |
| math.divide | Number (Int), Number (Int), Variable (Var) |
| math.sqrt | Number (Int), Variable (Var) |
| join | Text (String), Text (String), Variable (Var) |

To call variable, if their use is not explicit, you can called using this structure similar like php
```
 Instruction "$Variable";
```
## Wait
Remind that this is only an a experimental version in development. There have bugs and a few things to use. 
More things are comming soon.