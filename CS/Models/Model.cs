using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using CS.Models;
using System.Linq;
using DevExpress.Web.ASPxEditors;
using System.Collections;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;


public static class LargeDatabaseDataProvider {
    static LargeDatabaseDataContextDataContext db;
    public static LargeDatabaseDataContextDataContext DB {
        get {
            if (db == null)
                db = new LargeDatabaseDataContextDataContext();
            return db;
        }
    }
    public static IEnumerable GetProducts() {
        return from product in DB.Products select product;
    }

    public static IEnumerable GetSalesOrderDetails() {
        return from salesOrderDetail in DB.SalesOrderDetails select salesOrderDetail;
    }

    public static IList<Product> GetProductsByFilter(CriteriaOperator filterCriteria) {
        CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();

        IQueryable<Product> source = from product in DB.Products
                                     select product;
        IQueryable<Product> filteredData = source.AppendWhere(converter, filterCriteria) as IQueryable<Product>;

        return filteredData.ToList<Product>();
    }
}
