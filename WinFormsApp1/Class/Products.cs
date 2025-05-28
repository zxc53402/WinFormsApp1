using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Class
{
    internal class Products
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public string? UnitPrice { get; set; }
        public string? UnitsInStock { get; set; }
        public string? UnitsOnOrder { get; set; }
        public string? ReorderLevel { get; set; }
        public string? Discontinued { get; set; }                
    }
    internal class Category
    {
        public string? CategoryID { get; set;}
        public string? CategoryName { get; set;}        
    }
    internal class Orders
    {
        public string? OrderID { get; set; }
        public string? CompanyName { get; set; }
        public string? EmployeeName { get; set; }
        public string? OrderDate { get; set; }
        public string? RequiredDate { get; set; }
        public string? ShipName { get; set; }
        
    }
    internal class Suppliers1
    {
        public string? SupplierID { get;set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }


    }
    internal class Customers
    {
        public string? CustomerID { get;set;}
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
     
    }
    
    internal class Products2
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public string? UnitPrice { get; set; }
        public string? UnitsInStock { get; set; }
        public string? ReorderLevel { get; set; }
        public string? Discontinued { get; set; }
        
    }
    internal class Employees
    {
        public string? EmployeeID { get; set;}
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public string? BirthDate { get; set; }
        public string? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

    }
     





}
