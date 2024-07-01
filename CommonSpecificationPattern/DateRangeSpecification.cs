using CommonSpecificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Specification
{
    public class DateRangeSpecification<T> : ISpecification<T> where T : class
    {
        private readonly DateTime? _startDate;
        private readonly DateTime? _endDate;
        private readonly Expression<Func<T, DateTime>> _dateSelector;

        public DateRangeSpecification(DateTime? startDate, DateTime? endDate, Expression<Func<T, DateTime>> dateSelector)
        {
            _startDate = startDate;
            _endDate = endDate;
            _dateSelector = dateSelector;
        }

        public bool IsSatisfiedBy(T entity)
        {
            var compiledSelector = _dateSelector.Compile();
            var date = compiledSelector(entity);

            bool isAfterStart = !_startDate.HasValue || date >= _startDate.Value;
            bool isBeforeEnd = !_endDate.HasValue || date <= _endDate.Value;

            return isAfterStart && isBeforeEnd;
        }

        public Expression<Func<T, bool>> ToExpression()
        {
            var parameter = Expression.Parameter(typeof(T));
            var dateProperty = Expression.Invoke(_dateSelector, parameter);

            var startDateCondition = _startDate.HasValue
                ? Expression.GreaterThanOrEqual(dateProperty, Expression.Constant(_startDate.Value))
                : (Expression)Expression.Constant(true);

            var endDateCondition = _endDate.HasValue
                ? Expression.LessThanOrEqual(dateProperty, Expression.Constant(_endDate.Value))
                : (Expression)Expression.Constant(true);

            var combinedCondition = Expression.AndAlso(startDateCondition, endDateCondition);

            return Expression.Lambda<Func<T, bool>>(combinedCondition, parameter);
        }
    }
}
