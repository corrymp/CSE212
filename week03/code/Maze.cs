/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Checks to see if you can move in a given direction (dir). If you can, then moves based off the provided XY offsets (move).
    /// If you can't move, throws an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    /// <param name="dir">Direction index to move in. Any of 0,1,2,3 (left, right, up, down)</param>
    /// <param name="offset">XY offsets to use</param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Move(int dir, int[] offset)
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] space) && space[dir])
        {
            _currX += offset[0];
            _currY += offset[1];
            return;
        }
        throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft() => Move(0, [-1, 0]);

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight() => Move(1, [1, 0]);

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp() => Move(2, [0, -1]);

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown() => Move(3, [0, 1]);

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}