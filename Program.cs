using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using EFIntro;
using Microsoft.EntityFrameworkCore;


    Console.WriteLine("Start of program");

    using var db = new BloggingContext();

    Console.WriteLine($"Sqlite DB Located at {db.DbPath}");

    ParseAndSaveCsv<User>("C:\\Users\\kalle\\source\\repos\\entity-framwork-intro\\User.csv", db.Users);

    ParseAndSaveCsv<Post>("C:\\Users\\kalle\\source\\repos\\entity-framwork-intro\\Post.csv", db.Posts);

    ParseAndSaveCsv<Blog>("C:\\Users\\kalle\\source\\repos\\entity-framwork-intro\\Blog.csv", db.Blogs);

    ShowDatabaseContent(db);

static void ParseAndSaveCsv<T>(string filePath, DbSet<T> dbSet) where T : class, new()
{
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<T>().ToList();
        dbSet.AddRange(records);
    }
}

static void ShowDatabaseContent(BloggingContext db)
{
    foreach (var blog in db.Blogs.Include(b => b.Posts))
    {
        Console.WriteLine($"Blog: [ID: {blog.BlogId}, URL: {blog.Url}, Name: {blog.Name}]");

        foreach (var post in blog.Posts)
        {
            Console.WriteLine($"  Post: [ID: {post.PostId}, Title: {post.Title}, Content: {post.Content}]");
        }

        foreach (var user in blog.Users)
        {
            Console.WriteLine($"  User: [ID: {user.UserId}, Username: {user.Username}, Password: {user.Password}]");
        }

        Console.WriteLine();
    }
}