namespace Create_Mysql
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(228, 63);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDB.TabIndex = 0;
            this.btnCreateDB.Text = "创建库";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(228, 107);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTable.TabIndex = 1;
            this.btnCreateTable.Text = "创建表";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(95, 64);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(100, 21);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.Text = "xyt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "数据库名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "表名：";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(95, 108);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 21);
            this.txtTable.TabIndex = 5;
            this.txtTable.Text = "t1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 185);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnCreateDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTable;
    }
}

