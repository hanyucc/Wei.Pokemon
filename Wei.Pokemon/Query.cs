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
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        public static int num = 0;

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbType.SelectedItem.ToString())
                {
                    case "所有":
                        {
                            num = 0;
                            break;
                        }
                    case "水":
                        {
                            num = 1;
                            break;
                        }
                    case "火":
                        {
                            num = 2;
                            break;
                        }
                    case "草":
                        {
                            num = 3;
                            break;
                        }
                }
            }
            catch 
            {
                MessageBox.Show("未选择属性！！","未选择属性",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
