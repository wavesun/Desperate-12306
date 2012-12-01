namespace YA12306
{
    partial class MainFrame
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromBox = new System.Windows.Forms.ComboBox();
            this.toBox = new System.Windows.Forms.ComboBox();
            this.autoQuery = new System.Windows.Forms.CheckBox();
            this.queryIntervalText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trainBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(0, 85);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(974, 724);
            this.webBrowser.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(887, 57);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Query Now!";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date:";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "YYYY-MM-DD";
            this.datePicker.Location = new System.Drawing.Point(44, 9);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(180, 20);
            this.datePicker.TabIndex = 3;
            this.datePicker.Value = new System.DateTime(2012, 9, 30, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To:";
            // 
            // fromBox
            // 
            this.fromBox.FormattingEnabled = true;
            this.fromBox.Location = new System.Drawing.Point(44, 40);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(66, 21);
            this.fromBox.TabIndex = 6;
            this.fromBox.Text = "北京";
            // 
            // toBox
            // 
            this.toBox.FormattingEnabled = true;
            this.toBox.Location = new System.Drawing.Point(150, 40);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(74, 21);
            this.toBox.TabIndex = 7;
            this.toBox.Text = "许昌";
            // 
            // autoQuery
            // 
            this.autoQuery.AutoSize = true;
            this.autoQuery.Location = new System.Drawing.Point(676, 60);
            this.autoQuery.Name = "autoQuery";
            this.autoQuery.Size = new System.Drawing.Size(208, 17);
            this.autoQuery.TabIndex = 8;
            this.autoQuery.Text = "Automatically Query Every                  s";
            this.autoQuery.UseVisualStyleBackColor = true;
            this.autoQuery.CheckedChanged += new System.EventHandler(this.AutoQueryCheckedChanged);
            // 
            // queryIntervalText
            // 
            this.queryIntervalText.Location = new System.Drawing.Point(824, 58);
            this.queryIntervalText.Name = "queryIntervalText";
            this.queryIntervalText.Size = new System.Drawing.Size(40, 20);
            this.queryIntervalText.TabIndex = 9;
            this.queryIntervalText.Text = "7";
            this.queryIntervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.queryIntervalText.Validated += new System.EventHandler(this.QueryIntervalTextValidated);
            this.queryIntervalText.Validating += new System.ComponentModel.CancelEventHandler(this.QueryIntervalTextValidating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Train:";
            // 
            // trainBox
            // 
            this.trainBox.Location = new System.Drawing.Point(288, 40);
            this.trainBox.Name = "trainBox";
            this.trainBox.Size = new System.Drawing.Size(63, 20);
            this.trainBox.TabIndex = 11;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 809);
            this.Controls.Add(this.trainBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.queryIntervalText);
            this.Controls.Add(this.autoQuery);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.webBrowser);
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bot 12306";
            this.Load += new System.EventHandler(this.MainFrameLoad);
            this.Shown += new System.EventHandler(this.MainFrameShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fromBox;
        private System.Windows.Forms.ComboBox toBox;
        private System.Windows.Forms.CheckBox autoQuery;
        private System.Windows.Forms.TextBox queryIntervalText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox trainBox;

    }
}

