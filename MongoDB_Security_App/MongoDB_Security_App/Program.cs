using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq;

namespace MongoDB_Security_App
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetDatabase("cs-lab7");
            var students = database.GetCollection<BsonDocument>("users");
            var documents = students.Find(new BsonDocument()).ToList();
            List<string> pass = new List<string>();   

            foreach (BsonDocument doc in documents)
            {
                pass.Add(doc.GetElement("password").ToString());
            }
            
            for (int i = 0; i < pass.Count; i++)
            {
                if (pass[i].StartsWith("password="))
                {
                    pass[i] = pass[i].Replace("password=", "");
                }
                var filter = Builders<BsonDocument>.Filter.Eq("_id", i);
                var update = Builders<BsonDocument>.Update.Set("password", Encrypt(pass[i]));
                students.UpdateOne(filter, update);
                
            }
           
            var users = database.GetCollection<BsonDocument>("users");
            var updatedDoc = users.Find(new BsonDocument()).ToList();
            List<string> passEncrypted = new List<string>();
            foreach (BsonDocument doc in updatedDoc)
            {
                passEncrypted.Add(doc.GetElement("password").ToString());
                Console.WriteLine(doc);
            }


            Console.WriteLine("The decrypted passwords: ");
            for (int i = 0; i < passEncrypted.Count; i++)
            {
                //Console.WriteLine(pass[i]);
                if (passEncrypted[i].StartsWith("password="))
                {
                    passEncrypted[i] = passEncrypted[i].Replace("password=", "");
                }
                passEncrypted[i] = Decrypt(passEncrypted[i]);

                Console.WriteLine("Password " + i + ": " + passEncrypted[i]);
            }


        }
        //AES algorithm for encrypt and decrypt data (Advanced Encryption Standart)
        private static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
