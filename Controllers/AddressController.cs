using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Data;
    
namespace WebApplication2.Controllers
{
    public class AddressController : Controller
    {
        public ActionResult Index()
        {
            return View("AddressView");
        }
        public ActionResult NewAddress()
        {
            ViewData["States"] = GetStates();
            ViewData["Countries"] = GetCountries();
            return View("AddressView");
        }

        public ActionResult AddressList()
        {
            List<Address> AddressList = new List<Address>();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetAddressList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Address Ad = new Address();
                    Ad.Id = Convert.ToInt32(dr["Id"]);
                    Ad.HouseNo = Convert.ToInt32(dr["HouseNo"]);
                    Ad.StreetName = dr["StreetName"].ToString();
                    Ad.City = dr["City"].ToString();
                    Ad.State = dr["State"].ToString();
                    Ad.Country = dr["Country"].ToString();
                    Ad.Zipcode = Convert.ToInt32(dr["Zipcode"]);
                    AddressList.Add(Ad);
                }
            }
            return View("AddressList",AddressList);
        }

        public ActionResult Edit(int id)
        {
            ViewData["States"] = GetStates();
            ViewData["Countries"] = GetCountries();
            Address address = new Address();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetAddress(id);
            if (dt.Rows.Count > 0)
            {
                address.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                address.HouseNo = Convert.ToInt32(dt.Rows[0]["HouseNo"]);
                address.StreetName = dt.Rows[0]["StreetName"].ToString();
                address.City = dt.Rows[0]["City"].ToString();
                address.State = dt.Rows[0]["State"].ToString();
                address.Country = dt.Rows[0]["Country"].ToString();
                address.Zipcode = Convert.ToInt32(dt.Rows[0]["Zipcode"]);
            }
            return View("AddressView", address);

        }
 
        public ActionResult Update(Address address)
        {
            DbAccess db = new DbAccess();
            if (ModelState.IsValid)
            {
                if (address.Id==0)
                    db.SaveAddress(address, true);
                else
                    db.SaveAddress(address, false);
                return RedirectToAction("AddressList", "Address");
            }
            else
            {
                return View("AddressView", address);
            }
                
        }
        public ActionResult delete(int id)
        {
            DbAccess db = new DbAccess();
            db.DeleteAddress(id);
            return RedirectToAction("AddressList", "Address");
        }

        public List<State> GetStates()
        {
            List<State> states = new List<State>();
            states.Add(new State { Id = 0, StateName = "--Select--" });
            states.Add(new State { Id = 1, StateName = "Karnataka" });
            states.Add(new State { Id = 2, StateName = "Andhra Pradesh" });
            states.Add(new State { Id = 3, StateName = "Maharashtra" });
            states.Add(new State { Id = 4, StateName = "Tamil Nadu" });
            return states;
        }
        public List<Country> GetCountries()
        {
            List<Country> Countries = new List<Country>();
            Countries.Add(new Country { Id = 0, CountryName = "--Select--" });
            Countries.Add(new Country { Id = 1, CountryName = "India" });
            Countries.Add(new Country { Id = 2, CountryName = "UK" });
            Countries.Add(new Country { Id = 3, CountryName = "SriLanka" });
            Countries.Add(new Country { Id = 4, CountryName = "USA" });
            return Countries;
        }
    }
}