using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel;

namespace DALClassLibrary.DAL
{
    public class Manager
    {
        private readonly ModelContainer _dbServiceEntities = new ModelContainer();

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Manager(string firstname,string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public Managers ConvertToEntity()
        {
            if (_dbServiceEntities != null)
            {
                var entity =
                    _dbServiceEntities.Managers.FirstOrDefault(x => x.firstname == FirstName && x.lastname == LastName);
                if (entity != null)
                {
                    return entity;
                }
            }
            Mapper.CreateMap<Manager, Managers>();
            var manager = Mapper.Map<Manager, Managers>(this);
            if (_dbServiceEntities == null) return manager;
            _dbServiceEntities.Managers.Add(manager);
            _dbServiceEntities.SaveChangesAsync();
            return manager;
        }
    }
}
