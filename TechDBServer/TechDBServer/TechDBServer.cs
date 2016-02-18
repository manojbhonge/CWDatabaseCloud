using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.OleDb; // <- for database methods

namespace TechDBServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TechDBServer : ITechDBServer
    {
        string connectionString;
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataReader reader;


        public TechDBServer()
        {
           // initiate DB connection
             connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=techdb.mdb";
        }

        public List<ToolData> GetToolTypes()
        {
            List<ToolData> outputList = null;
            
            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                //Get tools type records from  MchToolTypeDesc
                string queryString = "select * from  MchToolTypeDesc";

                cmd = new OleDbCommand(queryString,conn);               
                reader = cmd.ExecuteReader();

                outputList = new List<ToolData>();

                while (reader.Read())
                {
                    ToolData toolData = new ToolData();
                    toolData.ToolName = reader.GetValue(1).ToString();
                    outputList.Add(toolData);
                }

                reader.Close();
                cmd.Dispose();
                conn.Close();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error");
                return null;
            }


            return outputList;
        }

        string GetCorropsondingQuery(string ToolType)
        {
            string query = "";

            switch (ToolType)
            {
                case "Ball End Mill" :
                    query = "select * from  MILLC where [Mill Tool Type] = 2";
                    break;
                case "Ball End Taper":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Bore":
                    query = "select * from  BORES";
                    break;
                case "Center Drill":
                    query = "select * from  CenterDrill";
                    break;
                case "Corner Round":
                    query = "select * from  MILLC where [Mill Tool Type] = 4";
                    break;
                case "Countersink":
                    query = "select * from  CounterSink";
                    break;
                case "Dovetail":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Drill":
                    query = "select * from  DRILLS";
                    break;
                case "Face Mill":
                    query = "select * from  FaceMillTool";
                    break;
                case "Flat End Mill":
                    query = "select * from  MILLC where [Mill Tool Type] = 1";
                    break;
                case "Flat End Taper":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Hog Nose End Mill":
                    query = "select * from  MILLC where [Mill Tool Type] = 3";
                    break;
                case "Hog Nose Taper":
                    //default
                    query = "select * from  BORES";
                    break;
                //case "Insert-Holder":
                //    break;
                case "Keyway":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Lollipop":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Multi-point Thread Mill":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Ream":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Single-point Thread Mill":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Tap - Cutting":
                    //default
                    query = "select * from  BORES";
                    break;
                case "Tap - Rolling":
                    //default
                    query = "select * from  BORES";
                    break;
                case "User-Defined":
                    //default
                    query = "select * from  BORES";
                    break;
                default:
                    break;
            }

            return query;
        }

        public List<ToolData> GetTools(string ToolType)
        {
            List<ToolData> outputList = null;

            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                string queryString = GetCorropsondingQuery(ToolType);            

                cmd = new OleDbCommand(queryString, conn);
                reader = cmd.ExecuteReader();

                outputList = new List<ToolData>();

                while (reader.Read())
                {
                    ToolData toolData = new ToolData();
                    toolData.ToolName = reader.GetValue(2).ToString();
                    outputList.Add(toolData);
                }

                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error");
                return null;
            }


            return outputList;
        }
    }
}
