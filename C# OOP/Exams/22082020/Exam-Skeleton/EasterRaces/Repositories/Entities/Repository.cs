﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public abstract T GetByName(string name);     

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
