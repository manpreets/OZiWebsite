using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OZiNursing.Objects
{
    /// <summary>
    /// This class is basic blue print of a Nurse object that will access methods from BLL or Business logic nurse
    /// </summary>
    public class Nurse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string HomePhone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public int NurseTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateofJoining { get; set; }
       


    
     public void GetNurseFromFields(
       
        string FirstName,
        string LastName,
        DateTime DateofBirth,
        string Address,
        string Suburb,
        int State,
        string PostCode,
        string HomePhone,
        string Mobile,
        string Email,
        string RegistrationNumber,
        int NurseTypeId,
        string CreatedBy,
        DateTime DateofJoining
        
        )
     {
         this.FirstName = FirstName;
         this.LastName = LastName;
         this.DateofBirth = DateofBirth;
         this.Address = Address;
         this.Suburb = Suburb;
         this.State = State;
         this.PostCode = PostCode;
         this.HomePhone = HomePhone;
         this.Mobile = Mobile;
         this.Email = Email;
         this.RegistrationNumber = RegistrationNumber;
         this.NurseTypeId = NurseTypeId;
         this.CreatedBy = CreatedBy;
         this.DateofJoining = DateofJoining;
      
         
     }
        public void GetNurseFromSDR(System.Data.SqlClient.SqlDataReader sdr)
     {
            
            this.Id = Convert.ToInt32(sdr["Id"]);
            this.UserName = sdr["UserName"].ToString();
            this.FirstName = sdr["FirstName"].ToString();
            this.LastName = sdr["LastName"].ToString();
            this.DateofBirth=Convert.ToDateTime(sdr["DateofBirth"]);
            this.Address = sdr["Address"].ToString();
            this.PostCode = sdr["PostCode"].ToString();
            this.Suburb = sdr["Suburb"].ToString();
            this.State = Convert.ToInt32(sdr["State"].ToString());
            this.HomePhone = sdr["HomePhone"].ToString();
            this.Mobile = sdr["Mobile"].ToString();
            this.Email = sdr["Email"].ToString();
            this.RegistrationNumber = sdr["RegistrationNumber"].ToString();
            this.NurseTypeId = Convert.ToInt32(sdr["NurseTypeId"]);
            this.CreatedBy = sdr["CreatedBy"].ToString();
            this.DateofJoining = Convert.ToDateTime(sdr["DateofJoining"]);





     }

        public int CreateNurse()
     {
         int nResult = DAL.Nurse.InsertNurse(this);
         return nResult;
     }
        public int UpdateNurse()
        {
            int nResult = DAL.Nurse.UpdateNurse(this);
            return nResult;
        }


}
}