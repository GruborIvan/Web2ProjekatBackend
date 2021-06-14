using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Service
{
    public interface IWebService
    {
        bool addEntity(object entity);
        List<object> getEntities(TipEntiteta tip);
        bool updateEntity(object entity);
        bool deleteEntity(object entity);
        object getEntity(TipEntiteta tip, string id);
    }
}
