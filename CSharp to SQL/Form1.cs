using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "dw001";
            textBox2.Text = "00001";
            //string timestamp = DateTime.Now.ToString();
            //string times = timestamp[0].ToString();
            //times = times + times;
            //textBox3.Text = times;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            DataSet CustomersDataSet = new DataSet();
            
            
            string sqlText = "SELECT * FROM Mst_Scanner";

            SqlConnection sqlConn = new SqlConnection(@"Data Source=MMI3700106LN01\SQLEXPRESS;Database=ScannerDB;Integrated Security=True");

            SqlCommand command = new SqlCommand(sqlText, sqlConn);


            SqlDataAdapter da = new SqlDataAdapter();
           da.InsertCommand = new SqlCommand("INSERT INTO Mst_Scanner VALUES(@Mobis_Ser,@Comp_Ser,@Add_Date)", sqlConn);
           da.InsertCommand.Parameters.Add("@Mobis_Ser", SqlDbType.VarChar).Value = textBox1.Text;
           da.InsertCommand.Parameters.Add("@Comp_Ser", SqlDbType.VarChar).Value = textBox2.Text;
           da.InsertCommand.Parameters.Add("@Add_Date", SqlDbType.Text).Value = textBox3.Text;

         //  SqlParameter sinceDateTimeParam = new SqlParameter("@sinceDateTime", SqlDbType.DateTime);
        //   sinceDateTimeParam.Value = since;
         //  da.Parameters.Add(sinceDateTimeParam);

            sqlConn.Open();
            da.InsertCommand.ExecuteNonQuery();
            sqlConn.Close();
            MessageBox.Show("added");
            this.Close();
        }
    }
}