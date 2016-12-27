using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wei.Pokemon
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string query1 = "select * from Package", query2="";
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            int gold=Convert.ToInt32(dt.Rows[3]["t_Number"].ToString());
            int a=Convert.ToInt32(dt.Rows[0]["t_Number"].ToString());
            int b=Convert.ToInt32(dt.Rows[1]["t_Number"].ToString());
            int c=Convert.ToInt32(dt.Rows[2]["t_Number"].ToString());

            if ((rdoC.Checked == true && gold < 100) || (rdoB.Checked == true && gold < 50) || (rdoA.Checked == true && gold < 10))
                MessageBox.Show("金币不足！！", "金币不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (rdoA.Checked == true && gold >= 10)
                {
                    gold -= 10;
                    a++;
                }
                else if (rdoB.Checked == true && gold >= 50)
                {
                    gold -= 50;
                    b++;
                }
                else if (rdoC.Checked == true && gold >= 100)
                {
                    gold -= 100;
                    c++;
                }
                query2 = "update Package set t_Number = " + gold + " where t_ID = 4";
                System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                m_comm.ExecuteNonQuery();
                query2 = "update Package set t_Number = " + a + " where t_ID = 1";
                m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                m_comm.ExecuteNonQuery();
                query2 = "update Package set t_Number = " + b + " where t_ID = 2";
                m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                m_comm.ExecuteNonQuery();
                query2 = "update Package set t_Number = " + c + " where t_ID = 3";
                m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                m_comm.ExecuteNonQuery();
                dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
                dt = new DataTable();
                dataAdapter1.Fill(dt);
                this.dgBall.DataSource = dt;
                this.dgBall.Show();
            }

        }

        private void Shop_Load(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string query1 = "select * from Package";
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            this.dgBall.DataSource = dt;
            this.dgBall.Show();
            m_conn.Close();
            m_conn.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
