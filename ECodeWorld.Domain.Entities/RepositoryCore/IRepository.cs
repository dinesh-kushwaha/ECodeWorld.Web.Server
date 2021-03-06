﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECodeWorld.Entities.RepositoryCore
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }

}
