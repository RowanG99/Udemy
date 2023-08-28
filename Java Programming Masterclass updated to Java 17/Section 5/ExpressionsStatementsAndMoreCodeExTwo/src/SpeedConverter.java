public class SpeedConverter {
    public static void main(String[] args) {
        printConversion(-1);
    }

    public static long toMilesPerHour(double kilometersPerHour)
    {
        final double ratio = 1.609;
        return kilometersPerHour < 0 ? -1 : Math.round((kilometersPerHour/ratio));

    }

    public static void printConversion(double kmH)
    {
        long mH = toMilesPerHour(kmH);
        if(kmH < 0)
        {
            System.out.println("Invalid Value");
        }
        else
        {
            System.out.println(kmH + " km/h = " + mH + " mi/h");
        }
    }
}