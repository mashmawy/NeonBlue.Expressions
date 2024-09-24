## **Introduction**

**Overview**

ExpressionEvaluator is a comprehensive library designed to efficiently parse, evaluate, and interpret mathematical expressions in C#. 
It provides a flexible framework for handling various data types, operators, functions, and variables within expressions.


**Target Audience**

This library is primarily aimed at developers and data analysts who need to incorporate expression evaluation capabilities into their applications. 
It is particularly useful for building calculators, scripting languages, data analysis tools, and custom domain-specific languages.

## **Installation**

**NuGet:**

1- Open your Visual Studio project.
2- Right-click on the project and select "Manage NuGet Packages."
3- Search for "NeonBlue.Expressions" and install the package.


**Alternatively:**
1- Download the library's NuGet package from the official repository.
2- Add the package to your project using the Package Manager Console or by manually adding a reference.
3- Install using CLI.
```bash
   dotnet add package NeonBlue.Expressions
```

## **Getting Started**
To get started you first need to import the library namespcae:

```c#
    using NeonBlue.Expressions;
```

**Basic Usage:**

```c#
    Evaluator evaluator = new();
    Expression expression = "2 * (3 + 4) / 5";
    var result = evaluator.Evaluate<int>(expression);
    Console.WriteLine("Result: " + result);
```

**Parameterized expression:**

```c#
        //creating the expression.
        Expression expression = "-1 + (-sum(x )+countd(x2) + (y -2) ) ";
    
        //define values.
        double[] x = [2, 2];
        double[] x2 = [20, 45, 60];
        double y = 10;
        //creating the expression parameters.
        var parameters =  new ExpressionParameters(new ExpressionParameter("x", x),
        new ExpressionParameter("x2", x2),
        new ExpressionParameter("y", y));

        //creating the evaluator object.
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        //evaluate the expression given the parameters and expect double result.
        var result = evaluator.Evaluate<double?>(expression,parameters);

        //display the result
        Console.WriteLine($"the result of the expression is ({result})");
```

**Create Custom Function:**

```c#
        Evaluator evaluator = new();   
        Func<int,int,int> myFunction=(a,b) => a+b;
        // add a custom function
        evaluator.AddCustomFunction("myFunction", myFunction);
        Expression expression = "myFunction(1, 2)"; 
        var result = evaluator.Evaluate(expression);

        Console.WriteLine("Result: " + result);
```
**Common Use Cases:**

* **Calculator applications:** Create advanced calculators with support for various mathematical operations and functions.
* **Scripting and automation:** Implement scripting languages or automation tools that rely on expression evaluation.
* **Data analysis and processing:** Perform complex calculations and transformations on data.
* **Custom domain-specific languages:** Develop DSLs that use expression evaluation for defining rules or logic.
* **Business Rules::** Implement dynamic decision-making logic based on custom conditions.

## **Core Concepts**

**Expressions:**

Expressions are constructed using a combination of variables, constants, operators, and functions. 
The library supports a wide range of expression syntax, including arithmetic operations, logical comparisons, function calls, and parentheses for grouping.

**Evaluation:**

The Evaluate method on the evaluator object is used to parse and evaluate an expression. It returns a Token object representing the result of the evaluation. 
The result can be a numerical value, a string, a datetime, a boolean or null depending on the expression.


**Variables and Constants:**
Variables can be defined and used within expressions to store and manipulate values. 
Constants are predefined values that cannot be changed. 
The library provides mechanisms for managing variables and constants within the evaluation context.


**Functions and Operators:**
The library supports a variety of built-in functions and operators, including:

Arithmetic operators: +, -, *, /, %, ^
Logical operators: &&, ||, !
Comparison operators: ==, !=, <, >, >=, <=
Mathematical functions: sin, cos, tan, log, sqrt, etc.
Datetime functions: adddays, addhours, dayname, etc.
Boolean functions: iif, and, isnull, etc.
String functions: concat, contain, ltrim, left, etc.
You can also define and use custom functions within your expressions.




## **License**
NeonBlue.Expressions is licensed under the MIT License and the Apache License, Version 2.0 (the "Licenses"). You may obtain a copy of the MIT License at https://opensource.org/license/mit and the Apache License, Version 2.0 at https://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the Licenses is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the Licenses for the specific language governing permissions and limitations under the Licenses.