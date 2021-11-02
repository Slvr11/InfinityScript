using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: reimplement utility functions from _hud_util

namespace InfinityScript
{
    public class HudElem
    {
        public Entity Entity { get; set; }

        #region static uiparent
        private static HudElem _uiParent;

        public static HudElem UIParent
        {
            get
            {
                if (_uiParent == null)
                {
                    _uiParent = new HudElem();
                }

                return _uiParent;
            }
        }

        private HudElem()
        {
            Entity = null;
            Children = new List<HudElem>();
        }
        #endregion

        internal HudElem(Entity entity)
        {
            Entity = entity;
            Children = new List<HudElem>();
        }

        public static HudElem GetHudElem(int entRef)
        {
            return new HudElem(new Entity(entRef));
        }

        public float X
        {
            get
            {
                if (Entity == null)
                {
                    return 0;
                }

                Parameter ret;
                ret = Entity.GetField(0);
                if (ret != null) return (float)ret;
                else return 0;
            }
            set
            {
                Entity.SetField(0, value);
            }
        }

        public float Y
        {
            get
            {
                if (Entity == null)
                {
                    return 0;
                }

                Parameter ret;
                ret = Entity.GetField(1);
                if (ret != null) return (float)ret;
                else return 0;
            }
            set
            {
                Entity.SetField(1, value);
            }
        }

        public float Z
        {
            get
            {
                if (Entity == null)
                {
                    return 0;
                }

                Parameter ret;
                ret = Entity.GetField(2);
                if (ret != null) return (float)ret;
                else return 0;
            }
            set
            {
                Entity.SetField(2, value);
            }
        }

        public float FontScale
        {
            get
            {
                if (Entity == null)
                {
                    return 0;
                }

                Parameter ret;
                ret = Entity.GetField(3);
                if (ret != null) return (float)ret;
                else return 0;
            }
            set
            {
                Entity.SetField(3, value);
            }
        }

        public Fonts Font
        {
            get
            {
                Parameter font = Entity.GetField(4);
                if (font == null) return Fonts.Default;

                Fonts ret;
                if (Enum.TryParse((string)font, out ret)) return ret;
                else return Fonts.Default;
            }
            set
            {
                Entity.SetField(4, value.ToString().ToLowerInvariant());
            }
        }

        public XAlignments AlignX
        {
            get
            {
                if (Entity == null) return XAlignments.Center;
                Parameter ret = Entity.GetField(5);
                if (ret == null) return XAlignments.Center;

                string align = (string)ret;
                align = align.ToLowerInvariant();
                /*
                foreach (HorzAlignments ret in Enum.GetValues(typeof(HorzAlignments)))
                {
                    if (ret.ToString().ToLowerInvariant() == align) return ret;
                }
                return HorzAlignments.NoScale;
                */
                switch (align)
                {
                    case "left":
                        return XAlignments.Left;
                    case "right":
                        return XAlignments.Right;
                    default:
                        return XAlignments.Center;
                }
            }
            set { Entity.SetField(5, value.ToString().ToLowerInvariant()); }
        }

        public YAlignments AlignY
        {
            get
            {
                if (Entity == null) return YAlignments.Middle;
                Parameter ret = Entity.GetField(6);
                if (ret == null) return YAlignments.Middle;

                string align = (string)ret;
                align = align.ToLowerInvariant();
                /*
                foreach (HorzAlignments ret in Enum.GetValues(typeof(HorzAlignments)))
                {
                    if (ret.ToString().ToLowerInvariant() == align) return ret;
                }
                return HorzAlignments.NoScale;
                */
                switch (align)
                {
                    case "top":
                        return YAlignments.Top;
                    case "bottom":
                        return YAlignments.Bottom;
                    default:
                        return YAlignments.Middle;
                }
            }
            set { Entity.SetField(6, value.ToString().ToLowerInvariant()); }
        }

