namespace Playground.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
            {
                c.Add(e);
            }

            return c;
        }
    }
}