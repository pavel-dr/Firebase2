using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User 
{
    public string username;
    public string email;
    public string lastModify;
    public List<string> testlist;
    public List<string> testlist2;
    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
        lastModify = System.DateTime.Now.ToString();
        //testlist = new List<string>() { "t1", "t2", "t2", "t2" };
        //testlist2 = new List<string>() { "tww1", "tqwqe2", "tqwqew2" };
    }
}
