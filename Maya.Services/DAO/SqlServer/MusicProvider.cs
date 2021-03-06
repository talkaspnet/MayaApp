/*
 * Code Generator v1.0
 * 2014-11-07 23:46:08
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
    internal class MusicProvider : ProviderBase, IMusicProvider 
    {
        #region SQLs Statements
        private const string SQL_GET_MUSICS_ALL = "SELECT * FROM Musics";
        private const string SQL_GET_MUSICS_PK = "SELECT * FROM Musics WHERE 1 = 1 AND [MusicId] = @MusicId";
        private const string SQL_DELETE_MUSICS_PK = "DELETE FROM Musics WHERE 1 = 1 AND [MusicId] = @MusicId";
        private const string SQL_GET_MUSICS_BY_DISTRICTID = "SELECT * FROM Musics WHERE [DistrictId] = @DistrictId";
        private const string SQL_DELETE_MUSICS_BY_DISTRICTID = "DELETE FROM Musics WHERE [DistrictId] = @DistrictId";

        private const string PROC_SAVE_MUSIC = "USP_Save_Music";
		private const string PROC_FETCH_MUSIC = "USP_Fetch_Musics";
        #endregion

        #region Fields
        private const string FIELD_MUSICID = "MusicId";
        private const string FIELD_NAME = "Name";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_LINKTO = "LinkTo";
        private const string FIELD_SORTORDER = "SortOrder";
        private const string FIELD_DISTRICTID = "DistrictId";
        #endregion

        #region Methods
        public List<MusicVO> GetItems() {
            return GetSQLResults( SQL_GET_MUSICS_ALL, CommandType.Text, null);
        }

		public List<MusicVO> GetItemsByDistrictCriteria( int districtId) {
			SqlParameter[] p = new SqlParameter[] {
				SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
			};
			return GetSQLResults( PROC_FETCH_MUSIC, CommandType.StoredProcedure, p );
		}

        public MusicVO GetItem(int musicId) {
            MusicVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_MUSICID, SqlDbType.Int, 4, musicId )
            };
            List<MusicVO> items = GetSQLResults( SQL_GET_MUSICS_PK, CommandType.Text, p);
            if (items.Count > 0) item = items[0];
            return item;
        }

        public void DeleteItem(int musicId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_MUSICID, SqlDbType.Int, 4, musicId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_MUSICS_PK, p);
        }

		public List<MusicVO> GetItemsByDistrictId(int districtId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
            };
            return GetSQLResults( SQL_GET_MUSICS_BY_DISTRICTID, CommandType.Text, p);
        }

        public void DeleteItemsByDistrictId(int districtId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, districtId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_MUSICS_BY_DISTRICTID, p);
        }

        public int SaveOrUpdateItem(MusicVO item) {
            SqlParameter[] p = new SqlParameter[] {
                SqlHelper.MakeInParameter( AT + FIELD_MUSICID, SqlDbType.Int, 4, item.MusicId ),
                SqlHelper.MakeInParameter( AT + FIELD_NAME, SqlDbType.NVarChar, 50, item.Name ),
                SqlHelper.MakeInParameter( AT + FIELD_DESCRIPTION, SqlDbType.NVarChar, 255, item.Description ),
                SqlHelper.MakeInParameter( AT + FIELD_LINKTO, SqlDbType.NVarChar, 512, item.LinkTo ),
                SqlHelper.MakeInParameter( AT + FIELD_SORTORDER, SqlDbType.Int, 4, item.SortOrder ),
                SqlHelper.MakeInParameter( AT + FIELD_DISTRICTID, SqlDbType.Int, 4, item.DistrictId ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty ),
                SqlHelper.MakeParameter( AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1 )
            };
            SqlHelper.ExecuteNonQuery( dbConnectionString, CommandType.StoredProcedure, PROC_SAVE_MUSIC, p );
            return Convert.ToInt32( p[p.Length - 1].Value );
        }
        #endregion

        #region Helpers
        private List<MusicVO> GetSQLResults(string sql, CommandType cmdType, SqlParameter[] p) {
            List<MusicVO> entities = new List<MusicVO>();
            IDataReader reader = null;

            try {
                reader = SqlHelper.ExecuteReader( dbConnectionString, cmdType, sql, p );
                while (reader.Read()) {
                    entities.Add( LoadMusic( reader ) );
                }
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            
            return entities;
        }

        private MusicVO LoadMusic(IDataReader reader) {
            MusicVO item = new MusicVO();
            SetBaseProperties(reader, item);

            item.MusicId = ReadInt32( reader, FIELD_MUSICID );
            item.Name = ReadString( reader, FIELD_NAME );
            item.Description = ReadString( reader, FIELD_DESCRIPTION );
            item.LinkTo = ReadString( reader, FIELD_LINKTO );
            item.SortOrder = ReadInt32( reader, FIELD_SORTORDER );
            item.DistrictId = ReadInt32( reader, FIELD_DISTRICTID );
            return item;
        }
        #endregion
    }
}