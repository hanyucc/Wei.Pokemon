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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确认重置所有游戏数据吗？","重置", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
                System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
                m_conn.Open();
                string query = "delete * from Fight";
                System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query, m_conn);
                m_comm.ExecuteNonQuery();
                query = "update Package set t_Number = 0";
                m_comm = new System.Data.OleDb.OleDbCommand(query, m_conn);
                m_comm.ExecuteNonQuery();
                query = "update Package set t_Number = 20 where t_ID = 4";
                m_comm = new System.Data.OleDb.OleDbCommand(query, m_conn);
                m_comm.ExecuteNonQuery();
                query = "delete * from Player";
                m_comm = new System.Data.OleDb.OleDbCommand(query, m_conn);
                m_comm.ExecuteNonQuery();
                query = "insert into Player (MON_name,MON_attack,MON_sheild,MON_level,MON_num1,MON_num2,MON_skill1,MON_skill2,MON_skill3,MON_health,MON_attribute,MON_id,MON_select) values ('初始精灵',52,110,10,0,0,1,14,15,2800,0,0,0)";
                m_comm = new System.Data.OleDb.OleDbCommand(query, m_conn);
                m_comm.ExecuteNonQuery();
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            Shop s = new Shop();
            s.ShowDialog();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Player i = new Player();
            i.Show();
        }

        private void btnBattle_Click(object sender, EventArgs e)
        {
            int a = 0;
            if(rdoKaladoun.Checked)
                a = 1;
            else if(rdoFreljord.Checked)
                a = 3;
            else if(rdoZaun.Checked)
                a = 2;
            if (a == 0)
                MessageBox.Show("未选择地区！！","未选择地区",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                Random r = new Random();
                int id = r.Next(1, 3);
                String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
                System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
                m_conn.Open();
                string query1 = "select * from Monster where MON_attribute = " + a;
                string query2 = "";
                string query3 = "select * from Player where MON_select = 1";
                string query5 = "delete * from Fight";
                System.Data.OleDb.OleDbCommand m_comm2 = new System.Data.OleDb.OleDbCommand(query5, m_conn);
                m_comm2.ExecuteNonQuery();
                System.Data.OleDb.OleDbDataAdapter dataAdapter2 = new System.Data.OleDb.OleDbDataAdapter(query3, m_conn);
                DataTable dt1 = new DataTable();
                dataAdapter2.Fill(dt1);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("未选择精灵！！", "未选择精灵", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
                    DataTable dt = new DataTable();
                    dataAdapter1.Fill(dt);
                    string query4 = "insert into Fight values(1,'" + dt1.Rows[0]["MON_name"] + "'," + dt1.Rows[0]["MON_skill1"] + "," + dt1.Rows[0]["MON_skill2"] + "," + dt1.Rows[0]["MON_skill3"] + "," + dt1.Rows[0]["MON_health"] + "," + dt1.Rows[0]["MON_attack"] + "," + dt1.Rows[0]["MON_sheild"] + "," + dt1.Rows[0]["MON_attribute"] + ",0,0)";
                    System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query4, m_conn);
                    m_comm.ExecuteNonQuery();
                    switch (id)
                    {
                        case 1:

                            query2 = "insert into Fight values(2,'" + dt.Rows[0]["MON_name"] + "'," + dt.Rows[0]["MON_skill1"] + "," + dt.Rows[0]["MON_skill2"] + "," + dt.Rows[0]["MON_skill3"] + "," + dt.Rows[0]["MON_health"] + "," + dt.Rows[0]["MON_attack"] + "," + dt.Rows[0]["MON_sheild"] + "," + dt.Rows[0]["MON_attribute"] + ",0,0)";
                            break;

                        case 2:
                            {
                                query2 = "insert into Fight values(2,'" + dt.Rows[1]["MON_name"] + "'," + dt.Rows[1]["MON_skill1"] + "," + dt.Rows[1]["MON_skill2"] + "," + dt.Rows[1]["MON_skill3"] + "," + dt.Rows[1]["MON_health"] + "," + dt.Rows[1]["MON_attack"] + "," + dt.Rows[1]["MON_sheild"] + "," + dt.Rows[1]["MON_attribute"] + ",0,0)";
                                break;
                            }
                    }
                    System.Data.OleDb.OleDbCommand m_comm1 = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                    m_comm1.ExecuteNonQuery();
                    m_conn.Close();
                    Battle b = new Battle();
                    b.ShowDialog();
                    m_conn.Open();
                    m_comm2.ExecuteNonQuery();
                    m_conn.Close();
                    m_conn.Dispose();
                }
            }
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            Type t = new Type();
            t.Show();
        }

        private void btnSkill_Click(object sender, EventArgs e)
        {
            Skill s = new Skill();
            s.Show();
        }

        private void rdoFreljord_CheckedChanged(object sender, EventArgs e)
        {
            lblBattle.Text = "在这里，你会遇到草系怪物。";
        }

        private void rdoZaun_CheckedChanged(object sender, EventArgs e)
        {
            lblBattle.Text = "在这里，你会遇到火系怪物。";
        }

        private void rdoKaladoun_CheckedChanged(object sender, EventArgs e)
        {
            lblBattle.Text = "在这里，你会遇到水系怪物。";
        }

    }
}
