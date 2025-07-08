using Godot;
using Hapheslime.Core;

namespace Hapheslime;

public partial class Boot : Node
{
    private const string MainSceneUID = "uid://cgs5ff4ot3rat";

    public override void _Ready()
    {
        SceneManager.Instance.ToPath(MainSceneUID);
    }
}
