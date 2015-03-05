using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Store.Disbursement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Controller
{
    public class DisbursementController
    {
        List<RequestByDept> list = new List<RequestByDept>();
        List<Request> lireq = new List<Request>();
        DisbursementList createDisb = new DisbursementList();

        //for binding into Representative Name and Collection Point according to Department 
        public Department getDepartmentData(string deptName)
        {
            var q = from dp in EntityBroker.getMyEntities().Departments
                    where dp.name == deptName
                    select dp;
            Department m = q.First<Department>();
            return m;
        }

        //for binding Delivery Date according to Department
        public DateTime getDeliveryDate(String deptName)
        {
            var date = from d in EntityBroker.getMyEntities().DisbursementLists
                       join dp in EntityBroker.getMyEntities().Departments on d.deptCode equals dp.code
                       where dp.code == deptName
                       select d.deliveryDate;
            DateTime dt = date.First<DateTime>();
            return dt;
        }

        public string getDeptBySession(string dept)
        {
            var deptName = from x in EntityBroker.getMyEntities().Departments
                           where x.code == dept
                           select x;
            Department deptname = deptName.FirstOrDefault();
            if (deptname != null)
            {
                string deptm = deptname.name;
                return deptm;
            }
                string message = "Error!";
                return message;
            
        }

        public List<RequestByDept> getApprovedReq(string dept)
        {
            var data = (from x in EntityBroker.getMyEntities().Requests
                        where x.deptCode == dept && x.status == "Approved"
                        join rd in EntityBroker.getMyEntities().RequestDetails on x.id equals rd.requestID
                        join d in EntityBroker.getMyEntities().Departments on x.deptCode equals d.code
                        join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                        group new { x, d, rd, s } by new { rd.stationeryCode, d.name, x.dateOfApp, s.description, rd.actualQuantity, rd.neededQuantity } into g
                        select new RequestByDept() { Name = g.Key.name, StationeryCode = g.Key.stationeryCode, Description = g.Key.description, DateOfApp = g.Key.dateOfApp.Value, NeededQuantity = g.Sum(y => y.rd.neededQuantity) }).Distinct();
            var result = (from row in data
                          select new RequestByDept() { Name = row.Name, StationeryCode = row.StationeryCode, Description = row.Description, DateOfApp = row.DateOfApp, NeededQuantity = data.Where(y => y.StationeryCode == row.StationeryCode).Sum(y => y.NeededQuantity) }).Distinct();
            return list = result.ToList();
        }


        public bool createDisbList(string dept, string clerk, string XOL, string delivDate)
        {
            var item = from dep in EntityBroker.getMyEntities().Departments
                       where dep.code == dept
                       join coll in EntityBroker.getMyEntities().CollectionPoints on XOL equals coll.place
                       select coll;
            CollectionPoint i = item.FirstOrDefault();

           // create new row in disbursementlist
            using (EntityBroker.getMyEntities())
            {
                createDisb.clerkEmpNo = clerk;
                createDisb.deptCode = dept;
                if (!string.IsNullOrEmpty(delivDate))
                {
                    createDisb.deliveryDate = Convert.ToDateTime(delivDate);
                }
                else
                {
                    return false;
                }
                createDisb.collectionPt = i.id;
                EntityBroker.getMyEntities().DisbursementLists.Add(createDisb);
                EntityBroker.getMyEntities().SaveChanges();
            
                //update in request table
                var update = (from x in EntityBroker.getMyEntities().Requests
                              where x.deptCode == dept && x.status == "Approved"
                              select x).Distinct();
                List<Request> lireq = update.ToList();
                if (lireq != null)
                {
                    foreach (var l in lireq)
                    {
                        l.status = "Accepted";
                        l.deliveryID = createDisb.id;
                        l.lastUpdate = DateTime.Now;
                    }
                    EntityBroker.getMyEntities().SaveChanges();
                    return true;
                }

            } return true;
        }

    }
}