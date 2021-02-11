using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace XFBtgControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MultiProgressRing : SKCanvasView
    {
        public MultiProgressRing()
        {
            WidthRequest = 500;
            HeightRequest = 500;
        }
        
        public static readonly BindableProperty Progress1Property = BindableProperty.Create(nameof(Progress1), typeof(double), typeof(MultiProgressRing), default(double));
        public double Progress1
        {
            get => (double)GetValue(Progress1Property);
            set => SetValue(Progress1Property, value);
        }
        public static readonly BindableProperty Progress2Property = BindableProperty.Create(nameof(Progress2), typeof(double), typeof(MultiProgressRing), default(double));
        public double Progress2
        {
            get => (double)GetValue(Progress2Property);
            set => SetValue(Progress2Property, value);
        }

        public static readonly BindableProperty Progress3Property = BindableProperty.Create(nameof(Progress3), typeof(double), typeof(MultiProgressRing), default(double));
        public double Progress3
        {
            get => (double)GetValue(Progress3Property);
            set => SetValue(Progress3Property, value);
        }
        public static readonly BindableProperty RingSpacingProperty = BindableProperty.Create(nameof(RingSpacing), typeof(double), typeof(MultiProgressRing), default(double));
        public double RingSpacing
        {
            get => (double)GetValue(RingSpacingProperty);
            set => SetValue(RingSpacingProperty, value);
        }

        public static readonly BindableProperty RingWidthProperty = BindableProperty.Create(nameof(RingWidth), typeof(double), typeof(MultiProgressRing), default(double));
        public double RingWidth
        {
            get => (double)GetValue(RingWidthProperty);
            set => SetValue(RingWidthProperty, value);
        }

        public static readonly BindableProperty RingOutlineColorProperty = BindableProperty.Create(nameof(RingOutlineColor), typeof(Color), typeof(MultiProgressRing), default(Color));
        public Color RingOutlineColor
        {
            get => (Color)GetValue(RingOutlineColorProperty);
            set => SetValue(RingOutlineColorProperty, value);
        }

        public static readonly BindableProperty ProgressColor1Property = BindableProperty.Create(nameof(ProgressColor1), typeof(Color), typeof(MultiProgressRing), default(Color));
        public Color ProgressColor1
        {
            get => (Color)GetValue(ProgressColor1Property);
            set => SetValue(ProgressColor1Property, value);
        }
        public static readonly BindableProperty ProgressColor2Property = BindableProperty.Create(nameof(ProgressColor2), typeof(Color), typeof(MultiProgressRing), default(Color));
        public Color ProgressColor2
        {
            get => (Color)GetValue(ProgressColor2Property);
            set => SetValue(ProgressColor2Property, value);
        }
        public static readonly BindableProperty ProgressColor3Property = BindableProperty.Create(nameof(ProgressColor3), typeof(Color), typeof(MultiProgressRing), default(Color));
        public Color ProgressColor3
        {
            get => (Color)GetValue(ProgressColor3Property);
            set => SetValue(ProgressColor3Property, value);
        }
        
        public void OnCanvasViewTapped(object sender, EventArgs e)
        {
            (sender as SKCanvasView).InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var ringWidth = (float)RingWidth;
            var ringSpacing = (float)RingSpacing;

            SKPaint outlinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,                
                Color = RingOutlineColor.ToSKColor(),
                StrokeWidth = ringWidth
            };

            SKPaint progress1Paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeCap = SKStrokeCap.Round,
                Color = ProgressColor1.ToSKColor(),
                StrokeWidth = ringWidth
            };

            SKPaint progress2Paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeCap = SKStrokeCap.Round,
                Color = ProgressColor2.ToSKColor(),
                StrokeWidth = ringWidth
            };

            SKPaint progress3Paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeCap = SKStrokeCap.Round,
                Color = ProgressColor3.ToSKColor(),
                StrokeWidth = ringWidth
            };

            SKPaint innerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.DarkGray.ToSKColor(),
                StrokeWidth = 10,
                MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 10f)
            };


            var ringRect = SKRect.Create (0,0, info.Width, info.Height);
            ringRect = SKRect.Inflate(ringRect, -(ringWidth * 0.5f), -(ringWidth * 0.5f));

            canvas.DrawOval(ringRect, outlinePaint);
            canvas.DrawArc(ringRect, -90, (float)Progress1 * 360,false, progress1Paint);
            canvas.DrawArc(ringRect, -90, (float)Progress1 * 360, false, innerPaint);

            ringRect = SKRect.Inflate(ringRect, -(ringWidth + ringSpacing), -(ringWidth + ringSpacing));
            canvas.DrawOval(ringRect, outlinePaint);
            canvas.DrawArc(ringRect, -90, (float)Progress2 * 360, false, progress2Paint);
            canvas.DrawArc(ringRect, -90, (float)Progress2 * 360, false, innerPaint);

            ringRect = SKRect.Inflate(ringRect, -(ringWidth + ringSpacing), -(ringWidth + ringSpacing));
            canvas.DrawOval(ringRect, outlinePaint);
            canvas.DrawArc(ringRect, -90, (float)Progress3 * 360, false, progress3Paint);
            canvas.DrawArc(ringRect, -90, (float)Progress3 * 360, false, innerPaint);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            // Determine when to change. Basically on any of the properties that we've added that affect
            // the visualization, including the size of the control, we'll repaint
            if (propertyName == Progress1Property.PropertyName
                || propertyName == Progress2Property.PropertyName
                || propertyName == Progress3Property.PropertyName
                || propertyName == WidthProperty.PropertyName
                || propertyName == HeightProperty.PropertyName
                || propertyName == ProgressColor1Property.PropertyName
                || propertyName == ProgressColor2Property.PropertyName
                || propertyName == ProgressColor3Property.PropertyName
                || propertyName == RingWidthProperty.PropertyName
                || propertyName == RingSpacingProperty.PropertyName)
            {
                InvalidateSurface();
            }
        }
    }
}