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
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        public static int monsterid = 1;

        private void Player_Load(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string query1 = "select * from Player";
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            this.dgType.DataSource = dt;
            this.dgType.Show();
            m_conn.Close();
            m_conn.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            Query q = new Query();
            q.ShowDialog();
            string query1;
            int query2;
            if (Query.num == 0)
                query1 = "select * from Player";
            else
            {
                query2 = Query.num;
                query1 = "select * from Player where MON_attribute = " + query2;
            }
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            this.dgType.DataSource = dt;
            this.dgType.Show();
            m_conn.Close();
            m_conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            monsterid = Convert.ToInt32(dgType.CurrentRow.Cells[0].Value);
            string query1 = "update Player set MON_select = 0";
            string query2 = "update Player set MON_select = 1 where ID = " + monsterid;
            System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query1, m_conn);
            m_comm.ExecuteNonQuery();
            System.Data.OleDb.OleDbCommand m_comm1 = new System.Data.OleDb.OleDbCommand(query2, m_conn);
            m_comm1.ExecuteNonQuery();
            MessageBox.Show("默认精灵已设置为“" + dgType.CurrentRow.Cells[1].Value + "”！！","设置成功",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
