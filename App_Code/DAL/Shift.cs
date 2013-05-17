using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using OZiNursing;
using OZiNursing.DAL;


/// <summary>
/// Summary description for Shift
/// </summary>
/// 

namespace OZiNursing.DAL
{
	public class Shift
	{
		public Shift()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int InsertShift(OZiNursing.Objects.Shift thisShift )
		{
			string sqlStr = "INSERT INTO Shift( ";
			sqlStr += "ShiftTypeId,NurseId,StartDateTime,EndDateTime,ClientId,DateCreated,CreatedBy,IsAssigned";
			sqlStr += " ) VALUES ( ";
			sqlStr += "@ShiftTypeId,@NurseId,@StartTime,@EndTime,@ClientId,@DateCreated,@CreatedBy,@IsAssigned";
			sqlStr += ")";

			SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

			DataAccess.AddParamToSqlCommand(sc, "@ShiftTypeId", thisShift.ShiftTypeId);
			DataAccess.AddParamToSqlCommand(sc, "@NurseId", thisShift.NurseId);
			DataAccess.AddParamToSqlCommand(sc,"@StartTime",thisShift.StartTime);
			DataAccess.AddParamToSqlCommand(sc,"@EndTime",thisShift.EndTime);
			DataAccess.AddParamToSqlCommand(sc,"@ClientId",thisShift.ClientId);
            DataAccess.AddParamToSqlCommand(sc, "@DateCreated", thisShift.DateCreated);
            DataAccess.AddParamToSqlCommand(sc, "@CreatedBy", thisShift.CreatedBy);
            DataAccess.AddParamToSqlCommand(sc, "@IsAssigned", thisShift.IsAssigned);

			return DataAccess.InsertDB(sc);



		}

        public static int UpdateShift(OZiNursing.Objects.Shift thisShift)
        {
            string sqlStr = "Update Shift SET ";
            sqlStr += "ShiftTypeId=@ShiftTypeId,NurseId=@NurseId,Date=,StartTime,EndTime,ClientId,IsAss";
            sqlStr += " ) VALUES ( ";
            sqlStr += "@ShiftTypeId,@NurseId,@Date,@StartTime,@EndTime,@ClientId";
            sqlStr += ")";

            SqlCommand sc = DataAccess.CreateSqlCommandFromString(sqlStr);

            DataAccess.AddParamToSqlCommand(sc, "@ShiftTypeId", thisShift.ShiftTypeId);
            DataAccess.AddParamToSqlCommand(sc, "@NurseId", thisShift.NurseId);
           // DataAccess.AddParamToSqlCommand(sc, "@Date", thisShift.Date);
            DataAccess.AddParamToSqlCommand(sc, "@StartTime", thisShift.StartTime);
            DataAccess.AddParamToSqlCommand(sc, "@EndTime", thisShift.EndTime);
            DataAccess.AddParamToSqlCommand(sc, "@ClientId", thisShift.ClientId);

            return DataAccess.InsertDB(sc);



        }



	}
}