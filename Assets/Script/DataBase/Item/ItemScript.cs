using UnityEngine;

[CreateAssetMenu(fileName = "ItemHero", menuName = "Assets/Item", order = 0)]
public class ItemScript : ScriptableObject
{
    public string itemId;
    public string Nama;
    public string Kota;
    public string tglLahir;
    public string KotaLahir;
    [TextArea]
    public string itemDeskripsi;
    public Sprite itemFoto;
}