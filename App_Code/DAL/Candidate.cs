using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OZiNursing.DAL;
using System.Data.SqlClient;

namespace OZiNursing.DAL
{

    /// <summary>
    /// Summary description for Member
    /// </summary>
    public class Candidate
    {
        public Candidate()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static OZiNursing.Objects.Candidate GetCandidateById(int Id)
        {
            OZiNursing.Objects.Candidate thisCandidate = new Objects.Candidate();
            string sqlStr = "SELECT * from Candidate WHERE Id=@Id";

            bool isCandidateFound = false;

            //SQL command created from DAL
            SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

            //Add parameters to the SQLCommand
            DataAccess.AddParamToSqlCommand(sc, "@Id", Id);

            SqlDataReader sdr = DataAccess.GetDB(sc);

            if (sdr.Read())
            {
                isCandidateFound = true;
                thisCandidate.GetCandidateProfileFromReaderRow(sdr);
               
            }
            sc.Connection.Close();
            sdr.Close();
            sdr.Dispose();

            if (isCandidateFound== true)
            {

                return thisCandidate;
            }
            else
            {
                return null;
            }

        }




        public static int InsertCandidate( OZiNursing.Objects.Candidate thisCandidate)
        {
            string sqlstr = "INSERT INTO Candidate( ";
            sqlstr += "UserId,FirstName,LastName,DateofBirth,Address,PostCode,Suburb,State,HomePhone,Mobile,Email,JobsApplied,DateLastVisited";
            sqlstr += ") VALUES (";
            sqlstr += "@UserId,@FirstName,@LastName,@DateofBirth,@Address,@PostCode,@Suburb,@State,@HomePhone,@Mobile,@Email,@JobsApplied,@DateLastVisited";
            sqlstr += ")";

            SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlstr);

            DataAccess.AddParamToSqlCommand(sc, "@UserId", thisCandidate.UserId);
            DataAccess.AddParamToSqlCommand(sc, "@FirstName", thisCandidate.FirstName);
            DataAccess.AddParamToSqlCommand(sc, "@LastName", thisCandidate.LastName);
            DataAccess.AddParamToSqlCommand(sc, "@DateofBirth", thisCandidate.DateofBirth);
            DataAccess.AddParamToSqlCommand(sc, "@Address", thisCandidate.Address);
            DataAccess.AddParamToSqlCommand(sc, "@PostCode", thisCandidate.PostCode);

            DataAccess.AddParamToSqlCommand(sc, "@Suburb", thisCandidate.Suburb);
            DataAccess.AddParamToSqlCommand(sc, "@State", thisCandidate.State);
            DataAccess.AddParamToSqlCommand(sc, "@HomePhone", thisCandidate.HomePhone);
            DataAccess.AddParamToSqlCommand(sc, "@Mobile", thisCandidate.Mobile);
            DataAccess.AddParamToSqlCommand(sc, "@Email", thisCandidate.Email);
            DataAccess.AddParamToSqlCommand(sc, "@JobsApplied", thisCandidate.JobsApplied);
            DataAccess.AddParamToSqlCommand(sc, "@DateLAstVisited", thisCandidate.DateLastVisited);


            return DataAccess.InsertDB(sc);


            
        }

        public static int UpdateCandidate(OZiNursing.Objects.Candidate thisCandidate)
        {
            string sqlstr = "Update Candidate SET ";
            sqlstr += "FirstName=@FirstName,LastName=@LastName,DateofBirth=@DateofBirth,Address=@Address,PostCode=@PostCode,Suburb=@Suburb,";
            sqlstr += "State=@State,HomePhone=@HomePhone,Mobile=@Mobile,Email=@Email ";
            sqlstr += "WHERE Id=@Id";

            SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlstr);
            DataAccess.AddParamToSqlCommand(sc, "@Id", thisCandidate.Id);
            //DataAccess.AddParamToSqlCommand(sc, "@UserId", thisCandidate.UserId);
            DataAccess.AddParamToSqlCommand(sc, "@FirstName", thisCandidate.FirstName);
            DataAccess.AddParamToSqlCommand(sc, "@LastName", thisCandidate.LastName);
            DataAccess.AddParamToSqlCommand(sc, "@DateofBirth", thisCandidate.DateofBirth);
            DataAccess.AddParamToSqlCommand(sc, "@Address", thisCandidate.Address);
            DataAccess.AddParamToSqlCommand(sc, "@PostCode", thisCandidate.PostCode);

            DataAccess.AddParamToSqlCommand(sc, "@Suburb", thisCandidate.Suburb);
            DataAccess.AddParamToSqlCommand(sc, "@State", thisCandidate.State);
            DataAccess.AddParamToSqlCommand(sc, "@HomePhone", thisCandidate.HomePhone);
            DataAccess.AddParamToSqlCommand(sc, "@Mobile", thisCandidate.Mobile);
            DataAccess.AddParamToSqlCommand(sc, "@Email", thisCandidate.Email);
           // DataAccess.AddParamToSqlCommand(sc, "@JobsApplied", thisCandidate.JobsApplied);
           // DataAccess.AddParamToSqlCommand(sc, "@DateLAstVisited", thisCandidate.DateLastVisited);


            return DataAccess.UpdateDB(sc);



        }

    }
}