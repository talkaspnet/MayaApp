/*
 * Code Generator v1.0
 * 2014-11-07 23:46:10
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
    internal class UserProvider : ProviderBase, IUserProvider 
    {
        #region SQLs Statements
        private const string SQL_GET_USERS_ALL = "SELECT * FROM Users";
        private const string SQL_GET_USERS_PK = "SELECT * FROM Users WHERE 1 = 1 AND [UserId] = @UserId";
        private const string SQL_DELETE_USERS_PK = "DELETE FROM Users WHERE 1 = 1 AND [UserId] = @UserId";

        private const string SQL_GET_USER_BY_USERNAME = "SELECT * FROM Users WHERE [UserName] = @UserName";
        private const string SQL_DELETE_USER_BY_USERNAME = "DELETE FROM Users WHERE [UserName] = @UserName";        private const string SQL_GET_USER_BY_EMAIL = "SELECT * FROM Users WHERE [Email] = @Email";
        private const string SQL_DELETE_USER_BY_EMAIL = "DELETE FROM Users WHERE [Email] = @Email";
        private const string PROC_SAVE_USER = "USP_Save_User";
        #endregion

        #region Fields
        private const string FIELD_USERID = "UserId";
        private const string FIELD_USERNAME = "UserName";
        private const string FIELD_PASSWORD = "Password";
        private const string FIELD_PASSWORDSALT = "PasswordSalt";
        private const string FIELD_EMAIL = "Email";
        private const string FIELD_EMAILSTATUS = "EmailStatus";
        private const string FIELD_ROLE = "Role";
        #endregion

        #region Methods
        public List<UserVO> GetItems() {
            return GetSQLResults( SQL_GET_USERS_ALL, null);
        }

        public UserVO GetItem(long userId) {
            UserVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_USERID, SqlDbType.BigInt, 8, userId )
            };
            List<UserVO> items = GetSQLResults( SQL_GET_USERS_PK, p);
            if (items.Count > 0) item = items[0];
            return item;
        }

        public void DeleteItem(long userId) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_USERID, SqlDbType.BigInt, 8, userId )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_USERS_PK, p);
        }
                /// <summary>
        /// Get item according to unique key.
        /// </summary>
        public UserVO GetItemByUserName(string userName) {
            UserVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_USERNAME, SqlDbType.NVarChar, 50, userName )
            };
            List<UserVO> items = GetSQLResults( SQL_GET_USER_BY_USERNAME, p);
            if (items.Count > 0) item = items[0];
            return item;
        }
        /// <summary>
        /// Delete item according to unique key.
        /// </summary>
        public void DeleteItemByUserName(string userName) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_USERNAME, SqlDbType.NVarChar, 50, userName )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_USER_BY_USERNAME, p);
        }        /// <summary>
        /// Get item according to unique key.
        /// </summary>
        public UserVO GetItemByEmail(string email) {
            UserVO item = null;
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_EMAIL, SqlDbType.NVarChar, 128, email )
            };
            List<UserVO> items = GetSQLResults( SQL_GET_USER_BY_EMAIL, p);
            if (items.Count > 0) item = items[0];
            return item;
        }
        /// <summary>
        /// Delete item according to unique key.
        /// </summary>
        public void DeleteItemByEmail(string email) {
            SqlParameter[] p = new SqlParameter[] { 
                SqlHelper.MakeInParameter( AT + FIELD_EMAIL, SqlDbType.NVarChar, 128, email )
            };
            SqlHelper.ExecuteNonQuery(dbConnectionString, CommandType.Text, SQL_DELETE_USER_BY_EMAIL, p);
        }
        public int SaveOrUpdateItem(UserVO item) {
            SqlParameter[] p = new SqlParameter[] {
                SqlHelper.MakeInParameter( AT + FIELD_USERID, SqlDbType.BigInt, 8, item.UserId ),
                SqlHelper.MakeInParameter( AT + FIELD_USERNAME, SqlDbType.NVarChar, 50, item.UserName ),
                SqlHelper.MakeInParameter( AT + FIELD_PASSWORD, SqlDbType.NVarChar, 64, item.Password ),
                SqlHelper.MakeInParameter( AT + FIELD_PASSWORDSALT, SqlDbType.NVarChar, 64, item.PasswordSalt ),
                SqlHelper.MakeInParameter( AT + FIELD_EMAIL, SqlDbType.NVarChar, 128, item.Email ),
                SqlHelper.MakeInParameter( AT + FIELD_EMAILSTATUS, SqlDbType.Int, 4, item.EmailStatus ),
                SqlHelper.MakeInParameter( AT + FIELD_ROLE, SqlDbType.Int, 4, item.Role ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate ),
                SqlHelper.MakeInParameter( AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty ),
                SqlHelper.MakeParameter( AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1 )
            };
            SqlHelper.ExecuteNonQuery( dbConnectionString, CommandType.StoredProcedure, PROC_SAVE_USER, p );
            return Convert.ToInt32( p[p.Length - 1].Value );
        }
        #endregion

        #region Helpers
        private List<UserVO> GetSQLResults(string sql, SqlParameter[] p) {
            List<UserVO> entities = new List<UserVO>();
            IDataReader reader = null;

            try {
                reader = SqlHelper.ExecuteReader( dbConnectionString, CommandType.Text, sql, p );
                while (reader.Read()) {
                    entities.Add( LoadUser( reader ) );
                }
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            
            return entities;
        }

        private UserVO LoadUser(IDataReader reader) {
            UserVO item = new UserVO();
            SetBaseProperties(reader, item);

            item.UserId = ReadInt64( reader, FIELD_USERID );
            item.UserName = ReadString( reader, FIELD_USERNAME );
            item.Password = ReadString( reader, FIELD_PASSWORD );
            item.PasswordSalt = ReadString( reader, FIELD_PASSWORDSALT );
            item.Email = ReadString( reader, FIELD_EMAIL );
            item.EmailStatus = ReadInt32( reader, FIELD_EMAILSTATUS );
            item.Role = ReadInt32( reader, FIELD_ROLE );
            return item;
        }
        #endregion
    }
}