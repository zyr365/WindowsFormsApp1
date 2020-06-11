namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Cam1ReconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.Cam2ReconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.labelCamera1Status = new System.Windows.Forms.Label();
            this.labelCamera2Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(539, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 288);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Cam1ReconnectTimer
            // 
            this.Cam1ReconnectTimer.Enabled = true;
            this.Cam1ReconnectTimer.Interval = 3000;
            this.Cam1ReconnectTimer.Tick += new System.EventHandler(this.Cam1ReconnectTimer_Tick);
            // 
            // Cam2ReconnectTimer
            // 
            this.Cam2ReconnectTimer.Enabled = true;
            this.Cam2ReconnectTimer.Interval = 3000;
            this.Cam2ReconnectTimer.Tick += new System.EventHandler(this.Cam2ReconnectTimer_Tick);
            // 
            // labelCamera1Status
            // 
            this.labelCamera1Status.AutoSize = true;
            this.labelCamera1Status.Location = new System.Drawing.Point(212, 129);
            this.labelCamera1Status.Name = "labelCamera1Status";
            this.labelCamera1Status.Size = new System.Drawing.Size(113, 12);
            this.labelCamera1Status.TabIndex = 2;
            this.labelCamera1Status.Text = "labelCamera1Status";
            // 
            // labelCamera2Status
            // 
            this.labelCamera2Status.AutoSize = true;
            this.labelCamera2Status.Location = new System.Drawing.Point(716, 129);
            this.labelCamera2Status.Name = "labelCamera2Status";
            this.labelCamera2Status.Size = new System.Drawing.Size(113, 12);
            this.labelCamera2Status.TabIndex = 3;
            this.labelCamera2Status.Text = "labelCamera2Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 320);
            this.Controls.Add(this.labelCamera2Status);
            this.Controls.Add(this.labelCamera1Status);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频预览";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer Cam1ReconnectTimer;
        private System.Windows.Forms.Timer Cam2ReconnectTimer;
        private System.Windows.Forms.Label labelCamera1Status;
        private System.Windows.Forms.Label labelCamera2Status;
    }
}

