using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Budweg.MVVM.Models;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class EmployeeRepository : Repository
    {
        public EmployeeRepository() 
        {
            Load();
        }

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

        public Employee GetEmployeeId(string email)
        {
            foreach (Employee emails in employees)
            {
                if (emails.Email == email)
                {
                    return emails;
                }

            }
                return null;
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

        public void Delete(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM EMPLOYEE WHERE Email = @Email",con);

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                cmd.ExecuteNonQuery();
            }
                employees.Remove(employee);
        }
    }
}
