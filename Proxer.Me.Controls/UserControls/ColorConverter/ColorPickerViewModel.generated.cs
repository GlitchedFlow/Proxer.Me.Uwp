﻿//<auto-generated/>
#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2015.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace UWPColorPickerSample
{
    /// <summary>
    /// カラーピッカーの ViewModel
    /// </summary>
    public partial class ColorPickerViewModel : BindableBase
    {
        #region Color:カラーコード プロパティ
        /// <summary>
        /// カラーコード
        /// </summary>
        private string color;

        /// <summary>
        /// カラーコード の変更前の処理
        /// </summary>
        partial void OnColorChanging(ref string value);

        /// <summary>
        /// カラーコード の変更後の処理
        /// </summary>
        partial void OnColorChanged();

        /// <summary>
        /// カラーコード の取得および設定
        /// </summary>
        
        public string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                if (this.color != value)
                {
                    this.OnColorChanging(ref value);
                    this.Set<string>(ref this.color, value);
                    this.OnColorChanged();
                }
            }
        }
        #endregion //Color:カラーコード プロパティ

        #region Red:赤成分 プロパティ
        /// <summary>
        /// 赤成分
        /// </summary>
        private int red;

        /// <summary>
        /// 赤成分 の変更前の処理
        /// </summary>
        partial void OnRedChanging(ref int value);

        /// <summary>
        /// 赤成分 の変更後の処理
        /// </summary>
        partial void OnRedChanged();

        /// <summary>
        /// 赤成分 の取得および設定
        /// </summary>
        
        public int Red
        {
            get
            {
                return this.red;
            }

            set
            {
                if (this.red != value)
                {
                    this.OnRedChanging(ref value);
                    this.Set<int>(ref this.red, value);
                    this.OnRedChanged();
                }
            }
        }
        #endregion //Red:赤成分 プロパティ

        #region RedString:赤成分文字列 プロパティ
        /// <summary>
        /// 赤成分文字列
        /// </summary>
        private string redString;

        /// <summary>
        /// 赤成分文字列 の変更前の処理
        /// </summary>
        partial void OnRedStringChanging(ref string value);

        /// <summary>
        /// 赤成分文字列 の変更後の処理
        /// </summary>
        partial void OnRedStringChanged();

        /// <summary>
        /// 赤成分文字列 の取得および設定
        /// </summary>
        
        public string RedString
        {
            get
            {
                return this.redString;
            }

            set
            {
                if (this.redString != value)
                {
                    this.OnRedStringChanging(ref value);
                    this.Set<string>(ref this.redString, value);
                    this.OnRedStringChanged();
                }
            }
        }
        #endregion //RedString:赤成分文字列 プロパティ

        #region Green:緑成分 プロパティ
        /// <summary>
        /// 緑成分
        /// </summary>
        private int green;

        /// <summary>
        /// 緑成分 の変更前の処理
        /// </summary>
        partial void OnGreenChanging(ref int value);

        /// <summary>
        /// 緑成分 の変更後の処理
        /// </summary>
        partial void OnGreenChanged();

        /// <summary>
        /// 緑成分 の取得および設定
        /// </summary>
        
        public int Green
        {
            get
            {
                return this.green;
            }

            set
            {
                if (this.green != value)
                {
                    this.OnGreenChanging(ref value);
                    this.Set<int>(ref this.green, value);
                    this.OnGreenChanged();
                }
            }
        }
        #endregion //Green:緑成分 プロパティ

        #region GreenString:緑成分文字列 プロパティ
        /// <summary>
        /// 緑成分文字列
        /// </summary>
        private string greenString;

        /// <summary>
        /// 緑成分文字列 の変更前の処理
        /// </summary>
        partial void OnGreenStringChanging(ref string value);

        /// <summary>
        /// 緑成分文字列 の変更後の処理
        /// </summary>
        partial void OnGreenStringChanged();

        /// <summary>
        /// 緑成分文字列 の取得および設定
        /// </summary>
        
        public string GreenString
        {
            get
            {
                return this.greenString;
            }

            set
            {
                if (this.greenString != value)
                {
                    this.OnGreenStringChanging(ref value);
                    this.Set<string>(ref this.greenString, value);
                    this.OnGreenStringChanged();
                }
            }
        }
        #endregion //GreenString:緑成分文字列 プロパティ

        #region Blue:青成分 プロパティ
        /// <summary>
        /// 青成分
        /// </summary>
        private int blue;

        /// <summary>
        /// 青成分 の変更前の処理
        /// </summary>
        partial void OnBlueChanging(ref int value);

        /// <summary>
        /// 青成分 の変更後の処理
        /// </summary>
        partial void OnBlueChanged();

        /// <summary>
        /// 青成分 の取得および設定
        /// </summary>
        
        public int Blue
        {
            get
            {
                return this.blue;
            }

            set
            {
                if (this.blue != value)
                {
                    this.OnBlueChanging(ref value);
                    this.Set<int>(ref this.blue, value);
                    this.OnBlueChanged();
                }
            }
        }
        #endregion //Blue:青成分 プロパティ

        #region BlueString:青成分文字列 プロパティ
        /// <summary>
        /// 青成分文字列
        /// </summary>
        private string blueString;

        /// <summary>
        /// 青成分文字列 の変更前の処理
        /// </summary>
        partial void OnBlueStringChanging(ref string value);

        /// <summary>
        /// 青成分文字列 の変更後の処理
        /// </summary>
        partial void OnBlueStringChanged();

        /// <summary>
        /// 青成分文字列 の取得および設定
        /// </summary>
        
        public string BlueString
        {
            get
            {
                return this.blueString;
            }

            set
            {
                if (this.blueString != value)
                {
                    this.OnBlueStringChanging(ref value);
                    this.Set<string>(ref this.blueString, value);
                    this.OnBlueStringChanged();
                }
            }
        }
        #endregion //BlueString:青成分文字列 プロパティ

        #region Alpha:アルファ値 プロパティ
        /// <summary>
        /// アルファ値
        /// </summary>
        private int alpha;

        /// <summary>
        /// アルファ値 の変更前の処理
        /// </summary>
        partial void OnAlphaChanging(ref int value);

        /// <summary>
        /// アルファ値 の変更後の処理
        /// </summary>
        partial void OnAlphaChanged();

        /// <summary>
        /// アルファ値 の取得および設定
        /// </summary>
        
        public int Alpha
        {
            get
            {
                return this.alpha;
            }

            set
            {
                if (this.alpha != value)
                {
                    this.OnAlphaChanging(ref value);
                    this.Set<int>(ref this.alpha, value);
                    this.OnAlphaChanged();
                }
            }
        }
        #endregion //Alpha:アルファ値 プロパティ

        #region AlphaString:アルファ値文字列 プロパティ
        /// <summary>
        /// アルファ値文字列
        /// </summary>
        private string alphaString;

        /// <summary>
        /// アルファ値文字列 の変更前の処理
        /// </summary>
        partial void OnAlphaStringChanging(ref string value);

        /// <summary>
        /// アルファ値文字列 の変更後の処理
        /// </summary>
        partial void OnAlphaStringChanged();

        /// <summary>
        /// アルファ値文字列 の取得および設定
        /// </summary>
        
        public string AlphaString
        {
            get
            {
                return this.alphaString;
            }

            set
            {
                if (this.alphaString != value)
                {
                    this.OnAlphaStringChanging(ref value);
                    this.Set<string>(ref this.alphaString, value);
                    this.OnAlphaStringChanged();
                }
            }
        }
        #endregion //AlphaString:アルファ値文字列 プロパティ

        #region PickPointX:カラーピックX座標 プロパティ
        /// <summary>
        /// カラーピックX座標
        /// </summary>
        private double pickPointX;

        /// <summary>
        /// カラーピックX座標 の変更前の処理
        /// </summary>
        partial void OnPickPointXChanging(ref double value);

        /// <summary>
        /// カラーピックX座標 の変更後の処理
        /// </summary>
        partial void OnPickPointXChanged();

        /// <summary>
        /// カラーピックX座標 の取得および設定
        /// </summary>
        
        public double PickPointX
        {
            get
            {
                return this.pickPointX;
            }

            set
            {
                if (this.pickPointX != value)
                {
                    this.OnPickPointXChanging(ref value);
                    this.Set<double>(ref this.pickPointX, value);
                    this.OnPickPointXChanged();
                }
            }
        }
        #endregion //PickPointX:カラーピックX座標 プロパティ

        #region PickPointY:カラーピックY座標 プロパティ
        /// <summary>
        /// カラーピックY座標
        /// </summary>
        private double pickPointY;

        /// <summary>
        /// カラーピックY座標 の変更前の処理
        /// </summary>
        partial void OnPickPointYChanging(ref double value);

        /// <summary>
        /// カラーピックY座標 の変更後の処理
        /// </summary>
        partial void OnPickPointYChanged();

        /// <summary>
        /// カラーピックY座標 の取得および設定
        /// </summary>
        
        public double PickPointY
        {
            get
            {
                return this.pickPointY;
            }

            set
            {
                if (this.pickPointY != value)
                {
                    this.OnPickPointYChanging(ref value);
                    this.Set<double>(ref this.pickPointY, value);
                    this.OnPickPointYChanged();
                }
            }
        }
        #endregion //PickPointY:カラーピックY座標 プロパティ

        #region HueColor:色相カラーコード プロパティ
        /// <summary>
        /// 色相カラーコード
        /// </summary>
        private string hueColor;

        /// <summary>
        /// 色相カラーコード の変更前の処理
        /// </summary>
        partial void OnHueColorChanging(ref string value);

        /// <summary>
        /// 色相カラーコード の変更後の処理
        /// </summary>
        partial void OnHueColorChanged();

        /// <summary>
        /// 色相カラーコード の取得および設定
        /// </summary>
        
        public string HueColor
        {
            get
            {
                return this.hueColor;
            }

            set
            {
                if (this.hueColor != value)
                {
                    this.OnHueColorChanging(ref value);
                    this.Set<string>(ref this.hueColor, value);
                    this.OnHueColorChanged();
                }
            }
        }
        #endregion //HueColor:色相カラーコード プロパティ

        #region ColorSpectrumPoint:色相座標 プロパティ
        /// <summary>
        /// 色相座標
        /// </summary>
        private double colorSpectrumPoint;

        /// <summary>
        /// 色相座標 の変更前の処理
        /// </summary>
        partial void OnColorSpectrumPointChanging(ref double value);

        /// <summary>
        /// 色相座標 の変更後の処理
        /// </summary>
        partial void OnColorSpectrumPointChanged();

        /// <summary>
        /// 色相座標 の取得および設定
        /// </summary>
        
        public double ColorSpectrumPoint
        {
            get
            {
                return this.colorSpectrumPoint;
            }

            set
            {
                if (this.colorSpectrumPoint != value)
                {
                    this.OnColorSpectrumPointChanging(ref value);
                    this.Set<double>(ref this.colorSpectrumPoint, value);
                    this.OnColorSpectrumPointChanged();
                }
            }
        }
        #endregion //ColorSpectrumPoint:色相座標 プロパティ

        #region RedStartColor:赤成分開始カラーコード プロパティ
        /// <summary>
        /// 赤成分開始カラーコード
        /// </summary>
        private string redStartColor;

        /// <summary>
        /// 赤成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnRedStartColorChanging(ref string value);

        /// <summary>
        /// 赤成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnRedStartColorChanged();

        /// <summary>
        /// 赤成分開始カラーコード の取得および設定
        /// </summary>
        
        public string RedStartColor
        {
            get
            {
                return this.redStartColor;
            }

            set
            {
                if (this.redStartColor != value)
                {
                    this.OnRedStartColorChanging(ref value);
                    this.Set<string>(ref this.redStartColor, value);
                    this.OnRedStartColorChanged();
                }
            }
        }
        #endregion //RedStartColor:赤成分開始カラーコード プロパティ

        #region RedEndColor:赤成分開始カラーコード プロパティ
        /// <summary>
        /// 赤成分開始カラーコード
        /// </summary>
        private string redEndColor;

        /// <summary>
        /// 赤成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnRedEndColorChanging(ref string value);

        /// <summary>
        /// 赤成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnRedEndColorChanged();

        /// <summary>
        /// 赤成分開始カラーコード の取得および設定
        /// </summary>
        
        public string RedEndColor
        {
            get
            {
                return this.redEndColor;
            }

            set
            {
                if (this.redEndColor != value)
                {
                    this.OnRedEndColorChanging(ref value);
                    this.Set<string>(ref this.redEndColor, value);
                    this.OnRedEndColorChanged();
                }
            }
        }
        #endregion //RedEndColor:赤成分開始カラーコード プロパティ

        #region GreenStartColor:緑成分開始カラーコード プロパティ
        /// <summary>
        /// 緑成分開始カラーコード
        /// </summary>
        private string greenStartColor;

        /// <summary>
        /// 緑成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnGreenStartColorChanging(ref string value);

        /// <summary>
        /// 緑成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnGreenStartColorChanged();

        /// <summary>
        /// 緑成分開始カラーコード の取得および設定
        /// </summary>
        
        public string GreenStartColor
        {
            get
            {
                return this.greenStartColor;
            }

            set
            {
                if (this.greenStartColor != value)
                {
                    this.OnGreenStartColorChanging(ref value);
                    this.Set<string>(ref this.greenStartColor, value);
                    this.OnGreenStartColorChanged();
                }
            }
        }
        #endregion //GreenStartColor:緑成分開始カラーコード プロパティ

        #region GreenEndColor:緑成分開始カラーコード プロパティ
        /// <summary>
        /// 緑成分開始カラーコード
        /// </summary>
        private string greenEndColor;

        /// <summary>
        /// 緑成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnGreenEndColorChanging(ref string value);

        /// <summary>
        /// 緑成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnGreenEndColorChanged();

        /// <summary>
        /// 緑成分開始カラーコード の取得および設定
        /// </summary>
        
        public string GreenEndColor
        {
            get
            {
                return this.greenEndColor;
            }

            set
            {
                if (this.greenEndColor != value)
                {
                    this.OnGreenEndColorChanging(ref value);
                    this.Set<string>(ref this.greenEndColor, value);
                    this.OnGreenEndColorChanged();
                }
            }
        }
        #endregion //GreenEndColor:緑成分開始カラーコード プロパティ

        #region BlueStartColor:青成分開始カラーコード プロパティ
        /// <summary>
        /// 青成分開始カラーコード
        /// </summary>
        private string blueStartColor;

        /// <summary>
        /// 青成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnBlueStartColorChanging(ref string value);

        /// <summary>
        /// 青成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnBlueStartColorChanged();

        /// <summary>
        /// 青成分開始カラーコード の取得および設定
        /// </summary>
        
        public string BlueStartColor
        {
            get
            {
                return this.blueStartColor;
            }

            set
            {
                if (this.blueStartColor != value)
                {
                    this.OnBlueStartColorChanging(ref value);
                    this.Set<string>(ref this.blueStartColor, value);
                    this.OnBlueStartColorChanged();
                }
            }
        }
        #endregion //BlueStartColor:青成分開始カラーコード プロパティ

        #region BlueEndColor:青成分開始カラーコード プロパティ
        /// <summary>
        /// 青成分開始カラーコード
        /// </summary>
        private string blueEndColor;

        /// <summary>
        /// 青成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnBlueEndColorChanging(ref string value);

        /// <summary>
        /// 青成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnBlueEndColorChanged();

        /// <summary>
        /// 青成分開始カラーコード の取得および設定
        /// </summary>
        
        public string BlueEndColor
        {
            get
            {
                return this.blueEndColor;
            }

            set
            {
                if (this.blueEndColor != value)
                {
                    this.OnBlueEndColorChanging(ref value);
                    this.Set<string>(ref this.blueEndColor, value);
                    this.OnBlueEndColorChanged();
                }
            }
        }
        #endregion //BlueEndColor:青成分開始カラーコード プロパティ

        #region AlphaStartColor:青成分開始カラーコード プロパティ
        /// <summary>
        /// 青成分開始カラーコード
        /// </summary>
        private string alphaStartColor;

        /// <summary>
        /// 青成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnAlphaStartColorChanging(ref string value);

        /// <summary>
        /// 青成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnAlphaStartColorChanged();

        /// <summary>
        /// 青成分開始カラーコード の取得および設定
        /// </summary>
        
        public string AlphaStartColor
        {
            get
            {
                return this.alphaStartColor;
            }

            set
            {
                if (this.alphaStartColor != value)
                {
                    this.OnAlphaStartColorChanging(ref value);
                    this.Set<string>(ref this.alphaStartColor, value);
                    this.OnAlphaStartColorChanged();
                }
            }
        }
        #endregion //AlphaStartColor:青成分開始カラーコード プロパティ

        #region AlphaEndColor:青成分開始カラーコード プロパティ
        /// <summary>
        /// 青成分開始カラーコード
        /// </summary>
        private string alphaEndColor;

        /// <summary>
        /// 青成分開始カラーコード の変更前の処理
        /// </summary>
        partial void OnAlphaEndColorChanging(ref string value);

        /// <summary>
        /// 青成分開始カラーコード の変更後の処理
        /// </summary>
        partial void OnAlphaEndColorChanged();

        /// <summary>
        /// 青成分開始カラーコード の取得および設定
        /// </summary>
        
        public string AlphaEndColor
        {
            get
            {
                return this.alphaEndColor;
            }

            set
            {
                if (this.alphaEndColor != value)
                {
                    this.OnAlphaEndColorChanging(ref value);
                    this.Set<string>(ref this.alphaEndColor, value);
                    this.OnAlphaEndColorChanged();
                }
            }
        }
        #endregion //AlphaEndColor:青成分開始カラーコード プロパティ
    }
}
