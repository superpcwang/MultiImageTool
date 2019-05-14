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
                MessageBox.Show("Save image error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void ErrorMessageBox(string m, Exception ex)
        {
            MessageBox.Show(m + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    foreach (String file in openFileDialogImages.FileNames)
                    {
                        //Testing code
                        try
                        {
                            //List all files
                            Image loadedImage = Image.FromFile(file, true);
                            int x = (loadedImage.Width - 100) / 2;
                            int y = (loadedImage.Height - 100) / 2;
                            g.DrawImage(loadedImage, new Rectangle(0, 0, 100, 100), x, y, 100, 100, GraphicsUnit.Pixel);
                        }
                        catch (Exception ex)
                        {
                            this.ErrorMessageBox("Draw images error: ", ex);
                        }
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

                        //Get file list
                        foreach (String file in openFileDialogImages.FileNames)
                            fileArray.Add(file);
                    }
                    catch (Exception ex)
                    {

                        this.ErrorMessageBox("Process images error: ", ex);
                        return;
                    }


                    //Sort the list
                    fileArray = fileArray.OrderBy(q => q).ToList();

                    //create bitmap
                    finalWidth = frameWidth;
                    finalHeight = frameHeight * fileArray.Count();
                    finalImage = new Bitmap(finalWidth, finalHeight);
                    Graphics g = Graphics.FromImage(finalImage);

                    //Draw new image
                    this.textLog.Text = "";
                    int lastHeight = 0;
                    foreach (string f in fileArray)
                    {
                        this.textLog.Text += f + "\n";
                        try
                        {
                            Image loadedImage = Image.FromFile(f, true);
                            int x = (loadedImage.Width - frameWidth) / 2;
                            int y = (loadedImage.Height - frameHeight) / 2;
                            g.DrawImage(loadedImage,
                                new Rectangle(0, lastHeight, frameWidth, frameHeight),
                                x,
                                y,
                                frameWidth,
                                frameHeight,
                                GraphicsUnit.Pixel
                            );
                            lastHeight += frameHeight;
                        }
                        catch (Exception ex)
                        {
                            this.ErrorMessageBox("Draw images error: ", ex);
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
            }
        }
    }
}
