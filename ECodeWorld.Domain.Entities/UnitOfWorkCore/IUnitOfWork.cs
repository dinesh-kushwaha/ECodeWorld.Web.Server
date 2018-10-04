using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Entities.UnitOfWorkCore
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
