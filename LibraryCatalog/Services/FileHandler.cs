using System;
using System.Collections.Generic;
using System.IO;

public static class FileHandler
{
    public static List<Book> ReadBooksFromFile(string filePath)
    {
        List<Book> books = new List<Book>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    Book book = new Book(parts[0], parts[1])
                    {
                        IsAvailable = bool.Parse(parts[2])
                    };
                    books.Add(book);
                }
            }
        }
        return books;
    }

    public static void SaveBooksToFile(string filePath, List<Book> books)
    {
        List<string> lines = new List<string>();
        foreach (Book book in books)
        {
            lines.Add($"{book.Title},{book.Author},{book.IsAvailable}");
        }
        File.WriteAllLines(filePath, lines);
    }
}
