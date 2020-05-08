using System.IO;

namespace CatchShapes.shapes
{
    public class ScoresForShapes
    {
        private static int redCircle = -1;
        private static int greenSquare = -1;
        private static int redSquare = 1;
        private static int greenCircle = 1;

        public static int RedCircle { get => redCircle; }
        public static int RedSquare { get => redSquare; }
        public static int GreenCircle { get => greenCircle; }
        public static int GreenSquare { get => greenSquare; }
    }
}
