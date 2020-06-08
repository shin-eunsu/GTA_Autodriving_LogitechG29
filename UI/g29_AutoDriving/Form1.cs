using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace g29_AutoDriving
{
    public partial class Form1 : Form
    {
        int wheelTarget, wheelCurrent;
        bool direction = false; //true : right(constant(-))

        string wheelValue = "0"; //center value
        string brakeValue = "32767"; //nonoperating value
        string accValue = "32767"; //nonoperating value

        string dt;
        string homePath = "C:/GTA_DATA/data_raw";
        string savePath, imgSavePath, imgName;

        //g29 ConstantForce
        //int[] ConstantForce = new int[11] { 0, 18, 20, 25, 30, 35, 40, 45, 50, 60, 70 };
        //int[] ConstantForce = new int[11] { 0, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90 };
        int[] ConstantForce = new int[11] { 0, 25, 30, 35, 40, 45, 50, 60, 70, 80, 90 };
        int damper = 20;
                

        //Image capture
        System.Drawing.Size gta_size;
        Bitmap bitmap = new Bitmap(800, 600);
        Graphics g;

        bool btn_view_click = false;
        
        public Form1()
        {
            InitializeComponent();

            //Timer Setting
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer_wheelState.Interval = 100;
            timer.Tick += new EventHandler(timer_wheelState_Tick);

            timer_rec.Interval = 20;
            timer_rec.Tick += new EventHandler(timer_rec_Tick);

            timer_view.Interval = 50;
            timer_view.Tick += new EventHandler(timer_view_Tick);

            timer_endtoend.Interval = 100;
            timer_endtoend.Tick += new EventHandler(timer_endtoend_Tick);

            worker_wheelState = new BackgroundWorker();
            worker_wheelState.DoWork += new DoWorkEventHandler(worker_DoWork_wheelState);

            //image capture size
            gta_size.Height = 600;
            gta_size.Width = 800;
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        ///Timer & BackgroundWorker
        private void timer_wheelState_Tick(object sender, EventArgs e)
        {
            worker_wheelState.RunWorkerAsync();
        }

        private void timer_rec_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now.ToString("yyMMdd_HHmmss_fff");

            try
            {
                Bitmap srcImage = new Bitmap(gta_size.Width, gta_size.Height);
                Graphics g = Graphics.FromImage(srcImage);
                g.CopyFromScreen(0, 30, 0, 0, gta_size);
                imgName = dt + ".jpg";
                //image Save
                System.Drawing.Size resize = new System.Drawing.Size(srcImage.Width / 4, srcImage.Height / 4);

                Bitmap resizeImage = new Bitmap(srcImage, resize);
                resizeImage.Save(imgSavePath + "/" + imgName, ImageFormat.Jpeg);
                //srcImage.Save(imgSavePath + "/" + imgName, ImageFormat.Jpeg);

                //update g29 value
                LogitechGSDK.LogiUpdate();
                wheelValue = LogitechGSDK.LogiGetStateCSharp(0).lX.ToString();
                accValue = LogitechGSDK.LogiGetStateCSharp(0).lY.ToString();
                brakeValue = LogitechGSDK.LogiGetStateCSharp(0).lRz.ToString();

                //update txt
                //FileStream fs = File.Create(savePath + "/data_original.txt");
                FileStream fs = new FileStream(savePath + "/data_original.txt", FileMode.Append, FileAccess.Write);
                byte[] info = new UTF8Encoding(true).GetBytes("\r\n" + dt + "\t" + accValue + "\t" + brakeValue + "\t" + wheelValue + "\t" + imgName);
                //Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();

                //pictureBox1.Image = resizeImage;
            }
            catch (Exception err)
            {
                MessageBox.Show("timer_rec: " + err.Message);
            }
        }

        private void timer_view_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap srcImage = new Bitmap(gta_size.Width, gta_size.Height);
                Graphics g = Graphics.FromImage(srcImage);
                g.CopyFromScreen(0, 30, 0, 0, gta_size);
                System.Drawing.Size resize = new System.Drawing.Size(srcImage.Width / 4, srcImage.Height / 4);
                Bitmap resizeImage = new Bitmap(srcImage, resize);

                pictureBox1.Size = new Size(800, 600);

                pictureBox1.Image = srcImage;
            }
            catch(Exception err)
            {
                MessageBox.Show("timer_view: " + err.Message);
            }
        }

        private void timer_endtoend_Tick(object sender, EventArgs e)
        {
            string dataPath = "D:/GTA_DATA1/proc_data/data.txt";
            try
            {
                Bitmap srcImage = new Bitmap(gta_size.Width, gta_size.Height);
                Graphics g = Graphics.FromImage(srcImage);
                g.CopyFromScreen(0, 30, 0, 0, gta_size);
                //image Save
                System.Drawing.Size resize = new System.Drawing.Size(srcImage.Width / 4, srcImage.Height / 4);
                Bitmap resizeImage = new Bitmap(srcImage, resize);
                resizeImage.Save("D:/GTA_DATA1/proc_data/gta.jpg", ImageFormat.Jpeg);

                // 
                //this.Invoke(new MethodInvoker(delegate ()
                //{
                //    txt_wheelTarget.Text = File.ReadAllText("D:/GTA_DATA1/proc_data/data_original.txt");
                //}));
                FileStream ReadData = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(ReadData);
                txt_wheelTarget.Text = sr.ReadLine();

                //update g29
                try
                {
                    wheelTarget = Convert.ToInt32(txt_wheelTarget.Text);
                }
                catch
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        txt_wheelTarget.Text = "0";

                    }));
                }

                LogitechGSDK.LogiSteeringInitialize(false);
                LogitechGSDK.LogiUpdate();

                wheelCurrent = Convert.ToInt32(txt_wheel.Text);
                txt_wheel.Text = LogitechGSDK.LogiGetStateCSharp(0).lX.ToString();
                txt_acc.Text = LogitechGSDK.LogiGetStateCSharp(0).lY.ToString();
                txt_brake.Text = LogitechGSDK.LogiGetStateCSharp(0).lRz.ToString();
                txt_clutch.Text = LogitechGSDK.LogiGetStateCSharp(0).rglSlider[0].ToString();


                if (wheelTarget > wheelCurrent)
                    direction = true;
                else
                    direction = false;

                if (Math.Abs(wheelCurrent - wheelTarget) <= 300)
                {
                    if (direction)
                    {
                        if (Math.Abs(wheelCurrent - wheelTarget) <= 100)
                        {
                            //LogitechGSDK.LogiStopConstantForce(0);
                            LogitechGSDK.LogiPlayDamperForce(0, 100);
                            LogitechGSDK.LogiPlayConstantForce(0, 0);
                            LogitechGSDK.LogiPlayDamperForce(0, damper);
                        }
                    }
                    else
                    {
                        //LogitechGSDK.LogiStopConstantForce(0);
                        LogitechGSDK.LogiPlayDamperForce(0, 100);
                        LogitechGSDK.LogiPlayConstantForce(0, 0);
                        LogitechGSDK.LogiPlayDamperForce(0, damper);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 2000)
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[1]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[1]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 5000)
                {
                    if (direction) //
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[2]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[2]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 10000)
                {
                    if (direction) //
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[3]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[3]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 15000)
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[4]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[4]);
                    }
                }
                else
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[10]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[10]);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("timer4: " + err.Message);
            }
        }

        void worker_DoWork_wheelState(object sender, DoWorkEventArgs e)
        {
            try
            {
                wheelTarget = Convert.ToInt32(txt_wheelTarget.Text);
            }
            catch
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txt_wheelTarget.Text = "0";
                }));
            }

            LogitechGSDK.LogiSteeringInitialize(false);
            LogitechGSDK.LogiUpdate();
            LogitechGSDK.LogiPlayDamperForce(0, 20);

            this.Invoke(new MethodInvoker(delegate ()
            {
                wheelCurrent = Convert.ToInt32(txt_wheel.Text);
                txt_wheel.Text = LogitechGSDK.LogiGetStateCSharp(0).lX.ToString();
                txt_acc.Text = LogitechGSDK.LogiGetStateCSharp(0).lY.ToString();
                txt_brake.Text = LogitechGSDK.LogiGetStateCSharp(0).lRz.ToString();
                txt_clutch.Text = LogitechGSDK.LogiGetStateCSharp(0).rglSlider[0].ToString();

                if (wheelTarget > wheelCurrent)
                    direction = true;
                else
                    direction = false;

                if (Math.Abs(wheelCurrent - wheelTarget) <= 600)
                {
                    if (direction)
                    {
                        if (Math.Abs(wheelCurrent - wheelTarget) <= 200)
                        {
                            LogitechGSDK.LogiStopConstantForce(0);
                            //LogitechGSDK.LogiPlayConstantForce(0, 0);
                        }
                    }
                    else
                    {
                        LogitechGSDK.LogiStopConstantForce(0);
                        //LogitechGSDK.LogiPlayConstantForce(0, 0);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 2000)
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[1]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[1]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 5000)
                {
                    if (direction) //
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[2]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[2]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 10000)
                {
                    if (direction) //
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[3]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[3]);
                    }
                }
                else if (Math.Abs(wheelCurrent - wheelTarget) <= 15000)
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[4]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[4]);
                    }
                }
                else
                {
                    if (direction)
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, -ConstantForce[10]);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlayConstantForce(0, ConstantForce[10]);
                    }
                }
            }));
            //txt_acc.Text = LogitechGSDK.LogiGetStateCSharp(0)
        }

        //Timer & BackgroundWorker end
        ///////////////////////////////////////////////////////////////////////////////////////
        

        ///////////////////////////////////////////////////////////////////////////////////////
        ///button event

        //wheel state
        private void btn_getState_Click(object sender, EventArgs e)
        {
            timer_wheelState.Start();
        }
        private void btn_stop_state_Click(object sender, EventArgs e)
        {
            timer_wheelState.Stop();
        }

        //Rec
        private void btn_rec_Click(object sender, EventArgs e)
        {
            if (btn_rec.Text == "rec")
            {
                LogitechGSDK.LogiSteeringInitialize(false);
                LogitechGSDK.LogiUpdate();

                //save folder path = current time
                savePath = Path.Combine(homePath, DateTime.Now.ToString("yyMMdd_HHmmss"));
                imgSavePath = savePath + "/images";
                Directory.CreateDirectory(savePath);
                Directory.CreateDirectory(imgSavePath);
                //make txt
                FileStream fs = File.Create(savePath + "/data_original.txt");
                byte[] info = new UTF8Encoding(true).GetBytes("Timestamp\tAccelerator\tBrake\tSteering\tImageName");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();

                timer_rec.Start();
                lbl_rec.Text = "Recording";
                btn_rec.Text = "stop";
            }
            else
            {
                timer_rec.Stop();
                btn_rec.Text = "rec";
                lbl_rec.Text = "";
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (btn_view.Text == "view")
            {
                timer_view.Start();
                btn_view_click = true;
                btn_view.Text = "stop";
            }
            else
            {
                timer_view.Stop();
                btn_view_click = false;
                btn_view.Text = "view";
            }
        }

        //Lane Tracking
        private void btn_start_laneTracking_Click(object sender, EventArgs e)
        {

        }

        private void btn_constant_Click(object sender, EventArgs e)
        {
            LogitechGSDK.LogiSteeringInitialize(false);
            LogitechGSDK.LogiUpdate();
            LogitechGSDK.LogiPlayDamperForce(0, 40);
            LogitechGSDK.LogiPlayConstantForce(0, 60);
        }

        private void btn_stop_conatant_Click(object sender, EventArgs e)
        {
            LogitechGSDK.LogiStopConstantForce(0);
            //LogitechGSDK.LogiPlayConstantForce(0, 0);
        }

        private void btn_stop_laneTracking_Click(object sender, EventArgs e)
        {

        }
        
        //end to end
        private void btn_start_endtoend_Click(object sender, EventArgs e)
        {
            timer_endtoend.Start();
        }

        private void btn_stop_endtoend_Click(object sender, EventArgs e)
        {
            timer_endtoend.Stop();
        }
        //button event end
        ///////////////////////////////////////////////////////////////////////////////////////        

    }
}