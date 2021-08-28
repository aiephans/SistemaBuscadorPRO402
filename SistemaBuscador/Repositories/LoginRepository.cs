using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public void SetSessionAndCookie(HttpContext context)
        {
            Guid sessionId = Guid.NewGuid();
            context.Session.SetString("sessionId", sessionId.ToString());
            context.Response.Cookies.Append("sessionId", sessionId.ToString());
        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            bool result = false;
            string connectionString = "server=localhost;database=PRO402BD;Integrated Security=true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_user", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@user", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            await sql.OpenAsync();
            int bdResult = (int)cmd.ExecuteScalar();
            if (bdResult > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
