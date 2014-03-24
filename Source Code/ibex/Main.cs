using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // used for memorystream and stream functionality
using System.Runtime.Serialization.Formatters.Binary; //used for binaryformatter
using System.Runtime.Serialization; //used for binaryformatter
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

//huge time lag on upload
//***each ROW is being updated/inserted one at a time when uploading the dataset... possibly need to pass dataset to web service on servers

//delete WCF service

//look into better garbage collection

namespace ibex
{
    public partial class Main : Form
    {
        public SqlConnection UNRconn = new SqlConnection("Data Source=BSQLPROJ\\SQLPROJECT;Initial Catalog=ibex;User ID=UNRlogin;Password=2kd&2kc8i1P;Connection Timeout=250");
        public SqlConnection Azureconn = new SqlConnection("Data Source=azureibex.cloudapp.net;Initial Catalog=ibexAzure;User ID=azurelogin;Password=dkcip!35p;Connection Timeout=250");
        public SqlConnection conn = new SqlConnection(); //generic, used in GetConnection to switch between connection strings
        public DataTable TestData = new DataTable(); //table used for storing test data records
        public SqlDataAdapter TestDataAdapter = new SqlDataAdapter(); //adapter used to update records to TestData database

        //global strings used for uploading data to archive
        public string contype;
        public string testType;
        public string server;

        public void GetMedium() //use radio option to find connection type and test type
        {
            //find connection medium
            if (rdoFiber.Checked == true) contype = "Fiber";
            else if (rdoCable.Checked == true) contype = "Cable";
            else if (rdoDSL.Checked == true) contype = "DSL";
            else contype = txtOther.Text;

            //find test type
            if (rdoEqualSize.Checked == true) testType = "Equal Size";
            else if (rdoTPC.Checked == true) testType = "TPC";
            else if (rdoCurve.Checked == true) testType = "Curve";

        }

        public void GetConnection() //select database connection string based on radio box
        {
            //select database connection strings based on radio box
            if (rdoUNR.Checked == true)
            {
                conn = UNRconn; // set conn to UNR connection, used in testing loop
                server = "UNR";
            }
            else if (rdoAzure.Checked == true)
            {
                conn = Azureconn; // set conn to Azure connection, used in testing loop
                server = "Azure";
            }

            ////set testdataadapter connection to Azure

            //TestDataAdapter.SelectCommand.Connection = Azureconn;
            //TestDataAdapter.InsertCommand.Connection = Azureconn;
            //TestDataAdapter.DeleteCommand.Connection = Azureconn;

        }

