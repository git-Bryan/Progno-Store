using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;
using Progno.Model.Translator;

namespace Progno.Business
{
    public class PersonLogic : BusinessBaseLogic<Person, PERSON>
    {
        public PersonLogic()
        {
            translator = new PersonTranslator();
        }

        public bool ModifyPerson(Person Person)
        {
            try
            {
                PERSON entity = GetEntityBy(x => x.Person_Id == Person.Id);
                if (entity != null)
                {


                    if (Person.Initial != null)
                    {
                        entity.Initial = Person.Initial;
                    }
                   
                    if (Person.ImageFileUrl != null)
                    {
                        entity.Image_File_Url = Person.ImageFileUrl;
                    }
                    if (Person.Sex.Id != null)
                    {
                        entity.Sex_Id = Person.Sex.Id;
                    }
                    if (Person.ContactAddress != null)
                    {
                        entity.Contact_Address = Person.ContactAddress;
                    }
                    if (Person.Email != null)
                    {
                        entity.Email = Person.Email;
                    }
                    if (Person.MobilePhone != null)
                    {
                        entity.Mobile_Phone = Person.MobilePhone;
                    }
                    if (Person.DateOfBirth != null)
                    {
                        entity.Date_Of_Birth = Person.DateOfBirth;
                    }
                    if (Person.Nationality.Id != null)
                    {
                        entity.Nationality_Id = Person.Nationality.Id;
                    }
                    if (Person.State.Id != null)
                    {
                        entity.State_Id = Person.State.Id;
                    }
                    if (Person.LocalGovernment.Id != null)
                    {
                        entity.Local_Government_Id = Person.LocalGovernment.Id;
                    }
                    if (Person.Religion.Id != null)
                    {
                        entity.Religion_Id = Person.Religion.Id;
                    }
                    if (Person.HomeTown != null)
                    {
                        entity.Home_Town = Person.HomeTown;
                    }
                    if (Person.HomeAddress != null)
                    {
                        entity.Home_Address = Person.HomeAddress;
                    }
                    
                   
                    Save();
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
