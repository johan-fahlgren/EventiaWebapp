﻿using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class AdminService
    {
        private readonly UserManager<EventiaUser> _userManager;


        public AdminService(UserManager<EventiaUser> userManager)
        {
            _userManager = userManager;
        }


        public class userRoles
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public IEnumerable<string> Role { get; set; }
        }



        public async Task<List<userRoles>> GetUsers()
        {
            var userList = await _userManager.Users.ToListAsync();

            var userRoleList = new List<userRoles>();

            foreach (EventiaUser user in userList)
            {
                var input = new userRoles();
                input.Username = user.UserName;
                input.Email = user.Email;
                input.Role = await GetUserRoleAsync(user);
                userRoleList.Add(input);
            }


            userRoleList.Sort((user1, user2) =>
                string.Compare(user1.Role.First(), user2.Role.First()));

            return userRoleList;
        }


        private async Task<List<String>> GetUserRoleAsync(EventiaUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }


    }
}











