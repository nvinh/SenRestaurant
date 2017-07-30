using System;

namespace SenRestaurant.Core
{
	public class CartDataService
	{
		private static CartRepository cartRepository = new CartRepository();

		public CartDataService ()
		{
		}

		public void AddCartItem(Pho pho, int amount)
		{
			cartRepository.AddCartItem (pho, amount);
		}

		public Cart GetCart()
		{
			return cartRepository.GetCart ();
		}

	}
}

