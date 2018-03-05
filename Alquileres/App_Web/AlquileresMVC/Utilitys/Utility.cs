using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AlquileresMVC.Utilitys
{
    public static class Utility
    {
        // Utility method to sort IQueryable given a field name as "string"
        // May consider to put in a central place to be shared
        public static IQueryable<T> Sort<T>(IQueryable<T> data, string fieldName, string sortOrder)
        {
            if (String.IsNullOrEmpty(fieldName) || String.IsNullOrEmpty(sortOrder)) 
                return data;

            var param = Expression.Parameter(typeof(T), "i");

            Expression conversion = Expression.Convert(Expression.Property(param, fieldName), typeof(object));

            var mySortExpression = Expression.Lambda<Func<T, object>>(conversion, param);

            return (sortOrder == "desc") ? data.OrderByDescending(mySortExpression) : data.OrderBy(mySortExpression);
        }

        public static IQueryable<T> Filter<T>(IQueryable<T> data, bool isSearch, string searchField, string operation, string searchValue)
        {
            if (!isSearch || String.IsNullOrEmpty(searchField) || String.IsNullOrEmpty(searchValue))
                return data;

            var filteredData = data;

            if (operation.Equals("cn", StringComparison.OrdinalIgnoreCase))
            {
                filteredData = data.Where(s =>
                (typeof(T).GetProperty(searchField).GetValue(s, null) == null) ? false :
                    typeof(T).GetProperty(searchField).GetValue(s, null).ToString().Contains(searchValue));
            }
            else if (operation.Equals("eq", StringComparison.OrdinalIgnoreCase))
            {
                filteredData = data.Where(s => 
                    (typeof(T).GetProperty(searchField).GetValue(s, null) == null) ? false :
                        (typeof(T).GetProperty(searchField).GetValue(s, null).ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                );
            }
            else if (operation.Equals("ne", StringComparison.OrdinalIgnoreCase))
            {
                filteredData = data.Where(s =>
                    (typeof(T).GetProperty(searchField).GetValue(s, null) == null) ? false :
                        !(typeof(T).GetProperty(searchField).GetValue(s, null).ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase)));
            }
            else if (operation.Equals("bw", StringComparison.OrdinalIgnoreCase))
            {
                filteredData = data.Where(s =>
                    (typeof(T).GetProperty(searchField).GetValue(s, null) == null) ? false :
                        (typeof(T).GetProperty(searchField).GetValue(s, null).ToString().Trim().StartsWith(searchValue, StringComparison.OrdinalIgnoreCase)));
            }
            else if (operation.Equals("ew", StringComparison.OrdinalIgnoreCase))
            {
                filteredData = data.Where(s =>
                    (typeof(T).GetProperty(searchField).GetValue(s, null) == null) ? false :
                        (typeof(T).GetProperty(searchField).GetValue(s, null).ToString().Trim().EndsWith(searchValue, StringComparison.OrdinalIgnoreCase)));
            }

            return filteredData;
        }

        public static IQueryable<T> FilterAndSort<T>(IQueryable<T> data, string sortField, string sortOrder, bool isSearch, string searchField, string operation, string searchString)
        {
            return Utility.Sort<T>(Utility.Filter<T>(data, isSearch, searchField, operation, searchString), sortField, sortOrder);
        }

        public class Entity<TEntity> : System.Data.Objects.DataClasses.EntityObject where TEntity : class, System.Data.Objects.DataClasses.IEntityWithRelationships
        {
            public static TEntity LoadReference(System.Data.Objects.DataClasses.EntityReference<TEntity> reference)
            {
                if (!reference.IsLoaded)
                    reference.Load();
                return reference.Value;
            }
        }

        public class JSON  
        {
            public class SeachAutocomplete
            {
                public static String Sort = "asc";
                public static Int32 Page = 1;
                public static Int32 Rows = 20;
                public static Boolean IsSearch = true;
                public static String SearchOper = "bw";

                public static JsonResult JsonEmpty()
                {
                    JsonResult emptyJson = new JsonResult();
                    emptyJson.Data = new
                    {
                        total = 0,
                        page = 1,
                        records = 0,
                        rows = new { }
                    };
                    emptyJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return emptyJson;
                }
            }
        }
    
    }
}
