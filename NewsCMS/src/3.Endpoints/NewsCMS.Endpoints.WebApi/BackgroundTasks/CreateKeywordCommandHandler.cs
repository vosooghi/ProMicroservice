using Ground.Core.Contracts.ApplicationServices.Events;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Infra.Data.Sql.Queries.News.Entities;
using System.Data.SqlClient;

namespace NewsCMS.Endpoints.WebApi.BackgroundTasks
{
    public class CreateKeywordCommandHandler : IDomainEventHandler<KeywordCreated>
    {
        private readonly SqlConnection _sqlConnection = new SqlConnection("server=.;initial catalog = NewsCMSDb; user id=sa;password=P@ssw0rd;encrypt=false");
        private readonly INewsCommandRepository _repository;

        public Task Handle(KeywordCreated Event)
        {            
            using (_sqlConnection)
            {
                _sqlConnection.Open();
                Keyword keyword = new Keyword { KeywordTitle = Event.Title, KeywordBusinessId = Event.BusinessId };
                string cmd = $"INSERT INTO [dbo].[Keyword] ([KeywordBusinessId],[KeywordTitle])VALUES('{keyword.KeywordBusinessId}',N'{keyword.KeywordTitle}')";
                SqlCommand sqlCommand = new SqlCommand(cmd, _sqlConnection);
                sqlCommand.ExecuteNonQuery();                
            }
            return Task.CompletedTask;
        }


        //public override async Task<CommandResult<long>> Handle(CreateKeyword command)
        //{
        //    Keyword keyword = new Keyword {  KeywordTitle = command.Title, KeywordBusinessId=command.BusinessId};
        //    string cmd = $"INSERT INTO [dbo].[Keyword] ([KeywordBusinessId],[KeywordTitle])VALUES('{keyword.KeywordBusinessId}',N'{keyword.KeywordTitle}')";
        //    SqlCommand sqlCommand = new SqlCommand(cmd, _sqlConnection);
        //    sqlCommand.ExecuteNonQuery();
        //    return Ok(1);
        //}



    }
}
