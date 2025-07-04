import java.util.ArrayList;
import java.util.List;

public class Cart {
    private List<CartItem> items = new ArrayList<>();

    public List<CartItem> getItems() { return items; }

    public void add(Product product, int quantity) {
        if (quantity > product.getQuantity()) {
            throw new RuntimeException("Not enough stock for " + product.getName());
        }
        items.add(new CartItem(product, quantity));
    }

    public boolean isEmpty() {
        return items.isEmpty();
    }

    public double getSubtotal() {
        return items.stream().mapToDouble(CartItem::getTotalPrice).sum();
    }

    public List<ShipmentDetail> getShipmentDetails() {
        List<ShipmentDetail> list = new ArrayList<>();
        for (CartItem item : items) {
            if (item.getProduct() instanceof IShippable) {
                IShippable s = (IShippable) item.getProduct();
                for (int i = 0; i < item.getQuantity(); i++) {
                    list.add(new ShipmentDetail(s.getName(), s.getWeight()));
                }
            }
        }
        return list;
    }

    public boolean hasExpiredItems() {
        for (CartItem item : items) {
            if (item.getProduct() instanceof IExpirable) {
                IExpirable e = (IExpirable) item.getProduct();
                if (e.isExpired()) return true;
            }
        }
        return false;
    }

    public boolean hasOutOfStock() {
        for (CartItem item : items) {
            if (item.getQuantity() > item.getProduct().getQuantity()) return true;
        }
        return false;
    }

    public void reduceStock() {
        for (CartItem item : items) {
            item.getProduct().setQuantity(item.getProduct().getQuantity() - item.getQuantity());
        }
    }

    // Helper class for shipment details
    public static class ShipmentDetail {
        public String name;
        public double weight;
        public ShipmentDetail(String name, double weight) {
            this.name = name;
            this.weight = weight;
        }
    }
} 