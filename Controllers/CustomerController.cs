using ORMAdonet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORMAdonet.Controllers
{
    public class CustomerController : Controller
    {
        private CRUD db = new CRUD();

        public object CustomerID { get; private set; }

        public ActionResult Index()
        {
            List<Customer> customerList = new List<Customer>();
            DataTable dtResult = db.GetAllCustomers();
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                Customer customer = new Customer(); //model
                customer.CustomerID = Convert.ToInt32(dtResult.Rows[i]["CustomerID"]);
                customer.FirstName = dtResult.Rows[i]["FirstName"].ToString();
                customer.LastName = dtResult.Rows[i]["LastName"].ToString();
                customer.CompanyName = dtResult.Rows[i]["CompanyName"].ToString();
                customer.EmailAddress = dtResult.Rows[i]["EmailAddress"].ToString();
                customer.Phone = dtResult.Rows[i]["Phone"].ToString();
                customerList.Add(customer);
            }
            return View(customerList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,CompanyName,EmailAddress,Phone")] Customer customer)
        {

            if (ModelState.IsValid)
            {
                int status = db.CreateCustomer(customer.CustomerID, customer.FirstName, customer.LastName, customer.CompanyName, customer.EmailAddress, customer.Phone);
                //int status = db.UpdateEmployee(employee.Id, employee.FirstName, employee.LastName, employee.Contact, employee.Email);
                ViewBag.StatusMessage = "Employee created successfully";
            }
            return RedirectToAction("Index");

        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            DataTable dt = db.GetCustomerById(id);
            Customer customer = new Customer();
            customer.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
            customer.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            customer.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            customer.CompanyName = Convert.ToString(dt.Rows[0]["Contact"]);
            customer.EmailAddress = Convert.ToString(dt.Rows[0]["EmailAddress"]);
            customer.Phone = Convert.ToString(dt.Rows[0]["Phone"]);
            // employee.Id = Convert.ToInt32(employee.Id);

            if (CustomerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (customer.CustomerID == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataTable dt = db.GetCustomerById(id);
            Customer customer = new Customer();
            customer.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
            customer.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
            customer.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
            customer.CompanyName = Convert.ToString(dt.Rows[0]["CompanyName"]);
            customer.EmailAddress = Convert.ToString(dt.Rows[0]["EmailAddress"]);
            customer.Phone = Convert.ToString(dt.Rows[0][""]);

            if (CustomerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (customer.CustomerID == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,CompanyName,EmailAddress,Phone")] Customer customer)
        {

            if (ModelState.IsValid)
            {
                int status = db.UpdateCustomer(customer.CustomerID, customer.FirstName, customer.LastName, customer.CompanyName, customer.EmailAddress, customer.Phone);

                ViewBag.Status = "Updated Employee details successfully";

            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            // CRUDModel model = new CRUDModel();
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
}
