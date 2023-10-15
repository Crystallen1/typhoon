namespace Typhoon
{
    partial class FormQueryByAttribute
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comBoxSelectMethod = new System.Windows.Forms.ComboBox();
            this.comBoxLayerName = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnDayu = new System.Windows.Forms.Button();
            this.btnDayuEqual = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnXiYu = new System.Windows.Forms.Button();
            this.btnXiaoyuEqual = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnNoEqual = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.labSelectResult = new System.Windows.Forms.Label();
            this.ListBoxFields = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtSelectResult = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comBoxSelectMethod);
            this.splitContainer1.Panel1.Controls.Add(this.comBoxLayerName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(923, 828);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "图层名";
            // 
            // comBoxSelectMethod
            // 
            this.comBoxSelectMethod.FormattingEnabled = true;
            this.comBoxSelectMethod.Items.AddRange(new object[] {
            "新建选择集",
            "添加到当前选择集",
            "从当前选择集中删除",
            "从当前选择集中选择"});
            this.comBoxSelectMethod.Location = new System.Drawing.Point(253, 102);
            this.comBoxSelectMethod.Name = "comBoxSelectMethod";
            this.comBoxSelectMethod.Size = new System.Drawing.Size(477, 32);
            this.comBoxSelectMethod.TabIndex = 1;
            this.comBoxSelectMethod.SelectedIndexChanged += new System.EventHandler(this.comBoxSelectMethod_SelectedIndexChanged_1);
            // 
            // comBoxLayerName
            // 
            this.comBoxLayerName.FormattingEnabled = true;
            this.comBoxLayerName.Location = new System.Drawing.Point(254, 22);
            this.comBoxLayerName.Name = "comBoxLayerName";
            this.comBoxLayerName.Size = new System.Drawing.Size(477, 32);
            this.comBoxLayerName.TabIndex = 0;
            this.comBoxLayerName.SelectedIndexChanged += new System.EventHandler(this.comBoxLayerName_SelectedIndexChanged_1);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.btnOr);
            this.splitContainer2.Panel1.Controls.Add(this.btnDayu);
            this.splitContainer2.Panel1.Controls.Add(this.btnDayuEqual);
            this.splitContainer2.Panel1.Controls.Add(this.btnAnd);
            this.splitContainer2.Panel1.Controls.Add(this.btnXiYu);
            this.splitContainer2.Panel1.Controls.Add(this.btnXiaoyuEqual);
            this.splitContainer2.Panel1.Controls.Add(this.btnNot);
            this.splitContainer2.Panel1.Controls.Add(this.btnNoEqual);
            this.splitContainer2.Panel1.Controls.Add(this.btnEqual);
            this.splitContainer2.Panel1.Controls.Add(this.labSelectResult);
            this.splitContainer2.Panel1.Controls.Add(this.ListBoxFields);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(923, 644);
            this.splitContainer2.SplitterDistance = 394;
            this.splitContainer2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "字段名";
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(402, 54);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(75, 49);
            this.btnOr.TabIndex = 16;
            this.btnOr.Text = "Or";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnDayu
            // 
            this.btnDayu.Location = new System.Drawing.Point(298, 109);
            this.btnDayu.Name = "btnDayu";
            this.btnDayu.Size = new System.Drawing.Size(75, 48);
            this.btnDayu.TabIndex = 14;
            this.btnDayu.Text = ">";
            this.btnDayu.UseVisualStyleBackColor = true;
            this.btnDayu.Click += new System.EventHandler(this.btnDayu_Click);
            // 
            // btnDayuEqual
            // 
            this.btnDayuEqual.Location = new System.Drawing.Point(402, 109);
            this.btnDayuEqual.Name = "btnDayuEqual";
            this.btnDayuEqual.Size = new System.Drawing.Size(75, 48);
            this.btnDayuEqual.TabIndex = 13;
            this.btnDayuEqual.Text = ">=";
            this.btnDayuEqual.UseVisualStyleBackColor = true;
            this.btnDayuEqual.Click += new System.EventHandler(this.btnDayuEqual_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(515, 109);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(75, 48);
            this.btnAnd.TabIndex = 12;
            this.btnAnd.Text = "And";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnXiYu
            // 
            this.btnXiYu.Location = new System.Drawing.Point(298, 163);
            this.btnXiYu.Name = "btnXiYu";
            this.btnXiYu.Size = new System.Drawing.Size(75, 48);
            this.btnXiYu.TabIndex = 11;
            this.btnXiYu.Text = "<";
            this.btnXiYu.UseVisualStyleBackColor = true;
            this.btnXiYu.Click += new System.EventHandler(this.btnXiYu_Click);
            // 
            // btnXiaoyuEqual
            // 
            this.btnXiaoyuEqual.Location = new System.Drawing.Point(402, 163);
            this.btnXiaoyuEqual.Name = "btnXiaoyuEqual";
            this.btnXiaoyuEqual.Size = new System.Drawing.Size(75, 48);
            this.btnXiaoyuEqual.TabIndex = 10;
            this.btnXiaoyuEqual.Text = "<=";
            this.btnXiaoyuEqual.UseVisualStyleBackColor = true;
            this.btnXiaoyuEqual.Click += new System.EventHandler(this.btnXiaoyuEqual_Click);
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(515, 163);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(75, 48);
            this.btnNot.TabIndex = 9;
            this.btnNot.Text = "Not";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnNoEqual
            // 
            this.btnNoEqual.Location = new System.Drawing.Point(515, 54);
            this.btnNoEqual.Name = "btnNoEqual";
            this.btnNoEqual.Size = new System.Drawing.Size(75, 49);
            this.btnNoEqual.TabIndex = 8;
            this.btnNoEqual.Text = "<>";
            this.btnNoEqual.UseVisualStyleBackColor = true;
            this.btnNoEqual.Click += new System.EventHandler(this.btnNoEqual_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(298, 54);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(75, 49);
            this.btnEqual.TabIndex = 4;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // labSelectResult
            // 
            this.labSelectResult.AutoSize = true;
            this.labSelectResult.Location = new System.Drawing.Point(317, 345);
            this.labSelectResult.Name = "labSelectResult";
            this.labSelectResult.Size = new System.Drawing.Size(82, 24);
            this.labSelectResult.TabIndex = 2;
            this.labSelectResult.Text = "label1";
            // 
            // ListBoxFields
            // 
            this.ListBoxFields.FormattingEnabled = true;
            this.ListBoxFields.ItemHeight = 24;
            this.ListBoxFields.Location = new System.Drawing.Point(39, 49);
            this.ListBoxFields.Name = "ListBoxFields";
            this.ListBoxFields.Size = new System.Drawing.Size(220, 292);
            this.ListBoxFields.TabIndex = 0;
            this.ListBoxFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxFields_MouseDoubleClick_1);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtSelectResult);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Size = new System.Drawing.Size(923, 246);
            this.splitContainer3.SplitterDistance = 176;
            this.splitContainer3.TabIndex = 0;
            // 
            // txtSelectResult
            // 
            this.txtSelectResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectResult.Location = new System.Drawing.Point(0, 0);
            this.txtSelectResult.Name = "txtSelectResult";
            this.txtSelectResult.Size = new System.Drawing.Size(923, 35);
            this.txtSelectResult.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(685, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "确认";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(766, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormQueryByAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 828);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormQueryByAttribute";
            this.Text = "FormQueryByAttribute";
            this.Load += new System.EventHandler(this.FormQueryByAttribute_Load_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox comBoxLayerName;
        private System.Windows.Forms.ComboBox comBoxSelectMethod;
        private System.Windows.Forms.ListBox ListBoxFields;
        private System.Windows.Forms.Label labSelectResult;
        private System.Windows.Forms.TextBox txtSelectResult;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnDayu;
        private System.Windows.Forms.Button btnDayuEqual;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnXiYu;
        private System.Windows.Forms.Button btnXiaoyuEqual;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnNoEqual;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}