using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportApp;

internal class SalesLogic
{
    static List<string> productList = [];
    static List<decimal> priceList = [];
    static int totalProducts = 0;
    static decimal totalPrice = 0;
    static int strongSale = 0;

    public static void SalesInteraction()
    {
        bool isRunning = true;        

        do
        {
            Console.Clear();
            Console.WriteLine("#### FÖRSÄLJNINGSRAPPORT ####");
            Console.Write("Ange produktnamn, eller skriv 'klar': ");

            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                ErrorMessage();
            }
            else if (userInput.ToLower()== "klar")
            {
                EndofDayReport();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else
            {
                Console.Write("Ange försäljningsbelopp: ");
                bool input = decimal.TryParse(Console.ReadLine(), out decimal value);
                if (input == false || value <= 0)
                {
                    ErrorMessage();
                }
                else
                {
                    productList.Add(userInput);
                    priceList.Add(value);
                    totalPrice += value;
                    totalProducts++;
                    if(value > 1000)
                    {
                        strongSale++;
                    }
                }
            }
            ViewSavedItems();
        }
        while(isRunning);
    }
    public static void ViewSavedItems()
    {
        Console.WriteLine("");
        Console.WriteLine("DAGENS FÖRSÄLJNINGAR:");

        for (int i = 0; i < productList.Count; i++)
        {
            Console.WriteLine($"{productList[i]}: {priceList[i]}kr.");
            Console.WriteLine("");
        }
        Console.WriteLine($"Antal sålda produkter {totalProducts}st.");
        Console.WriteLine("");
        Console.WriteLine($"Totala summan av försäljning: {totalPrice}kr.");
        Console.WriteLine("Tryck valfri knapp för att fortsätta");
        Console.ReadKey();
    }
    public static void ErrorMessage()
    {
        Console.Clear();
        Console.WriteLine("Du har skrivit in fel, försök igen!");
    }
    public static void EndofDayReport()
    {
        decimal averageSale = 0;
        if (productList.Count > 0)
        {
            averageSale = totalPrice / totalProducts;
        }
        Console.Clear();
        Console.WriteLine("SAMMANFATTNING DAGENSFÖRSÄLJNING");
        Console.WriteLine("");
        Console.WriteLine($"Antal försäljningar: {totalProducts}st.");
        Console.WriteLine($"Total försäljning: {totalPrice}kr.");
        Console.WriteLine($"Genomsnittlig försäljning: {averageSale}kr.");
        Console.WriteLine($"Försäljningar över 1000kr: {strongSale}st.");
        if(totalPrice <= 5000)
        {
            Console.WriteLine("Resultat: Svag försäljningsdag.");
        }
        else if (totalPrice >= 10000)
        {
            Console.WriteLine("Resultat: Stark försäljningsdag.");
        }
        else
        {
            Console.WriteLine("Resultat: Normal försäljningsdag.");
        }
    }
}
