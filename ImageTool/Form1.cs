using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class Form1 : Form
    {
        Image finalImage;

        public Form1()
        {
            InitializeComponent();
            this.openFileDialogImages.Filter = "PNG Images *.PNG;*.png)|*.PNG;*.png";
            this.openFileDialogImages.Multiselect = true;
            this.openFileDialogImages.Title = "Image Browser";
            this.btnOpenFiles.Click += new EventHandler(this.BtnOpenFiles_Click);
            this.btnSaveImages.Click += new EventHandler(this.BtnSaveImages_Click);
        }

        private void BtnSaveImages_Click(object sender, EventArgs e)
        {            
            try
            {
                if (finalImage.Height == 0 || finalImage.Width == 0)
                    return;

                saveFileDialogImages.ShowDialog();
                if (saveFileDialogImages.FileName == "")
                    return;

                finalImage.Save(saveFileDialogImages.FileName, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void BtnOpenFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr =  this.openFileDialogImages.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int finalWidth = 0;
                int finalHeight = 0;
                List<string> fileArray = new List<string>();

                if (this.cbTestMode.Checked == true)
                {
                    Image newImage = new Bitmap(100, 1000);
                    Graphics g = Graphics.FromImage(newImage);
                    int count = 0;
                    foreach (String file in openFileDialogImages.FileNames)
                    {
                        try
                        {
                            //List all files
                            this.textFiles.Text += file + ", ";

                            
                            Image loadedImage = Image.FromFile(file, true);
                            int w = (100 - loadedImage.Width) / 2;
                            int h = (100 - loadedImage.Height) / 2;
                            g.DrawImage(loadedImage, new Point(w, h));



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Load images error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        count++;
                    }
                    this.flowLayoutPanelImages.Controls.Clear();
                    PictureBox p = new PictureBox();
                    p.Height = newImage.Height;
                    p.Width = newImage.Width;
                    p.Image = newImage;
                    this.flowLayoutPanelImages.Controls.Add(p);

                    return;
                }
                else if (this.cbCutImage.Checked == true)
                {
                    int frameWidth = 0;
                    int frameHeight = 0;
                    try
                    {
                        frameWidth = Int32.Parse(this.tbCutWidth.Text);
                        frameHeight = Int32.Parse(this.tbCutHeight.Text);
                        foreach (String file in openFileDialogImages.FileNames)
                        {
                                this.textFiles.Text += file + ", ";
                                fileArray.Add(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Frame size error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //Sort the list
                    fileArray = fileArray.OrderBy(q => q).ToList();

                    //create bitmap
                    finalWidth = frameWidth;
                    finalHeight = frameHeight * fileArray.Count();
                    finalImage = new Bitmap(finalWidth, finalHeight);
                    Graphics g = Graphics.FromImage(finalImage);

                    int firstHeight = 0;
                    int firstWidth = 0;
                    try
                    {
                        Image loadedImage = Image.FromFile(fileArray[0]);
                        firstHeight = (frameHeight - loadedImage.Height)/2;
                        firstWidth = (frameWidth - loadedImage.Width) / 2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Load images error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (firstHeight > 0 || firstWidth > 0)
                    {
                        MessageBox.Show("Cut image error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                        

                    this.textLog.Text = "";
                    int lastHeight = firstHeight;
                    foreach (string f in fileArray)
                    {
                        this.textLog.Text += f + "\n";
                        try
                        {
                            Image loadedImage = Image.FromFile(f);
                            g.DrawImage(loadedImage, new Point(firstWidth, lastHeight));
                            lastHeight += frameHeight;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Load images error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                }
                else
                {
                    foreach (String file in openFileDialogImages.FileNames)
                    {
                        try
                        {
                            //List all files
                            this.textFiles.Text += file + ", ";

                            //Calculate total width and height
                            Image loadedImage = Image.FromFile(file, true);
                            if (loadedImage.Width > finalWidth)
                                finalWidth = loadedImage.Width;
                            finalHeight += loadedImage.Height;
                            fileArray.Add(file);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Load images error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    //Sort the list
                    fileArray = fileArray.OrderBy(q => q).ToList();

                    //Create bitmap
                    finalImage = new Bitmap(finalWidth, finalHeight);
                    Graphics g = Graphics.FromImage(finalImage);

                    this.textLog.Text = "";
                    int lastHeight = 0;
                    foreach (string f in fileArray)
                    {
                        this.textLog.Text += f + "\n";
                        try
                        {
                            Image loadedImage = Image.FromFile(f, true);
                            g.DrawImage(loadedImage, new Point(0, lastHeight));
                            lastHeight += loadedImage.Height;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Load images error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                this.flowLayoutPanelImages.Controls.Clear();
                PictureBox pb = new PictureBox();
                pb.Height = this.finalImage.Height;
                pb.Width = this.finalImage.Width;
                pb.Image = this.finalImage;
                this.flowLayoutPanelImages.Controls.Add(pb);

                this.textLog.Text += "W: " + finalWidth.ToString() + "\n";
                this.textLog.Text += "H: " + finalHeight.ToString() + "\n";
            }
        }
    }
}
