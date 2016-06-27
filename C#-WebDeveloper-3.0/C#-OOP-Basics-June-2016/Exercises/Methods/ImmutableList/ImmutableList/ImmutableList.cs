namespace ImmutableList
{
    using System.Collections.Generic;
    using System.Linq;

    public class ImmutableList
    {
        private List<int> integers;

        public ImmutableList(List<int> integers)
        {
            this.integers = integers;
        }

        public ImmutableList GetList()
        {
            return new ImmutableList(this.integers.ToList());
        }
    }
}
