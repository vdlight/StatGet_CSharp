namespace StatGet_CSharp
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Col_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Res = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Lag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Målgörare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Ass1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Ass2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_Time,
            this.Col_Res,
            this.Col_Stat,
            this.Col_Lag,
            this.Col_Målgörare,
            this.Col_Ass1,
            this.Col_Ass2});
            this.listView1.Location = new System.Drawing.Point(12, 140);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(884, 201);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Col_Time
            // 
            this.Col_Time.Text = "Time";
            this.Col_Time.Width = 70;
            // 
            // Col_Res
            // 
            this.Col_Res.Text = "Res";
            this.Col_Res.Width = 70;
            // 
            // Col_Stat
            // 
            this.Col_Stat.Text = "Stat";
            this.Col_Stat.Width = 70;
            // 
            // Col_Lag
            // 
            this.Col_Lag.Text = "Team";
            this.Col_Lag.Width = 70;
            // 
            // Col_Målgörare
            // 
            this.Col_Målgörare.Text = "Scorer";
            this.Col_Målgörare.Width = 200;
            // 
            // Col_Ass1
            // 
            this.Col_Ass1.Text = "Assist 1";
            this.Col_Ass1.Width = 200;
            // 
            // Col_Ass2
            // 
            this.Col_Ass2.Text = "Assist 2";
            this.Col_Ass2.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1000, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 386);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(884, 140);
            this.treeView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 601);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Col_Time;
        private System.Windows.Forms.ColumnHeader Col_Res;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader Col_Stat;
        private System.Windows.Forms.ColumnHeader Col_Lag;
        private System.Windows.Forms.ColumnHeader Col_Målgörare;
        private System.Windows.Forms.ColumnHeader Col_Ass1;
        private System.Windows.Forms.ColumnHeader Col_Ass2;
        private System.Windows.Forms.TreeView treeView1;
    }
}

