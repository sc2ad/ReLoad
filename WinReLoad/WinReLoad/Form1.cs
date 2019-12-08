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
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Emulamer.Utils;
using System.Net;




namespace WinReLoad
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.lstFileUpload.DragDrop += new
            System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.lstFileUpload.DragEnter += new
            System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
        //Animation Stuff For Drag + Drop
        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        //Drag + Drop
        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //Clear Text
            lstFileUpload.Items.Clear();

            //Create Temp Folder
            if (!Directory.Exists("Temp")) { 
                Directory.CreateDirectory("Temp");                
            };

            //Create Backup Folder
            if (!Directory.Exists("Backup")) { Directory.CreateDirectory("Backup"); };

            //Install Mod Loader Files
            if (Directory.Exists("Temp"))
            {
                if (!File.Exists(@"Temp/libmain.so") & !File.Exists(@"Temp/modloader.so"))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile("https://github.com/sc2ad/pistol-whip-hook/releases/download/v1.0.0/libmodloader.so", "Temp/libmodloader.so");
                        client.DownloadFile("https://github.com/sc2ad/pistol-whip-hook/releases/download/v1.0.0/libmain.so", "Temp/libmain.so");
                    }
                }
            }
            else
            {
                lstFileUpload.Items.Add("Temp folder doesn't exist..");
            };

            //Get File Location
            string[] fileLocation = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                //Set Up Copy + Paste Vars
                string sourcePath = fileLocation[0];
                string targetPath = @"Temp/PistolWhip.apk";
                string targetPathb = @"Backup/PistolWhip.apk";

                //Copy APK
                lstFileUpload.Items.Add("Creating temp apk..");
                System.IO.File.Copy(sourcePath, targetPath, true);
                System.IO.File.Copy(sourcePath, targetPathb, true);

            if (File.Exists(@"Temp/libmain.so") & File.Exists(@"Temp/libmodloader.so") & File.Exists("Temp/PistolWhip.apk"))
            {

                //Use Apkifier (Thanks Emulamer!) to put in mod files

                Apkifier Apkify = new Apkifier(@"Temp/PistolWhip.apk");

                if (!Apkify.FileExists(@"lib\arm64-v8a" + "libmodloader.so"))
                {
                    lstFileUpload.Items.Add("Working...");
                    Apkify.Write(@"Temp/libmodloader.so", Path.Combine(@"lib/arm64-v8a/", "libmodloader.so"), true, true);
                    Apkify.Write(@"Temp/libmain.so", @"lib/arm64-v8a/libmain.so", true, true);
                    Apkify.Sign();
                    if (Apkify.FileExists(@"lib/arm64-v8a/libmodloader.so")) { lstFileUpload.Items.Add("Tasks Completed!"); } else { lstFileUpload.Items.Add("Oops! Something has gone wrong.."); }; ;
                }
                else
                {
                    lstFileUpload.Items.Add("Already installed.");
                }


            } else
            {
                lstFileUpload.Items.Add("Oops, not all necessary files were copied or downloaded");
            }

            File.Copy(@"Temp/PistolWhip.APK", fileLocation[0]);


        }
    }
    

   




}









