using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantTimeListener : ITimeListener
{
    private Merchant _merchant;

    public MerchantTimeListener(Merchant merchant)
    {
        _merchant = merchant;
        _merchant.Init(new NoSaleStrategy());
    }

    public void onTimeUpdate(float time)
    {
        if (time < 0.3)
        {
            _merchant.SetStrategy(new NoSaleStrategy());
            return;
        }

        if (time < 0.6)
        {
            _merchant.SetStrategy(new FruitStrategy());
            return;
        }

        if (time < 0.9)
        {
        _merchant.SetStrategy(new ArmorStrategy());
            return;
        }

        _merchant.SetStrategy(new NoSaleStrategy());
    }
}
