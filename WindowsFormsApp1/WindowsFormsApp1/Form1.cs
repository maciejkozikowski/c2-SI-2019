using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string sciezkaDoPliku;
        float[,] systemDecyzyjny;

        float[,] WczytajSystem(string sciezkaDoPliku)
        {
            var linie = System.IO.File.ReadAllLines(sciezkaDoPliku);
            int iloscKolumn = 0;
            int iloscWierszy = 0;
            var linia2 = linie[0].Trim();
            var liczby2 = linia2.Split(' ');
            iloscWierszy = linie.Length;
            iloscKolumn = liczby2.Length;
            systemDecyzyjny = new float[iloscWierszy, iloscKolumn];
            for (int i = 0; i < linie.Length; i++)
            {
                var linia = linie[i].Trim();
                var liczby = linia.Split(' ');
                for (int j = 0; j < liczby.Length; j++)
                {
                    systemDecyzyjny[i, j] = float.Parse(liczby[j].Trim());
                }

            }


            return systemDecyzyjny;
        }
        private void button1Wybierz_Click(object sender, EventArgs e)
        {
            //openFileDialogSciezka.Filter = "txt files ("*.txt)|*.txt";
            if (openFileDialogSciezka.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            labelSciezka.Text = openFileDialogSciezka.FileName;
            sciezkaDoPliku = openFileDialogSciezka.FileName;
            systemDecyzyjny = WczytajSystem(sciezkaDoPliku);
        }

        float[,] GenerujMaske(float[,] systemDecyzyjny)
        {
            float[,] maska = new float[systemDecyzyjny.GetLength(0), systemDecyzyjny.GetLength(1)];
            for (int i = 0; i<systemDecyzyjny.GetLength(0); i++)
            {
                for(int j = 0; j<systemDecyzyjny.GetLength(1); j++)
                {
                    maska[i, j] = systemDecyzyjny[i, j];
                }
            }
            return maska;
        }

        int GenerujPokrycie(float[,] systemDecyzyjny, float[,] regula)
        {
            int pokrycieSystemu = 0;
            float[,] zbiorRegul = new float[regula.GetLength(0), regula.GetLength(1)];
            for (int i = 0; i < regula.GetLength(1); i++)
            {
                zbiorRegul[0, i] = regula[0, i];
                zbiorRegul[1, i] = regula[1, i];
            }
            for (int i=0; i < systemDecyzyjny.GetLength(0); i++)
            {
                bool pokrywaSie = true;
                for (int kolumna = 0; kolumna < regula.GetLength(1); kolumna++)
                {
                    zbiorRegul[2, kolumna] = systemDecyzyjny[i, Convert.ToInt32(regula[0, kolumna])];
                }
                for (int s = 0; s <regula.GetLength(1); s++)
                {
                    if (zbiorRegul[1, s] != zbiorRegul[2, s])
                    {
                        pokrywaSie = false;
                    }
                }
                if (pokrywaSie == true)
                {
                    pokrycieSystemu++;
                }
            }

            return pokrycieSystemu;
        }

        string SequentialCovering(float[,] systemDecyzyjny)
        {
            string reguly = "";
            int numerReguly = 1;
            float[,] maska = GenerujMaske(systemDecyzyjny);
            for (int i=1; i< systemDecyzyjny.GetLength(1); i++)
            {
                float[,] regula = new float[3, i];
                float decyzjaReguly;
                for (int wiersz = 0; wiersz<systemDecyzyjny.GetLength(0); wiersz++)
                {
                    for (int pierwszyBranyAtrybut = 0; pierwszyBranyAtrybut< systemDecyzyjny.GetLength(1) - i; pierwszyBranyAtrybut++)
                    {
                        for (int kolumny = pierwszyBranyAtrybut; kolumny < systemDecyzyjny.GetLength(1) - 1; kolumny++)
                        {
                            decyzjaReguly = maska[wiersz, systemDecyzyjny.GetLength(1) - i];
                            bool brakRegul = false;
                            int kolumna = kolumny;

                            if (maska[wiersz,kolumny] != 999)
                            {
                                int ktoryAtrybut = pierwszyBranyAtrybut;
                                for (int j = 0; j< i-1; j++)
                                {
                                    while (maska[wiersz, ktoryAtrybut] == 999)
                                    {
                                        ktoryAtrybut++;
                                    }
                                    if (ktoryAtrybut >= systemDecyzyjny.GetLength(1) - 1)
                                    {
                                        j = i;
                                        brakRegul = true;
                                    }
                                    else
                                    {
                                        regula[0, j] = ktoryAtrybut;
                                        regula[1, j] = maska[wiersz, ktoryAtrybut];
                                        ktoryAtrybut++;
                                    }
                                }
                                regula[0, i - 1] = kolumny;
                                regula[1, i - 1] = maska[wiersz, kolumny];

                            }
                            else
                            {
                                brakRegul = true;
                                kolumny = systemDecyzyjny.GetLength(1);
                            }
                            if (brakRegul == false)
                            {
                                bool sprzecznaRegula = false;
                                for (int kolejneWiersze = 0; kolejneWiersze < systemDecyzyjny.GetLength(0); kolejneWiersze++)
                                {
                                    bool kolejnyWiersz = false;
                                    if(kolejneWiersze != wiersz)
                                    {
                                        for (int uzupelnienie = 0; uzupelnienie < i; uzupelnienie++)
                                        {
                                            int kolumna2 = Convert.ToInt32(regula[0, uzupelnienie]);
                                            regula[2, uzupelnienie] = systemDecyzyjny[kolejneWiersze, kolumna2];
                                        }
                                        if (kolejnyWiersz == false)
                                        {
                                            bool identycznyDeskryptor = true;
                                            for (int k = 0; k < i; k++)
                                            {
                                                if (regula[1,k] != regula[2, k])
                                                {
                                                    identycznyDeskryptor = false;
                                                    k = i;
                                                }
                                            }
                                            if (identycznyDeskryptor == true && decyzjaReguly != systemDecyzyjny[kolejneWiersze, systemDecyzyjny.GetLength(1) - 1])
                                            {
                                                sprzecznaRegula = true;
                                            }
                                        }
                                    }
                                }
                                if (sprzecznaRegula == false)
                                {
                                    int pokrycie = 0;
                                    reguly = reguly + "R" + numerReguly + ":";
                                    for (int s = 0; s < i; s++)
                                    {
                                        int numerAtrybutu = Convert.ToInt32(regula[0, s]) + 1;
                                        reguly = reguly + "s" + numerAtrybutu + '=' + Convert.ToString(regula[1, s]) + " ";
                                        if (s< i - 1)
                                        {
                                            reguly = reguly + "/" + @"\";
                                        }
                                    }
                                    reguly = reguly + "d=>" + decyzjaReguly;
                                    for (int wierszMaski = 0; wierszMaski < systemDecyzyjny.GetLength(0); wierszMaski++)
                                    {
                                        bool kolejnyWiersz = false;
                                        for (int uzupelnienie = 0; uzupelnienie < i; uzupelnienie++)
                                        {
                                            int kolumna2 = Convert.ToInt32(regula[0, uzupelnienie]);
                                            if (maska[wierszMaski, kolumna2] != 999)
                                            {
                                                regula[2, uzupelnienie] = maska[wierszMaski, kolumna2];
                                            }
                                            else
                                            {
                                                kolejnyWiersz = true;
                                                uzupelnienie = i;

                                            }
                                        }
                                        for (int sprawdzenie = 0; sprawdzenie < i; sprawdzenie++)
                                        {
                                            if (regula[1, sprawdzenie] != regula[2, sprawdzenie])
                                            {
                                                kolejnyWiersz = true;
                                            }
                                            if (kolejnyWiersz == false)
                                            {
                                                for (int g = 0; g<systemDecyzyjny.GetLength(1) -1; g++)
                                                {
                                                    maska[wierszMaski, g] = 999;
                                                }
                                            }
                                        }
                                        pokrycie = GenerujPokrycie(systemDecyzyjny, regula);
                                        if (pokrycie > 1)
                                        {
                                            reguly = reguly + " [" + pokrycie + "]" + "\r\n";

                                        }
                                        else
                                        {
                                            reguly = reguly + "\r\n";
                                        }
                                        numerReguly++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return reguly;
        }

        private void buttonGeneruj_Click(object sender, EventArgs e)
        {
            string regulySeqCov = SequentialCovering(systemDecyzyjny);
            MessageBox.Show(regulySeqCov);
        }
    }
}
