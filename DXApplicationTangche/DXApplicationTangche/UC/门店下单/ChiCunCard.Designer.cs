﻿namespace mendian
{
    partial class ChiCunCard
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
            this.tiaozheng = new System.Windows.Forms.Label();
            this.kehu = new System.Windows.Forms.Label();
            this.chengyi = new System.Windows.Forms.Label();
            this.jian = new System.Windows.Forms.TextBox();
            this.jia = new System.Windows.Forms.TextBox();
            this.biaozhun = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tiaozheng
            // 
            this.tiaozheng.AutoSize = true;
            this.tiaozheng.BackColor = System.Drawing.Color.White;
            this.tiaozheng.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tiaozheng.Location = new System.Drawing.Point(314, 7);
            this.tiaozheng.Name = "tiaozheng";
            this.tiaozheng.Size = new System.Drawing.Size(22, 24);
            this.tiaozheng.TabIndex = 158;
            this.tiaozheng.Text = "0";
            // 
            // kehu
            // 
            this.kehu.AutoSize = true;
            this.kehu.BackColor = System.Drawing.Color.White;
            this.kehu.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kehu.Location = new System.Drawing.Point(226, 7);
            this.kehu.Name = "kehu";
            this.kehu.Size = new System.Drawing.Size(22, 24);
            this.kehu.TabIndex = 157;
            this.kehu.Text = "0";
            // 
            // chengyi
            // 
            this.chengyi.AutoSize = true;
            this.chengyi.BackColor = System.Drawing.Color.White;
            this.chengyi.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chengyi.Location = new System.Drawing.Point(676, 5);
            this.chengyi.Name = "chengyi";
            this.chengyi.Size = new System.Drawing.Size(22, 24);
            this.chengyi.TabIndex = 156;
            this.chengyi.Text = "0";
            // 
            // jian
            // 
            this.jian.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jian.ForeColor = System.Drawing.Color.Red;
            this.jian.Location = new System.Drawing.Point(583, 5);
            this.jian.Name = "jian";
            this.jian.Size = new System.Drawing.Size(54, 26);
            this.jian.TabIndex = 155;
            this.jian.Text = "0";
            this.jian.TextChanged += new System.EventHandler(this.jian_TextChanged);
            this.jian.MouseDown += new System.Windows.Forms.MouseEventHandler(this.jian_MouseDown);
            // 
            // jia
            // 
            this.jia.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jia.ForeColor = System.Drawing.Color.Blue;
            this.jia.Location = new System.Drawing.Point(496, 5);
            this.jia.Name = "jia";
            this.jia.Size = new System.Drawing.Size(54, 26);
            this.jia.TabIndex = 154;
            this.jia.Text = "0";
            this.jia.TextChanged += new System.EventHandler(this.jia_TextChanged);
            this.jia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.jia_MouseDown);
            // 
            // biaozhun
            // 
            this.biaozhun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.biaozhun.Location = new System.Drawing.Point(399, 5);
            this.biaozhun.Name = "biaozhun";
            this.biaozhun.Size = new System.Drawing.Size(70, 26);
            this.biaozhun.TabIndex = 153;
            this.biaozhun.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 152;
            this.label1.Text = "·";
            // 
            // ChiCunCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tiaozheng);
            this.Controls.Add(this.kehu);
            this.Controls.Add(this.chengyi);
            this.Controls.Add(this.jian);
            this.Controls.Add(this.jia);
            this.Controls.Add(this.biaozhun);
            this.Controls.Add(this.label1);
            this.Name = "ChiCunCard";
            this.Size = new System.Drawing.Size(751, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label tiaozheng;
        public System.Windows.Forms.Label kehu;
        public System.Windows.Forms.Label chengyi;
        public System.Windows.Forms.TextBox jian;
        public System.Windows.Forms.TextBox jia;
        public System.Windows.Forms.TextBox biaozhun;
        private System.Windows.Forms.Label label1;
    }
}
