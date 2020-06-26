using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string action = command[0];
                string newInfo = command[1];

                switch (action)
                {
                    case "Edit":
                        article.Edit(newInfo);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(newInfo);
                        break;
                    case "Rename":
                        article.Rename(newInfo);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(article);
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

            public void Edit(string newContent)
            {
                this.Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                this.Title = newTitle;
            }

            public override string ToString()
            {
                string result = string.Format($"{this.Title} - {this.Content}: {this.Author}");
                return result;
            }

        }
    }
}
