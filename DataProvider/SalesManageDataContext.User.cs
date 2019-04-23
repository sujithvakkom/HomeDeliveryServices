using DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{

    public partial class SalesManageDataContext : DbContext
    {
        public virtual UserDetail getAuthUserDetail(string userName, string password, int group = 8)
        {
            const string SELECT_USER = @"SELECT USER_NAME,ISNULL(FULL_NAME,USER_NAME)FULL_NAME,VEHICLE_CODE,PROFILE
                                            FROM delivery_users
                                            WHERE GROUP_ID = @group_id
                                                  AND
                                                  user_name = @user_name
                                                  AND
                                                  password = @password";

            var _user_name = !string.IsNullOrEmpty(userName) ?
                  new SqlParameter("@user_name", userName) :
                  new SqlParameter("@user_name", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var _password = !string.IsNullOrEmpty(password) ?
                new SqlParameter("@password", password) :
                new SqlParameter("@password", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var _group_id = new SqlParameter("@group_id", group) ;

            var users = this.Database.SqlQuery<UserDetail>(SELECT_USER, _user_name, _password,_group_id).ToList();
            UserDetail detail = users.Count > 0 ? users[0] : null;
            return detail;
        }
    }
}