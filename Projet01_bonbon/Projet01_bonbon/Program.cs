using Project;
namespace Projet01_bonbon;
internal class Program
    {
        public static void Main(string[] args)
        {
            while (true) 
                int selection = GetSelection();
                Candy userCandy = GetCandy(selection);
                while (userCandy.Stock == 0) 
                {
                    Board.Print(message: $"{userCandy.Name} VIDE!", selection: selection, price: userCandy.Price);
                    Thread.Sleep(2000);
                    selection = GetSelection();
                    userCandy = GetCandy(selection);
                }
                decimal prixTotal = userCandy.Price;
                decimal total = 0;
                while (total < prixTotal)
                {
                    Board.Print(message: userCandy.Name, selection: selection, price: userCandy.Price, received: total);
                    int choixArgent = GetCoin();
                    switch (choixArgent)
                    {
                        case (1):
                            total += 0.05m;
                            break;
                        case (2):
                            total += 0.10m;
                            break;
                        case (3):
                            total += 0.25m;
                            break;
                        case (4):
                            total += 1;
                            break;
                        case (5):
                            total += 2;
                            break;
                    }
                    if (choixArgent == 0)
                    {
                        Board.Print(message: "ANNULER", received: total, returned: total);
                        break;
                    }
                    if (total >= prixTotal)
                    {
                        Board.Print(message: "Prennez votre friandise...", selection: selection, price: prixTotal,
                            received: total, returned: (total - prixTotal), result: userCandy.Name);
                        userCandy.Stock -= userCandy.Stock;
                        Thread.Sleep(1000);
                    }
                }
                Console.WriteLine("Appuyez sur une touche pour acheter d'autre bonbon...");
                Console.ReadLine();
            }
        }
        public static int GetSelection() 
        {
            int selection;
            do
            {
                Board.Print(message: "VOTRE CHOIX ?"); 
                Console.Write("->"); 
                selection = int.Parse(Console.ReadLine());
            } while (selection < 1 || selection > 25); 
            return selection;
        }
        public static Candy GetCandy(int selection)
        {
            Candy[] bonbon = LoadCandies();
            return bonbon[selection - 1];
        }
        public static Candy[] LoadCandies()
        {
            Data dataManager = new Data();
            return dataManager.LoadCandies();
        }
        public static int GetCoin()
        {
            int choixArgent;
            Console.WriteLine("[0] = Annuler");
            Console.WriteLine("[1] = 5c");
            Console.WriteLine("[2] = 10c");
            Console.WriteLine("[3] = 25c");
            Console.WriteLine("[4] = 1$");
            Console.WriteLine("[5] = 2$");
            choixArgent = int.Parse(Console.ReadLine());
            return choixArgent;
        }
    }