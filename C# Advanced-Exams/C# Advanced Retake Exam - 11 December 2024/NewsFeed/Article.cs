namespace NewsFeed
{
    public class Article
    {
        public Article(string title, string author, int wordCount)
        {
            this.Title = title;
            this.Author = author;
            this.WordCount = wordCount;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public int WordCount { get; set; }

        public override string ToString()
        {
            return $"Article: '{Title}' by {Author} - {WordCount} words";
        }
    }
}
