using ConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharProject.Models
{
     public partial class Pharmacy
    {
        public bool AddDrug(Drug drug)
        {
            Drug existdrug = Drugs.Find(x => x.Name.ToLower() == drug.Name.ToLower());
            if (existdrug == null)
            {
                Drugs.Add(drug);
                return true;                
            }

            else
            {
                existdrug.Count += drug.Count;
                return false;
            }
        }

        public bool InforDrug(string DrugName)
        {
            Drug drug = Drugs.Find(x => x.Name.ToLower().Contains(DrugName.ToLower()));

            if (drug == null)
            {
                Extensions.Print($"  Drug of {DrugName} does not exist", ConsoleColor.Red);
                return false;
            }
            else
            {
                Console.WriteLine(" ");
                Extensions.Print($"  Please see: {drug.Description}", ConsoleColor.Green);
                return true;
            }
        }

        public void ShowDrugItems()
        {
            if (Drugs.Count == 0)
            {
                Extensions.Print("  Pharmacy of does not containt any drugs.", ConsoleColor.Red);
                return;
            }
            Console.WriteLine(" ");
            Extensions.Print("  List of available drugs: ", ConsoleColor.Yellow);
            foreach (var item in Drugs)
            {
                Extensions.Print(item.ToString(), ConsoleColor.Green);
            }
        }
        public bool SaleDrug(string DrugName, int NumberOfDrugs, double Budget)
        {
            Drug drug = Drugs.Find(x => x.Name.ToLower().Contains(DrugName.ToLower()));

            if (drug == null)
            {
                Extensions.Print($"  Drug of {DrugName} does not exist.", ConsoleColor.Red);
                return false;
            }
            else if (NumberOfDrugs > drug.Count)
            {
                Extensions.Print($"  Drug of {DrugName} does not exist in required quantitiy.", ConsoleColor.Red);
                return false;
            }
            else if (Budget < NumberOfDrugs * drug.Price)
            {
                Extensions.Print($"  You don't have sufficient budget to purchase drug of {DrugName} with quanitity of {NumberOfDrugs}.", ConsoleColor.Red);
                return false;
            }
            else
            {
                drug.Count = drug.Count - NumberOfDrugs;
                Budget = Budget - NumberOfDrugs * drug.Price;
            }
            Extensions.Print($"  Drug is succesfully added into your basket. Your remaining budget: {Budget} AZN. ", ConsoleColor.Green);
            return true;
        }
         
        public override string ToString()
        {
            return $" {ID}-{Name}";
        }
    }
}
