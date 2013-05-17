using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.Caching;
using Microsoft.Security.Application; //Anti XSS dll
using OZiNursing;

/*
'<!--$$Revision: 31 $-->
'<!--$$Author: Mark $-->
'<!--$$Date: 28/04/10 5:50p $-->
'<!--$$Logfile: /_ArtsHub.NET/App_Code/Utilities.cs $-->
'<!--$$NoKeywords: $-->
*/
/// <summary>
/// Good old ArtsHub Utils
/// </summary>
/// 

namespace OZiNursing
{
    public class Utilities : OZiNursing.DAL.DataAccess
    {
        // Date manipulation Methods

        public static string NiceDate(DateTime dt)
        {
            return dt.ToString("dd MMM yyyy");
        }
        //Method to fill day, month and year value to date denoting date of birth drop down lists
        public static void FillDateofBirthDropDown(DropDownList DropDownListDay, DropDownList DropDownListMonth, DropDownList DropDownListYear)
        {
            DropDownListDay.Items.Add("Day");
            DropDownListMonth.Items.Add("Month");
            DropDownListYear.Items.Add("Year");
           
             for (int i = 1; i <= 31; i++)
            {
                DropDownListDay.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                DropDownListMonth.Items.Add(i.ToString());
            }
            for (int i = 1900; i <= 2000; i++)
            {
                DropDownListYear.Items.Add(i.ToString());
            }
        }

        //Method to fill day, month and year value to date denoting currents and future years drop down lists
        public static void FillFutureYearsDropDown(DropDownList DropDownListDay, DropDownList DropDownListMonth, DropDownList DropDownListYear)
        {
            DropDownListDay.Items.Add("Day");
            DropDownListMonth.Items.Add("Month");
            DropDownListYear.Items.Add("Year");
            int yearNow=Convert.ToInt32(DateTime.Now.Year.ToString());
            for (int i = 1; i <= 31; i++)
            {
                DropDownListDay.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                DropDownListMonth.Items.Add(i.ToString());
            }
            for (int i = yearNow ; i <= yearNow + 2; i++)
            {
                DropDownListYear.Items.Add(i.ToString());
            }
        }
        //Method to fill hours and minutes into time denoting drop down lists
        public static void FillTimeDropDownList(DropDownList DropDownHours,DropDownList DropDownMinutes)
        {
            DropDownHours.Items.Add("Hour");
            DropDownMinutes.Items.Add("Minute");

            for (int i = 0; i <= 23; i++)
            {
                DropDownHours.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 59; i++)
            {
                DropDownMinutes.Items.Add(i.ToString());
            }
        }
        
       
        // Error Log / Handling Methods
#region Error Log / Handling Methods
        public static void LogError(Exception eError, EventLogEntryType enumType)
        {
            if (!EventLog.SourceExists("ArtsHub.NET",".")) 
            {
                EventLog.CreateEventSource("ArtsHub.NET", "Application", ".");
            }

            EventLog elArtsHub = new EventLog("Application",".","ArtsHub.NET");
            elArtsHub.WriteEntry(eError.Message, enumType);
        }
        #endregion

