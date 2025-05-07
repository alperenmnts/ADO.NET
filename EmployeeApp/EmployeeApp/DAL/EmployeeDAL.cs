using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeApp.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;

        public List<Employee> GetEmployees(int id = 0)
        {
            cmd = new SqlCommand("GetAllEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);

            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Employee()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    EmpName = dr["EmpName"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    Kimlik = Convert.ToByte(dr["Kimlik"]),
                    Departman = dr["Departman"].ToString(),
                    Date = Convert.ToDateTime(dr["EmpDate"])

                });
            }
            return list;
        }

        public bool InsertEmployee(Employee employee)
        {
            cmd = new SqlCommand("insertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", employee.EmpName);
            cmd.Parameters.Add("@surname", employee.Surname);
            cmd.Parameters.Add("@kimlik", employee.Kimlik);
            cmd.Parameters.Add("@departman", employee.Departman);
            cmd.Parameters.Add("@tarih", employee.Date).Value = DateTime.Now;
            con.Open();

            int etk = cmd.ExecuteNonQuery();
            con.Close();
            if (etk > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool UpdateEmployee(Employee employee)
        {
            cmd = new SqlCommand("updateEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", employee.EmpName);
            cmd.Parameters.Add("@surname", employee.Surname);
            cmd.Parameters.Add("@kimlik", employee.Kimlik);
            cmd.Parameters.Add("@departman", employee.Departman);
            cmd.Parameters.Add("@id", employee.Id);
            cmd.Parameters.Add("@tarih", employee.Date).Value = DateTime.Now;
            con.Open();

            int etk = cmd.ExecuteNonQuery();
            con.Close();
            if (etk > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool DeleteEmployee(int id)
        {
            cmd = new SqlCommand("deleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", id);
            con.Open();
            int etk = cmd.ExecuteNonQuery();
            con.Close();
            if (etk > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}