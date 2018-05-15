using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAPIExample.DataAccess
{
    public class DAEmployee
    {


        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstemployees = new List<Employee>();
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=DBEmployee;User id=user1;Password=password1!;Integrated Security=False";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from tblEmployee";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader.GetValue(0));
                emp.EmployeeFirstName = Convert.ToString(reader.GetValue(1));
                emp.EmployeeLastName = Convert.ToString(reader.GetValue(2));
                emp.ManagerID = Convert.ToInt32(reader.GetValue(3));
                lstemployees.Add(emp);

            }
            return lstemployees;

        }
        public int AddEmployee(Employee objEmployee)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=DBEmployee;User id=user1;Password=password1!;Integrated Security=False";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO tblEmployee (FirstName,LastName,ManagerId) Values (@EmployeeFirstName,@EmployeeLastName,@ManagerId)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@EmployeeFirstName", objEmployee.EmployeeFirstName);
            sqlCmd.Parameters.AddWithValue("@EmployeeLastName", objEmployee.EmployeeLastName);
            sqlCmd.Parameters.AddWithValue("@ManagerId", objEmployee.ManagerID);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
            return rowInserted;

        }

        public int UpdateEmployee(Employee objEmployee)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=DBEmployee;User id=user1;Password=password1!;Integrated Security=False";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblEmployee set FirstName=@EmployeeFirstName,LastName=@EmployeeLastName,ManagerId=@ManagerId where EmployeeID=@EmployeeID";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@EmployeeFirstName", objEmployee.EmployeeFirstName);
            sqlCmd.Parameters.AddWithValue("@EmployeeLastName", objEmployee.EmployeeLastName);
            sqlCmd.Parameters.AddWithValue("@ManagerId", objEmployee.ManagerID);
            sqlCmd.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeID);
            myConnection.Open();
            int rowupdated = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
            return rowupdated;

        }
        public int DeleteEmployee(Employee objEmployee)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=DBEmployee;User id=user1;Password=password1!;Integrated Security=False";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Delete from tblEmployee where EmployeeID=@EmployeeID";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeID);
            myConnection.Open();
            int rowupdated = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
            return rowupdated;

        }

    }
}
