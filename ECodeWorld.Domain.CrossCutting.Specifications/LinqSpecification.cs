using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECodeWorld.Domain.CrossCutting.Specifications.Core
{
    public abstract class LinqSpecification<T> : CompositeSpecification<T>
    {
        public abstract Expression<Func<T, bool>> AsExpression();
        public override bool IsSatisfiedBy(T candidate) => AsExpression().Compile()(candidate);
    }
}
