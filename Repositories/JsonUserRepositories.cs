using BlackJack.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BlackJack.Repositories
{
    public class JsonUserRepositories
    {
        private readonly string UserJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Users.json");

        public List<User> GetAll()
        {
            // Ensure the directory exists
            string directory = Path.GetDirectoryName(UserJsonPath)!;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Check if the file exists; if not, return an empty list
            if (!File.Exists(UserJsonPath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(UserJsonPath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void SaveAll(List<User> users)
        {
            // Ensure the directory exists
            string directory = Path.GetDirectoryName(UserJsonPath)!;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UserJsonPath, json);
        }

        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            SaveAll(users);
        }
    }
}