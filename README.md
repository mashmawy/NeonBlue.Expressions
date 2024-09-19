## **NeonBlue.Expressions: A Lightweight and Fast Expression Evaluator**

1. **Description:**
NeonBlue.Expressions is a .NET 8.0 C# library designed to efficiently evaluate expressions. It offers a streamlined solution for .NET developers seeking to avoid the overhead of traditional expression evaluation methods.

2. **Motivation:**
Existing expression evaluation libraries often rely on intermediaries like JavaScript engines or .NET expression trees, introducing additional layers of processing. NeonBlue.Expressions aims to eliminate this overhead by providing a direct, interpreter-based approach.
Also existing expression evaluation libraries often face limitations in handling aggregate functions for large datasets. Traditional approaches iterate over each array or list separately, leading to inefficient performance. .

3. **Key Features:**
* **Direct Interpretation:** NeonBlue.Expressions's interpreter directly executes expressions, minimizing computational overhead.
* **Efficient Aggregate Functions:** NeonBlue.Expressions's optimized aggregation technique significantly improves performance when working with large datasets.
* **Lightweight and Fast:** Designed for performance, NeonBlue.Expressions is optimized for efficient expression evaluation.
* **.NET 8 Compatibility:** Built on the latest .NET framework, ensuring compatibility and access to modern features.
* **Ease of Use:** A straightforward API simplifies integration into .NET applications.

4. **Installation:**
```bash
   dotnet add package NeonBlue.Expressions
```

5. **Basic usage:**
```c#
        //creating the expression.
        Expression expression = "-1 + (-sum(x )+countd(x2) + (y -2) ) ";
    
        //define values.
        double[] x = [2, 2];
        double[] x2 = [20, 45, 60];
        double y = 10;
        //creating the expression parameters.
        var paramaters =  new ExpressionParameters(new ExpressionParameter("x", x), new ExpressionParameter("x2", x2), new ExpressionParameter("y", y));

        //creating the evaluator object.
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        //evaluate the expression given the parameters and expect double result.
        var result = evaluator.Evaluate<double?>(expression,paramaters);

        //display the result
        Console.WriteLine($"the result of the expression is ({result})");
```


6. **Adding custom function:**
```c#
        //creating the expression.
        Expression expression = "multiarg(y,maDate,b)";
        
        //creating the evaluator object.
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        //creating multi argument function.
        Func<int,DateTime,bool, string> multiarg = (a,d,i) => { return $"{i} and {d.ToShortDateString()} {a}"; };

        //register the function with a unique name.
        evaluator.AddCustomFunction("multiarg", multiarg);
 
        //define values.
        int y = 10;
        bool b = false;
        DateTime maDate = DateTime.Now;

        //creating the expression parameters.
        var paramaters= 
        new ExpressionParameters(new ExpressionParameter("y", y),new ExpressionParameter("b", b),new ExpressionParameter("maDate", maDate));

        //evaluate the expression given the parameters and expect string result.
        var result = evaluator.Evaluate<string?>(expression,paramaters);

        //display the result
        Console.WriteLine($"the result of the expression is ({result})");
```

7. **Built-in Functions:**
String Functions :

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| substring       | string,   integer, integer         | String                | substring("hello",   1, 2)                |
| left            | string, integer                    | String                | left("hello", 2)                          |
| right           | string,   integer                  | String                | right("hello",   2)                       |
| upper           | string                             | String                | upper("hello")                            |
| lower           | string                             | String                | lower("HELLO")                            |
| cap             | string                             | String                | cap("hello world")                        |
| contain         | string, string                     | Boolean               | contain("hello",   "world")               |
| startwith       | string, string                     | Boolean               | startwith("hello", "he")                  |
| endwith         | string, string                     | Boolean               | endwith("hello",   "lo")                  |
| replace         | string, string, string             | String                | replace("hello", "e", "o")                |
| concat          | string, string                     | String                | concat("hello",   "world")                |
| trim            | string                             | String                | trim(" hello world ")                     |
| ltrim           | string                             | String                | ltrim("   hello world ")                  |
| rtrim           | string                             | String                | rtrim(" hello world ")                    |
| padleft         | string,   integer, char            | String                | padleft("hello",   5, ' ')                |
| padright        | string, integer, char              | String                | padright("hello", 5, ' ')                 |

