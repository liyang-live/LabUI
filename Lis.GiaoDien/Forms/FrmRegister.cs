using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using newCIS2008.Class;

namespace newCIS2008
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        public string GenerateKeys()
        {
            RSACryptography RSA = new RSACryptography();
            string publicKey, privateKey;

            // Generate RSA key pair
            RSA.GenerateKeys(out publicKey, out privateKey);

            string plainText = "93f99709-ce56-42a9-af7e-1d72c011c2dd";// Guid.NewGuid().ToString();

            // Encrypt
            string encryptedText = RSA.Encrypt(publicKey, plainText);

            // Decrypt
            string decryptedText = RSA.Decrypt(privateKey, encryptedText);
            return plainText + publicKey + privateKey + encryptedText + decryptedText;
            // return "<b>Token:</b> " + Server.HtmlEncode(plainText) + "<br />" + "<b>Public key:</b> " + Server.HtmlEncode(publicKey) + "<br />" + "<b>Private key:</b> " + Server.HtmlEncode(privateKey) + "<br />" + "<b>Encrypted text:</b> " + Server.HtmlEncode(encryptedText) + "<br />" + "<b>Decrypted text:</b> " + Server.HtmlEncode(decryptedText);
        }
        public string GenerateKeys(string key1, string key2, string dtcreate)
        {
            RSACryptography RSA = new RSACryptography();
            string publicKey, privateKey,dtcreates;

            // Generate RSA key pair
            RSA.GenerateKey(out publicKey, out privateKey,out dtcreates);

            string plainText = "93f99709-ce56-42a9-af7e-1d72c011c2dd";// Guid.NewGuid().ToString();

            // Encrypt
            string encryptedText = RSA.Encrypt(publicKey, plainText);

            // Decrypt
            string decryptedText = RSA.Decrypt(privateKey, encryptedText);
            string giaima = RSA.Decrypt(privateKey, encryptedText);
            File.WriteAllText(Application.StartupPath + "\\PrivateKey.xml", privateKey);
            File.WriteAllText(Application.StartupPath + "\\PublicKey.xml", publicKey);
            File.WriteAllText(Application.StartupPath + "\\DateKey.xml", dtcreates);
            MessageBox.Show("The Key pair created successfully at:\n" + Application.StartupPath);
            return plainText + publicKey + privateKey + encryptedText + decryptedText;
            // return "<b>Token:</b> " + Server.HtmlEncode(plainText) + "<br />" + "<b>Public key:</b> " + Server.HtmlEncode(publicKey) + "<br />" + "<b>Private key:</b> " + Server.HtmlEncode(privateKey) + "<br />" + "<b>Encrypted text:</b> " + Server.HtmlEncode(encryptedText) + "<br />" + "<b>Decrypted text:</b> " + Server.HtmlEncode(decryptedText);
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            GenerateKeys(textBox1.Text, textBox2.Text, dateTimePicker1.Text);
        }
    }
}
