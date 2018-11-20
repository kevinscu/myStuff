using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RelayInsuranceApplication
{
    public partial class Form1 : Form
    {
        
        int discount = 0;
        int d1age;
        double d2age;
        int d3age;
        int d4age;
        int d5age;
        int premium = 500;
        int validation = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
         
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime todaysDate = DateTime.Now;
            DateTime dateSelected = dateTimePickerStartDate.Value;
            int result = DateTime.Compare(dateSelected, todaysDate);

            if (result <= 0)
            {
                MessageBox.Show("Start Date of Policy");
            }

            else if (result > 0)
            {
                DateTime minusFiveYear = dateSelected.AddYears(-5);
                DateTime plusOneYear = dateSelected.AddYears(1);
                dateTimePickerEndDate.Value = plusOneYear;
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel3.Enabled = true;
                panel4.Enabled = true;
                panel5.Enabled = true;
                d1lastFiveYrs.Text = minusFiveYear.ToShortDateString();
                d2lastFiveYrs.Text = minusFiveYear.ToShortDateString();
                d3lastFiveYrs.Text = minusFiveYear.ToShortDateString();
                d4lastFiveYrs.Text = minusFiveYear.ToShortDateString();
                d5lastFiveYrs.Text = minusFiveYear.ToShortDateString();
                DateTime isdriverover21AtStartDateOfPolicy = dateSelected.AddYears(-21);
                DateTime isdriverlessthat25AtStartDateOfPolicy = dateSelected.AddYears(-25);


            }




        }

        /////////// CALCULATE DRIVER ONE AGE FROM DOB ENTERED ///////////////////////
        //FEATURE NOT DISPLAYING AGE CORRECTLY IN STRING FORMAT SO HIDDEN FOR NOW////
        private void d1DOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime from = d1DOBdateTimePicker.Value;
            DateTime to = DateTime.Now;
            TimeSpan TSpan = to - from;
            double days = TSpan.TotalDays;
            dOneAge.Enabled = true;
            dOneAge.Text = (days / 365).ToString("{0:0.##");
            d1age = (int)(days / 365);
        }

        // CALCULATE DRIVER TWO AGE FROM DOB ENTERED //
        private void dTwoDOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dTwoDOBdateTimePicker.Value;
            DateTime to = DateTime.Now;
            TimeSpan TSpan = to - from;
            double days = TSpan.TotalDays;
            dTwoAge.Enabled = true;
            dTwoAge.Text = (days / 365).ToString("0");
            d2age = (int)(days / 365);
        }

        // CALCULATE DRIVER THREE AGE FROM DOB ENTERED //
        private void dThreeDOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            DateTime from = dThreeDOBdateTimePicker.Value;
            DateTime to = DateTime.Now;
            TimeSpan TSpan = to - from;
            double days = TSpan.TotalDays;
            dThreeAge.Enabled = true;
            dThreeAge.Text = (days / 365).ToString("0");
            d3age = (int)(days / 365);
        }

        // CALCULATE DRIVER FOUR AGE FROM DOB ENTERED //
        private void dFourDOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dThreeDOBdateTimePicker.Value;
            DateTime to = DateTime.Now;
            TimeSpan TSpan = to - from;
            double days = TSpan.TotalDays;
            dFourAge.Enabled = true;
            dFourAge.Text = (days / 365).ToString("0");
            d4age = (int)(days / 365);
        }

        // CALCULATE DRIVER FIVE AGE FROM DOB ENTERED //
        private void dFiveDOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dThreeDOBdateTimePicker.Value;
            DateTime to = DateTime.Now;
            TimeSpan TSpan = to - from;
            double days = TSpan.TotalDays;
            dFiveAge.Enabled = true;
            dFiveAge.Text = (days / 365).ToString("0");
            d5age = (int)(days / 365);

        }


        // SUMMARY: DRIVER NUMBER OF CLAIMS IN LAST FIVE YEARS.
        /////////   FINDS OUT IF DRIVER HAD ANY OTHER CLAIMS IN LAST 5 YEARS     ////////
        /////////   FROM POLICY START DATE. IF DRIVER HAS HAD CLAIMS THEN MAKE   ////////
        /////////   SIMILAR NUMBER OF DATEPICKER TOOLS VISIBLE TO ENTER DATES    ////////
        /////////   OF CLAIMS. IF DRIVER HAD NO CLAIMS THEN KEEP ALL DATEPICKER  ////////
        /////////   TOOLS INVISIBLE.                                             ////////
        // DRIVER 1
        private void d1noOfClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d1noOfClaimsMade.SelectedIndex == 0)
            {
                d1claimOneDateTimePicker.Visible = false;
                d1claimTwoDateTimePicker.Visible = false;
                d1claimThreeDateTimePicker.Visible = false;
                d1claimFourDateTimePicker.Visible = false;
                d1claimFiveDateTimePicker.Visible = false;
            }
            else if (d1noOfClaimsMade.SelectedIndex == 1)
            {
                d1claimOneDateTimePicker.Visible  = true;
                d1claimTwoDateTimePicker.Visible = false;
                d1claimThreeDateTimePicker.Visible = false;
                d1claimFourDateTimePicker.Visible = false;
                d1claimFiveDateTimePicker.Visible = false;
            }

            else if (d1noOfClaimsMade.SelectedIndex == 2)
            {
                d1claimOneDateTimePicker.Visible  = true;
                d1claimTwoDateTimePicker.Visible = true;
                d1claimThreeDateTimePicker.Visible = false;
                d1claimFourDateTimePicker.Visible = false;
                d1claimFiveDateTimePicker.Visible = false;
            }

            else if (d1noOfClaimsMade.SelectedIndex == 3)
            {
                d1claimOneDateTimePicker.Visible = true;
                d1claimTwoDateTimePicker.Visible  = true;
                d1claimThreeDateTimePicker.Visible  = true;
                d1claimFourDateTimePicker.Visible = false;
                d1claimFiveDateTimePicker.Visible = false;
            }

            else if (d1noOfClaimsMade.SelectedIndex == 4)
            {
                d1claimOneDateTimePicker.Visible  = true;
                d1claimTwoDateTimePicker.Visible = true;
                d1claimThreeDateTimePicker.Visible  = true;
                d1claimFourDateTimePicker.Visible  = true;
                d1claimFiveDateTimePicker.Visible  = false;
            }
            else if (d1noOfClaimsMade.SelectedIndex == 5)
            {
                d1claimOneDateTimePicker.Visible  = true;
                d1claimTwoDateTimePicker.Visible  = true;
                d1claimThreeDateTimePicker.Visible  = true;
                d1claimFourDateTimePicker.Visible  = true;
                d1claimFiveDateTimePicker.Visible = true;
            }
        }
        // DRIVER 2
        private void d2NoOfClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d2NoOfClaimsMade.SelectedIndex == 0)
            {
                d2claimOneDateTimePicker.Visible = false;
                d2claimTwoDateTimePicker.Visible = false;
                d2claimThreeDateTimePicker.Visible = false;
                d2claimFourDateTimePicker.Visible = false;
                d2claimFiveDateTimePicker.Visible = false;
            }
            else if (d2NoOfClaimsMade.SelectedIndex == 1)
            {
                d2claimOneDateTimePicker.Visible  = true;
                d2claimTwoDateTimePicker.Visible = false;
                d2claimThreeDateTimePicker.Visible = false;
                d2claimFourDateTimePicker.Visible = false;
                d2claimFiveDateTimePicker.Visible = false;
            }

            else if (d2NoOfClaimsMade.SelectedIndex == 2)
            {
                d2claimOneDateTimePicker.Visible  = true;
                d2claimTwoDateTimePicker.Visible = true;
                d2claimThreeDateTimePicker.Visible  = false;
                d2claimFourDateTimePicker.Visible =false;
                d2claimFiveDateTimePicker.Visible = false;
            }

            else if (d2NoOfClaimsMade.SelectedIndex == 3)
            {
                d2claimOneDateTimePicker.Visible = true;
                d2claimTwoDateTimePicker.Visible  = true;
                d2claimThreeDateTimePicker.Visible  = true;
                d2claimFourDateTimePicker.Visible = false;
                d2claimFiveDateTimePicker.Visible  = false;
            }

            else if (d2NoOfClaimsMade.SelectedIndex == 4)
            {
                d2claimOneDateTimePicker.Visible = true;
                d2claimTwoDateTimePicker.Visible  = true;
                d2claimThreeDateTimePicker.Visible  = true;
                d2claimFourDateTimePicker.Visible = true;
                d2claimFiveDateTimePicker.Visible = false;
            }
            else if (d2NoOfClaimsMade.SelectedIndex == 5)
            {
                d2claimOneDateTimePicker.Visible  = true;
                d2claimTwoDateTimePicker.Visible  = true;
                d2claimThreeDateTimePicker.Visible  = true;
                d2claimFourDateTimePicker.Visible  = true;
                d2claimFiveDateTimePicker.Visible = true;
            }
        }
        // DRIVER 3
        private void d3NoOfClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d3NoOfClaimsMade.SelectedIndex == 0)
            {
                d3claimOneDateTimePicker.Visible = false;
                d3claimTwoDateTimePicker.Visible = false;
                d3claimThreeDateTimePicker.Visible = false;
                d3claimFourDateTimePicker.Visible = false;
                d3claimFiveDateTimePicker.Visible = false;
            }
            else if (d3NoOfClaimsMade.SelectedIndex == 1)
            {
                d3claimOneDateTimePicker.Visible = true;
                d3claimTwoDateTimePicker.Visible = false;
                d3claimThreeDateTimePicker.Visible = false;
                d3claimFourDateTimePicker.Visible = false;
                d3claimFiveDateTimePicker.Visible = false;
            }

            else if (d3NoOfClaimsMade.SelectedIndex == 2)
            {
                d3claimOneDateTimePicker.Visible = true;
                d3claimTwoDateTimePicker.Visible = true;
                d3claimThreeDateTimePicker.Visible = false;
                d3claimFourDateTimePicker.Visible = false;
                d3claimFiveDateTimePicker.Visible = false;
            }

            else if (d3NoOfClaimsMade.SelectedIndex == 3)
            {
                d3claimOneDateTimePicker.Visible = true;
                d3claimTwoDateTimePicker.Visible = true;
                d3claimThreeDateTimePicker.Visible = true;
                d3claimFourDateTimePicker.Visible = false;
                d3claimFiveDateTimePicker.Visible = false;
            }

            else if (d3NoOfClaimsMade.SelectedIndex == 4)
            {
                d3claimOneDateTimePicker.Visible = true;
                d3claimTwoDateTimePicker.Visible = true;
                d3claimThreeDateTimePicker.Visible = true;
                d3claimFourDateTimePicker.Visible = true;
                d3claimFiveDateTimePicker.Visible = false;
            }
            else if (d3NoOfClaimsMade.SelectedIndex == 5)
            {
                d3claimOneDateTimePicker.Visible = true;
                d3claimTwoDateTimePicker.Visible = true;
                d3claimThreeDateTimePicker.Visible = true;
                d3claimFourDateTimePicker.Visible = true;
                d3claimFiveDateTimePicker.Visible = true;
            }
        }
        // DRIVER 4
        private void d4NoOfClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d4NoOfClaimsMade.SelectedIndex == 0)
            {
                d4claimOneDateTimePicker.Visible = false;
                d4claimTwoDateTimePicker.Visible = false;
                d4claimThreeDateTimePicker.Visible = false;
                d4claimFourDateTimePicker.Visible = false;
                d4claimFiveDateTimePicker.Visible = false;
            }
            else if (d4NoOfClaimsMade.SelectedIndex == 1)
            {
                d4claimOneDateTimePicker.Visible = true;
                d4claimTwoDateTimePicker.Visible = false;
                d4claimThreeDateTimePicker.Visible = false;
                d4claimFourDateTimePicker.Visible = false;
                d4claimFiveDateTimePicker.Visible = false;
            }

            else if (d4NoOfClaimsMade.SelectedIndex == 2)
            {
                d4claimOneDateTimePicker.Visible = true;
                d4claimTwoDateTimePicker.Visible = true;
                d4claimThreeDateTimePicker.Visible = false;
                d4claimFourDateTimePicker.Visible = false;
                d4claimFiveDateTimePicker.Visible = false;
            }

            else if (d4NoOfClaimsMade.SelectedIndex == 3)
            {
                d4claimOneDateTimePicker.Visible = true;
                d4claimTwoDateTimePicker.Visible = true;
                d4claimThreeDateTimePicker.Visible = true;
                d4claimFourDateTimePicker.Visible = false;
                d4claimFiveDateTimePicker.Visible = false;
            }

            else if (d4NoOfClaimsMade.SelectedIndex == 4)
            {
                d4claimOneDateTimePicker.Visible = true;
                d4claimTwoDateTimePicker.Visible = true;
                d4claimThreeDateTimePicker.Visible = true;
                d4claimFourDateTimePicker.Visible = true;
                d2claimFiveDateTimePicker.Visible = false;
            }
            else if (d4NoOfClaimsMade.SelectedIndex == 5)
            {
                d4claimOneDateTimePicker.Visible = true;
                d4claimTwoDateTimePicker.Visible = true;
                d4claimThreeDateTimePicker.Visible = true;
                d4claimFourDateTimePicker.Visible = true;
                d4claimFiveDateTimePicker.Visible = true;
            }

        }
        // DRIVER 5
        private void d5NoOfClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d5NoOfClaimsMade.SelectedIndex == 0)
            {
                d5claimOneDateTimePicker.Visible = false;
                d5claimTwoDateTimePicker.Visible = false;
                d5claimThreeDateTimePicker.Visible = false;
                d5claimFourDateTimePicker.Visible = false;
                d5claimFiveDateTimePicker.Visible = false;
            }
            else if (d5NoOfClaimsMade.SelectedIndex == 1)
            {
                d5claimOneDateTimePicker.Visible = true;
                d5claimTwoDateTimePicker.Visible = false;
                d5claimThreeDateTimePicker.Visible = false;
                d5claimFourDateTimePicker.Visible = false;
                d5claimFiveDateTimePicker.Visible = false;
            }

            else if (d5NoOfClaimsMade.SelectedIndex == 2)
            {
                d5claimOneDateTimePicker.Visible = true;
                d5claimTwoDateTimePicker.Visible = true;
                d5claimThreeDateTimePicker.Visible = false;
                d5claimFourDateTimePicker.Visible = false;
                d5claimFiveDateTimePicker.Visible = false;
            }

            else if (d5NoOfClaimsMade.SelectedIndex == 3)
            {
                d5claimOneDateTimePicker.Visible = true;
                d5claimTwoDateTimePicker.Visible = true;
                d5claimThreeDateTimePicker.Visible = true;
                d5claimFourDateTimePicker.Visible = false;
                d5claimFiveDateTimePicker.Visible = false;
            }

            else if (d5NoOfClaimsMade.SelectedIndex == 4)
            {
                d5claimOneDateTimePicker.Visible = true;
                d5claimTwoDateTimePicker.Visible = true;
                d5claimThreeDateTimePicker.Visible = true;
                d5claimFourDateTimePicker.Visible = true;
                d5claimFiveDateTimePicker.Visible = false;
            }
            else if (d5NoOfClaimsMade.SelectedIndex == 5)
            {
                d5claimOneDateTimePicker.Visible = true;
                d5claimTwoDateTimePicker.Visible = true;
                d5claimThreeDateTimePicker.Visible = true;
                d5claimFourDateTimePicker.Visible = true;
                d5claimFiveDateTimePicker.Visible = true;
            }
        }



        // SUMMARY: CONTROLS NUMBER OF DRIVER FORM ENTRIES ON SCREEN
        //////   THIS CODE CONTROLS THE NUMBER OF DRIVER ENTRY FORMS THE USER CAN   /////
        //////   EDIT ON SCREEN. IT MAKES THE DRIVER INPUT FORMS VISIBLE/INVISIBLE  /////
        //////   TO THE USER VIA 5 PANELS THAT HAVE THEIR VISIBILITY PROPERTY       /////
        //////   CONTROLLED BY NUMBER OF DRIVERS SELECTED.                          /////

        private void noOfDrivers_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (noOfDrivers.SelectedIndex == 0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;

                noOfDrivers.SelectedIndex = -1;
                dateTimePickerStartDate.Enabled = true;
            }
            else if (noOfDrivers.SelectedIndex == 1)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                noOfDrivers.SelectedIndex = -1;
                dateTimePickerStartDate.Enabled = true;
            }
            else if (noOfDrivers.SelectedIndex == 2)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = false;
                panel5.Visible = false;
                dateTimePickerStartDate.Enabled = true;
            }
            else if (noOfDrivers.SelectedIndex == 3)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = false;
                dateTimePickerStartDate.Enabled = true;
            }
            else if (noOfDrivers.SelectedIndex == 4)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                dateTimePickerStartDate.Enabled = true;
            }
        }
                
        // SUMMARY: CALCULATES QUOTE PREMIUM 
        // FINDS OUT IF ANY DRIVERS HAVE OCCUPATION OF EITHER CHAUFFEUR OR ACCOUNTANT//
        // IF CHAUFFEUR INCREASE POLICY BY 20%. IF ACCOUNTANT DECREASE POLICY BY 10% //
       
        private void getQuoteButton_Click(object sender, EventArgs e)
        {
            int[] occupationCheck = new int[5];
            occupationCheck[0] = dOneOccupation.SelectedIndex;
            occupationCheck[1] = dTwoOccupation.SelectedIndex;
            occupationCheck[2] = dThreeOccupation.SelectedIndex;
            occupationCheck[3] = dFourOccupation.SelectedIndex;
            occupationCheck[4] = dFiveOccupation.SelectedIndex;
   
            for (int i = 0; i < occupationCheck.Length; i++)
            {
                if (occupationCheck[i] == 5)
                    //Test hook...MessageBox.Show("Driver is Chauffeur");
                    discount += 50;
                if (occupationCheck[i] == 0)
                    //Test hook...MessageBox.Show("Driver is Accountant");
                    discount -= 50;
            }

            //SUMMARY: CHECKS DRIVERS AGE AT START OF POLICY AND ADJUST PREMIUM ACCORDINGLY  ///////////////////////////////////

            ///First timespan is total days from driver DOB to Policy start date i.e. days old driver is at Policy start date///
            // Creates four additional timespans of 21yrs,25yrs,26yrs and 75yrs to work out what age category driver falls into.// 
            /////////////////////   If driver is between 21 and 25 at start of policy increase premium by 20%  /////////////////
            /////////////////////   If driver is between 26 and 75 at start of policy increase premium by 10%  /////////////////
            
            //DRIVER 1
            //Finds the drivers DOB value //
            DateTime driver1DOB = d1DOBdateTimePicker.Value;
            //Finds the Policy start date value //
            DateTime policyStartDate = dateTimePickerStartDate.Value;
            // Find the time span between Driver DOB and Policy Start Date//
            TimeSpan d1DobToPolicyStart = policyStartDate - driver1DOB;
            // Convert this time span into days. This is the total days old the driver will be at start of policy//
            int d1DobToPolicyStartInDays = d1DobToPolicyStart.Days;

            // Code below creates a second timespan of twenty one years in days to compare against //
            // previous timespan from driver DOB to Policy Start date. If the first time span is less than // 
            // 21 year timespan then driver is UNDER 21 yrs old and vice versa. Other timespans are also created to check // 
            //  driver age at start of policy.                                                                      //

            //Finds a start date of drivers DOB to add twenty one years onto//
            DateTime startPoint = d1DOBdateTimePicker.Value;
            //Adds four variables to hold timespans of 21 years, 25 years, 26 years and 75 years onto this start Point/Date//
            DateTime startPointPlus21Years = startPoint.AddYears(21);
            DateTime startPointPlus25Years = startPoint.AddYears(25);
            DateTime startPointPlus26Years = startPoint.AddYears(26);
            DateTime startPointPlus75Years = startPoint.AddYears(75);
            //Creates a Timespan of 21 years, 25 years, 26 years and 75 years.//
            TimeSpan timeSpanOf21Years = (startPointPlus21Years - startPoint);
            TimeSpan timeSpanOf25Years = (startPointPlus25Years - startPoint);
            TimeSpan timeSpanOf26Years = (startPointPlus26Years - startPoint);
            TimeSpan timeSpanOf75Years = (startPointPlus75Years - startPoint);
            //Converts each timespan into days so we can work out what age category driver falls into at Policy start date//

            int d1twentyOneYearsInDays = timeSpanOf21Years.Days;
            int d1twentyFiveYearsInDays = timeSpanOf25Years.Days;
            int d1twentySixYearsInDays = timeSpanOf26Years.Days;
            int d1seventyFiveYearsInDays = timeSpanOf75Years.Days;

            if (d1DobToPolicyStartInDays < d1twentyOneYearsInDays && panel1.Visible == true)
            {
              
                validation += 1;
                MessageBox.Show("Declined -" + dOneNameTextBox.Text + " is below 21yrs old.");

            }
            else if (d1DobToPolicyStartInDays > d1seventyFiveYearsInDays && panel1.Visible == true)
            {
               
                validation += 1;
                MessageBox.Show("Declined - " + dOneNameTextBox.Text + "is over 75 yrs old" );

            }

            if (d1DobToPolicyStartInDays >= d1twentyOneYearsInDays && d1DobToPolicyStartInDays <= d1twentyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is 21 or over and and less than or equal to 25 yrs old at start of Policy");
                discount += 100;
            }
            
            else if (d1DobToPolicyStartInDays >= d1twentySixYearsInDays && d1DobToPolicyStartInDays <= d1seventyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is over 26 and and less than or equal to 75 yrs old at start of Policy");
                discount -= 50;
            }

            
            //DRIVER 2
            //Finds the drivers DOB value //
            DateTime driver2DOB = dTwoDOBdateTimePicker.Value;
            //Finds the Policy start date value //
            DateTime d2policyStartDate = dateTimePickerStartDate.Value;
            // Find the time span between Driver DOB and Policy Start Date//
            TimeSpan d2DobToPolicyStart = d2policyStartDate - driver2DOB;
            // Convert this time span into days. This is the total days old the driver will be at start of policy//
            int d2DobToPolicyStartInDays = d2DobToPolicyStart.Days;

            // Code below creates a second timespan of twenty one years in days to compare against //
            // previous timespan from driver DOB to Policy Start date. If the first time span is less than // 
            // 21 year timespan then driver is UNDER 21 yrs old and vice versa. Other timespans are also created to check // 
            //  driver age at start of policy.                                                                      //

            //Finds a start date of drivers DOB to add twenty one years onto//
            DateTime d2startPoint = dTwoDOBdateTimePicker.Value;
            //Adds four variables to hold timespans of 21 years, 25 years, 26 years and 75 years onto this start Point/Date//
            DateTime d2startPointPlus21Years = d2startPoint.AddYears(21);
            DateTime d2startPointPlus25Years = d2startPoint.AddYears(25);
            DateTime d2startPointPlus26Years = d2startPoint.AddYears(26);
            DateTime d2startPointPlus75Years = d2startPoint.AddYears(75);
            //Creates a Timespan of 21 years, 25 years, 26 years and 75 years.//
            TimeSpan d2timeSpanOf21Years = (d2startPointPlus21Years - d2startPoint);
            TimeSpan d2timeSpanOf25Years = (d2startPointPlus25Years - d2startPoint);
            TimeSpan d2timeSpanOf26Years = (d2startPointPlus26Years - d2startPoint);
            TimeSpan d2timeSpanOf75Years = (d2startPointPlus75Years - d2startPoint);
            //Converts each timespan into days so we can work out what age category driver falls into at Policy start date//

            int d2twentyOneYearsInDays = d2timeSpanOf21Years.Days;
            int d2twentyFiveYearsInDays = d2timeSpanOf25Years.Days;
            int d2twentySixYearsInDays = d2timeSpanOf26Years.Days;
            int d2seventyFiveYearsInDays = d2timeSpanOf75Years.Days;

            if (d2DobToPolicyStartInDays < d2twentyOneYearsInDays && panel2.Visible == true)
            {
              
                validation += 1;
                MessageBox.Show("Declined -" + dTwoNameTextbox.Text + " is below 21yrs old." );

            }
            else if (d2DobToPolicyStartInDays > d2seventyFiveYearsInDays && panel2.Visible == true)
            {
             
                validation += 1;
                MessageBox.Show("Declined - " + dTwoNameTextbox.Text + "is over 75 yrs old");

            }

            if (d2DobToPolicyStartInDays >= d2twentyOneYearsInDays && d2DobToPolicyStartInDays <= d2twentyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is 21 or over and and less than or equal to 25 yrs old at start of Policy");
                discount += 100;
            }

            else if (d2DobToPolicyStartInDays >= d2twentySixYearsInDays && d2DobToPolicyStartInDays <= d2seventyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is over 26 and and less than or equal to 75 yrs old at start of Policy");
                discount -= 50;
            }

            //DRIVER 3
            //Finds the drivers DOB value //
            DateTime driver3DOB = dThreeDOBdateTimePicker.Value;
            //Finds the Policy start date value //
            DateTime d3policyStartDate = dateTimePickerStartDate.Value;
            // Find the time span between Driver DOB and Policy Start Date//
            TimeSpan d3DobToPolicyStart = d3policyStartDate - driver3DOB;
            // Convert this time span into days. This is the total days old the driver will be at start of policy//
            int d3DobToPolicyStartInDays = d3DobToPolicyStart.Days;

            // Code below creates a second timespan of twenty one years in days to compare against //
            // previous timespan from driver DOB to Policy Start date. If the first time span is less than // 
            // 21 year timespan then driver is UNDER 21 yrs old and vice versa. Other timespans are also created to check // 
            //  driver age at start of policy.                                                                      //

            //Finds a start date of drivers DOB to add twenty one years onto//
            DateTime d3startPoint = dThreeDOBdateTimePicker.Value;
            //Adds four variables to hold timespans of 21 years, 25 years, 26 years and 75 years onto this start Point/Date//
            DateTime d3startPointPlus21Years = d3startPoint.AddYears(21);
            DateTime d3startPointPlus25Years = d3startPoint.AddYears(25);
            DateTime d3startPointPlus26Years = d3startPoint.AddYears(26);
            DateTime d3startPointPlus75Years = d3startPoint.AddYears(75);
            //Creates a Timespan of 21 years, 25 years, 26 years and 75 years.//
            TimeSpan d3timeSpanOf21Years = (d3startPointPlus21Years - d3startPoint);
            TimeSpan d3timeSpanOf25Years = (d3startPointPlus25Years - d3startPoint);
            TimeSpan d3timeSpanOf26Years = (d3startPointPlus26Years - d3startPoint);
            TimeSpan d3timeSpanOf75Years = (d3startPointPlus75Years - d3startPoint);
            //Converts each timespan into days so we can work out what age category driver falls into at Policy start date//

            int d3twentyOneYearsInDays = d3timeSpanOf21Years.Days;
            int d3twentyFiveYearsInDays = d3timeSpanOf25Years.Days;
            int d3twentySixYearsInDays = d3timeSpanOf26Years.Days;
            int d3seventyFiveYearsInDays = d3timeSpanOf75Years.Days;

            if (d3DobToPolicyStartInDays < d3twentyOneYearsInDays && panel3.Visible == true)
            {
           
                validation += 1;
                MessageBox.Show("Declined -" + dThreeNameTextbox.Text + " is below 21yrs old.");

            }
            else if (d3DobToPolicyStartInDays > d3seventyFiveYearsInDays && panel3.Visible == true)
            {
                
                validation += 1;
                MessageBox.Show("Declined - " + dThreeNameTextbox.Text + "is over 75 yrs old");

            }

            if (d3DobToPolicyStartInDays > d3twentyOneYearsInDays && d3DobToPolicyStartInDays <= d3twentyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is 21 or over and and less than or equal to 25 yrs old at start of Policy");
                discount += 100;
            }

            else if (d3DobToPolicyStartInDays > d3twentyFiveYearsInDays && d3DobToPolicyStartInDays < d3seventyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is over 26 and and less than or equal to 75 yrs old at start of Policy");
                discount -= 50;
            }


            //DRIVER 4
            //Finds the drivers DOB value //
            DateTime driver4DOB = dFourDOBdateTimePicker.Value;
            //Finds the Policy start date value //
            DateTime d4policyStartDate = dateTimePickerStartDate.Value;
            // Find the time span between Driver DOB and Policy Start Date//
            TimeSpan d4DobToPolicyStart = d4policyStartDate - driver4DOB;
            // Convert this time span into days. This is the total days old the driver will be at start of policy//
            int d4DobToPolicyStartInDays = d4DobToPolicyStart.Days;

            // Code below creates a second timespan of twenty one years in days to compare against //
            // previous timespan from driver DOB to Policy Start date. If the first time span is less than // 
            // 21 year timespan then driver is UNDER 21 yrs old and vice versa. Other timespans are also created to check // 
            //  driver age at start of policy.                                                                      //

            //Finds a start date of drivers DOB to add twenty one years onto//
            DateTime d4startPoint = dFourDOBdateTimePicker.Value;
            //Adds four variables to hold timespans of 21 years, 25 years, 26 years and 75 years onto this start Point/Date//
            DateTime d4startPointPlus21Years = d4startPoint.AddYears(21);
            DateTime d4startPointPlus25Years = d4startPoint.AddYears(25);
            DateTime d4startPointPlus26Years = d4startPoint.AddYears(26);
            DateTime d4startPointPlus75Years = d4startPoint.AddYears(75);
            //Creates a Timespan of 21 years, 25 years, 26 years and 75 years.//
            TimeSpan d4timeSpanOf21Years = (d4startPointPlus21Years - d4startPoint);
            TimeSpan d4timeSpanOf25Years = (d4startPointPlus25Years - d4startPoint);
            TimeSpan d4timeSpanOf26Years = (d4startPointPlus26Years - d4startPoint);
            TimeSpan d4timeSpanOf75Years = (d4startPointPlus75Years - d4startPoint);
            //Converts each timespan into days so we can work out what age category driver falls into at Policy start date//

            int d4twentyOneYearsInDays = d4timeSpanOf21Years.Days;
            int d4twentyFiveYearsInDays = d4timeSpanOf25Years.Days;
            int d4twentySixYearsInDays = d4timeSpanOf26Years.Days;
            int d4seventyFiveYearsInDays = d4timeSpanOf75Years.Days;

            if (d4DobToPolicyStartInDays < d4twentyOneYearsInDays && panel4.Visible == true)
            {
            
                validation += 1;
                MessageBox.Show("Declined -" + dFourNameTextbox.Text + " is below 21yrs old.");

            }
            else if (d4DobToPolicyStartInDays > d4seventyFiveYearsInDays && panel4.Visible == true)
            {
             
                validation += 1;
                MessageBox.Show("Declined - " + dFourNameTextbox.Text + "is over 75 yrs old");

            }

            if (d4DobToPolicyStartInDays > d4twentyOneYearsInDays && d4DobToPolicyStartInDays <= d4twentyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is 21 or over and and less than or equal to 25 yrs old at start of Policy");
                discount += 100;
            }

            else if (d4DobToPolicyStartInDays > d4twentyFiveYearsInDays && d4DobToPolicyStartInDays < d4seventyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is over 26 and and less than or equal to 75 yrs old at start of Policy");
                discount -= 50;
            }

            //DRIVER 5
            //Finds the drivers DOB value //
            DateTime driver5DOB = dFiveDOBdateTimePicker.Value;
            //Finds the Policy start date value //
            DateTime d5policyStartDate = dateTimePickerStartDate.Value;
            // Find the time span between Driver DOB and Policy Start Date//
            TimeSpan d5DobToPolicyStart = d5policyStartDate - driver5DOB;
            // Convert this time span into days. This is the total days old the driver will be at start of policy//
            int d5DobToPolicyStartInDays = d5DobToPolicyStart.Days;

            // Code below creates a second timespan of twenty one years in days to compare against //
            // previous timespan from driver DOB to Policy Start date. If the first time span is less than // 
            // 21 year timespan then driver is UNDER 21 yrs old and vice versa. Other timespans are also created to check // 
            //  driver age at start of policy.                                                                      //

            //Finds a start date of drivers DOB to add twenty one years onto//
            DateTime d5startPoint = dFiveDOBdateTimePicker.Value;
            //Adds four variables to hold timespans of 21 years, 25 years, 26 years and 75 years onto this start Point/Date//
            DateTime d5startPointPlus21Years = d5startPoint.AddYears(21);
            DateTime d5startPointPlus25Years = d5startPoint.AddYears(25);
            DateTime d5startPointPlus26Years = d5startPoint.AddYears(26);
            DateTime d5startPointPlus75Years = d5startPoint.AddYears(75);
            //Creates a Timespan of 21 years, 25 years, 26 years and 75 years.//
            TimeSpan d5timeSpanOf21Years = (d5startPointPlus21Years - d5startPoint);
            TimeSpan d5timeSpanOf25Years = (d5startPointPlus25Years - d5startPoint);
            TimeSpan d5timeSpanOf26Years = (d5startPointPlus26Years - d5startPoint);
            TimeSpan d5timeSpanOf75Years = (d5startPointPlus75Years - d5startPoint);
            //Converts each timespan into days so we can work out what age category driver falls into at Policy start date//

            int d5twentyOneYearsInDays = d5timeSpanOf21Years.Days;
            int d5twentyFiveYearsInDays = d5timeSpanOf25Years.Days;
            int d5twentySixYearsInDays = d5timeSpanOf26Years.Days;
            int d5seventyFiveYearsInDays = d5timeSpanOf75Years.Days;

            if (d5DobToPolicyStartInDays < d5twentyOneYearsInDays && panel5.Visible == true)
            {
              
                validation += 1;
                MessageBox.Show ("Declined -" + dFiveNameTextbox.Text + " is below 21yrs old.");

            }
            else if (d5DobToPolicyStartInDays > d5seventyFiveYearsInDays && panel5.Visible == true)
            {
              
                validation += 1;
                MessageBox.Show("Declined - " + dFiveNameTextbox.Text + "is over 75 yrs old");

            }

            if (d5DobToPolicyStartInDays > d5twentyOneYearsInDays && d5DobToPolicyStartInDays <= d5twentyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is 21 or over and and less than or equal to 25 yrs old at start of Policy");
                discount += 100;
            }

            else if (d5DobToPolicyStartInDays > d5twentyFiveYearsInDays && d5DobToPolicyStartInDays < d5seventyFiveYearsInDays)
            {
                //Test hook....MessageBox.Show("Driver is over 26 and and less than or equal to 75 yrs old at start of Policy");
                discount -= 50;
            }



            //Checks if any claims made are less than one year or between 2 - 5 years.//
            //If claims are within one year of Policy start date then increase premium by 20%//
            //If claims are within 2 - 5 years of Policy start date increase policy by 10 %//

            if (d1noOfClaimsMade.SelectedIndex  ==1)

                {
                //Gets the claim date//
                DateTime d1NoOneClaimdate = d1claimOneDateTimePicker.Value;
                //Gets the Policy Start date//
                DateTime d1PolicyStartDate = dateTimePickerStartDate.Value;
                //Creates a timespan between date of claim and policy start date//
                TimeSpan d1CheckYearFromStartOfPolicy = (d1PolicyStartDate - d1NoOneClaimdate);
                //Creates 3 dates of 1 year, 2 years and 5 years from policy start date//
                DateTime d1oneYearDate = d1PolicyStartDate.AddYears(1);
                DateTime d1twoYearDate = d1PolicyStartDate.AddYears(2);
                DateTime d1fiveYearDate = d1PolicyStartDate.AddYears(5);
               // Creates 3 Timespans of 1,3 & 5 years from Policy Start date//
                TimeSpan d1Oneyr = (d1oneYearDate - d1PolicyStartDate);
                TimeSpan d1Twoyr = (d1twoYearDate - d1PolicyStartDate);
                TimeSpan d1Fiveyr = (d1fiveYearDate - d1PolicyStartDate);
                // Calculates the number of days in each timespan aaginst the number of days from claim date to 
                // Policy start date. This will determine what timeslot the claim falls into and how much premium to adjust//
                //
                int d1OneyrIndays = d1Oneyr.Days;
                int d1TwoyrIndays = d1Twoyr.Days;
                int d1FiveyrIndays = d1Fiveyr.Days;
                int claimDateToPSD = d1CheckYearFromStartOfPolicy.Days;


                    if (claimDateToPSD <= d1OneyrIndays)

                    {
                    //Test hook.....MessageBox.Show("driver has a claim within a year of policy start date");
                    discount += 100;
                    }
                    else if (claimDateToPSD >= d1TwoyrIndays && claimDateToPSD <= d1FiveyrIndays)
                    {
                    //Test hook.......MessageBox.Show("Driver has a claim that is between 2 and 5 years of policy start date");
                    discount += 50;
                    }
                 }


            if (d2NoOfClaimsMade.SelectedIndex == 1)

            {
                //Gets the claim date//
                DateTime d2NoOneClaimdate = d2claimOneDateTimePicker.Value;
                //Gets the Policy Start date//
                DateTime d2PolicyStartDate = dateTimePickerStartDate.Value;
                //Creates a timespan between date of claim and policy start date//
                TimeSpan d2CheckYearFromStartOfPolicy = (d2PolicyStartDate - d2NoOneClaimdate);
                //Creates 3 dates of 1 year, 2 years and 5 years from policy start date//
                DateTime d2oneYearDate = d2PolicyStartDate.AddYears(1);
                DateTime d2twoYearDate = d2PolicyStartDate.AddYears(2);
                DateTime d2fiveYearDate = d2PolicyStartDate.AddYears(5);
                // Creates 3 Timespans of 1,3 & 5 years from Policy Start date//
                TimeSpan d2Oneyr = (d2oneYearDate - d2PolicyStartDate);
                TimeSpan d2Twoyr = (d2twoYearDate - d2PolicyStartDate);
                TimeSpan d2Fiveyr = (d2fiveYearDate - d2PolicyStartDate);
                // Calculates the number of days in each timespan aaginst the number of days from claim date to 
                // Policy start date. This will determine what timeslot the claim falls into and how much premium to adjust//
                //
                int d2OneyrIndays = d2Oneyr.Days;
                int d2TwoyrIndays = d2Twoyr.Days;
                int d2FiveyrIndays = d2Fiveyr.Days;
                int claimDateToPSD = d2CheckYearFromStartOfPolicy.Days;


                if (claimDateToPSD <= d2OneyrIndays)

                {
                    //Test hook.....MessageBox.Show("driver has a claim within a year of policy start date");
                    discount += 100;
                }
                else if (claimDateToPSD >= d2TwoyrIndays && claimDateToPSD <= d2FiveyrIndays)
                {
                    //Test hook.......MessageBox.Show("Driver has a claim that is between 2 and 5 years of policy start date");
                    discount += 50;
                }
            }




            if (d3NoOfClaimsMade.SelectedIndex == 1)

            {
                //Gets the claim date//
                DateTime d3NoOneClaimdate = d3claimOneDateTimePicker.Value;
                //Gets the Policy Start date//
                DateTime d3PolicyStartDate = dateTimePickerStartDate.Value;
                //Creates a timespan between date of claim and policy start date//
                TimeSpan d3CheckYearFromStartOfPolicy = (d3PolicyStartDate - d3NoOneClaimdate);
                //Creates 3 dates of 1 year, 2 years and 5 years from policy start date//
                DateTime d3oneYearDate = d3PolicyStartDate.AddYears(1);
                DateTime d3twoYearDate = d3PolicyStartDate.AddYears(2);
                DateTime d3fiveYearDate = d3PolicyStartDate.AddYears(5);
                // Creates 3 Timespans of 1,3 & 5 years from Policy Start date//
                TimeSpan d3Oneyr = (d3oneYearDate - d3PolicyStartDate);
                TimeSpan d3Twoyr = (d3twoYearDate - d3PolicyStartDate);
                TimeSpan d3Fiveyr = (d3fiveYearDate - d3PolicyStartDate);
                // Calculates the number of days in each timespan aaginst the number of days from claim date to 
                // Policy start date. This will determine what timeslot the claim falls into and how much premium to adjust//
                //
                int d3OneyrIndays = d3Oneyr.Days;
                int d3TwoyrIndays = d3Twoyr.Days;
                int d3FiveyrIndays = d3Fiveyr.Days;
                int claimDateToPSD = d3CheckYearFromStartOfPolicy.Days;


                if (claimDateToPSD <= d3OneyrIndays)

                {
                    //Test hook.....MessageBox.Show("driver has a claim within a year of policy start date");
                    discount += 100;
                }
                else if (claimDateToPSD >= d3TwoyrIndays && claimDateToPSD <= d3FiveyrIndays)
                {
                    //Test hook.......MessageBox.Show("Driver has a claim that is between 2 and 5 years of policy start date");
                    discount += 50;
                }
            }


            if (d4NoOfClaimsMade.SelectedIndex == 1)

            {
                //Gets the claim date//
                DateTime d4NoOneClaimdate = d4claimOneDateTimePicker.Value;
                //Gets the Policy Start date//
                DateTime d4PolicyStartDate = dateTimePickerStartDate.Value;
                //Creates a timespan between date of claim and policy start date//
                TimeSpan d4CheckYearFromStartOfPolicy = (d4PolicyStartDate - d4NoOneClaimdate);
                //Creates 3 dates of 1 year, 2 years and 5 years from policy start date//
                DateTime d4oneYearDate = d4PolicyStartDate.AddYears(1);
                DateTime d4twoYearDate = d4PolicyStartDate.AddYears(2);
                DateTime d4fiveYearDate = d4PolicyStartDate.AddYears(5);
                // Creates 3 Timespans of 1,3 & 5 years from Policy Start date//
                TimeSpan d4Oneyr = (d4oneYearDate - d4PolicyStartDate);
                TimeSpan d4Twoyr = (d4twoYearDate - d4PolicyStartDate);
                TimeSpan d4Fiveyr = (d4fiveYearDate - d4PolicyStartDate);
                // Calculates the number of days in each timespan aaginst the number of days from claim date to 
                // Policy start date. This will determine what timeslot the claim falls into and how much premium to adjust//
                //
                int d4OneyrIndays = d4Oneyr.Days;
                int d4TwoyrIndays = d4Twoyr.Days;
                int d4FiveyrIndays = d4Fiveyr.Days;
                int claimDateToPSD = d4CheckYearFromStartOfPolicy.Days;


                if (claimDateToPSD <= d4OneyrIndays)

                {
                    //Test hook.....MessageBox.Show("driver has a claim within a year of policy start date");
                    discount += 100;
                }
                else if (claimDateToPSD >= d4TwoyrIndays && claimDateToPSD <= d4FiveyrIndays)
                {
                    //Test hook.......MessageBox.Show("Driver has a claim that is between 2 and 5 years of policy start date");
                    discount += 50;
                }
            }



            if (d5NoOfClaimsMade.SelectedIndex == 1)

            {
                //Gets the claim date//
                DateTime d5NoOneClaimdate = d5claimOneDateTimePicker.Value;
                //Gets the Policy Start date//
                DateTime d5PolicyStartDate = dateTimePickerStartDate.Value;
                //Creates a timespan between date of claim and policy start date//
                TimeSpan d5CheckYearFromStartOfPolicy = (d5PolicyStartDate - d5NoOneClaimdate);
                //Creates 3 dates of 1 year, 2 years and 5 years from policy start date//
                DateTime d5oneYearDate = d5PolicyStartDate.AddYears(1);
                DateTime d5twoYearDate = d5PolicyStartDate.AddYears(2);
                DateTime d5fiveYearDate = d5PolicyStartDate.AddYears(5);
                // Creates 3 Timespans of 1,3 & 5 years from Policy Start date//
                TimeSpan d5Oneyr = (d5oneYearDate - d5PolicyStartDate);
                TimeSpan d5Twoyr = (d5twoYearDate - d5PolicyStartDate);
                TimeSpan d5Fiveyr = (d5fiveYearDate - d5PolicyStartDate);
                // Calculates the number of days in each timespan aaginst the number of days from claim date to 
                // Policy start date. This will determine what timeslot the claim falls into and how much premium to adjust//
                //
                int d5OneyrIndays = d5Oneyr.Days;
                int d5TwoyrIndays = d5Twoyr.Days;
                int d5FiveyrIndays = d5Fiveyr.Days;
                int claimDateToPSD = d5CheckYearFromStartOfPolicy.Days;


                if (claimDateToPSD <= d5OneyrIndays)

                {
                    //Test hook.....MessageBox.Show("driver has a claim within a year of policy start date");
                    discount += 100;
                }
                else if (claimDateToPSD >= d5TwoyrIndays && claimDateToPSD <= d5FiveyrIndays)
                {
                    //Test hook.......MessageBox.Show("Driver has a claim that is between 2 and 5 years of policy start date");
                    discount += 50;
                }
            }

            //Calculates if driver has had more than one claim. If so,declines with the message " driver has more than one claim2

            if (d1noOfClaimsMade.SelectedIndex > 1)
            {
                validation += 1;
                MessageBox.Show("Declined - " + dOneNameTextBox.Text + "has more than one claim");
            }
            if (d2NoOfClaimsMade.SelectedIndex > 1)
            {
                validation += 1;
                MessageBox.Show("Declined - " + dTwoNameTextbox.Text + "has more than one claim");
            }
            if (d3NoOfClaimsMade.SelectedIndex > 1)
            {
                validation += 1;
                MessageBox.Show("Declined - " + dThreeNameTextbox.Text + "has more than one claim");
            }
            if (d4NoOfClaimsMade.SelectedIndex > 1)
            {
                validation += 1;
                MessageBox.Show("Declined - " + dFourNameTextbox.Text + "has more than one claim");
            }
            if (d5NoOfClaimsMade.SelectedIndex > 1)
            {
                validation += 1;
                MessageBox.Show("Declined - " + dFiveNameTextbox.Text + "has more than one claim");
            }


            premium = premium + discount;

            if (validation == 0)
            {
                MessageBox.Show("The premium cost is " + premium + " for this customer");
            }


            
        }

    
    }

}