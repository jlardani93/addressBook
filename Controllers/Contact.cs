using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddressBookProject.Models;

namespace AddressBookProject.Controllers
{
  public class ContactController : Controller
  {

    [HttpGet("/Contact/Form")]
    public ActionResult Form()
    {
      return View();
    }

    [HttpPost("/Contact/Create")]
    public ActionResult Create()
    {
      Contact myContact = new Contact();
      myContact.SetName(Request.Form["name"]);
      myContact.SetAddress(Request.Form["address"]);
      myContact.SetPhoneNumber(Request.Form["phoneNumber"]);
      myContact.Add();
      return View(myContact);
    }

    [HttpGet("/Contact/Display")]
    public ActionResult Display()
    {
      List<Contact> myContacts = Contact.GetContacts();
      return view(myContacts);
    }

    [HttpGet("/Contact/Info/{id}")]
    public ActionResult Info(int id)
    {
      Contact myContact = Contact.Find(id);
      return View("Create", myContact);
    }

    [HttpGet("/Contact/Clear")]
    public ActionResult Clear()
    {
      Contact.ClearContacts();
      return RedirectToAction("Display"); 
    }
  }
}
