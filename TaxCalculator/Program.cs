using System;
using System.Globalization;
using TaxCalculator.Entities;

namespace TaxCalculator // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();
            double totalTaxes = 0.0;

            Console.Write("Enter the number of tax payers: ");
            int numberOfTaxPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfTaxPayers; i++)
            {
                Console.WriteLine($"Tax pater #{i} data:");
                Console.Write("Indidual or company? (i/c)");
                char c = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if(c.Equals('i'))
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach(TaxPayer taxPayer in taxPayers)
            {
                Console.WriteLine($"{taxPayer.Name} : ${taxPayer.Tax().ToString("F2")}");
                totalTaxes += taxPayer.Tax();
            }
            Console.WriteLine();
            Console.Write($"TOTAL TAXES: ${totalTaxes.ToString("F2")}");
        }
    }
}