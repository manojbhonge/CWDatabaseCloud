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

        public List<string> GetToolTypes()
        {
            List<string> outputList = null;
            
            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                //Get tools type records from  MchToolTypeDesc
                string queryString = "select * from  MchToolTypeDesc";

                cmd = new OleDbCommand(queryString,conn);               
                reader = cmd.ExecuteReader();

                outputList = new List<string>();

                while (reader.Read())
                {   
                    outputList.Add(reader.GetValue(1).ToString());
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
                    
                    break;
                case "Bore":
                    break;
                case "Center Drill":
                    break;
                case "Corner Round":
                    query = "select * from  MILLC where [Mill Tool Type] = 4";
                    break;
                case "Countersink":
                    break;
                case "Dovetail":
                    break;
                case "Drill":
                    break;
                case "Face Mill":
                    break;
                case "Flat End Mill":
                    query = "select * from  MILLC where [Mill Tool Type] = 1";
                    break;
                case "Flat End Taper":
                    break;
                case "Hog Nose End Mill":
                    query = "select * from  MILLC where [Mill Tool Type] = 3";
                    break;
                case "Hog Nose Taper":
                    break;
                //case "Insert-Holder":
                //    break;
                case "Keyway":
                    break;
                case "Lollipop":
                    break;
                case "Multi-point Thread Mill":
                    break;
                case "Ream":
                    break;
                case "Single-point Thread Mill":
                    break;
                case "Tap - Cutting":
                    break;
                case "Tap - Rolling":
                    break;
                case "User-Defined":
                    break;
                default:
                    break;
            }

            return query;
        }

        public List<string> GetTools(string ToolType)
        {
            List<string> outputList = null;

            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();

                string queryString = GetCorropsondingQuery(ToolType);            

                cmd = new OleDbCommand(queryString, conn);
                reader = cmd.ExecuteReader();

                outputList = new List<string>();

                while (reader.Read())
                {
                    outputList.Add(reader.GetValue(2).ToString());
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
