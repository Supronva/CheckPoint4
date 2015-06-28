using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel;

namespace DALClassLibrary.DAL
{
    public class Product
    {
        private DBServiceEntities _dbServiceEntities = new DBServiceEntities();

        public string Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }

        public Products ConvertToEntity()
        {
            if (_dbServiceEntities != null)
            {
                var entity = _dbServiceEntities.Products.FirstOrDefault(x => x.name == Name);
                if (entity != null)
                {
                    return entity;
                }
            }

            Mapper.CreateMap<Product, Products>();
            return Mapper.Map<Product, Products>(this);
        }
    }
}
