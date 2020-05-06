using System.IO;

namespace CatchShapes.shapes
{
    public class ScoresForShapes
    {
        private static int redCircle = -1;
        private static int greenSquare = -1;
        private static int redSquare = 1;
        private static int greenCircle = 1;

        public static int RedCircle { get => redCircle; set => redCircle = value; }
        public static int RedSquare { get => redSquare; set => redSquare = value; }
        public static int GreenCircle { get => greenCircle; set => greenCircle = value; }
        public static int GreenSquare { get => greenSquare; set => greenSquare = value; }
    }
}
