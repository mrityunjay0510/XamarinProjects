using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Animation;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views.Animations;

namespace AgencyProfile
{
    public class Fab : View
    {
        private Paint _buttonPaint;
        private Paint _drawablePaint;
        private Bitmap _bitmap;
        private int _screenHeight;
        private float _currentY;
        private bool _hidden;

        private void Init(Color fabColor)
        {
           
            SetWillNotDraw(false);
            SetLayerType(LayerType.Software, null);
            _buttonPaint = new Paint(PaintFlags.AntiAlias) { Color = fabColor };
            _buttonPaint.SetStyle(Paint.Style.Fill);
            _buttonPaint.SetShadowLayer(10.0f, 0.0f, 3.5f, Color.Argb(100, 0, 0, 0));
            _drawablePaint = new Paint(PaintFlags.AntiAlias);
            Invalidate();

            var windowManager = Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            var display = windowManager.DefaultDisplay;
            var size = new Point();
            display.GetSize(size);
            _screenHeight = size.Y;
        }

        public Fab(Context context, IAttributeSet attributeSet)
            : base(context, attributeSet)
        {
            Init(Color.White);
        }

        public Fab(Context context)
            : base(context)
        {
            Init(Color.White);
        }

        public Fab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        { }

        public Color FabColor
        {
            set { Init(value); }
        }

        public Drawable FabDrawable
        {
            set
            {
                var drawable = value;
                _bitmap = ((BitmapDrawable)drawable).Bitmap;
                Invalidate();
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawCircle(Width / 2f, Height / 2f, Width / 2.6f, _buttonPaint);
            if (_bitmap != null)
            {
                canvas.DrawBitmap(_bitmap, (Width - _bitmap.Width) / 2f, (Height - _bitmap.Height) / 2f, _drawablePaint);
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
                Alpha = 1.0f;
            else if (e.Action == MotionEventActions.Down)
                Alpha = 0.5f;

            return base.OnTouchEvent(e);
        }

        public int DpToPx(int dp)
        {
            var displayMetrics = Context.Resources.DisplayMetrics;
            var px = Math.Round(dp * (displayMetrics.Xdpi / (int)DisplayMetricsDensity.Default));
            return (int)px;
        }

        public void Hide(bool hide)
        {
            if (_hidden != hide)
            {
                _hidden = hide;

                _currentY = GetY();
                var hideAnimation = ObjectAnimator.OfFloat(this, "Y", _screenHeight);
                hideAnimation.SetInterpolator(new AccelerateInterpolator());
                hideAnimation.Start();
                _hidden = true;
            }

        }

    }
}

