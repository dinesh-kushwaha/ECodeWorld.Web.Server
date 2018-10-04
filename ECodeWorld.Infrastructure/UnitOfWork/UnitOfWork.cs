//using ECodeWorld.Entities.UnitOfWorkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Infrastructure.UnitOfWork
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private static readonly ISessionFactory _sessionFactory;
    //    private ITransaction _transaction;

    //    public ISession Session { get; private set; }

    //    static UnitOfWork()
    //    {
    //        // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
    //        // application lifetime - the first time the UnitOfWork class is used
    //        _sessionFactory = Fluently.Configure()
    //            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("UnitOfWorkExample")))
    //            .Mappings(x => x.AutoMappings.Add(
    //                AutoMap.AssemblyOf<Product>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<ProductOverrides>()))
    //            .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
    //            .BuildSessionFactory();
    //    }

    //    public UnitOfWork()
    //    {
    //        Session = _sessionFactory.OpenSession();
    //    }

    //    public void BeginTransaction()
    //    {
    //        _transaction = Session.BeginTransaction();
    //    }

    //    public void Commit()
    //    {
    //        try
    //        {
    //            // commit transaction if there is one active
    //            if (_transaction != null && _transaction.IsActive)
    //                _transaction.Commit();
    //        }
    //        catch
    //        {
    //            // rollback if there was an exception
    //            if (_transaction != null && _transaction.IsActive)
    //                _transaction.Rollback();

    //            throw;
    //        }
    //        finally
    //        {
    //            Session.Dispose();
    //        }
    //    }

    //    public void Rollback()
    //    {
    //        try
    //        {
    //            if (_transaction != null && _transaction.IsActive)
    //                _transaction.Rollback();
    //        }
    //        finally
    //        {
    //            Session.Dispose();
    //        }
    //    }
    //}
}
