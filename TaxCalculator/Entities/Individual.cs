using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealtExpenditures { get; set; }
        public Individual(string name, double anualIncome, double healthExpenditures) : base (name, anualIncome)
        {
            HealtExpenditures = healthExpenditures;
        }
        public override double Tax()
        {
            double total = 0.0;
            if(AnualIncome < 20000.00)
            {
                total = AnualIncome * 0.15;
            }
            else
            {
                total = AnualIncome * 0.25;
            }

            if(HealtExpenditures > 0)
            {
                total -= HealtExpenditures * 0.5;
            }
            return total;
        }
    }
}
