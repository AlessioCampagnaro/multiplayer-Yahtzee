using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Yatzee
{
    public partial class frmYahtzee : Form
    {
        //Pellizzari Nicola 4BI


        //-------------------------------------------------------------------------------------------------------------------------

        //Se viene fuori questo errore:

    //Errore MSB3821 non è stato possibile elaborare il file Form1.resx
    //perché si trova nell'area Internet o Siti con restrizioni o presenta
    //il contrassegno del Web. Rimuovere il contrassegno del Web se si intende elaborare questi file.	

        //aprire powershell come amministratore e incollare questo:

        //Get-ChildItem -Path 'Percorso del progetto' -Recurse | Unblock-File

        //attenzione a modificare prima il percorso del progetto 
        //-------------------------------------------------------------------------------------------------------------------------

        private Tabella tabella;
        private Giocatore giocatore;
        private Button[] bottoni;
        private string fontLocation;
        private string pcbImageLocation;
        private string[] dadiDefaultIM;
        private string[] dadiBloccatiIM;
        private string[] logoOutPutIM;
        private bool[] dadiBloccati;
        int tiriCounter;

        public frmYahtzee()
        {
            InitializeComponent();
            AssegnaNomiFile();
            DataGridSetup();
            SetupGrafico();
            FontSetup();
            giocatore = new Giocatore("Player 1");
            tabella = new Tabella();
            bottoni = new Button[] { button1, button2, button3, button4, button5 };
            dadiBloccati = new bool[] { false, false, false, false, false };
        }
        //btn Roll

        private void Form1_Load(object sender, EventArgs e)
        {
            Bloccadadi();
            resetDadi();

            btnSelezionaPunteggio.Visible = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int[] dadi = giocatore.tiraDadi(dadiBloccati);
            AssegnaBottoni(dadi);
            RiempiDataGrid(tabella.RiempiTabella(dadi));
            TiraDadi();
            //Output Utente----
            lblOutPut.Text = "Roll: " +  tiriCounter.ToString();
        }
        //bottone Seleziona Punteggio
        private void btnSelezionaPunteggio_Click(object sender, EventArgs e)
        {
            

            if ((!tabella.ControlloCella(dtg.CurrentCell.RowIndex)) || (dtg.CurrentCell.RowIndex == tabella.DammiTabella().Length - 1) || (dtg.CurrentCell.ColumnIndex != 0))
            {
                tabella.BloccaCelle(dtg.CurrentCell.RowIndex);

                
                    dtg.CurrentCell.Style.BackColor = Color.FromArgb(253, 226, 146);
                    dtg.CurrentCell.Style.ForeColor = Color.FromArgb(43, 43, 43);
                

                ScegliPunteggio(tabella.DammiTabella()[dtg.CurrentCell.RowIndex]);
                lblOutPut.Text = " ";
            }
            FineGioco();
        }

        //Metodi Setup Form
        public void DataGridSetup()
        {
            string[] nomiCombinazioni = new string[] { "Dadi con 1", "Dadi con 2", "Dadi con 3", "Dadi con 4", "Dadi con 5", "Dadi con 6", "Bonobus", "Piccola Scala", "Grande Scala", "Tre di un tipo", "Quattro di un tipo", "Full House", "Yahtzee", "Chance", "TOTALE" };
            dtg.MultiSelect = false;
            dtg.BorderStyle = BorderStyle.FixedSingle;

            for (int i = 0; i < nomiCombinazioni.Length; i++)
            {
                dtg.Rows.Add(nomiCombinazioni[i]);
                dtg.Rows[i].Cells[1].Value = 0;
                dtg.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(43, 43, 43);
                dtg.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(43, 43, 43);
            }



        }

        public void AssegnaBottoni(int[] numDadi)
        {
            for (int i = 0; i < numDadi.Length; i++)
            {
                if (!dadiBloccati[i])
                {
                    bottoni[i].Image = Image.FromFile(dadiDefaultIM[numDadi[i] - 1]);
                }
            }
        }

        public void AssegnaNomiFile()
        {
            //in questo metodo vengono assegnati i nomi dei file che servono per il programma,
            //viene usato il metodo Path.GetFullPath() che a partire dalla directory da cui viene lanciato il programma
            //assegna al percorso principale un percorso sempre valido per accedere al file
            //Tutto Questo è per garantire il funzionamento del progetto anche se viene spostato in qualsiasi altra directory del disco fisso
            //ESEMPIO: 
            //
            // Percorso Principale(dove viene lanciato il programma yatzee.exe): C:\Users\nicop\source\repos\Yatzee\Yatzee\bin\Debug\netcoreapp3.1
            //
            // Path.GetFullPath(@"..\..\..\font\pixelated.ttf");
            // "..\" = una cartella indietro
            // "..\..\" = due cartelle indietro
            // ...
            // Percorso Finale: C:\Users\nicop\source\repos\Yatzee\Yatzee\font\pixelated.ttf



            fontLocation = Path.GetFullPath(@"..\..\..\font\pixelated.ttf");
            dadiDefaultIM = new string[6];
            pcbImageLocation = Path.GetFullPath(@"..\..\..\Assets\OutPutLogo\logo.png");
            dadiDefaultIM[0] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Uno.png");
            dadiDefaultIM[1] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Due.png");
            dadiDefaultIM[2] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Tre.png");
            dadiDefaultIM[3] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Quattro.png");
            dadiDefaultIM[4] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Cinque.png");
            dadiDefaultIM[5] = Path.GetFullPath(@"..\..\..\Assets\Dadi\Sei.png");

            dadiBloccatiIM = new string[6];
            dadiBloccatiIM[0] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Uno.png");
            dadiBloccatiIM[1] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Due.png");
            dadiBloccatiIM[2] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Tre.png");
            dadiBloccatiIM[3] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Quattro.png");
            dadiBloccatiIM[4] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Cinque.png");
            dadiBloccatiIM[5] = Path.GetFullPath(@"..\..\..\Assets\DadiSelezionati\Sei.png");

            logoOutPutIM = new string[4];
            logoOutPutIM[0] = Path.GetFullPath(@"..\..\..\Assets\OutPutLogo\logo.png");
            logoOutPutIM[1] = Path.GetFullPath(@"..\..\..\Assets\OutPutLogo\ButtaIdadi.png");
            logoOutPutIM[2] = Path.GetFullPath(@"..\..\..\Assets\OutPutLogo\SelezionaPunteggio.png");
            logoOutPutIM[3] = Path.GetFullPath(@"..\..\..\Assets\OutPutLogo\FinePartita.png");

        }

        public void RiempiDataGrid(int[] tabella)
        {

            for (int i = 0; i < tabella.Length; i++)
            {
                dtg[1, i].Value = tabella[i];
            }
        }

        public void SetupGrafico()
        {
            Size size = new Size(390, 180);
            pcbLogo.Size = size;
            pcbLogo.Image = Image.FromFile(pcbImageLocation);
            pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void FontSetup()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontLocation);
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
                c.ForeColor = Color.FromArgb(253, 226, 146);
            }
        }

        public void GraficaFineGioco()
        {
            for (int i = 0; i < bottoni.Length; i++)
            {
                bottoni[i].Visible = false;
            }

            btnSelezionaPunteggio.Visible = false;
            BtnTira.Visible = false;
            lblOutPut.Visible = false;

            this.BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(pcbLogo.Width, dtg.Size.Height + pcbLogo.Height + 20);
            dtg.Location = new Point(ClientSize.Width / 10, dtg.Location.Y);
            pcbLogo.Size = new Size(dtg.Width, pcbLogo.Height - 40);
            pcbLogo.Location = new Point(ClientSize.Width / 10, dtg.Height + 30);
            pcbLogo.Image = Image.FromFile(logoOutPutIM[3]);
        }


        public void impostaImmagineDado(int bottoneIndex, int dado, bool bloccato)
        {
            if (bloccato) { bottoni[bottoneIndex].Image = Image.FromFile(dadiBloccatiIM[dado]); }
            else { bottoni[bottoneIndex].Image = Image.FromFile(dadiDefaultIM[dado]); }
        }

        //Metodi del gioco-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 
        
        public void TiraDadi()
        {
            Sbloccadadi();
            btnSelezionaPunteggio.Visible = true;
            tiriCounter++;
            if (tiriCounter == 3) 
            {
                BtnTira.Visible = false;
                pcbLogo.Image = Image.FromFile(logoOutPutIM[2]);
            }        
       }

        public void ScegliPunteggio(int punteggio)
        {
            tiriCounter = 0;
            giocatore.punteggio = punteggio;
            BtnTira.Visible = true;
            btnSelezionaPunteggio.Visible = false;
            resetDadi();
            Bloccadadi();
            pcbLogo.Image = Image.FromFile(logoOutPutIM[1]);
        }

        public void resetDadi()
        {
            for (int i = 0; i < dadiBloccati.Length; i++)
            {
                dadiBloccati[i] = false;
            }
            int[] dadi = new int[] {1,2,3,4,5};
            AssegnaBottoni(dadi);
            tabella.ResetTabella();
            RiempiDataGrid(tabella.DammiTabella());
        }

        public void Bloccadadi()
        {
            for (int i = 0; i < bottoni.Length; i++)
            {
                bottoni[i].Enabled = false;
            }
        }

        public void Sbloccadadi()
        {
            for (int i = 0; i < bottoni.Length; i++)
            {
                bottoni[i].Enabled = true;
            }
        }

        public void FineGioco()
        {

            if (tabella.DammiNumBloccate() == tabella.DammiTabella().Length - 1) 
            {
                GraficaFineGioco();
            }

        }








        //click Bottoni Dadi------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            dadiBloccati[b.TabIndex] = !dadiBloccati[b.TabIndex];
            impostaImmagineDado(b.TabIndex, giocatore.dimmiDadi()[b.TabIndex] - 1, dadiBloccati[b.TabIndex]);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            dadiBloccati[b.TabIndex] = !dadiBloccati[b.TabIndex];
            impostaImmagineDado(b.TabIndex, giocatore.dimmiDadi()[b.TabIndex] - 1, dadiBloccati[b.TabIndex]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            dadiBloccati[b.TabIndex] = !dadiBloccati[b.TabIndex];
            impostaImmagineDado(b.TabIndex, giocatore.dimmiDadi()[b.TabIndex] - 1, dadiBloccati[b.TabIndex]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            dadiBloccati[b.TabIndex] = !dadiBloccati[b.TabIndex];
            impostaImmagineDado(b.TabIndex, giocatore.dimmiDadi()[b.TabIndex] - 1, dadiBloccati[b.TabIndex]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            dadiBloccati[b.TabIndex] = !dadiBloccati[b.TabIndex];
            impostaImmagineDado(b.TabIndex, giocatore.dimmiDadi()[b.TabIndex] - 1, dadiBloccati[b.TabIndex]);
        }
        //click Bottoni Dadi------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





















































        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
