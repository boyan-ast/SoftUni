using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> allArticles = new List<Article>(numberOfArticles);

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article article = new Article(articleData[0], articleData[1], articleData[2]);
                allArticles.Add(article);
            }

            string orderCriteria = Console.ReadLine();

            foreach (Article article in Article.Sort(allArticles, orderCriteria))
            {
                Console.WriteLine(article);
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
        
        public static List<Article> Sort(List<Article> articles, string criteria)
        {
            List<Article> resultList = new List<Article>(articles.Count);

            switch (criteria)
            {
                case "title": resultList = articles.OrderBy(x => x.Title).ToList(); break;
                case "content": resultList = articles.OrderBy(x => x.Content).ToList(); break;
                case "author": resultList = articles.OrderBy(x => x.Author).ToList(); break;
                default:
                    break;
            }

            return resultList;
        }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