        // RegEx Validation and Utililty style Methods
#region RegEx Methods
        // Function to test for Positive Integers.
        public static bool IsNaturalNumber(String strNumber)
        {
            bool bRet = false;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotNaturalPattern = new Regex("[^0-9]");
                Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
                bRet = !objNotNaturalPattern.IsMatch(strNumber) && objNaturalPattern.IsMatch(strNumber);
            }
            return bRet;
        }
        // Function to test for Positive Integers with zero inclusive
        public static bool IsWholeNumber(String strNumber)
        {
            bool bRet = false;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotWholePattern = new Regex("[^0-9]");
                bRet = !objNotWholePattern.IsMatch(strNumber);
            }
            return bRet;
        }
        // Function to Test for Integers both Positive & Negative
        public static bool IsInteger(String strNumber)
        {
            bool bRet = false;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotIntPattern = new Regex("[^0-9-]");
                Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
                bRet = !objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber);
            }
            return bRet;
        }
        // Function to Test for Positive Number both Integer & Real
        public static bool IsPositiveNumber(String strNumber)
        {
            bool bRet = false;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotPositivePattern = new Regex("[^0-9.]");
                Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
                Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
                bRet = !objNotPositivePattern.IsMatch(strNumber) &&
                objPositivePattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber);
            }
            return bRet;
        }
        // Function to test whether the string is valid number or not
        public static bool IsNumber(String strNumber)
        {
            bool bRet = false;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotNumberPattern = new Regex("[^0-9.-]");
                Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
                Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
                String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
                String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
                Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
                bRet = !objNotNumberPattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber) &&
                !objTwoMinusPattern.IsMatch(strNumber) &&
                objNumberPattern.IsMatch(strNumber);
            }
            return bRet;
        }
        // Function To test for Alphabets.
        public static bool IsAlpha(String strToCheck)
        {
            Regex objAlphaPattern = new Regex("[^a-zA-Z]");
            return !objAlphaPattern.IsMatch(strToCheck);
        }
        // Function to Check for AlphaNumeric.
        public static bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }
        // Function to Test for Positive Integers or set to zero
        public static int GetPositiveIntegerOrToZero(String strNumber)
        {
            int nReturn = 0;

            if (!string.IsNullOrEmpty(strNumber))
            {
                Regex objNotIntPattern = new Regex("[^0-9-]");
                Regex objIntPattern = new Regex("^[0-9]+$");
                if (!objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber))
                {
                    nReturn = Int32.Parse(strNumber);
                }
            }
            return nReturn;
        }
        //Replace with a given pattern Overload(1)
        public static String RegExReplace(String strText, String strPattern, String strReplace)
        {
            string strMyRetString = "";

            if (!string.IsNullOrEmpty(strText) && !string.IsNullOrEmpty(strPattern))
            {
                Regex objMyPattern = new Regex(strPattern);
                strMyRetString = objMyPattern.Replace(strText, strReplace);
            }

            return strMyRetString;
        }
        //Replace with a given pattern Overload(2) with Ignorecase
        public static String RegExReplace(String strText, String strPattern, String strReplace, bool bIgnoreCase)
        {
            string strMyRetString = "";

            if (!string.IsNullOrEmpty(strText) && !string.IsNullOrEmpty(strPattern))
            {
                if (bIgnoreCase)
                {
                    Regex objMyPattern = new Regex(strPattern, RegexOptions.IgnoreCase);
                    strMyRetString = objMyPattern.Replace(strText, strReplace);
                } 
                else
                {
                    Regex objMyPattern = new Regex(strPattern);
                    strMyRetString = objMyPattern.Replace(strText, strReplace);
                }
            }

            return strMyRetString;
        }
        //Match a given pattern
        public static bool RegexPatternMatch(String strText, String strPattern)
        {
            bool bMyRet = false;

            if (!string.IsNullOrEmpty(strText) && !string.IsNullOrEmpty(strPattern))
            {
                Regex objMyPattern = new Regex(strPattern);
                bMyRet = objMyPattern.IsMatch(strText);
            }

            return bMyRet;
        }
        /// <summary>
        /// StripHTML : remove html from user input
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string StripHTML(string strInput)
        { 
            string strOutput = "";

            if (!string.IsNullOrEmpty(strInput))
            {
                strOutput = strInput.Trim();
                strOutput = Utilities.RegExReplace(strOutput, @"<[^>]+>", "");
            }

            return strOutput;
        }

        /// <summary>
        /// InjectionClean : SQL Injection cleans for dynamic concatenated sql...
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string InjectionClean(string strText, bool bStripHTML, bool bUseAntiXssGetSafeHtml, bool bAllowSingleSemicolon)
        {
            //string strRet = "";
            string strRet = strText;

            /*
            if (!string.IsNullOrEmpty(strText))
            {
                strRet = strText.Trim();
                strRet = Utilities.RegExReplace(strRet, @";EXEC", "", true);
                strRet = Utilities.RegExReplace(strRet, @"; EXEC", "", true);
                strRet = Utilities.RegExReplace(strRet, @"EXEC(", "", true);
                strRet = Utilities.RegExReplace(strRet, @"EXEC (", "", true);
                strRet = Utilities.RegExReplace(strRet, @"=CAST(", "", true);
                strRet = Utilities.RegExReplace(strRet, @";SET", "", true);
                strRet = Utilities.RegExReplace(strRet, @"; SET", "", true);
                strRet = Utilities.RegExReplace(strRet, @";DECLARE", "", true);
                strRet = Utilities.RegExReplace(strRet, @"; DECLARE", "", true);
                strRet = Utilities.RegExReplace(strRet, @"';", "", true);
                strRet = Utilities.RegExReplace(strRet, @"' ;", "", true);
                strRet = Utilities.RegExReplace(strRet, @"%55%73%65%72%49%64", "", true); //Userid AS Hex
                strRet = Utilities.RegExReplace(strRet, @"%55%73%65%72%6e%61%6d%65", "", true); //Username AS Hex
                strRet = Utilities.RegExReplace(strRet, @"sysdatabases", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"is_member(''db_owner'')", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"sysobjects", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"\[master\]", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"cav_artshub", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"cav_artshub_dev", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"NCHAR(67)%2BNCHAR(65)%2BNCHAR(86)%2BNCHAR(95)%2BNCHAR(65)%2BNCHAR(114)%2BNCHAR(116)%2BNCHAR(115)%2BNCHAR(104)%2BNCHAR(117)%2BNCHAR(98)", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"CHAR(67)%2BCHAR(65)%2BCHAR(86)%2BCHAR(95)%2BCHAR(65)%2BCHAR(114)%2BCHAR(116)%2BCHAR(115)%2BCHAR(104)%2BCHAR(117)%2BCHAR(98)", "", true);			
                strRet = Utilities.RegExReplace(strRet, @"'^", "", true);
                strRet = Utilities.RegExReplace(strRet, @"^'", "", true);
                strRet = Utilities.RegExReplace(strRet, @"CAST(0x", "", true);
                strRet = Utilities.RegExReplace(strRet, @"CONCAT(", "", true);
                strRet = Utilities.RegExReplace(strRet, @"DROP TABLE", "", true);
                strRet = Utilities.RegExReplace(strRet, @"ALTER TABLE", "", true);
                strRet = Utilities.RegExReplace(strRet, @"ALTER COLUMN", "", true);
                strRet = Utilities.RegExReplace(strRet, @"DELETE FROM", "", true);
                strRet = Utilities.RegExReplace(strRet, @"NVARCHAR(", "", true);
                strRet = Utilities.RegExReplace(strRet, @"TBLCONTENTMAIN", "", true);
                strRet = Utilities.RegExReplace(strRet, @"UPDATE TBL", "", true);
                strRet = Utilities.RegExReplace(strRet, @"db_owner", "", true);
                strRet = Utilities.RegExReplace(strRet, @"char(", "", true);
                strRet = Utilities.RegExReplace(strRet, @"select%20top", "", true);
                strRet = Utilities.RegExReplace(strRet, @"from(", "", true);
                strRet = Utilities.RegExReplace(strRet, @"INSERT INTO", "", true);
                strRet = Utilities.RegExReplace(strRet, @"MODIFY COLUMN", "", true);
                strRet = Utilities.RegExReplace(strRet, @" DROP COLUMN ", "", true);
                strRet = Utilities.RegExReplace(strRet, @"--", "", true);
                strRet = Utilities.RegExReplace(strRet, @"<script", "", true);
                strRet = Utilities.RegExReplace(strRet, @".js", "", true);
                //This is when we are being extra paranoid about SQL injections!
                if (!bAllowSingleSemicolon) //false
                {
                    strRet = Utilities.RegExReplace(strRet, @";", "", true);
                }
                //Remove all html from user input
                if (bStripHTML)
                {
                    strRet = Utilities.StripHTML(strRet);
                }
                else // Allow only SAFE html
                {
                    //Microsoft XSS protection encoding
                    if (bUseAntiXssGetSafeHtml)
                    {
                        strRet = AntiXss.GetSafeHtml(strRet);
                    }
                }
               
            }
            */
            return strRet;
        }
        #endregion

        //Get Name By Id Methods
        //NOTE: These should probably live in DAL
