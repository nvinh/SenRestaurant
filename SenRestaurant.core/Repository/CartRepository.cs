using System;
using System.Collections.Generic;

namespace SenRestaurant.Core
{
	public class CartRepository
	{
		public CartRepository ()
		{
		}

		static Cart MainCart = new Cart() { CartItems = new List<CartItem>() };

		public void AddCartItem(Pho pho, int amount)
		{
			//TODO: add check if already added
			MainCart.CartItems.Add(new CartItem(){Pho = pho, Amount = amount});
		}

		public Cart GetCart()
		{
			return MainCart;
		}
	}
}

