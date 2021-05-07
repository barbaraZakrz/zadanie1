using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            for (int i = 0; i < Obiekty.Count; i++)
            {
                for (int j = 0; j < Obiekty[i].parametry.Count; j++)
                {
                    Console.WriteLine(Obiekty[i].parametry[j]);
                }

            }

        }


        public static List<Wiersz> normalizacja(List<Wiersz> lista)
        { 
            List<double> min = new List<double>(lista[0].parametry);
            List<double> max = new List<double>(lista[0].parametry);

            for (int i = 1; i < lista.Count; i++)
            {
                for (int j = 0; j < min.Count; j++)
                {
                    if (lista[i].parametry[j] < min[j])
                    {
                        min[j] = lista[i].parametry[j];
                    }

                    if (lista[i].parametry[j] > max[j])
                    {
                        max[j] = lista[i].parametry[j];
                    }
                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < min.Count; j++)
                {
                    lista[i].parametry[j] = (lista[i].parametry[j] - min[j]) / (max[j] - min[j]);
                }
            }

                return lista;
        }

        public static void zapis(List<Wiersz> lista) 
        {
            if (System.IO.File.Exists("dane.txt"))    
            {
                System.IO.File.Delete("dane.txt");    
            }

            String wiersz = "";

            using (System.IO.StreamWriter sw = System.IO.File.CreateText("dane.txt"))
            {
                for (int i=0; i < lista.Count; i++)
                {
                    wiersz = "";
                    for (int j = 0; j<lista[i].parametry.Count; j++)
                    {
                        String parametr = lista[i].parametry[j].ToString();
                        wiersz = String.Concat(wiersz, parametr, " ");
                        //wiersz.Concat(" ");
                    }
                    sw.WriteLine(wiersz);
                }


            }
           
        }
            
        static void Main(string[] args)
        {
           importData("australian.dat");
           zapis(normalizacja(importData("australian.dat")));
                

            Console.WriteLine("Hello World!");
        }
        
    }
}


