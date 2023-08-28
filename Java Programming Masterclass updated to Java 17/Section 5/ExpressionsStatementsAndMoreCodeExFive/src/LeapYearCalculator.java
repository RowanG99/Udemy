public class LeapYearCalculator {
    public static void main(String[] args) {
        boolean result = isLeapYear(2320);
        System.out.println(result);
    }

    public static boolean isLeapYear(int year)
    {
        if( year>=1 && year<=9999){
            if( (year %400==0)||(year%100 !=0 && year%4==0))
                return true;
        }
        else
            return false;
        return false;
    }
}


