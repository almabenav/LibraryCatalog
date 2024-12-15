using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();
    private const string filePath = "LibraryCatalog.txt"; // File where the books will be stored

    public Library()
    {
        LoadBooksFromFile();  // Load books when starting the program
    }

    public void AddBook()
    {
        Console.Write("Enter book title: ");
        string? title = Console.ReadLine();
        
        Console.Write("Enter book author: ");
        string? author = Console.ReadLine();

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
        {
            Console.WriteLine("Invalid input. Title and author cannot be empty.");
            return;
        }

        books.Add(new Book(title, author));
        Console.WriteLine("Book added successfully.");
        
        SaveBooksToFile();  // Save the books each time a new one is added
    }

    // Function for writing books to a file
    private void SaveBooksToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"{book.Title}|{book.Author}");
            }
        }
        Console.WriteLine("Books saved to file.");
    }

    // Function to read books from a file
    private void LoadBooksFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved books found.");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string title = parts[0];
                    string author = parts[1];
                    books.Add(new Book(title, author));
                }
            }
        }
        Console.WriteLine("Books loaded from file.");
    }


    public void BorrowBook()
    {
        Console.Write("Enter the title of the book to borrow: ");
        string? title = Console.ReadLine();

    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Book book = books.Find(b => b.Title == title && b.IsAvailable);
    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (book != null)
        {
            book.IsAvailable = false;
            Console.WriteLine($"You borrowed: {book.Title}");
        }
        else
        {
            Console.WriteLine("Book not available.");
        }
    }

    public void ReturnBook()
    {
        Console.Write("Enter the title of the book to return: ");
        string? title = Console.ReadLine();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Book book = books.Find(b => b.Title == title && !b.IsAvailable);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (book != null)
        {
            book.IsAvailable = true;
            Console.WriteLine($"You returned: {book.Title}");
        }
        else
        {
            Console.WriteLine("Book not found or not borrowed.");
        }
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}
