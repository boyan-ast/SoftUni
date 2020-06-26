using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> allArticles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article(input[0], input[1], input[2]);

                allArticles.Add(article);
            }

            string orderCriteria = Console.ReadLine();

            List<Article> orderedArticles = new List<Article>();

            if (orderCriteria == "title")
            {
                orderedArticles = allArticles.OrderBy(x => x.Title).ToList();
            }
            else if (orderCriteria == "content")
            {
                orderedArticles = allArticles.OrderBy(x => x.Content).ToList();
            }
            else if (orderCriteria == "author")
            {
                orderedArticles = allArticles.OrderBy(x => x.Author).ToList();
            }

            foreach (Article article in orderedArticles)
            {
                Console.WriteLine(article);
            }
        }

        class Article
        {
            private string title;
            private string content;
            private string author;

            public string Title
            {
                get { return this.title; }
                set { this.title = value; }
            }
            public string Content
            {
                get { return this.content; }
                set { this.content = value; }
            }
            public string Author
            {
                get { return this.author; }
                set { this.author = value; }
            }
            public Article()
            {

            }
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }
           
            public override string ToString()
            {
                string result = string.Format($"{this.Title} - {this.Content}: {this.Author}");
                return result;
            }

        }
    }
}