        public Main()
        {
            InitializeComponent();

            //initialize testdataadapter commands
            TestDataAdapter.SelectCommand = new SqlCommand("SELECT startTime, endTime, seconds, querySize, numRows, serv, contype, test, updown FROM TestData;", Azureconn);
            TestDataAdapter.InsertCommand = new SqlCommand("INSERT INTO TestData (startTime, endTime, seconds, querySize, numRows, serv, contype, test, updown) " +
                                                            "VALUES (@startTime, @endTime, @seconds, @querySize, @numRows, @serv, @contype, @test, @updown); ", Azureconn);
            TestDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM TestData; --DBCC CHECKIDENT('TestData', RESEED, 0)", Azureconn);

            //set sql parameters
            TestDataAdapter.InsertCommand.Parameters.Add("@startTime", SqlDbType.DateTime);
            TestDataAdapter.InsertCommand.Parameters.Add("@endTime", SqlDbType.DateTime);
            TestDataAdapter.InsertCommand.Parameters.Add("@seconds", SqlDbType.Float);
            TestDataAdapter.InsertCommand.Parameters.Add("@querySize", SqlDbType.BigInt);
            TestDataAdapter.InsertCommand.Parameters.Add("@numRows", SqlDbType.Int);
            TestDataAdapter.InsertCommand.Parameters.Add("@serv", SqlDbType.VarChar, 10);
            TestDataAdapter.InsertCommand.Parameters.Add("@contype", SqlDbType.VarChar, 10);
            TestDataAdapter.InsertCommand.Parameters.Add("@test", SqlDbType.VarChar, 15);
            TestDataAdapter.InsertCommand.Parameters.Add("@updown", SqlDbType.VarChar, 8);

            TestDataAdapter.InsertCommand.Parameters["@startTime"].SourceColumn = "startTime";
            TestDataAdapter.InsertCommand.Parameters["@endTime"].SourceColumn = "endTime";
            TestDataAdapter.InsertCommand.Parameters["@seconds"].SourceColumn = "seconds";
            TestDataAdapter.InsertCommand.Parameters["@querySize"].SourceColumn = "querySize";
            TestDataAdapter.InsertCommand.Parameters["@numRows"].SourceColumn = "numRows";
            TestDataAdapter.InsertCommand.Parameters["@serv"].SourceColumn = "serv";
            TestDataAdapter.InsertCommand.Parameters["@contype"].SourceColumn = "contype";
            TestDataAdapter.InsertCommand.Parameters["@test"].SourceColumn = "test";
            TestDataAdapter.InsertCommand.Parameters["@updown"].SourceColumn = "updown";
         
            TestData.Columns.Add("startTime", Type.GetType("System.DateTime"));
            TestData.Columns.Add("endTime", Type.GetType("System.DateTime"));
            TestData.Columns.Add("seconds", Type.GetType("System.Double"));
            TestData.Columns.Add("querySize", Type.GetType("System.Int64"));
            TestData.Columns.Add("numRows", Type.GetType("System.Int32"));
            TestData.Columns.Add("serv", Type.GetType("System.String"));
            TestData.Columns.Add("contype", Type.GetType("System.String"));
            TestData.Columns.Add("test", Type.GetType("System.String"));
            TestData.Columns.Add("updown", Type.GetType("System.String"));

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnDL_Click(object sender, EventArgs e)
        {
            // get connection and medium type from user input
            GetConnection();
            GetMedium();

            //clear archive display table and refresh display with current dataset
            TestData.Clear();
            //conn.Open();
            //TestDataAdapter.Fill(TestData);
            //conn.Close();

            //determine type of test to be performed
            switch (testType)
            {
                case "Equal Size":
                    // execute equal size dataset test
                    ExecuteEqualSize("download");
                    break;

                case "TPC":
                    //execute TPC benchmark test
                    ExecuteTPCTest("download");
                    break;

                case "Curve":
                    //execute long curve test download
                    ExecuteCurveTest("download");
                    break;
                default:
                    MessageBox.Show("Test type not selected");
                    break;
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // get connection and medium type from user input
            GetConnection();
            GetMedium();

            //clear archive display table and refresh display with current dataset
            TestData.Clear();
            //conn.Open();
            //TestDataAdapter.Fill(TestData);
            //conn.Close();

            //determine type of test to be performed
            switch (testType)
            {
                case "Equal Size":
                    // execute equal size dataset test
                    ExecuteEqualSize("upload");
                    break;

                case "TPC":
                    //execute TPC benchmark test
                    ExecuteTPCTest("upload");
                    break;

                case "Curve":
                    //execute long curve test upload
                    ExecuteCurveTest("upload");
                    break;
                default:
                    MessageBox.Show("Test type not selected");
                    break;
            }
        }

        public void ExecuteEqualSize(string upOrDown)
        {
            // declare variables used for keeping timestamps
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            TimeSpan elapse = new TimeSpan();

            //if test is download, perform Equal size dataset test download, if test is upload, perform equal size dataset test upload
            if (upOrDown == "download")
            {
                ////////////////////////////////////
                //Download Equal size dataset Test//
                ////////////////////////////////////

                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter8 = new SqlDataAdapter("SELECT TOP 8 data FROM dl8 ", conn); //used for 8 records of 8k
                SqlDataAdapter dataAdapter8k = new SqlDataAdapter("SELECT TOP 80 data FROM dl8k ", conn); //used for 8k records of 8

                DataTable table8 = new DataTable();// for 8 records of 8k
                DataTable table8k = new DataTable();// for 8k records of 8
                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //Stream s = new MemoryStream(); //can't have one stream, needs to be remade for each test iteration

                //configure loop parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 1;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 600;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 1;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    //LATENCY TEST for 8 records of 8k
                    {
                        start = DateTime.Now;

                        // Populate a new data table and bind it to a BindingSource.
                        //conn.Open();
                        dataAdapter8.Fill(table8);
                        //conn.Close();
                        //bindingSource1.DataSource = table; //not necessary to complete experiment

                        //set finish time to timeframe after db is loaded
                        finish = DateTime.Now;
                    }
                    //END LATENCY TEST

                    //find difference timeframes
                    elapse = finish.Subtract(start);

                    //need to serialize downloaded dataset
                    using (Stream s = new MemoryStream())//must be recreated for each test iteration, otherwise stream is appended to previous iteration
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        //**I kept track of when the table threw an outofmemory exception to see if certain code implementations were helping.**
                        formatter.Serialize(s, table8); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        // todo formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        size = (Int64)s.Length;
                        s.Dispose();
                        table8.Clear();
                        table8.Dispose();
                    }

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr = TestData.NewRow();
                    dr["startTime"] = start;
                    dr["endTime"] = finish;
                    dr["seconds"] = elapse.TotalSeconds;
                    dr["querySize"] = size;
                    dr["numRows"] = 8;
                    dr["serv"] = server;
                    dr["contype"] = contype;
                    dr["test"] = testType;
                    dr["updown"] = "download";
                    TestData.Rows.Add(dr);

                    // latency test for 8k records of 8
                    {
                        start = DateTime.Now;

                        // Populate a new data table and bind it to a BindingSource.
                        //conn.Open();
                        dataAdapter8k.Fill(table8k);
                        //conn.Close();
                        //bindingSource1.DataSource = table; //not necessary to complete experiment

                        //set finish time to timeframe after db is loaded
                        finish = DateTime.Now;
                    }
                    //find difference timeframes
                    elapse = finish.Subtract(start);


                    //need to serialize downloaded dataset
                    using (Stream s2 = new MemoryStream())//must be recreated for each test iteration, otherwise stream is appended to previous iteration
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        //**I kept track of when the table threw an outofmemory exception to see if certain code implementations were helping.**
                        formatter.Serialize(s2, table8k); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        // todo formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        size = (Int64)s2.Length;
                        s2.Dispose();
                        table8k.Clear();
                        table8k.Dispose();
                    }

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr2 = TestData.NewRow();
                    dr2["startTime"] = start;
                    dr2["endTime"] = finish;
                    dr2["seconds"] = elapse.TotalSeconds;
                    dr2["querySize"] = size;
                    dr2["numRows"] = 80;
                    dr2["serv"] = server;
                    dr2["contype"] = contype;
                    dr2["test"] = testType;
                    dr2["updown"] = "download";
                    TestData.Rows.Add(dr2);


                    //outdated way of uploaded parameters to DB. Example only in case current way doesn't work
                    //TestDataAdapter.InsertCommand.Parameters["@startTime"].Value = start;

                    //force garbage collection
                    //**tried number of ways to force garbage collection and I'm still receiving an error
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end loop



                /////////////////////////////////////////
                //End of Download Equal Size Dataset Test
                /////////////////////////////////////////
            }

            else if (upOrDown == "upload")
            {
                //////////////////////////////////
                //Upload Equal Size Dataset Test//
                //////////////////////////////////

                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter8 = new SqlDataAdapter("SELECT TOP 8 data FROM dl8 ", conn); //used for 8 records of 8k
                dataAdapter8.InsertCommand = new SqlCommand("INSERT INTO ul8 (data) VALUES (@data) ", conn);
                SqlDataAdapter dataAdapter8k = new SqlDataAdapter("SELECT TOP 80 data FROM dl8k ", conn); //used for 8k records of 8
                dataAdapter8k.InsertCommand = new SqlCommand("INSERT INTO ul8k(data) VALUES (@data) ", conn);

                DataTable table8 = new DataTable();// for 8 records of 8k
                table8.Columns.Add("data");
                DataTable table8k = new DataTable();// for 8k records of 8
                table8k.Columns.Add("data");
                string dataStr = "1";
                string dataStr8 = dataStr.PadRight(80, ' ');
                string dataStr8k = dataStr.PadRight(8, ' ');

                //set up Update command and parameters
                dataAdapter8.InsertCommand.Parameters.Add("@data", SqlDbType.Char, 80);
                dataAdapter8k.InsertCommand.Parameters.Add("@data", SqlDbType.Char, 8);
                dataAdapter8.InsertCommand.Parameters["@data"].SourceColumn = "data";
                dataAdapter8k.InsertCommand.Parameters["@data"].SourceColumn = "data";

                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //Stream s = new MemoryStream(); //can't have one stream, needs to be remade for each test iteration

                //configure loop parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 1;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 600;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 1;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    //create rows for upload 
                    for (int j = 1; j <= 8; j++)
                    {
                        DataRow dr = table8.NewRow();
                        dr["data"] = dataStr8;
                        table8.Rows.Add(dr);
                    }

                    //serialize current dataset
                    using (Stream s = new MemoryStream())
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        formatter.Serialize(s, table8); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300
                        size = (Int64)s.Length;
                        s.Dispose();
                    }

                    //start latency test
                    {
                        start = DateTime.Now;

                        //upload dataset to DB
                        //client.uploadTable(table);
                        dataAdapter8.Update(table8);
                        finish = DateTime.Now;


                    }//end latency test

                    elapse = finish.Subtract(start);

                    //dispose dataset
                    table8.Clear();

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr3 = TestData.NewRow();
                    dr3["startTime"] = start;
                    dr3["endTime"] = finish;
                    dr3["seconds"] = elapse.TotalSeconds;
                    dr3["querySize"] = size;
                    dr3["numRows"] = 8;
                    dr3["serv"] = server;
                    dr3["contype"] = contype;
                    dr3["test"] = testType;
                    dr3["updown"] = "upload";
                    TestData.Rows.Add(dr3);


                    //8 k upload
                    //create table for 8k upload
                    for (int j = 1; j <= 80; j++)
                    {
                        DataRow dr = table8k.NewRow();
                        dr["data"] = dataStr8k;
                        table8k.Rows.Add(dr);
                    }

                    //serialize current dataset
                    using (Stream s = new MemoryStream())
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        formatter.Serialize(s, table8k); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300
                        size = (Int64)s.Length;
                        s.Dispose();
                    }

