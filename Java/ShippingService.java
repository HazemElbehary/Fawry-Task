import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class ShippingService {
    public static void ship(List<ShipmentDetail> items) {
        if (items == null || items.isEmpty()) return;

        System.out.println("** Shipment notice **");
        Map<String, List<ShipmentDetail>> grouped = items.stream().collect(Collectors.groupingBy(i -> i.name));
        for (String key : grouped.keySet()) {
            List<ShipmentDetail> group = grouped.get(key);
            int count = group.size();
            double totalWeightGrams = group.stream().mapToDouble(i -> i.weight).sum() * 1000;
            System.out.printf("%dx %-12s %6.0fg\n", count, key, totalWeightGrams);
        }
        double totalWeight = items.stream().mapToDouble(i -> i.weight).sum();
        System.out.printf("Total package weight %.1fkg\n", totalWeight);
    }
} 