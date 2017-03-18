using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CourseResultWebApp.DataAcess {
    public class ViewRoomAllocInfoGateway {
        static readonly string ConnectionString = WebConfigurationManager.ConnectionStrings["CourseResultDBString"].ConnectionString;
        private SqlConnection _connection = new SqlConnection( ConnectionString );
    }
}