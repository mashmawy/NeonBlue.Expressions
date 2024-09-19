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


| Function   Name | Arguments                          | Return Value          | Example                                   | Function Category |
|-----------------|------------------------------------|-----------------------|-------------------------------------------|-------------------|
| substring       | string,   integer, integer         | String                | substring("hello",   1, 2)                | String            |
| left            | string, integer                    | String                | left("hello", 2)                          | String            |
| right           | string,   integer                  | String                | right("hello",   2)                       | String            |
| upper           | string                             | String                | upper("hello")                            | String            |
| lower           | string                             | String                | lower("HELLO")                            | String            |
| cap             | string                             | String                | cap("hello world")                        | String            |
| contain         | string, string                     | Boolean               | contain("hello",   "world")               | String            |
| startwith       | string, string                     | Boolean               | startwith("hello", "he")                  | String            |
| endwith         | string, string                     | Boolean               | endwith("hello",   "lo")                  | String            |
| replace         | string, string, string             | String                | replace("hello", "e", "o")                | String            |
| concat          | string, string                     | String                | concat("hello",   "world")                | String            |
| trim            | string                             | String                | trim(" hello world ")                     | String            |
| ltrim           | string                             | String                | ltrim("   hello world ")                  | String            |
| rtrim           | string                             | String                | rtrim(" hello world ")                    | String            |
| padleft         | string,   integer, char            | String                | padleft("hello",   5, ' ')                | String            |
| padright        | string, integer, char              | String                | padright("hello", 5, ' ')                 | String            |
| abs             | numeric                            | Numeric               | abs(-5)                                   | Mathematical      |
| acos            | numeric (-1 to 1)                  | Numeric (radians)     | acos(0.5)                                 | Mathematical      |
| acosh           | numeric (>=   1)                   | Numeric               | acosh(1.5)                                | Mathematical      |
| asin            | numeric (-1 to 1)                  | Numeric (radians)     | asin(0.5)                                 | Mathematical      |
| asinh           | numeric                            | Numeric               | asinh(1)                                  | Mathematical      |
| atan            | numeric                            | Numeric (radians)     | atan(1)                                   | Mathematical      |
| cbrt            | numeric                            | Numeric               | cbrt(8)                                   | Mathematical      |
| ceiling         | numeric                            | Integer               | ceiling(3.14)                             | Mathematical      |
| clamp           | numeric,   numeric, numeric        | Numeric               | clamp(5, 1,   10)                         | Mathematical      |
| cos             | numeric (radians)                  | Numeric               | cos(0)                                    | Mathematical      |
| cosh            | numeric                            | Numeric               | cosh(1)                                   | Mathematical      |
| exp             | numeric                            | Numeric               | exp(1)                                    | Mathematical      |
| floor           | numeric                            | Integer               | floor(3.14)                               | Mathematical      |
| log             | numeric (positive)                 | Numeric               | log(2.71828)                              | Mathematical      |
| log10           | numeric   (positive)               | Numeric               | log10(100)                                | Mathematical      |
| log2            | numeric (positive)                 | Numeric               | log2(4)                                   | Mathematical      |
| sin             | numeric   (radians)                | Numeric               | sin(0)                                    | Mathematical      |
| sinh            | numeric                            | Numeric               | sinh(1)                                   | Mathematical      |
| sqrt            | numeric   (non-negative)           | Numeric               | sqrt(4)                                   | Mathematical      |
| tan             | numeric (radians)                  | Numeric               | tan(0)                                    | Mathematical      |
| tanh            | numeric                            | Numeric               | tanh(1)                                   | Mathematical      |
| truncate        | numeric                            | Numeric               | truncate(3.14)                            | Mathematical      |
| pow             | numeric,   numeric                 | Numeric               | pow(2, 3)                                 | Mathematical      |
| round           | numeric, integer (optional)        | Numeric               | round(3.14)                               | Mathematical      |
| atanh           | numeric (-1 to   1)                | Numeric   (radians)   | atanh(0.5)                                | Mathematical      |
| isnull          | value                              | Boolean               | isnull(null)                              | Logical           |
| not             | boolean                            | Boolean               | not(true)                                 | Logical           |
| iif             | condition, true_value, false_value | Any                   | iif(true, "yes", "no")                    | Logical           |
| and             | boolean,   boolean                 | Boolean               | and(true,   false)                        | Logical           |
| or              | boolean, boolean                   | Boolean               | or(true, false)                           | Logical           |
| minutesdiff     | datetime,   datetime               | Integer               | minutesdiff("2023-01-01",   "2023-01-02") | Date/Time         |
| hourdiff        | datetime, datetime                 | Integer               | hourdiff("2023-01-01", "2023-01-02")      | Date/Time         |
| daydiff         | datetime,   datetime               | Integer               | daydiff("2023-01-01",   "2023-01-02")     | Date/Time         |
| addminutes      | datetime, integer                  | Datetime              | addminutes("2023-01-01", 30)              | Date/Time         |
| addhours        | datetime,   integer                | Datetime              | addhours("2023-01-01",   2)               | Date/Time         |
| year            | datetime                           | Integer               | year("2023-01-01")                        | Date/Time         |
| month           | datetime                           | Integer               | month("2023-01-01")                       | Date/Time         |
| day             | datetime                           | Integer               | day("2023-01-01")                         | Date/Time         |
| hour            | datetime                           | Integer               | hour("2023-01-01   12:00:00")             | Date/Time         |
| minutes         | datetime                           | Integer               | minutes("2023-01-01 12:00:00")            | Date/Time         |
| seconds         | datetime                           | Integer               | seconds("2023-01-01   12:00:00")          | Date/Time         |
| quarter         | datetime                           | Integer               | quarter("2023-01-01")                     | Date/Time         |
| monthname       | datetime                           | String                | monthname("2023-01-01")                   | Date/Time         |
| quartername     | datetime                           | String                | quartername("2023-01-01")                 | Date/Time         |
| dayname         | datetime                           | String                | dayname("2023-01-01")                     | Date/Time         |
| addays          | datetime, integer                  | Datetime              | addays("2023-01-01", 1)                   | Date/Time         |
| addmonths       | datetime,   integer                | Datetime              | addmonths("2023-01-01",                   | Date/Time         |
| addyears        | datetime, integer                  | Datetime              | addyears("2023-01-01", 2)                 | Date/Time         |
| cstring         | any                                | String                | cstring(123)                              | Conversion        |
| cbyte           | any                                | Byte                  | cbyte(128)                                | Conversion        |
| cdatetime       | any                                | Datetime              | cdatetime("2023-01-01")                   | Conversion        |
| cbool           | any                                | Boolean               | cbool("true")                             | Conversion        |
| clong           | any                                | Long                  | clong(1234567890)                         | Conversion        |
| cdecimal        | any                                | Decimal               | cdecimal("123.45")                        | Conversion        |
| cint            | any                                | Integer               | cint("123")                               | Conversion        |
| cfloat          | any                                | Float                 | cfloat("123.45")                          | Conversion        |
| cdouble         | any                                | Double                | cdouble("123.45")                         | Conversion        |
| sum             | Column name                        | Numeric               | sum(sales)                                | Aggregate         |
| count           | Column name                        | Any data type         | count(sales)                              | Aggregate         |
| countd          | Column name                        | Any data type         | countd(sales)                             | Aggregate         |
| min             | Column name                        | Numeric or   Datetime | min(sales)                                | Aggregate         |
| max             | Column name                        | Numeric or Datetime   | max(sales)                                | Aggregate         |
| first           | Column name                        | Any data type         | first(sales)                              | Aggregate         |
| last            | Column name                        | Any data type         | last(sales)                               | Aggregate         |
| avg             | Column name                        | Numeric               | avg(sales)                                | Aggregate         |
| var             | Column name                        | Numeric               | var(sales)                                | Aggregate         |
| std             | Column name                        | Numeric               | std(sales)                                | Aggregate         |
| mean            | Column name                        | Numeric               | mean(sales)                               | Aggregate         |


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