        public HorzAlignments HorzAlign
        {
            get
            {
                if (Entity == null) return HorzAlignments.NoScale;
                Parameter ret = Entity.GetField(7);
                if (ret == null) return HorzAlignments.NoScale;

                string align = (string)ret;
                align = align.ToLowerInvariant();
                /*
                foreach (HorzAlignments ret in Enum.GetValues(typeof(HorzAlignments)))
                {
                    if (ret.ToString().ToLowerInvariant() == align) return ret;
                }
                return HorzAlignments.NoScale;
                */
                switch (align)
                {
                    case "left":
                        return HorzAlignments.Left;
                    case "right":
                        return HorzAlignments.Right;
                    case "center":
                        return HorzAlignments.Center;
                    case "center_safearea":
                        return HorzAlignments.Center_SafeArea;
                    case "center_adjustable":
                        return HorzAlignments.Center_Adjustable;
                    case "alignto640":
                        return HorzAlignments.AlignTo640;
                    case "fullscreen":
                        return HorzAlignments.Fullscreen;
                    case "subleft":
                        return HorzAlignments.SubLeft;
                    case "left_adjustable":
                        return HorzAlignments.Left_Adjustable;
                    case "right_adjustable":
                        return HorzAlignments.Right_Adjustable;
                    default:
                        return HorzAlignments.NoScale;
                }
            }
            set { Entity.SetField(7, value.ToString().ToLowerInvariant()); }
        }

        public VertAlignments VertAlign
        {
            get
            {
                if (Entity == null) return VertAlignments.NoScale;
                Parameter ret = Entity.GetField(8);
                if (ret == null) return VertAlignments.NoScale;

                string align = (string)ret;
                align = align.ToLowerInvariant();
                switch (align)
                {
                    case "top":
                        return VertAlignments.Top;
                    case "bottom":
                        return VertAlignments.Bottom;
                    case "middle":
                        return VertAlignments.Middle;
                    case "center_safearea":
                        return VertAlignments.Center_SafeArea;
                    case "center_adjustable":
                        return VertAlignments.Center_Adjustable;
                    case "alignto640":
                        return VertAlignments.AlignTo640;
                    case "fullscreen":
                        return VertAlignments.Fullscreen;
                    case "subtop":
                        return VertAlignments.SubTop;
                    case "top_adjustable":
                        return VertAlignments.Top_Adjustable;
                    case "bottom_adjustable":
                        return VertAlignments.Bottom_Adjustable;
                    default:
                        return VertAlignments.NoScale;
                }
            }
            set { Entity.SetField(8, value.ToString().ToLowerInvariant()); }
        }

        public float Alpha
        {
            get
            {
                Parameter ret = Entity.GetField(10);
                if (ret == null) return 0f;
                return (float)ret;
            }
            set
            {
                Entity.SetField(10, value);
            }
        }

        public float GlowAlpha
        {
            get
            {
                Parameter ret = Entity.GetField(18);
                if (ret == null) return 0f;
                return (float)ret;
            }
            set
            {
                Entity.SetField(18, value);
            }
        }

        public int Sort
        {
            get
            {
                Parameter ret = Entity.GetField(12);
                if (ret == null) return 0;
                return (int)ret;
            }
            set
            {
                Entity.SetField(12, value);
            }
        }

        public bool HideWhenInMenu
        {
            get
            {
                Parameter ret = Entity.GetField(16);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(16, value);
            }
        }

        public bool LowResBackground
        {
            get
            {
                Parameter ret = Entity.GetField(14);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(14, value);
            }
        }

        public bool HideWhenDead
        {
            get
            {
                Parameter ret = Entity.GetField(15);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(15, value);
            }
        }

        public bool HideIn3rdPerson
        {
            get
            {
                Parameter ret = Entity.GetField(20);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(20, value);
            }
        }

        public bool HideWhenInDemo
        {
            get
            {
                Parameter ret = Entity.GetField(21);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(21, value);
            }
        }

        public bool Archived
        {
            get
            {
                Parameter ret = Entity.GetField(19);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(19, value);
            }
        }

