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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			sentenceList.Add(radioButton_want_some);
			sentenceList.Add(radioButton_mom);
			sentenceList.Add(radioButton_the_moment);
			sentenceList.Add(radioButton_professor);
			imgList.Add(radioButton_just_do_it);
			imgList.Add(radioButton_evil_patrick);
			imgList.Add(radioButton_excuse_me);
			imgList.Add(radioButton_doge);

			foreach(RadioButton i in sentenceList)
			{
				i.CheckedChanged += (s, e) => label_meme.Text = ((RadioButton)s).Text;
			}

			//addSentence("Lamp!!!");
			myConsole.script.Globals["addSentence"] = (Action<string>)(addSentence);
		}

		Random rand = new Random();
		Form2 myConsole = new Form2();
		List<RadioButton> sentenceList = new List<RadioButton>();
		List<RadioButton> imgList = new List<RadioButton>();

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if(keyData == (Keys.Control | Keys.Oemtilde))
			{
				myConsole.Show();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void addSentence(string str)
		{
			RadioButton senten = new RadioButton();
			senten.Text = str;
			senten.Font = new Font("Microsoft JhengHei", 9, FontStyle.Bold);
			sentenceList.Add(senten);
			senten.CheckedChanged += (s, e) => label_meme.Text = ((RadioButton)s).Text;
			tableLayoutPanel_sentence.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			tableLayoutPanel_sentence.Controls.Add(senten, 1, tableLayoutPanel_sentence.RowCount);
		}

		private void radioButton_just_do_it_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox_meme.Image = imageList_meme.Images["just_do_it"];
		}

		private void radioButton_evil_patrick_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox_meme.Image = imageList_meme.Images["evil_patrick"];
		}

		private void radioButton_excuse_me_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox_meme.Image = imageList_meme.Images["excuse_me_wtf"];
		}

		private void radioButton_doge_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox_meme.Image = imageList_meme.Images["doge"];
		}

		private void radioButton_Bold_CheckedChanged(object sender, EventArgs e)
		{
			label_meme.Font = new Font(label_meme.Font, FontStyle.Bold);
		}

		private void radioButton_Regular_CheckedChanged(object sender, EventArgs e)
		{

			label_meme.Font = new Font(label_meme.Font, FontStyle.Regular);
		}

		private void radioButton_Italic_CheckedChanged(object sender, EventArgs e)
		{

			label_meme.Font = new Font(label_meme.Font, FontStyle.Italic);
		}

		private void radioButton_Underline_CheckedChanged(object sender, EventArgs e)
		{

			label_meme.Font = new Font(label_meme.Font, FontStyle.Underline);
		}

		private void button_size_up_Click(object sender, EventArgs e)
		{
			label_meme.Font = new Font(label_meme.Font.FontFamily, label_meme.Font.Size + 1);
		}

		private void button_size_down_Click(object sender, EventArgs e)
		{
			label_meme.Font = new Font(label_meme.Font.FontFamily, label_meme.Font.Size - 1 <= 1 ? 1 : label_meme.Font.Size - 1);
		}

		private void button_random_Click(object sender, EventArgs e)
		{
			int num = rand.Next(imgList.Count);
			imgList[num].PerformClick();
			imgList[num].Checked = true;

			num = rand.Next(sentenceList.Count);
			sentenceList[num].PerformClick();
			sentenceList[num].Checked = true;
		}
	}
}
