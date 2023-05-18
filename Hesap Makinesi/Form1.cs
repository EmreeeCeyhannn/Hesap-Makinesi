using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Emre Ceyhan 21118080034
namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {// İlk başta label5, label6 ve label7'nin içeriğini boşaltır
            InitializeComponent();
            label5.Text = null;
            label6.Text = null;
            label7.Text = null;
        }
        // bu fonksiyon faktöriyel hesaplamaya yarayan fonksiyondur
        int faktr(int a)
        {
            int faktöriyel = 1;
            for (int i = 1; i <= a; i++)
            {
                faktöriyel = faktöriyel * i;
            }
            return faktöriyel;
        }
        // bu fonksiyon Asal sayı kontrolüne yarayan fonksiyondur
        bool Asal_kontrol(int number)
        {
            if (number < 2)
                return false;

            int sqrt = (int)Math.Sqrt(number);

            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextBox1 değeri boş değilse if bloğuna girer
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (int.TryParse(textBox1.Text, out int number))
                {
                    // TextBox1'deki değer bir tam sayıya dönüştürülebiliyorsa yine if bloğuna girer

                    if (number < 13)
                        // TextBox1'deki sayı 13'ten küçükse faktöriyel hesaplar ve sonucu label5'e yazdırır neden 13 sınır çünkü tipi int olduğunda en fazla 12 faktöriyeli hesapalyabiliyo
                        label5.Text = faktr(number).ToString();
                    else
                    {
                        // TextBox1'deki sayı 13 veya daha büyükse hata mesajı gösterir
                        MessageBox.Show("Lütfen çok büyük bir sayı girmeyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = null; // TextBox1'in içeriğini boşaltır
                    }
                }
                else
                {
                    // TextBox1'deki değer bir tam sayıya dönüştürülemezse veya negatif sayı girilmeye çalışırsa hata mesajı gösterir
                    MessageBox.Show("Lütfen sadece 0 veya pozitif bir tam sayı giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = null;// TextBox1'in içeriğini boşaltırır
                }
            }
            else
            { // TextBox1 boş ise label5'in içeriğini boşaltır
                label5.Text = null;
            }

            // TextBox1 değeri boş değilse if bloğuna girer
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (int.TryParse(textBox1.Text, out int number))
                {
                    // TextBox1'deki değer bir tam sayıya dönüştürülebiliyorsa if bloğuna girer

                    if (Asal_kontrol(number))
                        // TextBox1'deki sayı asal ise "EVET" yazdırr
                        label6.Text = "EVET";
                    else
                        // TextBox1'deki sayı asal değilse "HAYIR" yazdırır
                        label6.Text = "HAYIR";
                }
            }
            else
            {// TextBox1 boş ise label6'nın içeriğini boşaltır
                label6.Text = null;
            }
            // TextBox1 değeri boş değilse if bloğuna girer
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // TextBox1'deki değeri bir tam sayıya dönüştürür
                int number = int.Parse(textBox1.Text);
                // number adet elemanı olan bir string dizisi oluşturur
                string[] a = new string[number];
                // 0'dan number-1'e kadar olan sayıları diziye ekleer
                for (int i = 0; i <= number - 1; i++)
                {
                    a[i] = i.ToString();
                }
                // Diziyi '-' karakteri ile birleştirerek label7'ye yazdırır
                label7.Text = string.Join("-", a);
            }
            else
            {// TextBox1 boş ise label7'nin içeriğini boşaltır
                label7.Text = null;
            }
        }
    }
}