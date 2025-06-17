using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MemberDo의 요약 설명입니다.
/// </summary>
public class MemberDo
{
	private string userid;
	private string passwd;

	private string name;
	private string nickname;


	private string email;

	private string birthday;

	private string phone;

	private string address;
	private string joindate;

    private bool status;

    private int upgrade;

    public MemberDo(string userid, string passwd, string name, string nickname, string email, string birthday, string phone, string address)
    {
        this.userid = userid;
        this.passwd = passwd;
        this.name = name;
        this.nickname = nickname;
        this.email = email;
        this.birthday = birthday;
        this.phone = phone;
        this.address = address;
  
    }


    public MemberDo()
    {
    }

    public string Userid
    {
        get
        {
            return userid;
        }

        set
        {
            userid = value;
        }
    }

    public string Passwd
    {
        get
        {
            return passwd;
        }

        set
        {
            passwd = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Nickname
    {
        get
        {
            return nickname;
        }

        set
        {
            nickname = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Birthday
    {
        get
        {
            return birthday;
        }

        set
        {
            birthday = value;
        }
    }

    public string Phone
    {
        get
        {
            return phone;
        }

        set
        {
            phone = value;
        }
    }

    public string Address
    {
        get
        {
            return address;
        }

        set
        {
            address = value;
        }
    }

    public string Joindate
    {
        get
        {
            return joindate;
        }

        set
        {
            joindate = value;
        }
    }

    public bool Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public int Upgrade
    {
        get
        {
            return upgrade;
        }

        set
        {
            upgrade = value;
        }
    }
}