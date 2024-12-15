class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();  // The books will be automatically loaded from the file
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nWelcome to the Library Catalog System!");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    library.AddBook();  // automatically save the books in the
                    break;
                case "2":
                    library.BorrowBook();
                    break;
                case "3":
                    library.ReturnBook();
                    break;
                case "4":
                    library.ListBooks();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
