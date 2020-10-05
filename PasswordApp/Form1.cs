using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace PasswordApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Each password is 10 characters long
        public string pass = GenertePassword(10);

        // When click send button, the application send password through email to user
        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                
                client.Credentials = new NetworkCredential("pass.application.test@gmail.com", "78BbsmSfdss");
                MailMessage msg = new MailMessage();
                msg.To.Add(EmailTextBox.Text);
                var eMailValidator = new MailAddress(EmailTextBox.Text);
                msg.From = new MailAddress("pass.application.test@gmail.com");
                msg.Subject = "Password to enrol the app";
                msg.Body = "Your password: " + pass;

                client.Send(msg);
                MessageBox.Show("Password sent successfully!");
            }
            catch (Exception exception)
            {
                if (exception is FormatException || exception is Exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        public static string GenertePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890#*_+@!.";
            StringBuilder result = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                result.Append(valid[rnd.Next(valid.Length)]);
            }
            return result.ToString();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please enter password!");
            }
            else if (PasswordTextBox.Text == pass)
            {
                MessageBox.Show("Welcome, user!");
            }
            else
            {
                MessageBox.Show("Wrong password! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
        }
    }
}
