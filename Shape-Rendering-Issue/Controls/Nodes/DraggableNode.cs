using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;

namespace ShapeRenderingIssue.Controls.Nodes;

/// <summary>
///   A Control that can be dragged around by the user.
/// </summary>
/// <remarks>
///   Based on <see href="https://github.com/Abdesol/MovableControl">Abdesol/MovableControl</see>.
/// </remarks>
public abstract class DraggableNode : Shape
{
    /// <summary>
    ///   Whether or not the Control is currently being dragged.
    /// </summary>
    private bool _isDragged = false;

    /// <summary>
    ///    A Control will not always be dragged from its position value, but is within its Size.
    /// </summary>
    private Point _dragStartPoint;

    private TranslateTransform _transform = null!;

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        _isDragged = true;

        if (Parent is not Control parent)
            return;

        _dragStartPoint = e.GetPosition(parent);

        if (_transform != null)
        {
            _dragStartPoint = new Point(_dragStartPoint.X - _transform.X, 
                                        _dragStartPoint.Y - _transform.Y);
        }

        base.OnPointerPressed(e);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        _isDragged = false;

        base.OnPointerReleased(e);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        if (!_isDragged)
            return;

        if (Parent is not Control parent)
            return;

        var currentPos = e.GetPosition(parent);

        var offsetX = currentPos.X - _dragStartPoint.X;
        var offsetY = currentPos.Y - _dragStartPoint.Y;

        _transform = new TranslateTransform(offsetX, offsetY);
        RenderTransform = _transform;

        base.OnPointerMoved(e);
    }
}
