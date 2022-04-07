using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class AdminService
    {

        private readonly EventiaDbContext _dbContext;


        public AdminService(EventiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EventiaUser>> GetUsers()
        {
            var userList = await _dbContext.Users
                .ToListAsync();

            userList.Sort((username1, username2) =>
                string.Compare(username1.UserName, username2.UserName));

            return userList;
        }

    }
}


