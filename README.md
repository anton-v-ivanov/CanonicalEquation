# Canonical Equation
Transforms equation to canonical form: yields similar operands and equates the sum to zero.   
The equation can be of any order, can contains any number of variables, can be written with parentheses (in this case, the application should open parentheses according to math rules).   

The equation for the input will be passed as a string in the following format:   
`P1 + P2 + ... = ... + PN`  
Where P1..PN are operands represented as:   
`ax ^ k`  
Where `a` is a float number;   
`k` is an integer;  
`x` is a variable (it can contains several variables for one operand).  


For example, an equation can be given that is:  
`X ^ 2 + 3.5xy + y = y ^ 2 - xy + y`  
It should be transformed to:  
`X ^ 2 - y ^ 2 + 4.5xy = 0`   


The program is a console application and supports two modes of operation - interactive and file.  
In interactive mode, the program prompts you to enter an expression and displays the result. After that, the invitation to enter the expression is repeated. You can quit using the Ctrl+C.  
In the file mode, the program takes the file name as parameter. File should contains the line with the expressions. Program writes the result into a new file with the extension .out added.
