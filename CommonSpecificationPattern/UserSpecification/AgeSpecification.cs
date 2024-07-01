using CommonSpecificationPattern;
using Specification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Specification.UserSpecification
{
    public class AgeSpecification : Specification<User>
    {
        private readonly int _age;

        public AgeSpecification(int age)
        {
            _age = age;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Age >= _age;
        }
    }
}
