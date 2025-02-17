using Android.Content.Res;
using AndroidX.Core.Content;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildsApp.Platforms.Android
{
    public class CustomeShell : ShellRenderer
    {
        public CustomeShell()
        {

        }
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomeShellBottomViewAppearance();
        }
    }

    public class CustomeShellBottomViewAppearance : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;

            bottomView.ItemIconSize = 75;

            var backgroundDrawable = ContextCompat.GetDrawable(bottomView.Context, Resource.Drawable.rounded_bottom_nav_background);
            if (backgroundDrawable != null)
            {
                bottomView.Background = backgroundDrawable;
            }

            bottomView.ItemIconTintList = ColorStateList.ValueOf(Colors.White.ToPlatform());

            bottomView.SetPadding(50, 20, 50, 0);

            bottomView.Elevation = 0;

            var colorStateList = new ColorStateList(
                new int[][]
                {
            new int[] { global::Android.Resource.Attribute.StateChecked }, // Selected state
            new int[] { -global::Android.Resource.Attribute.StateChecked } // Default state
                },
                new int[]
                {
            Color.FromRgb(75, 168, 224).ToPlatform(), // Selected color
            Colors.Black.ToPlatform() // Default color
                }
            );

            bottomView.ItemIconTintList = colorStateList;
        }
    }
}