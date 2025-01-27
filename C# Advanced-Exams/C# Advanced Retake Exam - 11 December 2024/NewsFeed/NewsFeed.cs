using System.Text;

namespace NewsFeed
{
    public class NewsFeed
    {
        public NewsFeed(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Articles = new List<Article>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Article> Articles { get; set; }

        //Method for adding an article if the capacity allows it and if it's not already in the list
        public void AddArticle(Article article)
        {

            if (Articles.Count < Capacity && !Articles.Exists(a => a.Title == article.Title))
                Articles.Add(article);

        }

        //Method that returns boolean and delete the article if it exists
        public bool DeleteArticle(string title)
        {
            if (Articles.Exists(a => a.Title == title))
            {
                Articles.Remove(Articles.Find(a => a.Title == title));
                return true;
            }

            return false;

        }

        //Method that returns the shortest WordCount article
        public Article GetShortestArticle()
        {

            return Articles.OrderBy(a => a.WordCount).FirstOrDefault();

        }

        //Method that return details about given article title if it exists
        public string GetArticleDetails(string title)
        {
          
            if (!Articles.Exists(a => a.Title == title))
                return $"Article with title '{title}' not found.";

            return Articles.Find(a => a.Title == title).ToString();

        }

        //Returns the count of all added articles
        public int GetArticlesCount()
        {
            return Articles.Count;
        }

        //Returns string report of all added articles
        public string Report()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{Name} newsfeed content:");
            foreach (var article in Articles.OrderBy(a => a.WordCount))
            {
                builder.AppendLine($"{article.Author}: {article.Title}");
            }

            return builder.ToString().Trim();
        }
    }
}
