using NetTopologySuite.Geometries;

namespace MilesCarRental.Infraestructure.Utils;

public static class DistanceCalculator
{
    public static double CalculateDistance(double vehicleLongitude, double vehicleLatitude, Point clientPoint)
    {
        var vehiclePoint = new Point(vehicleLongitude, vehicleLatitude);
        return vehiclePoint.Distance(clientPoint);
    }

    public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
    {
        var earthRadiusKm = 6371;

        var dLat = DegreesToRadians(lat2 - lat1);
        var dLon = DegreesToRadians(lon2 - lon1);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = earthRadiusKm * c * 1000;
        return distance;
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
}