#region Get Name By Id Methods
        // Get RegionName from tblRegions by id ////////////////////////////////
        
        // Get Category Name from tblCategories by id ////////////////////////////////
       
#endregion

        // Hastable utility methods
#region Hashtable utils

        public static Hashtable GetQueryStringIntoHashtable(string strQueryString)
        {
            Hashtable htThisHashtable = new Hashtable();

            string[] strDataArray = strQueryString.Split(new Char[] { '&' }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int x = 0; x < strDataArray.Length; x++)
            {
                string[] strThisPair = strDataArray[x].Split(new Char[] { '=' }, System.StringSplitOptions.None);
                htThisHashtable.Add(strThisPair[0], strThisPair[1]);
            }

            return htThisHashtable;
        }

        public static string OutputHastableAsQueryString(Hashtable htThisHashtable, bool bDeleteLeadingAmpersand)
        {
            string strOutput = "";

            foreach (DictionaryEntry d in htThisHashtable)
            {
                //Add the pair
                strOutput += "&" + d.Key.ToString() + "=" + (String)d.Value.ToString();
            }

            //Delete the leading ampersand?
            if (bDeleteLeadingAmpersand) { strOutput = strOutput.Remove(0,1); }

            return strOutput;
        }

        #endregion

        // Standard Utility Style methods
