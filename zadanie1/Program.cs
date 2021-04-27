using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Globalization;

namespace zadanie1
{

    public class Wiersz
    {
        public List<double> parametry;

        public Wiersz(List<double> parametryIn)
        {
            parametry = parametryIn;
        }
    }

        class Program
        {
            public static List<Wiersz> importData(string fileName)
            {
                string wiersz;
                string[] wierszSplit;
                List<Wiersz> allData = new List<Wiersz>();
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                while (file.ReadLine() != null)
                {
                    List<double> parametry = new List<double>();
                    wiersz = file.ReadLine();
                    wierszSplit = wiersz.Split(' ');
                    for (int i = 0; i < (wierszSplit.Length - 1); i++)
                    {
                        parametry.Add(double.Parse(wierszSplit[i], CultureInfo.InvariantCulture));
                    }
                    Wiersz Obiekt = new Wiersz(parametry);
                    allData.Add(Obiekt);
                }
                file.Close();
                return allData;

            }

            public static void wyswietl(List<Wiersz> Obiekty)
            {
                for(int i =0; i<Obiekty.Count; i++)
                {
                    for (int j =0; j<Obiekty[i].parametry.Count; j++)
                    {
                        Console.WriteLine(Obiekty[i].parametry[j]);
                    }
                   
                }
                
            }

            static void Main(string[] args)
            {
                wyswietl(importData("australian.dat"));
                

                Console.WriteLine("Hello World!");
            }
        
    }
}

