using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM2116_ODEV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        CircularArrayTypedQueue donguselkuyruk = new CircularArrayTypedQueue(20);
        PriorityQueue onceliklikuyruk = new PriorityQueue(20);
        Musteri musteri = new Musteri();
        TersPriorityQueue tersonceliklikuyruk = new TersPriorityQueue(20);
        public void MusteriNoveIslemSuresiOlustur()
        {
            
            txtIslemSuresi.Text = musteri.IslemSuresiOlustur().ToString();
            txtMusteriNo.Text = musteri.BenzersizMusteriNoOlustur().ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MusteriNoveIslemSuresiOlustur();
            dgwDaireselKuyruk.RowCount = 20;
            dgwOncelikliKuyruk.RowCount = 20;
            dgwOncelikliDahaAz.RowCount = 20;
            dgwTersOncelikliDahaAz.RowCount = 20;
            dgwTersOncelikliKuyruk.RowCount = 20;
        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();

            musteri.Ad = txtAd.Text;
            musteri.Soyad = txtSoyad.Text;
            musteri.MusteriNo = int.Parse(txtMusteriNo.Text);
            musteri.IslemSuresi = int.Parse(txtIslemSuresi.Text);

            donguselkuyruk.Insert(musteri);
            onceliklikuyruk.Insert(musteri);
            tersonceliklikuyruk.Insert(musteri);
            
            txtAd.Text = txtIslemSuresi.Text = txtMusteriNo.Text = txtSoyad.Text = "";
            MusteriNoveIslemSuresiOlustur();
           
        }

        int dkbs = 0, dk = 0, okbs = 0, ok = 0, tok = 0,tokbs=0;
        int[] DKislemtamamlanmasuresi = new int[20];
        int[] OKislemtamamlanmasuresi = new int[20];
        int[] TOKislemtamamlanmasuresi = new int[20];

        double dkortislemtamamlanmasuresi, okortislemtamamlanmasuresi, tokortislemtamamlanmasuresi;
        private void btnIslemTamamla_Click(object sender, EventArgs e)
        {
            DonguselKuyrukIslemTamamla();
            OncelikliKuyrukIslemTamamla();
            TersOncelikliKuyrukIslemTamamla();
            
        }
        int ondeki = 0;
        private void DonguselKuyrukIslemTamamla()
        {
            dgwDaireselKuyruk.Rows[dk].Cells[0].Value = ((Musteri)donguselkuyruk.Peek()).MusteriNo;
            dgwDaireselKuyruk.Rows[dk].Cells[1].Value = ((Musteri)donguselkuyruk.Peek()).Ad;
            dgwDaireselKuyruk.Rows[dk].Cells[2].Value = ((Musteri)donguselkuyruk.Peek()).Soyad;
            dgwDaireselKuyruk.Rows[dk].Cells[3].Value = ((Musteri)donguselkuyruk.Peek()).IslemSuresi;
            dgwDaireselKuyruk.Update();
            ondeki = ((Musteri)donguselkuyruk.Remove()).IslemSuresi; 
            DKislemtamamlanmasuresi[dk]=(ondeki + dkbs);
            dkbs += ondeki;

            dgwDaireselKuyruk.Rows[dk].Cells[4].Value = DKislemtamamlanmasuresi[dk];
                dkortislemtamamlanmasuresi += (DKislemtamamlanmasuresi[dk] / 20);
                lblDKortistmm.Text = "Döngüsel Kuyruk Ortalama İşlem Tamamlanma Süresi: " + dkortislemtamamlanmasuresi;        
         dk++;
        }
        int[] OKbs = new int[20];
        private void OncelikliKuyrukIslemTamamla()
        {
            dgwOncelikliKuyruk.Rows[ok].Cells[0].Value = ((Musteri)onceliklikuyruk.Peek()).MusteriNo;
            dgwOncelikliKuyruk.Rows[ok].Cells[1].Value = ((Musteri)onceliklikuyruk.Peek()).Ad;
            dgwOncelikliKuyruk.Rows[ok].Cells[2].Value = ((Musteri)onceliklikuyruk.Peek()).Soyad;
            dgwOncelikliKuyruk.Rows[ok].Cells[3].Value = ((Musteri)onceliklikuyruk.Peek()).IslemSuresi;
            dgwOncelikliKuyruk.Update();
            int musno = ((Musteri)onceliklikuyruk.Peek()).MusteriNo;
            int ondeki = ((Musteri)onceliklikuyruk.Remove()).IslemSuresi;
            OKislemtamamlanmasuresi[ok] = (ondeki + okbs);
            OKbs[musno- 1] = (ondeki + okbs);
            okbs += ondeki;
            dgwOncelikliKuyruk.Rows[ok].Cells[4].Value = OKislemtamamlanmasuresi[ok].ToString();
            okortislemtamamlanmasuresi += (OKislemtamamlanmasuresi[ok] / 20);
            lblOKortistmm.Text = "Oncelikli Kuyruk Ortalama İşlem Tamamlanma Süresi: " + okortislemtamamlanmasuresi; 
            ok++;
        }
        int[] TOKbs = new int[20];
       private void TersOncelikliKuyrukIslemTamamla()
        {
            dgwTersOncelikliKuyruk.Rows[tok].Cells[0].Value = ((Musteri)tersonceliklikuyruk.Peek()).MusteriNo;
            dgwTersOncelikliKuyruk.Rows[tok].Cells[1].Value = ((Musteri)tersonceliklikuyruk.Peek()).Ad;
            dgwTersOncelikliKuyruk.Rows[tok].Cells[2].Value = ((Musteri)tersonceliklikuyruk.Peek()).Soyad;
            dgwTersOncelikliKuyruk.Rows[tok].Cells[3].Value = ((Musteri)tersonceliklikuyruk.Peek()).IslemSuresi;
            dgwTersOncelikliKuyruk.Update();
            int musno = ((Musteri)tersonceliklikuyruk.Peek()).MusteriNo;
            int ondeki = ((Musteri)tersonceliklikuyruk.Remove()).IslemSuresi;
            TOKislemtamamlanmasuresi[tok] = (ondeki + tokbs);
            TOKbs[musno - 1] = (ondeki + tokbs);
            tokbs += ondeki;
            dgwTersOncelikliKuyruk.Rows[tok].Cells[4].Value = TOKislemtamamlanmasuresi[tok].ToString();
            tokortislemtamamlanmasuresi += (TOKislemtamamlanmasuresi[tok] / 20);
            lblTOKortistmm.Text = "Ters Oncelikli Kuyruk Ortalama İşlem Tamamlanma Süresi: " + tokortislemtamamlanmasuresi;
            tok++;
        }

       int row = 0, trow = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {


                if (OKbs[i] < DKislemtamamlanmasuresi[i])
                {
                    dgwOncelikliDahaAz.Rows[row].Cells[0].Value = i + 1;
                    dgwOncelikliDahaAz.Rows[row].Cells[1].Value = OKbs[i];
                    row++;
                }
            }
            double fark = dkortislemtamamlanmasuresi - okortislemtamamlanmasuresi;
            
            int yuzde = Convert.ToInt32((fark / dkortislemtamamlanmasuresi) * 100);
            lblOKkazanc.Text = "Döngüsel-Oncelikli Kuyruk Kazanç   :" + fark.ToString() + "     %" + yuzde.ToString();

            
            for (int i = 0; i < 20; i++)
            {


                if (TOKbs[i] < DKislemtamamlanmasuresi[i])
                {
                    dgwTersOncelikliDahaAz.Rows[trow].Cells[0].Value = i + 1;
                    dgwTersOncelikliDahaAz.Rows[trow].Cells[1].Value = TOKbs[i];
                    trow++;
                }
            }
            double tfark = dkortislemtamamlanmasuresi - tokortislemtamamlanmasuresi;
            
            int tyuzde = Convert.ToInt32((tfark / dkortislemtamamlanmasuresi) * 100);

            lblTOKkazanc.Text = "Döngüsel-Ters Oncelikli Kazanç   :" + tfark.ToString() + "     %" + tyuzde.ToString();
            
                          


            
        }
            
    
}
        }
        
    


