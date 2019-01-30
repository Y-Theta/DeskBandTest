using System.Windows.Forms;

namespace BandTest_WinForm_ {
    partial class BandControlT {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Components
        private Label _label1;
        #endregion

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this._label1 = new Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this._label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._label1.ForeColor = System.Drawing.Color.White;
            this._label1.Location = new System.Drawing.Point(0, 0);
            this._label1.Name = "label1";
            this._label1.Size = new System.Drawing.Size(120, 40);
            this._label1.TabIndex = 0;
            this._label1.Text = "Hello";
            this._label1.AutoEllipsis = true;
            this._label1.AutoSize = false;
            this._label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BandControlT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this._label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(200, 40);
            this.MinimumSize = new System.Drawing.Size(200, 30);
            this.Size = new System.Drawing.Size(120, 30);
            this.Name = "BandControlT";
            this.ResumeLayout(false);
        }
        #endregion

        #region Dispose
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
