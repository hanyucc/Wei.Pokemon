using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Wei.Pokemon
{
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
        }
        private double wa = 1.0, wb = 1.0;
        private int hpa, hpb, sk1, sk2, sk3, sp2, sp3, d1, d2, d3, sk11, sk12, sk13, d11, d12, d13, sp12, sp13, ata, atb;
        DataTable dt, dt1, dt2;

        private void Battle_Load(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string q = "select * from Package";
            System.Data.OleDb.OleDbDataAdapter dataAdapter2 = new System.Data.OleDb.OleDbDataAdapter(q, m_conn);
            dt2 = new DataTable();
            dataAdapter2.Fill(dt2);
            string query1 = "select * from Fight";
            string query2 = "select * from Skill";
            System.Data.OleDb.OleDbDataAdapter dataAdapter = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            dt = new DataTable();
            dataAdapter.Fill(dt);
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query2, m_conn);
            dt1 = new DataTable();
            dataAdapter1.Fill(dt1);
            lbla.Text = dt.Rows[0]["MON_name"].ToString();
            lblb.Text = dt.Rows[1]["MON_name"].ToString();
            hpa = Convert.ToInt32(dt.Rows[0]["MON_health"]); hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
            sk1 = Convert.ToInt32(dt.Rows[0]["MON_skill1"]); sk2 = Convert.ToInt32(dt.Rows[0]["MON_skill2"]); sk3 = Convert.ToInt32(dt.Rows[0]["MON_skill3"]);
            sk11 = Convert.ToInt32(dt.Rows[1]["MON_skill1"]); sk12 = Convert.ToInt32(dt.Rows[1]["MON_skill2"]); sk13 = Convert.ToInt32(dt.Rows[1]["MON_skill3"]);
            sp2 = Convert.ToInt32(dt1.Rows[sk2 - 1]["SKILL_sp"]); sp3 = Convert.ToInt32(dt1.Rows[sk3 - 1]["SKILL_sp"]);
            sp12 = Convert.ToInt32(dt1.Rows[sk12 - 1]["SKILL_sp"]); sp13 = Convert.ToInt32(dt1.Rows[sk13 - 1]["SKILL_sp"]);
            d1 = Convert.ToInt32(dt1.Rows[sk1 - 1]["SKILL_damage"]); d2 = Convert.ToInt32(dt1.Rows[sk2 - 1]["SKILL_damage"]); d3 = Convert.ToInt32(dt1.Rows[sk3 - 1]["SKILL_damage"]);
            d11 = Convert.ToInt32(dt1.Rows[sk11 - 1]["SKILL_damage"]); d12 = Convert.ToInt32(dt1.Rows[sk12 - 1]["SKILL_damage"]); d13 = Convert.ToInt32(dt1.Rows[sk13 - 1]["SKILL_damage"]);
            ata = Convert.ToInt32(dt.Rows[0]["MON_attribute"]); atb = Convert.ToInt32(dt.Rows[1]["MON_attribute"]);
            tbxhpa.Text = hpa.ToString(); tbxhpb.Text = hpb.ToString();
            tbxsk1.Text = "DMG:" + dt1.Rows[sk1 - 1]["SKILL_damage"].ToString(); tbxsk2.Text = "DMG:" + dt1.Rows[sk2 - 1]["SKILL_damage"].ToString(); tbxsk3.Text = "DMG:" + dt1.Rows[sk3 - 1]["SKILL_damage"].ToString();
            btnsk1.Text = dt1.Rows[sk1 - 1]["SKILL_name"].ToString(); btnsk2.Text = dt1.Rows[sk2 - 1]["SKILL_name"].ToString(); btnsk3.Text = dt1.Rows[sk3 - 1]["SKILL_name"].ToString();
            m_conn.Close();
            m_conn.Dispose();
            if ((ata == 1 && atb == 2) || (ata == 2 && atb == 3) || (ata == 3 && atb == 1))
            {
                wa = 1.2;
                wb = 0.8;
            }
            else if ((atb == 1 && ata == 2) || (atb == 2 && ata == 3) || (atb == 3 && ata == 1))
            {
                wa = 0.8;
                wb = 1.2;
            }
        }

        private void btnsk1_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            int atka = Convert.ToInt32(dt.Rows[0]["MON_attack"]), atkb = Convert.ToInt32(dt.Rows[1]["MON_attack"]);
            int sha = Convert.ToInt32(dt.Rows[0]["MON_sheild"]), shb = Convert.ToInt32(dt.Rows[1]["MON_sheild"]);
            double dmg = Math.Max(0, (wa * d1 * atka - shb));
            lbld.Text = lbla.Text + "\n使用了" + btnsk1.Text + "\n造成了" + dmg.ToString() + "点伤害。";
            hpb -= Convert.ToInt32(dmg);
            if (hpb <= 0)
                hpb = 0;
            tbxhpb.Text = hpb.ToString();
            if (hpb == 0)
            {
                MessageBox.Show("胜利！！","胜利",MessageBoxButtons.OK,MessageBoxIcon.Information);
                int money = Convert.ToInt32(dt2.Rows[3]["t_Number"]) + 5;
                string query1 = "update Package set t_Number =" + money + " where t_ID = 4";
                System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query1, m_conn);
                m_comm.ExecuteNonQuery();
                this.Close();
            }
            if (hpb != 0)
            {
                Random r1 = new Random();
                int id1 = r1.Next(1, 4);
                int sk = 0, d = 0, sp = 0;
                switch (id1)
                {
                    case 1:
                        {
                            sk = sk11;
                            d = d11;
                            break;
                        }
                    case 2:
                        {
                            sk = sk12;
                            d = d12;
                            sp = sp12;
                            break;
                        }
                    case 3:
                        {
                            sk = sk13;
                            d = d13;
                            sp = sp13;
                            break;
                        }
                }
                if (sp != 1)
                {
                    double dmg1 = Math.Max(0, (wb * d * atkb - sha));
                    lblc.Text = dt.Rows[1]["MON_name"] + "\n使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n造成了" + dmg1.ToString() + "点伤害。";
                    hpa -= Convert.ToInt32(dmg1);
                    if (hpa <= 0)
                        hpa = 0;
                    tbxhpa.Text = hpa.ToString();
                }
                if (hpa == 0)
                {
                    MessageBox.Show("失败！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
                if (sp != 0)
                {
                    switch (sp)
                    {
                        case 1:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                lblc.Text = dt.Rows[1]["MON_name"] + "使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n回复了" + (wb * d * atkb).ToString() + "点生命。";
                                break;
                            }
                        case 2:
                            {
                                wb += 0.1;
                                break;
                            }
                        case 3:
                            {
                                wa -= 0.1;
                                break;
                            }
                        case 4:
                            {
                                wb -= 0.1;
                                break;
                            }
                        case 5:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                break;
                            }
                    }
                }
            }
        }

        private void btnsk2_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            int atka = Convert.ToInt32(dt.Rows[0]["MON_attack"]), atkb = Convert.ToInt32(dt.Rows[1]["MON_attack"]);
            int sha = Convert.ToInt32(dt.Rows[0]["MON_sheild"]), shb = Convert.ToInt32(dt.Rows[1]["MON_sheild"]);
            if (sp2 != 1)
            {
                double dmg = Math.Max(0, (wa * d2 * atka - shb));
                lbld.Text = lbla.Text + "\n使用了" + btnsk2.Text + "\n造成了" + dmg.ToString() + "点伤害。";
                hpb -= Convert.ToInt32(dmg);
                if (hpb <= 0)
                    hpb = 0;
                tbxhpb.Text = hpb.ToString();
            }
            if (hpb == 0)
            {
                MessageBox.Show("胜利！！", "胜利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int money = Convert.ToInt32(dt2.Rows[3]["t_Number"]) + 5;
                string query1 = "update Package set t_Number =" + money + " where t_ID = 4";
                System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query1, m_conn);
                m_comm.ExecuteNonQuery();
                this.Close();
            }
            if (sp2 != 0)
            {
                switch (sp2)
                {
                    case 1:
                        {
                            hpa += Convert.ToInt32(wa * d2 * atka);
                            if (hpa > Convert.ToInt32(dt.Rows[0]["MON_health"]))
                                hpa = Convert.ToInt32(dt.Rows[0]["MON_health"]);
                            tbxhpa.Text = hpa.ToString();
                            lbld.Text = lbla.Text + "\n使用了" + btnsk2.Text + "\n回复了" + (wa * d2 * atka).ToString() + "点生命。";
                            break;
                        }
                    case 2:
                        {
                            wa += 0.1;
                            break;
                        }
                    case 3:
                        {
                            wb -= 0.1;
                            break;
                        }
                    case 4:
                        {
                            wa -= 0.1;
                            break;
                        }
                    case 5:
                        {
                            hpa += Convert.ToInt32(wa * d2 * atka);
                            if (hpa > Convert.ToInt32(dt.Rows[0]["MON_health"]))
                                hpa = Convert.ToInt32(dt.Rows[0]["MON_health"]);
                            tbxhpa.Text = hpa.ToString();
                            break;
                        }
                }
            }
            tbxhpa.Text = hpa.ToString();
            if (hpb != 0)
            {
                Random r2 = new Random();
                int id2 = r2.Next(1, 4);
                int sk = 0, d = 0, sp = 0;
                switch (id2)
                {
                    case 1:
                        {
                            sk = sk11;
                            d = d11;
                            break;
                        }
                    case 2:
                        {
                            sk = sk12;
                            d = d12;
                            sp = sp12;
                            break;
                        }
                    case 3:
                        {
                            sk = sk13;
                            d = d13;
                            sp = sp13;
                            break;
                        }
                }
                if (sp != 1)
                {
                    double dmg1 = Math.Max(0, (wb * d * atkb - sha));
                    lblc.Text = dt.Rows[1]["MON_name"] + "\n使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n造成了" + dmg1.ToString() + "点伤害。";
                    hpa -= Convert.ToInt32(dmg1);
                    if (hpa <= 0)
                        hpa = 0;
                    tbxhpa.Text = hpa.ToString();
                }
                if (hpa == 0)
                {
                    MessageBox.Show("失败！！","失败",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    this.Close();
                }
                if (sp != 0)
                {
                    switch (sp)
                    {
                        case 1:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                lblc.Text = dt.Rows[1]["MON_name"] + "\n使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n回复了" + (wb * d * atkb).ToString() + "点生命。";
                                break;
                            }
                        case 2:
                            {
                                wb += 0.1;
                                break;
                            }
                        case 3:
                            {
                                wa -= 0.1;
                                break;
                            }
                        case 4:
                            {
                                wb -= 0.1;
                                break;
                            }
                        case 5:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                break;
                            }
                    }
                }
            }
        }

        private void btnsk3_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            int atka = Convert.ToInt32(dt.Rows[0]["MON_attack"]), atkb = Convert.ToInt32(dt.Rows[1]["MON_attack"]);
            int sha = Convert.ToInt32(dt.Rows[0]["MON_sheild"]), shb = Convert.ToInt32(dt.Rows[1]["MON_sheild"]);
            if (sp3 != 1)
            {
                double dmg = Math.Max(0,(wa * d3 * atka - shb));
                lbld.Text = lbla.Text + "\n使用了" + btnsk3.Text + "\n造成了" + dmg.ToString() + "点伤害。";
                hpb -= Convert.ToInt32(dmg);
                if (hpb <= 0)
                    hpb = 0;
                tbxhpb.Text = hpb.ToString();
            }
            if (hpb == 0)
            {
                MessageBox.Show("胜利！！", "胜利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int money = Convert.ToInt32(dt2.Rows[3]["t_Number"]) + 5;
                string query1 = "update Package set t_Number =" + money + " where t_ID = 4";
                System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query1, m_conn);
                m_comm.ExecuteNonQuery();
                this.Close();
            }
            if (sp3 != 0)
            {
                switch (sp3)
                {
                    case 1:
                        {
                            hpa += Convert.ToInt32(wa * d3 * atka);
                            if (hpa > Convert.ToInt32(dt.Rows[0]["MON_health"]))
                                hpa = Convert.ToInt32(dt.Rows[0]["MON_health"]);
                            tbxhpa.Text = hpa.ToString();
                            lbld.Text = lbla.Text + "\n使用了" + btnsk3.Text + "\n回复了" + (wa * d3 * atka).ToString() + "点生命。";
                            break;
                        }
                    case 2:
                        {
                            wa += 0.1;
                            break;
                        }
                    case 3:
                        {
                            wb -= 0.1;
                            break;
                        }
                    case 4:
                        {
                            wa -= 0.1;
                            break;
                        }
                    case 5:
                        {
                            hpa += Convert.ToInt32(wa * d3 * atka);
                            if (hpa > Convert.ToInt32(dt.Rows[0]["MON_health"]))
                                hpa = Convert.ToInt32(dt.Rows[0]["MON_health"]);
                            tbxhpa.Text = hpa.ToString();
                            break;
                        }
                }
            }
            tbxhpa.Text = hpa.ToString();
            if (hpb != 0)
            {
                Random r3 = new Random();
                int id3 = r3.Next(1, 4);
                int sk = 0, d = 0, sp = 0;
                switch (id3)
                {
                    case 1:
                        {
                            sk = sk11;
                            d = d11;
                            break;
                        }
                    case 2:
                        {
                            sk = sk12;
                            d = d12;
                            sp = sp12;
                            break;
                        }
                    case 3:
                        {
                            sk = sk13;
                            d = d13;
                            sp = sp13;
                            break;
                        }
                }
                if (sp != 1)
                {
                    double dmg1 = Math.Max(0, (wb * d * atkb - sha));
                    lblc.Text = dt.Rows[1]["MON_name"] + "\n使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n造成了" + dmg1.ToString() + "点伤害。";
                    hpa -= Convert.ToInt32(dmg1);
                    if (hpa <= 0)
                        hpa = 0;
                    tbxhpa.Text = hpa.ToString();
                }
                if (hpa == 0)
                {
                    MessageBox.Show("失败！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
                if (sp != 0)
                {
                    switch (sp)
                    {
                        case 1:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                lblc.Text = dt.Rows[1]["MON_name"] + "\n使用了" + dt1.Rows[sk - 1]["SKILL_name"] + "\n回复了" + (wb * d * atkb).ToString() + "点生命。";
                                break;
                            }
                        case 2:
                            {
                                wb += 0.1;
                                break;
                            }
                        case 3:
                            {
                                wa -= 0.1;
                                break;
                            }
                        case 4:
                            {
                                wb -= 0.1;
                                break;
                            }
                        case 5:
                            {
                                hpb += Convert.ToInt32(wb * d * atkb);
                                if (hpb > Convert.ToInt32(dt.Rows[1]["MON_health"]))
                                    hpb = Convert.ToInt32(dt.Rows[1]["MON_health"]);
                                tbxhpb.Text = hpb.ToString();
                                break;
                            }
                    }
                }
            }
        }

        private void btncatch_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string query2 = "insert into Player (MON_name,MON_attack,MON_sheild,MON_level,MON_num1,MON_num2,MON_skill1,MON_skill2,MON_skill3,MON_health,MON_attribute,MON_id,MON_select) values('" + dt.Rows[1]["MON_name"] + "'," + dt.Rows[1]["MON_attack"] + "," + dt.Rows[1]["MON_sheild"] + ",10,0,0," + dt.Rows[1]["MON_skill1"] + "," + dt.Rows[1]["MON_skill2"] + "," + dt.Rows[1]["MON_skill3"] + "," + dt.Rows[1]["MON_health"] + "," + dt.Rows[1]["MON_attribute"] + ",0,0)";
            string q = "select * from Package";
            System.Data.OleDb.OleDbDataAdapter dataAdapter2 = new System.Data.OleDb.OleDbDataAdapter(q, m_conn);
            dt2 = new DataTable();
            dataAdapter2.Fill(dt2);
            int num1 = Convert.ToInt32(dt2.Rows[0]["t_Number"]);
            int num2 = Convert.ToInt32(dt2.Rows[1]["t_Number"]);
            int num3 = Convert.ToInt32(dt2.Rows[2]["t_Number"]);
            try
            {
                if (cbxcatch.SelectedItem.ToString() == "精灵球A")
                {
                    if (num1 <= 0)
                        MessageBox.Show("精灵球数量不足！！", "精灵球不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        num1--;
                        string query3 = "update Package set t_Number =" + num1 + " where t_ID = 1";
                        System.Data.OleDb.OleDbCommand m_comm1 = new System.Data.OleDb.OleDbCommand(query3, m_conn);
                        m_comm1.ExecuteNonQuery();
                        Random r = new Random();
                        int id = r.Next(1, 101);
                        if (id <= 20)
                        {
                            MessageBox.Show("捕捉成功！！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                            m_comm.ExecuteNonQuery();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("捕捉失败！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                if (cbxcatch.SelectedItem.ToString() == "精灵球B")
                {
                    if (num2 <= 0)
                        MessageBox.Show("精灵球数量不足！！", "精灵球不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        num2--;
                        string query3 = "update Package set t_Number =" + num2 + " where t_ID = 2";
                        System.Data.OleDb.OleDbCommand m_comm1 = new System.Data.OleDb.OleDbCommand(query3, m_conn);
                        m_comm1.ExecuteNonQuery();
                        Random r = new Random();
                        int id = r.Next(1, 101);
                        if (id <= 50)
                        {
                            MessageBox.Show("捕捉成功！！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                            m_comm.ExecuteNonQuery();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("捕捉失败！！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                if (cbxcatch.SelectedItem.ToString() == "精灵球C")
                {
                    if (num3 <= 0)
                        MessageBox.Show("精灵球数量不足！！", "精灵球不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        num3--;
                        string query3 = "update Package set t_Number =" + num3 + " where t_ID = 3";
                        System.Data.OleDb.OleDbCommand m_comm1 = new System.Data.OleDb.OleDbCommand(query3, m_conn);
                        m_comm1.ExecuteNonQuery();
                        MessageBox.Show("捕捉成功！！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Data.OleDb.OleDbCommand m_comm = new System.Data.OleDb.OleDbCommand(query2, m_conn);
                        m_comm.ExecuteNonQuery();
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("未选择精灵球！！", "未选择精灵球", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}



