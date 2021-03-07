using Dos.User.Api.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dos.User.Api.Data.Specifications
{
    public abstract class BaseSpecification<T>
       : ISpecification<T>
    {
        #region Properties
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        #endregion Properties

        #region Constructors

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
            => Criteria = criteria;

        #endregion Constructors

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
