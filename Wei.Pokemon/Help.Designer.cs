namespace Wei.Pokemon
{
    partial class Help
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(346, 358);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "\n伪·口袋妖怪 使用说明\n\n1. 可通过图鉴查询游戏中所有精灵与技能的属性。\n\n2. sp属性代表特殊技能，其中：1代表回血，2代表提高自己攻击，3代表减少对方攻" +
    "击，4代表减少自己攻击，5代表回血且造成伤害。\n\n3. 每次战斗胜利获得5金币，失败无惩罚，可自行退出战斗。\n\n4. 战斗时可通过精灵球捕捉精灵，若捕捉成功则结" +
    "束战斗并获得精灵，同一精灵可重复获得。";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 381);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}