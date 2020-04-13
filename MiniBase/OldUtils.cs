using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyWorld
{
    class TinyWorldUtils
    {
        public static ISet<Vector2I> GetNeighborPositions(Vector2I pos, bool cardinalOnly = false)
        {
            ISet<Vector2I> neighbors = new HashSet<Vector2I>();
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (i != 0 || j != 0) // omit center cell
                        if (!cardinalOnly || i == 0 || j == 0) // N, E, S, W cells
                            neighbors.Add(Vec(pos.x + i, pos.y + j));
            return neighbors;
        }

        public static ISet<Vector2I> GetBorderSet(ISet<Vector2I> positions, bool cardinalOnly = false)
        {
            ISet<Vector2I> border = new HashSet<Vector2I>();
            foreach (Vector2I pos in positions)
                foreach (Vector2I neighborCell in GetNeighborPositions(pos, cardinalOnly))
                    if (InLiveableArea(neighborCell) && !positions.Contains(neighborCell))
                        border.Add(neighborCell);
            return border;
        }

        public static ISet<Vector2I> ErodeSet(ISet<Vector2I> positions, float erosionChance)
        {
            ISet<Vector2I> erodedSet = new HashSet<Vector2I>();
            foreach (Vector2I pos in positions)
                if (random.NextDouble() < erosionChance)
                    erodedSet.Add(pos);
            positions.ExceptWith(erodedSet);
            return erodedSet;
        }
    }
}
