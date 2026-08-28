using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportApp;

internal class SalesLogic
{
    static List<string> productList = [];
    static List<decimal> priceList = [];
    static int totalProducts = 0;

    public static void WelcomeMessage()
    {
        bool isRunning = true;        

        do
        {
            Console.WriteLine("#### FÖRSÄLJNINGSRAPPORT ####");
            Console.Write("Ange produktnamn, eller skriv 'klar': ");

            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                ErrorMessage();
            }
            else if (userInput.ToLower()== "klar")
            {
                isRunning = false;
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
                    totalProducts++;
                }
            }
            ViewSavedItems();
            
        }
        while(isRunning);
    }
    public static void ViewSavedItems()
    {
        for (int i = 0; i < productList.Count; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"{productList[i]}: {priceList[i]}kr.");
            Console.WriteLine("");
            Console.WriteLine($"Antal sålda produkter {totalProducts}st.");
        }
    }
    public static void ErrorMessage()
    {
        Console.WriteLine("Du har skrivit in fel, försök igen!");
    }

}
