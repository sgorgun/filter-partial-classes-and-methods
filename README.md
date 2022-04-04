## Task description ##

- Analyze your solutions of this tasks
    <details>
    <summary>Filter by Digit task</summary>
    
    Implement an `FilterByDigit` method that obtains an array of integers whose elements contain a given digit. The task definition is given in the  XML-comments for this method. Don't use LINQ.
     
     For example, for array `{ 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 } => { 7, 70, 17 } for digit = 7`. 
    </details>
    <details>
    <summary>Filter by Palindromic task</summary>   
    
    Implement a `FilterByPalindromic` method that takes an array of integers and filters it in such a way that the output will be a new array consisting only of elements that are palindromes. If there are no such elements return an empty array. Do not use LINQ queries and delegates.  
    </details>  

    What part of the code can be made reusable? And which part can be customizable depending on the specific way of matching the number with a certain predicate*?    
- Using the `static classes and methods (extension and partial methods recommended)` only, propose the option of allocating reusable code. Do not use delegates, abstact classes, interfaces or LINQ.
- Demonstrate the possibility of using common code with two different predicate of the number. Place solutions in two separate projects:
    - [Filter by Digit](/FilerByDigit);
    - [Filter by Palindromic](/FilterByPalindromic).
- Suggest your custom version of the predicate and place it in separate project.

*A `predicate`  is a statement made about a subject. The subject of the statement is that about which the statement is made. A predicate in programming is an expression that uses one or more values with a boolean result.
