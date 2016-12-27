namespace Wei.Pokemon
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnShop = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnBattle = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.rdoFreljord = new System.Windows.Forms.RadioButton();
            this.rdoZaun = new System.Windows.Forms.RadioButton();
            this.rdoKaladoun = new System.Windows.Forms.RadioButton();
            this.btnType = new System.Windows.Forms.Button();
            this.lblBattle = new System.Windows.Forms.Label();
            this.btnSkill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(145, 383);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(75, 23);
            this.btnShop.TabIndex = 0;
            this.btnShop.Text = "商店";
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(46, 383);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "精灵背包";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnBattle
            // 
            this.btnBattle.Location = new System.Drawing.Point(46, 339);
            this.btnBattle.Name = "btnBattle";
            this.btnBattle.Size = new System.Drawing.Size(75, 23);
            this.btnBattle.TabIndex = 2;
            this.btnBattle.Text = "战斗";
            this.btnBattle.UseVisualStyleBackColor = true;
            this.btnBattle.Click += new System.EventHandler(this.btnBattle_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(382, 383);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(572, 383);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 4;
            this.btnOut.Text = "退出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Image = ((System.Drawing.Image)(resources.GetObject("picMap.Image")));
            this.picMap.Location = new System.Drawing.Point(45, 12);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(602, 296);
            this.picMap.TabIndex = 5;
            this.picMap.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(572, 339);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // rdoFreljord
            // 
            this.rdoFreljord.AutoSize = true;
            this.rdoFreljord.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoFreljord.Location = new System.Drawing.Point(259, 77);
            this.rdoFreljord.Name = "rdoFreljord";
            this.rdoFreljord.Size = new System.Drawing.Size(105, 19);
            this.rdoFreljord.TabIndex = 8;
            this.rdoFreljord.TabStop = true;
            this.rdoFreljord.Text = "弗雷尔卓德";
            this.rdoFreljord.UseVisualStyleBackColor = true;
            this.rdoFreljord.CheckedChanged += new System.EventHandler(this.rdoFreljord_CheckedChanged);
            // 
            // rdoZaun
            // 
            this.rdoZaun.AutoSize = true;
            this.rdoZaun.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoZaun.Location = new System.Drawing.Point(477, 188);
            this.rdoZaun.Name = "rdoZaun";
            this.rdoZaun.Size = new System.Drawing.Size(57, 19);
            this.rdoZaun.TabIndex = 9;
            this.rdoZaun.TabStop = true;
            this.rdoZaun.Text = "祖安";
            this.rdoZaun.UseVisualStyleBackColor = true;
            this.rdoZaun.CheckedChanged += new System.EventHandler(this.rdoZaun_CheckedChanged);
            // 
            // rdoKaladoun
            // 
            this.rdoKaladoun.AutoSize = true;
            this.rdoKaladoun.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoKaladoun.Location = new System.Drawing.Point(182, 223);
            this.rdoKaladoun.Name = "rdoKaladoun";
            this.rdoKaladoun.Size = new System.Drawing.Size(73, 19);
            this.rdoKaladoun.TabIndex = 10;
            this.rdoKaladoun.TabStop = true;
            this.rdoKaladoun.Text = "卡拉多";
            this.rdoKaladoun.UseVisualStyleBackColor = true;
            this.rdoKaladoun.CheckedChanged += new System.EventHandler(this.rdoKaladoun_CheckedChanged);
            // 
            // btnType
            // 
            this.btnType.Location = new System.Drawing.Point(477, 383);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(75, 23);
            this.btnType.TabIndex = 11;
            this.btnType.Text = "精灵图鉴";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // lblBattle
            // 
            this.lblBattle.AutoSize = true;
            this.lblBattle.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBattle.Location = new System.Drawing.Point(142, 343);
            this.lblBattle.Name = "lblBattle";
            this.lblBattle.Size = new System.Drawing.Size(85, 13);
            this.lblBattle.TabIndex = 12;
            this.lblBattle.Text = "请选择地区。";
            // 
            // btnSkill
            // 
            this.btnSkill.Location = new System.Drawing.Point(477, 339);
            this.btnSkill.Name = "btnSkill";
            this.btnSkill.Size = new System.Drawing.Size(75, 23);
            this.btnSkill.TabIndex = 14;
            this.btnSkill.Text = "技能图鉴";
            this.btnSkill.UseVisualStyleBackColor = true;
            this.btnSkill.Click += new System.EventHandler(this.btnSkill_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 430);
            this.Controls.Add(this.btnSkill);
            this.Controls.Add(this.lblBattle);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.rdoKaladoun);
            this.Controls.Add(this.rdoZaun);
            this.Controls.Add(this.rdoFreljord);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBattle);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnShop);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnBattle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.RadioButton rdoFreljord;
        private System.Windows.Forms.RadioButton rdoZaun;
        private System.Windows.Forms.RadioButton rdoKaladoun;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Label lblBattle;
        private System.Windows.Forms.Button btnSkill;
    }
}