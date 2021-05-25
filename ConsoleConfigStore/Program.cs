using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ConsoleConfigStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = System.Configuration.ConfigurationSettings.AppSettings["listValue"].Split(',');
            string constring = string.Empty;
            SqlCommand cmd;
            constring = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write("Message Types are ");
                Console.WriteLine(list[i]);
                string sql = "INSERT INTO MessageTypes(MessageType,Network,MessageFormat,ECLChecking) VALUES('" + list[i] + "','FIN','XML',0)";
                cmd = new SqlCommand(sql, con);
              
                int value = cmd.ExecuteNonQuery();
            }
                    
        }
    }
}