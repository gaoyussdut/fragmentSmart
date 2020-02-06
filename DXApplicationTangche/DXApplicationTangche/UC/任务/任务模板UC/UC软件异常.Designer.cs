namespace DXApplicationTangche.UC.任务.任务模板UC
{
    partial class UC软件异常
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl任务模板 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl任务模板)).BeginInit();
            this.layoutControl任务模板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl任务模板
            // 
            this.layoutControl任务模板.Controls.Add(this.comboBoxEdit1);
            this.layoutControl任务模板.Controls.Add(this.dateTimePicker1);
            this.layoutControl任务模板.Controls.Add(this.textEdit);
            this.layoutControl任务模板.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl任务模板.Location = new System.Drawing.Point(0, 0);
            this.layoutControl任务模板.Name = "layoutControl任务模板";
            this.layoutControl任务模板.Root = this.Root;
            this.layoutControl任务模板.Size = new System.Drawing.Size(758, 445);
            this.layoutControl任务模板.TabIndex = 0;
            this.layoutControl任务模板.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(758, 445);
            this.Root.TextVisible = false;
            // 
            // textEdit
            // 
            this.textEdit.Location = new System.Drawing.Point(84, 12);
            this.textEdit.Name = "textEdit";
            this.textEdit.Size = new System.Drawing.Size(662, 24);
            this.textEdit.StyleController = this.layoutControl任务模板;
            this.textEdit.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(738, 28);
            this.layoutControlItem1.Text = "所属模块";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 85);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(738, 340);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(84, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(662, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateTimePicker1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(738, 29);
            this.layoutControlItem2.Text = "截止日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(84, 69);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "非常高",
            "高",
            "中",
            "低"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(662, 24);
            this.comboBoxEdit1.StyleController = this.layoutControl任务模板;
            this.comboBoxEdit1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.comboBoxEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 57);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(738, 28);
            this.layoutControlItem3.Text = "优先级";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 18);
            // 
            // UC软件异常
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl任务模板);
            this.Name = "UC软件异常";
            this.Size = new System.Drawing.Size(758, 445);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl任务模板)).EndInit();
            this.layoutControl任务模板.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl任务模板;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.TextEdit textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
