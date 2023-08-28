public class MegaBytesConverter {
    public static void main(String[] args) {
        printMegaBytesAndKiloBytes(3000);
    }

    public static void printMegaBytesAndKiloBytes(int kiloBytes)
    {
        if(kiloBytes < 0)
        {
            System.out.println("Invalid Value");
        }
        else {
            double megabytes = kiloBytes / 1024;
            int remainingKB =kiloBytes % 1024;
            System.out.println(kiloBytes + " KB = " + Math.round(megabytes) + " MB and " + remainingKB + " KB");
        }
    }
}