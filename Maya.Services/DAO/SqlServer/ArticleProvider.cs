/*
 * Code Generator v1.0
 * 2014-11-07 23:46:09
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
    internal class ArticleProvider : ProviderBase, IArticleProvider 
    {
        #region SQLs Statements
        private const string SQL_GET_ARTICLES_ALL = "SELECT * FROM Articles";
        private const string SQL_GET_ARTICLES_PK = "SELECT * FROM Articles WHERE 1 = 1 AND [ArticleId] = @ArticleId";
        private const string SQL_DELETE_ARTICLES_PK = "DELETE FROM Articles WHERE 1 = 1 AND [ArticleId] = @ArticleId";
        private const string SQL_GET_ARTICLES_BY_DISTRICTID = "SELECT * FROM Articles WHERE [DistrictId] = @DistrictId";
        private const string SQL_DELETE_ARTICLES_BY_DISTRICTID = "DELETE FROM Articles WHERE [DistrictId] = @DistrictId";        private const string SQL_GET_ARTICLES_BY_CATEGORYID = "SELECT * FROM Articles WHERE [CategoryId] = @CategoryId";
        private const string SQL_DELETE_ARTICLES_BY_CATEGORYID = "DELETE FROM Articles WHERE [CategoryId] = @CategoryId";

        private const string PROC_SAVE_ARTICLE = "USP_Save_Article";
		private const string PROC_FETCH_ARTICLES = "USP_Fetch_Articles";
		#endregion

		#region Fields
		private const string FIELD_ARTICLEID = "ArticleId";
        private const string FIELD_TITLE = "Title";
        private const string FIELD_ARTICLECONTENT = "ArticleContent";
        private const string FIELD_TAGS = "Tags";
        private const string FIELD_SORTORDER = "SortOrder";
        private const string FIELD_DISTRICTID = "DistrictId";
        private const string FIELD_CATEGORYID = "CategoryId";
		#endregion

		#region Methods
		public List<ArticleVO> GetItems() {
            return GetSQLResults( SQL_GET_ARTICLES_ALL, CommandType.Text, null);
        }

        public ArticleVO GetItem(int articleId) {
            ArticleVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_ARTICLEID, SqlDbType.Int, 4, articleId )
            };
            List<ArticleVO> items = GetSQLResults( SQL_GET_ARTICLES_PK, CommandType.Text, p);
            if (items.Count > 0) item = items[0];
            return item;
        }

		public List<ArticleVO> GetItems(int categoryId, int districtId ) {
			List<ArticleVO> items = new List<ArticleVO>();
			SqlParameter[] p = new SqlParameter[] {
				SqlHelper.MakeInParameter( AT + FIELD_CATEGORYID, SqlDbType.Int, 4, categoryId ),
				SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
			};
			return GetSQLResults( PROC_FETCH_ARTICLES, CommandType.StoredProcedure, p );
		}

        public void DeleteItem(int articleId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_ARTICLEID, SqlDbType.Int, 4, articleId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_ARTICLES_PK, p);
        }

		public List<ArticleVO> GetItemsByDistrictId(int districtId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
            };
            return GetSQLResults( SQL_GET_ARTICLES_BY_DISTRICTID, CommandType.Text, p);
        }

        public void DeleteItemsByDistrictId(int districtId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_ARTICLES_BY_DISTRICTID, p);
        }

		public List<ArticleVO> GetItemsByCategoryId(int categoryId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_CATEGORYID, SqlDbType.Int, 4, categoryId )
            };
            return GetSQLResults( SQL_GET_ARTICLES_BY_CATEGORYID, CommandType.Text, p);
        }

        public void DeleteItemsByCategoryId(int categoryId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_CATEGORYID, SqlDbType.Int, 4, categoryId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_ARTICLES_BY_CATEGORYID, p);
        }
        public int SaveOrUpdateItem(ArticleVO item) {
            SqlParameter[] p = new SqlParameter[] {
                SqlHelper.MakeInParameter( AT + FIELD_ARTICLEID, SqlDbType.Int, 4, item.ArticleId ),
                SqlHelper.MakeInParameter( AT + FIELD_TITLE, SqlDbType.NVarChar, 50, item.Title ),
                SqlHelper.MakeInParameter( AT + FIELD_ARTICLECONTENT, SqlDbType.NVarChar, -1, item.ArticleContent ),
                SqlHelper.MakeInParameter( AT + FIELD_TAGS, SqlDbType.NVarChar, 50, item.Tags ),
                SqlHelper.MakeInParameter( AT + FIELD_SORTORDER, SqlDbType.Int, 4, item.SortOrder ),
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, item.DistrictId ),
                SqlHelper.MakeInParameter( AT + FIELD_CATEGORYID, SqlDbType.Int, 4, item.CategoryId ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty ),
                SqlHelper.MakeParameter( AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1 )
            };
            SqlHelper.ExecuteNonQuery( dbConnectionString, CommandType.StoredProcedure, PROC_SAVE_ARTICLE, p );
            return Convert.ToInt32( p[p.Length - 1].Value );
        }
        #endregion

        #region Helpers
        private List<ArticleVO> GetSQLResults(string sql, CommandType type, SqlParameter[] p) {
            List<ArticleVO> entities = new List<ArticleVO>();
            IDataReader reader = null;

            try {
                reader = SqlHelper.ExecuteReader( dbConnectionString, type, sql, p );
                while (reader.Read()) {
                    entities.Add( LoadArticle( reader ) );
                }
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            
            return entities;
        }

        private ArticleVO LoadArticle(IDataReader reader) {
            ArticleVO item = new ArticleVO();
            SetBaseProperties(reader, item);

            item.ArticleId = ReadInt32( reader, FIELD_ARTICLEID );
            item.Title = ReadString( reader, FIELD_TITLE );
            item.ArticleContent = ReadString( reader, FIELD_ARTICLECONTENT );
            item.Tags = ReadString( reader, FIELD_TAGS );
            item.SortOrder = ReadInt32( reader, FIELD_SORTORDER );
            item.DistrictId = ReadInt32( reader, FIELD_DISTRICTID );
            item.CategoryId = ReadInt32( reader, FIELD_CATEGORYID );
            return item;
        }
        #endregion
    }
}