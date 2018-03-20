using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Dll
{
    #region Database Model
    public class Functions : DLW_Library.MySQL { public Functions() { SetConnection("localhost", "fyp_db", "root", ""); } }
    public class Appointment : Appointment_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string patient_id = "";
        public string Patient_id
        {
            get { return patient_id; }
            set { updateField("patient_id", value, id); patient_id = value; }
        }
        string doctor_id = "";
        public string Doctor_id
        {
            get { return doctor_id; }
            set { updateField("doctor_id", value, id); doctor_id = value; }
        }
        string schedule_date = "";
        public string Schedule_date
        {
            get { return schedule_date; }
            set { updateField("schedule_date", value, id); schedule_date = value; }
        }
        string descritpion = "";
        public string Descritpion
        {
            get { return descritpion; }
            set { updateField("descritpion", value, id); descritpion = value; }
        }
        string status = "";
        public string Status
        {
            get { return status; }
            set { updateField("status", value, id); status = value; }
        }
        string set_time = "";
        public string Set_time
        {
            get { return set_time; }
            set { updateField("set_time", value, id); set_time = value; }
        }
        public Appointment() { }
        public Appointment(string id) { loadData(id); }
        private Appointment loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `appointment` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.patient_id = row["patient_id"].ToString();
                this.doctor_id = row["doctor_id"].ToString();
                this.schedule_date = row["schedule_date"].ToString();
                this.descritpion = row["descritpion"].ToString();
                this.status = row["status"].ToString();
                this.set_time = row["set_time"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.patient_id = "";
            this.doctor_id = "";
            this.schedule_date = "";
            this.descritpion = "";
            this.status = "";
            this.set_time = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.patient_id = row["patient_id"].ToString();
                this.doctor_id = row["doctor_id"].ToString();
                this.schedule_date = row["schedule_date"].ToString();
                this.descritpion = row["descritpion"].ToString();
                this.status = row["status"].ToString();
                this.set_time = row["set_time"].ToString();
            }
        }

        public Appointment Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Appointment Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Appointment updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `appointment` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Appointment updateRow(string id, string patient_id, string doctor_id, string schedule_date, string descritpion, string status, string set_time)
        {
            string[] pars = { "id", "patient_id", "doctor_id", "schedule_date", "descritpion", "status", "set_time" };
            string[] values = { id, patient_id, doctor_id, schedule_date, descritpion, status, set_time };
            db.MysqlPlain("UPDATE `appointment` SET `id` = @id, `patient_id` = @patient_id, `doctor_id` = @doctor_id, `schedule_date` = @schedule_date, `descritpion` = @descritpion, `status` = @status, `set_time` = @set_time WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Appointment insert(string patient_id, string doctor_id, string schedule_date, string descritpion, string status, string set_time)
        {
            string[] pars = { "patient_id", "doctor_id", "schedule_date", "descritpion", "status", "set_time" };
            string[] values = { patient_id, doctor_id, schedule_date, descritpion, status, set_time };
            db.MysqlPlain("INSERT INTO `appointment`(`patient_id`, `doctor_id`, `schedule_date`, `descritpion`, `status`, `set_time`) VALUES(@patient_id, @doctor_id, @schedule_date, @descritpion, @status, @set_time)", pars, values);
            loadData(db.getMaxID("appointment"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `appointment` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `appointment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `appointment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Appointment> getAllRecords()
        {
            string query = "SELECT * FROM `appointment`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Appointment> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `appointment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Appointment> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `appointment`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Appointment> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `appointment`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Appointment> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `appointment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Appointment> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `appointment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Appointment_support
    {
        public List<Appointment> createObjects(System.Data.DataTable table)
        {
            List<Appointment> objects = new List<Appointment>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Appointment instance = new Appointment();
                instance.Id = row["id"].ToString();
                instance.Patient_id = row["patient_id"].ToString();
                instance.Doctor_id = row["doctor_id"].ToString();
                instance.Schedule_date = row["schedule_date"].ToString();
                instance.Descritpion = row["descritpion"].ToString();
                instance.Status = row["status"].ToString();
                instance.Set_time = row["set_time"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Patient_id, Doctor_id, Schedule_date, Descritpion, Status, Set_time }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Patient_id) { return "patient_id"; }
            if (column == Column.Doctor_id) { return "doctor_id"; }
            if (column == Column.Schedule_date) { return "schedule_date"; }
            if (column == Column.Descritpion) { return "descritpion"; }
            if (column == Column.Status) { return "status"; }
            if (column == Column.Set_time) { return "set_time"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Appointment> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("patient_id"); table.Columns.Add("doctor_id"); table.Columns.Add("schedule_date"); table.Columns.Add("descritpion"); table.Columns.Add("status"); table.Columns.Add("set_time"); foreach (Appointment instance in objects) { table.Rows.Add(instance.Id, instance.Patient_id, instance.Doctor_id, instance.Schedule_date, instance.Descritpion, instance.Status, instance.Set_time); }
            return table;
        }

    }
    public class Denied_app_table : Denied_app_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string appointment_id = "";
        public string Appointment_id
        {
            get { return appointment_id; }
            set { updateField("appointment_id", value, id); appointment_id = value; }
        }
        string subject = "";
        public string Subject
        {
            get { return subject; }
            set { updateField("subject", value, id); subject = value; }
        }
        string reason = "";
        public string Reason
        {
            get { return reason; }
            set { updateField("reason", value, id); reason = value; }
        }
        public Denied_app_table() { }
        public Denied_app_table(string id) { loadData(id); }
        private Denied_app_table loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `denied_app_table` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.appointment_id = row["appointment_id"].ToString();
                this.subject = row["subject"].ToString();
                this.reason = row["reason"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.appointment_id = "";
            this.subject = "";
            this.reason = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.appointment_id = row["appointment_id"].ToString();
                this.subject = row["subject"].ToString();
                this.reason = row["reason"].ToString();
            }
        }

        public Denied_app_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Denied_app_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Denied_app_table updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `denied_app_table` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Denied_app_table updateRow(string id, string appointment_id, string subject, string reason)
        {
            string[] pars = { "id", "appointment_id", "subject", "reason" };
            string[] values = { id, appointment_id, subject, reason };
            db.MysqlPlain("UPDATE `denied_app_table` SET `id` = @id, `appointment_id` = @appointment_id, `subject` = @subject, `reason` = @reason WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Denied_app_table insert(string appointment_id, string subject, string reason)
        {
            string[] pars = { "appointment_id", "subject", "reason" };
            string[] values = { appointment_id, subject, reason };
            db.MysqlPlain("INSERT INTO `denied_app_table`(`appointment_id`, `subject`, `reason`) VALUES(@appointment_id, @subject, @reason)", pars, values);
            loadData(db.getMaxID("denied_app_table"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `denied_app_table` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `denied_app_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Denied_app_table> getAllRecords()
        {
            string query = "SELECT * FROM `denied_app_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Denied_app_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `denied_app_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Denied_app_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `denied_app_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Denied_app_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `denied_app_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Denied_app_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `denied_app_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Denied_app_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `denied_app_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Denied_app_table_support
    {
        public List<Denied_app_table> createObjects(System.Data.DataTable table)
        {
            List<Denied_app_table> objects = new List<Denied_app_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Denied_app_table instance = new Denied_app_table();
                instance.Id = row["id"].ToString();
                instance.Appointment_id = row["appointment_id"].ToString();
                instance.Subject = row["subject"].ToString();
                instance.Reason = row["reason"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Appointment_id, Subject, Reason }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Appointment_id) { return "appointment_id"; }
            if (column == Column.Subject) { return "subject"; }
            if (column == Column.Reason) { return "reason"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Denied_app_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("appointment_id"); table.Columns.Add("subject"); table.Columns.Add("reason"); foreach (Denied_app_table instance in objects) { table.Rows.Add(instance.Id, instance.Appointment_id, instance.Subject, instance.Reason); }
            return table;
        }

    }
    public class Doctor_shift_table : Doctor_shift_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string doctor_id = "";
        public string Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }
        string shift_it = "";
        public string Shift_it
        {
            get { return shift_it; }
            set { shift_it = value; }
        }
        public Doctor_shift_table() { }
        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.doctor_id = "";
            this.shift_it = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.doctor_id = row["doctor_id"].ToString();
                this.shift_it = row["shift_it"].ToString();
            }
        }

        public Doctor_shift_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Doctor_shift_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Doctor_shift_table insert(string id, string doctor_id, string shift_it)
        {
            string[] pars = { "id", "doctor_id", "shift_it" };
            string[] values = { id, doctor_id, shift_it };
            db.MysqlPlain("INSERT INTO `doctor_shift_table`(`id`, `doctor_id`, `shift_it`) VALUES(@id, @doctor_id, @shift_it)", pars, values);
            return this;
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `doctor_shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Doctor_shift_table> getAllRecords()
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Doctor_shift_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Doctor_shift_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Doctor_shift_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Doctor_shift_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Doctor_shift_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `doctor_shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Doctor_shift_table_support
    {
        public List<Doctor_shift_table> createObjects(System.Data.DataTable table)
        {
            List<Doctor_shift_table> objects = new List<Doctor_shift_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Doctor_shift_table instance = new Doctor_shift_table();
                instance.Id = row["id"].ToString();
                instance.Doctor_id = row["doctor_id"].ToString();
                instance.Shift_it = row["shift_it"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Doctor_id, Shift_it }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Doctor_id) { return "doctor_id"; }
            if (column == Column.Shift_it) { return "shift_it"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Doctor_shift_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("doctor_id"); table.Columns.Add("shift_it"); foreach (Doctor_shift_table instance in objects) { table.Rows.Add(instance.Id, instance.Doctor_id, instance.Shift_it); }
            return table;
        }

    }
    public class Login_table : Login_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string username = "";
        public string Username
        {
            get { return username; }
            set { updateField("username", value, id); username = value; }
        }
        string password = "";
        public string Password
        {
            get { return password; }
            set { updateField("password", value, id); password = value; }
        }
        string creation_time = "";
        public string Creation_time
        {
            get { return creation_time; }
            set { updateField("creation_time", value, id); creation_time = value; }
        }
        string attempts = "";
        public string Attempts
        {
            get { return attempts; }
            set { updateField("attempts", value, id); attempts = value; }
        }
        public Login_table() { }
        public Login_table(string id) { loadData(id); }
        private Login_table loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `login_table` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
                this.creation_time = row["creation_time"].ToString();
                this.attempts = row["attempts"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.username = "";
            this.password = "";
            this.creation_time = "";
            this.attempts = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
                this.creation_time = row["creation_time"].ToString();
                this.attempts = row["attempts"].ToString();
            }
        }

        public Login_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login_table updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `login_table` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Login_table updateRow(string id, string username, string password, string creation_time, string attempts)
        {
            string[] pars = { "id", "username", "password", "creation_time", "attempts" };
            string[] values = { id, username, password, creation_time, attempts };
            db.MysqlPlain("UPDATE `login_table` SET `id` = @id, `username` = @username, `password` = @password, `creation_time` = @creation_time, `attempts` = @attempts WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Login_table insert(string username, string password, string creation_time, string attempts)
        {
            string[] pars = { "username", "password", "creation_time", "attempts" };
            string[] values = { username, password, creation_time, attempts };
            db.MysqlPlain("INSERT INTO `login_table`(`username`, `password`, `creation_time`, `attempts`) VALUES(@username, @password, @creation_time, @attempts)", pars, values);
            loadData(db.getMaxID("login_table"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `login_table` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> getAllRecords()
        {
            string query = "SELECT * FROM `login_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `login_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Login_table_support
    {
        public List<Login_table> createObjects(System.Data.DataTable table)
        {
            List<Login_table> objects = new List<Login_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Login_table instance = new Login_table();
                instance.Id = row["id"].ToString();
                instance.Username = row["username"].ToString();
                instance.Password = row["password"].ToString();
                instance.Creation_time = row["creation_time"].ToString();
                instance.Attempts = row["attempts"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Username, Password, Creation_time, Attempts }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Username) { return "username"; }
            if (column == Column.Password) { return "password"; }
            if (column == Column.Creation_time) { return "creation_time"; }
            if (column == Column.Attempts) { return "attempts"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Login_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("username"); table.Columns.Add("password"); table.Columns.Add("creation_time"); table.Columns.Add("attempts"); foreach (Login_table instance in objects) { table.Rows.Add(instance.Id, instance.Username, instance.Password, instance.Creation_time, instance.Attempts); }
            return table;
        }

    }
    public class Profile_image_table : Profile_image_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string user_id = "";
        public string User_id
        {
            get { return user_id; }
            set { updateField("user_id", value, id); user_id = value; }
        }
        string url = "";
        public string Url
        {
            get { return url; }
            set { updateField("url", value, id); url = value; }
        }
        string time = "";
        public string Time
        {
            get { return time; }
            set { updateField("time", value, id); time = value; }
        }
        public Profile_image_table() { }
        public Profile_image_table(string id) { loadData(id); }
        private Profile_image_table loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `profile_image_table` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.user_id = row["user_id"].ToString();
                this.url = row["url"].ToString();
                this.time = row["time"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.user_id = "";
            this.url = "";
            this.time = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.user_id = row["user_id"].ToString();
                this.url = row["url"].ToString();
                this.time = row["time"].ToString();
            }
        }

        public Profile_image_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Profile_image_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Profile_image_table updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `profile_image_table` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Profile_image_table updateRow(string id, string user_id, string url, string time)
        {
            string[] pars = { "id", "user_id", "url", "time" };
            string[] values = { id, user_id, url, time };
            db.MysqlPlain("UPDATE `profile_image_table` SET `id` = @id, `user_id` = @user_id, `url` = @url, `time` = @time WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Profile_image_table insert(string user_id, string url, string time)
        {
            string[] pars = { "user_id", "url", "time" };
            string[] values = { user_id, url, time };
            db.MysqlPlain("INSERT INTO `profile_image_table`(`user_id`, `url`, `time`) VALUES(@user_id, @url, @time)", pars, values);
            loadData(db.getMaxID("profile_image_table"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `profile_image_table` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `profile_image_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Profile_image_table> getAllRecords()
        {
            string query = "SELECT * FROM `profile_image_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Profile_image_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `profile_image_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Profile_image_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `profile_image_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Profile_image_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `profile_image_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Profile_image_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `profile_image_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Profile_image_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `profile_image_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Profile_image_table_support
    {
        public List<Profile_image_table> createObjects(System.Data.DataTable table)
        {
            List<Profile_image_table> objects = new List<Profile_image_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Profile_image_table instance = new Profile_image_table();
                instance.Id = row["id"].ToString();
                instance.User_id = row["user_id"].ToString();
                instance.Url = row["url"].ToString();
                instance.Time = row["time"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, User_id, Url, Time }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.User_id) { return "user_id"; }
            if (column == Column.Url) { return "url"; }
            if (column == Column.Time) { return "time"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Profile_image_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("user_id"); table.Columns.Add("url"); table.Columns.Add("time"); foreach (Profile_image_table instance in objects) { table.Rows.Add(instance.Id, instance.User_id, instance.Url, instance.Time); }
            return table;
        }

    }
    public class Shift_table : Shift_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string day_period = "";
        public string Day_period
        {
            get { return day_period; }
            set { updateField("day_period", value, id); day_period = value; }
        }
        string start_time = "";
        public string Start_time
        {
            get { return start_time; }
            set { updateField("start_time", value, id); start_time = value; }
        }
        string end_time = "";
        public string End_time
        {
            get { return end_time; }
            set { updateField("end_time", value, id); end_time = value; }
        }
        public Shift_table() { }
        public Shift_table(string id) { loadData(id); }
        private Shift_table loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `shift_table` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.day_period = row["day_period"].ToString();
                this.start_time = row["start_time"].ToString();
                this.end_time = row["end_time"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.day_period = "";
            this.start_time = "";
            this.end_time = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.day_period = row["day_period"].ToString();
                this.start_time = row["start_time"].ToString();
                this.end_time = row["end_time"].ToString();
            }
        }

        public Shift_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Shift_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Shift_table updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `shift_table` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Shift_table updateRow(string id, string day_period, string start_time, string end_time)
        {
            string[] pars = { "id", "day_period", "start_time", "end_time" };
            string[] values = { id, day_period, start_time, end_time };
            db.MysqlPlain("UPDATE `shift_table` SET `id` = @id, `day_period` = @day_period, `start_time` = @start_time, `end_time` = @end_time WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Shift_table insert(string day_period, string start_time, string end_time)
        {
            string[] pars = { "day_period", "start_time", "end_time" };
            string[] values = { day_period, start_time, end_time };
            db.MysqlPlain("INSERT INTO `shift_table`(`day_period`, `start_time`, `end_time`) VALUES(@day_period, @start_time, @end_time)", pars, values);
            loadData(db.getMaxID("shift_table"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `shift_table` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `shift_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Shift_table> getAllRecords()
        {
            string query = "SELECT * FROM `shift_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Shift_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Shift_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `shift_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Shift_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `shift_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Shift_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Shift_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `shift_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Shift_table_support
    {
        public List<Shift_table> createObjects(System.Data.DataTable table)
        {
            List<Shift_table> objects = new List<Shift_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Shift_table instance = new Shift_table();
                instance.Id = row["id"].ToString();
                instance.Day_period = row["day_period"].ToString();
                instance.Start_time = row["start_time"].ToString();
                instance.End_time = row["end_time"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Day_period, Start_time, End_time }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Day_period) { return "day_period"; }
            if (column == Column.Start_time) { return "start_time"; }
            if (column == Column.End_time) { return "end_time"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Shift_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("day_period"); table.Columns.Add("start_time"); table.Columns.Add("end_time"); foreach (Shift_table instance in objects) { table.Rows.Add(instance.Id, instance.Day_period, instance.Start_time, instance.End_time); }
            return table;
        }

    }
    public class User_details : User_details_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string fname = "";
        public string Fname
        {
            get { return fname; }
            set { updateField("fname", value, id); fname = value; }
        }
        string lname = "";
        public string Lname
        {
            get { return lname; }
            set { updateField("lname", value, id); lname = value; }
        }
        string email = "";
        public string Email
        {
            get { return email; }
            set { updateField("email", value, id); email = value; }
        }
        string address = "";
        public string Address
        {
            get { return address; }
            set { updateField("address", value, id); address = value; }
        }
        string contact = "";
        public string Contact
        {
            get { return contact; }
            set { updateField("contact", value, id); contact = value; }
        }
        string gender = "";
        public string Gender
        {
            get { return gender; }
            set { updateField("gender", value, id); gender = value; }
        }
        string dob = "";
        public string Dob
        {
            get { return dob; }
            set { updateField("dob", value, id); dob = value; }
        }
        string user_type = "";
        public string User_type
        {
            get { return user_type; }
            set { updateField("user_type", value, id); user_type = value; }
        }
        public User_details() { }
        public User_details(string id) { loadData(id); }
        private User_details loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `user_details` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.email = row["email"].ToString();
                this.address = row["address"].ToString();
                this.contact = row["contact"].ToString();
                this.gender = row["gender"].ToString();
                this.dob = row["dob"].ToString();
                this.user_type = row["user_type"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.fname = "";
            this.lname = "";
            this.email = "";
            this.address = "";
            this.contact = "";
            this.gender = "";
            this.dob = "";
            this.user_type = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.email = row["email"].ToString();
                this.address = row["address"].ToString();
                this.contact = row["contact"].ToString();
                this.gender = row["gender"].ToString();
                this.dob = row["dob"].ToString();
                this.user_type = row["user_type"].ToString();
            }
        }

        public User_details Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public User_details Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public User_details updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `user_details` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public User_details updateRow(string id, string fname, string lname, string email, string address, string contact, string gender, string dob, string user_type)
        {
            string[] pars = { "id", "fname", "lname", "email", "address", "contact", "gender", "dob", "user_type" };
            string[] values = { id, fname, lname, email, address, contact, gender, dob, user_type };
            db.MysqlPlain("UPDATE `user_details` SET `id` = @id, `fname` = @fname, `lname` = @lname, `email` = @email, `address` = @address, `contact` = @contact, `gender` = @gender, `dob` = @dob, `user_type` = @user_type WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public User_details insert(string fname, string lname, string email, string address, string contact, string gender, string dob, string user_type)
        {
            string[] pars = { "fname", "lname", "email", "address", "contact", "gender", "dob", "user_type" };
            string[] values = { fname, lname, email, address, contact, gender, dob, user_type };
            db.MysqlPlain("INSERT INTO `user_details`(`fname`, `lname`, `email`, `address`, `contact`, `gender`, `dob`, `user_type`) VALUES(@fname, @lname, @email, @address, @contact, @gender, @dob, @user_type)", pars, values);
            loadData(db.getMaxID("user_details"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `user_details` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `user_details` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `user_details` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<User_details> getAllRecords()
        {
            string query = "SELECT * FROM `user_details`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<User_details> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `user_details`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<User_details> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `user_details`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<User_details> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `user_details`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<User_details> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `user_details`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<User_details> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `user_details`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class User_details_support
    {
        public List<User_details> createObjects(System.Data.DataTable table)
        {
            List<User_details> objects = new List<User_details>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                User_details instance = new User_details();
                instance.Id = row["id"].ToString();
                instance.Fname = row["fname"].ToString();
                instance.Lname = row["lname"].ToString();
                instance.Email = row["email"].ToString();
                instance.Address = row["address"].ToString();
                instance.Contact = row["contact"].ToString();
                instance.Gender = row["gender"].ToString();
                instance.Dob = row["dob"].ToString();
                instance.User_type = row["user_type"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Fname, Lname, Email, Address, Contact, Gender, Dob, User_type }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Fname) { return "fname"; }
            if (column == Column.Lname) { return "lname"; }
            if (column == Column.Email) { return "email"; }
            if (column == Column.Address) { return "address"; }
            if (column == Column.Contact) { return "contact"; }
            if (column == Column.Gender) { return "gender"; }
            if (column == Column.Dob) { return "dob"; }
            if (column == Column.User_type) { return "user_type"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<User_details> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("fname"); table.Columns.Add("lname"); table.Columns.Add("email"); table.Columns.Add("address"); table.Columns.Add("contact"); table.Columns.Add("gender"); table.Columns.Add("dob"); table.Columns.Add("user_type"); foreach (User_details instance in objects) { table.Rows.Add(instance.Id, instance.Fname, instance.Lname, instance.Email, instance.Address, instance.Contact, instance.Gender, instance.Dob, instance.User_type); }
            return table;
        }

    }
    #endregion Database Model
}
