using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OZiNursing;

public partial class Administration_CreateShift : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            OZiNursing.Utilities.FillTimeDropDownList(DropDownListStartHour, DropDownListStartMinutes);
            OZiNursing.Utilities.FillTimeDropDownList(DropDownListEndHour, DropDownListEndMinutes);
            OZiNursing.Utilities.FillFutureYearsDropDown(DropDownListStartDay, DropDownListStartMonth, DropDownListStartYear);
            OZiNursing.Utilities.FillFutureYearsDropDown(DropDownListEndDay, DropDownListEndMonth, DropDownListEndYear);
            DropDownListNurse.Items.Add(new ListItem("Select Nurse", "0"));

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        OZiNursing.Objects.Shift thisShift = new OZiNursing.Objects.Shift();
        //Get date and time string values from dropdown lists
        string startDate= DropDownListStartDay.SelectedValue + "/" + DropDownListStartMonth.SelectedValue + "/" + DropDownListStartYear.SelectedValue;
        string startTime= DropDownListStartHour.SelectedValue + ":" + DropDownListStartMinutes.SelectedValue;
        string endDate= DropDownListEndDay.SelectedValue + "/" + DropDownListEndMonth.SelectedValue + "/" + DropDownListEndYear.SelectedValue;;
        string endTime= DropDownListEndHour.SelectedValue + ":" + DropDownListEndMinutes.SelectedValue;
        //Convert string date and time values to DateTime format
        DateTime startDateTime= Convert.ToDateTime(startDate + " " + startTime);
        DateTime endDateTime= Convert.ToDateTime(endDate + " " + endTime);

        thisShift.GetShiftFromFields(Convert.ToInt32(DropDownListShiftType.SelectedValue),Convert.ToInt32( DropDownListNurse.SelectedValue), startDateTime, endDateTime,
        Convert.ToInt32( DropDownListClient.SelectedValue), DateTime.Today, 0, true);
        int result=thisShift.CreateShift();
        
        PanelCreate.Visible = false;
        PanelComplete.Visible = true;
    }
    protected void DropDownListStartYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListEndDay.SelectedIndex = DropDownListStartDay.SelectedIndex;
        DropDownListEndMonth.SelectedIndex = DropDownListStartMonth.SelectedIndex;
        DropDownListEndYear.SelectedIndex = DropDownListStartYear.SelectedIndex;
        DropDownListEndDay.Focus();
    }
   
}