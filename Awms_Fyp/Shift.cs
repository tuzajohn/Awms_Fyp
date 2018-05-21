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
        Random random;
        public List<string> MyList;
        private string Paths;
        public Shift() { }
        public Shift(string filePath)
        {
            Paths = filePath;
        }
        public Shift(string filePath, string id)
        {
            Paths = filePath;
            var table = ConvertToDataTable("shift");
            var dictionary = ReadFromtTable(table);
            var nDictionary = SetShift(dictionary, id);
            table = CreateShiftTable(nDictionary);
            WriteToFile(table, filePath);
        }
        public string[] DaysOfWeek = { "MON", "TUE", "WEN", "THU", "FRI", "SAT", "SUN" };
        public DataTable CreateShiftTable(Dictionary<int, List<List<string>>> dictionary)
        {
            RegExpression er = new RegExpression();
            var (check, result) = er.IsPassword("kfsdfs");

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
                        var count = periodList.Count;
                        for (int i = 0; i < periodList.Count && !string.IsNullOrEmpty(periodList[i]); i++)
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
        public DataTable ConvertToDataTable(string title)
        {
            DataTable table = new DataTable(title);
            var lines = File.ReadAllLines(Paths).ToList();
            var columnNames = lines[0].Split('|');
            for (int col = 0; col < columnNames.Length; col++)
            {
                table.Columns.Add(columnNames[col]);
            }
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = table.Columns[columnNames[0]];
            table.PrimaryKey = keyColumns;
            int counter = 0;
            foreach (string line in lines)
            {
                counter++;
                if (counter - 1 == 0) { continue; }
                DataRow row = table.NewRow();
                //if (line.Contains(':'))
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
            for (int i = 0; i < table.Rows.Count; i++)
            {
                List<List<string>> lDictionary = new List<List<string>>();
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    List<string> tempList = new List<string>();
                    var cellValue = table.Rows[i][table.Columns[j]].ToString();
                    if (cellValue.Contains(':'))
                    {
                        var idArray = cellValue.Split(':');
                        for (int m = 0; m < idArray.Length; m++)
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
                    for (int i = 0; i < cellValues.Length - 1; i++)
                    {
                        var c = cellValues[i];
                        shiftFile.Write(cellValues[i] + "|");
                    }
                    shiftFile.Write(cellValues[cellValues.Length - 1] + "\n");
                }
                //shiftFile.Write($"Shift table as per {DateTime.Now.ToLongDateString()} @ {DateTime.Now.ToLongTimeString()}");
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
            var docType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, docId);

            var cus = from s in shiftDictionary where s.Value[0][0] == "MON" select s.Key;
            var n = cus.ToString();
            foreach (var day in shiftDictionary)
            {//int max = day.Value.Max(a => a.Count);
                //var newList = period.Intersect(DaysOfWeek).ToList();
                var matchingIdValues = day.Value.FirstOrDefault(stringToCheck => stringToCheck.Contains(docId));
                if (matchingIdValues == null)
                {
                    random = new Random();
                    int tempRandValue = random.Next(1, 6), pos = 0;
                    int max = day.Value.Max(a => a.Count);
                    foreach (var period in day.Value)
                    {
                        pos++;
                        var checkList = period.Intersect(DaysOfWeek).ToList();
                        if (checkList.Count == 0) { continue; }
                        if (pos == tempRandValue)
                        {
                            for (int i = 0; i < period.Count; i++)
                            {
                                var docTempType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, period[i]);
                                if (docTempType.Speciality != docType.Speciality)
                                {
                                    period.Add(docId);
                                }
                                //break;
                            }
                        }
                    }
                }
            }
            return shiftDictionary;
        }
        public void ManagingShift()
        {

        }

    }
}