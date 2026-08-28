using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportApp;

internal class SalesLogic
{

    public static void WelcomeMessage()
    {
        bool isRunning = true;
        List<string> productList = [];
        List<decimal> priceList = [];

        int totalProducts = 0;

        do
        {
            Console.WriteLine("#### FÖRSÄLJNINGSRAPPORT ####");
            Console.Write("Ange produktnamn, eller skriv 'klar': ");

            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Du har skrivit in fel, försök igen!");
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
                    Console.WriteLine("Du har skrivit in fel, försök igen!");
                }
                else
                {
                    productList.Add(userInput);
                    priceList.Add(value);
                    totalProducts++;
                }
            }
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"{ productList[i]}: {priceList[i]}kr.");
                Console.WriteLine("");
            }
        }
        while(isRunning);
    }
}
