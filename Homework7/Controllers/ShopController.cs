using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework7.Models;
using System.Data.SqlClient;

namespace Homework7.Controllers
{
    public class ShopController : Controller
    {
        //Create database link
        private SqlConnection DBConnection = new SqlConnection(DB.DBlink);
        //create new static list
        public static List<ShopItemViewModel> Items = new List<ShopItemViewModel>();
        //Declare variables
        double Price = 0.00;
        int Quantity = 0;

        // GET: Shop
        public ActionResult Index(string name, string description, string price, string quantity)
        {
            try
            {
                //convert parameters to correct format
                Price = Convert.ToDouble(price);
                Quantity = Convert.ToInt32(quantity);

                //check for empty submits and add to object and list if input is provided
                if (name != null && description != null && price != null && quantity != null)
                {
                    //create new object and add to the list
                    ShopItemViewModel newItem = new ShopItemViewModel(name, description, Price, Quantity);
                    Items.Add(newItem);
                }
            }
            catch (FormatException)
            {
                ViewBag.FormatException = "Price and Quantity needs to be a numeric value.";
                return View("addItem");
            }
            finally
            {
                if (price != null && quantity != null)
                {
                    //Error check if price is a value higher than 0
                    if (Price <= 0 || Quantity <= 0)
                    {
                        ViewBag.Error = "Price and Quantity needs to be a value greater than zero.";
                    }

                }
            }
            //create variable to count and store number of items in list
            int numberItems = Items.Count;
            //transfer number of items through viewbag
            ViewBag.Number = numberItems.ToString();

            return View(Items);
        }

        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult Part2()
        {
            return View();
        }

        //ActionResults created to use linq
        public ActionResult OrderByName()
        {
            Items = Items.OrderBy(Items => Items.MName).ToList();

            return RedirectToAction("Index");

        }

        public ActionResult SortByPrice()
        {
            Items = Items.OrderBy(Items => Items.MAmount).ToList();

            return RedirectToAction("Index");

        }

        public ActionResult SortByQuantity()
        {
            Items = Items.OrderByDescending(Items => Items.MAmount).ToList();

            return RedirectToAction("Index");

        }

        //Part 2 - Database
        //declare test variable for error handling on formatExceptions
        bool addToDatabse = true;

        public ActionResult AddToDB(string name, string description, string price, string quantity)
        {
            //declare test variable for error handling on formatExceptions
            int TestQuantity;
            double TestPrice;
           
            try
            {
                //convert parameters to correct format
                Price = Convert.ToDouble(price);
                Quantity = Convert.ToInt32(quantity);

                //Format Testing 
                TestQuantity = Quantity;
                TestPrice = Price;

            }
            catch (FormatException)
            {
                ViewBag.FormatException = "Price and Quantity needs to be a numeric value.";
                return View("Part2");
            }
            finally
            {
                try
                {
                    //Error check if price is a value higher than 0
                    if (Price <= 0 || Quantity <= 0)
                    {
                        ViewBag.Error = "Price and Quantity needs to be a value greater than zero.";
                        addToDatabse = false;
                    }

                    if (addToDatabse)
                    {
                        //insert values into DB using SqlCommand
                        SqlCommand newCommand = new SqlCommand("Insert into ShopItem VALUES('" + name + "','" + description + "','" + price + "','" + quantity + "')", DBConnection);
                        DBConnection.Open(); //close database connection
                        newCommand.ExecuteNonQuery(); //Execute insert
                    }
                   
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
                finally
                {
                    DBConnection.Close(); //close database connection
                }
            }

            return RedirectToAction("Part2");
        }
    }
}