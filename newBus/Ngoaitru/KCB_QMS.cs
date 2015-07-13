using System;
using System.Data;
using System.Transactions;
using System.Linq;
using SubSonic;
using VNS.Libs;
using VNS.HIS.DAL;

using System.Text;

using SubSonic;
using NLog;

namespace VNS.HIS.BusRule.Classes
{
    public class KCB_QMS
    {
        private NLog.Logger log;
        public KCB_QMS()
        {
            log = LogManager.GetCurrentClassLogger();
        }
        public  int LaySoKhamQMS(string MaQuay, string MaKhoa,string madoituongkcb, int SoKham, int IsUuTien)
        {
            StoredProcedure sp = SPs.QmsLayso(MaQuay, MaKhoa,madoituongkcb, SoKham, IsUuTien);
            sp.Execute();
            return Utility.Int32Dbnull(sp.OutputValues[0]);
        }
    }
}
