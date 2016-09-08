using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
  public  class PersonTranslator :BaseTranslator<Person, PERSON>
  {
     
      private SexTranslator sexTranslator;
      private LocalGovernmentTranslator localGovernmentTranslator;
      private NationalityTranslator nationalityTranslator;
      private ReligionTranslator religionTranslator;
      private StateTranslator stateTranslator;
      

      public PersonTranslator()
      {
         
          sexTranslator = new SexTranslator();
          localGovernmentTranslator = new LocalGovernmentTranslator();
          nationalityTranslator = new NationalityTranslator();
          religionTranslator = new ReligionTranslator();
          stateTranslator = new StateTranslator();
      }
      public override Person TranslateToModel(PERSON entity)
      {
          try
          {
              Person model = null;
              if (entity != null)
              {
                  model= new Person();
                  model.Id = entity.Person_Id;
                  model.ContactAddress = entity.Contact_Address;
                 model.FirstName = entity.First_Name;
                  model.LastName = entity.Last_Name;
                  model.Initial = entity.Initial;
                  model.Title = entity.Title;
                  model.ImageFileUrl = entity.Image_File_Url;
                  model.Email = entity.Email;
                  model.HomeTown = entity.Home_Town;
                  model.HomeAddress = entity.Home_Address;
                  model.MobilePhone = entity.Mobile_Phone;
                  model.OtherName = entity.Other_Name;
                  model.Sex = sexTranslator.TranslateToModel(entity.SEX);
                  model.DateOfBirth = entity.Date_Of_Birth;
                  model.LocalGovernment = localGovernmentTranslator.TranslateToModel(entity.LOCAL_GOVERNMENT);
                  model.Nationality = nationalityTranslator.TranslateToModel(entity.NATIONALITY);
                  model.Religion = religionTranslator.TranslateToModel(entity.RELIGION);
                  model.State = stateTranslator.TranslateToModel(entity.STATE);
                  model.DateRegistered = entity.Date_Entered;
              }
              return model;
          }
          catch (Exception)
          {
                
              throw;
          }
      }

      public override PERSON TranslateToEntity(Person model)
      {
          try
          {
              PERSON entity = null;
              if (model != null)
              {
                  entity = new PERSON();
                  entity.Person_Id = model.Id;
                  entity.Contact_Address = model.ContactAddress;
                 
                  if (model.LocalGovernment != null)
                  {
                      entity.Local_Government_Id = model.LocalGovernment.Id;
                  }
                  if (model.Nationality != null)
                  {
                      entity.Nationality_Id = model.Nationality.Id;
                  }
                  if (model.Religion != null)
                  {
                      entity.Religion_Id = model.Religion.Id;
                  }

                  if (model.State != null)
                  {
                      entity.State_Id = model.State.Id;
                  }
                  if (model.Sex != null)
                  {
                      entity.Sex_Id = model.Sex.Id;
 
                  }
                  entity.Title = model.Title;
                  entity.Date_Entered = model.DateRegistered;
                  entity.Initial = model.Initial;
                  entity.Home_Town = model.HomeTown;
                  entity.Home_Address = model.HomeAddress;
                  entity.Image_File_Url = model.ImageFileUrl;
                  entity.Email = model.Email;
                  entity.First_Name = model.FirstName;
                  entity.Last_Name = model.LastName;
                  entity.Mobile_Phone = model.MobilePhone;
                  entity.Other_Name = model.OtherName;
                  entity.Date_Of_Birth = model.DateOfBirth;
                       
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
