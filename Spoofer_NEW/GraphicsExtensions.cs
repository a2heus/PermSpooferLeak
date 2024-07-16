using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

// Token: 0x02000002 RID: 2
[NullableContext(1)]
[Nullable(0)]
public static class GraphicsExtensions
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
	{
		if (graphics == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (pen != null)
		{
			using (GraphicsPath graphicsPath = GraphicsExtensions.CreateRoundedRectanglePath(bounds, cornerRadius))
			{
				graphics.DrawPath(pen, graphicsPath);
				return;
			}
		}
		throw new ArgumentNullException("pen");
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020A8 File Offset: 0x000002A8
	private static GraphicsPath CreateRoundedRectanglePath(Rectangle bounds, int cornerRadius)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 2 * cornerRadius;
		Rectangle rect = new Rectangle(bounds.X, bounds.Y, num, num);
		graphicsPath.AddArc(rect, 180f, 90f);
		rect.X = bounds.Right - num;
		graphicsPath.AddArc(rect, 270f, 90f);
		rect.Y = bounds.Bottom - num;
		graphicsPath.AddArc(rect, 0f, 90f);
		rect.X = bounds.Left;
		graphicsPath.AddArc(rect, 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
