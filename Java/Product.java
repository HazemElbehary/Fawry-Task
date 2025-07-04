import java.util.Date;

public abstract class Product {
    protected String name;
    protected double price;
    protected int quantity;

    public Product(String name, double price, int quantity) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public String getName() { return name; }
    public double getPrice() { return price; }
    public int getQuantity() { return quantity; }
    public void setQuantity(int quantity) { this.quantity = quantity; }
}

class Cheese extends Product implements IExpirable, IShippable {
    private Date expiryDate;
    private double weightKg;

    public Cheese(String name, double price, int quantity, Date expiryDate, double weightKg) {
        super(name, price, quantity);
        this.expiryDate = expiryDate;
        this.weightKg = weightKg;
    }

    @Override
    public Date getExpiryDate() { return expiryDate; }

    @Override
    public boolean isExpired() { return new Date().after(expiryDate); }

    @Override
    public String getName() { return name; }

    @Override
    public double getWeight() { return weightKg; }
}

class Biscuits extends Product implements IExpirable, IShippable {
    private Date expiryDate;
    private double weightKg;

    public Biscuits(String name, double price, int quantity, Date expiryDate, double weightKg) {
        super(name, price, quantity);
        this.expiryDate = expiryDate;
        this.weightKg = weightKg;
    }

    @Override
    public Date getExpiryDate() { return expiryDate; }

    @Override
    public boolean isExpired() { return new Date().after(expiryDate); }

    @Override
    public String getName() { return name; }

    @Override
    public double getWeight() { return weightKg; }
}

class TV extends Product implements IShippable {
    private double weightKg;

    public TV(String name, double price, int quantity, double weightKg) {
        super(name, price, quantity);
        this.weightKg = weightKg;
    }

    @Override
    public String getName() { return name; }

    @Override
    public double getWeight() { return weightKg; }
}

class MobileScratchCard extends Product {
    public MobileScratchCard(String name, double price, int quantity) {
        super(name, price, quantity);
    }
} 