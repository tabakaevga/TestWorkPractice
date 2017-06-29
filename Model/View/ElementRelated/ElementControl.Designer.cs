namespace View.ElementRelated
{
    partial class ElementControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ElementTypeCombo = new System.Windows.Forms.ComboBox();
            this.ElementTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(4, 77);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(4, 116);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(34, 13);
            this.ValueLabel.TabIndex = 1;
            this.ValueLabel.Text = "Value";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(7, 93);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(168, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(7, 132);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(167, 20);
            this.ValueTextBox.TabIndex = 3;
            // 
            // ElementTypeCombo
            // 
            this.ElementTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ElementTypeCombo.FormattingEnabled = true;
            this.ElementTypeCombo.Items.AddRange(new object[] {
            "Inductor",
            "Capacitor",
            "Resistor"});
            this.ElementTypeCombo.Location = new System.Drawing.Point(7, 26);
            this.ElementTypeCombo.Name = "ElementTypeCombo";
            this.ElementTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.ElementTypeCombo.TabIndex = 4;
            // 
            // ElementTypeLabel
            // 
            this.ElementTypeLabel.AutoSize = true;
            this.ElementTypeLabel.Location = new System.Drawing.Point(4, 10);
            this.ElementTypeLabel.Name = "ElementTypeLabel";
            this.ElementTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.ElementTypeLabel.TabIndex = 5;
            this.ElementTypeLabel.Text = "Element Type";
            // 
            // ElementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ElementTypeLabel);
            this.Controls.Add(this.ElementTypeCombo);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "ElementsControl";
            this.Size = new System.Drawing.Size(191, 188);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.ComboBox ElementTypeCombo;
        private System.Windows.Forms.Label ElementTypeLabel;
    }
}
