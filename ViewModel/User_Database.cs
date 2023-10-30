﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class User_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;

            user.ID = int.Parse(reader["Id"].ToString());
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.Email = reader["Email"].ToString();
            user.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            user.Gender = reader["Gender"].ToString();
            user.PhoneNumber = reader["PhoneNumber"].ToString();
            user.PermissionLevel = int.Parse(reader["PermissionLevel"].ToString());
            user.Password = reader["Password"].ToString();

            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM User_Table";
            UserList userList = new UserList(ExecuteCommand());
            return userList;
        }

        public User SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM User_Table WHERE Id=" + Id;
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }

            return userList[0];
        }
    }
}
