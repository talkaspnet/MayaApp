/*
 * Code Generator v1.0
 * 2014-11-07 23:46:07
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Maya.Services.VO;


namespace Maya.Services.DAO.SqlServer 
{
    internal class ProductProvider : ProviderBase, IProductProvider 
    {
        #region SQLs Statements
        private const string SQL_GET_PRODUCTS_ALL = "SELECT * FROM Products";
        private const string SQL_GET_PRODUCTS_PK = "SELECT * FROM Products WHERE 1 = 1 AND [ProductId] = @ProductId";
        private const string SQL_DELETE_PRODUCTS_PK = "DELETE FROM Products WHERE 1 = 1 AND [ProductId] = @ProductId";


        private const string PROC_SAVE_PRODUCT = "USP_Save_Product";
		private const string PROC_FETCH_PRODUCTS = "USP_Fetch_Products";
        #endregion

        #region Fields
        private const string FIELD_PRODUCTID = "ProductId";
        private const string FIELD_NAME = "Name";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_LINKTO = "LinkTo";
        private const string FIELD_PIC = "Pic";
        private const string FIELD_SORTORDER = "SortOrder";
		private const string FIELD_DISTRICTID = "DistrictId";
		#endregion

		#region Methods
		public List<ProductVO> GetItems() {
            return GetSQLResults( SQL_GET_PRODUCTS_ALL, null);
        }

		public List<ProductVO> GetItemsByDistrictCriteria( int districtId ) {
			SqlParameter[] p = new SqlParameter[] {
				SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
			};
			return GetSQLResults( PROC_FETCH_PRODUCTS, CommandType.StoredProcedure, p );
		}

		public ProductVO GetItem(int productId) {
            ProductVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_PRODUCTID, SqlDbType.Int, 4, productId )
            };
            List<ProductVO> items = GetSQLResults( SQL_GET_PRODUCTS_PK, p);
            if (items.Count > 0) item = items[0];
            return item;
        }

        public void DeleteItem(int productId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_PRODUCTID, SqlDbType.Int, 4, productId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_PRODUCTS_PK, p);
        }
        
        public int SaveOrUpdateItem(ProductVO item) {
            SqlParameter[] p = new SqlParameter[] {
                SqlHelper.MakeInParameter( AT + FIELD_PRODUCTID, SqlDbType.Int, 4, item.ProductId ),
                SqlHelper.MakeInParameter( AT + FIELD_NAME, SqlDbType.NVarChar, 50, item.Name ),
                SqlHelper.MakeInParameter( AT + FIELD_DESCRIPTION, SqlDbType.NVarChar, 1024, item.Description ),
                SqlHelper.MakeInParameter( AT + FIELD_LINKTO, SqlDbType.NVarChar, 512, item.LinkTo ),
                SqlHelper.MakeInParameter( AT + FIELD_PIC, SqlDbType.NVarChar, 128, item.Pic ),
                SqlHelper.MakeInParameter( AT + FIELD_SORTORDER, SqlDbType.Int, 4, item.SortOrder ),
				SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, item.DistrictId ),
				SqlHelper.MakeInParameter( AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty ),
                SqlHelper.MakeParameter( AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1 )
            };
            SqlHelper.ExecuteNonQuery( dbConnectionString, CommandType.StoredProcedure, PROC_SAVE_PRODUCT, p );
            return Convert.ToInt32( p[p.Length - 1].Value );
        }
        #endregion

        #region Helpers
        private List<ProductVO> GetSQLResults(string sql, CommandType cmdType, SqlParameter[] p) {
            List<ProductVO> entities = new List<ProductVO>();
            IDataReader reader = null;

            try {
                reader = SqlHelper.ExecuteReader( dbConnectionString, cmdType, sql, p );
                while (reader.Read()) {
                    entities.Add( LoadProduct( reader ) );
                }
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            
            return entities;
        }

		private List<ProductVO> GetSQLResults( string sql, SqlParameter[] p ) {
			return this.GetSQLResults( sql, CommandType.Text, p );
		}

		private ProductVO LoadProduct(IDataReader reader) {
            ProductVO item = new ProductVO();
            SetBaseProperties(reader, item);

            item.ProductId = ReadInt32( reader, FIELD_PRODUCTID );
            item.Name = ReadString( reader, FIELD_NAME );
            item.Description = ReadString( reader, FIELD_DESCRIPTION );
            item.LinkTo = ReadString( reader, FIELD_LINKTO );
            item.Pic = ReadString( reader, FIELD_PIC );
            item.SortOrder = ReadInt32( reader, FIELD_SORTORDER );
			item.DistrictId = ReadInt32( reader, FIELD_DISTRICTID );
			return item;
        }
        #endregion
    }
}