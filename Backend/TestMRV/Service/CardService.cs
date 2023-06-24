using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestMRV.Data;
using TestMRV.Models;

namespace TestMRV.Service
{
    public class CardService
    {
        public void PriceDiscount(Card card)
        {
            if (card.Price > 500.00)
            {
                card.Price = card.Price * 10;
            }
        }

        //public void Accept(bool accept, Card card)
        //{
        //    if(accept)
        //    {
        //        card.Accept = accept;
        //    }
        //}
    }
}
