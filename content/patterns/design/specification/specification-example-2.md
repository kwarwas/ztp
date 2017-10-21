## Specification design pattern

Przykładowa implementacja z [LinqKit](https://github.com/scottksmith95/LINQKit):

    public class AndSpecification<T> : Specification<T> {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left,
            Specification<T> right) {
            _right = right; _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression() {
            return _right.ToExpression()
                .And(_left.ToExpression());
        }
    }
