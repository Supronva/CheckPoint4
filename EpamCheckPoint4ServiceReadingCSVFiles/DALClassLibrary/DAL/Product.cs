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
        private readonly ModelContainer _dbServiceEntities = new ModelContainer();

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
            var product = Mapper.Map<Product, Products>(this);
            if (_dbServiceEntities == null) return product;
            _dbServiceEntities.Products.Add(product);
            _dbServiceEntities.SaveChanges();
            return product;
        }
    }
}
