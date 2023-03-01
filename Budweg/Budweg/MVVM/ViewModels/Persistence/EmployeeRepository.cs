using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.MVVM.Models;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class EmployeeRepository : Repository
    {
        #region Singleton Pattern
        private static EmployeeRepository _instance;

        public static EmployeeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeRepository();
                    return _instance;
                }
                return _instance;
            }
        }
        #endregion

        List<Employee> employees = new List<Employee>();

        public override void Load()
        {

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string Name = dr["Name"].ToString();
                        string Email = dr["Email"].ToString();
                        bool IsHR = bool.Parse(dr["IsHR"].ToString());


                        Employee employee = new Employee(Name, Email, IsHR);

                        employees.Add(employee);

                    }
                }
            }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public Employee Create(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE(Name, Email, IsHR)" + 
                    "VALUES(@Name, @Email, @IsHR)", con);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                cmd.Parameters.Add("@IsHR", SqlDbType.Bit).Value = employee.IsHR;
                cmd.ExecuteNonQuery();

                employees.Add(employee);
                return employee;
            }
        }
    }
}
