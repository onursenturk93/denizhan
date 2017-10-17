using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Resources;

namespace Denizhan
{

    public partial class Form1 : Form
    {

        public Dictionary<string, string> credentials;

        public Form1()
        {
            InitializeComponent();
            XML_VeriOkuma();


        }
        // XmlTextWriter veri = new XmlTextWriter("onur1.xml", Encoding.UTF8);

        public void fonk_xml()
        {



        }


        private void XML_VeriOkuma() // XML VERİ OKUMA İŞLEMİ

        {
            this.credentials = new Dictionary<string, string>();
            XDocument xDoc = XDocument.Load(@"onur1.xml"); 
            XElement rootElement = xDoc.Root; // Xml Dokümanımız okunacak ve daha önce xmlimizde oluşturduğumuzroot tagları arasındaki element bu xelemente eklenicek
            int index = 1;
            foreach (XElement rehberimiz in rootElement.Elements()) // Şimdi ise foreach ile okudumuz root tagları arasındakiRehber Elementi içinde dönüyoruz ver verileri okumaya başlıyoruz…

            {
                
                string buttonName = "button" + index.ToString();
                Button button =  this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                button.Text = rehberimiz.Element("name").Value;
                button.AccessibleName = rehberimiz.Element("address").Value;
                button.Click += Button_Click;
                index++;
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            System.Diagnostics.Process.Start(button.AccessibleName);
        }

        private void XML_VeriEKleme() //XML VERİ EKLEME İŞLEMİ

        {

            XDocument xDoc = XDocument.Load(@"onur1.xml"); // Xml Dosyamıza Erişip Yükleme İşlemini Gerçekleştiriyoruz…

            XElement rootElement = xDoc.Root; // Xml Dokümanımız okunacak ve daha önce xmlimizde oluşturduğumuzroot tagları arasındaki element bu xelemente eklenicek…

            //İlk Önce ekliceğimiz elementi oluşturcaz

            XElement newElement = new XElement("rehber");// Rehber Elementimizi Oluşturduk…

            //Şimdi İse Elementimize Bir tana attribute oluşturup id atıcaz…

            XAttribute idAttribute = new XAttribute("id", "1");//attributeoluşturduk…

            XElement adiElement = new XElement("kisi_Adı", "Ömer Şakir");//elementlerimiz oluşturmaya devam ediyoruz…

            XElement emailElement = new XElement("kisi_EMail", "omer@hotmail.com");

            // Şimdi Sıra geldi oluşturdumuz elementleri Rehberelemntinini içine yerleştirmeye…

            newElement.Add(idAttribute, adiElement, emailElement); //Elementlerimizi rehber elementimizin içine sıralaekliyoruz….

            //Şimdi İse oluşturduğumuz ELementleri Yani rehberElementimizi Root Tagimiz olan IsRehberim in içine eklicez…

            rootElement.Add(newElement); // Oluşturduğumuzyeni elementi root tagının içine yazmaya başladık…

            // Şimdi İse ramda olan elementlerimiz kalıcı olarak dosyamızaişlemeye…

            xDoc.Save(@"onur1.xml");// İşlemimiz Başarılı Bir Şekilde Kayıt EdilmişOlacaktır…

        }


        OpenFileDialog ofd = new OpenFileDialog();
  
 
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            XML_VeriEKleme();
        }
    }
}
