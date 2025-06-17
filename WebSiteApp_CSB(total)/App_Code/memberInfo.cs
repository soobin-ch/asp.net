using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// memberInfo의 요약 설명입니다.
/// </summary>
public class memberInfo
{
	

    public string Name { get; set; }
    public string Nickname { get; set; }
    public string Phone { get; set; }
   
    public string birthDay { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public memberInfo() { }
    public memberInfo(string name, string nickname, string email, string birthDay, string phone,  string address)
    {
        Name = name;
        Nickname = nickname;
        Phone = phone;
        this.birthDay = birthDay;
        Email = email;
        Address = address;
    }
}
