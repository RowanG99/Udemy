public class Section5MessingAround {
    public static void main(String[] args) {
/*        boolean gameOver = true;
        int levelCompleted = 5, score = 800, bonus = 100, finalScore;
        finalScore = calculateScore(gameOver, levelCompleted, score, bonus);
        System.out.println(finalScore);*/
    int highScorePosition = calculateHighScorePosition(99);
    displayHighScorePosition("Rowan", highScorePosition);
    }
    public static int calculateHighScorePosition(int score)
    {
        int result;
        if(score >= 1000)
        {
            result = 1;
        }
        else if(score >= 500)
        {
            result = 2;
        }
        else if(score >= 100)
        {
            result = 3;
        }
        else
        {
            result = 4;
        }
        return result;
    }
    public static void displayHighScorePosition(String name, int position)
    {
        System.out.println(name + " managed to get into position " + position + " on the high score list.");
    }

/*    public static  int calculateScore(boolean gameOver, int levelCompleted, int score, int bonus){
        int finalScore = score;
        if(gameOver) {
            finalScore += (levelCompleted*bonus) + 1000;
        }
        return finalScore;
    }*/
}
