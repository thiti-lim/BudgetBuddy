using BudgetBuddy.Data;
using BudgetBuddy.Data.DomainModels;
using Microsoft.Identity.Web;

namespace BudgetBuddy.Repositories
{
	public class JobRepository
	{
		private readonly ISqlDataAccess db;
		private string currentUserId;

		public JobRepository(ISqlDataAccess db, IHttpContextAccessor contextAccessor)
		{
			this.db = db;
			currentUserId = contextAccessor.HttpContext?.User.GetObjectId() ?? "00000000-0000-0000-0000-000000000000";
		}

		public Task<IEnumerable<Job>> GetJobs()
        {
			string sql = $"SELECT * FROM Job WHERE UserId = {currentUserId}";
			return db.LoadData<Job, dynamic>(sql, new {}); 
        }

		public Task InsertJob(Job job)
		{
			job.UserId = currentUserId;

			string sql = @"INSERT INTO Customer (UserId, CustomerName) VALUES (@UserId, @JobName);";
			return db.SaveData(sql, job);
		}
	}
}
