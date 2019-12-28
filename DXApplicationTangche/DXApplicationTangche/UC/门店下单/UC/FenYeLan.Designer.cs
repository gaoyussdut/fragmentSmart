namespace mendian
{
    partial class FenYeLan
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.shangye = new DevExpress.XtraEditors.SimpleButton();
            this.xiaye = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(129, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "1";
            // 
            // shangye
            // 
            this.shangye.Location = new System.Drawing.Point(170, 2);
            this.shangye.Name = "shangye";
            this.shangye.Size = new System.Drawing.Size(90, 30);
            this.shangye.TabIndex = 1;
            this.shangye.Text = "上一页";
            // 
            // xiaye
            // 
            this.xiaye.Location = new System.Drawing.Point(284, 2);
            this.xiaye.Name = "xiaye";
            this.xiaye.Size = new System.Drawing.Size(90, 30);
            this.xiaye.TabIndex = 2;
            this.xiaye.Text = "下一页";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前页数";
            // 
            // FenYeLan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xiaye);
            this.Controls.Add(this.shangye);
            this.Controls.Add(this.label1);
            this.Name = "FenYeLan";
            this.Size = new System.Drawing.Size(453, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.SimpleButton shangye;
        public DevExpress.XtraEditors.SimpleButton xiaye;
    }
}