Mathematical Functions:

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| abs             | numeric                            | Numeric               | abs(-5)                                   |
| acos            | numeric (-1 to 1)                  | Numeric (radians)     | acos(0.5)                                 |
| acosh           | numeric (>=   1)                   | Numeric               | acosh(1.5)                                |
| asin            | numeric (-1 to 1)                  | Numeric (radians)     | asin(0.5)                                 |
| asinh           | numeric                            | Numeric               | asinh(1)                                  |
| atan            | numeric                            | Numeric (radians)     | atan(1)                                   |
| cbrt            | numeric                            | Numeric               | cbrt(8)                                   |
| ceiling         | numeric                            | Integer               | ceiling(3.14)                             |
| clamp           | numeric,   numeric, numeric        | Numeric               | clamp(5, 1,   10)                         |
| cos             | numeric (radians)                  | Numeric               | cos(0)                                    |
| cosh            | numeric                            | Numeric               | cosh(1)                                   |
| exp             | numeric                            | Numeric               | exp(1)                                    |
| floor           | numeric                            | Integer               | floor(3.14)                               |
| log             | numeric (positive)                 | Numeric               | log(2.71828)                              |
| log10           | numeric   (positive)               | Numeric               | log10(100)                                |
| log2            | numeric (positive)                 | Numeric               | log2(4)                                   |
| sin             | numeric   (radians)                | Numeric               | sin(0)                                    |
| sinh            | numeric                            | Numeric               | sinh(1)                                   |
| sqrt            | numeric   (non-negative)           | Numeric               | sqrt(4)                                   |
| tan             | numeric (radians)                  | Numeric               | tan(0)                                    |
| tanh            | numeric                            | Numeric               | tanh(1)                                   |
| truncate        | numeric                            | Numeric               | truncate(3.14)                            |
| pow             | numeric,   numeric                 | Numeric               | pow(2, 3)                                 |
| round           | numeric, integer (optional)        | Numeric               | round(3.14)                               |
| atanh           | numeric (-1 to   1)                | Numeric   (radians)   | atanh(0.5)                                |

Logical Functions:

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| isnull          | value                              | Boolean               | isnull(null)                              |
| not             | boolean                            | Boolean               | not(true)                                 |
| iif             | condition, true_value, false_value | Any                   | iif(true, "yes", "no")                    |
| and             | boolean,   boolean                 | Boolean               | and(true,   false)                        |
| or              | boolean, boolean                   | Boolean               | or(true, false)                           |

