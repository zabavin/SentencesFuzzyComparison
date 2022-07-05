using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  

namespace SentencesFuzzyComparison {
    class Program {
        static void Main(string[] args) {

            FuzzyComparer fc = new  FuzzyComparer();
            double d = fc.CalculateFuzzyEqualValue("первый тест", "первый");


            Console.ReadLine();
        }
    }
}
