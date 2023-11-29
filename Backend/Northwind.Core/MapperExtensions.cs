namespace Northwind.Core
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Maps the provided source instance into the target using AutoMap.
        /// </summary>
        /// <returns></returns>
        public static T To<T> (this object source)
        {
            Guard.IsNotNull (source, nameof(source));

            var target = MapperModule.Mapper.Map<T>(source);

            return target;
        }

        /// <summary>
        /// Maps the provided enumeration of source items as an enumeration of target items using AutoMap
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TTarget> ToSetOf<TTarget>(this System.Collections.IEnumerable source)
        {
            Guard.IsNotNull(source, nameof(source));

            var list = new List<TTarget>();
            var mapper = MapperModule.Mapper;

            foreach (var sourceItem in source)
            {
                var targetItem = mapper.Map<TTarget>(sourceItem)!;

                list.Add(targetItem);
            }

            return list;
        }
    }
}
