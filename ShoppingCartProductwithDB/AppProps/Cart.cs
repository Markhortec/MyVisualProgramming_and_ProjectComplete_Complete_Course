using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Cart
    {
        public List<MyProduct> items = null;
        public int totalQty = 0;
        public float totalPrice = 0;

        public Cart(Cart OldCart)
        {
            if(OldCart!=null)
            {
                items = OldCart.items;
                totalQty = OldCart.totalQty;
                totalPrice = OldCart.totalPrice;
            }
        }

        public bool RemoveFromCart(Product product, int qty)
        {
            MyProduct previousItem = items.FirstOrDefault(x => x.product.Id == product.Id);
            if(previousItem!=null)
            {
                if(previousItem.quantity == qty || qty == -1)
                {
                    totalPrice=totalPrice-(previousItem.quantity*previousItem.product.Price);
                    totalQty--;
                    items.Remove(previousItem);
                    return true;
                }
                else
                {
                    totalPrice = totalPrice - (previousItem.product.Price * qty);
                    previousItem.subTotal = previousItem.subTotal - (previousItem.product.Price * qty);
                    previousItem.quantity = previousItem.quantity - qty;
                    return true;
                }
            }
            return false;
        }
        public bool AddToCart(Product product, int qty)
        {
            if(items==null)
            {
                MyProduct myProduct = new MyProduct();
                myProduct.product = product;
                myProduct.quantity = qty;
                myProduct.subTotal = product.Price * qty;
                items = new List<MyProduct>();
                items.Add(myProduct);
                totalQty++;
                totalPrice = myProduct.subTotal;
                return true;
            }
            else
            {
                MyProduct previousItem = items.FirstOrDefault(x => x.product.Id == product.Id);
                if(previousItem != null)
                {
                    totalPrice = qty * previousItem.product.Price + totalPrice;
                    previousItem.quantity = previousItem.quantity + qty;
                    previousItem.subTotal = previousItem.subTotal + qty * previousItem.product.Price;
                    return true;
                }
                else
                {
                    MyProduct myProduct = new MyProduct();
                    myProduct.product = product;
                    myProduct.quantity = qty;
                    myProduct.subTotal = product.Price * qty;
                    items.Add(myProduct);
                    totalQty++;
                    totalPrice = myProduct.subTotal+ totalPrice;
                    return true;
                }
            }
            return false;
        }
    }

    public class MyProduct
    {
        public Product product;
        public int quantity;
        public float subTotal;
    }
}
