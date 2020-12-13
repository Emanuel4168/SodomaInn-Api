using SodomaInn.Core.Dto;
using SodomaInn.Core.Utils;
using SodomaInn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodomaInn.Business.Managers
{
    public class UserManager
    {
        public UserDto LogIn(UserDto logInUser)
        {
            UserDto userData = null;
            try 
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    string passHash = HashUtility.ComputeSha256Hash(logInUser.PassWord);
                    Usuarios userDb = context.Usuarios.FirstOrDefault(u => u.Username == logInUser.Username && u.PassWord == passHash);
                    userData = ObjectMapper.Map<Usuarios, UserDto>(userDb);
                }
                return userData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SignIn(UserDto user)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    user.PassWord = HashUtility.ComputeSha256Hash(user.PassWord);
                    Usuarios usuario = ObjectMapper.Map<UserDto, Usuarios>(user);
                    context.Usuarios.Add(usuario);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
