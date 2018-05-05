using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Project_Dll;
using Customs;

namespace Awms_Fyp
{
    public class Shift
    {
        public List<string> MyList;
        public Shift()
        {

        }
        public Shift(string filePath)
        {
            var table = ConvertToDataTable(filePath, "shift");
            var dictionary = ReadFromtTable(table);
            table = CreateShiftTable(dictionary);
            WriteToFile(table, filePath);
        }
        string[] DaysOfWeek = { "MON", "TUE", "WEN", "THU", "FRI", "SAT", "SUN" };
        private DataTable CreateShiftTable(Dictionary<int, List<List<string>>> dictionary)
        {
            DataTable table = new DataTable("shift");
            table.Columns.Add("Day");
            table.Columns.Add("PERIOD1");//0-4
            table.Columns.Add("PERIOD2");//4-8
            table.Columns.Add("PERIOD3");//8-12
            table.Columns.Add("PERIOD4");//12-16
            table.Columns.Add("PERIOD5");//16-20
            table.Columns.Add("PERIOD6");//20-24
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = table.Columns["Day"];
            table.PrimaryKey = keyColumns;
            int cellCounter = 0;
            foreach (var cellList in dictionary)
            {
                DataRow row = table.NewRow();
                foreach (var periodList in cellList.Value)
                {
                    if (cellCounter % 7 != 0)
                    {
                        for (int i = 0; i < periodList.Count; i++)
                        {
                            row[cellCounter] += periodList[i] + ":";
                        }
                    }
                    else { row[cellCounter] = DaysOfWeek[cellList.Key]; }
                    cellCounter++;
                }
                cellCounter = 0;
                table.Rows.Add(row);
            }
            return table;
        }
        public DataTable ConvertToDataTable(string filepath, string title)
        {
            DataTable table = new DataTable(title);
            var lines = File.ReadAllLines(filepath).ToList();
            var columnNames = lines[0].Split('|');
            for (int col = 0; col < columnNames.Length; col++)
            {
                table.Columns.Add(columnNames[col]);
            }
            int counter = 0;
            foreach (string line in lines)
            {
                counter++;
                if (counter-1 == 0) { continue; }
                DataRow row = table.NewRow();
                if (line.Contains(':'))
                {
                    var cols = line.Split('|');
                    for (int i = 0; i < cols.Length; i++)
                    {
                        row[i] = cols[i];
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
        public Dictionary<int, List<List<string>>> ReadFromtTable(DataTable table)
        {
            Dictionary<int, List<List<string>>> dictionary = new Dictionary<int, List<List<string>>>();
            for (int i = 0; i < table.Rows.Count-1; i++)
            {
                List<List<string>> lDictionary = new List<List<string>>();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    List<string> tempList = new List<string>();
                    var cellValue = table.Rows[i][table.Columns[j]].ToString();                    
                    if (cellValue.Contains(':'))
                    {
                        var idArray = cellValue.Split(':');
                        for (int m = 0; m < idArray.Length - 1; m++)
                        {
                            tempList.Add(idArray[m]);
                        }
                    }
                    else { tempList.Add(cellValue); }
                    lDictionary.Add(tempList);
                }
                dictionary.Add(i, lDictionary);
            }
            return dictionary;
        }
        private DataTable Transpose(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            foreach (DataRow row in dt.Rows)
            {
                dtNew.Columns.Add(new DataColumn(row[0].ToString()));
            }
            //Adding Row Data
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                DataRow r = dtNew.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    r[j] = dt.Rows[j][k];
                dtNew.Rows.Add(r);
            }

            return dtNew;
        }
        public void WriteToFile(DataTable table, string path)
        {
            //try
            {
                StreamWriter shiftFile = new StreamWriter(path);
                int h = 0;
                foreach (DataColumn col in table.Columns)
                {
                    h++;
                    if (h == table.Columns.Count) { break; }
                    shiftFile.Write(col + "|");
                }
                shiftFile.Write(table.Columns[table.Columns.Count - 1] + "\n");
                foreach (DataRow row in table.Rows)
                {
                    object[] cellValues = row.ItemArray;
                    for (int i = 0; i < cellValues.Length-1; i++)
                    {
                        var c = cellValues[i];
                        shiftFile.Write(cellValues[i] + "|");
                    }
                    shiftFile.Write(cellValues[cellValues.Length - 1] + "\n");
                }
                shiftFile.Write($"Shift table as per {DateTime.Now.ToLongDateString()} @ {DateTime.Now.ToLongTimeString()}");
                shiftFile.Flush();
                shiftFile.Close();
            }
            //catch (Exception) { }
        }
        public List<string> Shuffle(List<string> idList)
        {

            return null;
        }
        public Dictionary<int, List<List<string>>> SetShift(Dictionary<int, List<List<string>>> shiftDictionary, string docId)
        {
            int objCounter = 0;
            var docType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, docId);
            foreach (var shift in shiftDictionary)
            {
                foreach (var period in shift.Value)
                {
                    if (!period.Contains(docId))
                    {
                        foreach (var id in period)
                        {
                            var tempType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, id);

                        }
                    }
                }
            }


            return shiftDictionary;
        }
    }
}