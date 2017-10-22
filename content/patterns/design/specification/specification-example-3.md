## Specification design pattern

Przykładowa implementacja z [LinqKit](https://github.com/scottksmith95/LINQKit):

    public class FilterSpecification : Specification<Person> {
        private readonly string _filter;

        public FilterSpecification(string filter) {
            _filter = filter;
        }

        public override Expression<Func<Person, bool>> ToExpression() {
            if (!string.IsNullOrWhiteSpace(_filter)) {
                return x => x.FirstName.Contains(_filter) || 
                    x.LastName.Contains(_filter);
            }
            return x => true;
        }
    }
