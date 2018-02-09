using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookProject.Models
{
  public class Contact
  {
    private string _name;
    private string _phoneNumber;
    private string _address;
    private int _id;

    private static List<Contact> _contacts = new List<Contact>();

    public void SetName(string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
      _phoneNumber = phoneNumber;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public void SetAddress(string address)
    {
      _address = address;
    }

    public string GetAddress()
    {
      return _address;
    }

    public void Save()
    {
      _contacts.Add(this);
      _id = _contacts.Count;
    }

    public int GetId()
    {
      return _id;
    }

    public static void RemoveItem(int id)
    {
      _contacts.RemoveAt(id-1);
      // Resets the id value for each contact in the contacts list
      for (int i = 0; i < _contacts.Count; i++)
      {
        _contacts[i]._id = i+1;
      }
    }

    public static List<Contact> GetContacts()
    {
      return _contacts;
    }

    public static Contact Find(int id)
    {
      return _contacts[id-1];
    }

    public static void ClearContacts()
    {
      _contacts.Clear();
    }
  }
}