        public bool Foreground
        {
            get
            {
                Parameter ret = Entity.GetField(13);
                if (ret == null) return false;
                return (int)ret != 0;
            }
            set
            {
                Entity.SetField(13, value);
            }
        }

        public Vector3 Color
        {
            get
            {
                Parameter ret = Entity.GetField(9);
                if (ret == null) return Vector3.Zero;
                return ret.As<Vector3>();
            }
            set
            {
                Entity.SetField(9, value);
            }
        }

        public Vector3 GlowColor
        {
            get
            {
                Parameter ret = Entity.GetField(17);
                if (ret == null) return Vector3.Zero;
                return ret.As<Vector3>();
            }
            set
            {
                Entity.SetField(17, value);
            }
        }

        public string Label
        {
            get
            {
                Parameter ret = Entity.GetField(11);
                if (ret == null) return "";
                return (string)ret;
            }
            set
            {
                Entity.SetField(11, value);
            }
        }


        #region calls

        public Parameter GetField(string name)
        {
            return Entity.GetField(name);
        }

        public Parameter GetField(int index)
        {
            return Entity.GetField(index);
        }

        public void SetField(string name, Parameter value)
        {
            Entity.SetField(name, value);
        }
        #endregion

        public static HudElem CreateFontString(Entity client, Fonts font, float fontScale)
        {
            var elem = GSCFunctions.NewClientHudElem(client);
            elem.Font = font;
            elem.FontScale = fontScale;
            elem.X = 0;
            elem.Y = 0;
            elem.Height = (int)(12 * fontScale);
            elem.Parent = UIParent;
            return elem;
        }

        public static HudElem CreateServerFontString(Fonts font, float fontScale)
        {
            var elem = GSCFunctions.NewHudElem();
            elem.Font = font;
            elem.FontScale = fontScale;
            elem.X = 0;
            elem.Y = 0;
            elem.Height = (int)(12 * fontScale);
            elem.Parent = UIParent;
            return elem;
        }

        public static HudElem CreateIcon(Entity client, string shader, int width, int height)
        {
            var elem = GSCFunctions.NewClientHudElem(client);
            elem.X = 0;
            elem.Y = 0;
            elem.Width = width;
            elem.Height = height;
            elem.Parent = UIParent;

            if (shader != null)
            {
                elem.SetShader(shader, width, height);
                elem._shader = shader;
            }

            return elem;
        }

        #region utility functions
        #region parenting
        private HudElem _parent;
        public List<HudElem> Children { get; set; }

        public HudElem Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent != null)
                {
                    _parent.Children.Remove(this);
                }

