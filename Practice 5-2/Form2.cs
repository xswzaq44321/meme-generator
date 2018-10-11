using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoonSharp.Interpreter;

namespace Practice_5_2
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			ActiveControl = textBox_command;
			script.Options.DebugPrint = s => richTextBox_message.AppendText(s + "\r\n");
			richTextBox_message.AppendText("> ");

			script.Globals["clear"] = (Action)(() =>
			{
				richTextBox_message.Text = "";
			});
		}

		public Script script = new Script();
		List<string> prevCommands = new List<string>();
		int prevCommandsIter = 0;

		private void textBox_command_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox me = (TextBox)sender;
			if(e.KeyCode == Keys.Enter)
			{
				if(me.Text != "")
				{
					prevCommands.Add(me.Text);
					prevCommandsIter = prevCommands.Count - 1;
				}
				richTextBox_message.AppendText(me.Text + "\r\n");
				DynValue res = new DynValue();
				try
				{
					res = script.DoString(me.Text);
				}
				catch(Exception err)
				{
					richTextBox_message.SelectionColor = Color.Red;
					richTextBox_message.AppendText("\r\nError: " + err.Message + "\r\n\r\n");
				}
				richTextBox_message.AppendText("> ");
				richTextBox_message.ScrollToCaret();
				me.Text = "";
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (prevCommands.Count == 0)
					return;
				me.Text = prevCommands[prevCommandsIter == 0 ? 0 : prevCommandsIter--];
				textBox_command.SelectionStart = textBox_command.TextLength;
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (prevCommands.Count == 0)
					return;
				me.Text = prevCommandsIter == prevCommands.Count - 1 ? "" : prevCommands[++prevCommandsIter];
				textBox_command.SelectionStart = textBox_command.TextLength;
			}
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}
	}
}
