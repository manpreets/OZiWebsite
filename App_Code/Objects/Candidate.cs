using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OZiNursing.Objects
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime  DateofBirth { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Suburb { get; set; }
        public int State { get; set; }
        public string HomePhone { get; set; }
        public string Mobile { get; set; }
        public string  Email { get; set; }
        public int JobsApplied { get; set; }
        public DateTime DateLastVisited { get; set; }
      //public Guid gUserId { get; set; }
        public string UserId { get; set; }


        public void GetCandidateProfileFromReaderRow(SqlDataReader sdr)
        {
            //this.gUserId = (Guid)sdr["gUserId"];
            this.UserId = sdr["UserId"].ToString();
            this.Id = Convert.ToInt32( sdr["Id"]);
            this.FirstName = sdr["FirstName"].ToString();
            this.LastName = sdr["LastName"].ToString();
            this.DateofBirth = Convert.ToDateTime(sdr["DateofBirth"]);
            this.Address = sdr["Address"].ToString();
            this.PostCode = sdr["PostCode"].ToString();
            this.Suburb = sdr["Suburb"].ToString();
            this.State = Convert.ToInt32( sdr["State"].ToString());
            this.HomePhone = sdr["HomePhone"].ToString();
            this.Mobile = sdr["Mobile"].ToString();
            this.Email = sdr["Email"].ToString();
            this.JobsApplied = Convert.ToInt32(sdr["JobsApplied"]);
            this.DateLastVisited = Convert.ToDateTime(sdr["DateLastVisited"]);



        }

        public void GetCandidateFromFields(

            string FirstName,
            string LastName,
            DateTime DateofBirth,
            string Address,           
            string PostCode,
            string Suburb,
            int State,
            string HomePhone,
            string Mobile,
            string Email,
            int JobsApplied,
            DateTime DateLastVisited
                       
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateofBirth = DateofBirth;
            this.Address = Address;
            this.PostCode = PostCode;
            this.HomePhone = HomePhone;
            this.Mobile = Mobile;
            this.Suburb = Suburb;
            this.State = State;
            this.Email = Email;
            this.DateLastVisited = DateLastVisited;
            this.JobsApplied = JobsApplied;


       }

        public int CreateProfile(string UserId)
        {
            
          //  this.UserId = HttpContext.Current.User.Identity.Name;
            this.UserId = UserId;
            int nResult = DAL.Candidate.InsertCandidate(this);
            
            return nResult;
        }

        public int Update()
        {

            //  this.UserId = HttpContext.Current.User.Identity.Name;
            this.UserId = UserId;
            int nResult = DAL.Candidate.UpdateCandidate(this);

            return nResult;
        }

    }
}