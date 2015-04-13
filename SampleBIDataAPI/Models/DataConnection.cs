using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataConnection
/// </summary>
public static class DataConnection
{
    
    //public static string GetConnectionString(string database="WSSPBATCH")
    //{
    //    //return BusinessObjectBase.GetConnectionString(BusinessObjectBase.Databases.WSSPBATCH);

    //    string connectionString = BusinessObjectBase.GetConnectionString(BusinessObjectBase.Databases.WSSPBATCH);

    //    //Attempt to update the connection string to determine if the username and password are encrypted:
    //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
    //    builder.InitialCatalog = database;
    //    return builder.ToString();
    //}
    public static string GetSSASConnectionString()
    {

        return String.Format("data source={0};catalog=ACG;cube=ACG", GetServerName());
    }

    //public static bool CanAccessCCG(string ccg, string user)
    //{
    //    bool result = false;
    //    using (SqlConnection con = new SqlConnection(GetConnectionString()))
    //    {
    //        con.Open();
    //        SqlCommand command = new SqlCommand("SELECT acg.dbo.fnCanAccessPct(@UserName, @PctCode)", con);

    //        command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar).Value = user;
    //        command.Parameters.Add("@PctCode", System.Data.SqlDbType.VarChar).Value = ccg;

    //        result = bool.Parse(command.ExecuteScalar().ToString());

    //        con.Close();
    //    }
    //    return result;
    //}
    private static string GetServerName()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OLAPConnection"].ConnectionString;

        //Attempt to update the connection string to determine if the username and password are encrypted:
        //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
        //return builder.DataSource;
        return connectionString;
    }
}