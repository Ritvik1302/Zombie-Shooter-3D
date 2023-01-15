using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopType {
	AMMO,
	WEAPON_MP5K,
	WEAPON_AKM,
	WEAPON_M870,
	
};

public class Shop : MonoBehaviour {
	public ShopType shopType;
	public string title;
	public string description;
	public int price;
}
