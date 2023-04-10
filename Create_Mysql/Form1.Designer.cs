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
            this.SuspendLayout();
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(59, 58);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDB.TabIndex = 0;
            this.btnCreateDB.Text = "创建库";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(59, 110);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTable.TabIndex = 1;
            this.btnCreateTable.Text = "创建表";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 185);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnCreateDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Button btnCreateTable;
    }
}

