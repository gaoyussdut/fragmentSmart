﻿namespace mendian
{
    partial class UC款式卡片
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
            this.stylecardlabel = new System.Windows.Forms.Label();
            this.stylecardpicbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stylecardpicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // stylecardlabel
            // 
            this.stylecardlabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stylecardlabel.Location = new System.Drawing.Point(4, 222);
            this.stylecardlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stylecardlabel.Name = "stylecardlabel";
            this.stylecardlabel.Size = new System.Drawing.Size(181, 50);
            this.stylecardlabel.TabIndex = 1;
            this.stylecardlabel.Text = "款式";
            // 
            // stylecardpicbox
            // 
            this.stylecardpicbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stylecardpicbox.Image = global::DXApplicationTangche.Properties.Resources.QQ图片20190724112541;
            this.stylecardpicbox.Location = new System.Drawing.Point(0, 0);
            this.stylecardpicbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stylecardpicbox.Name = "stylecardpicbox";
            this.stylecardpicbox.Size = new System.Drawing.Size(187, 219);
            this.stylecardpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stylecardpicbox.TabIndex = 0;
            this.stylecardpicbox.TabStop = false;
            this.stylecardpicbox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UC款式卡片
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stylecardlabel);
            this.Controls.Add(this.stylecardpicbox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC款式卡片";
            this.Size = new System.Drawing.Size(189, 276);
            ((System.ComponentModel.ISupportInitialize)(this.stylecardpicbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label stylecardlabel;
        public System.Windows.Forms.PictureBox stylecardpicbox;
    }
}