                    //start latency test
                    {
                        start = DateTime.Now;

                        //upload dataset to DB
                        //client.uploadTable(table);
                        dataAdapter8k.Update(table8k);
                        finish = DateTime.Now;


                    }//end latency test

                    elapse = finish.Subtract(start);

                    //dispose dataset
                    table8k.Clear();

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr4 = TestData.NewRow();
                    dr4["startTime"] = start;
                    dr4["endTime"] = finish;
                    dr4["seconds"] = elapse.TotalSeconds;
                    dr4["querySize"] = size;
                    dr4["numRows"] = 80;
                    dr4["serv"] = server;
                    dr4["contype"] = contype;
                    dr4["test"] = testType;
                    dr4["updown"] = "upload";
                    TestData.Rows.Add(dr4);


                    //outdated way of uploaded parameters to DB. Example only in case current way doesn't work
                    //TestDataAdapter.InsertCommand.Parameters["@startTime"].Value = start;

                    //force garbage collection
                    //**tried number of ways to force garbage collection and I'm still receiving an error
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end of loop
                ///////////////////////////////////////
                //end of UPLOAD Equal Size Dataset TEST
                ///////////////////////////////////////
                
                //update archive database with new rows and clear for refresh
                //TestDataAdapter.Update(TestData);
                //TestData.Clear();

