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