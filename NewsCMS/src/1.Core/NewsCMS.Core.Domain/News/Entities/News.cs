using Ground.Core.Domain.Entities;
using Ground.Core.Domain.Toolkits.ValueObjects;
using Ground.Core.Domain.ValueObjects;
using NewsCMS.Core.Domain.News.Events;

namespace NewsCMS.Core.Domain.News.Entities
{
    public class News: AggregateRoot
    {
        #region Props
        public Title Title { get;private set; }
        public Description Description { get; private set; }
        public string Body { get; private set; }
        private readonly List<NewsKeywords> _newsKeywords = new List<NewsKeywords>();
        public IReadOnlyList<NewsKeywords> NewsKeywords=>_newsKeywords;
        #endregion

        #region Ctors
        private News()
        {
            
        }
        public News(Title title,Description description,string body, List<NewsKeywords> newsKeywords)
        {            
            Title = title;
            Description = description;
            Body = body;
            _newsKeywords.AddRange(newsKeywords);
            AddEvent(new NewsCreated(BusinessId.Value,title.Value,description.Value,body,string.Join(';',newsKeywords.Select(w=>w.KeywordBusinessId).ToList())));
        }
        #endregion
    }
}
