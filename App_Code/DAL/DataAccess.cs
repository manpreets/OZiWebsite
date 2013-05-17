using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace OZiNursing.DAL
{
    public class DataAccess
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["OZiNursingConnection"].ConnectionString;

            
            
            
            return conn;
        }

        public static SqlCommand CreateSqlCommandFromString(string s)
        {
            SqlCommand sc = new SqlCommand(s);
            
                sc.Connection = GetSqlConnection();
            

            return sc;
        }

        public static SqlDataReader GetDB(SqlCommand sc)
        {
            SqlDataReader sdr;
            sc.Connection.Open();

            sdr= sc.ExecuteReader();

           
            return sdr;
        }

        public static int InsertDB(SqlCommand sc)
        {



            sc.Connection.Open();
          int result=  sc.ExecuteNonQuery();

           
                sc.Connection.Close();
            
            return result;


        }

       

        public static int UpdateDB(SqlCommand sc)
        {
            int rowsAffected = 0;
            sc.Connection.Open();
                rowsAffected = sc.ExecuteNonQuery();
            
                sc.Connection.Close();
            

            return rowsAffected;
        }



        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, string tParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, tParamValue);
            sp.SqlDbType = SqlDbType.NVarChar;
            sc.Parameters.Add(sp);
        }
        //Overload string version to use SqlParameter.Size
        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, string tParamValue, int nParamSize)
        {
            SqlParameter sp = new SqlParameter(tParamName, tParamValue);
            sp.SqlDbType = SqlDbType.NVarChar;
            sp.Size = nParamSize;
            sc.Parameters.Add(sp);
        }

        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, int nParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, nParamValue);
            sp.SqlDbType = SqlDbType.Int;
            sc.Parameters.Add(sp);
        }

        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, double nParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, nParamValue);
            sp.SqlDbType = SqlDbType.Decimal;
            sc.Parameters.Add(sp);
        }

        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, bool bParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, bParamValue);
            sp.SqlDbType = SqlDbType.Bit;
            sc.Parameters.Add(sp);
        }


        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, DateTime dParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, dParamValue);
            sp.SqlDbType = SqlDbType.DateTime;
            sc.Parameters.Add(sp);
        }

        public static void AddParamToSqlCommand(SqlCommand sc, string tParamName, Guid gParamValue)
        {
            SqlParameter sp = new SqlParameter(tParamName, gParamValue);
            sp.SqlDbType = SqlDbType.UniqueIdentifier;
            sc.Parameters.Add(sp);
        }


        //Bind DropDownList to enum
        public static void BindDListToEnum(Type enumType, ListControl lc)
        {
            //Get names from enum
            string[] names = Enum.GetNames(enumType);
            //Get values from the enum
            Array values = Enum.GetValues(enumType);

            // turn it into a hash table
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int i = 0; i < names.Length; i++)
                // note the cast to integer here is important
                // otherwise we'll just get the enum string back again
                ht.Add(names[i], (int)values.GetValue(i));
            // return the dictionary to be bound to
            lc.DataSource = ht;
            lc.DataTextField = "Key";
            lc.DataValueField = "Value";
            lc.DataBind();


        }



    }


    
}