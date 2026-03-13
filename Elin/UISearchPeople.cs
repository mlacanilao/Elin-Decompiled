using System.Collections.Generic;
using UnityEngine.UI;

public class UISearchPeople : EMono
{
	public InputField inputSearch;

	public UIButton buttonClearSearch;

	public UIDropdown dropdown;

	public ListOwner list;

	public bool disable;

	public float intervalSearch;

	private int uidFilterZone = -1;

	private float timerSearch;

	private string lastSearch = "";

	public void Init(ListOwner _list)
	{
		if (disable)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		this.list = _list;
		inputSearch.onValueChanged.AddListener(Search);
		inputSearch.onSubmit.AddListener(Search);
		List<int> list = new List<int> { -1 };
		foreach (FactionBranch child in EMono.pc.faction.GetChildren())
		{
			list.Add(child.owner.uid);
		}
		dropdown.SetList(0, list, delegate(int a, int i)
		{
			object obj;
			if (a != -1)
			{
				obj = EMono.game.spatials.Find(a)?.Name;
				if (obj == null)
				{
					return "???";
				}
			}
			else
			{
				obj = "all".lang();
			}
			return (string)obj;
		}, delegate(int i, int a)
		{
			SE.ClickOk();
			uidFilterZone = a;
			this.list.List();
		});
		this.list.list.funcFilter = FuncFilter;
	}

	private void LateUpdate()
	{
		if (!disable && timerSearch > 0f)
		{
			timerSearch -= Core.delta;
			if (timerSearch <= 0f)
			{
				Search(inputSearch.text);
			}
		}
	}

	public bool FuncFilter(object _c)
	{
		Chara chara = _c as Chara;
		if (uidFilterZone != -1 && (chara.homeZone == null || chara.homeZone.uid != uidFilterZone))
		{
			return false;
		}
		if (!lastSearch.IsEmpty() && !chara.NameBraced.ToLower().Contains(lastSearch))
		{
			return false;
		}
		return true;
	}

	public void Search(string s)
	{
		s = s.ToLower();
		if (s.IsEmpty())
		{
			s = "";
		}
		buttonClearSearch.SetActive(inputSearch.text != "");
		if (!(s == lastSearch))
		{
			timerSearch = intervalSearch;
			lastSearch = s;
			Redraw();
		}
	}

	public void ClearSearch()
	{
		inputSearch.text = "";
		timerSearch = 0f;
		lastSearch = "";
		Redraw();
	}

	public void Redraw()
	{
		list.List();
	}
}
