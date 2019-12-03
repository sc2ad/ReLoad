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
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.X509.Store;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Cms;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Utilities.IO.Pem;



using OpenSsl = Org.BouncyCastle.OpenSsl;


    



namespace WinReLoad
{

    public partial class Form1 : Form
    {
        //VARIABLES
        bool installed = false;

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
            //Find APK and extract it to temp folder and backup folder (skip for now)
            //Check for libmodloader.so
            //if found libmodloader { Go to mod loading form }
            //else allow user to select install ReLoad
            //function for installing reload:
            //run apkifier and put in both lib files + mod folder
            //delete old pistol whip apk from quest and install new with adb
            //check it worked
            //delete temp file
            //move to mod loader form


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
            //Get File Location
            string[] fileLocation = (string[])e.Data.GetData(DataFormats.FileDrop, false);            
            lstFileUpload.Items.Add(fileLocation[0]);

            //Set Up Copy + Paste Vars
            string sourcePath = fileLocation[0];
            string targetPath = @"..\..\Temp\" + "PistolWhip.apk";           
            

            System.IO.File.Copy(sourcePath, targetPath, true);
        }
    }
    






}
