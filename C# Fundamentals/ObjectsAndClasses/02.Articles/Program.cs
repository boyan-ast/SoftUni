using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Article article = new Article(articleData[0], articleData[1], articleData[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string modification = command[0];
                string newContent = command[1];

                ModifyTheArticle(article, modification, newContent);
            }

            Console.WriteLine(article);
        }

        private static void ModifyTheArticle(Article article, string action, string newContent)
        {
            switch (action)
            {
                case "Edit": article.Edit(newContent); break;
                case "ChangeAuthor": article.ChangeAuthor(newContent); break;
                case "Rename": article.Rename(newContent); break;
                default:
                    break;
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
