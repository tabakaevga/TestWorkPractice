namespace View.CircuitForms
{
    partial class ParallelCircuitEditor
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.AddSubcircuitButton = new System.Windows.Forms.Button();
            this.AddElementButton = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.RemoveComponentButton = new System.Windows.Forms.Button();
            this.ComponentsGroupBox = new System.Windows.Forms.GroupBox();
            this.ComponentsListBox = new System.Windows.Forms.ListBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ComponentsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(12, 381);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 15;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // AddSubcircuitButton
            // 
            this.AddSubcircuitButton.Location = new System.Drawing.Point(12, 320);
            this.AddSubcircuitButton.Name = "AddSubcircuitButton";
            this.AddSubcircuitButton.Size = new System.Drawing.Size(75, 34);
            this.AddSubcircuitButton.TabIndex = 14;
            this.AddSubcircuitButton.Text = "Add Serial Subcircuit";
            this.AddSubcircuitButton.UseVisualStyleBackColor = true;
            this.AddSubcircuitButton.Click += new System.EventHandler(this.AddSubcircuitButton_Click);
            // 
            // AddElementButton
            // 
            this.AddElementButton.Location = new System.Drawing.Point(12, 291);
            this.AddElementButton.Name = "AddElementButton";
            this.AddElementButton.Size = new System.Drawing.Size(75, 23);
            this.AddElementButton.TabIndex = 13;
            this.AddElementButton.Text = "Add Element";
            this.AddElementButton.UseVisualStyleBackColor = true;
            this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(93, 381);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 12;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // RemoveComponentButton
            // 
            this.RemoveComponentButton.Location = new System.Drawing.Point(93, 320);
            this.RemoveComponentButton.Name = "RemoveComponentButton";
            this.RemoveComponentButton.Size = new System.Drawing.Size(75, 34);
            this.RemoveComponentButton.TabIndex = 11;
            this.RemoveComponentButton.Text = "Remove Component";
            this.RemoveComponentButton.UseVisualStyleBackColor = true;
            this.RemoveComponentButton.Click += new System.EventHandler(this.RemoveComponentButton_Click);
            // 
            // ComponentsGroupBox
            // 
            this.ComponentsGroupBox.Controls.Add(this.ComponentsListBox);
            this.ComponentsGroupBox.Location = new System.Drawing.Point(12, 51);
            this.ComponentsGroupBox.Name = "ComponentsGroupBox";
            this.ComponentsGroupBox.Size = new System.Drawing.Size(221, 234);
            this.ComponentsGroupBox.TabIndex = 10;
            this.ComponentsGroupBox.TabStop = false;
            this.ComponentsGroupBox.Text = "Components";
            // 
            // ComponentsListBox
            // 
            this.ComponentsListBox.FormattingEnabled = true;
            this.ComponentsListBox.Location = new System.Drawing.Point(6, 19);
            this.ComponentsListBox.Name = "ComponentsListBox";
            this.ComponentsListBox.Size = new System.Drawing.Size(209, 212);
            this.ComponentsListBox.TabIndex = 0;
            this.ComponentsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ComponentsListBox_MouseDoubleClick);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 16;
            this.NameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 25);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 17;
            // 
            // ParallelCircuitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 412);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.AddSubcircuitButton);
            this.Controls.Add(this.AddElementButton);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.RemoveComponentButton);
            this.Controls.Add(this.ComponentsGroupBox);
            this.Name = "ParallelCircuitEditor";
            this.Text = "ParallelCircuitEditor";
            this.ComponentsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button AddSubcircuitButton;
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button RemoveComponentButton;
        private System.Windows.Forms.GroupBox ComponentsGroupBox;
        private System.Windows.Forms.ListBox ComponentsListBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}