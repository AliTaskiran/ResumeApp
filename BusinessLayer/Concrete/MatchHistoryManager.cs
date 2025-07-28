using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MatchHistoryManager : IMatchHistoryService
    {
        IMatchHistoryDal _matchHistoryDal;

        public MatchHistoryManager(IMatchHistoryDal matchHistoryDal)
        {
            _matchHistoryDal = matchHistoryDal;
        }

        public void TAdd(MatchHistory t)
        {
           _matchHistoryDal.Insert(t);
        }

        public void TDelete(MatchHistory t)
        {
           _matchHistoryDal.Delete(t);
        }

        public MatchHistory TGetById(int id)
        {
          return _matchHistoryDal.GetById(id);
        }

        public List<MatchHistory> TGetList()
        {
            return _matchHistoryDal.GetList();
        }

        public void TUpdate(MatchHistory t)
        {
           _matchHistoryDal.Update(t);
        }
    }
}
