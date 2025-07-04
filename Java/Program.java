import java.util.Date;
import java.util.Calendar;

public class Program {
    public static void main(String[] args) {
        Date cheeseExpiry = addDays(new Date(), 2);
        Date biscuitsExpiry = addDays(new Date(), 1);

        Cheese cheese = new Cheese("Cheese", 100, 5, cheeseExpiry, 0.2);
        Biscuits biscuits = new Biscuits("Biscuits", 150, 10, biscuitsExpiry, 0.7);
        TV tv = new TV("TV", 5000, 2, 8.0);
        MobileScratchCard scratchCard = new MobileScratchCard("ScratchCard", 20, 100);

        Customer customer = new Customer("Hazem", 1000);
        Cart cart = new Cart();

        cart.add(cheese, 2);
        cart.add(biscuits, 1);
        cart.add(scratchCard, 1);

        Shop.checkout(customer, cart);
    }

    // Helper to add days to a date
    private static Date addDays(Date date, int days) {
        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        cal.add(Calendar.DATE, days);
        return cal.getTime();
    }
} 