namespace DXApplicationTangche.UC
{
    partial class Frm工艺流程管理
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
            this.treeList工艺流程一览 = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNODE_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEMP_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colINDEX = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEMP_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList工艺流程一览)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList工艺流程一览
            // 
            this.treeList工艺流程一览.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colINDEX,
            this.colNODE_NAME,
            this.colEMP_ID,
            this.colEMP_NAME});
            this.treeList工艺流程一览.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList工艺流程一览.Location = new System.Drawing.Point(0, 0);
            this.treeList工艺流程一览.Name = "treeList工艺流程一览";
            this.treeList工艺流程一览.ParentFieldName = "PID";
            this.treeList工艺流程一览.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEdit1});
            this.treeList工艺流程一览.Size = new System.Drawing.Size(1209, 486);
            this.treeList工艺流程一览.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colNODE_NAME
            // 
            this.colNODE_NAME.Caption = "流程节点名称";
            this.colNODE_NAME.FieldName = "NODE_NAME";
            this.colNODE_NAME.Name = "colNODE_NAME";
            this.colNODE_NAME.Visible = true;
            this.colNODE_NAME.VisibleIndex = 1;
            // 
            // colEMP_ID
            // 
            this.colEMP_ID.Caption = "EMP_ID";
            this.colEMP_ID.FieldName = "EMP_ID";
            this.colEMP_ID.Name = "colEMP_ID";
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.PopupView = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colINDEX
            // 
            this.colINDEX.Caption = "顺序";
            this.colINDEX.FieldName = "INDEX";
            this.colINDEX.Name = "colINDEX";
            this.colINDEX.Visible = true;
            this.colINDEX.VisibleIndex = 0;
            // 
            // colEMP_NAME
            // 
            this.colEMP_NAME.Caption = "负责人";
            this.colEMP_NAME.FieldName = "EMP_NAME";
            this.colEMP_NAME.Name = "colEMP_NAME";
            this.colEMP_NAME.Visible = true;
            this.colEMP_NAME.VisibleIndex = 2;
            // 
            // Frm工艺流程管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 486);
            this.Controls.Add(this.treeList工艺流程一览);
            this.Name = "Frm工艺流程管理";
            this.Text = "Frm工艺流程管理";
            ((System.ComponentModel.ISupportInitialize)(this.treeList工艺流程一览)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList工艺流程一览;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colINDEX;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNODE_NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEMP_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEMP_NAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}