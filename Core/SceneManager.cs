using Godot;
using Godot.Collections;
using Hapheslime.Common;

namespace Hapheslime.Core;

[GlobalClass]
public partial class SceneManager : Node
{
    public static SceneManager Instance { get; private set; }

    private string _loadingScenePath;
    private Array _loadingProgress = [];

    private const string LoadingErrorLog = "An error occurred while trying to load the scene";
    private const string LoadingFailedLog = "Scene loading is failed";
    private const string CurrentSceneChangedLog = "Changing current scene to";

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        UpdateProgress();
    }

    public float GetStatus() => (float)_loadingProgress[0];

    public void ToPath(string path)
    {
        if (!ResourceLoader.Exists(path))
            return;

        _loadingScenePath = path;
        var err = ResourceLoader.LoadThreadedRequest(path);

        if (err != Error.Ok)
        {
            _loadingScenePath = null;
            Logger.Error(LoadingErrorLog);
        }
    }

    public void ToPacked(PackedScene scene)
    {
        var tree = GetTree();
        var sceneInstance = scene.Instantiate();

        tree.Root.CallDeferred("add_child", sceneInstance);
        tree.Root.CallDeferred("remove_child", tree.CurrentScene);
        tree.SetDeferred("current_scene", sceneInstance);

        Logger.Info($"{CurrentSceneChangedLog} {sceneInstance.Name}");
    }

    private void UpdateProgress()
    {
        if (_loadingScenePath is null)
            return;

        var result = ResourceLoader.LoadThreadedGetStatus(_loadingScenePath, _loadingProgress);

        switch (result)
        {
            case ResourceLoader.ThreadLoadStatus.Failed:
                _loadingScenePath = null;
                Logger.Error(LoadingFailedLog);
                break;

            case ResourceLoader.ThreadLoadStatus.InProgress:
                break;

            case ResourceLoader.ThreadLoadStatus.Loaded:
                var scene = (PackedScene)ResourceLoader.LoadThreadedGet(_loadingScenePath);
                ToPacked(scene);
                break;
        }
    }
}
