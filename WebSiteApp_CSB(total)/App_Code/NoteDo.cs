using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NoteDo의 요약 설명입니다.
/// </summary>
public class NoteDo
{
	
		private string author;
		private string contents;
	
	public string Author
	{
		get { return author; }
		set { author = value; }
	}

	public string Contents
	{
		get { return contents; }
		set { contents = value; }

	}

	public NoteDo(string author, string contents)
	{
		this.author = author;
		this.contents = contents;
	}
}