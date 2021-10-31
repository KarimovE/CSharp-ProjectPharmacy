using ConsoleApp.Utils;
using CsharProject.Models;
using System;
using System.Collections.Generic;

namespace CsharProject
{
    class Program
    {
        private static readonly string password = "welcome1";
        static void Main(string[] args)
        {
            //Introduction
            Console.WriteLine(" ");
            Extensions.Print("                                          <WELCOME TO PHARMACY SYSTEM>", ConsoleColor.Blue);
            Console.WriteLine(" ");
            // List of pharmacies
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            // Drug types
            DrugType type1 = new DrugType("Capsule");
            DrugType type2 = new DrugType("Tablet");
            DrugType type3 = new DrugType("Drops/Sprays");
            DrugType type4 = new DrugType("Injection");
            List<DrugType> types = new List<DrugType>();
            types.Add(type1);
            types.Add(type2);
            types.Add(type3);
            types.Add(type4);
            //Operations
            while (true)
            {
                Extensions.Print("  Admin activities: 1 - Making new pharmacy, 2 - Drug addition.", ConsoleColor.Gray);
                Console.WriteLine(" ");
                Extensions.Print("  End user activities: 3 - Drug info, 4 - Show drugs, 5 - Purchase drug, 6 - Finish.", ConsoleColor.Yellow);
                Console.WriteLine(" ");
            Again:
                Console.Write("  Please select your request number: ");
                int i = 0;
                String option = Console.ReadLine();
                try
                {
                    int menu = int.Parse(option);
                    if (menu >= 1 & menu <= 6)
                    {
                        if (menu == 6)
                            break;
                        //Password requirement for admin procedures
                        if (menu == 1 || menu == 2)
                        {
                            while (true)
                            {
                            Password:
                                if (i == 3)
                                {
                                    goto Again;
                                }
                                Console.WriteLine(" ");
                                Console.Write("  Please enter password: ");
                                string passwordentered = Console.ReadLine();
                                i++;

                                if (passwordentered != password)
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print($"  Wrong password! {3 - i} chances remaining!", ConsoleColor.Red);
                                    goto Password;
                                }
                                else goto passed;
                            }
                        }
                    passed:
                        //Options
                        switch (menu)
                        {
                            case 1: //Pharmacy addition into system
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter Pharmacy name:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                string pharmacyName = Console.ReadLine();
                                if (pharmacies.Exists(x => x.Name.ToLower() == pharmacyName.ToLower()))
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print("  This Pharmacy already exists.", ConsoleColor.Red);
                                    goto case 1;
                                }
                                Pharmacy pharmacy = new Pharmacy(pharmacyName);
                                pharmacies.Add(pharmacy);
                                Console.WriteLine(" ");
                                Extensions.Print($"  {pharmacyName} is succesfully added.", ConsoleColor.Green);
                                break;

                            case 2: //Drug addition into system
                                Extensions.ListofPharmacies(pharmacies);
                            inputPharmacyName:
                                Extensions.Print("  Enter Pharmacy name that you want to add drug:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                pharmacyName = Console.ReadLine();
                                Pharmacy existingPharmacy = Extensions.existPharmacy(pharmacyName, pharmacies);
                                if (existingPharmacy == null)
                                {
                                    Extensions.Print("  Select from existing pharmacies:", ConsoleColor.Red);
                                    goto inputPharmacyName;
                                }
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drug name:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                string drugName = Console.ReadLine();
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drug description:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                string drugDescription = Console.ReadLine();
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drug amount:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                int drugAmount = int.Parse(Console.ReadLine());
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drug price:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                double drugPrice = double.Parse(Console.ReadLine());
                                Extensions.Print("  Enter drug expire date with the format of MM/DD/YYYY:", ConsoleColor.Yellow);
                                Console.Write("- ");                               
                                DateTime expiredate = DateTime.Parse(Console.ReadLine());
                                if (expiredate <= DateTime.Today)
                                {
                                    Extensions.Print("Drug is expired!", ConsoleColor.Red);
                                    goto Again;

                                }                               
                                Again1:
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drugtype from below list:", ConsoleColor.Yellow);
                                Console.Write("  ");
                                foreach (var item in types)
                                {
                                    Console.Write(item.TypeName);
                                    if (item.ID != types.Count)
                                        Console.Write(", ");
                                }
                                Console.WriteLine(" ");
                                Console.Write("- ");
                                string drugtype = Console.ReadLine();
                                DrugType existdrugtype = types.Find(x => x.TypeName.ToLower() == drugtype.ToLower());
                                if (existdrugtype == null)
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print("  Select from available types! ", ConsoleColor.Red);
                                    goto Again1;
                                }
                                Drug drug = new Drug(existdrugtype, drugName, drugDescription, drugAmount, drugPrice, expiredate);
                                if (existingPharmacy.AddDrug(drug))
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print($"  {drugName} is successfully added.", ConsoleColor.Green);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print($"  {drugName} already existed, only its count is increased.", ConsoleColor.Red);
                                    break;
                                }

                            case 3: //Description of a drug
                                Extensions.ListofPharmacies(pharmacies);
                            inputPharmacyName1:
                                Extensions.Print("  Enter Pharmacy name that you want to look at drugs:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                pharmacyName = Console.ReadLine();
                                existingPharmacy = Extensions.existPharmacy(pharmacyName, pharmacies);
                                if (existingPharmacy == null)
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print("  Select from existing pharmacies:", ConsoleColor.Red);
                                    Console.Write("- ");
                                    goto inputPharmacyName1;
                                }
                                existingPharmacy.ShowDrugItems();
                            EnterDrugName:
                                Extensions.Print("  Enter Drug name that you want to see description:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                drugName = Console.ReadLine();
                                if (!existingPharmacy.InforDrug(drugName))
                                {
                                    goto EnterDrugName;
                                }
                                break;

                            case 4: //Show all drugs
                                Console.WriteLine(" ");
                                Extensions.Print("  List of Existing Pharmacies:", ConsoleColor.Yellow);
                                foreach (var item in pharmacies)
                                {
                                    Extensions.Print(item.ToString(), ConsoleColor.Green);
                                }
                            inputPharmacyName2:
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter Pharmacy name that you want to look at drugs:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                pharmacyName = Console.ReadLine();
                                existingPharmacy = Extensions.existPharmacy(pharmacyName, pharmacies);
                                if (existingPharmacy == null)
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print("  Select from existing pharmacies:", ConsoleColor.Red);
                                    goto inputPharmacyName2;
                                }
                                existingPharmacy.ShowDrugItems();
                                break;

                            case 5: //Procurement
                                Console.WriteLine(" ");
                                Extensions.Print("  List of Existing Pharmacies:", ConsoleColor.Yellow);
                                foreach (var item in pharmacies)
                                {
                                    Extensions.Print(item.ToString(), ConsoleColor.Green);
                                }
                            inputPharmacyName3:
                                Extensions.Print("  Enter pharmacy name that you want to purchase drugs from: ", ConsoleColor.Yellow);
                                Console.Write("- ");
                                pharmacyName = Console.ReadLine();
                                existingPharmacy = Extensions.existPharmacy(pharmacyName, pharmacies);
                                if (existingPharmacy == null)
                                {
                                    Console.WriteLine(" ");
                                    Extensions.Print("  Select from existing pharmacies:", ConsoleColor.Red);
                                    goto inputPharmacyName3;
                                }
                                existingPharmacy.ShowDrugItems();
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter drug name that you want to purchase:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                drugName = Console.ReadLine();
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter the number of drugs you want to purchase:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                int count = int.Parse(Console.ReadLine());
                                Console.WriteLine(" ");
                                Extensions.Print("  Enter your budget with AZN:", ConsoleColor.Yellow);
                                Console.Write("- ");
                                double budget = double.Parse(Console.ReadLine());
                                existingPharmacy.SaleDrug(drugName, count, budget);

                                break;
                            default:
                                break;
                        }

                    }

                    else
                    {
                        Console.WriteLine(" ");
                        Extensions.Print($"  Out of available options range!", ConsoleColor.Red);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(" ");
                    Extensions.Print($"  Relevant type to be entered!", ConsoleColor.Red);
                }

            }

        }

    }
}
