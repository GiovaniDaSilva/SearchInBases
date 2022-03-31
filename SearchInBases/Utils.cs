using MySqlConnector;
using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SearchInBases
{
    public static class Utils
    {
        private static string format_date_name = "dd-MM-yyyy HHmmss";

        public static bool IsNullOrEmpty<T>(List<T> lista)
        {
            if (lista == null) return true;
            if (lista.Count <= 0) return true;
            return false;
        }

        public static bool IsNull<T>(List<T> lista)
        {
            return (lista == null);
        }

        public static string FormatDateTimeToName(DateTime data)
        {
            return data.ToString(format_date_name);
        }


        public static string Encrypt(string text)
        {
            try
            {
                string textToEncrypt = text;
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                Debug.Print(ToReturn);
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Message.MessageException("Falha ao criptografar dados");
            }
        }


        public static string Decrypt(string text)
        {
            try
            {
                string textToDecrypt = text;
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                Log.addErroMessage("Erro ao descriptografar key");
                ErroService.TratarErro(ae);
                return "";
            }
        }

    }
}
