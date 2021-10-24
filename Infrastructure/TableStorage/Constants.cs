using TableStorage.Entities;

namespace TableStorage
{
    internal static class Constants
    {
        /// <summary>
        /// Table name definitions
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        internal static string TableName(object entity)
        {
            var entityType = entity.GetType();
            return entityType switch
            {
                Type when entityType == typeof(VisitorPropertiesEntity) => "VisitorPropertiesEntity",
                _ => throw new ArgumentException($"No table name defined for type:{entityType}"),
            };
        }
    }
}
