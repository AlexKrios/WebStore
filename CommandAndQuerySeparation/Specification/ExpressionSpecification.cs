using System;

namespace CQS.Specification
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> _expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                _expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return _expression(o);
        }
    }
}