#region Standard Utility Style methods

        /// <summary>
        /// Trims and replaces wildcards in a search string
        /// </summary>
        public static string FormatSearchString(string strSearchText)
        {
            return strSearchText.Trim().Replace("*", "%");
        }

        public static string CleanseCreditCardNumber(string strCCNo)
        {
            return strCCNo.Replace("-", "").Replace(" ", "").Trim();
        }

        public static string PrepBoolForTransactionLog(bool bValue)
        {
            string strReturnValue = "0";
            if (bValue) { strReturnValue = "1"; }
            return strReturnValue;
        }
        /// <summary>
        /// Check for null and return ""
        /// </summary>
        public static string GetEmptyStringOrValue(string strValue)
        {
            return (string.IsNullOrEmpty(strValue)? "": strValue);
        }

        /// <summary>
        /// Adds the onfocus and onblur attributes to all input controls found in the specified parent,
        /// to change their apperance with the control has the focus
        /// </summary>
        /// <implement>
        ///protected override void OnLoad(EventArgs e)
        ///{
        ///    //This is done in ArtsHubPage
        ///}
        /// </implement>
        public static void SetInputControlsHighlight(Control container, string className, bool onlyTextBoxes)
        {
            foreach (Control ctl in container.Controls)
            {
                if ((onlyTextBoxes && ctl is TextBox) || ctl is TextBox || ctl is DropDownList ||
                    ctl is ListBox || ctl is CheckBox || ctl is RadioButton ||
                    ctl is RadioButtonList || ctl is CheckBoxList)
                {
                    WebControl wctl = ctl as WebControl;
                    wctl.Attributes.Add("onfocus", string.Format("this.className = '{0}';", className));
                    wctl.Attributes.Add("onblur", "this.className = '';");
                }
                else
                {
                    if (ctl.Controls.Count > 0)
                        SetInputControlsHighlight(ctl, className, onlyTextBoxes);
                }
            }
        }

        /// <summary>
        /// Converts the input plain-text to HTML version, replacing carriage returns
        /// and spaces with <br /> and &nbsp;
        /// </summary>
        public static string ConvertToHtml(string content)
        {
            content = HttpUtility.HtmlEncode(content);
            content = content.Replace("  ", "&nbsp;&nbsp;").Replace(
               "\t", "&nbsp;&nbsp;&nbsp;").Replace("\n", "<br>");
            return content;
        }
        /// <summary>
        /// RemoveTrailingCharacter : remove the last char from a string
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string RemoveTrailingCharacter(string strInput)
        {
            string strOutput = "";
            int nLen = 0;

            if (strInput.Length > 1)
            {
                strInput = strInput.Trim();
                nLen = strInput.Length;

                strOutput = strInput.Substring(0, nLen - 1);
            }
            else
            {
                strOutput = strInput;
            }
            return strOutput;
        }


        #endregion


        #region AdminDisplayUtilityMethods

        /// <summary>
        /// Returns a color choice for setting CSS red/green on sales balances
        /// </summary>
        public static string GetDisplayStatusColor(double nBalance)
        {
            string strClass = "";

            if (nBalance < 0)
            {
                strClass = " adminred";
            }
            else
            {
                strClass = " admingreen";
            }

            return strClass;
        }

        /// <summary>
        /// Returns a color choice for setting CSS red/green based on boolean
        /// </summary>
        public static string GetDisplayStatusColor(bool bResult)
        {
            string strClass = "";

            if (!bResult)
            {
                strClass = " adminred";
            }
            else
            {
                strClass = " admingreen";
            }

            return strClass;
        }

        
        /// <summary>
        /// Formats an admin label by message type
        /// </summary>
        public static void WriteAdminMessage(Label thisLabel, string strMessage, AdminMessageTypes messageType)
        {
            thisLabel.Text = strMessage;
            switch (messageType)
            {
                case AdminMessageTypes.Error:
                    thisLabel.CssClass = "adminFormResults error";
                    break;
                case AdminMessageTypes.Information:
                    thisLabel.CssClass = "adminFormResults";
                    break;
                case AdminMessageTypes.Success:
                    thisLabel.CssClass = "adminFormResults success";
                    break;
                case AdminMessageTypes.Warning:
                    thisLabel.CssClass = "adminFormResults error";
                    break;
            }
        }

        public enum AdminMessageTypes { Error, Warning, Information, Success }


        /// <summary>
        /// Applies the time difference to DateTimes based on the GMT Config value
        /// </summary>
       

        #endregion
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// Implemented as: EM.GetStringValue(enum.property);
    /// </summary>
    public class StringValueAttribute : Attribute
    {

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
}
