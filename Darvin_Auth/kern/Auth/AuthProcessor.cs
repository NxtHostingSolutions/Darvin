using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Darvin_Auth.kern.Auth
{
    class AuthProcessor
    {
        etc.Config config = new etc.Config();
        public string Auth_Token(string token)
        {
            if(token != "")
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = config.ConnectionString();
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand Command;
                SqlDataReader Reader;
                String sql,Output = "";

                sql = "select status from tbl_Auth_Tokens where token='"+token+"'";
                Command = new SqlCommand(sql, cnn);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Output = Output + Reader.GetValue(0) + "\n";
                }
                //cnn.Close();

                // string token_auth = sql.Read
                if (Output != "")
                {
                    return Output;
                }
                else
                {
                    return "failed_not_auth";
                }
            }
            else
            {
                return "failed_token_empty";
            }
        }
    }
}
