using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OZiNursing;
using OZiNursing.DAL;
using System.Data.SqlClient;


namespace OZiNursing.DAL
{

/// <summary>
/// Summary description for Nurse
/// </summary>
public class Nurse
{
	public static OZiNursing.Objects.Nurse GetNurseById(int Id)
	{
		OZiNursing.Objects.Nurse thisNurse = new Objects.Nurse();
		string sqlStr = "SELECT * from Nurse WHERE Id=@Id";

		bool isNurseFound = false;
		
		//SQL command created from DAL
		SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

		//Add parameters to the SQLCommand
		DataAccess.AddParamToSqlCommand(sc, "@Id", Id);

		SqlDataReader sdr= DataAccess.GetDB(sc);

		if (sdr.Read())
		{
			isNurseFound = true;
			thisNurse.GetNurseFromSDR(sdr);
			
		}
		sc.Connection.Close();
		sdr.Close();
		sdr.Dispose();

		if (isNurseFound == true)
		{

			return thisNurse;
		}
		else
		{
			return null;
		}
	
	}

	public static int InsertNurse(OZiNursing.Objects.Nurse thisNurse)
	{
		string sqlStr = "INSERT INTO Nurse( ";
		sqlStr += "UserName,FirstName,LastName,DateofBirth,Address,PostCode,Suburb,State,HomePhone,Mobile,Email,";
		sqlStr+="RegistrationNumber,NurseTypeId,CreatedBy,DateofJoining";

		sqlStr += ") VALUES (";

		sqlStr += "@UserName,@FirstName,@LastName,@DateofBirth,@Address,@PostCode,@Suburb,@State,@HomePhone,@Mobile,@Email,";
		sqlStr += "@RegistrationNumber,@NurseTypeId,@CreatedBy,@DateofJoining";
		sqlStr += ")";

		//SQL command created from DAL method
		SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

		//Parameters added on the basis of their data type
		DataAccess.AddParamToSqlCommand(sc, "@UserName", thisNurse.UserName);
		DataAccess.AddParamToSqlCommand(sc, "@FirstName", thisNurse.FirstName);
		DataAccess.AddParamToSqlCommand(sc, "@LastName", thisNurse.LastName);
		DataAccess.AddParamToSqlCommand(sc, "@DateofBirth", thisNurse.DateofBirth);
		DataAccess.AddParamToSqlCommand(sc, "@Address", thisNurse.Address);
		DataAccess.AddParamToSqlCommand(sc, "@PostCode", thisNurse.PostCode);

		DataAccess.AddParamToSqlCommand(sc, "@Suburb", thisNurse.Suburb);
		DataAccess.AddParamToSqlCommand(sc, "@State", thisNurse.State);
		DataAccess.AddParamToSqlCommand(sc, "@HomePhone", thisNurse.HomePhone);
		DataAccess.AddParamToSqlCommand(sc, "@Mobile", thisNurse.Mobile);
		DataAccess.AddParamToSqlCommand(sc, "@Email", thisNurse.Email);
		DataAccess.AddParamToSqlCommand(sc, "@RegistrationNumber", thisNurse.RegistrationNumber);
		DataAccess.AddParamToSqlCommand(sc, "@NurseTypeId", thisNurse.NurseTypeId);
		DataAccess.AddParamToSqlCommand(sc, "@CreatedBy", thisNurse.CreatedBy);
		DataAccess.AddParamToSqlCommand(sc, "@DateofJoining", thisNurse.DateofJoining);
	

		return DataAccess.InsertDB(sc);
		
	}

	public static int UpdateNurse(OZiNursing.Objects.Nurse thisNurse)
	{
		string sqlStr = "Update Nurse SET ";
		sqlStr += "FirstName=@FirstName,LastName=@LastName,DateofBirth=@DateofBirth,Address=@Address,PostCode=@PostCode,";
		sqlStr+= "Suburb=@Suburb,State=@State,HomePhone=@HomePhone,Mobile=@Mobile,Email=@Email,";
		sqlStr += "RegistrationNumber=@RegistrationNumber,NurseTypeId=@NurseTypeId ";

		sqlStr += "WHERE Id=@Id";

		//SQL command created from DAL method
		SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

		//Parameters added on the basis of their data type
        DataAccess.AddParamToSqlCommand(sc, "@Id", thisNurse.Id);
		//DataAccess.AddParamToSqlCommand(sc, "@UserName", thisNurse.UserName);
		DataAccess.AddParamToSqlCommand(sc, "@FirstName", thisNurse.FirstName);
		DataAccess.AddParamToSqlCommand(sc, "@LastName", thisNurse.LastName);
		DataAccess.AddParamToSqlCommand(sc, "@DateofBirth", thisNurse.DateofBirth);
		DataAccess.AddParamToSqlCommand(sc, "@Address", thisNurse.Address);
		DataAccess.AddParamToSqlCommand(sc, "@PostCode", thisNurse.PostCode);

		DataAccess.AddParamToSqlCommand(sc, "@Suburb", thisNurse.Suburb);
		DataAccess.AddParamToSqlCommand(sc, "@State", thisNurse.State);
		DataAccess.AddParamToSqlCommand(sc, "@HomePhone", thisNurse.HomePhone);
		DataAccess.AddParamToSqlCommand(sc, "@Mobile", thisNurse.Mobile);
		DataAccess.AddParamToSqlCommand(sc, "@Email", thisNurse.Email);
		DataAccess.AddParamToSqlCommand(sc, "@RegistrationNumber", thisNurse.RegistrationNumber);
		DataAccess.AddParamToSqlCommand(sc, "@NurseTypeId", thisNurse.NurseTypeId);
		//DataAccess.AddParamToSqlCommand(sc, "@CreatedBy", thisNurse.CreatedBy);
		


		return DataAccess.InsertDB(sc);

	}


	
}



}