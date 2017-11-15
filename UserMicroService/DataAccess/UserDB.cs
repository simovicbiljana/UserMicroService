using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {

        public static User ReadDbRow(SqlDataReader reader)
        {
            User retVal = new User();

            retVal.Id = (int)reader["Id"];
            retVal.Name = reader["Name"] as string;
            retVal.Email = reader["Email"] as string;

            return retVal;
        }

        public static User GetUserById(int id)
        {
            try
            {
                User userToReturn = new User();
                using (SqlConnection connection = new SqlConnection (DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                        SELECT 
                            *
                        FROM
                            [user].[User]
                        WHERE
                            [Id] = @Id
                    ");
                    command.Parameters.Add("@Id", SqlDbType.Int, id);
                    command.Parameters["@Id"].Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userToReturn = ReadDbRow(reader);
                        }
                    }
                }
                return userToReturn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }

        
    }
}