Date/Time Functions:

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| minutesdiff     | datetime,   datetime               | Integer               | minutesdiff("2023-01-01",   "2023-01-02") |
| hourdiff        | datetime, datetime                 | Integer               | hourdiff("2023-01-01", "2023-01-02")      |
| daydiff         | datetime,   datetime               | Integer               | daydiff("2023-01-01",   "2023-01-02")     |
| addminutes      | datetime, integer                  | Datetime              | addminutes("2023-01-01", 30)              |
| addhours        | datetime,   integer                | Datetime              | addhours("2023-01-01",   2)               |
| year            | datetime                           | Integer               | year("2023-01-01")                        |
| month           | datetime                           | Integer               | month("2023-01-01")                       |
| day             | datetime                           | Integer               | day("2023-01-01")                         |
| hour            | datetime                           | Integer               | hour("2023-01-01   12:00:00")             |
| minutes         | datetime                           | Integer               | minutes("2023-01-01 12:00:00")            |
| seconds         | datetime                           | Integer               | seconds("2023-01-01   12:00:00")          |
| quarter         | datetime                           | Integer               | quarter("2023-01-01")                     |
| monthname       | datetime                           | String                | monthname("2023-01-01")                   |
| quartername     | datetime                           | String                | quartername("2023-01-01")                 |
| dayname         | datetime                           | String                | dayname("2023-01-01")                     |
| addays          | datetime, integer                  | Datetime              | addays("2023-01-01", 1)                   |
| addmonths       | datetime,   integer                | Datetime              | addmonths("2023-01-01",                   |
| addyears        | datetime, integer                  | Datetime              | addyears("2023-01-01", 2)                 |

Conversion Functions:

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| cstring         | any                                | String                | cstring(123)                              |
| cbyte           | any                                | Byte                  | cbyte(128)                                |
| cdatetime       | any                                | Datetime              | cdatetime("2023-01-01")                   |
| cbool           | any                                | Boolean               | cbool("true")                             |
| clong           | any                                | Long                  | clong(1234567890)                         |
| cdecimal        | any                                | Decimal               | cdecimal("123.45")                        |
| cint            | any                                | Integer               | cint("123")                               |
| cfloat          | any                                | Float                 | cfloat("123.45")                          |
| cdouble         | any                                | Double                | cdouble("123.45")                         |

Aggregate Functions:

| Function   Name | Arguments                          | Return Value          | Example                                   |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|
| sum             | Column name                        | Numeric               | sum(sales)                                |
| count           | Column name                        | Any data type         | count(sales)                              |
| countd          | Column name                        | Any data type         | countd(sales)                             |
| min             | Column name                        | Numeric or   Datetime | min(sales)                                |
| max             | Column name                        | Numeric or Datetime   | max(sales)                                |
| first           | Column name                        | Any data type         | first(sales)                              |
| last            | Column name                        | Any data type         | last(sales)                               |
| avg             | Column name                        | Numeric               | avg(sales)                                |
| var             | Column name                        | Numeric               | var(sales)                                |
| std             | Column name                        | Numeric               | std(sales)                                |
| mean            | Column name                        | Numeric               | mean(sales)                               |


8. **Operators:**

| Category   | Operator | Meaning                                                 | Example          |
|------------|----------|---------------------------------------------------------|------------------|
| Arithmetic | -        | Subtraction                                             | 5 - 3            |
| Arithmetic | +        | Addition                                                | 5 + 3            |
| Arithmetic | %        | Modulus   (remainder)                                   | 5 % 3            |
| Arithmetic | /        | Division                                                | 5 / 3            |
| Arithmetic | *        | Multiplication                                          | 5 * 3            |
| Comparison | "="      | Assignment                                              | x = 5            |
| Comparison | "=="     | Equality   comparison                                   | x == 5           |
| Comparison | !=       | Inequality comparison                                   | x != 5           |
| Comparison | >        | Greater than                                            | x > 5            |
| Comparison | <        | Less than                                               | x < 5            |
| Comparison | <=       | Less than or   equal to                                 | x <= 5           |
| Comparison | >=       | Greater than or equal to                                | x >= 5           |
| Logical    | &&       | Logical AND                                             | x > 0   && y > 0 |
| Logical    | "\|\|"   | Logical OR                                              | x > 0 \|\| y > 0 |
| Logical    | !        | Logical NOT                                             | !x               | 

9. **Roadmap:**

- Further Unit and Functional Testing

- Support Localization

- Implement Excel Financial Functions

- Add User Defined Aggregate Functions Feature

10. **License**

NeonBlue.Expressions is licensed under the MIT License and the Apache License, Version 2.0 (the "Licenses"). You may obtain a copy of the MIT License at https://opensource.org/license/mit and the Apache License, Version 2.0 at https://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the Licenses is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the Licenses for the specific language governing permissions and limitations under the Licenses.