namespace View
{
    partial class BaseCircuitEditor
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
            this.ComponentsGroupBox = new System.Windows.Forms.GroupBox();
            this.ComponentsListBox = new System.Windows.Forms.ListBox();
            this.AddElementButton = new System.Windows.Forms.Button();
            this.RemoveComponentButton = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ComponentsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComponentsGroupBox
            // 
            this.ComponentsGroupBox.Controls.Add(this.ComponentsListBox);
            this.ComponentsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ComponentsGroupBox.Name = "ComponentsGroupBox";
            this.ComponentsGroupBox.Size = new System.Drawing.Size(221, 234);
            this.ComponentsGroupBox.TabIndex = 0;
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
            // 
            // AddElementButton
            // 
            this.AddElementButton.Location = new System.Drawing.Point(12, 252);
            this.AddElementButton.Name = "AddElementButton";
            this.AddElementButton.Size = new System.Drawing.Size(75, 23);
            this.AddElementButton.TabIndex = 2;
            this.AddElementButton.Text = "Add Element";
            this.AddElementButton.UseVisualStyleBackColor = true;
            this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // RemoveComponentButton
            // 
            this.RemoveComponentButton.Location = new System.Drawing.Point(93, 281);
            this.RemoveComponentButton.Name = "RemoveComponentButton";
            this.RemoveComponentButton.Size = new System.Drawing.Size(75, 34);
            this.RemoveComponentButton.TabIndex = 4;
            this.RemoveComponentButton.Text = "Remove Component";
            this.RemoveComponentButton.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(93, 342);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // BaseCircuitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 377);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.RemoveComponentButton);
            this.Controls.Add(this.AddElementButton);
            this.Controls.Add(this.ComponentsGroupBox);
            this.Name = "BaseCircuitEditor";
            this.Text = "Circuit Designer";
            this.ComponentsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ComponentsGroupBox;
        private System.Windows.Forms.ListBox ComponentsListBox;
        private System.Windows.Forms.Button AddElementButton;
        private System.Windows.Forms.Button RemoveComponentButton;
        private System.Windows.Forms.Button ButtonCancel;
    }
}