using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<Poruka> GetByType(TipPoruke tip);
        void ReadAll(List<string> ajdijevi);
        IQueryable<Poruka> GetAllUnread();
        IQueryable<Poruka> GetAll();

        void AddNotification(Poruka poruka);
    }
}
