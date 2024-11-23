using System.ComponentModel.DataAnnotations;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] articleDatas = input.Split(", ");
            Article article = new Article(articleDatas[0], articleDatas[1], articleDatas[2]);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] datas = input.Split(": ");
                switch (datas[0])
                {
                    case "Edit":
                        article.Edit(datas[1]);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(datas[1]);
                        break;

                    case "Rename":
                        article.Rename(datas[1]);
                        break;
                }
            }
            Console.WriteLine(article.ToString());

        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
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


