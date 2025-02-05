using MVCTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace MVCTask.Controllers
{
    public class RegistrationController : Controller
    {

        [HttpGet]   // GET: Registration
        public ActionResult Index()
        {
            User objU = new User();
            BALUser objBal = new BALUser();
            DataSet dsReg = new DataSet();
            dsReg = objBal.ShowDetails();
            List<User> lstUser2 = new List<User>();
            for (int i = 0; i < dsReg.Tables[0].Rows.Count; i++)
            {
                User obj2 = new User();
                obj2.Id = Convert.ToInt32(dsReg.Tables[0].Rows[i]["ID"].ToString());
                obj2.Name = dsReg.Tables[0].Rows[i]["Name"].ToString();
                obj2.address = dsReg.Tables[0].Rows[i]["Address"].ToString();
                obj2.Email = dsReg.Tables[0].Rows[i]["EmailID"].ToString();
                obj2.MobileNo = dsReg.Tables[0].Rows[i]["MobileNo"].ToString();
                obj2.Gender = dsReg.Tables[0].Rows[i]["Gender"].ToString();
                obj2.Country = dsReg.Tables[0].Rows[i]["CountryName"].ToString();
                obj2.State = dsReg.Tables[0].Rows[i]["StateName"].ToString();
                obj2.City = dsReg.Tables[0].Rows[i]["CityName"].ToString();
                //obj2.CityId = Convert.ToInt32(dsReg.Tables[0].Rows[i]["CityID"].ToString());
                lstUser2.Add(obj2);

            }
            objU.lstUser = lstUser2;


            return View(objU);
            // return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            User objU = new User();
            BALUser objBal = new BALUser();
           

            //FetchCountry
            var dsCountry = objBal.FetchCountry();
            var CountryList = new List<SelectListItem>();
            if (dsCountry != null && dsCountry.Tables.Count > 0)
            {
                foreach (DataRow row in dsCountry.Tables[0].Rows)
                {

                    CountryList.Add(new SelectListItem
                    {
                        Value = row["CountryID"].ToString(),
                        Text = row["CountryName"].ToString()
                    });
                }
            }
            ViewBag.CountryList = CountryList;
            return View(objU);
           // return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            BALUser objShow = new BALUser();
            SqlDataReader dr;
            dr = objShow.GetDetails(id);
            User obj2 = new User();
            while (dr.Read())
            {
                obj2.Id = Convert.ToInt32(dr["ID"].ToString());
                obj2.Name = dr["Name"].ToString();
                obj2.address= dr["Address"].ToString();
                obj2.Email = dr["EmailId"].ToString();
                obj2.MobileNo = dr["MobileNo"].ToString();
                obj2.Gender = dr["Gender"].ToString();
                obj2.Country = dr["CountryName"].ToString();
                obj2.State = dr["StateName"].ToString();
                obj2.City = dr["CityName"].ToString();

            }
            dr.Close();
            return PartialView("Details",obj2 );
        }

        [HttpPost]
        public ActionResult Register(User objU)
        {
            BALUser objBal = new BALUser();
            objBal.SaveData(objU);
            return RedirectToAction("Register");

        }


        [HttpGet]
        public JsonResult FecthState(int CountryId)
        {
            BALUser objBal = new BALUser();
            var ds = objBal.FetchState(CountryId);
            var stateList = new List<SelectListItem>();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    stateList.Add(new SelectListItem

                    {
                        Value = row["StateID"].ToString(),
                        Text = row["StateName"].ToString()
                    });
                }
            }
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FecthCity(int StateId)
        {
            BALUser objBal = new BALUser();
            var ds = objBal.FetchCity(StateId);
            var CityList = new List<SelectListItem>();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    CityList.Add(new SelectListItem
                    {
                        Value = row["CityID"].ToString(),
                        Text = row["CityName"].ToString()
                    });
                }
            }
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]

        public ActionResult Delete(int Id) 
        {
            BALUser objDelete = new BALUser();
            objDelete.Delete(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id) 
        {
            User obj = new User();
            BALUser objUpdate = new BALUser();
            SqlDataReader dr;
            dr = objUpdate.EditDetails(Id);
            while (dr.Read()) 
            {
               // obj.Id= Convert.ToInt32(dr["id"].ToString());
                obj.Id = Convert.ToInt32(dr["ID"].ToString());
                obj.Name = dr["Name"].ToString();
                obj.address = dr["Address"].ToString();
                obj.Email = dr["EmailId"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.Gender = dr["Gender"].ToString();
                obj.CityId = Convert.ToInt32(dr["CityID"].ToString());
                obj.CountryId = Convert.ToInt32(dr["CountryID"].ToString());
                obj.StateId = Convert.ToInt32(dr["StateID"].ToString());

            }

            var dsCountry = objUpdate.FetchCountry();
            var CountryList = new List<SelectListItem>();
            if (dsCountry != null && dsCountry.Tables.Count > 0)
            {
                foreach (DataRow row in dsCountry.Tables[0].Rows)
                {
                    CountryList.Add(new SelectListItem
                    {
                        Value = row["CountryID"].ToString(),
                        Text = row["CountryName"].ToString()
                    });
                }
            }

            ViewBag.CountryList = CountryList;

            

            return View(obj);
        }

        [HttpPost]

        public ActionResult Edit(User obj)
        {
            BALUser objEdit = new BALUser();
            objEdit.UpdateData(obj);
            return RedirectToAction("Index");

        }



    }
}