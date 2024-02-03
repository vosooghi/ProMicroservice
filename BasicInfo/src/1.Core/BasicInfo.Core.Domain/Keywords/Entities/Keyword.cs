using BasicInfo.Core.Domain.Keywords.Events;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Core.Domain.Entities;
using Ground.Core.Domain.Exceptions;
using System.Net;

namespace BasicInfo.Core.Domain.Keywords.Entities
{
    public class Keyword: AggregateRoot
    {
        #region Props
        public KeywordStatus Status { get; set; }
        public  KeywordTitle Title { get; set; }
        #endregion
        #region Ctors
        public Keyword(KeywordTitle keywordTitle)
        {
            Title = keywordTitle;
            Status = KeywordStatus.Preview;
            AddEvent(new KeywordCreated(BusinessId.Value, keywordTitle.Value));
        }
        private Keyword()
        {
            
        }
        #endregion

        #region Methods
        public void ChangeTitle(KeywordTitle keywordTitle)
        {
            if(Status== KeywordStatus.Inactive)
                throw new InvalidEntityStateException("Keyword's title in inactive state can not be changed.",nameof(ChangeTitle), nameof(KeywordStatus.Inactive));
            Title = keywordTitle;
            Status = KeywordStatus.Preview;
            AddEvent(new KeywordTitleChanged(BusinessId.Value, keywordTitle.Value));
        }
        public void Active()
        {
            if (Status == KeywordStatus.Active)
                throw new InvalidEntityStateException("Keyword is already Active.", nameof(Active), nameof(KeywordStatus.Active));
            
            Status = KeywordStatus.Active;
            AddEvent(new KeywordActivated(BusinessId.Value));
        }
        public void Inactive()
        {
            if (Status == KeywordStatus.Inactive)
                throw new InvalidEntityStateException("Keyword is already inactive.", nameof(Inactive), nameof(KeywordStatus.Inactive));

            Status = KeywordStatus.Inactive;
            AddEvent(new KeywordInactivated(BusinessId.Value));
        }
        #endregion
    }
}
