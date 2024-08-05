namespace ToolDanhMuc
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
            this.txtTool = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTool = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTool
            // 
            this.txtTool.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTool.Location = new System.Drawing.Point(79, 16);
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(251, 34);
            this.txtTool.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Record";
            // 
            // btnTool
            // 
            this.btnTool.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTool.Location = new System.Drawing.Point(22, 388);
            this.btnTool.Name = "btnTool";
            this.btnTool.Size = new System.Drawing.Size(147, 50);
            this.btnTool.TabIndex = 5;
            this.btnTool.Text = "Tool";
            this.btnTool.UseVisualStyleBackColor = true;
            this.btnTool.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTool);
            this.Name = "Form1";
            this.Text = "Tạo lập dữ liệu từ SGD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTool;
    }
}

