using Avalonia;
using Avalonia.Media;

namespace ShapeRenderingIssue.Controls.Nodes;

public class RectangleNode : DraggableNode
{
    protected override Geometry? CreateDefiningGeometry()
    {
        var rect = new Rect(Bounds.Size).Deflate(StrokeThickness / 2);
        return new RectangleGeometry(rect);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        return new Size(StrokeThickness, StrokeThickness);
    }
}