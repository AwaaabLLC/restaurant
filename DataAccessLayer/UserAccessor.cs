using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserAccessor
    {
        public static List<User> GetUsers(string userName, string password)
        {
            List<User> userList = new List<User>();
            char[] separator = { ',' };
            try
            {

                StreamReader fileReader = new StreamReader(AppData.DataPath + @"\" + AppData.UsersFileName);

                while (fileReader.EndOfStream == false)
                {
                    string line = fileReader.ReadLine();
                    string[] parts;
                    if (line.Length > 24)
                    {
                        parts = line.Split(separator);
                        if (parts.Count() == 5)
                        {
                            User user = new User();
                            user.UserId = Convert.ToInt16(parts[0]);
                            user.UserName = parts[1];
                            user.Password = parts[2];
                            user.CellPhone = parts[3];
                            user.EmailAddress = parts[4];
                            userList.Add(user);
                        }

                    }
                }
                fileReader.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return userList;
        }
    }
}
