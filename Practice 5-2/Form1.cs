﻿using System;
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
			imgSelectList.Add(radioButton_just_do_it);
			imgSelectList.Add(radioButton_evil_patrick);
			imgSelectList.Add(radioButton_excuse_me);
			imgSelectList.Add(radioButton_doge);

			int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
			tableLayoutPanel_sentence.Padding = new Padding(0, 0, vertScrollWidth, 0);
			tableLayoutPanel_img.Padding = new Padding(0, 0, vertScrollWidth, 0);

			foreach(RadioButton i in sentenceList)
			{
				i.CheckedChanged += (s, e) => label_meme.Text = ((RadioButton)s).Text;
			}
			foreach(RadioButton i in imgSelectList)
			{
				i.CheckedChanged += (s, e) => pictureBox_meme.Image = (Image)Resource.ResourceManager.GetObject(((RadioButton)s).Text);
			}
			
			myConsole.script.Globals["addSentence"] = (Action<string>)(addSentence);
			myConsole.script.Globals["addImg"] = (Action<string, string>)(addImage);
		}

		Random rand = new Random();
		Form2 myConsole = new Form2();
		List<Image> imgList = new List<Image>();
		List<RadioButton> sentenceList = new List<RadioButton>();
		List<RadioButton> imgSelectList = new List<RadioButton>();

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
			senten.AutoSize = true;
			sentenceList.Add(senten);
			senten.CheckedChanged += (s, e) => label_meme.Text = ((RadioButton)s).Text;
			tableLayoutPanel_sentence.RowCount++;
			tableLayoutPanel_sentence.Controls.Add(senten, 1, tableLayoutPanel_sentence.RowCount);
		}

		private void addImage(string path, string name)
		{
			Bitmap image = new Bitmap(path);
			RadioButton img = new RadioButton();
			img.Text = name;
			img.Font = new Font("Microsoft JhengHei", 9, FontStyle.Bold);
			img.AutoSize = true;
			imgSelectList.Add(img);
			img.CheckedChanged += (s, e) => pictureBox_meme.Image = image;
			tableLayoutPanel_img.RowCount++;
			tableLayoutPanel_img.Controls.Add(img, 1, tableLayoutPanel_img.RowCount);
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
			label_meme.Font = new Font(label_meme.Font.FontFamily, label_meme.Font.Size + 1, label_meme.Font.Style);
		}

		private void button_size_down_Click(object sender, EventArgs e)
		{
			label_meme.Font = new Font(label_meme.Font.FontFamily, label_meme.Font.Size - 1 <= 1 ? 1 : label_meme.Font.Size - 1, label_meme.Font.Style);
		}

		private void button_random_Click(object sender, EventArgs e)
		{
			int num = rand.Next(imgSelectList.Count);
			imgSelectList[num].PerformClick();
			imgSelectList[num].Checked = true;

			num = rand.Next(sentenceList.Count);
			sentenceList[num].PerformClick();
			sentenceList[num].Checked = true;
		}

		private void button_export_Click(object sender, EventArgs e)
		{
			Image img = pictureBox_meme.Image;
			float scaleHeight = (float)pictureBox_meme.Height / (float)img.Height;
			float scaleWidth = (float)pictureBox_meme.Width / (float)img.Width;
			float scale = Math.Min(scaleHeight, scaleWidth);
			img = new Bitmap(img, (int)(img.Width * scale), (int)(img.Height * scale));
			SizeF sentSize = label_meme.CreateGraphics().MeasureString(label_meme.Text, label_meme.Font);
			SizeF imgSize = img.Size;
			Padding sentPadding = new Padding(0, 20, 0, 20);

			Bitmap canvas = new Bitmap((int)Math.Max(imgSize.Width, sentSize.Width + sentPadding.Left + sentPadding.Right), (int)(imgSize.Height + sentSize.Height + sentPadding.Top + sentPadding.Bottom));
			Graphics graphic = Graphics.FromImage(canvas);
			graphic.Clear(Color.White);
			graphic.DrawString(label_meme.Text, label_meme.Font, Brushes.Black, (canvas.Width - (sentPadding.Left + sentSize.Width + sentPadding.Right)) / 2 + sentPadding.Left, sentPadding.Top);
			graphic.DrawImage(img, (canvas.Width - img.Width) / 2, sentPadding.Top + sentSize.Height + sentPadding.Bottom);

			saveFileDialog1.ShowDialog();
			if(saveFileDialog1.FileName != "")
			{
				System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
				switch (saveFileDialog1.FilterIndex)
				{
					case 1: // jpeg
						canvas.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
						break;
					case 2: // bmp
						canvas.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
						break;
					case 3: // gif
						canvas.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
						break;
					case 4: // png
						canvas.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
						break;
				}
				fs.Close();
			}
		}
	}
}
