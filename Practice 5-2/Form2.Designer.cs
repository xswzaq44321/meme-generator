namespace Practice_5_2
{
	partial class Form2
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
			this.richTextBox_message = new System.Windows.Forms.RichTextBox();
			this.textBox_command = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// richTextBox_message
			// 
			this.richTextBox_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_message.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox_message.Location = new System.Drawing.Point(18, 13);
			this.richTextBox_message.Margin = new System.Windows.Forms.Padding(4);
			this.richTextBox_message.Name = "richTextBox_message";
			this.richTextBox_message.ReadOnly = true;
			this.richTextBox_message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.richTextBox_message.Size = new System.Drawing.Size(688, 480);
			this.richTextBox_message.TabIndex = 0;
			this.richTextBox_message.Text = "";
			// 
			// textBox_command
			// 
			this.textBox_command.AllowDrop = true;
			this.textBox_command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_command.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_command.Location = new System.Drawing.Point(18, 501);
			this.textBox_command.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox_command.Name = "textBox_command";
			this.textBox_command.Size = new System.Drawing.Size(688, 28);
			this.textBox_command.TabIndex = 1;
			this.textBox_command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_command_KeyDown);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 542);
			this.Controls.Add(this.textBox_command);
			this.Controls.Add(this.richTextBox_message);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form2";
			this.Text = "Lua console";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox_message;
		private System.Windows.Forms.TextBox textBox_command;
	}
}