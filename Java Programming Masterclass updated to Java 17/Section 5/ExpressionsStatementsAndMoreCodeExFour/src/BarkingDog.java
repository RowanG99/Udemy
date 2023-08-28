public class BarkingDog {
    public static void main(String[] args) {
        boolean test = false;
        test = shouldWakeUp(true, 13);

        System.out.println(test);
    }

    public static boolean shouldWakeUp(boolean barking, int hourOfDay)
    {
        if (!barking)
            return false;
        if (hourOfDay < 0 || hourOfDay > 23)
            return false;
        return hourOfDay < 8 || hourOfDay > 22;
    }
}