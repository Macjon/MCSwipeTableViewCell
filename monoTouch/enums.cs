using System;

namespace MonoTouch.MCSwipeTableViewCell
{
    public enum MCSwipeTableViewCellState
    {
        None = 0,
        One = (1 << 0),
        Two = (1 << 1),
        Three = (1 << 2),
        Four = (1 << 3)
    }

    public enum MCSwipeTableViewCellMode
    {
        None = 0,
        Exit,
        Switch
    }
}
