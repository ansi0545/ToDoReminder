namespace ToDoReminder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            blDateAndTime = new Label();
            dateTimePicker = new DateTimePicker();
            lblPriority = new Label();
            comboBoxPriority = new ComboBox();
            lblToDo = new Label();
            txtBoxEnterToDo = new TextBox();
            btnAdd = new Button();
            grpBoxToDo = new GroupBox();
            listViewToDo = new ListView();
            toolStripMenuSaveDataFile = new ToolStripMenuItem();
            toolStripMenuNew = new ToolStripMenuItem();
            toolStripOpenDatafile = new ToolStripMenuItem();
            toolStripSaveDataFile = new ToolStripMenuItem();
            toolStripExit = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStripAbout = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            btnChange = new Button();
            btnDelete = new Button();
            toolTip = new ToolTip(components);
            timer = new System.Windows.Forms.Timer(components);
            lblTime = new Label();
            grpBoxToDo.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // blDateAndTime
            // 
            blDateAndTime.AutoSize = true;
            blDateAndTime.Location = new Point(12, 45);
            blDateAndTime.Name = "blDateAndTime";
            blDateAndTime.Size = new Size(124, 25);
            blDateAndTime.TabIndex = 1;
            blDateAndTime.Text = "Date and time";
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm";
            dateTimePicker.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(189, 39);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(300, 30);
            dateTimePicker.TabIndex = 2;
            toolTip.SetToolTip(dateTimePicker, "Click to open calendar for date, write in the time here.");
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(505, 47);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(68, 25);
            lblPriority.TabIndex = 3;
            lblPriority.Text = "Priority";
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPriority.FormattingEnabled = true;
            comboBoxPriority.Location = new Point(578, 44);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new Size(182, 33);
            comboBoxPriority.TabIndex = 4;
            comboBoxPriority.SelectedIndexChanged += comboBoxPriority_SelectedIndexChanged;
            // 
            // lblToDo
            // 
            lblToDo.AutoSize = true;
            lblToDo.Location = new Point(17, 95);
            lblToDo.Name = "lblToDo";
            lblToDo.Size = new Size(57, 25);
            lblToDo.TabIndex = 5;
            lblToDo.Text = "To do";
            // 
            // txtBoxEnterToDo
            // 
            txtBoxEnterToDo.Location = new Point(92, 92);
            txtBoxEnterToDo.Name = "txtBoxEnterToDo";
            txtBoxEnterToDo.Size = new Size(668, 31);
            txtBoxEnterToDo.TabIndex = 6;
            txtBoxEnterToDo.TextChanged += txtBoxEnterToDo_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(298, 141);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 34);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpBoxToDo
            // 
            grpBoxToDo.Controls.Add(listViewToDo);
            grpBoxToDo.Location = new Point(17, 209);
            grpBoxToDo.Name = "grpBoxToDo";
            grpBoxToDo.Size = new Size(1362, 361);
            grpBoxToDo.TabIndex = 8;
            grpBoxToDo.TabStop = false;
            grpBoxToDo.Text = "To Do";
            // 
            // listViewToDo
            // 
            listViewToDo.FullRowSelect = true;
            listViewToDo.Location = new Point(6, 37);
            listViewToDo.Name = "listViewToDo";
            listViewToDo.Size = new Size(1350, 315);
            listViewToDo.TabIndex = 0;
            listViewToDo.UseCompatibleStateImageBehavior = false;
            listViewToDo.View = View.Details;
            listViewToDo.SelectedIndexChanged += listViewToDo_SelectedIndexChanged;
            // 
            // toolStripMenuSaveDataFile
            // 
            toolStripMenuSaveDataFile.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuNew, toolStripOpenDatafile, toolStripSaveDataFile, toolStripExit });
            toolStripMenuSaveDataFile.Name = "toolStripMenuSaveDataFile";
            toolStripMenuSaveDataFile.Size = new Size(54, 29);
            toolStripMenuSaveDataFile.Text = "File";
            // 
            // toolStripMenuNew
            // 
            toolStripMenuNew.Name = "toolStripMenuNew";
            toolStripMenuNew.ShortcutKeys = Keys.Control | Keys.N;
            toolStripMenuNew.Size = new Size(226, 34);
            toolStripMenuNew.Text = "New";
            toolStripMenuNew.Click += toolStripMenuNew_Click;
            // 
            // toolStripOpenDatafile
            // 
            toolStripOpenDatafile.Name = "toolStripOpenDatafile";
            toolStripOpenDatafile.Size = new Size(226, 34);
            toolStripOpenDatafile.Text = "Open data file";
            toolStripOpenDatafile.Click += toolStripOpenDatafile_Click;
            // 
            // toolStripSaveDataFile
            // 
            toolStripSaveDataFile.Name = "toolStripSaveDataFile";
            toolStripSaveDataFile.Size = new Size(226, 34);
            toolStripSaveDataFile.Text = "Save data file";
            toolStripSaveDataFile.Click += toolStripSaveDataFile_Click;
            // 
            // toolStripExit
            // 
            toolStripExit.Name = "toolStripExit";
            toolStripExit.ShortcutKeys = Keys.Alt | Keys.F4;
            toolStripExit.Size = new Size(226, 34);
            toolStripExit.Text = "Exit";
            toolStripExit.Click += toolStripExit_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripAbout
            // 
            toolStripAbout.Name = "toolStripAbout";
            toolStripAbout.Size = new Size(176, 34);
            toolStripAbout.Text = "About...";
            toolStripAbout.Click += toolStripAbout_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuSaveDataFile, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1391, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnChange
            // 
            btnChange.Enabled = false;
            btnChange.Location = new Point(92, 576);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(177, 34);
            btnChange.TabIndex = 9;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(317, 576);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(172, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Location = new Point(1200, 576);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(80, 25);
            lblTime.TabIndex = 11;
            lblTime.Text = "21:32:27";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 634);
            Controls.Add(btnDelete);
            Controls.Add(btnChange);
            Controls.Add(grpBoxToDo);
            Controls.Add(btnAdd);
            Controls.Add(txtBoxEnterToDo);
            Controls.Add(lblToDo);
            Controls.Add(comboBoxPriority);
            Controls.Add(lblPriority);
            Controls.Add(dateTimePicker);
            Controls.Add(blDateAndTime);
            Controls.Add(lblTime);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "ToDo reminder by Ann-Sofie";
            grpBoxToDo.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label blDateAndTime;
        private DateTimePicker dateTimePicker;
        private Label lblPriority;
        private ComboBox comboBoxPriority;
        private Label lblToDo;
        private TextBox txtBoxEnterToDo;
        private Button btnAdd;
        private GroupBox grpBoxToDo;
        private ToolStripMenuItem toolStripMenuSaveDataFile;
        private ToolStripMenuItem toolStripMenuNew;
        private ToolStripMenuItem toolStripOpenDatafile;
        private ToolStripMenuItem toolStripSaveDataFile;
        private ToolStripMenuItem toolStripExit;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem toolStripAbout;
        private MenuStrip menuStrip1;
        private ListView listViewToDo;
        private Button btnChange;
        private Button btnDelete;
        private ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
        private Label lblTime;
    }
}
