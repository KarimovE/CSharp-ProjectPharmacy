using CsharProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utils
{
    static class Extensions
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.WriteLine(" ");
            Console.ResetColor();
        }
        public static void ListofPharmacies(List<Pharmacy> pharmacies)
        {
            Console.WriteLine(" ");
            Extensions.Print("  List of Existing Pharmacies: ", ConsoleColor.Yellow);
            foreach (var item in pharmacies)
            {
                Console.Write(" ");
                Extensions.Print(item.ToString(), ConsoleColor.Green);
            }
        }
        public static Pharmacy existPharmacy(string pharmacyName, List<Pharmacy> pharmacies)
        {
            return pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
        }                                        
    }           
}