                //refresh TestData Archive by query server to check data uploaded properly
                //conn.Open();
                //TestDataAdapter.Fill(TestData);
                //conn.Close();
                //gvArchive.DataSource = TestData;
            }

            //update archive database with new rows and clear for refresh
            //TestDataAdapter.Update(TestData);

            //DEPRECATED - display last timestamps and latency in ms, out of loop, unnecessary for test
            //lblStart.Text = start.ToShortDateString() + " " + start.ToLongTimeString() + " " + start.Millisecond.ToString() + " ms";
            //lblFinish.Text = finish.ToShortDateString() + " " + finish.ToLongTimeString() + " " + finish.Millisecond.ToString() + " ms";
            //lblElapsed.Text = elapse.Minutes.ToString() + " min " + elapse.TotalSeconds.ToString() + " sec ";
            //lblSize.Text = size.ToString(); //not necessary to complete experiment

            //refresh TestData Archive by query server to check data uploaded properly
            //conn.Open();
            TestDataAdapter.Update(TestData);
            //conn.Close();
            gvArchive.DataSource = TestData;
            TestData.Clear();


        }

        public void ExecuteTPCTest(string upOrDown)
        {
            // declare variables used for keeping timestamps
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            TimeSpan elapse = new TimeSpan();

            //if test is download, perform Equal size dataset test download, if test is upload, perform equal size dataset test upload
            if (upOrDown == "download")
            {
                ////////////////////////////////////
                //Download TPC Test//
                ////////////////////////////////////

                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TOP 1000 tpcData FROM tpcDownload ", conn); //used for 8 records of 8k
                
                DataTable table = new DataTable();// for 8 records of 8k
                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //Stream s = new MemoryStream(); //can't have one stream, needs to be remade for each test iteration

                //configure loop parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 1;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 600;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 1;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    //LATENCY TEST for 8 records of 8k
                    {
                        start = DateTime.Now;

                        // Populate a new data table and bind it to a BindingSource.
                        //conn.Open();
                        dataAdapter.Fill(table);
                        //conn.Close();
                        //bindingSource1.DataSource = table; //not necessary to complete experiment

                        //set finish time to timeframe after db is loaded
                        finish = DateTime.Now;
                    }
                    //END LATENCY TEST

                    //find difference timeframes
                    elapse = finish.Subtract(start);

                    //need to serialize downloaded dataset
                    using (Stream s = new MemoryStream())//must be recreated for each test iteration, otherwise stream is appended to previous iteration
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        //**I kept track of when the table threw an outofmemory exception to see if certain code implementations were helping.**
                        formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        // todo formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        size = (Int64)s.Length;
                        s.Dispose();

                    }

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr = TestData.NewRow();
                    dr["startTime"] = start;
                    dr["endTime"] = finish;
                    dr["seconds"] = elapse.TotalSeconds;
                    dr["querySize"] = size;
                    dr["numRows"] = table.Rows.Count;
                    dr["serv"] = server;
                    dr["contype"] = contype;
                    dr["test"] = testType;
                    dr["updown"] = "download";
                    TestData.Rows.Add(dr);

                    table.Clear();
                    table.Dispose();

                    //force garbage collection
                    //**tried number of ways to force garbage collection and I'm still receiving an error
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end loop



                /////////////////////////////////////////
                //End of Download TPC Test
                /////////////////////////////////////////
            }

            else if (upOrDown == "upload")
            {
                //////////////////////////////////
                //Upload TPC Dataset Test//
                //////////////////////////////////

                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TOP 20 data FROM tpcUpload ", conn); //used for 8 records of 8k
                dataAdapter.InsertCommand = new SqlCommand("INSERT INTO tpcUpload (tpcData) VALUES (@tpcData) ", conn);
                
                DataTable table = new DataTable();// for 8 records of 8k
                table.Columns.Add("tpcData");
                string dataStr = "1";
                string dataTPCStr = dataStr.PadRight(153, ' ');

                //set up Update command and parameters
                dataAdapter.InsertCommand.Parameters.Add("@tpcData", SqlDbType.Char, 153);
                dataAdapter.InsertCommand.Parameters["@tpcData"].SourceColumn = "tpcData";

                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //Stream s = new MemoryStream(); //can't have one stream, needs to be remade for each test iteration

                //configure loop parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 1;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 600;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 1;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    //create rows for upload 
                    for (int j = 1; j <= 20; j++)
                    {
                        DataRow dr = table.NewRow();
                        dr["tpcData"] = dataTPCStr;
                        table.Rows.Add(dr);
                    }

                    //serialize current dataset
                    using (Stream s = new MemoryStream())
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300
                        size = (Int64)s.Length;
                        s.Dispose();
                    }

                    //start latency test
                    {
                        start = DateTime.Now;

                        //upload dataset to DB
                        //client.uploadTable(table);
                        dataAdapter.Update(table);
                        finish = DateTime.Now;


                    }//end latency test

                    elapse = finish.Subtract(start);

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr3 = TestData.NewRow();
                    dr3["startTime"] = start;
                    dr3["endTime"] = finish;
                    dr3["seconds"] = elapse.TotalSeconds;
                    dr3["querySize"] = size;
                    dr3["numRows"] = table.Rows.Count;
                    dr3["serv"] = server;
                    dr3["contype"] = contype;
                    dr3["test"] = testType;
                    dr3["updown"] = "upload";
                    TestData.Rows.Add(dr3);

                    //dispose dataset
                    table.Clear();

                    //force garbage collection
                    //**tried number of ways to force garbage collection and I'm still receiving an error
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end of loop
                ///////////////////////////////////////
                //end of UPLOAD TPC Dataset TEST
                ///////////////////////////////////////

                //update archive database with new rows and clear for refresh
                //TestDataAdapter.Update(TestData);
                //TestData.Clear();

                //refresh TestData Archive by query server to check data uploaded properly
                //conn.Open();
                //TestDataAdapter.Fill(TestData);
                //conn.Close();
                //gvArchive.DataSource = TestData;
            }

            //update archive database with new rows and clear for refresh
            //TestDataAdapter.Update(TestData);

            //DEPRECATED - display last timestamps and latency in ms, out of loop, unnecessary for test
            //lblStart.Text = start.ToShortDateString() + " " + start.ToLongTimeString() + " " + start.Millisecond.ToString() + " ms";
            //lblFinish.Text = finish.ToShortDateString() + " " + finish.ToLongTimeString() + " " + finish.Millisecond.ToString() + " ms";
            //lblElapsed.Text = elapse.Minutes.ToString() + " min " + elapse.TotalSeconds.ToString() + " sec ";
            //lblSize.Text = size.ToString(); //not necessary to complete experiment

            //refresh TestData Archive by query server to check data uploaded properly
            //conn.Open();
            TestDataAdapter.Update(TestData);
            //conn.Close();
            gvArchive.DataSource = TestData;
            TestData.Clear();

        }

        public void ExecuteCurveTest(string upOrDown)
        {
            // declare variables used for keeping timestamps
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            TimeSpan elapse = new TimeSpan();

            //if test is download, perform download curve test, if test is upload, perform upload curve test
            if (upOrDown == "download")
            {
                ///////////////////////////////
                //Download Curve Test//////////
                ///////////////////////////////

                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(); //initialize Select Command
                dataAdapter.SelectCommand.Connection = conn;  //set connection for command
                DataTable table = new DataTable();// taken from top of loop
                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //Stream s = new MemoryStream(); //can't have one stream, needs to be remade for each test iteration

                //configure test parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 100;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 1000;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 100;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    int rows = i;
                    if (chkMod.Checked == true) int.TryParse(txtMod.Text, out rows);

                    //change select query based on current loop iteration
                    dataAdapter.SelectCommand.CommandText = "SELECT TOP " + rows.ToString() + " id, data1, data2, data3, data4 FROM dlDB";

                    //LATENCY TEST
                    {
                        start = DateTime.Now;

                        // Populate a new data table and bind it to a BindingSource.
                        //conn.Open();
                        dataAdapter.Fill(table);
                        //conn.Close();
                        //bindingSource1.DataSource = table; //not necessary to complete experiment

                        //set finish time to timeframe after db is loaded
                        finish = DateTime.Now;
                    }
                    //END LATENCY TEST

                    //find difference timeframes
                    elapse = finish.Subtract(start);

                    //need to serialize downloaded dataset
                    using (Stream s = new MemoryStream())//must be recreated for each test iteration, otherwise stream is appended to previous iteration
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        //**I kept track of when the table threw an outofmemory exception to see if certain code implementations were helping.**
                        formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        // todo formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300, 14900, 15900
                        size = (Int64)s.Length;
                        s.Dispose();
                        table.Clear();
                        table.Dispose();
                    }

                    //create a row for the recorded test and place in TestData table to be uploaded
                    DataRow dr = TestData.NewRow();
                    dr["startTime"] = start;
                    dr["endTime"] = finish;
                    dr["seconds"] = elapse.TotalSeconds;
                    dr["querySize"] = size;
                    dr["numRows"] = rows;
                    dr["serv"] = server;
                    dr["contype"] = contype;
                    dr["test"] = testType;
                    dr["updown"] = "download";
                    TestData.Rows.Add(dr);

                    //outdated way of uploaded parameters to DB. Example only in case current way doesn't work
                    //TestDataAdapter.InsertCommand.Parameters["@startTime"].Value = start;

                    //force garbage collection
                    //**tried number of ways to force garbage collection and I'm still receiving an error
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end loop

                /////////////////////////////
                //End of Download Curve Test
                /////////////////////////////
            }

            else if (upOrDown == "upload")
            {
                ///////////////////////////
                //Upload Curve Test////////
                ///////////////////////////


                // Create a new data adapter based on the specified query, loop iteration, and command as well as tools for serialization
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select data1, data2, data3, data4 FROM uploadDB", conn);
                dataAdapter.InsertCommand = new SqlCommand("INSERT INTO uploadDB (data1, data2, data3, data4) VALUES (@data1, @data2, @data3, @data4)", conn); //initialize Update Command
                dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM uploadDB; DBCC CHECKIDENT('uploadDB', RESEED, 0)", conn);
                DataTable table = new DataTable();// taken from top of loop
                //dataAdapter.Fill(table);
                table.Columns.Add("data1");
                table.Columns.Add("data2");
                table.Columns.Add("data3");
                table.Columns.Add("data4");
                string dataStr = "1";
                //dataStr = dataStr.PadRight(1999, ' ');
                dataStr = dataStr.PadRight(2000, ' ');

                BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization 
                Int64 size = 0; //taken from serialization

                //set up Update command and parameters
                dataAdapter.InsertCommand.CommandText = "INSERT INTO uploadDB (data1, data2, data3, data4) VALUES (@data1, @data2, @data3, @data4)";
                dataAdapter.InsertCommand.Parameters.Add("@data1", SqlDbType.Char, 2000);
                dataAdapter.InsertCommand.Parameters.Add("@data2", SqlDbType.Char, 2000);
                dataAdapter.InsertCommand.Parameters.Add("@data3", SqlDbType.Char, 2000);
                dataAdapter.InsertCommand.Parameters.Add("@data4", SqlDbType.Char, 2000);
                dataAdapter.InsertCommand.Parameters["@data1"].SourceColumn = "data1";
                dataAdapter.InsertCommand.Parameters["@data2"].SourceColumn = "data2";
                dataAdapter.InsertCommand.Parameters["@data3"].SourceColumn = "data3";
                dataAdapter.InsertCommand.Parameters["@data4"].SourceColumn = "data4";

                //configure test parameters
                int rowStart;
                int rowEnd;
                int rowStep;

                if (txtStart.Text == "" || txtStart.Text == null) rowStart = 100;
                else int.TryParse(txtStart.Text, out rowStart);

                if (txtEnd.Text == "" || txtEnd.Text == null) rowEnd = 1000;
                else int.TryParse(txtEnd.Text, out rowEnd);

                if (txtStep.Text == "" || txtStep.Text == null) rowStep = 100;
                else int.TryParse(txtStep.Text, out rowStep);

                //temp for loop, need to convert to a more manual system in order to not run out of memory
                for (int i = rowStart; i <= rowEnd; i += rowStep) //possibly reduce total # of rows to help memory 100000 breaks
                {
                    table.Clear();
                    int rows = i;
                    if (chkMod.Checked == true) int.TryParse(txtMod.Text, out rows);

                    //create dataset using a for loop to create each row based on current iteration
                    for (int j = 0; j < rows; j++)
                    {
                        DataRow dr = table.NewRow();
                        dr["data1"] = dataStr;
                        dr["data2"] = dataStr;
                        dr["data3"] = dataStr;
                        dr["data4"] = dataStr;
                        table.Rows.Add(dr);
                    }

                    //serialize current dataset
                    using (Stream s = new MemoryStream())
                    {
                        //BinaryFormatter formatter = new BinaryFormatter(); //moved to beginning of click
                        formatter.Serialize(s, table); //table too large at rows 11900, 9800, 12400, 12000, 13200, 11900, 14200, 13400, 13500, 16500, 16400, 14800, 15500, 15300
                        size = (Int64)s.Length;
                        s.Dispose();
                    }

                    //start latency test
                    {
                        start = DateTime.Now;

                        //upload dataset to DB
                        //client.uploadTable(table);
                        dataAdapter.Update(table);
                        finish = DateTime.Now;


                    }//end latency test

                    elapse = finish.Subtract(start);

                    //dispose dataset
                    table.Clear();

                    //create data row to record data from test
                    DataRow testDR = TestData.NewRow();
                    testDR["startTime"] = start;
                    testDR["endTime"] = finish;
                    testDR["seconds"] = elapse.TotalSeconds;
                    testDR["querySize"] = size;
                    testDR["numRows"] = rows;
                    testDR["serv"] = server;
                    testDR["contype"] = contype;
                    testDR["test"] = testType;
                    testDR["updown"] = "upload";
                    TestData.Rows.Add(testDR);


                    //force garbage collection
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                    GC.WaitForFullGCComplete(-1);

                }//end of loop
                //////////////////////////
                //end of UPLOAD CURVE TEST
                //////////////////////////
            }

            //update archive database with new rows and clear for refresh
            TestDataAdapter.Update(TestData);
            TestData.Clear();

            //DEPRECATED - display last timestamps and latency in ms, out of loop, unnecessary for test
            //lblStart.Text = start.ToShortDateString() + " " + start.ToLongTimeString() + " " + start.Millisecond.ToString() + " ms";
            //lblFinish.Text = finish.ToShortDateString() + " " + finish.ToLongTimeString() + " " + finish.Millisecond.ToString() + " ms";
            //lblElapsed.Text = elapse.Minutes.ToString() + " min " + elapse.TotalSeconds.ToString() + " sec ";
            //lblSize.Text = size.ToString(); //not necessary to complete experiment

            //refresh TestData Archive by query server to check data uploaded properly
            //conn.Open();
            //TestDataAdapter.Fill(TestData);
            //conn.Close();
            gvArchive.DataSource = TestData;

        }

        private void btnGenData_Click(object sender, EventArgs e)
        {
            GetConnection();

            SqlDataAdapter da = new SqlDataAdapter("INSERT INTO dlDB (data1, data2, data3, data4) VALUES ('1','1','1','1')", conn);
            lblGenerate.Text = " ";
            lblGenerate.Text = "Generating...";
            conn.Open();
            for (int i = 0; i < Convert.ToInt32(txtGenerate.Text); i++)
            {
                da.SelectCommand.ExecuteNonQuery();

            }
            conn.Close();
            lblGenerate.Text += " Done!";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //get current connection to server from user
            GetConnection();

            //delete records and reset identity for ID column
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dlDB", conn);
            da.DeleteCommand = new SqlCommand("DELETE FROM dlDB; DBCC CHECKIDENT('dlDB', RESEED, 0)");
            conn.Open();
            lblGenerate.Text = " ";
            lblGenerate.Text = "Deleting...";
            da.DeleteCommand.Connection = conn;
            da.DeleteCommand.ExecuteNonQuery();
            lblGenerate.Text += " Done";
            conn.Close();
        }

        private void btnLoadArchive_Click(object sender, EventArgs e)
        {
            //get connection to server from user input
            GetConnection();

            //refresh TestData table with current archive
            TestData.Clear();
            //conn.Open();
            TestDataAdapter.Fill(TestData);
            gvArchive.DataSource = TestData;
            //conn.Close();
        }

        private void btnClearArhive_Click(object sender, EventArgs e)
        {
            //get connection server info from user input
            GetConnection();

            //clear testdata archive DB and clear Testdata table
            Azureconn.Open();
            TestDataAdapter.DeleteCommand.ExecuteNonQuery();
            Azureconn.Close();
            lblGenerate.Text = "Archive Cleared";
            TestData.Clear();
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            GetConnection();
            string connName = conn.DataSource.ToString();

            //test connection
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection to " + connName + " SUCCEEDED", "Connection Successful");
            }
            catch (Exception err)
            {
                MessageBox.Show("Connection to " + connName + " FAILED\n\n" + err.Message, "Connection Error");
            }

        }

        private void btnOverheadForm_Click(object sender, EventArgs e)
        {
            Overhead1 frm = new Overhead1();
            frm.Show();
        }
    }
}
