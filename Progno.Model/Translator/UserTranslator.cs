using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
  public  class UserTranslator : BaseTranslator<User, USER>
  {
      private RoleTranslator roleTranslator;

      public UserTranslator()
      {
          roleTranslator = new RoleTranslator();
      }

      public override User TranslateToModel(USER entity)
      {
          try
          {
              User model = null;
              if (entity != null)
              {
                  model = new User();
                  model.Id = entity.User_Id;
                  model.Name = entity.User_Name;
                  model.Password = entity.Password;
                  model.Email = entity.Email;
                  model.Image = entity.Image_File_Url;
                  model.Role = roleTranslator.TranslateToModel(entity.ROLE);
                  model.LastLogin = entity.Last_Login_Date;
              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override USER TranslateToEntity(User model)
      {
          try
          {
              USER entity = null;
              if (model != null)
              {
                  entity = new USER();
                  entity.User_Id = model.Id;
                  entity.User_Name = model.Name;
                  entity.Password = model.Password;
                  entity.Role_Id = model.Role.Id;
                  entity.Email = model.Email;
                  entity.Image_File_Url = model.Image;
                  entity.Last_Login_Date = model.LastLogin;
                  
              }
              return entity;
          }
          catch (Exception)
          {
              
              throw;
          }
      }
  }
}
