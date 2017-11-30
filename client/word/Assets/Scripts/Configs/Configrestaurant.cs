using  UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Configrestaurant : IBaseDataObject{
	private int _id;
	public int id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}
	private int _role_id;
	public int role_id
	{
		get
		{
			return _role_id;
		}
		set
		{
			_role_id = value;
		}
	}
	public string role_name{get;set;}
	public string role_type{get;set;}
	public string isLeft{get;set;}
	public string talk{get;set;}


	public static Configrestaurant[] datas = new Configrestaurant[12];
	public static Dictionary<int,Configrestaurant> map = new Dictionary<int, Configrestaurant> ();

	public static Configrestaurant GetByKey (int key){
		Configrestaurant data;
		if (map.TryGetValue (key, out data)) {
			return data;
		} else {
			return null;
		}
	}
	static Configrestaurant (){

		datas [0] = new Configrestaurant ();
		datas [0].id = 10000;
		datas [0].role_id = 0;
		datas [0].role_name = "A";
		datas [0].role_type = "npc";
		datas [0].isLeft = "";
		datas [0].talk = "what can I do for you,sir?";

		map.Add (datas [0].id,datas [0]);

		datas [1] = new Configrestaurant ();
		datas [1].id = 10001;
		datas [1].role_id = 0;
		datas [1].role_name = "B";
		datas [1].role_type = "npc";
		datas [1].isLeft = "";
		datas [1].talk = "what have you got this [morning]?";

		map.Add (datas [1].id,datas [1]);

		datas [2] = new Configrestaurant ();
		datas [2].id = 10002;
		datas [2].role_id = 0;
		datas [2].role_name = "A";
		datas [2].role_type = "npc";
		datas [2].isLeft = "";
		datas [2].talk = "[Fruit] Juice,[cakes] and [refreshments], and everything.";

		map.Add (datas [2].id,datas [2]);

		datas [3] = new Configrestaurant ();
		datas [3].id = 10003;
		datas [3].role_id = 0;
		datas [3].role_name = "B";
		datas [3].role_type = "npc";
		datas [3].isLeft = "";
		datas [3].talk = "I'd like to have a glass of [tomato] juice,please.";

		map.Add (datas [3].id,datas [3]);

		datas [4] = new Configrestaurant ();
		datas [4].id = 10004;
		datas [4].role_id = 0;
		datas [4].role_name = "A";
		datas [4].role_type = "npc";
		datas [4].isLeft = "";
		datas [4].talk = "Any [ceral],sir?";

		map.Add (datas [4].id,datas [4]);

		datas [5] = new Configrestaurant ();
		datas [5].id = 10005;
		datas [5].role_id = 0;
		datas [5].role_name = "B";
		datas [5].role_type = "npc";
		datas [5].isLeft = "";
		datas [5].talk = "Yes ,a dish of cream of [wheat].";

		map.Add (datas [5].id,datas [5]);

		datas [6] = new Configrestaurant ();
		datas [6].id = 10006;
		datas [6].role_id = 0;
		datas [6].role_name = "A";
		datas [6].role_type = "npc";
		datas [6].isLeft = "";
		datas [6].talk = "and eggs?";

		map.Add (datas [6].id,datas [6]);

		datas [7] = new Configrestaurant ();
		datas [7].id = 10007;
		datas [7].role_id = 0;
		datas [7].role_name = "B";
		datas [7].role_type = "npc";
		datas [7].isLeft = "";
		datas [7].talk = "Year,bacon and eggs with buttered toast,I like my bacon very crisp.";

		map.Add (datas [7].id,datas [7]);

		datas [8] = new Configrestaurant ();
		datas [8].id = 10008;
		datas [8].role_id = 0;
		datas [8].role_name = "A";
		datas [8].role_type = "npc";
		datas [8].isLeft = "";
		datas [8].talk = "How do you want your eggs?";

		map.Add (datas [8].id,datas [8]);

		datas [9] = new Configrestaurant ();
		datas [9].id = 10009;
		datas [9].role_id = 0;
		datas [9].role_name = "B";
		datas [9].role_type = "npc";
		datas [9].isLeft = "";
		datas [9].talk = "Fried,please.";

		map.Add (datas [9].id,datas [9]);

		datas [10] = new Configrestaurant ();
		datas [10].id = 10010;
		datas [10].role_id = 0;
		datas [10].role_name = "A";
		datas [10].role_type = "npc";
		datas [10].isLeft = "";
		datas [10].talk = "Anything more,sir?";

		map.Add (datas [10].id,datas [10]);

		datas [11] = new Configrestaurant ();
		datas [11].id = 10011;
		datas [11].role_id = 0;
		datas [11].role_name = "B";
		datas [11].role_type = "npc";
		datas [11].isLeft = "";
		datas [11].talk = "No,that's [enough],Thank you.";

		map.Add (datas [11].id,datas [11]);
	}
}