namespace ProducerConsumer
{
    partial class Form1
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
            this.btnConsumer = new System.Windows.Forms.Button();
            this.btnProducer = new System.Windows.Forms.Button();
            this.btnConsumerMR = new System.Windows.Forms.Button();
            this.btnProducerMR = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // btnConsumer
            // 
            this.btnConsumer.Location = new System.Drawing.Point(12, 12);
            this.btnConsumer.Name = "btnConsumer";
            this.btnConsumer.Size = new System.Drawing.Size(102, 23);
            this.btnConsumer.TabIndex = 0;
            this.btnConsumer.Text = "Start Consumer";
            this.btnConsumer.UseVisualStyleBackColor = true;
            this.btnConsumer.Click += new System.EventHandler(this.btnConsumer_Click);
            // 
            // btnProducer
            // 
            this.btnProducer.Location = new System.Drawing.Point(134, 12);
            this.btnProducer.Name = "btnProducer";
            this.btnProducer.Size = new System.Drawing.Size(102, 23);
            this.btnProducer.TabIndex = 1;
            this.btnProducer.Text = "Start Producer";
            this.btnProducer.UseVisualStyleBackColor = true;
            this.btnProducer.Click += new System.EventHandler(this.btnProducer_Click);
            // 
            // btnConsumerMR
            // 
            this.btnConsumerMR.Location = new System.Drawing.Point(12, 98);
            this.btnConsumerMR.Name = "btnConsumerMR";
            this.btnConsumerMR.Size = new System.Drawing.Size(102, 23);
            this.btnConsumerMR.TabIndex = 2;
            this.btnConsumerMR.Text = "Consumer MR";
            this.btnConsumerMR.UseVisualStyleBackColor = true;
            this.btnConsumerMR.Click += new System.EventHandler(this.btnConsumerMR_Click);
            // 
            // btnProducerMR
            // 
            this.btnProducerMR.Location = new System.Drawing.Point(134, 98);
            this.btnProducerMR.Name = "btnProducerMR";
            this.btnProducerMR.Size = new System.Drawing.Size(102, 23);
            this.btnProducerMR.TabIndex = 3;
            this.btnProducerMR.Text = "Producer MR";
            this.btnProducerMR.UseVisualStyleBackColor = true;
            this.btnProducerMR.Click += new System.EventHandler(this.btnProducerMR_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 181);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnProducerMR);
            this.Controls.Add(this.btnConsumerMR);
            this.Controls.Add(this.btnProducer);
            this.Controls.Add(this.btnConsumer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsumer;
        private System.Windows.Forms.Button btnProducer;
        private System.Windows.Forms.Button btnConsumerMR;
        private System.Windows.Forms.Button btnProducerMR;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

