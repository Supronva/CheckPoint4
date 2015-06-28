using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel;

namespace DALClassLibrary.DAL
{
   public class Client
    {
       DBServiceEntities _dbServiceEntities = new DBServiceEntities();

       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int Age { get; set; }

       public Client(string firstname, string lastname, int age)
       {
           FirstName = firstname;
           LastName = lastname;
           Age = age;
       }

       public Clients ConvertToEntity()
       {
           if (_dbServiceEntities != null)
           {
               var entity =
                   _dbServiceEntities.Clients.FirstOrDefault(
                       x => x.firstname == FirstName && x.lastname == LastName && x.age == Age);
               if (entity != null)
               {
                   return entity;
               }
           }

           Mapper.CreateMap<Client, Clients>();
           return Mapper.Map<Client, Clients>(this);
       }
    }
}
