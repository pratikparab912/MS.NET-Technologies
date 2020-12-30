using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

           cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            
            ds = new DataSet();
            da.Fill(ds, "Emps");

            cmd.CommandText = "select * from Departments";
            da.Fill(ds, "Deps");

            //primary key validation
            DataColumn[] arrCols = new DataColumn[1];
            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
            ds.Tables["Emps"].PrimaryKey = arrCols;


            //foreign key validation
            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);


            //column level constraints
            //ds.Tables["Deps"].Columns["DeptName"].Unique = true;

            //dgEmps.ItemsSource = ds.Tables[0].DefaultView;
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
            //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;
            cn.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";

            // cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text);

            //SqlParameter p = new SqlParameter();
            //p.ParameterName = "@Name";
            //p.SourceColumn = "Name";
            //p.SourceVersion = DataRowVersion.Current;
            //cmdUpdate.Parameters.Add(p);
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //similarly create the insert command
            //similarly create the delete command

            SqlDataAdapter da = new SqlDataAdapter();

            da.UpdateCommand = cmdUpdate;
            //da.InsertCommand = cmdInsert;
            //da.DeleteCommand = cmdDelete;


            da.Update(ds, "Emps");
        }
    }
}
