using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Upgrade : MonoBehaviour
{
    private bool onUpgrade = false;
    private int damageLevel = 1;
    private int rangeLevel = 1;
    private int fireRateLevel = 1;
    private bool[] maxStatUpgrades = new bool[] {false, false, false};
    private int level = 0;
    private float totalPriceUpgrade = 0f;

    private void OnMouseOver()
    {
        onUpgrade = true;    
    }

    private void OnMouseExit()
    {
        onUpgrade = false;
    }

    public bool GetOnUpgrade()
    {
        return onUpgrade;
    }

    public void UpgradeDamage(Tower tower)
    {
        if (damageLevel <= 3)
        {
            float price = PriceUpgradeLevel(damageLevel);
            if (GameMenu.Instance().MoneyValue >= price)
            {
                tower.SetTowerDamage(tower.GetTowerDamage() + tower.GetBaseTowerDamage() * 0.3f);
                GameMenu.Instance().MoneyValue -= price;
                totalPriceUpgrade += price;
                damageLevel++;
                UtilsClass.CreateWorldTextPopup("Damage Level: " + (damageLevel - 1), UtilsClass.GetMouseWorldPosition(), 0.5f);
                if (damageLevel == 3)
                {
                    maxStatUpgrades[0] = true;
                }
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Not Enough Money!!", UtilsClass.GetMouseWorldPosition(), 0.5f);
            }
        }
        else
        {
            UtilsClass.CreateWorldTextPopup("Damage Level Max!", UtilsClass.GetMouseWorldPosition(), 0.5f);
        }

    }

    public void UpgradeRange(Tower tower)
    {
        if (rangeLevel <= 3)
        {
            float price = PriceUpgradeLevel(rangeLevel);
            if (GameMenu.Instance().MoneyValue >= price)
            {
                tower.SetRange(tower.GetRange() + tower.GetBaseTowerRange() * 0.2f);
                GameMenu.Instance().MoneyValue -= price;
                totalPriceUpgrade += price;
                rangeLevel++;
                UtilsClass.CreateWorldTextPopup("Range Level: " + (rangeLevel - 1), UtilsClass.GetMouseWorldPosition(), 0.5f);
                if (rangeLevel == 3)
                {
                    maxStatUpgrades[1] = true;
                }
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Not Enough Money!!", UtilsClass.GetMouseWorldPosition(), 0.5f);
            }
        }
        else
        {
            UtilsClass.CreateWorldTextPopup("Range Level Max!", UtilsClass.GetMouseWorldPosition(), 0.5f);

        }
    }

    public void UpgradeFireRate(Tower tower)
    {
        if (fireRateLevel <= 3)
        {
            float price = PriceUpgradeLevel(fireRateLevel);
            if (GameMenu.Instance().MoneyValue >= price)
            {
                tower.SetFireRate(tower.GetFireRate() + tower.GetBaseFireRate() * 0.5f);
                GameMenu.Instance().MoneyValue -= price;
                totalPriceUpgrade += price;
                fireRateLevel++;
                UtilsClass.CreateWorldTextPopup("Fire Rate Level Up: " + (fireRateLevel - 1), UtilsClass.GetMouseWorldPosition(), 0.5f);
                if (fireRateLevel == 3)
                {
                    maxStatUpgrades[2] = true;
                }
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Not Enough Money!!", UtilsClass.GetMouseWorldPosition(), 0.5f);
            }
        }
        else
        {
            UtilsClass.CreateWorldTextPopup("Fire Rate Level Max!", UtilsClass.GetMouseWorldPosition(), 0.5f);
        }
    }

    public void UpgradeLevel(Tower tower)
    {
        if (level < 3)
        {
            if (CheckMaxStatUpgrade())
            {
                level++;
                UtilsClass.CreateWorldTextPopup("Tower Level: " + level, UtilsClass.GetMouseWorldPosition(), 0.5f);
                ResetStat();
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Can't Upgrade Next Level!!", UtilsClass.GetMouseWorldPosition(), 0.5f);
            }
        }
        else
        {
            UtilsClass.CreateWorldTextPopup("Max Level!", UtilsClass.GetMouseWorldPosition(), 0.5f);
        }
    }

    public bool CheckMaxStatUpgrade()
    {
        foreach (bool b in maxStatUpgrades)
        {
            if (!b)
            {
                return false;
            }
        }
        return true;
    }

    private float PriceUpgradeLevel(float level)
    {
        if (level == 1)
        {
            return 50f;
        } else if (level == 2)
        {
            return 100f;
        } else
        {
            return 150f;
        }
    }

    public void SellTower(GameObject gameObject)
    {
        Tower tower = gameObject.GetComponent<Tower>();
        totalPriceUpgrade += tower.GetPrice();
        GameMenu.Instance().MoneyValue += totalPriceUpgrade / 2;
        Destroy(gameObject);
    }

    private void ResetStat()
    {
        damageLevel = 1;
        rangeLevel = 1;
        fireRateLevel = 1;
        maxStatUpgrades[0] = false;
        maxStatUpgrades[1] = false;
        maxStatUpgrades[2] = false;
    }

    private int GetLevelStat(int index)
    {
        if (index == 0)
        {
            return damageLevel;
        } else if (index == 1)
        {
            return rangeLevel;
        }else
        {
            return fireRateLevel; 
        }
    }
}
