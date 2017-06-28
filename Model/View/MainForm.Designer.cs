namespace View
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CircuitsGroup = new System.Windows.Forms.GroupBox();
            this.CircuitsList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCircuit = new System.Windows.Forms.Button();
            this.RemoveCircuit = new System.Windows.Forms.Button();
            this.CalcButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DrawButton = new System.Windows.Forms.Button();
            this.CircuitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ZGroupBox = new System.Windows.Forms.GroupBox();
            this.ZGridView = new System.Windows.Forms.DataGridView();
            this.ZColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreqColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CircuitsGroup.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitBindingSource)).BeginInit();
            this.ZGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CircuitsGroup
            // 
            this.CircuitsGroup.Controls.Add(this.CircuitsList);
            this.CircuitsGroup.Location = new System.Drawing.Point(12, 27);
            this.CircuitsGroup.Name = "CircuitsGroup";
            this.CircuitsGroup.Size = new System.Drawing.Size(310, 263);
            this.CircuitsGroup.TabIndex = 0;
            this.CircuitsGroup.TabStop = false;
            this.CircuitsGroup.Text = "Circuits";
            // 
            // CircuitsList
            // 
            this.CircuitsList.FormattingEnabled = true;
            this.CircuitsList.Location = new System.Drawing.Point(6, 19);
            this.CircuitsList.Name = "CircuitsList";
            this.CircuitsList.Size = new System.Drawing.Size(298, 238);
            this.CircuitsList.TabIndex = 0;
            this.CircuitsList.SelectedIndexChanged += new System.EventHandler(this.CircuitsList_SelectedIndexChanged);
            this.CircuitsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CircuitsList_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDropDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // FileDropDown
            // 
            this.FileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.FileDropDown.Image = ((System.Drawing.Image)(resources.GetObject("FileDropDown.Image")));
            this.FileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileDropDown.Name = "FileDropDown";
            this.FileDropDown.Size = new System.Drawing.Size(38, 22);
            this.FileDropDown.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // AddCircuit
            // 
            this.AddCircuit.Location = new System.Drawing.Point(12, 305);
            this.AddCircuit.Name = "AddCircuit";
            this.AddCircuit.Size = new System.Drawing.Size(91, 23);
            this.AddCircuit.TabIndex = 2;
            this.AddCircuit.Text = "Add Circuit";
            this.AddCircuit.UseVisualStyleBackColor = true;
            this.AddCircuit.Click += new System.EventHandler(this.AddCircuit_Click);
            // 
            // RemoveCircuit
            // 
            this.RemoveCircuit.Location = new System.Drawing.Point(109, 305);
            this.RemoveCircuit.Name = "RemoveCircuit";
            this.RemoveCircuit.Size = new System.Drawing.Size(91, 23);
            this.RemoveCircuit.TabIndex = 3;
            this.RemoveCircuit.Text = "Remove Circuit";
            this.RemoveCircuit.UseVisualStyleBackColor = true;
            this.RemoveCircuit.Click += new System.EventHandler(this.RemoveCircuit_Click);
            // 
            // CalcButton
            // 
            this.CalcButton.Location = new System.Drawing.Point(338, 305);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(91, 23);
            this.CalcButton.TabIndex = 4;
            this.CalcButton.Text = "Calc Z";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Schema 1";
            this.saveFileDialog1.Filter = "TW Files| *.tw.";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(206, 305);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(91, 23);
            this.DrawButton.TabIndex = 5;
            this.DrawButton.Text = "Draw Circuit";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ZGroupBox
            // 
            this.ZGroupBox.Controls.Add(this.ZGridView);
            this.ZGroupBox.Location = new System.Drawing.Point(338, 28);
            this.ZGroupBox.Name = "ZGroupBox";
            this.ZGroupBox.Size = new System.Drawing.Size(234, 262);
            this.ZGroupBox.TabIndex = 6;
            this.ZGroupBox.TabStop = false;
            this.ZGroupBox.Text = "Z:";
            // 
            // ZGridView
            // 
            this.ZGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ZGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZColumn,
            this.FreqColumn});
            this.ZGridView.Location = new System.Drawing.Point(6, 18);
            this.ZGridView.Name = "ZGridView";
            this.ZGridView.Size = new System.Drawing.Size(222, 238);
            this.ZGridView.TabIndex = 0;
            // 
            // ZColumn
            // 
            this.ZColumn.HeaderText = "Z";
            this.ZColumn.Name = "ZColumn";
            // 
            // FreqColumn
            // 
            this.FreqColumn.HeaderText = "Frequency";
            this.FreqColumn.Name = "FreqColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 366);
            this.Controls.Add(this.ZGroupBox);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.RemoveCircuit);
            this.Controls.Add(this.AddCircuit);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CircuitsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "TestWorkRLC";
            this.CircuitsGroup.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitBindingSource)).EndInit();
            this.ZGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox CircuitsGroup;
        private System.Windows.Forms.ListBox CircuitsList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton FileDropDown;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button AddCircuit;
        private System.Windows.Forms.Button RemoveCircuit;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.BindingSource CircuitBindingSource;
        private System.Windows.Forms.GroupBox ZGroupBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreqColumn;
        private System.Windows.Forms.DataGridView ZGridView;
    }
}

