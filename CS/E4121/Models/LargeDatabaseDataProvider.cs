using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace E4121.Models
{
    public static class LargeDatabaseDataProvider
    {
        static LargeDatabaseDataContext db;
        public static LargeDatabaseDataContext DB
        {
            get
            {
                if (db == null)
                    db = new LargeDatabaseDataContext();
                return db;
            }
        }

        public static IList<Email> GetEmailsByFilter(CriteriaOperator filterCriteria)
        {
            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();

            IQueryable<Email> source = from product in DB.Emails
                                       select product;
            IQueryable<Email> filteredData = source.AppendWhere(converter, filterCriteria) as IQueryable<Email>;

            return filteredData.ToList<Email>();
        }
    }
}