using System;
using System.Drawing;

namespace BombGameSolver.Source.Maze {
    public class Maze {
        /* Load image into memory */
        public Maze() {
            Bitmap myBitmap =
                new Bitmap("C:/Users/Robert/Development/projects/BombGameSolver/Resources/maze/maze11.png");

            Console.WriteLine(myBitmap.ToString());
        }

        /* Check every green pixel in image, if green pixel has line of sight of another green pixel,
         * (up, down, left, right) without hitting a black pixel, allow a path between them. */

        /* Add player and target positions and check for path between them */
    }
}