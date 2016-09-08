using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;
using Progno.Model.Translator;

namespace Progno.Business
{
    public class UserLogic : BusinessBaseLogic<User, USER>
    {
        public UserLogic()
        {
            translator = new UserTranslator();
        }

        public bool ValidateUser(string Username, string Password)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == Username && p.Password == Password;
                User UserDetails = GetModelBy(selector);
                if (UserDetails != null && UserDetails.Password != null)
                {
                    UpdateLastLogin(UserDetails);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public bool UpdateLastLogin(User user)
        {
            try
            {
                Expression<Func<USER, bool>> selector = p => p.User_Name == user.Name && p.Password == user.Password;
                USER userEntity = GetEntityBy(selector);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

                userEntity.User_Name = user.Name;
                userEntity.Password = user.Password;
                userEntity.Role_Id = user.Role.Id;                
                userEntity.Last_Login_Date = DateTime.Now;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public User UpdateUser(User user)
        {
            try
            {
                USER userEntity = GetEntityBy(x => x.User_Id == user.Id);
                if (userEntity == null || userEntity.User_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }

    
                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public bool UpdateUserPassword(User user)
        //{
        //    try
        //    {
        //        USER userEntity = GetEntityBy(x => x.User_Id == user.Id);
        //        if (userEntity == null || userEntity.User_Id <= 0)
        //        {
        //            throw new Exception(NoItemFound);
        //        }

        //        userEntity.Password = user.Password;
        //        userEntity.Password_Changed = user.PasswordChanged;

        //        int modifiedRecordCount = Save();
        //        if (modifiedRecordCount <= 0)
        //        {
        //            throw new Exception(NoItemModified);
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //}

    }

}
