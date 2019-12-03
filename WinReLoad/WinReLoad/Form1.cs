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
        string modName = "";
        string computerDrive;
        int i;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                computerDrive = drive.Name;
                FileInfo FileCheck = new FileInfo(computerDrive + @"\Internal shared storage\Android\data\com.cloudheadgames.pistolwhip\files\mods");
                if (FileCheck.FullName != modName)
                {
                    Application.Exit();
                }
            };
            
        }
    }







}
