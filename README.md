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



4. **Basic usage:**
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


5. **Adding custom function:**
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

| Function   Category | Function Name | Purpose                                            | Arguments                          | Return Value          | Example                                   |
|---------------------|---------------|----------------------------------------------------|------------------------------------|-----------------------|-------------------------------------------|
| String              | substring     | Extracts a   substring                             | string,   integer, integer         | String                | substring("hello",   1, 2)                |
| String              | left          | Extracts left part of string                       | string, integer                    | String                | left("hello", 2)                          |
| String              | right         | Extracts right   part of string                    | string,   integer                  | String                | right("hello",   2)                       |
| String              | upper         | Converts string to uppercase                       | string                             | String                | upper("hello")                            |
| String              | lower         | Converts   string to lowercase                     | string                             | String                | lower("HELLO")                            |
| String              | cap           | Capitalizes first letter of each word              | string                             | String                | cap("hello world")                        |
| String              | contain       | Checks if   string contains another string         | string, string                     | Boolean               | contain("hello",   "world")               |
| String              | startwith     | Checks if string starts with another string        | string, string                     | Boolean               | startwith("hello", "he")                  |
| String              | endwith       | Checks if   string ends with another string        | string, string                     | Boolean               | endwith("hello",   "lo")                  |
| String              | replace       | Replaces occurrences of a string                   | string, string, string             | String                | replace("hello", "e", "o")                |
| String              | concat        | Concatenates   strings                             | string, string                     | String                | concat("hello",   "world")                |
| String              | trim          | Removes leading and trailing whitespace            | string                             | String                | trim(" hello world ")                     |
| String              | ltrim         | Removes   leading whitespace                       | string                             | String                | ltrim("   hello world ")                  |
| String              | rtrim         | Removes trailing whitespace                        | string                             | String                | rtrim(" hello world ")                    |
| String              | padleft       | Pads left side   of string                         | string,   integer, char            | String                | padleft("hello",   5, ' ')                |
| String              | padright      | Pads right side of string                          | string, integer, char              | String                | padright("hello", 5, ' ')                 |
| Mathematical        | abs           | Calculates   absolute value                        | numeric                            | Numeric               | abs(-5)                                   |
| Mathematical        | acos          | Calculates arccosine                               | numeric (-1 to 1)                  | Numeric (radians)     | acos(0.5)                                 |
| Mathematical        | acosh         | Calculates   hyperbolic arccosine                  | numeric (>=   1)                   | Numeric               | acosh(1.5)                                |
| Mathematical        | asin          | Calculates arcsine                                 | numeric (-1 to 1)                  | Numeric (radians)     | asin(0.5)                                 |
| Mathematical        | asinh         | Calculates   hyperbolic arcsine                    | numeric                            | Numeric               | asinh(1)                                  |
| Mathematical        | atan          | Calculates arctangent                              | numeric                            | Numeric (radians)     | atan(1)                                   |
| Mathematical        | cbrt          | Calculates   cube root                             | numeric                            | Numeric               | cbrt(8)                                   |
| Mathematical        | ceiling       | Rounds up to nearest integer                       | numeric                            | Integer               | ceiling(3.14)                             |
| Mathematical        | clamp         | Clamps a   number within a range                   | numeric,   numeric, numeric        | Numeric               | clamp(5, 1,   10)                         |
| Mathematical        | cos           | Calculates cosine                                  | numeric (radians)                  | Numeric               | cos(0)                                    |
| Mathematical        | cosh          | Calculates   hyperbolic cosine                     | numeric                            | Numeric               | cosh(1)                                   |
| Mathematical        | exp           | Calculates exponential                             | numeric                            | Numeric               | exp(1)                                    |
| Mathematical        | floor         | Rounds down to   nearest integer                   | numeric                            | Integer               | floor(3.14)                               |
| Mathematical        | log           | Calculates natural logarithm                       | numeric (positive)                 | Numeric               | log(2.71828)                              |
| Mathematical        | log10         | Calculates   base-10 logarithm                     | numeric   (positive)               | Numeric               | log10(100)                                |
| Mathematical        | log2          | Calculates base-2 logarithm                        | numeric (positive)                 | Numeric               | log2(4)                                   |
| Mathematical        | sin           | Calculates   sine                                  | numeric   (radians)                | Numeric               | sin(0)                                    |
| Mathematical        | sinh          | Calculates hyperbolic sine                         | numeric                            | Numeric               | sinh(1)                                   |
| Mathematical        | sqrt          | Calculates   square root                           | numeric   (non-negative)           | Numeric               | sqrt(4)                                   |
| Mathematical        | tan           | Calculates tangent                                 | numeric (radians)                  | Numeric               | tan(0)                                    |
| Mathematical        | tanh          | Calculates   hyperbolic tangent                    | numeric                            | Numeric               | tanh(1)                                   |
| Mathematical        | truncate      | Truncates a number                                 | numeric                            | Numeric               | truncate(3.14)                            |
| Mathematical        | pow           | Calculates   power                                 | numeric,   numeric                 | Numeric               | pow(2, 3)                                 |
| Mathematical        | round         | Rounds a number                                    | numeric, integer (optional)        | Numeric               | round(3.14)                               |
| Mathematical        | atanh         | Calculates   hyperbolic arctangent                 | numeric (-1 to   1)                | Numeric   (radians)   | atanh(0.5)                                |
| Logical             | isnull        | Checks if a value is null                          | value                              | Boolean               | isnull(null)                              |
| Logical             | not           | Performs   logical negation                        | boolean                            | Boolean               | not(true)                                 |
| Logical             | iif           | Implements an if-else conditional                  | condition, true_value, false_value | Any                   | iif(true, "yes", "no")                    |
| Logical             | and           | Performs   logical AND                             | boolean,   boolean                 | Boolean               | and(true,   false)                        |
| Logical             | or            | Performs logical OR                                | boolean, boolean                   | Boolean               | or(true, false)                           |
| Date/Time           | minutesdiff   | Calculates   minutes difference                    | datetime,   datetime               | Integer               | minutesdiff("2023-01-01",   "2023-01-02") |
| Date/Time           | hourdiff      | Calculates hours difference                        | datetime, datetime                 | Integer               | hourdiff("2023-01-01", "2023-01-02")      |
| Date/Time           | daydiff       | Calculates   days difference                       | datetime,   datetime               | Integer               | daydiff("2023-01-01",   "2023-01-02")     |
| Date/Time           | addminutes    | Adds minutes to datetime                           | datetime, integer                  | Datetime              | addminutes("2023-01-01", 30)              |
| Date/Time           | addhours      | Adds hours to   datetime                           | datetime,   integer                | Datetime              | addhours("2023-01-01",   2)               |
| Date/Time           | year          | Extracts year from datetime                        | datetime                           | Integer               | year("2023-01-01")                        |
| Date/Time           | month         | Extracts month   from datetime                     | datetime                           | Integer               | month("2023-01-01")                       |
| Date/Time           | day           | Extracts day from datetime                         | datetime                           | Integer               | day("2023-01-01")                         |
| Date/Time           | hour          | Extracts hour   from datetime                      | datetime                           | Integer               | hour("2023-01-01   12:00:00")             |
| Date/Time           | minutes       | Extracts minutes from datetime                     | datetime                           | Integer               | minutes("2023-01-01 12:00:00")            |
| Date/Time           | seconds       | Extracts   seconds from datetime                   | datetime                           | Integer               | seconds("2023-01-01   12:00:00")          |
| Date/Time           | quarter       | Extracts quarter from datetime                     | datetime                           | Integer               | quarter("2023-01-01")                     |
| Date/Time           | monthname     | Gets month   name from datetime                    | datetime                           | String                | monthname("2023-01-01")                   |
| Date/Time           | quartername   | Gets quarter name from datetime                    | datetime                           | String                | quartername("2023-01-01")                 |
| Date/Time           | dayname       | Gets day name   from datetime                      | datetime                           | String                | dayname("2023-01-01")                     |
| Date/Time           | addays        | Adds days to datetime                              | datetime, integer                  | Datetime              | addays("2023-01-01", 1)                   |
| Date/Time           | addmonths     | Adds months to   datetime                          | datetime,   integer                | Datetime              | addmonths("2023-01-01",                   |
| Date/Time           | addyears      | Adds years to datetime                             | datetime, integer                  | Datetime              | addyears("2023-01-01", 2)                 |
| Conversion          | cstring       | Converts to   string                               | any                                | String                | cstring(123)                              |
| Conversion          | cbyte         | Converts to byte                                   | any                                | Byte                  | cbyte(128)                                |
| Conversion          | cdatetime     | Converts to   datetime                             | any                                | Datetime              | cdatetime("2023-01-01")                   |
| Conversion          | cbool         | Converts to boolean                                | any                                | Boolean               | cbool("true")                             |
| Conversion          | clong         | Converts to   long                                 | any                                | Long                  | clong(1234567890)                         |
| Conversion          | cdecimal      | Converts to decimal                                | any                                | Decimal               | cdecimal("123.45")                        |
| Conversion          | cint          | Converts to   integer                              | any                                | Integer               | cint("123")                               |
| Conversion          | cfloat        | Converts to float                                  | any                                | Float                 | cfloat("123.45")                          |
| Conversion          | cdouble       | Converts to   double                               | any                                | Double                | cdouble("123.45")                         |
| Aggregate           | sum           | Calculates the sum of a column                     | Column name                        | Numeric               | sum(sales)                                |
| Aggregate           | count         | Counts the   number of non-null values in a column | Column name                        | Any data type         | count(sales)                              |
| Aggregate           | countd        | Counts the number of distinct values in a column   | Column name                        | Any data type         | countd(sales)                             |
| Aggregate           | min           | Finds the   minimum value in a column              | Column name                        | Numeric or   Datetime | min(sales)                                |
| Aggregate           | max           | Finds the maximum value in a column                | Column name                        | Numeric or Datetime   | max(sales)                                |
| Aggregate           | first         | Returns the   first value in a column              | Column name                        | Any data type         | first(sales)                              |
| Aggregate           | last          | Returns the last value in a column                 | Column name                        | Any data type         | last(sales)                               |
| Aggregate           | avg           | Calculates the   average value in a column         | Column name                        | Numeric               | avg(sales)                                |
| Aggregate           | var           | Calculates the variance in a column                | Column name                        | Numeric               | var(sales)                                |
| Aggregate           | std           | Calculates the   standard deviation in a column    | Column name                        | Numeric               | std(sales)                                |
| Aggregate           | mean          | Calculates the mean value in a column              | Column name                        | Numeric               | mean(sales)                               |

6. **Roadmap:**

- Further Unit and Functional Testing

- Support Localization

- Implement Excel Financial Functions

- Add User Defined Aggregate Functions Feature

7. **License**

NeonBlue.Expressions is licensed under the MIT License and the Apache License, Version 2.0 (the "Licenses"). You may obtain a copy of the MIT License at https://opensource.org/license/mit and the Apache License, Version 2.0 at https://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed   
 under the Licenses is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the Licenses for the specific language governing permissions and limitations under the   
 Licenses.