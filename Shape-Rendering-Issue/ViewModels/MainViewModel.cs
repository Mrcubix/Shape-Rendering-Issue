using System.Collections.ObjectModel;
using ShapeRenderingIssue.ViewModels.Controls.Nodes;

namespace ShapeRenderingIssue.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<NodeViewModel> Nodes { get; } = new();

    public MainViewModel()
    {
        var rect1 = new RectangleNodeViewModel
        {
            X = 100,
            Y = 100,
            Width = 75,
            Height = 75
        };

        var rect2 = new RectangleNodeViewModel
        {
            X = 200,
            Y = 200,
            Width = 50,
            Height = 50
        };

        var circle1 = new CircleNodeViewModel
        {
            X = 300,
            Y = 300,
            Width = 25,
            Height = 25
        };

        Nodes.Add(rect1);
        Nodes.Add(rect2);
        Nodes.Add(circle1);
    }
}
