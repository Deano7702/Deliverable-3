using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Deliverable2
{
    //Dean Mason
    //1574783
    public partial class Form1 : Form
    {

        List<Offender> offenderList = new List<Offender>(); //List of offender objects


        public Form1()
        {
            InitializeComponent();

            generateData();

            createSummaryStats();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDisplay.SelectedItem != null)
            {

                string[] temp = new string[3];
                int index = listBoxDisplay.SelectedIndex;

                temp = listBoxDisplay.Items[index].ToString().Split(' ');
                temp = temp.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                SQL.selectQuery("exec OffenceByID '" + temp[0] + "'");

                while (SQL.read.Read())
                {
                    textBoxOffenseID.Text = SQL.read[0].ToString();
                    textBoxDescription.Text = SQL.read[1].ToString();
                    textBoxSpeed.Text = SQL.read[2].ToString();
                    textBoxDateTime.Text = SQL.read[3].ToString();
                    textBoxICN.Text = SQL.read[4].ToString();
                    textBoxX.Text = SQL.read[5].ToString();
                    textBoxY.Text = SQL.read[6].ToString();
                    textBoxNoticeNumber.Text = SQL.read[7].ToString();
                    textBoxRegistrationNumber.Text = SQL.read[8].ToString();
                    textBoxOffenderID.Text = SQL.read[9].ToString();
                    textBoxWeather.Text = SQL.read[10].ToString();

                }

                SQL.read.Close();

                createInfringementNotice();

            }
        }


        private void btn_newOffense_Click(object sender, EventArgs e)
        {


            //SQL.selectQuery("INSERT INTO offence(offence_id, offense_description, speed_alleged, timedate, icn, x_pos, y_pos, notice_number, registration_number, offender_id, weather)VALUES("+ "'" + offenceID + "'" + ", " + "'" + offenceDesc + "'" + ", " + "'" + speed + "'" +", " + "'" + datetime + "'" + ", " + "'" + icn + "'" + ", " + "'" + xPos + "'" + ", " + "'" + yPos + "'" + ", " + "'" + noticeNum + "'" + ", "  + "'" + registrationNum + "'" + ", " + "'" + weather + "'" + ");");

            string query = "INSERT INTO offence (offence_id, offense_description, speed_alleged, timedate, icn, x_pos, y_pos, notice_number, registration_number, offender_id, weather) VALUES (@offence_id, @offense_description, @speed_alleged, @timedate, @icn, @x_pos, @y_pos, @notice_number, @registration_number, @offender_id, @weather)";
            SqlParameter[] parameters = new SqlParameter[11];

            parameters[0] = new SqlParameter("@offence_id", textBoxOffenseID.Text);
            parameters[1] = new SqlParameter("@offense_description", textBoxDescription.Text);
            parameters[2] = new SqlParameter("@speed_alleged", textBoxSpeed.Text);
            parameters[3] = new SqlParameter("@timedate", textBoxDateTime.Text);
            parameters[4] = new SqlParameter("@icn", textBoxICN.Text);
            parameters[5] = new SqlParameter("@x_pos", textBoxX.Text);
            parameters[6] = new SqlParameter("@y_pos", textBoxY.Text);
            parameters[7] = new SqlParameter("@notice_number", textBoxNoticeNumber.Text);
            parameters[8] = new SqlParameter("@registration_number", textBoxRegistrationNumber.Text);
            parameters[9] = new SqlParameter("@offender_id", textBoxOffenderID.Text);
            parameters[10] = new SqlParameter("@weather", textBoxWeather.Text);

            try
            {
                SQL.executeQuery(query, parameters);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            generateData();

            try
            {
                createSummaryStats();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string[] temp = new string[11];
            int index = listBoxDisplay.SelectedIndex;

            try
            {
                temp = listBoxDisplay.Items[index].ToString().Split(' ');
                temp = temp.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                SqlParameter[] parameters = new SqlParameter[1];

                if (temp[3] != null)
                {
                    String offenseID = temp[0];

                    string query = "DELETE FROM offence WHERE offence_id = @offence_id";

                    parameters[0] = new SqlParameter("@offence_id", offenseID);

                    try
                    {
                        SQL.executeQuery(query, parameters);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            generateData();
            createSummaryStats();

        }

        public void generateData()
        {
            listBoxDisplay.Items.Clear(); //Clear the listbox of data
            offenderList.Clear(); //Clear or reset the offender list

            //List box header
            listBoxDisplay.Items.Add("OFFENCE_ID".PadRight(16) +
                            "FIRSTNAME".PadRight(10) +
                            "SURNAME".PadRight(10) +
                            "NOTICE_NUMBER".PadRight(15) +
                            "DESCRIPTION".PadRight(19) +
                            "SPEED".PadRight(10) +
                            "DATE/TIME".PadRight(25) +
                            "ICN".PadRight(12) +
                            "XPOS".PadRight(10) +
                            "YPOS".PadRight(10) +
                            "REGISTRATION".PadRight(15) +
                            "OFFENDER_ID".PadRight(14) +
                            "WEATHER");

            //Creating variables to store offender information
            string fname = "";
            string lname = "";
            string ID = "";

            //Selecting a query from the database using the SQL class
            SQL.selectQuery("Select * from offender");

            //While the SQL reader is not at the end of the datastream
            while (SQL.read.Read())
            {
                ID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the ID
                fname = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offenders first name
                lname = SQL.read[2].ToString(); //Assign the second value from the SQL reader as the offenders last name

                Offender offender = new Offender(ID, fname, lname); //Create a new offender object given ID and name

                offenderList.Add(offender); //Add the new offender to the list of offenders

            }

            SQL.read.Close();

            //Selecting a new query from the database using the SQL class
            SQL.selectQuery("Select * from offence");

            //Initiating variables to store values from the SQL reader
            string offenceID = "";
            string offenceDesc = "";
            string speed = "";
            string datetime = "";
            string icn = "";
            string xPos = "";
            string yPos = "";
            string noticeNum = "";
            string registrationNum = "";
            string offenderID = "";
            string weather = "";

            //While the SQL reader is not at the end of the datastreama
            while (SQL.read.Read())
            {
                offenceID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the offenceID
                offenceDesc = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offence description
                speed = SQL.read[2].ToString(); //Assign the third value from the SQL reader as the speed
                datetime = SQL.read[3].ToString(); //Assign the fourth value from the SQL reader as the date and time
                icn = SQL.read[4].ToString(); //Assign the fifth value from the SQL reader as the icn
                xPos = SQL.read[5].ToString(); //Assign the sixth value from the SQL reader as the x position
                yPos = SQL.read[6].ToString(); //Assign the seventh value from the SQL reader as the y position
                noticeNum = SQL.read[7].ToString(); //Assign the eightth value from the SQL reader as the notice number
                registrationNum = SQL.read[8].ToString(); //Assign the nineth value from the SQL reader as the registration number
                offenderID = SQL.read[9].ToString(); //Assign the tenth value from the SQL reader as the offender ID
                weather = SQL.read[10].ToString(); //Assign the eleventh value from the SQL reader as the weather status

                //For every offender created by information provided by the database query
                foreach (Offender o in offenderList)
                {
                    //If the offender ID matches the offender object ID
                    if (offenderID == o.ID)
                    {
                        //Display formatted information about the offender 
                        listBoxDisplay.Items.Add(offenceID.PadRight(16) + 
                            o.firstName.PadRight(10) +
                            o.lastName.PadRight(10) +
                            noticeNum.PadRight(15) +
                            offenceDesc.PadRight(19) +
                            speed.PadRight(10) +
                            datetime.PadRight(25) +
                            icn.PadRight(12) +
                            xPos.PadRight(10) +
                            yPos.PadRight(10) +
                            registrationNum.PadRight(15) +
                            offenderID.PadRight(14) +
                            weather.PadRight(10));
                    }
                }
            }

            SQL.read.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            textBoxOffenseID.Clear();
            textBoxDescription.Clear();
            textBoxSpeed.Clear();
            textBoxDateTime.Clear();
            textBoxICN.Clear();
            textBoxX.Clear();
            textBoxY.Clear();
            textBoxNoticeNumber.Clear();
            textBoxRegistrationNumber.Clear();
            textBoxOffenderID.Clear();
            textBoxWeather.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBoxDisplay.Items.Clear(); //Clear the listbox of data
            offenderList.Clear(); //Clear or reset the offender list

            //List box header
            listBoxDisplay.Items.Add("OFFENCE_ID".PadRight(16) +
                "FIRSTNAME".PadRight(10) +
                "SURNAME".PadRight(10) +
                "NOTICE_NUMBER".PadRight(15) +
                "DESCRIPTION".PadRight(19) +
                "SPEED".PadRight(10) +
                "DATE/TIME".PadRight(25) +
                "ICN".PadRight(12) +
                "XPOS".PadRight(10) +
                "YPOS".PadRight(10) +
                "REGISTRATION".PadRight(15) +
                "OFFENDER_ID".PadRight(14) +
                "WEATHER");

            //Creating variables to store offender information
            string fname = "";
            string lname = "";
            string ID = "";

            //Selecting a query from the database using the SQL class
            SQL.selectQuery("Select * from offender");

            //While the SQL reader is not at the end of the datastream
            while (SQL.read.Read())
            {
                ID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the ID
                fname = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offenders first name
                lname = SQL.read[2].ToString(); //Assign the second value from the SQL reader as the offenders last name

                Offender offender = new Offender(ID, fname, lname); //Create a new offender object given ID and name

                offenderList.Add(offender); //Add the new offender to the list of offenders

            }

            SQL.read.Close();

            //Selecting a new query from the database using the SQL class
            SQL.executeQueryProcedure("unpaidInfringements");

            //Initiating variables to store values from the SQL reader
            string offenceID = "";
            string offenceDesc = "";
            string speed = "";
            string datetime = "";
            string icn = "";
            string xPos = "";
            string yPos = "";
            string noticeNum = "";
            string registrationNum = "";
            string offenderID = "";
            string weather = "";

            //While the SQL reader is not at the end of the datastreama
            while (SQL.read.Read())
            {
                offenceID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the offenceID
                offenceDesc = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offence description
                speed = SQL.read[2].ToString(); //Assign the third value from the SQL reader as the speed
                datetime = SQL.read[3].ToString(); //Assign the fourth value from the SQL reader as the date and time
                icn = SQL.read[4].ToString(); //Assign the fifth value from the SQL reader as the icn
                xPos = SQL.read[5].ToString(); //Assign the sixth value from the SQL reader as the x position
                yPos = SQL.read[6].ToString(); //Assign the seventh value from the SQL reader as the y position
                noticeNum = SQL.read[7].ToString(); //Assign the eightth value from the SQL reader as the notice number
                registrationNum = SQL.read[8].ToString(); //Assign the nineth value from the SQL reader as the registration number
                offenderID = SQL.read[9].ToString(); //Assign the tenth value from the SQL reader as the offender ID
                weather = SQL.read[10].ToString(); //Assign the eleventh value from the SQL reader as the weather status

                //For every offender created by information provided by the database query
                foreach (Offender o in offenderList)
                {
                    //If the offender ID matches the offender object ID
                    if (offenderID == o.ID)
                    {
                        //Display formatted information about the offender 
                        listBoxDisplay.Items.Add(offenceID.PadRight(16) +
                            o.firstName.PadRight(10) +
                            o.lastName.PadRight(10) +
                            noticeNum.PadRight(15) +
                            offenceDesc.PadRight(19) +
                            speed.PadRight(10) +
                            datetime.PadRight(25) +
                            icn.PadRight(12) +
                            xPos.PadRight(10) +
                            yPos.PadRight(10) +
                            registrationNum.PadRight(15) +
                            offenderID.PadRight(14) +
                            weather.PadRight(10));
                    }
                }
            }

            SQL.read.Close();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBoxDisplay.Items.Clear(); //Clear the listbox of data
            offenderList.Clear(); //Clear or reset the offender list

            //List box header
            listBoxDisplay.Items.Add("OFFENCE_ID".PadRight(16) +
                "FIRSTNAME".PadRight(10) +
                "SURNAME".PadRight(10) +
                "NOTICE_NUMBER".PadRight(15) +
                "DESCRIPTION".PadRight(19) +
                "SPEED".PadRight(10) +
                "DATE/TIME".PadRight(25) +
                "ICN".PadRight(12) +
                "XPOS".PadRight(10) +
                "YPOS".PadRight(10) +
                "REGISTRATION".PadRight(15) +
                "OFFENDER_ID".PadRight(14) +
                "WEATHER");

            //Creating variables to store offender information
            string fname = "";
            string lname = "";
            string ID = "";

            //Selecting a query from the database using the SQL class
            SQL.selectQuery("Select * from offender");

            //While the SQL reader is not at the end of the datastream
            while (SQL.read.Read())
            {
                ID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the ID
                fname = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offenders first name
                lname = SQL.read[2].ToString(); //Assign the second value from the SQL reader as the offenders last name

                Offender offender = new Offender(ID, fname, lname); //Create a new offender object given ID and name

                offenderList.Add(offender); //Add the new offender to the list of offenders

            }

            SQL.read.Close();

            //Selecting a new query from the database using the SQL class
            SQL.executeQueryProcedure("withoutInfringementNotice");

            //Initiating variables to store values from the SQL reader
            string offenceID = "";
            string offenceDesc = "";
            string speed = "";
            string datetime = "";
            string icn = "";
            string xPos = "";
            string yPos = "";
            string noticeNum = "";
            string registrationNum = "";
            string offenderID = "";
            string weather = "";

            //While the SQL reader is not at the end of the datastreama
            while (SQL.read.Read())
            {
                offenceID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the offenceID
                offenceDesc = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offence description
                speed = SQL.read[2].ToString(); //Assign the third value from the SQL reader as the speed
                datetime = SQL.read[3].ToString(); //Assign the fourth value from the SQL reader as the date and time
                icn = SQL.read[4].ToString(); //Assign the fifth value from the SQL reader as the icn
                xPos = SQL.read[5].ToString(); //Assign the sixth value from the SQL reader as the x position
                yPos = SQL.read[6].ToString(); //Assign the seventh value from the SQL reader as the y position
                noticeNum = SQL.read[7].ToString(); //Assign the eightth value from the SQL reader as the notice number
                registrationNum = SQL.read[8].ToString(); //Assign the nineth value from the SQL reader as the registration number
                offenderID = SQL.read[9].ToString(); //Assign the tenth value from the SQL reader as the offender ID
                weather = SQL.read[10].ToString(); //Assign the eleventh value from the SQL reader as the weather status

                //For every offender created by information provided by the database query
                foreach (Offender o in offenderList)
                {
                    //If the offender ID matches the offender object ID
                    if (offenderID == o.ID)
                    {
                        //Display formatted information about the offender 
                        listBoxDisplay.Items.Add(offenceID.PadRight(16) +
                            o.firstName.PadRight(10) +
                            o.lastName.PadRight(10) +
                            noticeNum.PadRight(15) +
                            offenceDesc.PadRight(19) +
                            speed.PadRight(10) +
                            datetime.PadRight(25) +
                            icn.PadRight(12) +
                            xPos.PadRight(10) +
                            yPos.PadRight(10) +
                            registrationNum.PadRight(15) +
                            offenderID.PadRight(14) +
                            weather.PadRight(10));
                    }
                }
            }

            SQL.read.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBoxDisplay.Items.Clear(); //Clear the listbox of data
            offenderList.Clear(); //Clear or reset the offender list

            //List box header
            listBoxDisplay.Items.Add("OFFENCE_ID".PadRight(16) +
                "FIRSTNAME".PadRight(10) +
                "SURNAME".PadRight(10) +
                "NOTICE_NUMBER".PadRight(15) +
                "DESCRIPTION".PadRight(19) +
                "SPEED".PadRight(10) +
                "DATE/TIME".PadRight(25) +
                "ICN".PadRight(12) +
                "XPOS".PadRight(10) +
                "YPOS".PadRight(10) +
                "REGISTRATION".PadRight(15) +
                "OFFENDER_ID".PadRight(14) +
                "WEATHER");

            //Creating variables to store offender information
            string fname = "";
            string lname = "";
            string ID = "";

            //Selecting a query from the database using the SQL class
            SQL.selectQuery("Select * from offender");

            //While the SQL reader is not at the end of the datastream
            while (SQL.read.Read())
            {
                ID = SQL.read[0].ToString(); //Assign the first value from the SQL reader as the ID
                fname = SQL.read[1].ToString(); //Assign the second value from the SQL reader as the offenders first name
                lname = SQL.read[2].ToString(); //Assign the second value from the SQL reader as the offenders last name

                Offender offender = new Offender(ID, fname, lname); //Create a new offender object given ID and name

                offenderList.Add(offender); //Add the new offender to the list of offenders

            }

            SQL.read.Close();

            //Selecting a new query from the database using the SQL class
            SQL.executeQueryProcedure("overdueInfringements");

            //Initiating variables to store values from the SQL reader
            string offenceID = "";
            string offenceDesc = "";
            string speed = "";
            string datetime = "";
            string icn = "";
            string xPos = "";
            string yPos = "";
            string noticeNum = "";
            string registrationNum = "";
            string offenderID = "";
            string weather = "";

            //While the SQL reader is not at the end of the datastreama
            while (SQL.read.Read())
            {
                offenceID = SQL.read[1].ToString(); //Assign the first value from the SQL reader as the offenceID
                offenceDesc = SQL.read[2].ToString(); //Assign the second value from the SQL reader as the offence description
                speed = SQL.read[3].ToString(); //Assign the third value from the SQL reader as the speed
                datetime = SQL.read[4].ToString(); //Assign the fourth value from the SQL reader as the date and time
                icn = SQL.read[5].ToString(); //Assign the fifth value from the SQL reader as the icn
                xPos = SQL.read[6].ToString(); //Assign the sixth value from the SQL reader as the x position
                yPos = SQL.read[7].ToString(); //Assign the seventh value from the SQL reader as the y position
                noticeNum = SQL.read[8].ToString(); //Assign the eightth value from the SQL reader as the notice number
                registrationNum = SQL.read[9].ToString(); //Assign the nineth value from the SQL reader as the registration number
                offenderID = SQL.read[10].ToString(); //Assign the tenth value from the SQL reader as the offender ID
                weather = SQL.read[11].ToString(); //Assign the eleventh value from the SQL reader as the weather status


                //For every offender created by information provided by the database query
                foreach (Offender o in offenderList)
                {
                    //If the offender ID matches the offender object ID
                    if (offenderID == o.ID)
                    {
                        //Display formatted information about the offender 
                        listBoxDisplay.Items.Add(offenceID.PadRight(16) +
                            o.firstName.PadRight(10) +
                            o.lastName.PadRight(10) +
                            noticeNum.PadRight(15) +
                            offenceDesc.PadRight(19) +
                            speed.PadRight(10) +
                            datetime.PadRight(25) +
                            icn.PadRight(12) +
                            xPos.PadRight(10) +
                            yPos.PadRight(10) +
                            registrationNum.PadRight(15) +
                            offenderID.PadRight(14) +
                            weather.PadRight(10));
                    }
                }
            }

            SQL.read.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            generateData();
        }

        public string summaryReportStats(string query)
        {
            string returnStat = "";
            
            SQL.executeQueryProcedure(query);

            while (SQL.read.Read())
            {
                returnStat = SQL.read[0].ToString();
            }

            SQL.read.Close();

            return returnStat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE offence set offence_id = @offence_id, offense_description = @offense_description, speed_alleged = @speed_alleged, timedate = @timedate, icn = @icn, x_pos = @x_pos, y_pos = @y_pos, notice_number = @notice_number, registration_number = @registration_number, offender_id = @offender_id, weather = @weather  where offence_id = @offence_id";
            SqlParameter[] parameters = new SqlParameter[11];

            parameters[0] = new SqlParameter("@offence_id", textBoxOffenseID.Text);
            parameters[1] = new SqlParameter("@offense_description", textBoxDescription.Text);
            parameters[2] = new SqlParameter("@speed_alleged", textBoxSpeed.Text);
            parameters[3] = new SqlParameter("@timedate", textBoxDateTime.Text);
            parameters[4] = new SqlParameter("@icn", textBoxICN.Text);
            parameters[5] = new SqlParameter("@x_pos", textBoxX.Text);
            parameters[6] = new SqlParameter("@y_pos", textBoxY.Text);
            parameters[7] = new SqlParameter("@notice_number", textBoxNoticeNumber.Text);
            parameters[8] = new SqlParameter("@registration_number", textBoxRegistrationNumber.Text);
            parameters[9] = new SqlParameter("@offender_id", textBoxOffenderID.Text);
            parameters[10] = new SqlParameter("@weather", textBoxWeather.Text);

            try
            {
                SQL.executeQuery(query, parameters);

                MessageBox.Show("Offence ID: " + textBoxOffenseID.Text + " has been updated.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            generateData();
            createSummaryStats();
        }

        public void createInfringementNotice()
        {
            string[] dateTime;

            string[] temp = new string[11];
            int index = listBoxDisplay.SelectedIndex;

            temp = listBoxDisplay.Items[index].ToString().Split(' ');
            temp = temp.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            String noticeNumber = temp[3];

            //Initiating variables to store values from the SQL reader
            string noticeNum = "";
            string icn = "";
            string fname = "";
            string lname = "";
            string roadStreetNum = "";
            string roadStreet = "";
            string DOB = "";
            string licenseNumber = "";
            string timeDate = "";
            string make = "";
            string model = "";
            string offenseLocation = "";
            string road = "";
            string region = "";
            string regoNum = "";
            string amount = "";
            string speedLimit = "";
            string speedAlleged = "";
            string description = "";
            string excessSpeed = "";
            string dayOfWeek = "";

            string query = "exec infringementNoticeData '" + noticeNumber + "'";

            //Selecting a new query from the database using the SQL class
            SQL.selectQuery(query);

            //While the SQL reader is not at the end of the datastreama
            while (SQL.read.Read())
            {
                noticeNum = SQL.read[0].ToString();
                icn = SQL.read[1].ToString();
                fname = SQL.read[2].ToString();
                lname = SQL.read[3].ToString();
                roadStreetNum = SQL.read[4].ToString();
                roadStreet = SQL.read[5].ToString();
                DOB = SQL.read[6].ToString();
                licenseNumber = SQL.read[7].ToString();
                timeDate = SQL.read[8].ToString();
                make = SQL.read[9].ToString();
                model = SQL.read[10].ToString();
                offenseLocation = SQL.read[11].ToString();
                road = SQL.read[12].ToString();
                region = SQL.read[13].ToString();
                regoNum = SQL.read[14].ToString();
                amount = "$" + SQL.read[15].ToString();
                speedLimit = SQL.read[16].ToString() + "km/h";
                speedAlleged = SQL.read[17].ToString() + "km/h";
                description = SQL.read[18].ToString();
                excessSpeed = SQL.read[19].ToString() + "km/h";
                dayOfWeek = SQL.read[20].ToString();

            }

            SQL.read.Close();

            textBoxNotice.Text = noticeNum;
            textBox2.Text = icn;
            textBoxName.Text = fname + " " + lname;
            textBoxAddress.Text = roadStreetNum + " " + roadStreet;
            textBoxRego.Text = regoNum;
            textBoxRoad.Text = roadStreet;
            textBoxDate.Text = timeDate;
            textBoxLocality.Text = region;
            textBoxMake.Text = make;
            textBoxModel.Text = model;
            textBoxLocation.Text = offenseLocation;
            textBoxDesc.Text = description;
            textBoxFeePayable.Text = amount;
            textBoxSpeedLimit.Text = speedLimit;
            textBoxSpeedAlleged.Text = speedAlleged;
            textBoxExcessSpeed.Text = excessSpeed;
            textBox1.Text = dayOfWeek;

            dateTime = timeDate.Split(' ');
            textBoxPayableAfter.Text = dateTime[0];
        }

        public void createSummaryStats()
        {
            textBoxTotalOffenses.Text = summaryReportStats("numOffenses");
            textBoxTotalFees.Text = "$" + summaryReportStats("sumOfInfringements");
            textBoxAvgExcessSpeed.Text = summaryReportStats("averageExcessSpeed") + "km/h";
            textBoxCommonOffenceDay.Text = summaryReportStats("offenceDayOfWeekCommon");
            textBoxCommonOffenceMake.Text = summaryReportStats("offenceVehicleMakeCommon");
        }

    }
}
