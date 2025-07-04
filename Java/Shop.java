import java.util.List;

public class Shop {
    public static void checkout(Customer customer, Cart cart) {
        if (cart.isEmpty())
            throw new RuntimeException("Cart is empty");

        if (cart.hasExpiredItems())
            throw new RuntimeException("Cart has expired items");

        if (cart.hasOutOfStock())
            throw new RuntimeException("Some products are out of stock");

        List<Cart.ShipmentDetail> shippingItems = cart.getShipmentDetails();
        double shippingCost = shippingItems.size() * 15;

        double subtotal = cart.getSubtotal();
        double total = subtotal + shippingCost;

        customer.deduct(total);
        cart.reduceStock();

        ShippingService.ship(shippingItems);

        System.out.println("** Checkout receipt **");
        for (CartItem item : cart.getItems()) {
            System.out.printf("%dx %-12s %6.0f\n", item.getQuantity(), item.getProduct().getName(), item.getTotalPrice());
        }

        System.out.println("----------------------");
        System.out.printf("%-12s%6.0f\n", "Subtotal", subtotal);
        System.out.printf("%-12s%6.0f\n", "Shipping", shippingCost);
        System.out.printf("%-12s%6.0f\n", "Amount", total);
    }
} 