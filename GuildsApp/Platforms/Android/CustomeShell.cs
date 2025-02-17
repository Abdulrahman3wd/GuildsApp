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
            // Dispose resources if needed
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
            // Reset appearance if needed
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            // Set label visibility mode
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;

            // Set icon size
            bottomView.ItemIconSize = 75;

            // Set background with rounded corners
            var backgroundDrawable = ContextCompat.GetDrawable(bottomView.Context, Resource.Drawable.rounded_bottom_nav_background);
            if (backgroundDrawable != null)
            {
                bottomView.Background = backgroundDrawable;
            }

            // Set default icon tint (unselected state)
            bottomView.ItemIconTintList = ColorStateList.ValueOf(Colors.White.ToPlatform());

            // Set padding
            bottomView.SetPadding(50, 20, 50, 0);

            // Remove elevation
            bottomView.Elevation = 0;

            // Customize selected tab icon color
            var colorStateList = new ColorStateList(
                new int[][]
                {
            new int[] { global::Android.Resource.Attribute.StateChecked }, // Selected state
            new int[] { -global::Android.Resource.Attribute.StateChecked } // Default state
                },
                new int[]
                {
            Color.FromRgb(212, 83, 18).ToPlatform(), // Selected color
            Colors.Black.ToPlatform() // Default color
                }
            );

            bottomView.ItemIconTintList = colorStateList;
        }
    }
}