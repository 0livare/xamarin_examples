using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChefTest4.BlackCat
{
    class BlackCatPage : ContentPage
    {
        public BlackCatPage()
        {
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10
            };

            // Get access to the text resource
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            string resource = "ChefTest4.BlackCat.Texts.TheBlackCat.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string title = reader.ReadLine();
                    Label lblTitle = new Label
                    {
                        Text = title,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    };
                    mainStack.Children.Add(lblTitle);

                    for (string line; (line=reader.ReadLine()) != null;)
                    {
                        Label label = new Label
                        {
                            Text = line,
                            TextColor = Color.Black
                        };
                        textStack.Children.Add(label);
                    }
                }

                ScrollView scroll = new ScrollView
                {
                    Content = textStack,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(5, 0)
                };

                mainStack.Children.Add(scroll);
                Content = mainStack;
                BackgroundColor = Color.White;
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            }


        }
    }
}