                _parent = value;
                _parent.Children.Add(this);


            }
        }
        #endregion

        #region Point value stuff
        public enum HorzAlignments
        {
            SubLeft,
            Left,
            Center,
            Right,
            Fullscreen,
            NoScale,
            AlignTo640,
            Center_SafeArea,
            Center_Adjustable,
            Left_Adjustable,
            Right_Adjustable
        }
        public enum VertAlignments
        {
            SubTop,
            Top,
            Middle,
            Bottom,
            Fullscreen,
            NoScale,
            AlignTo640,
            Center_SafeArea,
            Center_Adjustable,
            Top_Adjustable,
            Bottom_Adjustable
        }
        public enum XAlignments
        {
            Left,
            Center,
            Right
        }
        public enum YAlignments
        {
            Top,
            Middle,
            Bottom
        }
        #endregion

        #region fonts
        public enum Fonts
        {
            Big,
            Bold,
            ExtraBig,
            HudBig,
            HudSmall,
            Normal,
            Objective,
            Small,
            Default,
            BigFixed
        }
        #endregion

        #region positioning

        public void SetPoint(string point)
        {
            SetPoint(point, point, 0, 0, 0);
        }

        public void SetPoint(string point, string relativePoint)
        {
            SetPoint(point, relativePoint, 0, 0, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset)
        {
            SetPoint(point, relativePoint, xOffset, 0, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset, int yOffset)
        {
            SetPoint(point, relativePoint, xOffset, yOffset, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset, int yOffset, int moveTime)
        {
            var element = Parent;

            point = point.ToLowerInvariant();
            relativePoint = relativePoint.ToLowerInvariant();

            if (moveTime > 0)
            {
                this.MoveOverTime(moveTime);
            }

            _xOffset = xOffset;
            _yOffset = yOffset;
            _point = point;
            _relativePoint = relativePoint;

            AlignX = XAlignments.Center;
            AlignY = YAlignments.Middle;

            if (point.Contains("top"))
            {
                AlignY = YAlignments.Top;
            }

            else if (point.Contains("bottom"))
            {
                AlignY = YAlignments.Bottom;
            }

            if (point.Contains("left"))
            {
                AlignX = XAlignments.Left;
            }

            else if (point.Contains("right"))
            {
                AlignX = XAlignments.Right;
            }

            var relativeX = HorzAlignments.Center_Adjustable;
            var relativeY = VertAlignments.Middle;

            if (relativePoint.Contains("top"))
            {
                relativeY = VertAlignments.Top_Adjustable;
            }

            else if (relativePoint.Contains("bottom"))
            {
                relativeY = VertAlignments.Bottom_Adjustable;
            }

            if (relativePoint.Contains("left"))
            {
                relativeX = HorzAlignments.Left_Adjustable;
            }

            else if (relativePoint.Contains("right"))
            {
                relativeX = HorzAlignments.Right_Adjustable;
            }

            if (element.Entity == null)
            {
                HorzAlign = relativeX;
                VertAlign = relativeY;
            }
            else
            {
                HorzAlign = element.HorzAlign;
                VertAlign = element.VertAlign;
            }

            var xFactor = 0;
            var yFactor = 0;
            var offsetX = 0;
            var offsetY = 0;

            if (relativeX.ToString().Split('_')[0] == element.AlignX.ToString())
            {
                offsetX = 0;
                xFactor = 0;
            }
            else if (relativeX == HorzAlignments.Center || element.AlignX == XAlignments.Center)
            {
                offsetX = (element.Width == 0) ? 0 : (element.Width / 2);

                if (relativeX == HorzAlignments.Left_Adjustable || element.AlignX == XAlignments.Right)
                {
                    xFactor = -1;
                }
                else
                {
                    xFactor = 1;
                }
            }
            else
            {
                offsetX = element.Width;

                if (relativeX == HorzAlignments.Left_Adjustable)
                {
                    xFactor = -1;
                }
                else
                {
                    xFactor = 1;
                }
            }

            X = element.X + (offsetX * xFactor);

            if (relativeY.ToString().Split('_')[0] == element.AlignY.ToString())
            {
                offsetY = 0;
                yFactor = 0;
            }
            else if (relativeY == VertAlignments.Middle || element.AlignY == YAlignments.Middle)
            {
                offsetY = (element.Height == 0) ? 0 : (element.Height / 2);

                if (relativeY == VertAlignments.Top_Adjustable || element.AlignY == YAlignments.Bottom)
                {
                    yFactor = -1;
                }
                else
                {
                    yFactor = 1;
                }
            }
            else
            {
                offsetY = element.Height;

                if (relativeY == VertAlignments.Top_Adjustable)
                {
                    yFactor = -1;
                }
                else
                {
                    yFactor = 1;
                }
            }

            Y = element.Y + (offsetY * yFactor);

            X += _xOffset;
            Y += _yOffset;

            // setpointbar stuff
            
            UpdateChildren();
        }

        private void UpdateChildren()
        {
            foreach (var child in Children)
            {
                child.SetPoint(child._point, child._relativePoint, child._xOffset, child._yOffset);
            }
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public string Shader
        {
            get { return _shader;}
            set { this.SetShader(value); _shader = value; }
        }

        private int _xOffset;
        private int _yOffset;
        private string _point;
        private string _relativePoint;
        internal string _shader = "";
        #endregion
        #endregion
    }
}
