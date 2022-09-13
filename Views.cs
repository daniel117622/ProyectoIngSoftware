using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlankApp
{
    internal class Views
    {
        public static View CreateColorFrame(Color color,string name)
        {
            return new Frame
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                     {
                     new BoxView
                     {
                        Color = color
                     },
                    new Label
                    {
                        Text = name,
                        TextColor = Color.Black,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                     },
                     new StackLayout
                    {
                        Children =
                            {
                             new Label
                            {
                             Text = String.Format("{0:X2}-{1:X2}-{2:X2}",(int)(255 * color.R),(int)(255 * color.G),(int)(255 * color.B)),
                             TextColor = Color.Black,
                             VerticalOptions = LayoutOptions.CenterAndExpand,
                             IsVisible = color != Color.Default
                             },
                            new Label
                            {
                             Text = String.Format("{0:F2}, {1:F2}, {2:F2}", color.Hue,color.Saturation,color.Luminosity),
                             TextColor = Color.Black,
                             VerticalOptions = LayoutOptions.CenterAndExpand,
                             IsVisible = color != Color.Default
                            }
                     }
                        ,HorizontalOptions = LayoutOptions.End
                     }
                   }
                }
            };
        }
    }
}

