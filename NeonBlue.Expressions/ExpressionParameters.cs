using System.Linq;

namespace NeonBlue.Expressions
{
    public class ExpressionParameters
    {
        Dictionary<string, ExpressionParameter> Parameters { get; } = [];
        public int MaxLength { get => _maxLength; }

        int _maxLength;
        int _cursor = -1;
        public ExpressionParameters(params ExpressionParameter[] parameters)
        {
            foreach (var item in parameters)
            {
                Parameters.Add(item.Name, item);
            }
            var arrays =
                parameters.Where(p => p.IsArray);
            if (arrays.Any())
            {
                _maxLength = arrays.Max(p => p.ArrayLength);
            }
        }

        public void Add(ExpressionParameter parameter)
        {
            Parameters.Add(parameter.Name, parameter);
            var parameters = Parameters.Values;
            var arrays =
                parameters.Where(p => p.IsArray);
            if (arrays.Any())
            {
                _maxLength = arrays.Max(p => p.ArrayLength);
            }
        }
        public object? GetValue(string name)
        {
            var para = Parameters[name];
            if (para is not null && para.IsArray && para.Value is not null)
            {
                if (para.ArrayLength > _cursor)
                {
                    var array = (Array)para.Value;
                    return array?.GetValue(_cursor);
                }
                else
                {
                    var array = (Array)para.Value;
                    return array?.GetValue(para.ArrayLength - 1);
                }
            }
            else
            {
                return para?.Value;
            }
        }
        public void Remove(string name)
        {
            Parameters.Remove(name);
            var parameters = Parameters.Values;
            var arrays =
                parameters.Where(p => p.IsArray);
            if (arrays.Any())
            {
                _maxLength = arrays.Max(p => p.ArrayLength);
            }
        }
        public Dictionary<string, object?> MoveNext()
        {
            Dictionary<string, object?> updated = [];
            _cursor++;
            foreach (var para in from parameter in Parameters
                                 let para = parameter.Value
                                 where para is not null && parameter.Value.IsArray
                                 select para)
            {
                if (para.Value is null || para.ArrayLength <= _cursor)
                {
                    continue;
                }

                var array = (Array)para.Value;
                updated.Add(para.Name, array?.GetValue(_cursor));
            } 
            return updated;
        }
        public void Reset()
        {
            _cursor = -1;
        }
        public IEnumerable<ExpressionParameter> GetParameters()
        {
            return Parameters.Values;
        }

    }

}